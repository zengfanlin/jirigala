//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Globalization;

namespace DotNet.Utilities
{
    /// <summary>
    ///	AppMessage
    /// 通用讯息控制基类
    /// 
    /// 修改纪录
    ///		2007.05.17 版本：1.0	JiRiGaLa 建立，为了提高效率分开建立了类。
    ///	
    /// 版本：3.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.17</date>
    /// </author> 
    /// </summary>
    public partial class AppMessage
    {
        // ExceptionService异常纪录服务及相关的方法名称定义
        public static string ExceptionService = "异常纪录服务";
        public static string ExceptionService_GetDataTable = "取得异常列表";
        public static string ExceptionService_BatchDelete = "删除异常";
        public static string ExceptionService_Delete = "批量删除异常";
        public static string ExceptionService_Truncate = "清除全部异常";

        // FileService档案服务及相关的方法名称定义
        public static string FileService = "档案服务";
        public static string FileService_SystemCreateDirectory = "系统创建目录";
        public static string FileService_CompanyFile = "公司文档";
        public static string FileService_UserSpace = "用户空间";
        public static string FileService_Folder = " 的文件夾";
        public static string FileService_SendFile = "发送的文件";
        public static string FileService_File = " 的文件";
        public static string FileService_ReceiveFile = "收到的文件";
        public static string FileService_SendFileFrom = " 发送文件 ";
        public static string FileService_CheckReceiveFile = "，请注意查收。";
        public static string FileService_GetEntity = "取得实体";
        public static string FileService_Exists = "判断是否存在";
        public static string FileService_Download = "下载文件";
        public static string FileService_Upload = "上传档案";
        public static string FileService_GetDataTableByFolder = "依文件夹取得档案列表";
        public static string FileService_GetDataTableByIds = "依文件ID取得档案列表";
        public static string FileService_DeleteByFolder = "依文件夹删除档案";

        // FolderService文件夹服务及相关的方法名称定义
        public static string FolderService = "文件夹服务";

        // ItemDetailsService选项明细管理服务及相关的方法名称定义
        public static string ItemDetailsService = "选项明细管理服务";
        public static string ItemDetailsService_GetDataTable = "取得列表";
        public static string ItemDetailsService_GetDataTableByParent = "依父节点取得列表";
        public static string ItemDetailsService_GetDataTableByCode = "依编号取得列表";
        public static string ItemDetailsService_GetDSByCodes = "批量取得资料";
        public static string ItemDetailsService_GetEntity = "取得实体";
        public static string ItemDetailsService_Add = "新增实体";
        public static string ItemDetailsService_Update = "更新实体";
        public static string ItemDetailsService_Delete = "删除实体";
        public static string ItemDetailsService_BatchMoveTo = "批量移动";
        public static string ItemDetailsService_BatchDelete = "批量删除";
        public static string ItemDetailsService_BatchSave = "批量储存";

        // ItemsService选项管理服务及相关的方法名称定义
        public static string ItemsService = "选项管理服务";
        public static string ItemsService_GetDataTable = "取得列表";
        public static string ItemsService_GetEntity = "取得实体";
        public static string ItemsService_GetDataTableByParent = "依父节点取得列表";
        public static string ItemsService_Add = "新增实体";
        public static string ItemsService_Update = "更新实体";
        public static string ItemsService_CreateTable = "新增数据表";
        public static string ItemsService_Delete = "删除实体";
        public static string ItemsService_BatchMoveTo = "批量移动";
        public static string ItemsService_BatchDelete = "批量删除";
        public static string ItemsService_BatchSave = "批量储存";

