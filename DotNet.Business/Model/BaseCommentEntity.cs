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
    /// BaseCommentEntity
    /// 评论表
    /// 
    /// 修改纪录
    /// 
    /// 2012-05-14 版本：1.0 JiRiGaLa 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>JiRiGaLa</name>
    /// <date>2012-05-14</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class BaseCommentEntity : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public String Id { get; set; }

        /// <summary>
        /// 部门代码
        /// </summary>
        public string DepartmentId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public String DepartmentName { get; set; }

        /// <summary>
        /// 父亲节点主键
        /// </summary>
        public string ParentId { get; set; }

        /// <summary>
        /// 分类编号
        /// </summary>
        public String CategoryCode { get; set; }

        /// <summary>
        /// 唯一识别主键
        /// </summary>
        public String ObjectId { get; set; }

        /// <summary>
        /// 消息的指向网页页面
        /// </summary>
        public String TargetURL { get; set; }

        /// <summary>
        /// 主题
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public String Contents { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public String IPAddress { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public int? DeletionStateCode { get; set; }

        /// <summary>
        /// 有效
        /// </summary>
        public int? Enabled { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }

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
        public BaseCommentEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseCommentEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseCommentEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseCommentEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseCommentEntity GetSingle(DataTable dataTable)
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
        public List<BaseCommentEntity> GetList(DataTable dataTable)
        {
            List<BaseCommentEntity> entities = new List<BaseCommentEntity>();
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
        public BaseCommentEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldId]);
            this.DepartmentId = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldDepartmentId]);
            this.DepartmentName = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldDepartmentName]);
            this.ParentId = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldParentId]);
            this.CategoryCode = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldCategoryCode]);
            this.ObjectId = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldObjectId]);
            this.TargetURL = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldTargetURL]);
            this.Title = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldTitle]);
            this.Contents = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldContents]);
            this.IPAddress = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldIPAddress]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseCommentEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseCommentEntity.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldDescription]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseCommentEntity.FieldSortCode]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseCommentEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseCommentEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseCommentEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseCommentEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader); ;
            this.Id = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldId]);
            this.DepartmentId = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldDepartmentId]);
            this.DepartmentName = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldDepartmentName]);
            this.ParentId = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldParentId]);
            this.CategoryCode = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldCategoryCode]);
            this.ObjectId = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldObjectId]);
            this.TargetURL = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldTargetURL]);
            this.Title = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldTitle]);
            this.Contents = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldContents]);
            this.IPAddress = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldIPAddress]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseCommentEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseCommentEntity.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldDescription]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseCommentEntity.FieldSortCode]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseCommentEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseCommentEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseCommentEntity.FieldModifiedBy]);
            return this;
        }
    }
}
