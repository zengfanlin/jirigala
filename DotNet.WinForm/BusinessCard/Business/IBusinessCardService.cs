//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.ServiceModel;

namespace DotNet.WinForm
{    
    using DotNet.Utilities;

    /// <summary>
    /// IBusinessCardService
    /// 名片管理接口
    /// 
    /// 修改纪录
    /// 
    ///		2008.11.10 版本：1.0 JiRiGaLa 创建主键。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.11.10</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IBusinessCardService
    {
        /// <summary>
        /// 获取全部列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTable(BaseUserInfo userInfo);

        /// <summary>
        /// 获取公开列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetPublicDT(BaseUserInfo userInfo);

        /// <summary>
        /// 获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByUser(BaseUserInfo userInfo);

        /// <summary>
        /// 获取某个
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable Get(BaseUserInfo userInfo, string id);

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        BaseBusinessCardEntity GetEntity(BaseUserInfo userInfo, string id);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="businessCardEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>主键主键</returns>
        [OperationContract]
        string AddEntity(BaseUserInfo userInfo, BaseBusinessCardEntity businessCardEntity, out string statusCode, out string statusMessage);


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>数据表</returns>
        [OperationContract]
        string Add(BaseUserInfo userInfo, DataTable dataTable, out string statusCode, out string statusMessage);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="businessCardEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int UpdateEntity(BaseUserInfo userInfo, BaseBusinessCardEntity businessCardEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状态信息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Update(BaseUserInfo userInfo, DataTable dataTable, out string statusCode, out string statusMessage);

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
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchSave(BaseUserInfo userInfo, DataTable dataTable);
    }
}
