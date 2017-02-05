//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;
    
    /// <summary>
    /// IWorkFlowActivityAdminService
    /// 工作流审核步骤
    /// 
    /// <author>
    ///     <name>韩峰</name>
    ///     <date>2011.03.05</date>
    /// </author>
    /// </summary>
    [ServiceContract]
    public interface IWorkFlowActivityAdminService
    {
        /// <summary>
        /// 获取工作流步骤定义列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="workFlowId">工作流主键</param> 
        /// <returns>数据权限</returns>
        [OperationContract]
        DataTable GetDataTable(BaseUserInfo userInfo, string workFlowId);

        /// <summary>
        /// 添加工作流
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <param name="workFlowActivityEntity">工作流定义实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Add(BaseUserInfo userInfo, BaseWorkFlowActivityEntity workFlowActivityEntity);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">选种的数组</param>
        /// <returns>数据权限</returns>
        [OperationContract]
        int BatchDelete(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchSave(BaseUserInfo userInfo, DataTable dataTable);
    }
}
