//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;

namespace DotNet.Business
{
    /// <summary>
    /// BaseTableColumnsEntity
    /// 表字段结构定义说明
    ///
    /// 修改纪录
    ///
    ///		2010-07-15 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010-07-15</date>
    /// </author>
    /// </summary>
    public partial class BaseTableColumnsEntity
    {
        ///<summary>
        /// 表字段结构定义说明
        ///</summary>
        [NonSerialized]
        public static string TableName = "BaseTableColumns";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 表
        ///</summary>
        [NonSerialized]
        public static string FieldTableCode = "TableCode";

        ///<summary>
        /// 表
        ///</summary>
        [NonSerialized]
        public static string FieldColumnCode = "ColumnCode";

        ///<summary>
        /// 表名
        ///</summary>
        [NonSerialized]
        public static string FieldColumnName = "ColumnName";

        /// <summary>
        /// 采用约束条件
        /// </summary>
        [NonSerialized]
        public static string FieldUseConstraint = "UseConstraint";

        ///<summary>
        /// 是公开
        ///</summary>
        [NonSerialized]
        public static string FieldIsPublic = "IsPublic";

        ///<summary>
        /// 数据类型
        ///</summary>
        [NonSerialized]
        public static string FieldDataType = "DataType";

        ///<summary>
        /// 数据字典来源
        ///</summary>
        [NonSerialized]
        public static string FieldTargetTable = "TargetTable";

        ///<summary>
        /// 有效
        ///</summary>
        [NonSerialized]
        public static string FieldEnabled = "Enabled";

        ///<summary>
        /// 允许编辑
        ///</summary>
        [NonSerialized]
        public static string FieldAllowEdit = "AllowEdit";

        ///<summary>
        /// 允许删除
        ///</summary>
        [NonSerialized]
        public static string FieldAllowDelete = "AllowDelete";

        ///<summary>
        /// 删除标记
        ///</summary>
        [NonSerialized]
        public static string FieldDeletionStateCode = "DeletionStateCode";

        ///<summary>
        /// 排序码
        ///</summary>
        [NonSerialized]
        public static string FieldSortCode = "SortCode";

        ///<summary>
        /// 描述
        ///</summary>
        [NonSerialized]
        public static string FieldDescription = "Description";

        ///<summary>
        /// 创建日期
        ///</summary>
        [NonSerialized]
        public static string FieldCreateOn = "CreateOn";

        ///<summary>
        /// 创建用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldCreateUserId = "CreateUserId";

        ///<summary>
        /// 创建用户
        ///</summary>
        [NonSerialized]
        public static string FieldCreateBy = "CreateBy";

        ///<summary>
        /// 修改日期
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedOn = "ModifiedOn";

        ///<summary>
        /// 修改用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedUserId = "ModifiedUserId";

        ///<summary>
        /// 修改用户
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedBy = "ModifiedBy";
    }
}
