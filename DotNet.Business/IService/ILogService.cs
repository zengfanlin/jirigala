//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// ILogService
    /// 
    /// 修改纪录
    /// 
    ///		2008.04.02 版本：1.0 JiRiGaLa 添加接口定义。
    ///		2011.03.27 版本：1.1 JiRiGaLa 离开时的日志记录WriteExit函数补充。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.02</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface ILogService
    {
        /// <summary>
        /// 写入日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="processID">服务</param>
        /// <param name="processName">服务名称</param>
        /// <param name="methodId">操作</param>
        /// <param name="methodName">操作名称</param>
        /// <param name="description">描述</param>
        [OperationContract(IsOneWay = true)]
        void WriteLog(BaseUserInfo userInfo, string processId, string processName, string methodId, string methodName);

        /// <summary>
        /// 离开时的日志记录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="logId">日志主键</param>
        [OperationContract(IsOneWay = true)]
        void WriteExit(BaseUserInfo userInfo, string logId);

        /// <summary>
        /// 获取日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetLogGeneral(BaseUserInfo userInfo);

        /// <summary>
        /// 重置访问情况
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">日志主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable ResetVisitInfo(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 按日期获取日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <param name="userId">用户主键</param>
        /// <param name="moduleId">模块主键</param> 
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByDate(BaseUserInfo userInfo, string beginDate, string endDate, string userId, string moduleId);

        /// <summary>
        /// 按模块获取日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="moduleId">模块主键</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByModule(BaseUserInfo userInfo, string moduleId, string beginDate, string endDate);

        /// <summary>
        /// 按员工获取日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByUser(BaseUserInfo userInfo, string userId, string beginDate, string endDate);

        /// <summary>
        /// 删除日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Delete(BaseUserInfo userInfo, string id);

        /// <summary>
        /// 批量删除日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDelete(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 清除日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        void Truncate(BaseUserInfo userInfo);

        /// <summary>
        /// 按日期获取日志（业务）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="beginDate">开始时间</param>
        /// <param name="endDate">结束时间</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableApplicationByDate(BaseUserInfo userInfo, string beginDate, string endDate);

        /// <summary>
        /// 批量删除日志(业务)
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDeleteApplication(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 清除日志(业务)
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        void TruncateApplication(BaseUserInfo userInfo);

        /// <summary>
        /// 查询日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="search">查询</param>
        /// <param name="OnlyOnLine">是否在线</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable Search(BaseUserInfo userInfo, string searchValue, bool OnlyOnLine);
    }
}