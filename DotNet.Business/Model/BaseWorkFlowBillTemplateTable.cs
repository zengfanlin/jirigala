//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace DotNet.Business
{
    /// <summary>
    /// BaseWorkFlowBillTemplateTable
    /// 工作流模板表
    /// 
    /// 修改纪录
    /// 
    /// 2012-05-18 版本：1.0 JiRiGaLa 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>JiRiGaLa</name>
    /// <date>2012-05-18</date>
    /// </author>
    /// </summary>
    public partial class BaseWorkFlowBillTemplateEntity
    {
        ///<summary>
        /// 工作流模板表
        ///</summary>
        [NonSerialized]
        public static string TableName = "BaseWorkFlowBillTemplate";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 模版标题
        ///</summary>
        [NonSerialized]
        public static string FieldTitle = "Title";

        ///<summary>
        /// 模版编号
        ///</summary>
        [NonSerialized]
        public static string FieldCode = "Code";

        ///<summary>
        /// 模版分类
        ///</summary>
        [NonSerialized]
        public static string FieldCategoryCode = "CategoryCode";

        ///<summary>
        /// 标准流程
        ///</summary>
        [NonSerialized]
        public static string FieldIntroduction = "Introduction";

        ///<summary>
        /// 文件内容
        ///</summary>
        [NonSerialized]
        public static string FieldContents = "Contents";

        ///<summary>
        /// 模版类型
        ///</summary>
        [NonSerialized]
        public static string FieldTemplateType = "TemplateType";

        ///<summary>
        /// 流转审批
        ///</summary>
        [NonSerialized]
        public static string FieldUseWorkFlow = "UseWorkFlow";

        ///<summary>
        /// 添加页面
        ///</summary>
        [NonSerialized]
        public static string FieldAddPage = "AddPage";

        ///<summary>
        /// 编辑页面
        ///</summary>
        [NonSerialized]
        public static string FieldEditPage = "EditPage";

        ///<summary>
        /// 显示页面
        ///</summary>
        [NonSerialized]
        public static string FieldShowPage = "ShowPage";

        ///<summary>
        /// 列表页面
        ///</summary>
        [NonSerialized]
        public static string FieldListPage = "ListPage";

        ///<summary>
        /// 管理页面
        ///</summary>
        [NonSerialized]
        public static string FieldAdminPage = "AdminPage";

        ///<summary>
        /// 审核状态
        ///</summary>
        [NonSerialized]
        public static string FieldAuditStatus = "AuditStatus";

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
        /// 有效
        ///</summary>
        [NonSerialized]
        public static string FieldEnabled = "Enabled";

        ///<summary>
        /// 排序码
        ///</summary>
        [NonSerialized]
        public static string FieldSortCode = "SortCode";

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
