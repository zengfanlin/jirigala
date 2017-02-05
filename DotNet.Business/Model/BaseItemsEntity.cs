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
    /// BaseItemsEntity
    /// 选项主表（资源）
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
    public partial class BaseItemsEntity : BaseEntity
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

        private int? parentId = null;
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

        private string targetTable = null;
        /// <summary>
        /// 目标存储表
        /// </summary>
        public string TargetTable
        {
            get
            {
                return this.targetTable;
            }
            set
            {
                this.targetTable = value;
            }
        }

        private int? isTree = 0;
        /// <summary>
        /// 树型结构
        /// </summary>
        public int? IsTree
        {
            get
            {
                return this.isTree;
            }
            set
            {
                this.isTree = value;
            }
        }

        private string useItemCode = null;
        /// <summary>
        /// 编号字段对应值
        /// </summary>
        public string UseItemCode
        {
            get
            {
                return this.useItemCode;
            }
            set
            {
                this.useItemCode = value;
            }
        }

        private string useItemName = null;
        /// <summary>
        /// 名称字段对应值
        /// </summary>
        public string UseItemName
        {
            get
            {
                return this.useItemName;
            }
            set
            {
                this.useItemName = value;
            }
        }

        private string useItemValue = null;
        /// <summary>
        /// 值字段对应值
        /// </summary>
        public string UseItemValue
        {
            get
            {
                return this.useItemValue;
            }
            set
            {
                this.useItemValue = value;
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
        public BaseItemsEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseItemsEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseItemsEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseItemsEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseItemsEntity GetSingle(DataTable dataTable)
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
        public List<BaseItemsEntity> GetList(DataTable dataTable)
        {
            List<BaseItemsEntity> entites = new List<BaseItemsEntity>();
            foreach(DataRow dataRow in dataTable.Rows)
            {
                entites.Add(GetFrom(dataRow));
            }
            return entites;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseItemsEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToInt(dataRow[BaseItemsEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToInt(dataRow[BaseItemsEntity.FieldParentId]);
            this.Code = BaseBusinessLogic.ConvertToString(dataRow[BaseItemsEntity.FieldCode]);
            this.FullName = BaseBusinessLogic.ConvertToString(dataRow[BaseItemsEntity.FieldFullName]);
            this.TargetTable = BaseBusinessLogic.ConvertToString(dataRow[BaseItemsEntity.FieldTargetTable]);
            this.IsTree = BaseBusinessLogic.ConvertToInt(dataRow[BaseItemsEntity.FieldIsTree]);
            this.UseItemCode = BaseBusinessLogic.ConvertToString(dataRow[BaseItemsEntity.FieldUseItemCode]);
            this.UseItemName = BaseBusinessLogic.ConvertToString(dataRow[BaseItemsEntity.FieldUseItemName]);
            this.UseItemValue = BaseBusinessLogic.ConvertToString(dataRow[BaseItemsEntity.FieldUseItemValue]);
            this.AllowEdit = BaseBusinessLogic.ConvertToInt(dataRow[BaseItemsEntity.FieldAllowEdit]);
            this.AllowDelete = BaseBusinessLogic.ConvertToInt(dataRow[BaseItemsEntity.FieldAllowDelete]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseItemsEntity.FieldDeletionStateCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseItemsEntity.FieldDescription]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseItemsEntity.FieldEnabled]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseItemsEntity.FieldSortCode]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseItemsEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseItemsEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseItemsEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseItemsEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseItemsEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseItemsEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseItemsEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader);
            this.Id = BaseBusinessLogic.ConvertToInt(dataReader[BaseItemsEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToInt(dataReader[BaseItemsEntity.FieldParentId]);
            this.Code = BaseBusinessLogic.ConvertToString(dataReader[BaseItemsEntity.FieldCode]);
            this.FullName = BaseBusinessLogic.ConvertToString(dataReader[BaseItemsEntity.FieldFullName]);
            this.TargetTable = BaseBusinessLogic.ConvertToString(dataReader[BaseItemsEntity.FieldTargetTable]);
            this.IsTree = BaseBusinessLogic.ConvertToInt(dataReader[BaseItemsEntity.FieldIsTree]);
            this.UseItemCode = BaseBusinessLogic.ConvertToString(dataReader[BaseItemsEntity.FieldUseItemCode]);
            this.UseItemName = BaseBusinessLogic.ConvertToString(dataReader[BaseItemsEntity.FieldUseItemName]);
            this.UseItemValue = BaseBusinessLogic.ConvertToString(dataReader[BaseItemsEntity.FieldUseItemValue]);
            this.AllowEdit = BaseBusinessLogic.ConvertToInt(dataReader[BaseItemsEntity.FieldAllowEdit]);
            this.AllowDelete = BaseBusinessLogic.ConvertToInt(dataReader[BaseItemsEntity.FieldAllowDelete]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseItemsEntity.FieldDeletionStateCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseItemsEntity.FieldDescription]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseItemsEntity.FieldEnabled]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseItemsEntity.FieldSortCode]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseItemsEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseItemsEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseItemsEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseItemsEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseItemsEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseItemsEntity.FieldModifiedBy]);
            return this;
        }
    }
}
