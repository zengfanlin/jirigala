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
    /// BaseUserOrganizeEntity
    /// 用户帐户组织关系表
    ///
    /// 修改纪录
    ///
    ///		2010-09-25 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010-09-25</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class BaseUserOrganizeEntity : BaseEntity
    {
        private int? id = 0;
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

        private int? userId = 0;
        /// <summary>
        /// 用户帐户主键
        /// </summary>
        public int? UserId
        {
            get
            {
                return this.userId;
            }
            set
            {
                this.userId = value;
            }
        }

        private int? companyId = 0;
        /// <summary>
        /// 公司代码
        /// </summary>
        public int? CompanyId
        {
            get
            {
                return this.companyId;
            }
            set
            {
                this.companyId = value;
            }
        }

        private int? departmentId = 0;
        /// <summary>
        /// 部门代码
        /// </summary>
        public int? DepartmentId
        {
            get
            {
                return this.departmentId;
            }
            set
            {
                this.departmentId = value;
            }
        }

        private int? workgroupId = 0;
        /// <summary>
        /// 工作组代码
        /// </summary>
        public int? WorkgroupId
        {
            get
            {
                return this.workgroupId;
            }
            set
            {
                this.workgroupId = value;
            }
        }

        private int? roleId = 0;
        /// <summary>
        /// 角色主键
        /// </summary>
        public int? RoleId
        {
            get
            {
                return this.roleId;
            }
            set
            {
                this.roleId = value;
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

        private int? deletionStateCode = 0;
        /// <summary>
        /// 删除标记
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
        public BaseUserOrganizeEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseUserOrganizeEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseUserOrganizeEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseUserOrganizeEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseUserOrganizeEntity GetSingle(DataTable dataTable)
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
        public List<BaseUserOrganizeEntity> GetList(DataTable dataTable)
        {
            List<BaseUserOrganizeEntity> entites = new List<BaseUserOrganizeEntity>();
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
        public BaseUserOrganizeEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserOrganizeEntity.FieldId]);
            this.UserId = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserOrganizeEntity.FieldUserId]);
            this.CompanyId = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserOrganizeEntity.FieldCompanyId]);
            this.DepartmentId = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserOrganizeEntity.FieldDepartmentId]);
            this.WorkgroupId = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserOrganizeEntity.FieldWorkgroupId]);
            this.RoleId = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserOrganizeEntity.FieldRoleId]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserOrganizeEntity.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseUserOrganizeEntity.FieldDescription]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserOrganizeEntity.FieldDeletionStateCode]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseUserOrganizeEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseUserOrganizeEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseUserOrganizeEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseUserOrganizeEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseUserOrganizeEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseUserOrganizeEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseUserOrganizeEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader);
            this.Id = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserOrganizeEntity.FieldId]);
            this.UserId = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserOrganizeEntity.FieldUserId]);
            this.CompanyId = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserOrganizeEntity.FieldCompanyId]);
            this.DepartmentId = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserOrganizeEntity.FieldDepartmentId]);
            this.WorkgroupId = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserOrganizeEntity.FieldWorkgroupId]);
            this.RoleId = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserOrganizeEntity.FieldRoleId]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserOrganizeEntity.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseUserOrganizeEntity.FieldDescription]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserOrganizeEntity.FieldDeletionStateCode]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseUserOrganizeEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseUserOrganizeEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseUserOrganizeEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseUserOrganizeEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseUserOrganizeEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseUserOrganizeEntity.FieldModifiedBy]);
            return this;
        }
    }
}
