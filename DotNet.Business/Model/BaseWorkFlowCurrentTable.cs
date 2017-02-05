//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace DotNet.Business
{
    /// <summary>
    /// BaseWorkFlowCurrentTable
    /// 工作流当前审核状态
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
    public partial class BaseWorkFlowCurrentEntity
    {
        ///<summary>
        /// 工作流当前审核状态
        ///</summary>
        [NonSerialized]
        public static string TableName = "BaseWorkFlowCurrent";

        ///<summary>
        /// 代码
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 实体分类主键
        ///</summary>
        [NonSerialized]
        public static string FieldCategoryCode = "CategoryCode";

        ///<summary>
        /// 实体分类名称
        ///</summary>
        [NonSerialized]
        public static string FieldCategoryFullName = "CategoryFullName";

        ///<summary>
        /// 实体主键
        ///</summary>
        [NonSerialized]
        public static string FieldObjectId = "ObjectId";

        ///<summary>
        /// 实体名称
        ///</summary>
        [NonSerialized]
        public static string FieldObjectFullName = "ObjectFullName";

        ///<summary>
        /// 工作流主键
        ///</summary>
        [NonSerialized]
        public static string FieldWorkFlowId = "WorkFlowId";

        ///<summary>
        /// 审核步骤主键
        ///</summary>
        [NonSerialized]
        public static string FieldActivityId = "ActivityId";

        ///<summary>
        /// 审核步骤名称
        ///</summary>
        [NonSerialized]
        public static string FieldActivityFullName = "ActivityFullName";

        ///<summary>
        /// 待审核部门主键
        ///</summary>
        [NonSerialized]
        public static string FieldToDepartmentId = "ToDepartmentId";

        ///<summary>
        /// 待审核部门名称
        ///</summary>
        [NonSerialized]
        public static string FieldToDepartmentName = "ToDepartmentName";

        ///<summary>
        /// 待审核用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldToUserId = "ToUserId";

        ///<summary>
        /// 待审核用户
        ///</summary>
        [NonSerialized]
        public static string FieldToUserRealName = "ToUserRealName";

        ///<summary>
        /// 待审核角色主键
        ///</summary>
        [NonSerialized]
        public static string FieldToRoleId = "ToRoleId";

        ///<summary>
        /// 待审核角色
        ///</summary>
        [NonSerialized]
        public static string FieldToRoleRealName = "ToRoleRealName";

        ///<summary>
        /// 审核用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldAuditUserId = "AuditUserId";

        ///<summary>
        /// 审核用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldAuditUserCode = "AuditUserCode";

        ///<summary>
        /// 审核用户
        ///</summary>
        [NonSerialized]
        public static string FieldAuditUserRealName = "AuditUserRealName";

        ///<summary>
        /// 发出日期
        ///</summary>
        [NonSerialized]
        public static string FieldSendDate = "SendDate";

        ///<summary>
        /// 审核日期
        ///</summary>
        [NonSerialized]
        public static string FieldAuditDate = "AuditDate";

        ///<summary>
        /// 审核意见
        ///</summary>
        [NonSerialized]
        public static string FieldAuditIdea = "AuditIdea";

        ///<summary>
        /// 审核状态码
        ///</summary>
        [NonSerialized]
        public static string FieldAuditStatus = "AuditStatus";

        ///<summary>
        /// 审核状态
        ///</summary>
        [NonSerialized]
        public static string FieldAuditStatusName = "AuditStatusName";

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
