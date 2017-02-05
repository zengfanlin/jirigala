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
    /// BaseItemDetailsEntity
    /// 选项明细表（资源明细表结构）
    ///
    /// 修改纪录
    ///
    ///		2010-07-28 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010-07-28</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class BaseItemDetailsEntity : BaseEntity
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

        private int? parentId = 0;
        /// <summary>
        /// 父节点主键
        /// </summary>
        public int? ParentId
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

        private string itemCode = null;
        /// <summary>
        /// 资源编号
        /// </summary>
        public string ItemCode
        {
            get
            {
                return this.itemCode;
            }
            set
            {
                this.itemCode = value;
            }
        }

        private string itemName = null;
        /// <summary>
        /// 资源名称
        /// </summary>
        public string ItemName
        {
            get
            {
                return this.itemName;
            }
            set
            {
                this.itemName = value;
            }
        }

        private string itemValue = null;
        /// <summary>
        /// 资源值
        /// </summary>
        public string ItemValue
        {
            get
            {
                return this.itemValue;
            }
            set
            {
                this.itemValue = value;
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
        public BaseItemDetailsEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseItemDetailsEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseItemDetailsEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseItemDetailsEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseItemDetailsEntity GetSingle(DataTable dataTable)
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
        public List<BaseItemDetailsEntity> GetList(DataTable dataTable)
        {
            List<BaseItemDetailsEntity> entites = new List<BaseItemDetailsEntity>();
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
        public BaseItemDetailsEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToInt(dataRow[BaseItemDetailsEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToInt(dataRow[BaseItemDetailsEntity.FieldParentId]);
            this.ItemCode = BaseBusinessLogic.ConvertToString(dataRow[BaseItemDetailsEntity.FieldItemCode]);
            this.ItemName = BaseBusinessLogic.ConvertToString(dataRow[BaseItemDetailsEntity.FieldItemName]);
            this.ItemValue = BaseBusinessLogic.ConvertToString(dataRow[BaseItemDetailsEntity.FieldItemValue]);
            this.AllowEdit = BaseBusinessLogic.ConvertToInt(dataRow[BaseItemDetailsEntity.FieldAllowEdit]);
            this.AllowDelete = BaseBusinessLogic.ConvertToInt(dataRow[BaseItemDetailsEntity.FieldAllowDelete]);
            this.IsPublic = BaseBusinessLogic.ConvertToInt(dataRow[BaseItemDetailsEntity.FieldIsPublic]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseItemDetailsEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseItemDetailsEntity.FieldDeletionStateCode]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseItemDetailsEntity.FieldSortCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseItemDetailsEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseItemDetailsEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseItemDetailsEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseItemDetailsEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseItemDetailsEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseItemDetailsEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseItemDetailsEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseItemDetailsEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader);
            this.Id = BaseBusinessLogic.ConvertToInt(dataReader[BaseItemDetailsEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToInt(dataReader[BaseItemDetailsEntity.FieldParentId]);
            this.ItemCode = BaseBusinessLogic.ConvertToString(dataReader[BaseItemDetailsEntity.FieldItemCode]);
            this.ItemName = BaseBusinessLogic.ConvertToString(dataReader[BaseItemDetailsEntity.FieldItemName]);
            this.ItemValue = BaseBusinessLogic.ConvertToString(dataReader[BaseItemDetailsEntity.FieldItemValue]);
            this.AllowEdit = BaseBusinessLogic.ConvertToInt(dataReader[BaseItemDetailsEntity.FieldAllowEdit]);
            this.AllowDelete = BaseBusinessLogic.ConvertToInt(dataReader[BaseItemDetailsEntity.FieldAllowDelete]);
            this.IsPublic = BaseBusinessLogic.ConvertToInt(dataReader[BaseItemDetailsEntity.FieldIsPublic]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseItemDetailsEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseItemDetailsEntity.FieldDeletionStateCode]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseItemDetailsEntity.FieldSortCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseItemDetailsEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseItemDetailsEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseItemDetailsEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseItemDetailsEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseItemDetailsEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseItemDetailsEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseItemDetailsEntity.FieldModifiedBy]);
            return this;
        }
    }
}
