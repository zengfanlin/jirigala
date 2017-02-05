//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;

namespace DotNet.Business
{
    /// <summary>
    /// BaseContactEntity
    /// 联络单主表
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
    public partial class BaseContactEntity
    {
        ///<summary>
        /// 联络单主表
        ///</summary>
        [NonSerialized]
        public static string TableName = "BaseContact";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 父主键
        ///</summary>
        [NonSerialized]
        public static string FieldParentId = "ParentId";

        ///<summary>
        /// 主题
        ///</summary>
        [NonSerialized]
        public static string FieldTitle = "Title";

        ///<summary>
        /// 内容
        ///</summary>
        [NonSerialized]
        public static string FieldContents = "Contents";

        ///<summary>
        /// 邮件等级
        ///</summary>
        [NonSerialized]
        public static string FieldPriority = "Priority";

        ///<summary>
        /// 发送邮件总数
        ///</summary>
        [NonSerialized]
        public static string FieldSendCount = "SendCount";

        ///<summary>
        /// 已阅读人数
        ///</summary>
        [NonSerialized]
        public static string FieldReadCount = "ReadCount";

        /// <summary>
        /// 回复数量
        /// </summary>
        [NonSerialized]
        public static string FieldReplyCount = "ReplyCount";

        ///<summary>
        /// 是否公开
        ///</summary>
        [NonSerialized]
        public static string FieldIsOpen = "IsOpen";

        ///<summary>
        /// 最后评论人主键
        ///</summary>
        [NonSerialized]
        public static string FieldCommentUserId = "CommentUserId";

        ///<summary>
        /// 最后评论人姓名
        ///</summary>
        [NonSerialized]
        public static string FieldCommentUserRealName = "CommentUserRealName";

        ///<summary>
        /// 最后评论时间
        ///</summary>
        [NonSerialized]
        public static string FieldCommentDate = "CommentDate";

        ///<summary>
        /// 是否删除
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
