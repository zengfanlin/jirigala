//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// IFileService
    /// 
    /// 修改纪录
    /// 
    ///		2008.04.29 版本：1.0 JiRiGaLa 添加接口定义。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.29</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IFileService
    {
        /// <summary>
        /// 发送文件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fileName">文件名</param>
        /// <param name="file">文件内容</param>
        /// <param name="toUserId">发送给谁主键</param>
        /// <returns>文件主键</returns>
        [OperationContract]
        string Send(BaseUserInfo userInfo, string fileName, byte[] file, string toUserId);

        /// <summary>
        /// 文件是否已存在
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderId">文件夹主键</param>
        /// <param name="fileName">文件名</param>
        /// <returns>是否已存在</returns>
        [OperationContract]
        bool Exists(BaseUserInfo userInfo, string folderId, string fileName);

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>文件</returns>
        [OperationContract]
        byte[] Download(BaseUserInfo userInfo, string id);

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderId">文件夹主键</param>
        /// <param name="fileName">文件名</param>
        /// <param name="file">文件</param>
        /// <param name="description">描述</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Upload(BaseUserInfo userInfo, string folderId, string fileName, byte[] file, bool enabled);

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        BaseFileEntity GetEntity(BaseUserInfo userInfo, string id);

        /// <summary>
        /// 按文件夹获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderId">文件夹主键</param>
        /// <returns>数据权限</returns>
        [OperationContract]
        DataTable GetDataTableByFolder(BaseUserInfo userInfo, string folderId);

        /// <summary>
        /// 按文件夹删除文件
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderId">文件夹主键</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int DeleteByFolder(BaseUserInfo userInfo, string folderId);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="folderId">文件夹主键</param>
        /// <param name="fileName">文件名</param>
        /// <param name="file">文件</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Add(BaseUserInfo userInfo, string folderId, string fileName, byte[] file, string description, bool enabled, out string statusCode, out string statusMessage);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <param name="folderId">文件夹</param>
        /// <param name="fileName">文件名</param>
        /// <param name="description">描述</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Update(BaseUserInfo userInfo, string id, string folderId, string fileName, string description, bool enabled, out string statusCode, out string statusMessage);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <param name="fileName">文件名</param>
        /// <param name="file">文件</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int UpdateFile(BaseUserInfo userInfo, string id, string fileName, byte[] file, out string statusCode, out string statusMessage);

        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <param name="newName">新名称</param>
        /// <param name="enabled">有效</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Rename(BaseUserInfo userInfo, string id, string newName, bool enabled, out string statusCode, out string statusMessage);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="search">查询</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable Search(BaseUserInfo userInfo, string searchValue);

        /// <summary>
        /// 按主键数组获取列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByIds(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <param name="folderId">文件夹主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int MoveTo(BaseUserInfo userInfo, string id, string folderId);

        /// <summary>
        /// 批量移动数据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <param name="folderId">文件夹主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchMoveTo(BaseUserInfo userInfo, string[] ids, string folderId);

        /// <summary>
        /// 删除
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
        /// 批量保存
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int BatchSave(BaseUserInfo userInfo, DataTable dataTable);
    }
}