        // LogOnService登入服务及相关的方法名称定义
        public static string LogOnService = "登入服务";
        public static string LogOnService_GetUserDT = "取得用户列表";
        public static string LogOnService_GetStaffUserDT = "取得内部员工列表";
        public static string LogOnService_OnLine = "用户在线报导";
        public static string LogOnService_OnExit = "用户退出应用程序";
        public static string LogOnService_LockUser = "锁定用户";
        public static string LogOnService_SetPassword = "设定用户密码";
        public static string LogOnService_ChangePassword = "用户变更密码";
        public static string LogOnService_ChangeCommunicationPassword = "用户变更通讯密码";
        public static string LogOnService_CommunicationPassword = "验证用户通讯密码";
        public static string LogOnService_CreateDigitalSignature = "建立数字证书签名";
        public static string LogOnService_GetPublicKey = "取得当前用户的公钥";
        public static string LogOnService_ChangeSignedPassword = "用户变更签名密码";
        public static string LogOnService_SignedPassword = "验证用户数字签名密码";

        // LogService日志服务及相关的方法名称定义
        public static string LogService = "日志服务";
        public static string LogService_GetLogGeneral = "取得用户访问情况日志";
        public static string LogService_ResetVisitInfo = "重置用户访问情况";
        public static string LogService_GetDataTableByDate = "依日期取得日志";
        public static string LogService_GetDataTableByModule = "依菜单取得日志";
        public static string LogService_GetDataTableByUser = "依用户取得日志";
        public static string LogService_Delete = "删除日志";
        public static string LogService_BatchDelete = "批量删除日志";
        public static string LogService_Truncate = "清除全部日志";
        public static string LogService_GetDataTableApplicationByDate = "依日期取得日志(商务)";
        public static string LogService_BatchDeleteApplication = "批量删除日志(商务)";
        public static string LogService_TruncateApplication = "清除全部日志(商务)";

        // MessageService讯息服务及相关的方法名称定义
        public static string MessageService = "讯息服务";
        public static string MessageService_GetInnerOrganize = "取得内部组织机构";
        public static string MessageService_GetUserDTByDepartment = "按部门取得用户信息";
        public static string MessageService_BatchSend = "批量发送站内讯息";
        public static string MessageService_Send = "发送讯息";
        public static string MessageService_MessageChek = "取得讯息状态";
        public static string MessageService_ReadFromReceiver = "取得特定用户的新讯息";
        public static string MessageService_Read = "阅读讯息";

        // ModuleService菜单服务及相关的方法名称定义
        public static string ModuleService = "菜单服务";
        public static string ModuleService_GetDataTable = "取得列表";
        public static string ModuleService_GetEntity = "取得实体";
        public static string ModuleService_GetFullNameByCode = "透过编号取得菜单名称";
        public static string ModuleService_Add = "新增菜单";
        public static string ModuleService_Update = "更新菜单";
        public static string ModuleService_GetDataTableByParent = "依父节点取得列表";
        public static string ModuleService_Delete = "删除菜单";
        public static string ModuleService_BatchDelete = "批量删除";
        public static string ModuleService_SetDeleted = "批量标示删除标志";
        public static string ModuleService_MoveTo = "移动菜单";
        public static string ModuleService_BatchMoveTo = "批量移动";
        public static string ModuleService_BatchSave = "批量储存";
        public static string ModuleService_SetSortCode = "储存排序顺序";
        public static string ModuleService_GetPermissionDT = "取得关联的权限项列表";
        public static string ModuleService_GetIdsByPermission = "依操作权限项取得关联的菜单主键";

        public static string ModuleService_BatchAddPermissions = "菜单批量新增关联操作权限项";
        public static string ModuleService_BatchAddModules = "新增操作权限项关联菜单";
        public static string ModuleService_BatchDletePermissions = "删除菜单与操作权限项的关联";
        public static string ModuleService_BatchDleteModules = "删除操作权限项与菜单的关联";

