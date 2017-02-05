//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;

namespace DotNet.Business
{
    /// <summary>
    /// BasePermissionItemEntity
    /// 操作权限项定义
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
    public partial class BasePermissionItemEntity
    {
        ///<summary>
        /// 操作权限项定义
        ///</summary>
        [NonSerialized]
        public static string TableName = "BasePermissionItem";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 父级主键
        ///</summary>
        [NonSerialized]
        public static string FieldParentId = "ParentId";

        ///<summary>
        /// 编号
        ///</summary>
        [NonSerialized]
        public static string FieldCode = "Code";

        ///<summary>
        /// 名称
        ///</summary>
        [NonSerialized]
        public static string FieldFullName = "FullName";

        ///<summary>
        /// 权限分类编号
        ///</summary>
        [NonSerialized]
        public static string FieldCategoryCode = "CategoryCode";

        ///<summary>
        /// 权限域
        ///</summary>
        [NonSerialized]
        public static string FieldIsScope = "IsScope";

        ///<summary>
        /// 是公开
        ///</summary>
        [NonSerialized]
        public static string FieldIsPublic = "IsPublic";

        ///<summary>
        /// 是显示
        ///</summary>
        [NonSerialized]
        public static string FieldIsVisible = "IsVisible";

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
        /// 最后被调用日期
        ///</summary>
        [NonSerialized]
        public static string FieldLastCall = "LastCall";

        ///<summary>
        /// 有效
        ///</summary>
        [NonSerialized]
        public static string FieldEnabled = "Enabled";

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
