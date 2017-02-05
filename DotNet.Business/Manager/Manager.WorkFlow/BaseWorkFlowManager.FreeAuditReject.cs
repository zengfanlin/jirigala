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
        public int FreeAuditReject(string currentId, string toUserId, string toDepartmentId = null, string toRoleId = null, string auditIdea = null)
        {
            IWorkFlowManager workFlowManager = this.GetWorkFlowManager(currentId);
            workFlowManager.SetUserInfo(this.UserInfo);
            return FreeAuditReject(workFlowManager, currentId, toUserId, toDepartmentId, toRoleId, auditIdea);
        }

        #region public int FreeAuditReject(IWorkFlowManager workFlowManager, string currentId, string toUserId, string toDepartmentId = null, string toRoleId = null, string auditIdea = null) 自由审批
        /// <summary>
        /// 自由审批退回
        /// </summary>
        /// <param name="workFlowManager"></param>
        /// <param name="currentId"></param>
        /// <param name="toUserId"></param>
        /// <param name="toDepartmentId"></param>
        /// <param name="toRoleId"></param>
        /// <param name="auditIdea"></param>
        /// <returns></returns>
        public int FreeAuditReject(IWorkFlowManager workFlowManager, string currentId, string toUserId, string toDepartmentId = null, string toRoleId = null, string auditIdea = null)
        {
            // 返回值
            int returnValue = 0;
            // 这里用锁的机制，提高并发控制能力
            lock (WorkFlowCurrentLock)
            {
                BaseWorkFlowCurrentEntity workFlowCurrentEntity = this.GetEntity(currentId);
                BaseWorkFlowActivityEntity workFlowActivityEntity = new BaseWorkFlowActivityEntity();
                // FreeWorkFlow 自由工作流
                workFlowActivityEntity.WorkFlowId = 0;
                // 获取排序码
                workFlowActivityEntity.SortCode = int.Parse(new BaseSequenceManager().GetSequence("FreeWorkFlow", 10000000));
                
                // 若都没接收的人，就发给创建人
                if (string.IsNullOrEmpty(toUserId) && string.IsNullOrEmpty(toDepartmentId) && string.IsNullOrEmpty(toRoleId))
                {  
                    toUserId = workFlowCurrentEntity.CreateUserId;
                }
                // 是否提交给用户审批
                if (!string.IsNullOrEmpty(toUserId))
                {
                    workFlowActivityEntity.AuditUserId = toUserId;
                    workFlowActivityEntity.AuditUserRealName = new BaseUserManager().GetEntity(toUserId).RealName;
                }
                // 是否提交给部门审批
                if (!string.IsNullOrEmpty(toDepartmentId))
                {
                    workFlowActivityEntity.AuditDepartmentId = toDepartmentId;
                    workFlowActivityEntity.AuditDepartmentName = new BaseOrganizeManager().GetEntity(toDepartmentId).FullName;
                }
                // 是否提交给角色审批
                if (!string.IsNullOrEmpty(toRoleId))
                {
                    workFlowActivityEntity.AuditRoleId = toRoleId;
                    workFlowActivityEntity.AuditRoleRealName = new BaseRoleManager().GetEntity(toRoleId).RealName;
                }
                // 进行更新操作
                returnValue = this.StepAuditReject(currentId, auditIdea, workFlowActivityEntity);
                if (returnValue == 0)
                {
                    // 数据可能被删除
                    this.ReturnStatusCode = StatusCode.ErrorDeleted.ToString();
                }
                workFlowCurrentEntity = this.GetEntity(currentId);
                // 发送提醒信息
                if (workFlowManager != null)
                {
                    if (!string.IsNullOrEmpty(workFlowActivityEntity.AuditUserId))
                    {
                        workFlowActivityEntity.AuditDepartmentId = null;
                        workFlowActivityEntity.AuditRoleId = null;
                    }
                    workFlowManager.OnAuditReject(workFlowCurrentEntity);
                    // 只发给申请人
                    workFlowManager.SendRemindMessage(workFlowCurrentEntity, AuditStatus.AuditReject, new string[] { workFlowCurrentEntity.CreateUserId }, workFlowActivityEntity.AuditDepartmentId, workFlowActivityEntity.AuditRoleId);
                }
                this.ReturnStatusMessage = this.GetStateMessage(this.ReturnStatusCode);
                return returnValue;
            }
        }
        #endregion

        #region private int StepAuditPass(string currentId, string auditIdea, BaseWorkFlowActivityEntity workFlowActivityEntity) 审核通过(不需要再发给别人了)
        /// <summary>
        /// 审核通过(不需要再发给别人了)
        /// </summary>
        /// <param name="currentId">当前主键</param>
        /// <param name="auditIdea">批示</param>
        /// <returns>影响行数</returns>
        private int StepAuditReject(string currentId, string auditIdea, BaseWorkFlowActivityEntity workFlowActivityEntity)
        {
            BaseWorkFlowCurrentEntity workFlowCurrentEntity = this.GetEntity(currentId);
            // 1.记录当前的审核时间、审核人信息
            workFlowCurrentEntity.AuditDate = DateTime.Now;
            workFlowCurrentEntity.AuditIdea = auditIdea;
            workFlowCurrentEntity.AuditUserId = this.UserInfo.Id;
            workFlowCurrentEntity.AuditUserRealName = this.UserInfo.RealName;
            workFlowCurrentEntity.AuditStatus = AuditStatus.AuditReject.ToString();
            workFlowCurrentEntity.AuditStatusName = AuditStatus.AuditReject.ToDescription();
            // 2.记录审核日志
            this.AddHistory(workFlowCurrentEntity);
            // 3.上一个审核结束了，新的审核又开始了，更新待审核情况
            workFlowCurrentEntity.ActivityId = workFlowActivityEntity.Id;
            workFlowCurrentEntity.ToRoleId = workFlowActivityEntity.AuditRoleId;
            workFlowCurrentEntity.ToRoleRealName = workFlowActivityEntity.AuditRoleRealName;
            workFlowCurrentEntity.ToDepartmentId = workFlowActivityEntity.AuditDepartmentId;
            workFlowCurrentEntity.ToDepartmentName = workFlowActivityEntity.AuditDepartmentName;
            workFlowCurrentEntity.ToUserId = workFlowActivityEntity.AuditUserId;
            workFlowCurrentEntity.ToUserRealName = workFlowActivityEntity.AuditUserRealName;
            workFlowCurrentEntity.SortCode = workFlowActivityEntity.SortCode;
            return this.UpdateEntity(workFlowCurrentEntity);
        }
        #endregion
    }
}