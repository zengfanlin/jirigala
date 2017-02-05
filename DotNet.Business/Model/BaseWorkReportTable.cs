//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.Business
{
    /// <summary>
    /// BaseWorkReportEntity
    /// 
    /// 修改记录
    /// 
    ///     2008.05.16 版本:1.0 吉日嘎拉 字段Project改为 ProjectFullName, 添加一个字段 StaffFullName
    ///     2008.05.15 版本:1.0 吉日嘎拉 添加项目主键和工作日志分类主键两个数据字段,修改字段(Item改为Project)
    ///     2008.05.08 版本:1.0 吉日嘎拉 添加部门主键和公司主键两个数据字段
    ///     2008.05.04 版本:1.0 吉日嘎拉 主键的创建
    ///
    /// 版本1.1
    /// 
    /// <author>
    ///     <name>吉日嘎拉</name>
    ///     <date>2008.05.04</date>
    /// </author>
    /// </summary>
    public partial class BaseWorkReportEntity
    {
        /// <summary>
        /// 表名
        /// </summary>
        [NonSerialized]
        public static string TableName = "BaseWorkReport";

        /// <summary>
        /// 主键
        /// </summary>
        [NonSerialized]
        public static string FieldId = "Id";

        /// <summary>
        /// 公司主键
        /// </summary>
        [NonSerialized]
        public static string FieldCompanyId = "CompanyId";

        /// <summary>
        /// 部门主键
        /// </summary>
        [NonSerialized]
        public static string FieldDepartmentId = "DepartmentId";

        /// <summary>
        /// 职员主键
        /// </summary>
        [NonSerialized]
        public static string FieldStaffId = "StaffId";

        /// <summary>
        /// 职员姓名
        /// </summary>
        [NonSerialized]
        public static string FieldStaffFullName = "StaffFullName";

        /// <summary>
        /// 工作日志分类主键
        /// </summary>
        [NonSerialized]
        public static string FieldCategoryId = "CategoryId";

        /// <summary>
        /// 工作日志分类
        /// </summary>
        [NonSerialized]
        public static string FieldCategoryFullName = "CategoryFullName";

        /// <summary>
        /// 项目主键
        /// </summary>
        [NonSerialized]
        public static string FieldProjectId = "ProjectId";

        /// <summary>
        /// 项目
        /// </summary>
        [NonSerialized]
        public static string FieldProjectFullName = "ProjectFullName";

        /// <summary>
        /// 工作日志的日期
        /// </summary>
        [NonSerialized]
        public static string FieldWorkDate = "WorkDate";

        /// <summary>
        /// 工作日志内容
        /// </summary>
        [NonSerialized]
        public static string FieldContent = "Content";

        /// <summary>
        /// 工时
        /// </summary>
        [NonSerialized]
        public static string FieldManHour = "ManHour";

        /// <summary>
        /// 评分
        /// </summary>
        [NonSerialized]
        public static string FieldScore = "Score";

        /// <summary>
        /// 描述
        /// </summary>
        [NonSerialized]
        public static string FieldDescription = "Description";

        /// <summary>
        /// 审核状态
        /// </summary>
        [NonSerialized]
        public static string FieldStateCode = "StateCode";

        /// <summary>
        /// 有效
        /// </summary>
        [NonSerialized]
        public static string FieldEnabled = "Enabled";

        /// <summary>
        /// 审核者主键
        /// </summary>
        [NonSerialized]
        public static string FieldAuditStaffId = "AuditStaffId";

        /// <summary>
        /// 排序
        /// </summary>
        [NonSerialized]
        public static string FieldSortCode = "SortCode";

        /// <summary>
        /// 创建者主键
        /// </summary>
        [NonSerialized]
        public static string FieldCreateUserId = "CreateUserId";

        /// <summary>
        /// 创建日期
        /// </summary>
        [NonSerialized]
        public static string FieldCreateOn = "CreateOn";

        /// <summary>
        /// 修改者主键
        /// </summary>
        [NonSerialized]
        public static string FieldModifiedUserId = "ModifiedUserId";

        /// <summary>
        /// 修改日期
        /// </summary>
        [NonSerialized]
        public static string FieldModifiedOn = "ModifiedOn";
    }
}