        // OrganizeService组织机构服务及相关的方法名称定义
        public static string OrganizeService = "组织机构服务";
        public static string OrganizeService_Add = "新增实体";
        public static string OrganizeService_AddByDetail = "依明细情况新增实体";
        public static string OrganizeService_GetEntity = "取得实体";
        public static string OrganizeService_GetDataTable = "取得列表";
        public static string OrganizeService_GetDataTableByParent = "依父节点取得列表";
        public static string OrganizeService_GetInnerOrganizeDT = "取得内部组织机构";
        public static string OrganizeService_GetCompanyDT = "取得公司列表";
        public static string OrganizeService_GetDepartmentDT = "取得部门列表";
        public static string OrganizeService_Search = "查询组织机构";
        public static string OrganizeService_Update = "更新组织机构";
        public static string OrganizeService_Delete = "删除组织机构";
        public static string OrganizeService_BatchDelete = "批量删除";
        public static string OrganizeService_SetDeleted = "批量标示删除标志";
        public static string OrganizeService_BatchSave = "批量储存";
        public static string OrganizeService_MoveTo = "移动组织机构";
        public static string OrganizeService_BatchMoveTo = "批量移动";
        public static string OrganizeService_BatchSetCode = "批量重新产生编号";
        public static string OrganizeService_BatchSetSortCode = "批量重新产生排序码";

        // ParameterService参数服务及相关的方法名称定义
        public static string ParameterService = "参数服务";
        public static string ParameterService_GetParameter = "取得参数值";
        public static string ParameterService_SetParameter = "设置参数值";
        public static string ParameterService_GetDataTableByParameter = "取得列表";
        public static string ParameterService_GetDataTableParameterCode = "依编号取得列表";
        public static string ParameterService_DeleteByParameter = "删除参数";
        public static string ParameterService_DeleteByParameterCode = "依参数编号删除";
        public static string ParameterService_Delete = "删除参数";
        public static string ParameterService_BatchDelete = "批量删除参数";

        // PermissionItemService操作权限项定义服务及相关的方法名称定义
        public static string PermissionItemService = "操作权限项定义服务";
        public static string PermissionItemService_Add = "新增操作权限项";
        public static string PermissionItemService_GetDataTable = "取得列表";
        public static string PermissionItemService_GetDataTableByParent = "依父节点取得列表";
        public static string PermissionItemService_GetLicensedDT = "取得授权范围";
        public static string PermissionItemService_GetEntity = "取得实体";
        public static string PermissionItemService_GetEntityByCode = "依编号取得实体";
        public static string PermissionItemService_Update = "更新实体";
        public static string PermissionItemService_MoveTo = "移动实体";
        public static string PermissionItemService_BatchMoveTo = "批量移动实体";
        public static string PermissionItemService_Delete = "删除实体";
        public static string PermissionItemService_BatchDelete = "批量删除实体";
        public static string PermissionItemService_SetDeleted = "批量标示删除标志";
        public static string PermissionItemService_BatchSave = "批量储存";
        public static string PermissionItemService_BatchSetSortCode = "重新产生排序码";
        public static string PermissionItemService_GetIdsByModule = "按模块主键获取操作权限项主键数组";

