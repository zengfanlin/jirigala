//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseMessageEntity
    /// 消息表
    /// 
    /// 修改纪录
    /// 
    /// 2012-07-03 版本：1.0 JiRiGaLa 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>JiRiGaLa</name>
    /// <date>2012-07-03</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class BaseMessageEntity : BaseEntity
    {
        private String id = string.Empty;
        /// <summary>
        /// 主键
        /// </summary>
        public String Id
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

        private String parentId = string.Empty;
        /// <summary>
        /// 父亲节点主键
        /// </summary>
        public String ParentId
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

        private String receiverDepartmentId = string.Empty;
        /// <summary>
        /// 部门主键
        /// </summary>
        public String ReceiverDepartmentId
        {
            get
            {
                return this.receiverDepartmentId;
            }
            set
            {
                this.receiverDepartmentId = value;
            }
        }

        private String receiverDepartmentName = string.Empty;
        /// <summary>
        /// 部门名称
        /// </summary>
        public String ReceiverDepartmentName
        {
            get
            {
                return this.receiverDepartmentName;
            }
            set
            {
                this.receiverDepartmentName = value;
            }
        }

        private String receiverId = string.Empty;
        /// <summary>
        /// 接收者主键
        /// </summary>
        public String ReceiverId
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

        private String receiverRealName = string.Empty;
        /// <summary>
        /// 接收着姓名
        /// </summary>
        public String ReceiverRealName
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

        private String functionCode = string.Empty;
        /// <summary>
        /// 功能分类主键，Send发送、Receiver接收
        /// </summary>
        public String FunctionCode
        {
            get
            {
                return this.functionCode;
            }
            set
            {
                this.functionCode = value;
            }
        }

        private String categoryCode = string.Empty;
        /// <summary>
        /// 分类主键
        /// </summary>
        public String CategoryCode
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

        private String objectId = string.Empty;
        /// <summary>
        /// 唯一识别主键
        /// </summary>
        public String ObjectId
        {
            get
            {
                return this.objectId;
            }
            set
            {
                this.objectId = value;
            }
        }

        private String title = string.Empty;
        /// <summary>
        /// 主题
        /// </summary>
        public String Title
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

        private String contents = string.Empty;
        /// <summary>
        /// 内容
        /// </summary>
        public String Contents
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

        private int? isNew = null;
        /// <summary>
        /// 是否新信息
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

        private int? readCount = 0;
        /// <summary>
        /// 被阅读次数
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

        private DateTime? readDate = null;
        /// <summary>
        /// 阅读日期
        /// </summary>
        public DateTime? ReadDate
        {
            get
            {
                return this.readDate;
            }
            set
            {
                this.readDate = value;
            }
        }

        private String targetURL = string.Empty;
        /// <summary>
        /// 消息的指向网页页面
        /// </summary>
        public String TargetURL
        {
            get
            {
                return this.targetURL;
            }
            set
            {
                this.targetURL = value;
            }
        }

        private String iPAddress = string.Empty;
        /// <summary>
        /// IP地址
        /// </summary>
        public String IPAddress
        {
            get
            {
                return this.iPAddress;
            }
            set
            {
                this.iPAddress = value;
            }
        }

        private String createDepartmentId = string.Empty;
        /// <summary>
        /// 部门主键
        /// </summary>
        public String CreateDepartmentId
        {
            get
            {
                return this.createDepartmentId;
            }
            set
            {
                this.createDepartmentId = value;
            }
        }

        private String createDepartmentName = string.Empty;
        /// <summary>
        /// 部门名称
        /// </summary>
        public String CreateDepartmentName
        {
            get
            {
                return this.createDepartmentName;
            }
            set
            {
                this.createDepartmentName = value;
            }
        }

        private int? deletionStateCode = null;
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

        private int? enabled = 1;
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

        private String description = string.Empty;
        /// <summary>
        /// 描述
        /// </summary>
        public String Description
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

        private int? sortCode = null;
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

        private String createUserId = string.Empty;
        /// <summary>
        /// 创建用户主键
        /// </summary>
        public String CreateUserId
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

        private String createBy = string.Empty;
        /// <summary>
        /// 创建用户
        /// </summary>
        public String CreateBy
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

        private String modifiedUserId = string.Empty;
        /// <summary>
        /// 修改用户主键
        /// </summary>
        public String ModifiedUserId
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

        private String modifiedBy = string.Empty;
        /// <summary>
        /// 修改用户
        /// </summary>
        public String ModifiedBy
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
        public BaseMessageEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseMessageEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseMessageEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseMessageEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseMessageEntity GetSingle(DataTable dataTable)
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
        /// 从数据表读取返回实体列表
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public List<BaseMessageEntity> GetList(DataTable dataTable)
        {
            List<BaseMessageEntity> entities = new List<BaseMessageEntity>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                entities.Add(GetFrom(dataRow));
            }
            return entities;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseMessageEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldParentId]);
            this.ReceiverDepartmentId = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldReceiverDepartmentId]);
            this.ReceiverDepartmentName = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldReceiverDepartmentName]);
            this.ReceiverId = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldReceiverId]);
            this.ReceiverRealName = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldReceiverRealName]);
            this.FunctionCode = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldFunctionCode]);
            this.CategoryCode = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldCategoryCode]);
            this.ObjectId = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldObjectId]);
            this.Title = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldTitle]);
            this.Contents = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldContents]);
            this.IsNew = BaseBusinessLogic.ConvertToInt(dataRow[BaseMessageEntity.FieldIsNew]);
            this.ReadCount = BaseBusinessLogic.ConvertToInt(dataRow[BaseMessageEntity.FieldReadCount]);
            this.ReadDate = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseMessageEntity.FieldReadDate]);
            this.TargetURL = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldTargetURL]);
            this.IPAddress = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldIPAddress]);
            this.CreateDepartmentId = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldCreateDepartmentId]);
            this.CreateDepartmentName = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldCreateDepartmentName]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseMessageEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseMessageEntity.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldDescription]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseMessageEntity.FieldSortCode]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseMessageEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseMessageEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseMessageEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseMessageEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader); ;
            this.Id = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldParentId]);
            this.ReceiverDepartmentId = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldReceiverDepartmentId]);
            this.ReceiverDepartmentName = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldReceiverDepartmentName]);
            this.ReceiverId = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldReceiverId]);
            this.ReceiverRealName = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldReceiverRealName]);
            this.FunctionCode = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldFunctionCode]);
            this.CategoryCode = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldCategoryCode]);
            this.ObjectId = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldObjectId]);
            this.Title = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldTitle]);
            this.Contents = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldContents]);
            this.IsNew = BaseBusinessLogic.ConvertToInt(dataReader[BaseMessageEntity.FieldIsNew]);
            this.ReadCount = BaseBusinessLogic.ConvertToInt(dataReader[BaseMessageEntity.FieldReadCount]);
            this.ReadDate = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseMessageEntity.FieldReadDate]);
            this.TargetURL = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldTargetURL]);
            this.IPAddress = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldIPAddress]);
            this.CreateDepartmentId = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldCreateDepartmentId]);
            this.CreateDepartmentName = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldCreateDepartmentName]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseMessageEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseMessageEntity.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldDescription]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseMessageEntity.FieldSortCode]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseMessageEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseMessageEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseMessageEntity.FieldModifiedBy]);
            return this;
        }
    }
}
