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
        public int FreeAuditPass(string currentId, string toUserId, string toDepartmentId = null, string toRoleId = null, string auditIdea = null)
        {
            IWorkFlowManager workFlowManager = this.GetWorkFlowManager(currentId);
            workFlowManager.SetUserInfo(this.UserInfo);
            return FreeAuditPass(workFlowManager, currentId, toUserId, toDepartmentId,  toRoleId, auditIdea);
        }

        #region public int FreeAuditPass(IWorkFlowManager workFlowManager, string currentId, string toUserId, string toDepartmentId = null, string toRoleId = null, string auditIdea = null) 自由审批
        /// <summary>
        /// 自由审批
        /// </summary>
        /// <param name="workFlowManager"></param>
        /// <param name="currentId"></param>
        /// <param name="toUserId"></param>
        /// <param name="toDepartmentId"></param>
        /// <param name="toRoleId"></param>
        /// <param name="auditIdea"></param>
        /// <returns></returns>
        public int FreeAuditPass(IWorkFlowManager workFlowManager, string currentId, string toUserId, string toDepartmentId = null, string toRoleId = null, string auditIdea = null)
        {
            // 返回值
            int returnValue = 0;
            // 这里用锁的机制，提高并发控制能力
            lock (WorkFlowCurrentLock)
            {
                BaseWorkFlowActivityEntity workFlowActivityEntity = new BaseWorkFlowActivityEntity();
                // FreeWorkFlow 自由工作流
                workFlowActivityEntity.WorkFlowId = 0;
                // 获取排序码
                workFlowActivityEntity.SortCode = int.Parse(new BaseSequenceManager().GetSequence("FreeWorkFlow", 10000000));
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
        }
        #endregion
    }
}