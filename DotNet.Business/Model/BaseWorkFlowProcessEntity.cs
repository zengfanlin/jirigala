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
    /// BaseWorkFlowProcessEntity
    /// 工作流定义
    ///
    /// 修改纪录
    ///
    ///		2012-04-09 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012-04-09</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class BaseWorkFlowProcessEntity : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 用户主键
        /// </summary>
        public String UserId { get; set; }

        /// <summary>
        /// 组织机构主键
        /// </summary>
        public String OrganizeId { get; set; }

        /// <summary>
        /// 模版单据主键
        /// </summary>
        public String BillTemplateId { get; set; }

        /// <summary>
        /// 审核类型（按用户，按部门，按单据）
        /// </summary>
        public String AuditCategoryCode { get; set; }

        /// <summary>
        /// 反射回调类,工作流回写数据库,通过接口定义调用类的方法等
        /// </summary>
        public String CallBackClass { get; set; }

        /// <summary>
        /// 回写表
        /// </summary>
        public String CallBackTable { get; set; }

        /// <summary>
        /// 分类主键
        /// </summary>
        public String CategoryCode { get; set; }

        /// <summary>
        /// 流程编号
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        /// 流程名称
        /// </summary>
        public String FullName { get; set; }

        /// <summary>
        /// 流程内容
        /// </summary>
        public String Contents { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }

        /// <summary>
        /// 有效
        /// </summary>
        public int? Enabled { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public int? DeletionStateCode { get; set; }

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
        public BaseWorkFlowProcessEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseWorkFlowProcessEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseWorkFlowProcessEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseWorkFlowProcessEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseWorkFlowProcessEntity GetSingle(DataTable dataTable)
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
        public List<BaseWorkFlowProcessEntity> GetList(DataTable dataTable)
        {
            List<BaseWorkFlowProcessEntity> entities = new List<BaseWorkFlowProcessEntity>();
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
        public BaseWorkFlowProcessEntity GetFrom(DataRow dataRow)
        {
            this.Id = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowProcessEntity.FieldId]);
            this.UserId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowProcessEntity.FieldUserId]);
            this.OrganizeId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowProcessEntity.FieldOrganizeId]);
            this.BillTemplateId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowProcessEntity.FieldBillTemplateId]);
            this.AuditCategoryCode = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowProcessEntity.FieldAuditCategoryCode]);
            this.CallBackClass = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowProcessEntity.FieldCallBackClass]);
            this.CallBackTable = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowProcessEntity.FieldCallBackTable]);
            this.CategoryCode = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowProcessEntity.FieldCategoryCode]);
            this.Code = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowProcessEntity.FieldCode]);
            this.FullName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowProcessEntity.FieldFullName]);
            this.Contents = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowProcessEntity.FieldContents]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowProcessEntity.FieldSortCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowProcessEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowProcessEntity.FieldDeletionStateCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowProcessEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseWorkFlowProcessEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowProcessEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowProcessEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseWorkFlowProcessEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowProcessEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowProcessEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseWorkFlowProcessEntity GetFrom(IDataReader dataReader)
        {
            this.Id = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowProcessEntity.FieldId]);
            this.UserId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowProcessEntity.FieldUserId]);
            this.OrganizeId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowProcessEntity.FieldOrganizeId]);
            this.BillTemplateId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowProcessEntity.FieldBillTemplateId]);
            this.AuditCategoryCode = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowProcessEntity.FieldAuditCategoryCode]);
            this.CallBackClass = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowProcessEntity.FieldCallBackClass]);
            this.CallBackTable = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowProcessEntity.FieldCallBackTable]);
            this.CategoryCode = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowProcessEntity.FieldCategoryCode]);
            this.Code = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowProcessEntity.FieldCode]);
            this.FullName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowProcessEntity.FieldFullName]);
            this.Contents = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowProcessEntity.FieldContents]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowProcessEntity.FieldSortCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowProcessEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowProcessEntity.FieldDeletionStateCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowProcessEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseWorkFlowProcessEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowProcessEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowProcessEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseWorkFlowProcessEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowProcessEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowProcessEntity.FieldModifiedBy]);
            return this;
        }
    }
}
