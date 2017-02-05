//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// IWorkFlowProcessAdminService
    /// 工作流管理
    ///
    /// <author>
    ///		<name>韩峰</name>
    ///		<date>2011.03.05</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IWorkFlowProcessAdminService
    {
        /// <summary>
        /// 添加工作流
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <param name="workFlowProcessEntity">工作流定义实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Add(BaseUserInfo userInfo, BaseWorkFlowProcessEntity workFlowProcessEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 批量删除组织机构
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDelete(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <returns>数据表</returns>
        [OperationContract]
        int BatchSave(BaseUserInfo userInfo, DataTable dataTable);

        /// <summary>
        /// 单个删除工作流
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <param name="organizeId">组织主键</param> 
        /// <returns>影响行数</returns>
        [OperationContract]
        int Delete(BaseUserInfo userInfo, string id);

        /// <summary>
        /// 获取工作流列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据权限</returns>
        [OperationContract]
        DataTable GetDataTable(BaseUserInfo userInfo, string id = null);

        /// <summary>
        /// 获取工作流
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        BaseWorkFlowProcessEntity GetEntity(BaseUserInfo userInfo, string id);

        /// <summary>
        /// 批量打删除标志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetDeleted(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 更新工作流
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowProcessEntity">实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Update(BaseUserInfo userInfo, BaseWorkFlowProcessEntity workFlowProcessEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 获取表单模板类型
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetBillTemplateDT(BaseUserInfo userInfo);

        /// <summary>
        /// 获取具体的审批流程
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="workFlowCode">工作流程编号</param>
        /// <returns>流程</returns>
        [OperationContract]
        string GetProcessId(BaseUserInfo userInfo, string workFlowCode);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="userId"></param>
        /// <param name="categoryCode"></param>
        /// <param name="searchValue"></param>
        /// <param name="enabled"></param>
        /// <param name="deletionStateCode"></param>
        /// <returns></returns>
        DataTable Search(BaseUserInfo userInfo, string userId, string categoryCode, string searchValue, bool? enabled, bool? deletionStateCode);
    }
}
