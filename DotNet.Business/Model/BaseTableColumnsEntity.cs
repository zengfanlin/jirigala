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
    /// BaseTableColumnsEntity
    /// 表字段结构定义说明
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
    public partial class BaseTableColumnsEntity : BaseEntity
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

        private string tableCode = null;
        /// <summary>
        /// 表
        /// </summary>
        public string TableCode
        {
            get
            {
                return this.tableCode;
            }
            set
            {
                this.tableCode = value;
            }
        }

        private string columnCode = null;
        /// <summary>
        /// 表
        /// </summary>
        public string ColumnCode
        {
            get
            {
                return this.columnCode;
            }
            set
            {
                this.columnCode = value;
            }
        }

        private string columnName = null;
        /// <summary>
        /// 表名
        /// </summary>
        public string ColumnName
        {
            get
            {
                return this.columnName;
            }
            set
            {
                this.columnName = value;
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

        private int? allowEdit = 0;
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

        private int? allowDelete = 0;
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
        public BaseTableColumnsEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseTableColumnsEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseTableColumnsEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseTableColumnsEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseTableColumnsEntity GetSingle(DataTable dataTable)
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
        public List<BaseTableColumnsEntity> GetList(DataTable dataTable)
        {
            List<BaseTableColumnsEntity> entites = new List<BaseTableColumnsEntity>();
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
        public BaseTableColumnsEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToInt(dataRow[BaseTableColumnsEntity.FieldId]);
            this.TableCode = BaseBusinessLogic.ConvertToString(dataRow[BaseTableColumnsEntity.FieldTableCode]);
            this.ColumnCode = BaseBusinessLogic.ConvertToString(dataRow[BaseTableColumnsEntity.FieldColumnCode]);
            this.ColumnName = BaseBusinessLogic.ConvertToString(dataRow[BaseTableColumnsEntity.FieldColumnName]);
            this.IsPublic = BaseBusinessLogic.ConvertToInt(dataRow[BaseTableColumnsEntity.FieldIsPublic]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseTableColumnsEntity.FieldEnabled]);
            this.AllowEdit = BaseBusinessLogic.ConvertToInt(dataRow[BaseTableColumnsEntity.FieldAllowEdit]);
            this.AllowDelete = BaseBusinessLogic.ConvertToInt(dataRow[BaseTableColumnsEntity.FieldAllowDelete]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseTableColumnsEntity.FieldDeletionStateCode]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseTableColumnsEntity.FieldSortCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseTableColumnsEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseTableColumnsEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseTableColumnsEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseTableColumnsEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseTableColumnsEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseTableColumnsEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseTableColumnsEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseTableColumnsEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader);
            this.Id = BaseBusinessLogic.ConvertToInt(dataReader[BaseTableColumnsEntity.FieldId]);
            this.TableCode = BaseBusinessLogic.ConvertToString(dataReader[BaseTableColumnsEntity.FieldTableCode]);
            this.ColumnCode = BaseBusinessLogic.ConvertToString(dataReader[BaseTableColumnsEntity.FieldColumnCode]);
            this.ColumnName = BaseBusinessLogic.ConvertToString(dataReader[BaseTableColumnsEntity.FieldColumnName]);
            this.IsPublic = BaseBusinessLogic.ConvertToInt(dataReader[BaseTableColumnsEntity.FieldIsPublic]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseTableColumnsEntity.FieldEnabled]);
            this.AllowEdit = BaseBusinessLogic.ConvertToInt(dataReader[BaseTableColumnsEntity.FieldAllowEdit]);
            this.AllowDelete = BaseBusinessLogic.ConvertToInt(dataReader[BaseTableColumnsEntity.FieldAllowDelete]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseTableColumnsEntity.FieldDeletionStateCode]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseTableColumnsEntity.FieldSortCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseTableColumnsEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseTableColumnsEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseTableColumnsEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseTableColumnsEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseTableColumnsEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseTableColumnsEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseTableColumnsEntity.FieldModifiedBy]);
            return this;
        }
    }
}
