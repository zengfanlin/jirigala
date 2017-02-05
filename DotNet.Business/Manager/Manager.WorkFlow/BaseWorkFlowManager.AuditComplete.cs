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
        public int AuditComplete(string[] currentIds, string auditIdea)
        {
            int returnValue = 0;
            for (int i = 0; i < currentIds.Length; i++)
            {
                returnValue += AuditComplete(currentIds[i], auditIdea);
            }
            return returnValue;
        }

        public int AuditComplete(string currentId, string auditIdea)
        {
            IWorkFlowManager workFlowManager = this.GetWorkFlowManager(currentId);
            workFlowManager.SetUserInfo(this.UserInfo);
            return AuditComplete(workFlowManager, currentId, auditIdea);
        }

        #region public int AuditComplete(IWorkFlowManager workFlowManager, string currentId, string auditIdea)
        /// <summary>
        /// 最终审核通过（完成）
        /// </summary>
        /// <param name="workFlowManager">当前审批流程接口</param>
        /// <param name="currentId">当前主键</param>
        /// <param name="auditIdea">批示</param>
        /// <returns>影响行数</returns>
        public int AuditComplete(IWorkFlowManager workFlowManager, string currentId, string auditIdea)
        {
            int returnValue = 0;
            // 1：进行更新操作
            BaseWorkFlowCurrentEntity workFlowCurrentEntity = this.StepAuditComplete(currentId, auditIdea);
            if (workFlowCurrentEntity.Id != null)
            {
                // 2：对当前审批流程接口进行处理
                if (workFlowManager != null)
                {
                    // 3：进行审批处理完毕动作
                    workFlowManager.OnAuditComplete(workFlowCurrentEntity);
                    string[] userIds = null;
                    /*
                    // 4：这里给所有相关的人发一个消息，告诉他们审批完成了
                    BaseWorkFlowStepManager workFlowStepManager = new BaseWorkFlowStepManager(this.DbHelper, this.UserInfo);
                    userIds = workFlowStepManager.GetProperties(new KeyValuePair<string, object>(BaseWorkFlowStepEntity.FieldCategoryCode, workFlowCurrentEntity.CategoryCode)
                        , new KeyValuePair<string, object>(BaseWorkFlowStepEntity.FieldObjectId, workFlowCurrentEntity.ObjectId)
                        , BaseWorkFlowStepEntity.FieldAuditUserId);
                    */
                    // 把创建人加上，发出者也需要获得提醒信息
                    userIds = StringUtil.Concat(userIds, workFlowCurrentEntity.CreateUserId);
                    // 当前操作者没必要参与进来，可以少发一个没必要的提示信息，减少没必要的提醒信息
                    userIds = StringUtil.Remove(userIds, this.UserInfo.Id);
                    workFlowManager.SendRemindMessage(workFlowCurrentEntity, AuditStatus.AuditComplete, userIds, null, null);
                    returnValue = 1;
                }
            }
            else
            {
                // 数据可能被删除
                this.ReturnStatusCode = StatusCode.ErrorDeleted.ToString();
            }
            // 应该给创建者一个提醒消息
            this.ReturnStatusMessage = this.GetStateMessage(this.ReturnStatusCode);
            return returnValue;
        }
        #endregion

        #region private BaseWorkFlowCurrentEntity StepAuditComplete(string currentId, string auditIdea)
        /// <summary>
        /// 最终审核通过（完成）
        /// </summary>
        /// <param name="currentId">当前主键</param>
        /// <param name="auditIdea">批示</param>
        /// <returns>影响行数</returns>
        private BaseWorkFlowCurrentEntity StepAuditComplete(string currentId, string auditIdea)
        {
            BaseWorkFlowCurrentEntity currentEntity = this.GetEntity(currentId);
            // 1.记录审核时间、审核人、审核意见
            currentEntity.AuditUserId = this.UserInfo.Id;
            currentEntity.AuditUserRealName = this.UserInfo.RealName;
            currentEntity.AuditIdea = auditIdea;
            currentEntity.AuditStatus = AuditStatus.AuditComplete.ToString();
            currentEntity.AuditStatusName = AuditStatus.AuditComplete.ToDescription();
            currentEntity.AuditDate = DateTime.Now;
            currentEntity.ToUserId = null;
            currentEntity.ToUserRealName = null;
            currentEntity.ToDepartmentId = null;
            currentEntity.ToDepartmentName = null;
            currentEntity.ToRoleId = null;
            currentEntity.ToRoleRealName = null;
            // 审批好了，数据就生效了
            currentEntity.Enabled = 1;
            // 2.记录审核日志记录日志
            this.AddHistory(currentEntity);
            // 3.更新当前表
            this.UpdateEntity(currentEntity);
            return currentEntity;
        }
        #endregion        
    }
}