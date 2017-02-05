//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// IWorkFlowCurrentService
    /// 当前审核工作流
    /// 
    /// <author>
    ///		<name>韩峰</name>
    ///		<date>2011.03.05</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IWorkFlowCurrentService
    {
        /// <summary>
        /// 检查是否是步骤流
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="currentFlowIds">主键组</param>
        /// <param name="returnStatusCode">返回代码</param>
        /// <param name="returnStatusMessage">返回信息</param>
        /// <returns></returns>
        [OperationContract]
        bool CheckIsAutoWorkFlow(BaseUserInfo userInfo, string[] currentFlowIds, out string returnStatusCode, out string returnStatusMessage);

        /// <summary>
        /// 检查是否是步骤流
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="categoryCode">单据类型代码</param>
        /// <param name="objectIds">单据主键组</param>
        /// <param name="returnStatusCode">返回代码</param>
        /// <param name="returnStatusMessage">返回信息</param>
        /// <returns></returns>
        [OperationContract]
        bool CheckIsAutoWorkFlow(BaseUserInfo userInfo, string categoryCode, string[] objectIds, out string returnStatusCode, out string returnStatusMessage);

        /// <summary>
        /// 替换工作审核者
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="oldCode">原来的工号</param>
        /// <param name="newCode">新的工号</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Replace(BaseUserInfo userInfo, string oldCode, string newCode);

        /// <summary>
        /// 获取待审核主键
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryId">分类主键</param>
        /// <param name="objectId">主键</param>
        /// <returns>主键</returns>
        [OperationContract]
        string GetCurrentId(BaseUserInfo userInfo, string categoryId, string objectId);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTable(BaseUserInfo userInfo);

        /// <summary>
        /// 获取监控列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetMonitorDT(BaseUserInfo userInfo);

        /// <summary>
        /// 获取分页监控列表
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="categoryCode"></param>
        /// <param name="searchValue"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetMonitorPagedDT(BaseUserInfo userInfo, int pageSize, int pageIndex, out int recordCount, string categoryCode = null, string searchValue = null);

        /// <summary>
        /// 获取待审批
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="userId">用户主键</param>
        /// <param name="categoryCode">分类代码</param>      
        /// <param name="searchValue">查询字符串</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetWaitForAudit(BaseUserInfo userInfo, string userId = null, string categoryCode = null, string categorybillFullName = null, string searchValue = null);

        /// <summary>
        /// 获取审核历史明细 
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryId">单据分类主键</param>
        /// <param name="objectId">单据主键</param>
        /// <returns>数据权限</returns>
        [OperationContract]
        DataTable GetAuditDetailDT(BaseUserInfo userInfo, string categoryId, string objectId);

        /// <summary>
        /// 最终审核通过
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <param name="id">主键</param>
        /// <param name="auditIdea">审核意见</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int AuditComplete(BaseUserInfo userInfo, string[] ids, string auditIdea);

        /// <summary>
        /// 撤消审批流程中的单据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="currentWorkFlowId">当前工作流主键</param>
        /// <param name="auditIdea">撤销意见</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int AuditQuash(BaseUserInfo userInfo, string[] currentWorkFlowIds, string auditIdea);

        /// <summary>
        /// 审核退回
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">当前主键</param>
        /// <param name="auditIdea">审核建议</param>
        /// <returns>数据权限</returns>
        [OperationContract]
        int AuditReject(BaseUserInfo userInfo, string[] ids, string auditIdea);

        /// <summary>
        /// 自动工作流审核通过
        /// </summary>
        /// <param name="flowIds">当前流程主键组</param>
        /// <param name="auditIdea">提交意见</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int AuditPass(BaseUserInfo userInfo, string[] flowIds, string auditIdea);

        /// <summary>
        /// 开始审核
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryCode">分类编号</param>
        /// <param name="categoryFullName">分类名称</param>
        /// <param name="objectIds">实体主键数组</param>
        /// <param name="objectFullName">实体名称</param>
        /// <param name="workFlowCode">工作流编号</param>
        /// <param name="auditIdea">审核意见</param>
        /// <param name="returnStatusCode">审核状态</param>
        /// <returns>主键</returns>
        [OperationContract]
        string AuditStatr(BaseUserInfo userInfo, string categoryCode, string categoryFullName, string[] objectIds, string objectFullName, string workFlowCode, string auditIdea, out string returnStatusCode, DataTable dtWorkFlowActivity = null);

        /// <summary>
        /// 下个流程发送给谁
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">当前主键</param>
        /// <param name="sendToUserId">用户主键</param>
        /// <param name="auditIdea">审核意见</param>
        /// <returns>数据权限</returns>
        [OperationContract]
        int AuditTransmit(BaseUserInfo userInfo, string id, string workFlowCategory, string sendToUserId, string auditIdea);

        // <summary>
        /// 提交审批（自由流）
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="categoryCode">单据类型代码</param>
        /// <param name="categoryFullName">单据类型名称</param>
        /// <param name="objectIds">单据主键组</param>
        /// <param name="objectFullName">单据名称</param>
        /// <param name="workFlowCode">工作流类型</param>
        /// <param name="auditIdea">审批意见</param>
        /// <param name="workFlowCategory">审批类型</param>
        /// <param name="toId">发给主键</param>
        /// <param name="toFullName">发给名称</param>
        /// <param name="returnStatusCode"></param>
        /// <returns></returns>
        [OperationContract]
        string AuditFreeStart(BaseUserInfo userInfo, string categoryCode, string categoryFullName, string[] objectIds, string objectFullName, string objectId, string workFlowCode, string toUserId, string toDepartmentId, string toRoleId, string auditIdea, out string returnStatusCode);

        /// <summary>
        /// 自由工作流审核通过
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="flowId">工作流主键</param>
        /// <param name="workFlowCategory">类型</param>
        /// <param name="toId">发送给主键</param>
        /// <param name="toFullName">发送给名称</param>
        /// <param name="auditIdea">意见</param>
        /// <returns></returns>
        [OperationContract]
        int FreeAuditPass(BaseUserInfo userInfo, string flowId, string workFlowCategory, string toId, string toFullName, string auditIdea);
    
        /// <summary>
        /// 获取已审核流程列表
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="categoryCode">单据类型</param>
        /// <param name="categorybillFullName">流程</param>
        /// <param name="searchValue">关键字</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetAuditRecord(BaseUserInfo userInfo, string categoryCode, string categorybillFullName = null, string searchValue = null);
    }
}
