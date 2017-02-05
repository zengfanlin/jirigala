//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseWorkFlowActivityEntity
    /// 工作流步骤定义
    ///
    /// 修改纪录
    ///
    ///		2010-08-04 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010-08-04</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class BaseWorkFlowActivityEntity : BaseEntity
    {
        private int? id = null;
        /// <summary>
        /// 主键
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

        private int? workFlowId = null;
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

        private string code = null;
        /// <summary>
        /// 流程编号
        /// </summary>
        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        private string fullName = null;
        /// <summary>
        /// 流程名称
        /// </summary>
        public string FullName
        {
            get
            {
                return this.fullName;
            }
            set
            {
                this.fullName = value;
            }
        }

        private string auditDepartmentId = null;
        /// <summary>
        /// 审核部门主键
        /// </summary>
        public string AuditDepartmentId
        {
            get
            {
                return this.auditDepartmentId;
            }
            set
            {
                this.auditDepartmentId = value;
            }
        }

        private string auditDepartmentName = null;
        /// <summary>
        /// 审核部门名称
        /// </summary>
        public string AuditDepartmentName
        {
            get
            {
                return this.auditDepartmentName;
            }
            set
            {
                this.auditDepartmentName = value;
            }
        }

        private string auditUserId = null;
        /// <summary>
        /// 审核员主键
        /// </summary>
        public string AuditUserId
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

        private string auditUserCode = null;
        /// <summary>
        /// 审核员编号
        /// </summary>
        public string AuditUserCode
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

        private string auditUserRealName = null;
        /// <summary>
        /// 审核员
        /// </summary>
        public string AuditUserRealName
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

        private string auditRoleId = null;
        /// <summary>
        /// 审核角色主键
        /// </summary>
        public string AuditRoleId
        {
            get
            {
                return this.auditRoleId;
            }
            set
            {
                this.auditRoleId = value;
            }
        }

        private string auditRoleRealName = null;
        /// <summary>
        /// 审核角色
        /// </summary>
        public string AuditRoleRealName
        {
            get
            {
                return this.auditRoleRealName;
            }
            set
            {
                this.auditRoleRealName = value;
            }
        }

        private string activityType = null;
        /// <summary>
        /// 审核类型
        /// </summary>
        public string ActivityType
        {
            get
            {
                return this.activityType;
            }
            set
            {
                this.activityType = value;
            }
        }

        private int? allowPrint = 0;
        /// <summary>
        /// 允许打印
        /// </summary>
        public int? AllowPrint
        {
            get
            {
                return this.allowPrint;
            }
            set
            {
                this.allowPrint = value;
            }
        }

        private int? allowEditDocuments = 0;
        /// <summary>
        /// 允许编辑单据
        /// </summary>
        public int? AllowEditDocuments
        {
            get
            {
                return this.allowEditDocuments;
            }
            set
            {
                this.allowEditDocuments = value;
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

        private string description = null;
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
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

        private string createUserId = null;
        /// <summary>
        /// 创建用户主键
        /// </summary>
        public string CreateUserId
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

        private string createBy = null;
        /// <summary>
        /// 创建用户
        /// </summary>
        public string CreateBy
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

        private string modifiedUserId = null;
        /// <summary>
        /// 修改用户主键
        /// </summary>
        public string ModifiedUserId
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

        private string modifiedBy = null;
        /// <summary>
        /// 修改用户
        /// </summary>
        public string ModifiedBy
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
        public BaseWorkFlowActivityEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseWorkFlowActivityEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseWorkFlowActivityEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseWorkFlowActivityEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseWorkFlowActivityEntity GetSingle(DataTable dataTable)
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
        /// 从数据表读取实体列表
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public List<BaseWorkFlowActivityEntity> GetList(DataTable dataTable)
        {
            List<BaseWorkFlowActivityEntity> entites = new List<BaseWorkFlowActivityEntity>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                entites.Add(GetFrom(dataRow));
            }
            return entites;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseWorkFlowActivityEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowActivityEntity.FieldId]);
            this.WorkFlowId = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowActivityEntity.FieldWorkFlowId]);
            this.Code = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowActivityEntity.FieldCode]);
            this.FullName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowActivityEntity.FieldFullName]);
            this.AuditDepartmentId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowActivityEntity.FieldAuditDepartmentId]);
            this.AuditDepartmentName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowActivityEntity.FieldAuditDepartmentName]);
            this.AuditUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowActivityEntity.FieldAuditUserId]);
            this.AuditUserCode = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowActivityEntity.FieldAuditUserCode]);
            this.AuditUserRealName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowActivityEntity.FieldAuditUserRealName]);
            this.AuditRoleId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowActivityEntity.FieldAuditRoleId]);
            this.AuditRoleRealName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowActivityEntity.FieldAuditRoleRealName]);
            this.ActivityType = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowActivityEntity.FieldActivityType]);
            this.AllowPrint = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowActivityEntity.FieldAllowPrint]);
            this.AllowEditDocuments = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowActivityEntity.FieldAllowEditDocuments]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowActivityEntity.FieldSortCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowActivityEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowActivityEntity.FieldDeletionStateCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowActivityEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseWorkFlowActivityEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowActivityEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowActivityEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseWorkFlowActivityEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowActivityEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowActivityEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseWorkFlowActivityEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader);
            this.Id = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowActivityEntity.FieldId]);
            this.WorkFlowId = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowActivityEntity.FieldWorkFlowId]);
            this.Code = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowActivityEntity.FieldCode]);
            this.FullName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowActivityEntity.FieldFullName]);
            this.AuditDepartmentId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowActivityEntity.FieldAuditDepartmentId]);
            this.AuditDepartmentName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowActivityEntity.FieldAuditDepartmentName]);
            this.AuditUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowActivityEntity.FieldAuditUserId]);
            this.AuditUserCode = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowActivityEntity.FieldAuditUserCode]);
            this.AuditUserRealName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowActivityEntity.FieldAuditUserRealName]);
            this.AuditRoleId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowActivityEntity.FieldAuditRoleId]);
            this.AuditRoleRealName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowActivityEntity.FieldAuditRoleRealName]);
            this.ActivityType = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowActivityEntity.FieldActivityType]);
            this.AllowPrint = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowActivityEntity.FieldAllowPrint]);
            this.AllowEditDocuments = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowActivityEntity.FieldAllowEditDocuments]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowActivityEntity.FieldSortCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowActivityEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowActivityEntity.FieldDeletionStateCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowActivityEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseWorkFlowActivityEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowActivityEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowActivityEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseWorkFlowActivityEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowActivityEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowActivityEntity.FieldModifiedBy]);
            return this;
        }
    }
}
