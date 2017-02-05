//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Transactions;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseWorkFlowCurrentManager
    /// 流程管理.
    /// 
    /// 修改纪录
    ///		
    ///		2012.04.04 版本：1.0 JiRiGaLa	脱离。
    /// 
    /// 版本：1.0
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.04.04</date>
    /// </author>
    /// </summary>
    public partial class BaseWorkFlowCurrentManager : BaseManager, IBaseManager
    {
        //-----------------------------------------------------
        //                  启动工作流 步骤流
        //-----------------------------------------------------

        /// <summary>
        /// 启动工作流（步骤流转）
        /// </summary>
        /// <param name="workFlowManager">审批流程管理器</param>
        /// <param name="objectId">单据主键</param>
        /// <param name="objectFullName">单据名称</param>
        /// <param name="categoryCode">单据分类</param>
        /// <param name="categoryFullName">单据分类名称</param>
        /// <param name="workFlowCode">工作流程</param>
        /// <param name="auditIdea">审批意见</param>
        /// <param name="dtWorkFlowActivity">需要走的流程</param>
        /// <returns>主键</returns>
        public string AutoStatr(IWorkFlowManager workFlowManager, string objectId, string objectFullName, string categoryCode, string categoryFullName = null, string workFlowCode = null, string auditIdea = null, DataTable dtWorkFlowActivity = null)
        {
            string currentId = string.Empty;
            if (dtWorkFlowActivity == null || dtWorkFlowActivity.Rows.Count == 0)
            {
                return currentId;
            }
            lock (WorkFlowCurrentLock)
            {
                BaseWorkFlowStepEntity workFlowStepEntity = null;
                // 这里需要读取一下
                if (dtWorkFlowActivity == null)
                {

                }
                workFlowStepEntity = new BaseWorkFlowStepEntity(dtWorkFlowActivity.Rows[0]);
                if (!string.IsNullOrEmpty(workFlowStepEntity.AuditUserId))
                {
                    // 若是任意人可以审核的,需要进行一次人工选任的工作
                    if (workFlowStepEntity.AuditUserId.Equals("Anyone"))
                    {
                        return null;
                    }
                }
                // 1. 先把已有的流程设置功能都删除掉
                BaseWorkFlowStepManager workFlowStepManager = new BaseWorkFlowStepManager(this.DbHelper, this.UserInfo);
                workFlowStepManager.Delete(
                    new KeyValuePair<string, object>(BaseWorkFlowStepEntity.FieldCategoryCode, categoryCode)
                    , new KeyValuePair<string, object>(BaseWorkFlowStepEntity.FieldObjectId, objectId));
                // 2. 把当前的流程设置保存好
                foreach (DataRow dataRow in dtWorkFlowActivity.Rows)
                {
                    workFlowStepEntity = new BaseWorkFlowStepEntity(dataRow);
                    workFlowStepEntity.ActivityId = workFlowStepEntity.Id;
                    workFlowStepEntity.CategoryCode = categoryCode;
                    workFlowStepEntity.ObjectId = objectId;
                    workFlowStepEntity.Id = null;
                    workFlowStepManager.Add(workFlowStepEntity);
                }
                workFlowStepEntity = new BaseWorkFlowStepEntity(dtWorkFlowActivity.Rows[0]);

                // 3. 启动审核流程
                currentId = this.GetCurrentId(categoryCode, objectId);
                BaseWorkFlowCurrentEntity workFlowCurrentEntity = null;
                if (currentId.Length > 0)
                {
                    // 获取当前处于什么状态
                    string auditstatus = this.GetProperty(currentId, BaseWorkFlowCurrentEntity.FieldAuditStatus);
                    // 如果还是开始审批状态的话，允许他再次提交把原来的覆盖掉
                    if (auditstatus == AuditStatus.StartAudit.ToString())
                    {
                        this.UpdataAuditStatr(currentId, categoryCode, categoryFullName, objectId, objectFullName, auditIdea, workFlowStepEntity);
                    }
                    // 不是的话则返回
                    else
                    {
                        // 该单据已进入审核状态不能在次提交
                        this.ReturnStatusCode = StatusCode.ErrorChanged.ToString();
                        // 返回为空可以判断
                        currentId = null;
                    }
                }
                else
                {
                    workFlowManager.BeforeAutoStatr(objectId);
                    currentId = this.StepAuditStatr(categoryCode, categoryFullName, objectId, objectFullName, auditIdea, workFlowStepEntity);
                    workFlowCurrentEntity = this.GetEntity(currentId);
                    // 发送提醒信息，若发给指定的某个人了，就不发给部门的提示信息了
                    if (workFlowManager != null)
                    {
                        if (!string.IsNullOrEmpty(workFlowStepEntity.AuditUserId))
                        {
                            workFlowStepEntity.AuditDepartmentId = null;
                            workFlowStepEntity.AuditRoleId = null;
                        }
                        workFlowManager.SendRemindMessage(workFlowCurrentEntity, AuditStatus.StartAudit, new string[] { workFlowCurrentEntity.CreateUserId, workFlowStepEntity.AuditUserId }, workFlowStepEntity.AuditDepartmentId, workFlowStepEntity.AuditRoleId);
                    }
                    // 成功工作流后的处理
                    if (!string.IsNullOrEmpty(objectId))
                    {
                        workFlowManager.AfterAutoStatr(objectId);
                    }
                    // 运行成功
                    this.ReturnStatusCode = StatusCode.OK.ToString();
                    this.ReturnStatusMessage = this.GetStateMessage(this.ReturnStatusCode);
                }
            }
            return currentId;
        }

        private int UpdataAuditStatr(string id, string categoryCode, string categoryFullName, string objectId, string objectFullName, string auditIdea, BaseWorkFlowStepEntity workFlowStepEntity)
        {
            BaseWorkFlowCurrentEntity workFlowCurrentEntity = this.GetEntity(id);
            workFlowCurrentEntity.CategoryCode = categoryCode;
            workFlowCurrentEntity.CategoryFullName = categoryFullName;
            workFlowCurrentEntity.ObjectId = objectId;
            workFlowCurrentEntity.ObjectFullName = objectFullName;
            workFlowCurrentEntity.WorkFlowId = workFlowStepEntity.WorkFlowId;
            workFlowCurrentEntity.ActivityId = workFlowStepEntity.Id;
            workFlowCurrentEntity.SendDate = DateTime.Now;
            workFlowCurrentEntity.AuditDate = DateTime.Now;
            workFlowCurrentEntity.AuditStatus = AuditStatus.StartAudit.ToString();
            workFlowCurrentEntity.AuditStatusName = AuditStatus.StartAudit.ToDescription();

            // 是否提交给组织机构审批
            if (!string.IsNullOrEmpty(workFlowStepEntity.AuditDepartmentId))
            {
                workFlowCurrentEntity.ToDepartmentId = workFlowStepEntity.AuditDepartmentId;
                workFlowCurrentEntity.ToDepartmentName = workFlowStepEntity.AuditDepartmentName;
            }
            // 是否提交给角色审批
            if (!string.IsNullOrEmpty(workFlowStepEntity.AuditRoleId))
            {
                workFlowCurrentEntity.ToDepartmentId = workFlowStepEntity.AuditRoleId;
                workFlowCurrentEntity.ToDepartmentName = workFlowStepEntity.AuditRoleRealName;
            }
            // 是否提交给用户审批
            if (!string.IsNullOrEmpty(workFlowStepEntity.AuditUserId))
            {
                BaseUserManager userManager = new BaseUserManager(UserInfo);
                BaseUserEntity userEntity = userManager.GetEntity(workFlowStepEntity.AuditUserId);
                workFlowCurrentEntity.ToUserId = workFlowStepEntity.AuditUserId;
                workFlowCurrentEntity.ToUserRealName = userEntity.RealName;
                // TODO 用户的部门信息需要处理
                if (!string.IsNullOrEmpty(userEntity.DepartmentId))
                {
                    BaseOrganizeManager organizeManager = new BaseOrganizeManager(UserInfo);
                    BaseOrganizeEntity organizeEntity = organizeManager.GetEntity(userEntity.DepartmentId);
                    workFlowCurrentEntity.ToDepartmentId = userEntity.DepartmentId;
                    workFlowCurrentEntity.ToDepartmentName = organizeEntity.FullName;
                }
            }
            // 当前审核人的信息写入当前工作流
            // workFlowCurrentEntity.AuditUserId = this.UserInfo.Id;
            // workFlowCurrentEntity.AuditUserCode = this.UserInfo.Code;
            // workFlowCurrentEntity.AuditUserRealName = this.UserInfo.RealName;
            workFlowCurrentEntity.AuditIdea = auditIdea;
            workFlowCurrentEntity.AuditDate = DateTime.Now;
            return this.UpdateEntity(workFlowCurrentEntity);
        }

        private string StepAuditStatr(string categoryCode, string categoryFullName, string objectId, string objectFullName, string auditIdea, BaseWorkFlowStepEntity workFlowStepEntity)
        {
            BaseWorkFlowCurrentEntity workFlowCurrentEntity = new BaseWorkFlowCurrentEntity();
            // 1.这个是工作流的第一个发出日期，需要全局保留，其实也是创建日期了，但是有重新审核的这个说法，若有2次重新审核的事项，的确需要保留这个字段
            // workFlowCurrentEntity.CallBack = workFlowManager.GetType().ToString();
            workFlowCurrentEntity.WorkFlowId = workFlowStepEntity.WorkFlowId;
            workFlowCurrentEntity.ActivityId = workFlowStepEntity.Id;
            // 这里是为了优化越级审核用的，按排序嘛进行先后顺序排序
            BaseWorkFlowActivityManager workFlowActivityManager = new BaseWorkFlowActivityManager(this.DbHelper, this.UserInfo);
            workFlowCurrentEntity.CategoryCode = categoryCode;
            workFlowCurrentEntity.CategoryFullName = categoryFullName;
            workFlowCurrentEntity.ObjectId = objectId;
            workFlowCurrentEntity.ObjectFullName = objectFullName;
            // 2.当前审核人的信息写入当前工作流
            // workFlowCurrentEntity.AuditUserId = this.UserInfo.Id;
            // workFlowCurrentEntity.AuditUserCode = this.UserInfo.Code;
            // workFlowCurrentEntity.AuditUserRealName = this.UserInfo.RealName;
            workFlowCurrentEntity.AuditIdea = auditIdea;
            workFlowCurrentEntity.AuditStatus = AuditStatus.StartAudit.ToString();
            workFlowCurrentEntity.AuditStatusName = AuditStatus.StartAudit.ToDescription();
            workFlowCurrentEntity.SendDate = DateTime.Now;
            // 3.接下来需要待审核的对象的信息
            workFlowCurrentEntity.ToUserId = workFlowStepEntity.AuditUserId;
            workFlowCurrentEntity.ToUserRealName = workFlowStepEntity.AuditUserRealName;
            workFlowCurrentEntity.ToDepartmentId = workFlowStepEntity.AuditDepartmentId;
            workFlowCurrentEntity.ToDepartmentName = workFlowStepEntity.AuditDepartmentName;
            workFlowCurrentEntity.ToRoleId = workFlowStepEntity.AuditRoleId;
            workFlowCurrentEntity.ToRoleRealName = workFlowStepEntity.AuditRoleRealName;
            // 4.这些标志信息需要处理好，这里表示工作流还没完成生效，还在审批中的意思。
            workFlowCurrentEntity.SortCode = workFlowStepEntity.SortCode;
            workFlowCurrentEntity.Enabled = 0;
            workFlowCurrentEntity.DeletionStateCode = 0;
            return this.AddEntity(workFlowCurrentEntity);
        }
    }
}