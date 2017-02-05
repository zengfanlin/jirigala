//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseWorkFlowCurrentEntity
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
    [Serializable]
    public partial class BaseWorkFlowCurrentEntity : BaseEntity
    {
        private String id = string.Empty;
        /// <summary>
        /// 代码
        /// </summary>
        public String Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        private String categoryCode = string.Empty;
        /// <summary>
        /// 实体分类主键
        /// </summary>
        public String CategoryCode
        {
            get
            {
                return this.categoryCode;
            }
            set
            {
                this.categoryCode = value;
            }
        }

        private String categoryFullName = string.Empty;
        /// <summary>
        /// 实体分类名称
        /// </summary>
        public String CategoryFullName
        {
            get
            {
                return this.categoryFullName;
            }
            set
            {
                this.categoryFullName = value;
            }
        }

        private String objectId = string.Empty;
        /// <summary>
        /// 实体主键
        /// </summary>
        public String ObjectId
        {
            get
            {
                return this.objectId;
            }
            set
            {
                this.objectId = value;
            }
        }

        private String objectFullName = string.Empty;
        /// <summary>
        /// 实体名称
        /// </summary>
        public String ObjectFullName
        {
            get
            {
                return this.objectFullName;
            }
            set
            {
                this.objectFullName = value;
            }
        }

        private int? workFlowId = 0;
        /// <summary>
        /// 工作流主键
        /// </summary>
        public int? WorkFlowId
        {
            get
            {
                return this.workFlowId;
            }
            set
            {
                this.workFlowId = value;
            }
        }

        private int? activityId = 0;
        /// <summary>
        /// 审核步骤主键
        /// </summary>
        public int? ActivityId
        {
            get
            {
                return this.activityId;
            }
            set
            {
                this.activityId = value;
            }
        }

        private String activityFullName = string.Empty;
        /// <summary>
        /// 审核步骤名称
        /// </summary>
        public String ActivityFullName
        {
            get
            {
                return this.activityFullName;
            }
            set
            {
                this.activityFullName = value;
            }
        }

        private String toDepartmentId = string.Empty;
        /// <summary>
        /// 待审核部门主键
        /// </summary>
        public String ToDepartmentId
        {
            get
            {
                return this.toDepartmentId;
            }
            set
            {
                this.toDepartmentId = value;
            }
        }

        private String toDepartmentName = string.Empty;
        /// <summary>
        /// 待审核部门名称
        /// </summary>
        public String ToDepartmentName
        {
            get
            {
                return this.toDepartmentName;
            }
            set
            {
                this.toDepartmentName = value;
            }
        }

        private String toUserId = string.Empty;
        /// <summary>
        /// 待审核用户主键
        /// </summary>
        public String ToUserId
        {
            get
            {
                return this.toUserId;
            }
            set
            {
                this.toUserId = value;
            }
        }

        private String toUserRealName = string.Empty;
        /// <summary>
        /// 待审核用户
        /// </summary>
        public String ToUserRealName
        {
            get
            {
                return this.toUserRealName;
            }
            set
            {
                this.toUserRealName = value;
            }
        }

        private String toRoleId = string.Empty;
        /// <summary>
        /// 待审核角色主键
        /// </summary>
        public String ToRoleId
        {
            get
            {
                return this.toRoleId;
            }
            set
            {
                this.toRoleId = value;
            }
        }

        private String toRoleRealName = string.Empty;
        /// <summary>
        /// 待审核角色
        /// </summary>
        public String ToRoleRealName
        {
            get
            {
                return this.toRoleRealName;
            }
            set
            {
                this.toRoleRealName = value;
            }
        }

        private String auditUserId = string.Empty;
        /// <summary>
        /// 审核用户主键
        /// </summary>
        public String AuditUserId
        {
            get
            {
                return this.auditUserId;
            }
            set
            {
                this.auditUserId = value;
            }
        }

        private String auditUserCode = string.Empty;
        /// <summary>
        /// 审核用户主键
        /// </summary>
        public String AuditUserCode
        {
            get
            {
                return this.auditUserCode;
            }
            set
            {
                this.auditUserCode = value;
            }
        }

        private String auditUserRealName = string.Empty;
        /// <summary>
        /// 审核用户
        /// </summary>
        public String AuditUserRealName
        {
            get
            {
                return this.auditUserRealName;
            }
            set
            {
                this.auditUserRealName = value;
            }
        }

        private DateTime? sendDate = null;
        /// <summary>
        /// 发出日期
        /// </summary>
        public DateTime? SendDate
        {
            get
            {
                return this.sendDate;
            }
            set
            {
                this.sendDate = value;
            }
        }

        private DateTime? auditDate = null;
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? AuditDate
        {
            get
            {
                return this.auditDate;
            }
            set
            {
                this.auditDate = value;
            }
        }

        private String auditIdea = string.Empty;
        /// <summary>
        /// 审核意见
        /// </summary>
        public String AuditIdea
        {
            get
            {
                return this.auditIdea;
            }
            set
            {
                this.auditIdea = value;
            }
        }

        private String auditStatus = string.Empty;
        /// <summary>
        /// 审核状态码
        /// </summary>
        public String AuditStatus
        {
            get
            {
                return this.auditStatus;
            }
            set
            {
                this.auditStatus = value;
            }
        }

        private String auditStatusName = string.Empty;
        /// <summary>
        /// 审核状态
        /// </summary>
        public String AuditStatusName
        {
            get
            {
                return this.auditStatusName;
            }
            set
            {
                this.auditStatusName = value;
            }
        }

        private int? sortCode = null;
        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode
        {
            get
            {
                return this.sortCode;
            }
            set
            {
                this.sortCode = value;
            }
        }

        private int? enabled = 1;
        /// <summary>
        /// 有效
        /// </summary>
        public int? Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                this.enabled = value;
            }
        }

        private int? deletionStateCode = 0;
        /// <summary>
        /// 删除标志
        /// </summary>
        public int? DeletionStateCode
        {
            get
            {
                return this.deletionStateCode;
            }
            set
            {
                this.deletionStateCode = value;
            }
        }

        private String description = string.Empty;
        /// <summary>
        /// 描述
        /// </summary>
        public String Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        private DateTime? createOn = null;
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateOn
        {
            get
            {
                return this.createOn;
            }
            set
            {
                this.createOn = value;
            }
        }

        private String createUserId = string.Empty;
        /// <summary>
        /// 创建用户主键
        /// </summary>
        public String CreateUserId
        {
            get
            {
                return this.createUserId;
            }
            set
            {
                this.createUserId = value;
            }
        }

        private String createBy = string.Empty;
        /// <summary>
        /// 创建用户
        /// </summary>
        public String CreateBy
        {
            get
            {
                return this.createBy;
            }
            set
            {
                this.createBy = value;
            }
        }

        private DateTime? modifiedOn = null;
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? ModifiedOn
        {
            get
            {
                return this.modifiedOn;
            }
            set
            {
                this.modifiedOn = value;
            }
        }

        private String modifiedUserId = string.Empty;
        /// <summary>
        /// 修改用户主键
        /// </summary>
        public String ModifiedUserId
        {
            get
            {
                return this.modifiedUserId;
            }
            set
            {
                this.modifiedUserId = value;
            }
        }

        private String modifiedBy = string.Empty;
        /// <summary>
        /// 修改用户
        /// </summary>
        public String ModifiedBy
        {
            get
            {
                return this.modifiedBy;
            }
            set
            {
                this.modifiedBy = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseWorkFlowCurrentEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseWorkFlowCurrentEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseWorkFlowCurrentEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseWorkFlowCurrentEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseWorkFlowCurrentEntity GetSingle(DataTable dataTable)
        {
            if ((dataTable == null) || (dataTable.Rows.Count == 0))
            {
                return null;
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.GetFrom(dataRow);
                break;
            }
            return this;
        }

        /// <summary>
        /// 从数据表读取返回实体列表
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public List<BaseWorkFlowCurrentEntity> GetList(DataTable dataTable)
        {
            List<BaseWorkFlowCurrentEntity> entities = new List<BaseWorkFlowCurrentEntity>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                entities.Add(GetFrom(dataRow));
            }
            return entities;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseWorkFlowCurrentEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldId]);
            this.CategoryCode = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldCategoryCode]);
            this.CategoryFullName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldCategoryFullName]);
            this.ObjectId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldObjectId]);
            this.ObjectFullName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldObjectFullName]);
            this.WorkFlowId = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowCurrentEntity.FieldWorkFlowId]);
            this.ActivityId = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowCurrentEntity.FieldActivityId]);
            this.ActivityFullName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldActivityFullName]);
            this.ToDepartmentId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldToDepartmentId]);
            this.ToDepartmentName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldToDepartmentName]);
            this.ToUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldToUserId]);
            this.ToUserRealName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldToUserRealName]);
            this.ToRoleId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldToRoleId]);
            this.ToRoleRealName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldToRoleRealName]);
            this.AuditUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldAuditUserId]);
            this.AuditUserCode = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldAuditUserCode]);
            this.AuditUserRealName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldAuditUserRealName]);
            this.SendDate = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseWorkFlowCurrentEntity.FieldSendDate]);
            this.AuditDate = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseWorkFlowCurrentEntity.FieldAuditDate]);
            this.AuditIdea = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldAuditIdea]);
            this.AuditStatus = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldAuditStatus]);
            this.AuditStatusName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldAuditStatusName]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowCurrentEntity.FieldSortCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowCurrentEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowCurrentEntity.FieldDeletionStateCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseWorkFlowCurrentEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseWorkFlowCurrentEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowCurrentEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseWorkFlowCurrentEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader); ;
            this.Id = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldId]);
            this.CategoryCode = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldCategoryCode]);
            this.CategoryFullName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldCategoryFullName]);
            this.ObjectId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldObjectId]);
            this.ObjectFullName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldObjectFullName]);
            this.WorkFlowId = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowCurrentEntity.FieldWorkFlowId]);
            this.ActivityId = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowCurrentEntity.FieldActivityId]);
            this.ActivityFullName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldActivityFullName]);
            this.ToDepartmentId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldToDepartmentId]);
            this.ToDepartmentName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldToDepartmentName]);
            this.ToUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldToUserId]);
            this.ToUserRealName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldToUserRealName]);
            this.ToRoleId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldToRoleId]);
            this.ToRoleRealName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldToRoleRealName]);
            this.AuditUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldAuditUserId]);
            this.AuditUserCode = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldAuditUserCode]);
            this.AuditUserRealName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldAuditUserRealName]);
            this.SendDate = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseWorkFlowCurrentEntity.FieldSendDate]);
            this.AuditDate = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseWorkFlowCurrentEntity.FieldAuditDate]);
            this.AuditIdea = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldAuditIdea]);
            this.AuditStatus = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldAuditStatus]);
            this.AuditStatusName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldAuditStatusName]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowCurrentEntity.FieldSortCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowCurrentEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowCurrentEntity.FieldDeletionStateCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseWorkFlowCurrentEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseWorkFlowCurrentEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowCurrentEntity.FieldModifiedBy]);
            return this;
        }
    }
}
