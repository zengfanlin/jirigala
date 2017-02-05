//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;
    
    /// <summary>
    /// IPermissionItemService
    /// 对权限配置表的操作
    /// 
    /// 修改纪录
    /// 
    ///		2008.09.02 版本：1.3 JiRiGaLa 将命名修改为 IPermissionAdminService 。
    ///		2008.06.12 版本：1.2 JiRiGaLa 传递类对象。
    ///		2008.05.09 版本：1.1 JiRiGaLa 命名修改为IPermissionService。
    ///		2008.03.23 版本：1.0 JiRiGaLa 添加权限。
    ///		
    /// 版本：1.3
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.09.02</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IPermissionItemService
    {
        /// <summary>
        /// 获得权限列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTable(BaseUserInfo userInfo);

        /// <summary>
        /// 获得列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parentId">父亲节点主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByParent(BaseUserInfo userInfo, string parentId);

        /// <summary>
        /// 添加一个权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemEntity">权限实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>数据表</returns>
        [OperationContract]
        string Add(BaseUserInfo userInfo, BasePermissionItemEntity permissionItemEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 按明细添加一个操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="code">编号</param>
        /// <param name="fullName">名称</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string AddByDetail(BaseUserInfo userInfo, string code, string fullName, out string statusCode, out string statusMessage);

        /// <summary>
        /// 获取一个操作权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        BasePermissionItemEntity GetEntity(BaseUserInfo userInfo, string id);

        /// <summary>
        /// 按编号获取名称
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="code">编号</param>
        /// <returns>实体</returns>
        [OperationContract]
        BasePermissionItemEntity GetEntityByCode(BaseUserInfo userInfo, string code);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemEntity">权限实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Update(BaseUserInfo userInfo, BasePermissionItemEntity permissionItemEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 移动权限数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <param name="parentId">父结点主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int MoveTo(BaseUserInfo userInfo, string id, string parentId);

        /// <summary>
        /// 批量移动权限数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键组</param>
        /// <param name="parentId">父结点主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchMoveTo(BaseUserInfo userInfo, string[] ids, string parentId);

        /// <summary>
        /// 删除一个权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Delete(BaseUserInfo userInfo, string id);

        /// <summary>
        /// 批量删除权限
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
        /// 批量保存权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">权限数据表</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchSave(BaseUserInfo userInfo, DataTable dataTable);

        /// <summary>
        /// 保存权限排序顺序
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchSetSortCode(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 操作权限主健数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleId">模块主键</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetIdsByModule(BaseUserInfo userInfo, string moduleId);

        /// <summary>
        /// 按主键数组获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">组织机构主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByIds(BaseUserInfo userInfo, string[] ids);
    }
}