        // PermissionService权限判断服务及相关的方法名称定义
        public static string PermissionService = "权限判断服务";
        public static string PermissionService_IsInRole = "用户是否在指定的角色中";
        public static string PermissionService_IsAuthorizedByUser = "该用户是否有相应的操作权限";
        public static string PermissionService_IsAuthorizedByRole = "该角色是否有相应的操作权限";
        public static string PermissionService_IsAdministratorByUser = "该用户是否为超级管理员";
        public static string PermissionService_GetPermissionDTByUser = "取得该用户的所有权限列表";
        public static string PermissionService_IsModuleAuthorized = "当前用户是否对某个菜单有相应的权限";
        public static string PermissionService_IsModuleAuthorizedByUser = "该用户是否对某个菜单有相应的权限";
        public static string PermissionService_GetUserPermissionScope = "取得用户的数据权限范围";
        public static string PermissionService_GetOrganizeDTByPermission = "依某个权限域取得组织机构列表";
        public static string PermissionService_GetOrganizeIdsByPermission = "依某个数据权限取得组织机构主键数组";
        public static string PermissionService_GetRoleDTByPermission = "依某个权限域取得角色列表";
        public static string PermissionService_GetRoleIdsByPermission = "按权限取得角色数组列表";
        public static string PermissionService_GetUserDTByPermission = "依某个权限域取得用户列表";
        public static string PermissionService_GetUserIdsByPermission = "依某个数据权限取得用户主键数组";
        public static string PermissionService_GetModuleDTByPermission = "依某个权限域取得菜单列表";
        public static string PermissionService_GetPermissionItemDTByPermission = "用户的所有可授权范围(有授权权限的权限列表)";
        public static string PermissionService_GetRolePermissionItemIds = "取得角色权限主键数组";
        public static string PermissionService_GrantRolePermissions = "授予角色的权限";
        public static string PermissionService_GrantRolePermissionById = "授予角色的权限";
        public static string PermissionService_RevokeRolePermissions = "删除角色的权限";
        public static string PermissionService_ClearRolePermission = "清除角色权限";
        public static string PermissionService_RevokeRolePermissionById = "删除角色的权限";
        public static string PermissionService_GetRoleScopeUserIds = "取得角色的某个权限域的组织范围";
        public static string PermissionService_GetRoleScopeRoleIds = "取得角色的某个权限域的组织范围";
        public static string PermissionService_GetRoleScopeOrganizeIds = "取得角色的某个权限域的组织范围";
        public static string PermissionService_GrantRoleUserScopes = "授予角色的某个权限域的组织范围";
        public static string PermissionService_RevokeRoleUserScopes = "删除角色的某个权限域的组织范围";
        public static string PermissionService_GrantRoleRoleScopes = "授予角色的某个权限域的组织范围";
        public static string PermissionService_RevokeRoleRoleScopes = "删除角色的某个权限域的组织范围";
        public static string PermissionService_GrantRoleOrganizeScopes = "授予角色的某个权限域的组织范围";
        public static string PermissionService_RevokeRoleOrganizeScopes = "删除角色的某个权限域的组织范围";
        public static string PermissionService_GetRoleScopePermissionItemIds = "取得角色授权权限列表";
        public static string PermissionService_GrantRolePermissionItemScopes = "授予角色的授权权限范围";
        public static string PermissionService_RevokeRolePermissionItemScopes = "授予角色的授权权限范围";
        public static string PermissionService_ClearRolePermissionScope = "清除角色权限范围";
        public static string PermissionService_GetUserPermissionItemIds = "取得用户权力主键数组";
        public static string PermissionService_GrantUserPermissions = "授予用户操作权限";
        public static string PermissionService_GrantUserPermissionById = "授予用户操作权限";
        public static string PermissionService_RevokeUserPermission = "删除用户操作权限";
        public static string PermissionService_RevokeUserPermissionById = "删除用户操作权限";
        public static string PermissionService_GetUserScopeOrganizeIds = "取得用户的某个权限域的组织范围";
        public static string PermissionService_GrantUserOrganizeScopes = "设置用户的某个权限域的组织范围";
        public static string PermissionService_RevokeUserOrganizeScopes = "设置用户的某个权限域的组织范围";
        public static string PermissionService_GetUserScopeUserIds = "取得用户的某个权限域的组织范围";
        public static string PermissionService_GrantUserUserScopes = "设置用户的某个权限域的组织范围";
        public static string PermissionService_RevokeUserUserScopes = "设置用户的某个权限域的用户范围";
        public static string PermissionService_GetUserScopeRoleIds = "取得用户的某个权限域的用户范围";
        public static string PermissionService_GrantUserRoleScopes = "设置用户的某个权限域的用户范围";
        public static string PermissionService_RevokeUserRoleScopes = "设置用户的某个权限域的用户范围";
        public static string PermissionService_GetUserScopePermissionItemIds = "取得用户授权权限列表";
        public static string PermissionService_GrantUserPermissionItemScopes = "授予用户的授权权限范围";
        public static string PermissionService_RevokeUserPermissionItemScopes = "删除用户的授权权限范围";
        public static string PermissionService_ClearUserPermission = "清除用户权力";
        public static string PermissionService_ClearUserPermissionScope = "清除用户权力范围";
        public static string PermissionService_GetModuleDTByUser = "取得用户有访问权限的菜单";
        public static string PermissionService_GetUserScopeModuleIds = "取得用户菜单权限范围主键数组";
        public static string PermissionService_GrantUserModuleScopes = "授予用户菜单的权限范围";
        public static string PermissionService_GrantUserModuleScope = "授予用户菜单的权限范围";
        public static string PermissionService_RevokeUserModuleScope = "删除用户菜单的权限范围";
        public static string PermissionService_RevokeUserModuleScopes = "删除用户菜单的权限范围";
        public static string PermissionService_GetRoleScopeModuleIds = "取得用户菜单权限范围主键数组";
        public static string PermissionService_GrantRoleModuleScopes = "授予用户菜单的权限范围";
        public static string PermissionService_GrantRoleModuleScope = "授予用户菜单的权限范围";
        public static string PermissionService_RevokeRoleModuleScopes = "删除用户菜单的权限范围";
        public static string PermissionService_RevokeRoleModuleScope = "删除用户菜单的权限范围";

