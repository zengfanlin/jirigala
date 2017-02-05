//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace DotNet.Business
{
    /// <summary>
    /// BaseMessageTable
    /// 消息表
    /// 
    /// 修改纪录
    /// 
    /// 2012-07-03 版本：1.0 JiRiGaLa 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>JiRiGaLa</name>
    /// <date>2012-07-03</date>
    /// </author>
    /// </summary>
    public partial class BaseMessageEntity
    {
        ///<summary>
        /// 消息表
        ///</summary>
        [NonSerialized]
        public static string TableName = "BaseMessage";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 父亲节点主键
        ///</summary>
        [NonSerialized]
        public static string FieldParentId = "ParentId";

        ///<summary>
        /// 部门主键
        ///</summary>
        [NonSerialized]
        public static string FieldReceiverDepartmentId = "ReceiverDepartmentId";

        ///<summary>
        /// 部门名称
        ///</summary>
        [NonSerialized]
        public static string FieldReceiverDepartmentName = "ReceiverDepartmentName";

        ///<summary>
        /// 接收者主键
        ///</summary>
        [NonSerialized]
        public static string FieldReceiverId = "ReceiverId";

        ///<summary>
        /// 接收着姓名
        ///</summary>
        [NonSerialized]
        public static string FieldReceiverRealName = "ReceiverRealName";

        ///<summary>
        /// 功能分类主键，Send发送、Receiver接收
        ///</summary>
        [NonSerialized]
        public static string FieldFunctionCode = "FunctionCode";

        ///<summary>
        /// 分类主键
        ///</summary>
        [NonSerialized]
        public static string FieldCategoryCode = "CategoryCode";

        ///<summary>
        /// 唯一识别主键
        ///</summary>
        [NonSerialized]
        public static string FieldObjectId = "ObjectId";

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
        /// 是否新信息
        ///</summary>
        [NonSerialized]
        public static string FieldIsNew = "IsNew";

        ///<summary>
        /// 被阅读次数
        ///</summary>
        [NonSerialized]
        public static string FieldReadCount = "ReadCount";

        ///<summary>
        /// 阅读日期
        ///</summary>
        [NonSerialized]
        public static string FieldReadDate = "ReadDate";

        ///<summary>
        /// 消息的指向网页页面
        ///</summary>
        [NonSerialized]
        public static string FieldTargetURL = "TargetURL";

        ///<summary>
        /// IP地址
        ///</summary>
        [NonSerialized]
        public static string FieldIPAddress = "IPAddress";

        ///<summary>
        /// 部门主键
        ///</summary>
        [NonSerialized]
        public static string FieldCreateDepartmentId = "CreateDepartmentId";

        ///<summary>
        /// 部门名称
        ///</summary>
        [NonSerialized]
        public static string FieldCreateDepartmentName = "CreateDepartmentName";

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
