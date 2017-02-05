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
    /// BaseNewsEntity
    /// 新闻表
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
    public partial class BaseNewsEntity : BaseEntity
    {
        private string id = null;
        /// <summary>
        /// 代码
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

        private string folderId = null;
        /// <summary>
        /// 文件夹节点代码
        /// </summary>
        public string FolderId
        {
            get
            {
                return this.folderId;
            }
            set
            {
                this.folderId = value;
            }
        }

        /// <summary>
        /// 部门主键
        /// </summary>
        public String DepartmentId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public String DepartmentName { get; set; }

        private string categoryCode = null;
        /// <summary>
        /// 文件类别码
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

        private string code = null;
        /// <summary>
        /// 文件编号
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

        private string title = null;
        /// <summary>
        /// 文件名
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

        private string filePath = null;
        /// <summary>
        /// 文件路径
        /// </summary>
        public string FilePath
        {
            get
            {
                return this.filePath;
            }
            set
            {
                this.filePath = value;
            }
        }

        private string introduction = null;
        /// <summary>
        /// 内容简介
        /// </summary>
        public string Introduction
        {
            get
            {
                return this.introduction;
            }
            set
            {
                this.introduction = value;
            }
        }

        private string contents = null;
        /// <summary>
        /// 文件内容
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

        private string source = null;
        /// <summary>
        /// 新闻来源
        /// </summary>
        public string Source
        {
            get
            {
                return this.source;
            }
            set
            {
                this.source = value;
            }
        }

        private string keywords = null;
        /// <summary>
        /// 关键字
        /// </summary>
        public string Keywords
        {
            get
            {
                return this.keywords;
            }
            set
            {
                this.keywords = value;
            }
        }

        private int? fileSize = 0;
        /// <summary>
        /// 文件大小
        /// </summary>
        public int? FileSize
        {
            get
            {
                return this.fileSize;
            }
            set
            {
                this.fileSize = value;
            }
        }

        private string imageUrl = null;
        /// <summary>
        /// 图片文件位置(图片新闻)
        /// </summary>
        public string ImageUrl
        {
            get
            {
                return this.imageUrl;
            }
            set
            {
                this.imageUrl = value;
            }
        }

        private int? homePage = 0;
        /// <summary>
        /// 置首页
        /// </summary>
        public int? HomePage
        {
            get
            {
                return this.homePage;
            }
            set
            {
                this.homePage = value;
            }
        }

        private int? subPage = 0;
        /// <summary>
        /// 置二级页
        /// </summary>
        public int? SubPage
        {
            get
            {
                return this.subPage;
            }
            set
            {
                this.subPage = value;
            }
        }

        private string auditStatus = null;
        /// <summary>
        /// 审核状态
        /// </summary>
        public string AuditStatus
        {
            get
            {
                return this.auditStatus;
            }
            set
            {
                this.auditStatus = value;
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

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseNewsEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseNewsEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseNewsEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseNewsEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseNewsEntity GetSingle(DataTable dataTable)
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
        public List<BaseNewsEntity> GetList(DataTable dataTable)
        {
            List<BaseNewsEntity> entites = new List<BaseNewsEntity>();
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
        public virtual BaseNewsEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            Id = BaseBusinessLogic.ConvertToString(dataRow[BaseNewsEntity.FieldId]);
            DepartmentId = BaseBusinessLogic.ConvertToString(dataRow[BaseNewsEntity.FieldDepartmentId]);
            DepartmentName = BaseBusinessLogic.ConvertToString(dataRow[BaseNewsEntity.FieldDepartmentName]);
            FolderId = BaseBusinessLogic.ConvertToString(dataRow[BaseNewsEntity.FieldFolderId]);
            CategoryCode = BaseBusinessLogic.ConvertToString(dataRow[BaseNewsEntity.FieldCategoryCode]);
            Code = BaseBusinessLogic.ConvertToString(dataRow[BaseNewsEntity.FieldCode]);
            Title = BaseBusinessLogic.ConvertToString(dataRow[BaseNewsEntity.FieldTitle]);
            FilePath = BaseBusinessLogic.ConvertToString(dataRow[BaseNewsEntity.FieldFilePath]);
            Introduction = BaseBusinessLogic.ConvertToString(dataRow[BaseNewsEntity.FieldIntroduction]);
            Contents = BaseBusinessLogic.ConvertToString(dataRow[BaseNewsEntity.FieldContents]);
            Source = BaseBusinessLogic.ConvertToString(dataRow[BaseNewsEntity.FieldSource]);
            Keywords = BaseBusinessLogic.ConvertToString(dataRow[BaseNewsEntity.FieldKeywords]);
            FileSize = BaseBusinessLogic.ConvertToInt(dataRow[BaseNewsEntity.FieldFileSize]);
            ImageUrl = BaseBusinessLogic.ConvertToString(dataRow[BaseNewsEntity.FieldImageUrl]);
            SubPage = BaseBusinessLogic.ConvertToInt(dataRow[BaseNewsEntity.FieldSubPage]);
            HomePage = BaseBusinessLogic.ConvertToInt(dataRow[BaseNewsEntity.FieldHomePage]);
            AuditStatus = BaseBusinessLogic.ConvertToString(dataRow[BaseNewsEntity.FieldAuditStatus]);
            ReadCount = BaseBusinessLogic.ConvertToInt(dataRow[BaseNewsEntity.FieldReadCount]);
            DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseNewsEntity.FieldDeletionStateCode]);
            Description = BaseBusinessLogic.ConvertToString(dataRow[BaseNewsEntity.FieldDescription]);
            Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseNewsEntity.FieldEnabled]);
            SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseNewsEntity.FieldSortCode]);
            CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseNewsEntity.FieldCreateOn]);
            CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseNewsEntity.FieldCreateBy]);
            CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseNewsEntity.FieldCreateUserId]);
            ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseNewsEntity.FieldModifiedOn]);
            ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseNewsEntity.FieldModifiedBy]);
            ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseNewsEntity.FieldModifiedUserId]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public virtual BaseNewsEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader);
            Id = BaseBusinessLogic.ConvertToString(dataReader[BaseNewsEntity.FieldId]);
            FolderId = BaseBusinessLogic.ConvertToString(dataReader[BaseNewsEntity.FieldFolderId]);
            DepartmentId = BaseBusinessLogic.ConvertToString(dataReader[BaseNewsEntity.FieldDepartmentId]);
            DepartmentName = BaseBusinessLogic.ConvertToString(dataReader[BaseNewsEntity.FieldDepartmentName]);
            CategoryCode = BaseBusinessLogic.ConvertToString(dataReader[BaseNewsEntity.FieldCategoryCode]);
            Code = BaseBusinessLogic.ConvertToString(dataReader[BaseNewsEntity.FieldCode]);
            Title = BaseBusinessLogic.ConvertToString(dataReader[BaseNewsEntity.FieldTitle]);
            FilePath = BaseBusinessLogic.ConvertToString(dataReader[BaseNewsEntity.FieldFilePath]);
            Introduction = BaseBusinessLogic.ConvertToString(dataReader[BaseNewsEntity.FieldIntroduction]);
            Contents = BaseBusinessLogic.ConvertToString(dataReader[BaseNewsEntity.FieldContents]);
            Source = BaseBusinessLogic.ConvertToString(dataReader[BaseNewsEntity.FieldSource]);
            Keywords = BaseBusinessLogic.ConvertToString(dataReader[BaseNewsEntity.FieldKeywords]);
            FileSize = BaseBusinessLogic.ConvertToInt(dataReader[BaseNewsEntity.FieldFileSize]);
            ImageUrl = BaseBusinessLogic.ConvertToString(dataReader[BaseNewsEntity.FieldImageUrl]);
            SubPage = BaseBusinessLogic.ConvertToInt(dataReader[BaseNewsEntity.FieldSubPage]);
            HomePage = BaseBusinessLogic.ConvertToInt(dataReader[BaseNewsEntity.FieldHomePage]);
            AuditStatus = BaseBusinessLogic.ConvertToString(dataReader[BaseNewsEntity.FieldAuditStatus]);
            ReadCount = BaseBusinessLogic.ConvertToInt(dataReader[BaseNewsEntity.FieldReadCount]);
            DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseNewsEntity.FieldDeletionStateCode]);
            Description = BaseBusinessLogic.ConvertToString(dataReader[BaseNewsEntity.FieldDescription]);
            Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseNewsEntity.FieldEnabled]);
            SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseNewsEntity.FieldSortCode]);
            CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseNewsEntity.FieldCreateOn]);
            CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseNewsEntity.FieldCreateBy]);
            CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseNewsEntity.FieldCreateUserId]);
            ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseNewsEntity.FieldModifiedOn]);
            ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseNewsEntity.FieldModifiedBy]);
            ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseNewsEntity.FieldModifiedUserId]);
            return this;
        }
    }
}
