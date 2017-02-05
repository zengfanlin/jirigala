//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// IItemsService
    /// 
    /// 修改纪录
    /// 
    ///		2008.04.02 版本：1.0 JiRiGaLa 创建主键。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.02</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IItemsService
    {
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        [OperationContract]
        DataTable GetDataTable(BaseUserInfo userInfo);

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        [OperationContract]
        BaseItemsEntity GetEntity(BaseUserInfo userInfo, string id);

        /// <summary>
        /// 获取子列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="parentId">父节点主键</param>
        [OperationContract]
        DataTable GetDataTableByParent(BaseUserInfo userInfo, string parentId);

        /// <summary>
        /// 添加编码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="itemsEntity">实体</param>
        /// <param name="statusCode">状态返回码</param>
        /// <param name="statusMessage">状态返回信息</param>
        [OperationContract]
        string Add(BaseUserInfo userInfo, BaseItemsEntity itemsEntity, out string statusCode, out string statusMessage);
                
        /// <summary>
        /// 创建表结构
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="tableName">表名</param>
        /// <param name="statusCode">状态返回码</param>
        /// <param name="statusMessage">状态返回信息</param>
        [OperationContract]
        void CreateTable(BaseUserInfo userInfo, string tableName, out string statusCode, out string statusMessage);        

        /// <summary>
        /// 更新编码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="itemsEntity">实体</param>
        /// <param name="statusCode">状态返回码</param>
        /// <param name="statusMessage">状态返回信息</param>
        [OperationContract]
        int Update(BaseUserInfo userInfo, BaseItemsEntity itemsEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="tableName">目标表</param>
        /// <param name="id">主键</param>
        [OperationContract]
        int Delete(BaseUserInfo userInfo, string tableName, string id);

        /// <summary>
        /// 批量删除编码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="tableName">目标表</param>
        /// <param name="ids">主键数组</param>
        [OperationContract]
        int BatchDelete(BaseUserInfo userInfo, string tableName, string[] ids);

        /// <summary>
        /// 批量移动编码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="tableName">目标表</param>
        /// <param name="ids">编码主键数组</param>
        /// <param name="targetId">父级主键</param>
        [OperationContract]
        int BatchMoveTo(BaseUserInfo userInfo, string tableName, string[] ids, string targetId);

        /// <summary>
        /// 批量保存编码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="dataTable">影响行数</param>
        [OperationContract]
        int BatchSave(BaseUserInfo userInfo, DataTable dataTable);
    }
}
