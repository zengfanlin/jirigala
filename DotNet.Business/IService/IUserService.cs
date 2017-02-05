//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.Collections.Generic;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// IUserService
    /// 
    /// 修改纪录
    /// 
    ///		2010.09.26 版本：1.3 JiRiGaLa 添加GetDataTableByDepartment接口。
    ///		2010.04.25 版本：1.2 JiRiGaLa 添加Exists接口。
    ///		2008.10.25 版本：1.1 JiRiGaLa 添加OpenId登录接口。
    ///		2008.04.01 版本：1.0 JiRiGaLa 添加接口定义。
    ///		
    /// 版本：1.3
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.09.26</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IUserService
    {
        /// <summary>
        /// 用户名是否重复
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parameters">字段名称，值</param>
        /// <returns>已存在</returns>
        [OperationContract]
        bool Exists(BaseUserInfo userInfo, List<KeyValuePair<string, object>> parameters);

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="userEntity">用户实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string AddUser(BaseUserInfo userInfo, BaseUserEntity userEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 按部门获取部门用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="departmentId">部门主键</param>
        /// <param name="containChildren">含子部门</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByDepartment(BaseUserInfo userInfo, string departmentId, bool containChildren);

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        BaseUserEntity GetEntity(BaseUserInfo userInfo, string id);
       
        /// <summary>
        /// 获得用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTable(BaseUserInfo userInfo);

        /// <summary>
        /// 按主键获取
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByIds(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 按角色获取用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByRole(BaseUserInfo userInfo, string roleId);

        /// <summary>
        /// 查询用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userName">用户名</param>
        /// <param name="auditStates">用户状态</param>
        /// <param name="roleIds">角色主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable Search(BaseUserInfo userInfo, string userName, string auditStates, string[] roleIds);

        /// <summary>
        /// 设置用户状态
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <param name="auditStates">审核状态</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetUserAuditStates(BaseUserInfo userInfo, string[] ids, AuditStatus auditStatus);

        /// <summary>
        /// 设置用户的默认角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int SetDefaultRole(BaseUserInfo userInfo, string userId, string roleId);

        /// <summary>
        /// 批量设置用户的默认角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userIds">用户主键</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int BatchSetDefaultRole(BaseUserInfo userInfo, string[] userIds, string roleId);

        /// <summary>
        /// 单个删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Delete(BaseUserInfo userInfo, string id);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDelete(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 批量打删除标志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetDeleted(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 获取用户类型
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetRoleDT(BaseUserInfo userInfo);

        /// <summary>
        /// 用户是否在某个角色里
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="roleCode">角色编号</param>
        /// <returns>存在</returns>
        [OperationContract]
        bool UserIsInRole(BaseUserInfo userInfo, string userId, string roleCode);

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        /// <param name="userEntity">用户实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int UpdateUser(BaseUserInfo userInfo, BaseUserEntity userEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 获取员工角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="staffId">员工主键</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetUserRoleIds(BaseUserInfo userInfo, string userId);

        /// <summary>
        /// 批量加入到员工
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="staffId">员工主键</param>
        /// <param name="addToRoleIds">加入角色主键集</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int AddUserToRole(BaseUserInfo userInfo, string userId, string[] addToRoleIds);

        /// <summary>
        /// 批量移出角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="staffId">员工主键</param>
        /// <param name="removeRoleIds">移出角色主键集</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int RemoveUserFromRole(BaseUserInfo userInfo, string userId, string[] removeRoleIds);

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchSave(BaseUserInfo userInfo, DataTable dataTable);

        /// <summary>
        /// 获得用户的组织机构兼职情况
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetUserOrganizeDT(BaseUserInfo userInfo, string userId);

        [OperationContract]
        bool UserIsInOrganize(BaseUserInfo userInfo, string userId, string organizeName);

        /// <summary>
        /// 用户帐户添加到组织机构
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userOrganizeEntity">用户组织关系</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string AddUserToOrganize(BaseUserInfo userInfo, BaseUserOrganizeEntity userOrganizeEntity, out string statusCode, out string statusMessage);
        
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDeleteUserOrganize(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 清除用户归属的角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int ClearUserRole(BaseUserInfo userInfo, string userId);
    }
}