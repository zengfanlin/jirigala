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
    /// BaseContactEntity
    /// 联络单主表
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
    public partial class BaseContactEntity : BaseEntity
    {
        private string id = null;
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

        private string parentId = null;
        /// <summary>
        /// 父主键
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

        private string title = null;
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

        private string contents = null;
        /// <summary>
        /// 内容
        /// </summary>
        public string Contents
        {
            get
            {
                return this.contents;
            }
            set
            {
                this.contents = value;
            }
        }

        private string priority = null;
        /// <summary>
        /// 邮件等级
        /// </summary>
        public string Priority
        {
            get
            {
                return this.priority;
            }
            set
            {
                this.priority = value;
            }
        }

        private int? sendCount = 0;
        /// <summary>
        /// 发送邮件总数
        /// </summary>
        public int? SendCount
        {
            get
            {
                return this.sendCount;
            }
            set
            {
                this.sendCount = value;
            }
        }

        private int? readCount = 0;
        /// <summary>
        /// 已阅读人数
        /// </summary>
        public int? ReadCount
        {
            get
            {
                return this.readCount;
            }
            set
            {
                this.readCount = value;
            }
        }

        private int? isOpen = 0;
        /// <summary>
        /// 是否公开
        /// </summary>
        public int? IsOpen
        {
            get
            {
                return this.isOpen;
            }
            set
            {
                this.isOpen = value;
            }
        }

        private string commentUserId = null;
        /// <summary>
        /// 最后评论人主键
        /// </summary>
        public string CommentUserId
        {
            get
            {
                return this.commentUserId;
            }
            set
            {
                this.commentUserId = value;
            }
        }

        private string commentUserRealName = null;
        /// <summary>
        /// 最后评论人姓名
        /// </summary>
        public string CommentUserRealName
        {
            get
            {
                return this.commentUserRealName;
            }
            set
            {
                this.commentUserRealName = value;
            }
        }

        private DateTime? commentDate = null;
        /// <summary>
        /// 最后评论时间
        /// </summary>
        public DateTime? CommentDate
        {
            get
            {
                return this.commentDate;
            }
            set
            {
                this.commentDate = value;
            }
        }

        private int? deletionStateCode = 0;
        /// <summary>
        /// 是否删除
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
        public BaseContactEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseContactEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseContactEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseContactEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseContactEntity GetSingle(DataTable dataTable)
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
        public List<BaseContactEntity> GetList(DataTable dataTable)
        {
            List<BaseContactEntity> entites = new List<BaseContactEntity>();
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
        public BaseContactEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[BaseContactEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToString(dataRow[BaseContactEntity.FieldParentId]);
            this.Title = BaseBusinessLogic.ConvertToString(dataRow[BaseContactEntity.FieldTitle]);
            this.Contents = BaseBusinessLogic.ConvertToString(dataRow[BaseContactEntity.FieldContents]);
            this.Priority = BaseBusinessLogic.ConvertToString(dataRow[BaseContactEntity.FieldPriority]);
            this.SendCount = BaseBusinessLogic.ConvertToInt(dataRow[BaseContactEntity.FieldSendCount]);
            this.ReadCount = BaseBusinessLogic.ConvertToInt(dataRow[BaseContactEntity.FieldReadCount]);
            this.IsOpen = BaseBusinessLogic.ConvertToInt(dataRow[BaseContactEntity.FieldIsOpen]);
            this.CommentUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseContactEntity.FieldCommentUserId]);
            this.CommentUserRealName = BaseBusinessLogic.ConvertToString(dataRow[BaseContactEntity.FieldCommentUserRealName]);
            this.CommentDate = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseContactEntity.FieldCommentDate]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseContactEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseContactEntity.FieldEnabled]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseContactEntity.FieldSortCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseContactEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseContactEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseContactEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseContactEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseContactEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseContactEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseContactEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseContactEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader);
            this.Id = BaseBusinessLogic.ConvertToString(dataReader[BaseContactEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToString(dataReader[BaseContactEntity.FieldParentId]);
            this.Title = BaseBusinessLogic.ConvertToString(dataReader[BaseContactEntity.FieldTitle]);
            this.Contents = BaseBusinessLogic.ConvertToString(dataReader[BaseContactEntity.FieldContents]);
            this.Priority = BaseBusinessLogic.ConvertToString(dataReader[BaseContactEntity.FieldPriority]);
            this.SendCount = BaseBusinessLogic.ConvertToInt(dataReader[BaseContactEntity.FieldSendCount]);
            this.ReadCount = BaseBusinessLogic.ConvertToInt(dataReader[BaseContactEntity.FieldReadCount]);
            this.IsOpen = BaseBusinessLogic.ConvertToInt(dataReader[BaseContactEntity.FieldIsOpen]);
            this.CommentUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseContactEntity.FieldCommentUserId]);
            this.CommentUserRealName = BaseBusinessLogic.ConvertToString(dataReader[BaseContactEntity.FieldCommentUserRealName]);
            this.CommentDate = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseContactEntity.FieldCommentDate]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseContactEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseContactEntity.FieldEnabled]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseContactEntity.FieldSortCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseContactEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseContactEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseContactEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseContactEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseContactEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseContactEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseContactEntity.FieldModifiedBy]);
            return this;
        }
    }
}
