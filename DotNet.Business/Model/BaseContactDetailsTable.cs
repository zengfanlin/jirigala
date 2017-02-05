//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;

namespace DotNet.Business
{
    /// <summary>
    /// BaseContactDetailsEntity
    /// 联络单明细表
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
    public partial class BaseContactDetailsEntity
    {
        ///<summary>
        /// 联络单明细表
        ///</summary>
        [NonSerialized]
        public static string TableName = "BaseContactDetails";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 联络单主主键
        ///</summary>
        [NonSerialized]
        public static string FieldContactId = "ContactId";

        ///<summary>
        /// 接收者分类
        ///</summary>
        [NonSerialized]
        public static string FieldCategory = "Category";

        ///<summary>
        /// 接收者主键
        ///</summary>
        [NonSerialized]
        public static string FieldReceiverId = "ReceiverId";

        ///<summary>
        /// 接收者姓名
        ///</summary>
        [NonSerialized]
        public static string FieldReceiverRealName = "ReceiverRealName";

        ///<summary>
        /// 是否新邮件
        ///</summary>
        [NonSerialized]
        public static string FieldIsNew = "IsNew";

        ///<summary>
        /// 是否有新的评论
        ///</summary>
        [NonSerialized]
        public static string FieldNewComment = "NewComment";

        ///<summary>
        /// 最后阅读IP
        ///</summary>
        [NonSerialized]
        public static string FieldLastViewIP = "LastViewIP";

        ///<summary>
        /// 最后阅读时间
        ///</summary>
        [NonSerialized]
        public static string FieldLastViewDate = "LastViewDate";

        ///<summary>
        /// 有新评论是否提示
        ///</summary>
        [NonSerialized]
        public static string FieldEnabled = "Enabled";

        ///<summary>
        /// 删除标志
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
