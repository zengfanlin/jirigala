//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// ITableColumnsService
    /// 表字段结构
    /// 
    /// 修改纪录
    /// 
    ///		2011.05.16 版本：1.0 JiRiGaLa 创建主键。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.05.16</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface ITableColumnsService
    {
        /// <summary>
        /// 按表名获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="tableCode">表名</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByTable(BaseUserInfo userInfo, string tableCode);

        /// <summary>
        /// 获取约束条件（所有的约束）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="resourceId">资源主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetConstraintDT(BaseUserInfo userInfo, string resourceCategory, string resourceId);

        /// <summary>
        /// 设置约束条件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="tableName">表名</param>
        /// <param name="constraint">约束</param>
        /// <param name="enabled">有效</param>
        /// <returns>主键</returns>
        [OperationContract]
        string SetConstraint(BaseUserInfo userInfo, string resourceCategory, string resourceId, string tableName, string permissionCode, string constraint, bool enabled);

        /// <summary>
        /// 获取约束条件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="tableName">表名</param>
        /// <returns>约束条件</returns>
        [OperationContract]
        string GetConstraint(BaseUserInfo userInfo, string resourceCategory, string resourceId, string tableName);

        /// <summary>
        /// 获取约束条件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="tableName">表名</param>
        /// <returns>约束条件</returns>
        [OperationContract]
        BasePermissionScopeEntity GetConstraintEntity(BaseUserInfo userInfo, string resourceCategory, string resourceId, string tableName, string permissionCode);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDeleteConstraint(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 获取用户的件约束表达式
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源类别</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="tableName">表名</param>
        /// <param name="constraint">约束</param>
        /// <returns>主键</returns>
        [OperationContract]
        string GetUserConstraint(BaseUserInfo userInfo, string tableName);
    }
}