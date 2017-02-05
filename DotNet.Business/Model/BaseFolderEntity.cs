//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseFolderEntity
    /// 文件夹表
    /// 
    /// 修改纪录
    /// 
    /// 2012-05-17 版本：1.1 Serwif 补充完整AllowEdit,AllowDelete
    /// 2012-05-17 版本：1.0 JiRiGaLa 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>JiRiGaLa</name>
    /// <date>2012-05-17</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class BaseFolderEntity : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public String Id { get; set; }

        /// <summary>
        /// 父亲节点主键
        /// </summary>
        public String ParentId { get; set; }

        /// <summary>
        /// 文件夹名
        /// </summary>
        public String FolderName { get; set; }

        /// <summary>
        /// 状态码
        /// </summary>
        public String StateCode { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }

        public int? allowEdit = 1;
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

        public int? allowDelete = 1;
        /// <summary>
        /// 描述
        /// </summary>
        public int? AllowDelete {
            get {
                return this.allowDelete;
            }
            set { this.allowDelete = value; }
        }

        /// <summary>
        /// 是公开
        /// </summary>
        public int? IsPublic { get; set; }

        /// <summary>
        /// 有效
        /// </summary>
        public int? Enabled { get; set; }

        private int? deletionStateCode = 0;
        /// <summary>
        /// 删除状态
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

        /// <summary>
        /// 描述
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateOn { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        public String CreateUserId { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public String CreateBy { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// 修改用户主键
        /// </summary>
        public String ModifiedUserId { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        public String ModifiedBy { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseFolderEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseFolderEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseFolderEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseFolderEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseFolderEntity GetSingle(DataTable dataTable)
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
        public List<BaseFolderEntity> GetList(DataTable dataTable)
        {
            List<BaseFolderEntity> entities = new List<BaseFolderEntity>();
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
        public BaseFolderEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[BaseFolderEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToString(dataRow[BaseFolderEntity.FieldParentId]);
            this.FolderName = BaseBusinessLogic.ConvertToString(dataRow[BaseFolderEntity.FieldFolderName]);
            this.StateCode = BaseBusinessLogic.ConvertToString(dataRow[BaseFolderEntity.FieldStateCode]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseFolderEntity.FieldSortCode]);
            this.AllowEdit = BaseBusinessLogic.ConvertToInt(dataRow[BaseFolderEntity.FieldAllowEdit]);
            this.AllowDelete = BaseBusinessLogic.ConvertToInt(dataRow[BaseFolderEntity.FieldAllowDelete]);
            this.IsPublic = BaseBusinessLogic.ConvertToInt(dataRow[BaseFolderEntity.FieldIsPublic]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseFolderEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseFolderEntity.FieldDeletionStateCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseFolderEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseFolderEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseFolderEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseFolderEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseFolderEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseFolderEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseFolderEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseFolderEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader); ;
            this.Id = BaseBusinessLogic.ConvertToString(dataReader[BaseFolderEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToString(dataReader[BaseFolderEntity.FieldParentId]);
            this.FolderName = BaseBusinessLogic.ConvertToString(dataReader[BaseFolderEntity.FieldFolderName]);
            this.StateCode = BaseBusinessLogic.ConvertToString(dataReader[BaseFolderEntity.FieldStateCode]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseFolderEntity.FieldSortCode]);
            this.AllowEdit = BaseBusinessLogic.ConvertToInt(dataReader[BaseFolderEntity.FieldAllowEdit]);
            this.AllowDelete = BaseBusinessLogic.ConvertToInt(dataReader[BaseFolderEntity.FieldAllowDelete]);
            this.IsPublic = BaseBusinessLogic.ConvertToInt(dataReader[BaseFolderEntity.FieldIsPublic]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseFolderEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseFolderEntity.FieldDeletionStateCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseFolderEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseFolderEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseFolderEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseFolderEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseFolderEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseFolderEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseFolderEntity.FieldModifiedBy]);
            return this;
        }
    }
}
