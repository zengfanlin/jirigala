//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;

namespace DotNet.Business
{
    /// <summary>
    /// BaseUserOrganizeEntity
    /// 用户帐户组织关系表
    ///
    /// 修改纪录
    ///
    ///		2010-09-25 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010-09-25</date>
    /// </author>
    /// </summary>
    public partial class BaseUserOrganizeEntity
    {
        ///<summary>
        /// 用户帐户组织关系表
        ///</summary>
        [NonSerialized]
        public static string TableName = "BaseUserOrganize";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 用户帐户主键
        ///</summary>
        [NonSerialized]
        public static string FieldUserId = "UserId";

        ///<summary>
        /// 公司代码
        ///</summary>
        [NonSerialized]
        public static string FieldCompanyId = "CompanyId";

        ///<summary>
        /// 部门代码
        ///</summary>
        [NonSerialized]
        public static string FieldDepartmentId = "DepartmentId";

        ///<summary>
        /// 工作组代码
        ///</summary>
        [NonSerialized]
        public static string FieldWorkgroupId = "WorkgroupId";

        ///<summary>
        /// 角色主键
        ///</summary>
        [NonSerialized]
        public static string FieldRoleId = "RoleId";

        ///<summary>
        /// 有效
        ///</summary>
        [NonSerialized]
        public static string FieldEnabled = "Enabled";

        ///<summary>
        /// 描述
        ///</summary>
        [NonSerialized]
        public static string FieldDescription = "Description";

        ///<summary>
        /// 删除标记
        ///</summary>
        [NonSerialized]
        public static string FieldDeletionStateCode = "DeletionStateCode";

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
