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
        /// 组织机构模块关联关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// 66.获取用户模块权限范围主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetOrganizeScopeModuleIds(BaseUserInfo userInfo, string organizeId, string permissionItemCode);

        /// <summary>
        /// 67.授予用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="grantModuleIds">授予模块主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantOrganizeModuleScopes(BaseUserInfo userInfo, string organizeId, string permissionItemCode, string[] grantModuleIds);

        /// <summary>
        /// 68.授予用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="grantModuleId">授予模块主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        string GrantOrganizeModuleScope(BaseUserInfo userInfo, string organizeId, string permissionItemCode, string grantModuleId);

        /// <summary>
        /// 69.撤消用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="revokeModuleIds">撤消模块主键数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeOrganizeModuleScopes(BaseUserInfo userInfo, string organizeId, string permissionItemCode, string[] revokeModuleIds);

        /// <summary>
        /// 70.撤消用户模块的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="revokeModuleId">撤消模块主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeOrganizeModuleScope(BaseUserInfo userInfo, string organizeId, string permissionItemCode, string revokeModuleId);


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 组织机构权限关联关系相关
        //////////////////////////////////////////////////////////////////////////////////////////////////////


        /// <summary>
        /// 20.获取组织机构权限主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetOrganizePermissionItemIds(BaseUserInfo userInfo, string organizeId);

        /// <summary>
        /// 20.获取组织机构主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemId">操作权限主键</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetOrganizeIdsByPermission(BaseUserInfo userInfo, string permissionItemId);

        /// <summary>
        /// 23.授予组织机构的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="grantPermissionItemId">授予权限</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        string GrantOrganizePermissionById(BaseUserInfo userInfo, string organizeId, string grantPermissionItemId);

        /// <summary>
        /// 21.授予角色的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeIds">组织机构主键数组</param>
        /// <param name="grantPermissionItemIds">授予权限数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int GrantOrganizePermissions(BaseUserInfo userInfo, string[] organizeIds, string[] grantPermissionItemIds);

        /// <summary>
        /// 撤消组织机构的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeIds">组织机构主键数组</param>
        /// <param name="grantPermissionItemIds">授予权限数组</param>
        /// <param name="revokePermissionItemIds">撤消权限数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeOrganizePermissions(BaseUserInfo userInfo, string[] organizeIds, string[  ] revokePermissionItemIds);

        /// <summary>
        /// 26.撤消组织机构的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="revokePermissionItemId">撤消权限数组</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RevokeOrganizePermissionById(BaseUserInfo userInfo, string organizeId, string revokePermissionItemId);

        /// <summary>
        /// 39.清除权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        int ClearOrganizePermission(BaseUserInfo userInfo, string id);

    }
}