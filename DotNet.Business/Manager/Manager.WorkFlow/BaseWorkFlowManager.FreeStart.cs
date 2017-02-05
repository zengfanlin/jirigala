//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseWorkFlowCurrentManager
    /// 流程管理.
    /// 
    /// 修改纪录
    ///		
    ///		2012.05.31 版本：1.0 JiRiGaLa	创建。
    /// 
    /// 版本：1.0
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.05.31</date>
    /// </author>
    /// </summary>
    public partial class BaseWorkFlowCurrentManager : BaseManager, IBaseManager
    {
        //-----------------------------------------------------
        //                  启动工作流 自由流
        //-----------------------------------------------------

        /// <summary>
        /// 启动工作流(自由流转)
        /// </summary>
        /// <param name="workFlowManager"></param>
        /// <param name="objectId"></param>
        /// <param name="objectFullName"></param>
        /// <param name="categoryCode"></param>
        /// <param name="categoryFullName"></param>
        /// <param name="workFlowCode"></param>
        /// <param name="toUserId"></param>
        /// <param name="toDepartmentId"></param>
        /// <param name="toRoleId"></param>
        /// <param name="auditIdea"></param>
        /// <returns></returns>
        public string FreeStart(IWorkFlowManager workFlowManager, string objectId, string objectFullName, string categoryCode, string categoryFullName, string workFlowCode, string toUserId, string toDepartmentId = null, string toRoleId = null, string auditIdea = null)
        {
            // 获取当前工作流步骤
            string currentId = this.GetCurrentId(categoryCode, objectId);
            // 定义步骤实体
            BaseWorkFlowStepEntity workFlowStepEntity = new BaseWorkFlowStepEntity();
            // FreeWorkFlow 自由工作流
            workFlowStepEntity.WorkFlowId = 0;
            // 获取排序码
            workFlowStepEntity.SortCode = int.Parse(new BaseSequenceManager().GetSequence(workFlowCode, 10000000));
            // 是否提交给用户审批
            if (!string.IsNullOrEmpty(toUserId))
            {
                workFlowStepEntity.AuditUserId = toUserId;
                workFlowStepEntity.AuditUserRealName = new BaseUserManager().GetEntity(toUserId).RealName;
            }
            // 是否提交给部门审批
            if (!string.IsNullOrEmpty(toDepartmentId))
            {
                workFlowStepEntity.AuditDepartmentId = toDepartmentId;
                workFlowStepEntity.AuditDepartmentName = new BaseOrganizeManager().GetEntity(toDepartmentId).FullName;
            }
            // 是否提交给角色审批
            if (!string.IsNullOrEmpty(toRoleId))
            {
                workFlowStepEntity.AuditRoleId = toRoleId;
                workFlowStepEntity.AuditRoleRealName = new BaseRoleManager().GetEntity(toRoleId).RealName;
            }
            if (workFlowManager != null)
            {
                workFlowManager.BeforeAutoStatr(objectId);
            }
            // 如果已经存在
            if (currentId.Length > 0)
            {                
                // 获取当前处于什么状态
                string auditstatus = this.GetProperty(currentId, BaseWorkFlowCurrentEntity.FieldAuditStatus);
                // 如果还是开始审批状态的话，允许他再次提交把原来的覆盖掉
                if (auditstatus == AuditStatus.StartAudit.ToString() 
                    || auditstatus == AuditStatus.AuditReject.ToString())
                {
                    // 更新
                    this.UpdataAuditStatr(currentId, categoryCode, categoryFullName, objectId, objectFullName, auditIdea, workFlowStepEntity);
                }
                // 不是的话则返回
                else
                {
                    // 该单据已进入审核状态不能在次提交
                    this.ReturnStatusCode = StatusCode.ErrorChanged.ToString();
                    // 返回为空可以判断
                    currentId = null;
                    return currentId;
                }
            }
            else
            {   
                // 新增
                currentId = this.StepAuditStatr(categoryCode, categoryFullName, objectId, objectFullName, auditIdea, workFlowStepEntity);
            }
            BaseWorkFlowCurrentEntity workFlowCurrentEntity = this.GetEntity(currentId);
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
            if (workFlowManager != null && !string.IsNullOrEmpty(objectId))
            {
                workFlowManager.AfterAutoStatr(objectId);
            }
            // 运行成功
            this.ReturnStatusCode = StatusCode.OK.ToString();
            this.ReturnStatusMessage = this.GetStateMessage(this.ReturnStatusCode);
            return currentId;
        }
    }
}