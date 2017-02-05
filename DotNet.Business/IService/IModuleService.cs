//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// IModuleService
    /// 
    /// 修改纪录
    /// 
    ///		2008.04.03 版本：1.0 JiRiGaLa 添加接口定义。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.03</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IModuleService
    {
        /// <summary>
        /// 获取模块列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTable(BaseUserInfo userInfo);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByIds(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        BaseModuleEntity GetEntity(BaseUserInfo userInfo, string id);
        
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="code">编号</param>
        /// <returns>名称</returns>
        [OperationContract]
        string GetFullNameByCode(BaseUserInfo userInfo, string code);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Add(BaseUserInfo userInfo, BaseModuleEntity moduleEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Update(BaseUserInfo userInfo, BaseModuleEntity moduleEntity, out string statusCode, out string statusMessage);        

        /// <summary>
        /// 获得列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parentId">父结点主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByParent(BaseUserInfo userInfo, string parentId);

        /// <summary>
        /// 单个删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Delete(BaseUserInfo userInfo, string id);
        
        /// <summary>
        /// 批量删除模块
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <param name="parentId">父结点主键</param>
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
        /// 移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="parentId">父结点主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int MoveTo(BaseUserInfo userInfo, string moduleId, string parentId);

        /// <summary>
        /// 批量移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeIds">组织机构主键数组</param>
        /// <param name="parentId">父结点主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchMoveTo(BaseUserInfo userInfo, string[] moduleIds, string parentId);

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="parentId">父结点主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchSave(BaseUserInfo userInfo, DataTable dataTable);

        /// <summary>
        /// 保存排序顺序
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetSortCode(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 模块权限列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleId">模块主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetPermissionDT(BaseUserInfo userInfo, string moduleId);

        /// <summary>
        /// 菜单主健数组
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemId">操作权限主键</param>
        /// <returns>主键数组</returns>
        [OperationContract]
        string[] GetIdsByPermission(BaseUserInfo userInfo, string permissionItemId);

        /// <summary>
        /// 模块挂接权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleId">模块主键</param>
        /// <param name="permissionItemIds">权限主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchAddPermissions(BaseUserInfo userInfo, string moduleId, string[] permissionItemIds);

        /// <summary>
        /// 模块挂接权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="moduleIds">模块主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchAddModules(BaseUserInfo userInfo, string permissionItemId, string[] moduleIds);

        /// <summary>
        /// 撤销模块挂接权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleId">模块主键</param>
        /// <param name="permissionItemIds">权限主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDletePermissions(BaseUserInfo userInfo, string moduleId, string[] permissionItemIds);

        /// <summary>
        /// 撤销模块挂接权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="modulesIds">模块主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDleteModules(BaseUserInfo userInfo, string permissionItemId, string[] modulesIds);
    }
}