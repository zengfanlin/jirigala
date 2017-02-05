//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.Business
{
    /// <summary>
    /// BaseProjectEntity
    /// 
    /// 修改记录
    /// 
    ///     2008.05.20 版本1.0 JiRiGaLa 主键创建
    /// 
    /// 版本1.0
    /// <author>
    ///     <name>JiRiGaLa</name>
    ///     <date>2008.05.20</date>
    /// </author>
    /// </summary>
    public partial class BaseProjectEntity
    {
        /// <summary>
        /// 表名
        /// </summary>
        [NonSerialized]
        public static string TableName = "BaseProject";

        /// <summary>
        /// 主键
        /// </summary>
        [NonSerialized]
        public static string FieldId = "Id";

        /// <summary>
        /// 部门主键
        /// </summary>
        [NonSerialized]
        public static string FieldOrganizeId = "OrganizeId";

        /// <summary>
        /// 编号
        /// </summary>
        [NonSerialized]
        public static string FieldCode = "Code";

        /// <summary>
        /// 全称
        /// </summary>
        [NonSerialized]
        public static string FieldFullName = "FullName";

        /// <summary>
        /// 分类主键
        /// </summary>
        [NonSerialized]
        public static string FieldCategoryId = "CategoryId";

        /// <summary>
        /// 主管主键
        /// </summary>
        [NonSerialized]
        public static string FieldManagerID = "ManagerID";

        /// <summary>
        /// 有效
        /// </summary>
        [NonSerialized]
        public static string FieldEnabled = "Enabled";

        /// <summary>
        /// 描述
        /// </summary>
        [NonSerialized]
        public static string FieldDescription = "Description";

        /// <summary>
        /// 排序码
        /// </summary>
        [NonSerialized]
        public static string FieldSortCode = "SortCode";

        /// <summary>
        /// 创建者主键
        /// </summary>
        [NonSerialized]
        public static string FieldCreateUserId = "CreateUserId";

        /// <summary>
        /// 创建者日期
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