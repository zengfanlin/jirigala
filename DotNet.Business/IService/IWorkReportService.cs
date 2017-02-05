//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// IWorkReport
    /// 工作日志
    /// 
    /// 修改纪录
    /// 
    ///     2008.06.09 版本:1.2 吉日嘎拉 CheckWorkDate的修改
    ///     2008.05.21 版本:1.1 吉日嘎拉 GetDataTableByUser的修改
    ///     2008.05.17 版本:1.1 吉日嘎拉 审核管理查询中添加姓名查询
    ///     2008.05.16 版本:1.1 吉日嘎拉 主键的优化
    ///     2008.05.08 版本:1.0 吉日嘎拉 公司主键及部门主键两个数据字段的添加,对于部分主键进行修改
    ///     2008.04.29 版本:1.0 吉日嘎拉 创建主键
    /// 
    /// 版本:1.2
    /// 
    /// <author>
    ///     <name>吉日嘎拉</name>
    ///     <date>2008.04.29</date>
    /// </author>
    /// </summary>
    [ServiceContract]
    public interface IWorkReportService
    {
        /// <summary>
        /// 获取一个工作日志列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTable(BaseUserInfo userInfo, string id);

        /// <summary>
        /// 获取职员工作日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="staffId">职员主键</param>
        /// <param name="reportDate">日期</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableByUser(BaseUserInfo userInfo, string staffId, string reportDate);

        /// <summary>
        /// 更新工作日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="statusCode">返回的状态码</param>
        /// <param name="statusMessage">返回的状态信息</param>
        /// <returns>影响的行数</returns>
        [OperationContract]
        int Update(BaseUserInfo userInfo, DataTable dataTable, out string statusCode, out string statusMessage);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Add(BaseUserInfo userInfo, DataTable dataTable, out string statusCode, out string statusMessage);

        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchDelete(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 查询审核列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <param name="enabled">有效</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable SearchAuditing(BaseUserInfo userInfo, DateTime startDate, DateTime endDate, int enabled);

        /// <summary>
        /// 批量设置审核状态
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <param name="enabled">有效</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        bool BatchSetEnabled(BaseUserInfo userInfo, string[] ids, int enabled);

        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="dataTable">数据表</param>
        /// <param name="enabled">有效性</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="endDate">结束日期</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable BatchSave(BaseUserInfo userInfo, DataTable dataTable, int enabled, DateTime startDate, DateTime endDate);

        /// <summary>
        ///  获取项目列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetProjectDT(BaseUserInfo userInfo);

        /// <summary>
        /// 获取项目全称
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>项目全称</returns>
        [OperationContract]
        string GetProjectFullName(BaseUserInfo userInfo, string id);

        /// <summary>
        /// 检查工作日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="paramstaffId">当前查询职员主键</param>
        /// <returns>日期数组</returns>
        [OperationContract]
        DateTime[] CheckWorkDate(BaseUserInfo userInfo, string staffId);

        /// <summary>
        /// 求某天工时之和
        /// </summary>
        /// <param name="userInfo">当前操作员信息</param>
        /// <param name="paramStaffID">职员主键</param>
        /// <param name="paramDate">日期</param>
        /// <returns>工时之和</returns>
        [OperationContract]
        Double SumManHour(BaseUserInfo userInfo, string staffId, DateTime paramDate);
    }
}
