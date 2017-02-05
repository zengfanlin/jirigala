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
    /// BaseWorkFlowBillTemplateEntity
    /// 工作流模板表
    /// 
    /// 修改纪录
    /// 
    /// 2012-05-18 版本：1.0 JiRiGaLa 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>JiRiGaLa</name>
    /// <date>2012-05-18</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class BaseWorkFlowBillTemplateEntity : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public String Id { get; set; }

        /// <summary>
        /// 模版标题
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// 模版编号
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        /// 模版分类
        /// </summary>
        public String CategoryCode { get; set; }

        /// <summary>
        /// 标准流程
        /// </summary>
        public String Introduction { get; set; }

        /// <summary>
        /// 文件内容
        /// </summary>
        public String Contents { get; set; }

        /// <summary>
        /// 模版类型
        /// </summary>
        public String TemplateType { get; set; }

        /// <summary>
        /// 流转审批
        /// </summary>
        public int? UseWorkFlow { get; set; }

        /// <summary>
        /// 添加页面
        /// </summary>
        public String AddPage { get; set; }

        /// <summary>
        /// 编辑页面
        /// </summary>
        public String EditPage { get; set; }

        /// <summary>
        /// 显示页面
        /// </summary>
        public String ShowPage { get; set; }

        /// <summary>
        /// 列表页面
        /// </summary>
        public String ListPage { get; set; }

        /// <summary>
        /// 管理页面
        /// </summary>
        public String AdminPage { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public String AuditStatus { get; set; }

        /// <summary>
        /// 删除标志
        /// </summary>
        public int? DeletionStateCode { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// 有效
        /// </summary>
        public int? Enabled { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateOn { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public String CreateBy { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        public String CreateUserId { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        public String ModifiedBy { get; set; }

        /// <summary>
        /// 修改用户主键
        /// </summary>
        public String ModifiedUserId { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseWorkFlowBillTemplateEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseWorkFlowBillTemplateEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseWorkFlowBillTemplateEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseWorkFlowBillTemplateEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseWorkFlowBillTemplateEntity GetSingle(DataTable dataTable)
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
        public List<BaseWorkFlowBillTemplateEntity>  GetList(DataTable dataTable)
        {
            List<BaseWorkFlowBillTemplateEntity> entities=new List<BaseWorkFlowBillTemplateEntity>();
            foreach(DataRow dataRow in dataTable.Rows)
            {
                entities.Add(GetFrom(dataRow));
            }
            return entities;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseWorkFlowBillTemplateEntity GetFrom(DataRow dataRow)
        {
this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowBillTemplateEntity.FieldId]);
            this.Title = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowBillTemplateEntity.FieldTitle]);
            this.Code = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowBillTemplateEntity.FieldCode]);
            this.CategoryCode = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowBillTemplateEntity.FieldCategoryCode]);
            this.Introduction = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowBillTemplateEntity.FieldIntroduction]);
            this.Contents = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowBillTemplateEntity.FieldContents]);
            this.TemplateType = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowBillTemplateEntity.FieldTemplateType]);
            this.UseWorkFlow = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowBillTemplateEntity.FieldUseWorkFlow]);
            this.AddPage = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowBillTemplateEntity.FieldAddPage]);
            this.EditPage = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowBillTemplateEntity.FieldEditPage]);
            this.ShowPage = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowBillTemplateEntity.FieldShowPage]);
            this.ListPage = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowBillTemplateEntity.FieldListPage]);
            this.AdminPage = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowBillTemplateEntity.FieldAdminPage]);
            this.AuditStatus = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowBillTemplateEntity.FieldAuditStatus]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowBillTemplateEntity.FieldDeletionStateCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowBillTemplateEntity.FieldDescription]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowBillTemplateEntity.FieldEnabled]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowBillTemplateEntity.FieldSortCode]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseWorkFlowBillTemplateEntity.FieldCreateOn]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowBillTemplateEntity.FieldCreateBy]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowBillTemplateEntity.FieldCreateUserId]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseWorkFlowBillTemplateEntity.FieldModifiedOn]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowBillTemplateEntity.FieldModifiedBy]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowBillTemplateEntity.FieldModifiedUserId]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseWorkFlowBillTemplateEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader);;
            this.Id = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowBillTemplateEntity.FieldId]);
            this.Title = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowBillTemplateEntity.FieldTitle]);
            this.Code = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowBillTemplateEntity.FieldCode]);
            this.CategoryCode = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowBillTemplateEntity.FieldCategoryCode]);
            this.Introduction = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowBillTemplateEntity.FieldIntroduction]);
            this.Contents = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowBillTemplateEntity.FieldContents]);
            this.TemplateType = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowBillTemplateEntity.FieldTemplateType]);
            this.UseWorkFlow = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowBillTemplateEntity.FieldUseWorkFlow]);
            this.AddPage = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowBillTemplateEntity.FieldAddPage]);
            this.EditPage = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowBillTemplateEntity.FieldEditPage]);
            this.ShowPage = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowBillTemplateEntity.FieldShowPage]);
            this.ListPage = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowBillTemplateEntity.FieldListPage]);
            this.AdminPage = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowBillTemplateEntity.FieldAdminPage]);
            this.AuditStatus = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowBillTemplateEntity.FieldAuditStatus]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowBillTemplateEntity.FieldDeletionStateCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowBillTemplateEntity.FieldDescription]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowBillTemplateEntity.FieldEnabled]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowBillTemplateEntity.FieldSortCode]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseWorkFlowBillTemplateEntity.FieldCreateOn]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowBillTemplateEntity.FieldCreateBy]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowBillTemplateEntity.FieldCreateUserId]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseWorkFlowBillTemplateEntity.FieldModifiedOn]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowBillTemplateEntity.FieldModifiedBy]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowBillTemplateEntity.FieldModifiedUserId]);
            return this;
        }
    }
}
