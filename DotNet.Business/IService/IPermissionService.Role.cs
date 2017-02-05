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
        /// 角色权限关联关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// 20.获取角色权限主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetRolePermissionItemIds(BaseUserInfo userInfo, string roleId);

        /// <summary>
        /// 20.获取角色主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemId">操作权限主键</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetRoleIdsByPermission(BaseUserInfo userInfo, string permissionItemId);

        /// <summary>
        /// 21.授予角色的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleIds">角色主键数组</param>
        /// <param name="grantPermissionItemIds">授予权限数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantRolePermissions(BaseUserInfo userInfo, string[] roleIds, string[] grantPermissionItemIds);

        /// <summary>
        /// 22.授予角色的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleName">角色名</param>
        /// <param name="grantPermissionItemId">授予权限</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        string GrantRolePermission(BaseUserInfo userInfo, string roleName, string grantPermissionItemId);

        /// <summary>
        /// 23.授予角色的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="grantPermissionItemId">授予权限</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        string GrantRolePermissionById(BaseUserInfo userInfo, string roleId, string grantPermissionItemId);

        /// <summary>
        /// 24.撤消角色的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleIds">角色主键数组</param>
        /// <param name="grantPermissionItemIds">授予权限数组</param>
        /// <param name="revokePermissionItemIds">撤消权限数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeRolePermissions(BaseUserInfo userInfo, string[] roleIds, string[] revokePermissionItemIds);

        /// <summary>
        /// 25.撤消角色的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="revokePermissionItemId">撤消权限数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeRolePermission(BaseUserInfo userInfo, string roleId, string revokePermissionItemId);

        /// <summary>
        /// 26.撤消角色的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="revokePermissionItemId">撤消权限数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeRolePermissionById(BaseUserInfo userInfo, string roleId, string revokePermissionItemId);

        /// <summary>
        /// 27.获取角色的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetRoleScopeUserIds(BaseUserInfo userInfo, string roleId, string permissionItemCode);

        /// <summary>
        /// 28.获取角色的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetRoleScopeRoleIds(BaseUserInfo userInfo, string roleId, string permissionItemCode);

        /// <summary>
        /// 29.获取角色的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetRoleScopeOrganizeIds(BaseUserInfo userInfo, string roleId, string permissionItemCode);

        /// <summary>
        /// 30.授予角色的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="grantUserIds">授予用户主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantRoleUserScopes(BaseUserInfo userInfo, string roleId, string permissionItemCode, string[] grantUserIds);

        /// <summary>
        /// 31.撤消角色的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="revokeUserIds">撤消的用户主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeRoleUserScopes(BaseUserInfo userInfo, string roleId, string permissionItemCode, string[] revokeUserIds);

        /// <summary>
        /// 32.授予角色的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="grantRoleIds">授予角色主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantRoleRoleScopes(BaseUserInfo userInfo, string roleId, string permissionItemCode, string[] grantRoleIds);

        /// <summary>
        /// 33.撤消角色的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="revokeRoleIds">撤消的角色主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeRoleRoleScopes(BaseUserInfo userInfo, string roleId, string permissionItemCode, string[] revokeRoleIds);

        /// <summary>
        /// 34.授予角色的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">权限主键</param>
        /// <param name="grantOrganizeIds">授予组织主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantRoleOrganizeScopes(BaseUserInfo userInfo, string roleId, string permissionItemCode, string[] grantOrganizeIds);

        /// <summary>
        /// 35.撤消角色的某个权限域的组织范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">权限主键</param>
        /// <param name="revokeOrganizeIds">撤消的组织主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeRoleOrganizeScopes(BaseUserInfo userInfo, string roleId, string permissionItemCode, string[] revokeOrganizeIds);

        /// <summary>
        /// 36.获取角色授权权限列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限项编号</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetRoleScopePermissionItemIds(BaseUserInfo userInfo, string roleId, string permissionItemCode);

        /// <summary>
        /// 37.授予角色的授权权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="grantPermissionItemIds">授予的权限主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantRolePermissionItemScopes(BaseUserInfo userInfo, string roleId, string permissionItemCode, string[] grantPermissionItemIds);

        /// <summary>
        /// 38.授予角色的授权权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="revokePermissionItemIds">撤消的权限主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeRolePermissionItemScopes(BaseUserInfo userInfo, string roleId, string permissionItemCode, string[] revokePermissionItemIds);

        /// <summary>
        /// 39.清除权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        int ClearRolePermission(BaseUserInfo userInfo, string id);

        [OperationContract]
        int ClearRolePermissionScope(BaseUserInfo userInfo, string id, string permissionItemCode);

        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 角色模块关联关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// 66.获取用户模块权限范围主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetRoleScopeModuleIds(BaseUserInfo userInfo, string roleId, string permissionItemCode);

        /// <summary>
        /// 67.授予用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="grantModuleIds">授予模块主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantRoleModuleScopes(BaseUserInfo userInfo, string roleId, string permissionItemCode, string[] grantModuleIds);

        /// <summary>
        /// 68.授予用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="grantModuleId">授予模块主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        string GrantRoleModuleScope(BaseUserInfo userInfo, string roleId, string permissionItemCode, string grantModuleId);

        /// <summary>
        /// 69.撤消用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="revokeModuleIds">撤消模块主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeRoleModuleScopes(BaseUserInfo userInfo, string roleId, string permissionItemCode, string[] revokeModuleIds);

        /// <summary>
        /// 70.撤消用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="revokeModuleId">撤消模块主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeRoleModuleScope(BaseUserInfo userInfo, string roleId, string permissionItemCode, string revokeModuleId);
    }
}