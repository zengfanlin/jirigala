//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;

namespace DotNet.Business
{
    /// <summary>
    /// BasePermissionScopeEntity
    /// 数据权限表
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
    public partial class BasePermissionScopeEntity
    {
        ///<summary>
        /// 数据权限表
        ///</summary>
        [NonSerialized]
        public static string TableName = "BasePermissionScope";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 什么类型的
        ///</summary>
        [NonSerialized]
        public static string FieldResourceCategory = "ResourceCategory";

        ///<summary>
        /// 什么资源
        ///</summary>
        [NonSerialized]
        public static string FieldResourceId = "ResourceId";

        ///<summary>
        /// 对什么类型的
        ///</summary>
        [NonSerialized]
        public static string FieldTargetCategory = "TargetCategory";

        ///<summary>
        /// 对什么资源
        ///</summary>
        [NonSerialized]
        public static string FieldTargetId = "TargetId";

        ///<summary>
        /// 有什么权限
        ///</summary>
        [NonSerialized]
        public static string FieldPermissionItemId = "PermissionId";

        ///<summary>
        /// 权限约束
        ///</summary>
        [NonSerialized]
        public static string FieldPermissionConstraint = "PermissionConstraint";

        ///<summary>
        /// 开始生效日期
        ///</summary>
        [NonSerialized]
        public static string FieldStartDate = "StartDate";

        ///<summary>
        /// 结束生效日期
        ///</summary>
        [NonSerialized]
        public static string FieldEndDate = "EndDate";

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
        /// 创建用户
        ///</summary>
        [NonSerialized]
        public static string FieldCreateBy = "CreateBy";

        ///<summary>
        /// 创建用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldCreateUserId = "CreateUserId";

        ///<summary>
        /// 修改日期
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedOn = "ModifiedOn";

        ///<summary>
        /// 修改用户
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedBy = "ModifiedBy";

        ///<summary>
        /// 修改用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedUserId = "ModifiedUserId";
    }
}