        public static string PermissionService_GetOrganizePermissionItemIds = "取得组织机构权限主键数组";
        public static string PermissionService_GrantOrganizePermissions = "授予组织机构的权限";
        public static string PermissionService_GrantOrganizePermissionById = "授予组织机构的权限";
        public static string PermissionService_RevokeOrganizePermissions = "删除组织机构的权限";
        public static string PermissionService_RevokeOrganizePermissionById = "删除组织机构的权限";
        public static string PermissionService_ClearOrganizePermission = "清除组织机构权限";
        public static string PermissionService_GetOrganizeScopeModuleIds = "取得组织机构菜单权限范围主键数组";
        public static string PermissionService_GrantOrganizeModuleScopes = "授予组织机构菜单的权限范围";
        public static string PermissionService_GrantOrganizeModuleScope = "授予组织机构菜单的权限范围";
        public static string PermissionService_RevokeOrganizeModuleScopes = "删除组织机构菜单的权限范围";
        public static string PermissionService_RevokeOrganizeModuleScope = "删除组织机构菜单的权限范围";

        public static string PermissionService_GetResourcePermissionItemIds = "取得资源权限主键数组";
        public static string PermissionService_GrantResourcePermission = "授予资源的权限";
        public static string PermissionService_RevokeResourcePermission = "删除资源的权限";
        public static string PermissionService_GetPermissionScopeTargetIds = "取得资源权限范围主键数组";
        public static string PermissionService_RevokePermissionScopeTargets = "删除资源的权限范围";
        public static string PermissionService_ClearPermissionScopeTarget = "删除资源的权限范围";
        public static string PermissionService_GetResourceScopeIds = "取得用户的某个资源的权限范围";
        public static string PermissionService_GetTreeResourceScopeIds = "取得用户的某个资源的权限范围(树型资源)";




        // RoleService角色管理服务及相关的方法名称定义
        public static string RoleService = "角色管理服务";
        public static string RoleService_Add = "新增角色";
        public static string RoleService_GetDataTable = "取得列表";
        public static string RoleService_GetDataTableByOrganize = "依组织机构取得角色列表";
        public static string RoleService_GetEntity = "取得实体";
        public static string RoleService_Update = "更新实体";
        public static string RoleService_GetDataTableByIds = "依主键数组取得角色列表";
        public static string RoleService_Search = "查询角色列表";
        public static string RoleService_BatchSave = "批量储存角色";
        public static string RoleService_MoveTo = "移动角色数据";
        public static string RoleService_BatchMoveTo = "批量移动角色数据";
        public static string RoleService_ResetSortCode = "排序角色顺序";
        public static string RoleService_GetRoleUserIds = "取得角色中的用户主键";
        public static string RoleService_AddUserToRole = "用户新增至角色";
        public static string RoleService_RemoveUserFromRole = "将用户从角色中移除";
        public static string RoleService_Delete = "删除角色";
        public static string RoleService_BatchDelete = "批量删除角色";
        public static string RoleService_SetDeleted = "批量标示删除标志";
        public static string RoleService_ClearRoleUser = "清除角色用户关联";

