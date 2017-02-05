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
    /// BaseRoleEntity
    /// 系统角色表
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
    [Serializable]
    public partial class BaseRoleEntity : BaseEntity
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

        private string systemId = null;
        /// <summary>
        /// 系统主键
        /// </summary>
        public string SystemId
        {
            get
            {
                return this.systemId;
            }
            set
            {
                this.systemId = value;
            }
        }

        private string organizeId = null;
        /// <summary>
        /// 组织机构主键
        /// </summary>
        public string OrganizeId
        {
            get
            {
                return this.organizeId;
            }
            set
            {
                this.organizeId = value;
            }
        }

        private string code = null;
        /// <summary>
        /// 角色编号
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

        private string realName = null;
        /// <summary>
        /// 角色名称
        /// </summary>
        public string RealName
        {
            get
            {
                return this.realName;
            }
            set
            {
                this.realName = value;
            }
        }

        private string categoryCode = null;
        /// <summary>
        /// 角色分类
        /// </summary>
        public string CategoryCode
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

        private int? allowEdit = 1;
        /// <summary>
        /// 允许编辑
        /// </summary>
        public int? AllowEdit
        {
            get
            {
                return this.allowEdit;
            }
            set
            {
                this.allowEdit = value;
            }
        }

        private int? allowDelete = 1;
        /// <summary>
        /// 允许删除
        /// </summary>
        public int? AllowDelete
        {
            get
            {
                return this.allowDelete;
            }
            set
            {
                this.allowDelete = value;
            }
        }

        private int? isVisible = 1;
        /// <summary>
        /// 是否显示
        /// </summary>
        public int? IsVisible
        {
            get
            {
                return this.isVisible;
            }
            set
            {
                this.isVisible = value;
            }
        }

        private int? sortCode = 0;
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

        private int? enabled = 0;
        /// <summary>
        /// 有效标志
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
        public BaseRoleEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseRoleEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseRoleEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseRoleEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseRoleEntity GetSingle(DataTable dataTable)
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
        public List<BaseRoleEntity> GetList(DataTable dataTable)
        {
            List<BaseRoleEntity> entites = new List<BaseRoleEntity>();
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
        public BaseRoleEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToInt(dataRow[BaseRoleEntity.FieldId]);
            this.SystemId = BaseBusinessLogic.ConvertToString(dataRow[BaseRoleEntity.FieldSystemId]);
            this.OrganizeId = BaseBusinessLogic.ConvertToString(dataRow[BaseRoleEntity.FieldOrganizeId]);
            this.Code = BaseBusinessLogic.ConvertToString(dataRow[BaseRoleEntity.FieldCode]);
            this.RealName = BaseBusinessLogic.ConvertToString(dataRow[BaseRoleEntity.FieldRealName]);
            this.CategoryCode = BaseBusinessLogic.ConvertToString(dataRow[BaseRoleEntity.FieldCategoryCode]);
            this.AllowEdit = BaseBusinessLogic.ConvertToInt(dataRow[BaseRoleEntity.FieldAllowEdit]);
            this.AllowDelete = BaseBusinessLogic.ConvertToInt(dataRow[BaseRoleEntity.FieldAllowDelete]);
            this.IsVisible = BaseBusinessLogic.ConvertToInt(dataRow[BaseRoleEntity.FieldIsVisible]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseRoleEntity.FieldSortCode]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseRoleEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseRoleEntity.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseRoleEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseRoleEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseRoleEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseRoleEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseRoleEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseRoleEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseRoleEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseRoleEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader);
            this.Id = BaseBusinessLogic.ConvertToInt(dataReader[BaseRoleEntity.FieldId]);
            this.SystemId = BaseBusinessLogic.ConvertToString(dataReader[BaseRoleEntity.FieldSystemId]);
            this.OrganizeId = BaseBusinessLogic.ConvertToString(dataReader[BaseRoleEntity.FieldOrganizeId]);
            this.Code = BaseBusinessLogic.ConvertToString(dataReader[BaseRoleEntity.FieldCode]);
            this.RealName = BaseBusinessLogic.ConvertToString(dataReader[BaseRoleEntity.FieldRealName]);
            this.CategoryCode = BaseBusinessLogic.ConvertToString(dataReader[BaseRoleEntity.FieldCategoryCode]);
            this.AllowEdit = BaseBusinessLogic.ConvertToInt(dataReader[BaseRoleEntity.FieldAllowEdit]);
            this.AllowDelete = BaseBusinessLogic.ConvertToInt(dataReader[BaseRoleEntity.FieldAllowDelete]);
            this.IsVisible = BaseBusinessLogic.ConvertToInt(dataReader[BaseRoleEntity.FieldIsVisible]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseRoleEntity.FieldSortCode]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseRoleEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseRoleEntity.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseRoleEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseRoleEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseRoleEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseRoleEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseRoleEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseRoleEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseRoleEntity.FieldModifiedBy]);
            return this;
        }
    }
}