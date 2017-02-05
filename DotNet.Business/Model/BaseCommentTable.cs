//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace DotNet.Business
{
    /// <summary>
    /// BaseCommentTable
    /// 评论表
    /// 
    /// 修改纪录
    /// 
    /// 2012-05-14 版本：1.0 JiRiGaLa 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>JiRiGaLa</name>
    /// <date>2012-05-14</date>
    /// </author>
    /// </summary>
    public partial class BaseCommentEntity
    {
        ///<summary>
        /// 评论表
        ///</summary>
        [NonSerialized]
        public static string TableName = "BaseComment";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 部门代码
        ///</summary>
        [NonSerialized]
        public static string FieldDepartmentId = "DepartmentId";

        ///<summary>
        /// 部门名称
        ///</summary>
        [NonSerialized]
        public static string FieldDepartmentName = "DepartmentName";

        ///<summary>
        /// 父亲节点主键
        ///</summary>
        [NonSerialized]
        public static string FieldParentId = "ParentId";

        ///<summary>
        /// 分类编号
        ///</summary>
        [NonSerialized]
        public static string FieldCategoryCode = "CategoryCode";

        ///<summary>
        /// 唯一识别主键
        ///</summary>
        [NonSerialized]
        public static string FieldObjectId = "ObjectId";

        ///<summary>
        /// 消息的指向网页页面
        ///</summary>
        [NonSerialized]
        public static string FieldTargetURL = "TargetURL";

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
        /// IP地址
        ///</summary>
        [NonSerialized]
        public static string FieldIPAddress = "IPAddress";

        ///<summary>
        /// 删除标志
        ///</summary>
        [NonSerialized]
        public static string FieldDeletionStateCode = "DeletionStateCode";

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
