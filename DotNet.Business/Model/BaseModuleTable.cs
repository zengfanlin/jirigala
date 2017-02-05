//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace DotNet.Business
{
    /// <summary>
    /// BaseModuleTable
    /// 模块（菜单）表
    /// 
    /// 修改纪录
    /// 
    /// 2012-05-22 版本：1.0 JiRiGaLa 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>JiRiGaLa</name>
    /// <date>2012-05-22</date>
    /// </author>
    /// </summary>
    public partial class BaseModuleEntity
    {
        ///<summary>
        /// 模块（菜单）表
        ///</summary>
        [NonSerialized]
        public static string TableName = "BaseModule";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 父节点主键
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
        /// 菜单分类System\Application
        ///</summary>
        [NonSerialized]
        public static string FieldCategory = "Category";

        ///<summary>
        /// 图标编号
        ///</summary>
        [NonSerialized]
        public static string FieldImageIndex = "ImageIndex";

        ///<summary>
        /// 选中状态图标编号
        ///</summary>
        [NonSerialized]
        public static string FieldSelectedImageIndex = "SelectedImageIndex";

        ///<summary>
        /// 导航地址(Web网址)[B\S]
        ///</summary>
        [NonSerialized]
        public static string FieldNavigateUrl = "NavigateUrl";

        ///<summary>
        /// 目标窗体中打开[B\S]
        ///</summary>
        [NonSerialized]
        public static string FieldTarget = "Target";

        ///<summary>
        /// 窗体名[C\S]
        ///</summary>
        [NonSerialized]
        public static string FieldFormName = "FormName";

        ///<summary>
        /// 动态连接库[C\S]
        ///</summary>
        [NonSerialized]
        public static string FieldAssemblyName = "AssemblyName";

        ///<summary>
        /// 操作权限编号(数据权限范围)
        ///</summary>
        [NonSerialized]
        public static string FieldPermissionItemCode = "PermissionItemCode";

        ///<summary>
        /// 需要数据权限过滤的表(,符号分割)
        ///</summary>
        [NonSerialized]
        public static string FieldPermissionScopeTables = "PermissionScopeTables";

        ///<summary>
        /// 排序码
        ///</summary>
        [NonSerialized]
        public static string FieldSortCode = "SortCode";

        ///<summary>
        /// 有效
        ///</summary>
        [NonSerialized]
        public static string FieldEnabled = "Enabled";

        ///<summary>
        /// 删除标志
        ///</summary>
        [NonSerialized]
        public static string FieldDeletionStateCode = "DeletionStateCode";

        ///<summary>
        /// 是公开
        ///</summary>
        [NonSerialized]
        public static string FieldIsPublic = "IsPublic";

        ///<summary>
        /// 展开状态
        ///</summary>
        [NonSerialized]
        public static string FieldExpand = "Expand";

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
