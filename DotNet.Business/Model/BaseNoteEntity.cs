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
    /// BaseNoteEntity 
    /// 表结构定义部分
    /// 
    /// 修改记录
    /// 
    ///     2008.09.16 版本：1.0 Caihuajun 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// </summary>
    /// <author>
    ///		<name>Caihuajun</name>
    ///		<date>2008.09.16</date>
    /// </author> 
    /// </summary>
    [Serializable]
    public partial class BaseNoteEntity : BaseEntity
    {
        public BaseNoteEntity()
        {
        }

        public BaseNoteEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        #region public void ClearProperty()
        /// <summary>
        /// 清除内容
        /// </summary>
        /// 
        public void ClearProperty()
        {
            this.Id = string.Empty;
            this.Title = string.Empty;
            this.CategoryId = string.Empty;
            this.CategoryFullName = string.Empty;
            this.Color = string.Empty;
            this.Content = string.Empty;
            this.Enabled = true;
            this.Important = false;
            this.DeletionStateCode = false;
            this.SortCode = string.Empty;
            this.CreateUserId = string.Empty;
            this.CreateOn = string.Empty;
            this.ModifiedUserId = string.Empty;
            this.ModifiedOn = string.Empty;
        }
        #endregion

        #region public BaseNoteEntity GetSingle(DataTable dataTable) 从数据表读取实体
        /// <summary>
        /// 从数据表读取实体
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="StaffEntity">实体</param>
        /// <returns>实体</returns>
        public BaseNoteEntity GetSingle(DataTable dataTable)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.GetFrom(dataRow);
                break;
            }
            return this;
        }
        #endregion

        /// <summary>
        /// 从数据表读取实体列表
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public List<BaseNoteEntity> GetList(DataTable dataTable)
        {
            List<BaseNoteEntity> entites = new List<BaseNoteEntity>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                entites.Add(GetFrom(dataRow));
            }
            return entites;
        }

        #region public BaseNoteEntity GetFrom(DataRow dataRow) 从数据行读取
        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        /// <returns>实体类</returns>
        public BaseNoteEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[BaseNoteEntity.FieldId]);
            this.Title= BaseBusinessLogic.ConvertToString(dataRow[BaseNoteEntity.FieldTitle]);
            this.CategoryId = BaseBusinessLogic.ConvertToString(dataRow[BaseNoteEntity.FieldCategoryId]);
            this.CategoryFullName = BaseBusinessLogic.ConvertToString(dataRow[BaseNoteEntity.FieldCategoryFullName]);
            this.Color = BaseBusinessLogic.ConvertToString(dataRow[BaseNoteEntity.FieldColor]);
            this.Content = BaseBusinessLogic.ConvertToString(dataRow[BaseNoteEntity.FieldContent]);
            this.Enabled = BaseBusinessLogic.ConvertIntToBoolean(dataRow[BaseNoteEntity.FieldEnabled]);
            this.Important = BaseBusinessLogic.ConvertIntToBoolean(dataRow[BaseNoteEntity.FieldImportant]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertIntToBoolean(dataRow[BaseNoteEntity.FieldDeletionStateCode]);
            this.SortCode = BaseBusinessLogic.ConvertToString(dataRow[BaseNoteEntity.FieldSortCode]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseNoteEntity.FieldCreateUserId]);
            this.CreateOn = BaseBusinessLogic.ConvertToString(dataRow[BaseNoteEntity.FieldCreateOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseNoteEntity.FieldModifiedUserId]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToString(dataRow[BaseNoteEntity.FieldModifiedOn]);
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

        private string title = string.Empty;
        /// <summary>
        /// 主题
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        private string categoryId = string.Empty;
        /// <summary>
        /// 类别主键
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
        /// 类别名称
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

        private string color = string.Empty;
        /// <summary>
        /// 颜色
        /// </summary>
        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

        private string content = string.Empty;
        /// <summary>
        /// 备忘内容
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

        private bool enabled = true;
        /// <summary>
        /// 状态
        /// </summary>
        public bool Enabled
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

        private bool important = false;
        /// <summary>
        /// 重要性
        /// </summary>
        public bool Important
        {
            get
            {
                return this.important;
            }
            set
            {
                this.important = value;
            }
        }

        private bool deletionStateCode = false;
        /// <summary>
        /// 删除标志
        /// </summary>
        public bool DeletionStateCode
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

        private string sortCode = string.Empty;
        /// <summary>
        /// 排序码
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
        /// 创建时间
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
        /// 最后修改者主键
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
        /// 最后修改时间
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