//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;

namespace DotNet.Business
{
    /// <summary>
    /// BaseWorkFlowStepEntity
    /// 工作流步骤定义
    ///
    /// 修改纪录
    ///
    ///		2010-08-04 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010-08-04</date>
    /// </author>
    /// </summary>
    public partial class BaseWorkFlowActivityEntity
    {
        ///<summary>
        /// 工作流步骤定义
        ///</summary>
        [NonSerialized]
        public static string TableName = "BaseWorkFlowActivity";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 工作流主键
        ///</summary>
        [NonSerialized]
        public static string FieldWorkFlowId = "WorkFlowId";

        ///<summary>
        /// 流程编号
        ///</summary>
        [NonSerialized]
        public static string FieldCode = "Code";

        ///<summary>
        /// 流程名称
        ///</summary>
        [NonSerialized]
        public static string FieldFullName = "FullName";

        ///<summary>
        /// 审核部门主键
        ///</summary>
        [NonSerialized]
        public static string FieldAuditDepartmentId = "AuditDepartmentId";

        ///<summary>
        /// 审核部门名称
        ///</summary>
        [NonSerialized]
        public static string FieldAuditDepartmentName = "AuditDepartmentName";

        ///<summary>
        /// 审核员主键
        ///</summary>
        [NonSerialized]
        public static string FieldAuditUserId = "AuditUserId";

        ///<summary>
        /// 审核员编号
        ///</summary>
        [NonSerialized]
        public static string FieldAuditUserCode = "AuditUserCode";

        ///<summary>
        /// 审核员
        ///</summary>
        [NonSerialized]
        public static string FieldAuditUserRealName = "AuditUserRealName";

        ///<summary>
        /// 审核角色主键
        ///</summary>
        [NonSerialized]
        public static string FieldAuditRoleId = "AuditRoleId";

        ///<summary>
        /// 审核角色
        ///</summary>
        [NonSerialized]
        public static string FieldAuditRoleRealName = "AuditRoleRealName";

        ///<summary>
        /// 节点类型
        ///</summary>
        [NonSerialized]
        public static string FieldActivityType = "ActivityType";

        ///<summary>
        /// 允许打印
        ///</summary>
        [NonSerialized]
        public static string FieldAllowPrint = "AllowPrint";

        ///<summary>
        /// 允许编辑单据
        ///</summary>
        [NonSerialized]
        public static string FieldAllowEditDocuments = "AllowEditDocuments";

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
