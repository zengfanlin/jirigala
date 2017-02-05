//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using DotNet.Utilities;

namespace DotNet.Business
{
    /// <summary>
    /// IWorkFlowManager
    /// 可审批化的类接口定义
    /// 
    /// 修改纪录
    /// 
    ///		2011.09.06 版本：1.0 JiRiGaLa 创建文件。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.09.06</date>
    /// </author> 
    /// </summary>
    public interface IWorkFlowManager
    {
        string CurrentTableName { get; set; }

        IDbHelper GetDbHelper();

        BaseUserInfo GetUserInfo();
        
        void SetUserInfo(BaseUserInfo userInfo);

        // string categoryCode, string categoryFullName, string objectId, string objectFullName, string workFlowCode

        /// <summary>
        /// 获取待审核单据的网址
        /// </summary>
        /// <param name="userId">发送给谁</param>
        /// <param name="currentId">工作流当前主键</param>
        /// <returns>获取网址</returns>
        string GetUrl(string currentId);


        /// <summary>
        /// 发送即时通讯提醒
        /// </summary>
        /// <param name="workFlowCurrentEntity">当前审核流实体信息</param>
        /// <param name="auditStatus">审核状态</param>
        /// <param name="userIds">发送给用户主键数组</param>
        /// <param name="organizeId">发送给部门主键数组</param>
        /// <param name="roleId">发送给角色主键数组</param>
        /// <returns>影响行数</returns>
        int SendRemindMessage(BaseWorkFlowCurrentEntity workFlowCurrentEntity, AuditStatus auditStatus, string[] userIds, string organizeId, string roleId);


        /// <summary>
        /// 当工作流开始启动前需要做的工作
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>工作流启动信息</returns>
        bool BeforeAutoStatr(string id);

        /// <summary>
        /// 当工作流开始启动之后需要做的工作
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        int AfterAutoStatr(string id);


        // ====================================== //
        // 下面是用户自己提交单据审核时发生的事件 //
        // ====================================== //

        /// <summary>
        /// 废弃单据
        /// （废弃单据时）当废弃审批流时需要做的事情
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="auditIdea">批示</param>
        /// <returns>影响行数</returns>
        int AuditQuash(string id, string auditIdea);

        /// <summary>
        /// 批量废弃单据
        /// （批量废弃单据时）当废弃审批流时需要做的事情
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <param name="auditIdea">批示</param>
        /// <returns>影响行数</returns>
        int AuditQuash(string[] ids, string auditIdea);

        // ====================================== //
        // 下面是用户被审核单据被审核时发生的事件 //
        // ====================================== //

        /// <summary>
        /// (点通过时)当审核通过时
        /// </summary>
        /// <param name="currentId">审批流当前主键</param>
        /// <param name="auditIdea">批示</param>
        /// <returns>成功失败</returns>
        bool OnAutoAuditPass(BaseWorkFlowCurrentEntity workFlowCurrentEntity);

        /// <summary>
        /// (点退回时)当审核退回时
        /// </summary>
        /// <param name="currentId">审批流当前主键</param>
        /// <param name="auditIdea">批示</param>
        /// <returns>成功失败</returns>
        bool OnAuditReject(BaseWorkFlowCurrentEntity workFlowCurrentEntity);
        
        /// <summary>
        /// 废弃单据
        /// （废弃单据时）当废弃审批流时需要做的事情
        /// </summary>
        /// <param name="workFlowCurrentEntity">当前审批流程</param>
        /// <returns>影响行数</returns>
        bool OnAuditQuash(BaseWorkFlowCurrentEntity workFlowCurrentEntity);

        /// <summary>
        /// 流程完成时
        /// 结束审核时，需要回调写入到表里，调用相应的事件
        /// 若成功可以执行完成的处理
        /// </summary>
        /// <param name="workFlowCurrentEntity">当前审批流实体</param>
        /// <param name="auditIdea">批示</param>
        /// <returns>成功失败</returns>
        bool OnAuditComplete(BaseWorkFlowCurrentEntity workFlowCurrentEntity);

        // (退回到某一节点时) 被退回到某个节点

        // 当有人评论时的功能实现

        /// <summary>
        /// 重置单据
        /// （单据发生错误时）紧急情况下实用
        /// </summary>
        /// <param name="currentId">审批流当前主键</param>
        /// <param name="categoryCode">单据分类</param>
        /// <param name="auditIdea">批示</param>
        /// <returns>影响行数</returns>
        bool OnReset(BaseWorkFlowCurrentEntity workFlowCurrentEntity);
    }
}