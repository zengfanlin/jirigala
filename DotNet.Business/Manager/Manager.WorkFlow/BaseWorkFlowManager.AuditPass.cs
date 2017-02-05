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
        /// <summary>
        /// (点批量通过时)当批量审核通过时
        /// </summary>
        /// <param name="currentId">审批流当前主键数组</param>
        /// <param name="auditIdea">批示</param>
        /// <returns>成功失败</returns>
        public int AutoAuditPass(string[] currentIds, string auditIdea)
        {
            int returnValue = 0;
            for (int i = 0; i < currentIds.Length; i++)
            {
                returnValue += this.AutoAuditPass(currentIds[i], auditIdea);
            }
            return returnValue;
        }

        public int AutoAuditPass(string currentId, string auditIdea)
        {
            IWorkFlowManager workFlowManager = this.GetWorkFlowManager(currentId);
            return AutoAuditPass(workFlowManager, currentId, auditIdea);
        }

        /// <summary>
        /// (点通过时)当审核通过时
        /// </summary>
        /// <param name="currentId">审批流当前主键</param>
        /// <param name="auditIdea">批示</param>
        /// <returns>成功失败</returns>
        public int AutoAuditPass(IWorkFlowManager workFlowManager, string currentId, string auditIdea)
        {
            int returnValue = 0;
            // 这里要加锁，防止并发提交
            // 这里用锁的机制，提高并发控制能力
            lock (WorkFlowCurrentLock)
            {
                // using (TransactionScope transactionScope = new TransactionScope())
                //{
                //try
                //{
                // 1. 先获得现在的状态？当前的工作流主键、当前的审核步骤主键？
                BaseWorkFlowCurrentEntity workFlowCurrentEntity = this.GetEntity(currentId);

                // 只有待审核状态的，才可以通过,被退回的也可以重新提交
                if (!(workFlowCurrentEntity.AuditStatus.Equals(AuditStatus.StartAudit.ToString())
                    || workFlowCurrentEntity.AuditStatus.Equals(AuditStatus.AuditPass.ToString())
                    || workFlowCurrentEntity.AuditStatus.Equals(AuditStatus.WaitForAudit.ToString())
                    || workFlowCurrentEntity.AuditStatus.Equals(AuditStatus.AuditReject.ToString())
                    ))
                {
                    return returnValue;
                }

                // 是不是给当前人审核的,或者当前人在委托的人？
                if (!string.IsNullOrEmpty(workFlowCurrentEntity.ToUserId))
                {
                    if (!(workFlowCurrentEntity.ToUserId.ToString().Equals(this.UserInfo.Id) || workFlowCurrentEntity.ToUserId.ToString().Equals(this.UserInfo.TargetUserId)))
                    {
                        return returnValue;
                    }
                }

                BaseWorkFlowActivityEntity workFlowActivityEntity = this.GetNextWorkFlowActivity(workFlowCurrentEntity);
                // 3. 进行下一步流转？转给角色？还是传给用户？
                if (workFlowActivityEntity == null || workFlowActivityEntity.Id == null)
                {
                    // 4. 若没下一步了，那就得结束流程了？审核结束了
                    returnValue = this.AuditComplete(workFlowManager, currentId, auditIdea);
                }
                else
                {
                    // 审核进入下一步
                    // 当前是哪个步骤？
                    // 4. 是否已经在工作流里了？
                    // 5. 若已经在工作流里了，那就进行更新操作？
                    if (!string.IsNullOrEmpty(workFlowActivityEntity.AuditUserId))
                    {
                        // 若是任意人可以审核的,需要进行一次人工选任的工作
                        if (workFlowActivityEntity.AuditUserId.Equals("Anyone"))
                        {
                            return returnValue;
                        }
                    }
                    // 按用户审核,审核通过
                    returnValue = AuditPass(workFlowManager, currentId, auditIdea, workFlowActivityEntity);
                }
                //}
                //catch (System.Exception ex)
                //{
                // 在本地记录异常
                //    FileUtil.WriteException(UserInfo, ex);
                //}
                //finally
                //{
                //}
                // transactionScope.Complete();
                //}
            }
            return returnValue;
        }

        #region public int AuditPass(IWorkFlowManager workFlowManager, string currentId, BaseWorkFlowActivityEntity workFlowActivityEntity) 审核通过
        /// <summary>
        /// 审核通过
        /// </summary>
        /// <param name="id">当前主键</param>
        /// <param name="auditIdea">批示</param>
        /// <returns>影响行数</returns>
        public int AuditPass(IWorkFlowManager workFlowManager, string currentId, string auditIdea, BaseWorkFlowActivityEntity workFlowActivityEntity)
        {
            int returnValue = 0;
            // 进行更新操作
            returnValue = this.StepAuditPass(currentId, auditIdea, workFlowActivityEntity);
            if (returnValue == 0)
            {
                // 数据可能被删除
                this.ReturnStatusCode = StatusCode.ErrorDeleted.ToString();
            }
            BaseWorkFlowCurrentEntity workFlowCurrentEntity = this.GetEntity(currentId);
            // 发送提醒信息
            if (workFlowManager != null)
            {
                if (!string.IsNullOrEmpty(workFlowActivityEntity.AuditUserId))
                {
                    workFlowActivityEntity.AuditDepartmentId = null;
                    workFlowActivityEntity.AuditRoleId = null;
                }
                workFlowManager.OnAutoAuditPass(workFlowCurrentEntity);
                workFlowManager.SendRemindMessage(workFlowCurrentEntity, AuditStatus.AuditPass, new string[] { workFlowCurrentEntity.CreateUserId, workFlowActivityEntity.AuditUserId }, workFlowActivityEntity.AuditDepartmentId, workFlowActivityEntity.AuditRoleId);
            }
            this.ReturnStatusMessage = this.GetStateMessage(this.ReturnStatusCode);
            return returnValue;
        }
        #endregion

        #region private int StepAuditPass(string currentId, string auditIdea, BaseWorkFlowActivityEntity workFlowActivityEntity) 审核通过(不需要再发给别人了)
        /// <summary>
        /// 审核通过(不需要再发给别人了)
        /// </summary>
        /// <param name="currentId">当前主键</param>
        /// <param name="auditIdea">批示</param>
        /// <returns>影响行数</returns>
        private int StepAuditPass(string currentId, string auditIdea, BaseWorkFlowActivityEntity workFlowActivityEntity)
        {
            BaseWorkFlowCurrentEntity workFlowCurrentEntity = this.GetEntity(currentId);
            // 1.记录当前的审核时间、审核人信息
            workFlowCurrentEntity.AuditDate = DateTime.Now;
            workFlowCurrentEntity.AuditIdea = auditIdea;
            workFlowCurrentEntity.AuditUserId = this.UserInfo.Id;
            workFlowCurrentEntity.AuditUserRealName = this.UserInfo.RealName;
            workFlowCurrentEntity.AuditStatus = AuditStatus.AuditPass.ToString();
            workFlowCurrentEntity.AuditStatusName = AuditStatus.AuditPass.ToDescription();
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