        // SequenceService序列管理服务及相关的方法名称定义
        public static string SequenceService = "序列管理服务";
        public static string SequenceService_Add = "新增序列";
        public static string SequenceService_GetDataTable = "取得列表";
        public static string SequenceService_GetEntity = "取得实体";
        public static string SequenceService_Update = "更新序列";
        public static string SequenceService_Reset = "批量重置序列";
        public static string SequenceService_Delete = "删除序列";
        public static string SequenceService_BatchDelete = "批量删除序列";

        // StaffService职员管理服务及相关的方法名称定义
        public static string StaffService = "职员管理服务";
        public static string StaffService_GetAddressDT = "取得内部通讯簿";
        public static string StaffService_GetAddressPageDT = "取得内部通讯簿";
        public static string StaffService_UpdateAddress = "更新通讯地址";
        public static string StaffService_BatchUpdateAddress = "批量更新通讯地址";
        public static string StaffService_AddStaff = "新增职员";
        public static string StaffService_UpdateStaff = "更新职员";
        public static string StaffService_GetDataTable = "取得列表";
        public static string StaffService_GetEntity = "取得实体";
        public static string StaffService_GetDataTableByIds = "取得职员列表";
        public static string StaffService_GetDataTableByDepartment = "依部门取得列表";
        public static string StaffService_GetDataTableByOrganize = "依公司取得列表";
        public static string StaffService_SetStaffUser = "职员关联用户";

        // TableColumnsService表字段权限服务及相关的方法名称定义
        public static string TableColumnsService = "表字段权限服务";
        public static string TableColumnsService_GetDataTableByTable = "依表明取得字段列表";
        public static string TableColumnsService_GetConstraintDT = "取得约束条件(所有的约束)";
        public static string TableColumnsService_GetUserConstraint = "取得当前用户的约束条件";
        public static string TableColumnsService_SetConstraint = "设置约束条件";
        public static string TableColumnsService_BatchDeleteConstraint = "批量删除";

        // UserService用户管理服务及相关的方法名称定义
        public static string UserService = "用户管理服务";
        public static string UserService_Check = "请审核。";
        public static string UserService_Application = " 申请帐户：";
        public static string UserService_AddUser = "新增用户";
        public static string UserService_GetDataTableByDepartment = "依部门取得用户列表";
        public static string UserService_GetEntity = "取得实体";
        public static string UserService_GetDataTable = "取得列表";
        public static string UserService_GetDataTableByRole = "依角色取得列表";
        public static string UserService_GetDataTableByIds = "依主键取得列表";
        public static string UserService_GetRoleDT = "取得用户的角色列表";
        public static string UserService_UserInRole = "判断用户是否在某个角色中";
        public static string UserService_UpdateUser = "更新用户";
        public static string UserService_Search = "查询用户";
        public static string UserService_SetUserAuditStates = "设置用户审核状态";
        public static string UserService_SetDefaultRole = "设置用户的预设角色";

        // WorkFlowActivityAdminService工作流程定义服务及相关的方法名称定义
        public static string WorkFlowActivityAdminService = "工作流程定义服务";

        // WorkFlowCurrentService当前工作流程服务
        public static string WorkFlowCurrentService = "当前工作流程服务";

        // WorkFlowProcessAdminService工作流程处理过程服务
        public static string WorkFlowProcessAdminService = "工作流程处理过程服务";

        // BillTemplateService单据模板服务
        public static string BillTemplateService = "单据模板服务";
    }
}