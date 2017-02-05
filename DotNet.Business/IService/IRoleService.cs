//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.ServiceModel;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// IRoleService
    /// 角色接口
    /// 
    /// 修改纪录
    /// 
    ///		2009.09.06 版本：1.2 JiRiGaLa IsInRole 增加。
    ///		2008.11.26 版本：1.1 JiRiGaLa 角色用户关系及角色权限关系相关函数整理。
    ///		2008.04.09 版本：1.0 JiRiGaLa 创建主键。
    ///		
    /// 版本：1.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.11.26</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IRoleService
    {
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Add(BaseUserInfo userInfo, BaseRoleEntity roleEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTable(BaseUserInfo userInfo);

        /// <summary>
        /// 获取默认角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDefaultRoleDT(BaseUserInfo userInfo);

        /// <summary>
        /// 获取业务角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetApplicationRole(BaseUserInfo userInfo);

        /// <summary>
        /// 获取用户群组列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetUserGroup(BaseUserInfo userInfo);
        
        /// <summary>
        /// 按组织机构获取角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByOrganize(BaseUserInfo userInfo, string organizeId);
        
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        BaseRoleEntity GetEntity(BaseUserInfo userInfo, string id);
        
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Update(BaseUserInfo userInfo, BaseRoleEntity roleEntity, out string statusCode, out string statusMessage);
        
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByIds(BaseUserInfo userInfo, string[] ids);
        
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="searchValue">查询字符串</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable Search(BaseUserInfo userInfo, string organizeId, string searchValue);
        
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleEntites">角色列表</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchSave(BaseUserInfo userInfo, List<BaseRoleEntity> roleEntites);
        
        /// <summary>
        /// 移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <param name="targetId">目标主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int MoveTo(BaseUserInfo userInfo, string id, string targetId);
        
        /// <summary>
        /// 批量移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <param name="targetId">目标主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchMoveTo(BaseUserInfo userInfo, string[] ids, string targetId);
        
        /// <summary>
        /// 排序顺序
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int ResetSortCode(BaseUserInfo userInfo, string organizeId);
        
        /// <summary>
        /// 获得角色中的用户主键
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>用户主键</returns>
        [OperationContract]
        string[] GetRoleUserIds(BaseUserInfo userInfo, string roleId);
        
        /// <summary>
        /// 用户添加到角色
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="addUserIds">用户主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int AddUserToRole(BaseUserInfo userInfo, string roleId, string[] addUserIds);

        /// <summary>
        /// 将用户从角色中移除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="userIds">用户主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int RemoveUserFromRole(BaseUserInfo userInfo, string roleId, string[] userIds);
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
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
        /// 清楚角色用户关联
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int ClearRoleUser(BaseUserInfo userInfo, string roleId);

        /// <summary>
        /// 按角色名获取角色列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">角色名</param>
        /// <returns>数据表</returns>
        DataTable GetDataTableByRoleName(BaseUserInfo userInfo, string roleName);
     }
}