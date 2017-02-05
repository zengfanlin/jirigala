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
    /// BasePermissionItemEntity
    /// 操作权限项定义
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
    public partial class BasePermissionItemEntity : BaseEntity
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

        private string parentId = null;
        /// <summary>
        /// 父级主键
        /// </summary>
        public string ParentId
        {
            get
            {
                return this.parentId;
            }
            set
            {
                this.parentId = value;
            }
        }

        private string code = null;
        /// <summary>
        /// 编号
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
        /// 名称
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

        private string category = "Application";
        /// <summary>
        /// 权限分类
        /// </summary>
        public string CategoryCode
        {
            get
            {
                return this.category;
            }
            set
            {
                this.category = value;
            }
        }

        private int? isScope = 0;
        /// <summary>
        /// 权限域
        /// </summary>
        public int? IsScope
        {
            get
            {
                return this.isScope;
            }
            set
            {
                this.isScope = value;
            }
        }

        private int? isPublic = 0;
        /// <summary>
        /// 是公开
        /// </summary>
        public int? IsPublic
        {
            get
            {
                return this.isPublic;
            }
            set
            {
                this.isPublic = value;
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

        private DateTime? lastCall = null;
        /// <summary>
        /// 最后被调用日期
        /// </summary>
        public DateTime? LastCall
        {
            get
            {
                return this.lastCall;
            }
            set
            {
                this.lastCall = value;
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
        public BasePermissionItemEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BasePermissionItemEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BasePermissionItemEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BasePermissionItemEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BasePermissionItemEntity GetSingle(DataTable dataTable)
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
        public List<BasePermissionItemEntity> GetList(DataTable dataTable)
        {
            List<BasePermissionItemEntity> entites = new List<BasePermissionItemEntity>();
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
        public BasePermissionItemEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToInt(dataRow[BasePermissionItemEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionItemEntity.FieldParentId]);
            this.Code = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionItemEntity.FieldCode]);
            this.FullName = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionItemEntity.FieldFullName]);
            this.CategoryCode = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionItemEntity.FieldCategoryCode]);
            this.IsScope = BaseBusinessLogic.ConvertToInt(dataRow[BasePermissionItemEntity.FieldIsScope]);
            this.IsPublic = BaseBusinessLogic.ConvertToInt(dataRow[BasePermissionItemEntity.FieldIsPublic]);
            this.AllowEdit = BaseBusinessLogic.ConvertToInt(dataRow[BasePermissionItemEntity.FieldAllowEdit]);
            this.AllowDelete = BaseBusinessLogic.ConvertToInt(dataRow[BasePermissionItemEntity.FieldAllowDelete]);
            this.LastCall = BaseBusinessLogic.ConvertToDateTime(dataRow[BasePermissionItemEntity.FieldLastCall]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BasePermissionItemEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BasePermissionItemEntity.FieldDeletionStateCode]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BasePermissionItemEntity.FieldSortCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionItemEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BasePermissionItemEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionItemEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionItemEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BasePermissionItemEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionItemEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BasePermissionItemEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BasePermissionItemEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader);
            this.Id = BaseBusinessLogic.ConvertToInt(dataReader[BasePermissionItemEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionItemEntity.FieldParentId]);
            this.Code = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionItemEntity.FieldCode]);
            this.FullName = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionItemEntity.FieldFullName]);
            this.CategoryCode = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionItemEntity.FieldCategoryCode]);
            this.IsScope = BaseBusinessLogic.ConvertToInt(dataReader[BasePermissionItemEntity.FieldIsScope]);
            this.IsPublic = BaseBusinessLogic.ConvertToInt(dataReader[BasePermissionItemEntity.FieldIsPublic]);
            this.AllowEdit = BaseBusinessLogic.ConvertToInt(dataReader[BasePermissionItemEntity.FieldAllowEdit]);
            this.AllowDelete = BaseBusinessLogic.ConvertToInt(dataReader[BasePermissionItemEntity.FieldAllowDelete]);
            this.LastCall = BaseBusinessLogic.ConvertToDateTime(dataReader[BasePermissionItemEntity.FieldLastCall]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BasePermissionItemEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BasePermissionItemEntity.FieldDeletionStateCode]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BasePermissionItemEntity.FieldSortCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionItemEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BasePermissionItemEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionItemEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionItemEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BasePermissionItemEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionItemEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BasePermissionItemEntity.FieldModifiedBy]);
            return this;
        }
    }
}
