//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// IParameterService
    /// 参数服务接口
    /// 
    /// 修改纪录
    /// 
    ///		2008.04.30 版本：1.0 JiRiGaLa 添加接口定义。
    ///		2011.07.15 版本：2.0 JiRiGaLa 获取服务器端配置的功能改进。
    ///		
    /// 版本：2.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.07.15</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IParameterService
    {
        /// <summary>
        /// 获取服务器上的配置信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="key">配置项主键</param>
        /// <returns>配置内容</returns>
        [OperationContract]
        string GetServiceConfig(BaseUserInfo userInfo, string key);

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryId">类别主键</param>
        /// <param name="parameterId">标志主键</param>
        /// <param name="parameterCode">编码</param>
        /// <returns>数据权限</returns>
        [OperationContract]
        string GetParameter(BaseUserInfo userInfo, string categoryId, string parameterId, string parameterCode);

        /// <summary>
        /// 更新参数设置
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryId">类别主键</param>
        /// <param name="parameterId">标志主键</param>
        /// <param name="parameterCode">编码</param>
        /// <param name="parameterContent">参数内容</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetParameter(BaseUserInfo userInfo, string categoryId, string parameterId, string parameterCode, string parameterContent);

        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryId">类别主键</param>
        /// <param name="parameterId">标志主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByParameter(BaseUserInfo userInfo, string categoryId, string parameterId);

        /// <summary>
        /// 获取记录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryId">类别主键</param>
        /// <param name="parameterId">标志主键</param>
        /// <param name="parameterCode">编码</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableParameterCode(BaseUserInfo userInfo, string categoryId, string parameterId, string parameterCode);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryId">类别主键</param>
        /// <param name="parameterId">标志主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int DeleteByParameter(BaseUserInfo userInfo, string categoryId, string parameterId);
        
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryId">类别主键</param>
        /// <param name="parameterId">标志主键</param>
        /// <param name="parameterCode">标志编号</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int DeleteByParameterCode(BaseUserInfo userInfo, string categoryId, string parameterId, string parameterCode);

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
    }
}
