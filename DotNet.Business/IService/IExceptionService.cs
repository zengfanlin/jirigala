//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// IExceptionService
    /// 
    /// 修改纪录
    /// 
    ///		2008.04.02 版本：1.0 JiRiGaLa 添加接口定义。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.02</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IExceptionService
    {
        /// <summary>
        /// 获取异常列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTable(BaseUserInfo userInfo);

        /// <summary>
        /// 批量删除异常
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable Delete(BaseUserInfo userInfo, string id);

        /// <summary>
        /// 批量删除异常
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDelete(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 清除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Truncate(BaseUserInfo userInfo);
    }
}