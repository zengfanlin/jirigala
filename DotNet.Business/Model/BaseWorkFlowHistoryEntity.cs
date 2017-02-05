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
    /// BaseWorkFlowHistoryEntity
    /// 工作流审核历史步骤记录
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
    public partial class BaseWorkFlowHistoryEntity : BaseEntity
    {
        private int? id = null;
        /// <summary>
        /// 代码
        /// </summary>
        public int? Id
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

        private String currentFlowId = string.Empty;
        /// <summary>
        /// 当前工作流主键
        /// </summary>
        public String CurrentFlowId
        {
            get
            {
                return this.currentFlowId;
            }
            set
            {
                this.currentFlowId = value;
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
        public BaseWorkFlowHistoryEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseWorkFlowHistoryEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseWorkFlowHistoryEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseWorkFlowHistoryEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseWorkFlowHistoryEntity GetSingle(DataTable dataTable)
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
        public List<BaseWorkFlowHistoryEntity> GetList(DataTable dataTable)
        {
            List<BaseWorkFlowHistoryEntity> entities = new List<BaseWorkFlowHistoryEntity>();
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
        public BaseWorkFlowHistoryEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowHistoryEntity.FieldId]);
            this.CurrentFlowId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryEntity.FieldCurrentFlowId]);
            this.WorkFlowId = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowHistoryEntity.FieldWorkFlowId]);
            this.ActivityId = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowHistoryEntity.FieldActivityId]);
            this.ActivityFullName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryEntity.FieldActivityFullName]);
            this.ToDepartmentId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryEntity.FieldToDepartmentId]);
            this.ToDepartmentName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryEntity.FieldToDepartmentName]);
            this.ToUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryEntity.FieldToUserId]);
            this.ToUserRealName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryEntity.FieldToUserRealName]);
            this.ToRoleId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryEntity.FieldToRoleId]);
            this.ToRoleRealName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryEntity.FieldToRoleRealName]);
            this.AuditUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryEntity.FieldAuditUserId]);
            this.AuditUserCode = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryEntity.FieldAuditUserCode]);
            this.AuditUserRealName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryEntity.FieldAuditUserRealName]);
            this.SendDate = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseWorkFlowHistoryEntity.FieldSendDate]);
            this.AuditDate = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseWorkFlowHistoryEntity.FieldAuditDate]);
            this.AuditIdea = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryEntity.FieldAuditIdea]);
            this.AuditStatus = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryEntity.FieldAuditStatus]);
            this.AuditStatusName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryEntity.FieldAuditStatusName]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowHistoryEntity.FieldSortCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowHistoryEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowHistoryEntity.FieldDeletionStateCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseWorkFlowHistoryEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseWorkFlowHistoryEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseWorkFlowHistoryEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader); ;
            this.Id = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowHistoryEntity.FieldId]);
            this.CurrentFlowId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryEntity.FieldCurrentFlowId]);
            this.WorkFlowId = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowHistoryEntity.FieldWorkFlowId]);
            this.ActivityId = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowHistoryEntity.FieldActivityId]);
            this.ActivityFullName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryEntity.FieldActivityFullName]);
            this.ToDepartmentId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryEntity.FieldToDepartmentId]);
            this.ToDepartmentName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryEntity.FieldToDepartmentName]);
            this.ToUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryEntity.FieldToUserId]);
            this.ToUserRealName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryEntity.FieldToUserRealName]);
            this.ToRoleId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryEntity.FieldToRoleId]);
            this.ToRoleRealName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryEntity.FieldToRoleRealName]);
            this.AuditUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryEntity.FieldAuditUserId]);
            this.AuditUserCode = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryEntity.FieldAuditUserCode]);
            this.AuditUserRealName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryEntity.FieldAuditUserRealName]);
            this.SendDate = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseWorkFlowHistoryEntity.FieldSendDate]);
            this.AuditDate = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseWorkFlowHistoryEntity.FieldAuditDate]);
            this.AuditIdea = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryEntity.FieldAuditIdea]);
            this.AuditStatus = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryEntity.FieldAuditStatus]);
            this.AuditStatusName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryEntity.FieldAuditStatusName]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowHistoryEntity.FieldSortCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowHistoryEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowHistoryEntity.FieldDeletionStateCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseWorkFlowHistoryEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseWorkFlowHistoryEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryEntity.FieldModifiedBy]);
            return this;
        }
    }
}
