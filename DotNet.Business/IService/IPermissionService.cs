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
    ///		2011.04.30 版本：2.0 JiRiGaLa 整理接口注释。
    ///		2010.07.06 版本：1.9 JiRiGaLa 数据权限进行优化处理，统一处理删除标志功能。
    ///		2010.05.24 版本：1.8 JiRiGaLa 增加 角色的权限判断。
    ///		2009.09.09 版本：1.7 JiRiGaLa 增加 GetUserPermissionScope、GetOrganizeIdsByPermission、GetRoleIdsByPermission、GetUserIdsByPermission。
    ///		2008.11.28 版本：1.6 JiRiGaLa 整理为52个标准接口定义，完善 GetLicensePermissionByUser 接口定义。
    ///		2008.11.27 版本：1.5 JiRiGaLa 整理为50个标准接口定义，有些permissionItemCode修改为permissionItemId。
    ///		2008.11.27 版本：1.5 JiRiGaLa 接口改进为B/S系统适合的接口定义 整理为45个标准接口定义。
    ///		2008.11.26 版本：1.4 JiRiGaLa 将权限相关的类方法集中到 IPermissionService 接口中。
    ///		2008.09.02 版本：1.3 JiRiGaLa 将命名修改为 IPermissionService 。
    ///		2008.06.12 版本：1.2 JiRiGaLa 传递类对象。
    ///		2008.05.09 版本：1.1 JiRiGaLa 命名修改为 IPermissionService。
    ///		2008.03.23 版本：1.0 JiRiGaLa 添加权限。
    ///		
    /// 版本：2.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.04.30</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public partial interface IPermissionService
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 用户权限判断相关(需要实现对外调用)
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 01.用户是否在指定的角色里
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="roleName">角色名称</param>
        /// <returns>在角色里</returns>
        [OperationContract]
        bool IsInRole(BaseUserInfo userInfo, string userId, string roleName);

        /// <summary>
        /// 02.当前用户是否有相应的操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="permissionItemName">操作权限名称</param>
        /// <returns>是否有权限</returns>
        [OperationContract]
        bool IsAuthorized(BaseUserInfo userInfo, string permissionItemCode, string permissionItemName);

        /// <summary>
        /// 03.某个用户是否有相应的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="permissionItemName">操作权限名称</param>
        /// <returns>是否有权限</returns>
        [OperationContract]
        bool IsAuthorizedByUser(BaseUserInfo userInfo, string userId, string permissionItemCode, string permissionItemName);

        /// <summary>
        /// 04.某个角色是否有相应的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>是否有权限</returns>
        [OperationContract]
        bool IsAuthorizedByRole(BaseUserInfo userInfo, string roleId, string permissionItemCode);

        /// <summary>
        /// 05.当前用户是否超级管理员
        /// </summary>
        /// <param name="userInfo"></param>
        /// <returns></returns>
        [OperationContract]
        bool IsAdministrator(BaseUserInfo userInfo);

        /// <summary>
        /// 06.某个用户是否超级管理员
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [OperationContract]
        bool IsAdministratorByUser(BaseUserInfo userInfo, string userId);

        /// <summary>
        /// 07.获得当前用户的所有权限列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetPermissionDT(BaseUserInfo userInfo);

        /// <summary>
        /// 08.获得某个用户的所有权限列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetPermissionDTByUser(BaseUserInfo userInfo, string userId);

        /// <summary>
        /// 09.当前用户是否对某个模块有相应的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleCode">模块编号</param>
        /// <returns>是否有权限</returns>
        [OperationContract]
        bool IsModuleAuthorized(BaseUserInfo userInfo, string moduleCode);

        /// <summary>
        /// 10.某个用户是否对某个模块有相应的权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="moduleCode">模块编号</param>
        /// <returns>是否有权限</returns>
        [OperationContract]
        bool IsModuleAuthorizedByUser(BaseUserInfo userInfo, string userId, string moduleCode);

        /// <summary>
        /// 11.获得用户的数据权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限域编号</param>
        /// <returns>数据权限范围</returns>
        [OperationContract]
        PermissionScope GetUserPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode);


        //////////////////////////////////////////////////////////////////////////////////////////////////////
        /// 用户权限范围判断相关(需要实现对外调用)
        //////////////////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 12.按某个数据权限获取组织列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限域编号</param>
        /// <param name="childrens">包含子节点</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetOrganizeDTByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode, bool childrens = true);

        /// <summary>
        /// 13.按某个数据权限获取组织主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限域编号</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetOrganizeIdsByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode);

        /// <summary>
        /// 14.按某个数据权限获取角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限域编号</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetRoleDTByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode);

        /// <summary>
        /// 15.按某个数据权限获取角色主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限域编号</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetRoleIdsByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode);

        /// <summary>
        /// 16.按某个权限域获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限域编号</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetUserDTByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode);

        /// <summary>
        /// 17.按某个数据权限获取用户主键数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限域编号</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetUserIdsByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode);

        /// <summary>
        /// 18.按某个权限域获取模块列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限域编号</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetModuleDTByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode);

        /// <summary>
        /// 19.有授权权限的权限列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限域编号</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetPermissionItemDTByPermissionScope(BaseUserInfo userInfo, string userId, string permissionItemCode);
    }
}