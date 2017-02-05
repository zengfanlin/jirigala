//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;

namespace DotNet.Business
{
    /// <summary>
    /// BaseOrganizeEntity
    /// 组织机构、部门表
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
    public partial class BaseOrganizeEntity
    {
        ///<summary>
        /// 组织机构、部门表
        ///</summary>
        [NonSerialized]
        public static string TableName = "BaseOrganize";

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
        /// 简称
        ///</summary>
        [NonSerialized]
        public static string FieldShortName = "ShortName";

        ///<summary>
        /// 名称
        ///</summary>
        [NonSerialized]
        public static string FieldFullName = "FullName";

        ///<summary>
        /// 分类
        ///</summary>
        [NonSerialized]
        public static string FieldCategory = "Category";

        ///<summary>
        /// 外线电话
        ///</summary>
        [NonSerialized]
        public static string FieldOuterPhone = "OuterPhone";

        ///<summary>
        /// 内线电话
        ///</summary>
        [NonSerialized]
        public static string FieldInnerPhone = "InnerPhone";

        ///<summary>
        /// 传真
        ///</summary>
        [NonSerialized]
        public static string FieldFax = "Fax";

        ///<summary>
        /// 邮编
        ///</summary>
        [NonSerialized]
        public static string FieldPostalcode = "Postalcode";

        ///<summary>
        /// 地址
        ///</summary>
        [NonSerialized]
        public static string FieldAddress = "Address";

        ///<summary>
        /// 网址
        ///</summary>
        [NonSerialized]
        public static string FieldWeb = "Web";

        ///<summary>
        /// 内部组织机构
        ///</summary>
        [NonSerialized]
        public static string FieldIsInnerOrganize = "IsInnerOrganize";

        ///<summary>
        /// 开户行
        ///</summary>
        [NonSerialized]
        public static string FieldBank = "Bank";

        ///<summary>
        /// 银行帐号
        ///</summary>
        [NonSerialized]
        public static string FieldBankAccount = "BankAccount";

        ///<summary>
        /// 删除标记
        ///</summary>
        [NonSerialized]
        public static string FieldDeletionStateCode = "DeletionStateCode";

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