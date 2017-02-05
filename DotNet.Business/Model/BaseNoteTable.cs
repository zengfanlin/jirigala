//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.Business
{
    /// <summary>
    /// BaseNoteEntity
    /// <author>
    ///		<name>Caihuajun</name>
    ///		<date>2008.9.16</date>
    /// </author>
    /// </summary>
    public partial class BaseNoteEntity
    {
        /// <summary>
        /// 表名
        /// </summary>
        [NonSerialized]
        public static string TableName = "BaseNote";

        /// <summary>
        /// 主键
        /// </summary>
        [NonSerialized]
        public static string FieldId = "Id";

        /// <summary>
        /// 主题
        /// </summary>
        [NonSerialized]
        public static string FieldTitle = "Title";

        /// <summary>
        /// 类别主键
        /// </summary>
        [NonSerialized]
        public static string FieldCategoryId = "CategoryId";

        /// <summary>
        /// 类别名称
        /// </summary>
        [NonSerialized]
        public static string FieldCategoryFullName = "CategoryFullName";

        /// <summary>
        /// 颜色
        /// </summary>
        [NonSerialized]
        public static string FieldColor = "Color";

        /// <summary>
        /// 备忘内容
        /// </summary>
        [NonSerialized]
        public static string FieldContent = "Content";

        /// <summary>
        /// 状态
        /// </summary>
        [NonSerialized]
        public static string FieldEnabled = "Enabled";

        /// <summary>
        /// 重要性
        /// </summary>
        [NonSerialized]
        public static string FieldImportant = "Important";

        /// <summary>
        /// 删除标志
        /// </summary>
        [NonSerialized]
        public static string FieldDeletionStateCode = "DeletionStateCode";

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
        /// 创建时间
        /// </summary>
        [NonSerialized]
        public static string FieldCreateOn = "CreateOn";

        /// <summary>
        /// 最后修改者主键
        /// </summary>
        [NonSerialized]
        public static string FieldModifiedUserId = "ModifiedUserId";

        /// <summary>
        /// 最后修改时间
        /// </summary>
        [NonSerialized]
        public static string FieldModifiedOn = "ModifiedOn";
    }
}