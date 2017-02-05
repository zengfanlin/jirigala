//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;
    
    /// <summary>
    /// IPermissionService
    /// 与权限判断等相关的接口定义
    /// 
    /// 修改纪录
    /// 
    ///		2012.03.22 版本：1.0 JiRiGaLa 添加权限。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.03.22</date>
    /// </author> 
    /// </summary>
    public partial interface IPermissionService
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 用户权限关联关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// 40.获取用户权限主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetUserPermissionItemIds(BaseUserInfo userInfo, string userId);

        /// <summary>
        /// 40.获取用户主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemId">操作权限主键</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetUserIdsByPermission(BaseUserInfo userInfo, string permissionItemId);

        /// <summary>
        /// 41.授予用户的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键数组</param>
        /// <param name="grantPermissionItemIds">授予权限数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantUserPermissions(BaseUserInfo userInfo, string[] userIds, string[] grantPermissionItemIds);

        /// <summary>
        /// 42.授予用户的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="grantPermissionItemId">授予权限数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        string GrantUserPermissionById(BaseUserInfo userInfo, string userId, string grantPermissionItemId);

        /// <summary>
        /// 43.撤消用户的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userIds">用户主键数组</param>
        /// <param name="revokePermissionItemIds">撤消权限数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeUserPermissions(BaseUserInfo userInfo, string[] userIds, string[] revokePermissionItemIds);

        /// <summary>
        /// 44.撤消用户的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="revokePermissionItemId">撤消权限</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeUserPermissionById(BaseUserInfo userInfo, string userId, string revokePermissionItemId);

        /// <summary>
        /// 45.获取用户的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限主键</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetUserScopeOrganizeIds(BaseUserInfo userInfo, string userId, string permissionItemCode);

        /// <summary>
        /// 46.设置用户的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限主键</param>
        /// <param name="grantOrganizeIds">授予的组织主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantUserOrganizeScopes(BaseUserInfo userInfo, string userId, string permissionItemCode, string[] grantOrganizeIds);

        /// <summary>
        /// 47.设置用户的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限主键</param>
        /// <param name="revokeOrganizeIds">撤消的组织主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeUserOrganizeScopes(BaseUserInfo userInfo, string userId, string permissionItemCode, string[] revokeOrganizeIds);

        /// <summary>
        /// 48.获取用户的某个权限域的用户范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限主键</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetUserScopeUserIds(BaseUserInfo userInfo, string userId, string permissionItemCode);

        /// <summary>
        /// 49.设置用户的某个权限域的用户范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限主键</param>
        /// <param name="grantUserIds">授予的用户主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantUserUserScopes(BaseUserInfo userInfo, string userId, string permissionItemCode, string[] grantUserIds);

        /// <summary>
        /// 50.设置用户的某个权限域的用户范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限主键</param>
        /// <param name="revokeUserIds">撤消的用户主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeUserUserScopes(BaseUserInfo userInfo, string userId, string permissionItemCode, string[] revokeUserIds);

        /// <summary>
        /// 51.获取用户的某个权限域的用户范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限主键</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetUserScopeRoleIds(BaseUserInfo userInfo, string userId, string permissionItemCode);

        /// <summary>
        /// 52.设置用户的某个权限域的用户范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限主键</param>
        /// <param name="grantUserIds">授予的用户主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantUserRoleScopes(BaseUserInfo userInfo, string userId, string permissionItemCode, string[] grantRoleIds);

        /// <summary>
        /// 53.设置用户的某个权限域的用户范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限主键</param>
        /// <param name="revokeUserIds">撤消的用户主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeUserRoleScopes(BaseUserInfo userInfo, string userId, string permissionItemCode, string[] revokeRoleds);

        /// <summary>
        /// 54.获取用户授权权限列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetUserScopePermissionItemIds(BaseUserInfo userInfo, string userId, string permissionItemCode);

        /// <summary>
        /// 55.授予用户的授权权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="grantPermissionItemIds">授予的权限主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantUserPermissionItemScopes(BaseUserInfo userInfo, string userId, string permissionItemCode, string[] grantPermissionItemIds);

        /// <summary>
        /// 56.撤消用户的授权权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="revokePermissionItemIds">撤消的权限主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeUserPermissionItemScopes(BaseUserInfo userInfo, string userId, string permissionItemCode, string[] revokePermissionItemIds);

        /// <summary>
        /// 57.清除权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        int ClearUserPermission(BaseUserInfo userInfo, string id);

        /// <summary>
        /// 58.
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="id"></param>
        /// <param name="permissionItemCode"></param>
        /// <returns></returns>
        [OperationContract]
        int ClearUserPermissionScope(BaseUserInfo userInfo, string id, string permissionItemCode);

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 用户关联模块关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 59.获得用户有权限的模块
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetModuleDT(BaseUserInfo userInfo);

        /// <summary>
        /// 获取用户有权限访问的模块主键
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetModuleIdsByUser(BaseUserInfo userInfo, string userId);

        /// <summary>
        /// 60.获得用户有权限的模块
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetModuleDTByUser(BaseUserInfo userInfo, string userId);

        /// <summary>
        /// 61.获取用户模块权限范围主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetUserScopeModuleIds(BaseUserInfo userInfo, string userId, string permissionItemCode);

        /// <summary>
        /// 62.授予用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="grantModuleId">授予模块主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        string GrantUserModuleScope(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string grantModuleId);

        /// <summary>
        /// 63.授予用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="grantModuleIds">授予模块主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantUserModuleScopes(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string[] grantModuleIds);

        /// <summary>
        /// 64.撤消用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="revokeModuleId">撤消模块主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeUserModuleScope(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string revokeModuleId);

        /// <summary>
        /// 65.撤消用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="revokeModuleIds">撤消模块主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeUserModuleScopes(BaseUserInfo userInfo, string userId, string permissionScopeItemCode, string[] revokeModuleIds);

    }
}