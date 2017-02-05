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
    /// BaseContactDetailsEntity
    /// 联络单明细表
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
    public partial class BaseContactDetailsEntity : BaseEntity
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

        private string contactId = null;
        /// <summary>
        /// 联络单主主键
        /// </summary>
        public string ContactId
        {
            get
            {
                return this.contactId;
            }
            set
            {
                this.contactId = value;
            }
        }

        private string category = null;
        /// <summary>
        /// 接收者分类
        /// </summary>
        public string Category
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

        private string receiverId = null;
        /// <summary>
        /// 接收者主键
        /// </summary>
        public string ReceiverId
        {
            get
            {
                return this.receiverId;
            }
            set
            {
                this.receiverId = value;
            }
        }

        private string receiverRealName = null;
        /// <summary>
        /// 接收者姓名
        /// </summary>
        public string ReceiverRealName
        {
            get
            {
                return this.receiverRealName;
            }
            set
            {
                this.receiverRealName = value;
            }
        }

        private int? isNew = 0;
        /// <summary>
        /// 是否新邮件
        /// </summary>
        public int? IsNew
        {
            get
            {
                return this.isNew;
            }
            set
            {
                this.isNew = value;
            }
        }

        private int? newComment = 0;
        /// <summary>
        /// 是否有新的评论
        /// </summary>
        public int? NewComment
        {
            get
            {
                return this.newComment;
            }
            set
            {
                this.newComment = value;
            }
        }

        private string lastViewIP = null;
        /// <summary>
        /// 最后阅读IP
        /// </summary>
        public string LastViewIP
        {
            get
            {
                return this.lastViewIP;
            }
            set
            {
                this.lastViewIP = value;
            }
        }

        private string lastViewDate = null;
        /// <summary>
        /// 最后阅读时间
        /// </summary>
        public string LastViewDate
        {
            get
            {
                return this.lastViewDate;
            }
            set
            {
                this.lastViewDate = value;
            }
        }

        private int? enabled = 0;
        /// <summary>
        /// 有新评论是否提示
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
        public BaseContactDetailsEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseContactDetailsEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseContactDetailsEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseContactDetailsEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseContactDetailsEntity GetSingle(DataTable dataTable)
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
        public List<BaseContactDetailsEntity> GetList(DataTable dataTable)
        {
            List<BaseContactDetailsEntity> entites = new List<BaseContactDetailsEntity>();
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
        public BaseContactDetailsEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[BaseContactDetailsEntity.FieldId]);
            this.ContactId = BaseBusinessLogic.ConvertToString(dataRow[BaseContactDetailsEntity.FieldContactId]);
            this.Category = BaseBusinessLogic.ConvertToString(dataRow[BaseContactDetailsEntity.FieldCategory]);
            this.ReceiverId = BaseBusinessLogic.ConvertToString(dataRow[BaseContactDetailsEntity.FieldReceiverId]);
            this.ReceiverRealName = BaseBusinessLogic.ConvertToString(dataRow[BaseContactDetailsEntity.FieldReceiverRealName]);
            this.IsNew = BaseBusinessLogic.ConvertToInt(dataRow[BaseContactDetailsEntity.FieldIsNew]);
            this.NewComment = BaseBusinessLogic.ConvertToInt(dataRow[BaseContactDetailsEntity.FieldNewComment]);
            this.LastViewIP = BaseBusinessLogic.ConvertToString(dataRow[BaseContactDetailsEntity.FieldLastViewIP]);
            this.LastViewDate = BaseBusinessLogic.ConvertToString(dataRow[BaseContactDetailsEntity.FieldLastViewDate]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseContactDetailsEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseContactDetailsEntity.FieldDeletionStateCode]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseContactDetailsEntity.FieldSortCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseContactDetailsEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseContactDetailsEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseContactDetailsEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseContactDetailsEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseContactDetailsEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseContactDetailsEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseContactDetailsEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseContactDetailsEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader);
            this.Id = BaseBusinessLogic.ConvertToString(dataReader[BaseContactDetailsEntity.FieldId]);
            this.ContactId = BaseBusinessLogic.ConvertToString(dataReader[BaseContactDetailsEntity.FieldContactId]);
            this.Category = BaseBusinessLogic.ConvertToString(dataReader[BaseContactDetailsEntity.FieldCategory]);
            this.ReceiverId = BaseBusinessLogic.ConvertToString(dataReader[BaseContactDetailsEntity.FieldReceiverId]);
            this.ReceiverRealName = BaseBusinessLogic.ConvertToString(dataReader[BaseContactDetailsEntity.FieldReceiverRealName]);
            this.IsNew = BaseBusinessLogic.ConvertToInt(dataReader[BaseContactDetailsEntity.FieldIsNew]);
            this.NewComment = BaseBusinessLogic.ConvertToInt(dataReader[BaseContactDetailsEntity.FieldNewComment]);
            this.LastViewIP = BaseBusinessLogic.ConvertToString(dataReader[BaseContactDetailsEntity.FieldLastViewIP]);
            this.LastViewDate = BaseBusinessLogic.ConvertToString(dataReader[BaseContactDetailsEntity.FieldLastViewDate]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseContactDetailsEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseContactDetailsEntity.FieldDeletionStateCode]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseContactDetailsEntity.FieldSortCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseContactDetailsEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseContactDetailsEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseContactDetailsEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseContactDetailsEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseContactDetailsEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseContactDetailsEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseContactDetailsEntity.FieldModifiedBy]);
            return this;
        }
    }
}
