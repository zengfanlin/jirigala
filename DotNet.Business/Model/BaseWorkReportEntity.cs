//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseWorkReportEntity
    /// 
    /// 修改纪录
    /// 
    ///     2008.05.16 版本:1.1 吉日嘎拉 字段Project改为ProjectName,添加一个字段StaffName
    ///     2008.05.15 版本:1.0 吉日嘎拉 添加项目主键和工作日志分类主键两个数据字段,修改字段(Item改为Project)
    ///     2008.05.08 版本:1.0 吉日嘎拉 添加部门主键和公司主键两个数据字段
    ///     2008.05.04 版本:1.0 吉日嘎拉 主键创建
    /// 
    /// 版本1.1
    /// 
    /// <author>
    ///     <name>吉日嘎拉</name>
    ///     <date>2008.05.04</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class BaseWorkReportEntity : BaseEntity
    {
        public BaseWorkReportEntity()
        {
        }

        public BaseWorkReportEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        public BaseWorkReportEntity(DataTable dataTable)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.GetFrom(dataRow);
                break;
            }
        }

        /// <summary>
        /// 从数据表读取实体列表
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public List<BaseWorkReportEntity> GetList(DataTable dataTable)
        {
            List<BaseWorkReportEntity> entites = new List<BaseWorkReportEntity>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                entites.Add(GetFrom(dataRow));
            }
            return entites;
        }

        /// <summary>
        /// 从数据行中读取实体类
        /// </summary>
        /// <param name="dataTable">数据行</param>
        /// <returns>实体类</returns>
        public BaseWorkReportEntity GetFrom(DataRow dataRow)
        {
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkReportEntity.FieldId]);
            this.WorkDate = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkReportEntity.FieldWorkDate]);
            this.Content = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkReportEntity.FieldContent]);
            this.ManHour = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkReportEntity.FieldManHour]);
            this.ProjectId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkReportEntity.FieldProjectId]);
            if (dataRow.Table.Columns.Contains(BaseWorkReportEntity.FieldProjectFullName))
            {
                this.ProjectFullName = dataRow.IsNull(BaseWorkReportEntity.FieldProjectFullName) ? string.Empty : dataRow[BaseWorkReportEntity.FieldProjectFullName].ToString();
            }
            this.CategoryId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkReportEntity.FieldCategoryId]);
            if (dataRow.Table.Columns.Contains(BaseWorkReportEntity.FieldCategoryFullName))
            {
                this.CategoryFullName = dataRow.IsNull(BaseWorkReportEntity.FieldCategoryFullName) ? string.Empty : dataRow[BaseWorkReportEntity.FieldCategoryFullName].ToString();
            }
            this.CompanyId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkReportEntity.FieldCompanyId]);
            this.DepartmentId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkReportEntity.FieldDepartmentId]);
            this.Score = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkReportEntity.FieldScore]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkReportEntity.FieldDescription]);
            this.StaffId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkReportEntity.FieldStaffId]);
            if (dataRow.Table.Columns.Contains(BaseWorkReportEntity.FieldStaffFullName))
            {
                this.StaffFullName = dataRow.IsNull(BaseWorkReportEntity.FieldStaffFullName) ? string.Empty : dataRow[BaseWorkReportEntity.FieldStaffFullName].ToString();
            }
            this.AuditStaffId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkReportEntity.FieldAuditStaffId]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkReportEntity.FieldEnabled]);
            this.SortCode = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkReportEntity.FieldSortCode]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkReportEntity.FieldCreateUserId]);
            this.CreateOn = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkReportEntity.FieldCreateOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkReportEntity.FieldModifiedUserId]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkReportEntity.FieldModifiedOn]);
            return this;
        }

        #region public BaseWorkReportEntity GetSingle(DataTable dataTable) 从数据表读取实体
        /// <summary>
        /// 从数据表中读取实体类
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>实体类</returns>
        public BaseWorkReportEntity GetSingle(DataTable dataTable)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.GetFrom(dataRow);
                break;
            }
            return this;
        }
        #endregion


        private string id = string.Empty;
        /// <summary>
        /// 主键
        /// </summary>
        public string Id
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

        private string companyId = string.Empty;
        /// <summary>
        /// 公司主键
        /// </summary>
        public string CompanyId
        {
            get
            {
                return companyId;
            }
            set
            {
                this.companyId = value;
            }
        }

        private string departmentId = string.Empty;
        /// <summary>
        /// 部门主键
        /// </summary>
        public string DepartmentId
        {
            get
            {
                return departmentId;
            }
            set
            {
                this.departmentId = value;
            }
        }

        private string staffId = string.Empty;
        /// <summary>
        /// 职员主键
        /// </summary>
        public string StaffId
        {
            get
            {
                return this.staffId;
            }
            set
            {
                this.staffId = value;
            }
        }

        private string staffFullName = string.Empty;
        /// <summary>
        /// 职工姓名
        /// </summary>
        public string StaffFullName
        {
            get
            {
                return this.staffFullName;
            }
            set
            {
                this.staffFullName = value;
            }
        }

        private string categoryId = string.Empty;
        /// <summary>
        /// 工作日志分类主键
        /// </summary>
        public string CategoryId
        {
            get
            {
                return this.categoryId;
            }
            set
            {
                this.categoryId = value;
            }
        }

        private string categoryFullName = string.Empty;
        /// <summary>
        /// 工作日志分类
        /// </summary>
        public string CategoryFullName
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

        private string projectId = string.Empty;
        /// <summary>
        /// 项目主键
        /// </summary>
        public string ProjectId
        {
            get
            {
                return this.projectId;
            }
            set
            {
                this.projectId = value;
            }
        }

        private string projectFullName = string.Empty;
        /// <summary>
        /// 项目
        /// </summary>
        public string ProjectFullName
        {
            get
            {
                return this.projectFullName;
            }
            set
            {
                this.projectFullName = value;
            }
        }

        private string workDate = string.Empty;
        /// <summary>
        /// 工作日志的日期
        /// </summary>
        public string WorkDate
        {
            get
            {
                return this.workDate;
            }
            set
            {
                workDate = value;
            }
        }

        private string content = string.Empty;
        /// <summary>
        /// 工作日志的内容
        /// </summary>
        public string Content
        {
            get
            {
                return this.content;
            }
            set
            {
                this.content = value;
            }
        }

        private string manHour = string.Empty;
        /// <summary>
        /// 工时
        /// </summary>
        public string ManHour
        {
            get
            {
                return this.manHour;
            }
            set
            {
                this.manHour = value;
            }
        }

        private int? score = 0;
        /// <summary>
        /// 评分
        /// </summary>
        public int? Score
        {
            get
            {
                return this.score;
            }
            set
            {
                this.score = value;
            }
        }

        private string description = string.Empty;
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

        private string stateCode = string.Empty;
        /// <summary>
        /// 审核状态
        /// </summary>
        public string StateCode
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

        private int? enabled = 0;
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

        private string auditStaffId = string.Empty;
        /// <summary>
        /// 审核者主键
        /// </summary>
        public string AuditStaffId
        {
            get
            {
                return this.auditStaffId;
            }
            set
            {
                this.auditStaffId = value;
            }
        }

        private string sortCode = string.Empty;
        /// <summary>
        ///  排序
        /// </summary>
        public string SortCode
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

        private string createUserId = string.Empty;
        /// <summary>
        /// 创建者主键
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

        private string createOn = string.Empty;
        /// <summary>
        /// 创建日期
        /// </summary>
        public string CreateOn
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

        private string modifiedUserId = string.Empty;
        /// <summary>
        /// 修改者主键
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

        private string modifiedOn = string.Empty;
        /// <summary>
        /// 修改日期
        /// </summary>
        public string ModifiedOn
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
    }
}
