//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace DotNet.Business
{
    /// <summary>
    /// BaseWorkFlowProcessTable
    /// 工作流定义
    ///
    /// 修改纪录
    ///
    ///		2012-04-09 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012-04-09</date>
    /// </author>
    /// </summary>
    public partial class BaseWorkFlowProcessEntity
    {
        ///<summary>
        /// 工作流定义
        ///</summary>
        [NonSerialized]
        public static string TableName = "BaseWorkFlowProcess";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldUserId = "UserId";

        ///<summary>
        /// 组织机构主键
        ///</summary>
        [NonSerialized]
        public static string FieldOrganizeId = "OrganizeId";

        ///<summary>
        /// 模版单据主键
        ///</summary>
        [NonSerialized]
        public static string FieldBillTemplateId = "BillTemplateId";

        ///<summary>
        /// 审核类型（按用户，按部门，按单据）
        ///</summary>
        [NonSerialized]
        public static string FieldAuditCategoryCode = "AuditCategoryCode";

        ///<summary>
        /// 反射回调类,工作流回写数据库,通过接口定义调用类的方法等
        ///</summary>
        [NonSerialized]
        public static string FieldCallBackClass = "CallBackClass";

        ///<summary>
        /// 回写表
        ///</summary>
        [NonSerialized]
        public static string FieldCallBackTable = "CallBackTable";

        ///<summary>
        /// 分类
        ///</summary>
        [NonSerialized]
        public static string FieldCategoryCode = "CategoryCode";

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
        /// 流程内容
        ///</summary>
        [NonSerialized]
        public static string FieldContents = "Contents";

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
