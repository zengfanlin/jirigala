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
    /// BaseModuleEntity
    /// 模块（菜单）表
    /// 
    /// 修改纪录
    /// 
    /// 2012-05-22 版本：1.0 JiRiGaLa 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>JiRiGaLa</name>
    /// <date>2012-05-22</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class BaseModuleEntity : BaseEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 父节点主键
        /// </summary>
        public int? ParentId { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public String FullName { get; set; }

        /// <summary>
        /// 菜单分类System\Application
        /// </summary>
        public String Category { get; set; }

        /// <summary>
        /// 图标编号
        /// </summary>
        public String ImageIndex { get; set; }

        /// <summary>
        /// 选中状态图标编号
        /// </summary>
        public String SelectedImageIndex { get; set; }

        /// <summary>
        /// 导航地址(Web网址)[B\S]
        /// </summary>
        public String NavigateUrl { get; set; }

        /// <summary>
        /// 目标窗体中打开[B\S]
        /// </summary>
        public String Target { get; set; }

        /// <summary>
        /// 窗体名[C\S]
        /// </summary>
        public String FormName { get; set; }

        /// <summary>
        /// 动态连接库[C\S]
        /// </summary>
        public String AssemblyName { get; set; }

        /// <summary>
        /// 操作权限编号(数据权限范围)
        /// </summary>
        public String PermissionItemCode { get; set; }

        /// <summary>
        /// 需要数据权限过滤的表(,符号分割)
        /// </summary>
        public String PermissionScopeTables { get; set; }

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
        /// 是公开
        /// </summary>
        public int? IsPublic { get; set; }

        /// <summary>
        /// 展开状态
        /// </summary>
        public int? Expand { get; set; }

        /// <summary>
        /// 允许编辑
        /// </summary>
        public int? AllowEdit { get; set; }

        /// <summary>
        /// 允许删除
        /// </summary>
        public int? AllowDelete { get; set; }

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
        public BaseModuleEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseModuleEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseModuleEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseModuleEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseModuleEntity GetSingle(DataTable dataTable)
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
        public List<BaseModuleEntity>  GetList(DataTable dataTable)
        {
            List<BaseModuleEntity> entities=new List<BaseModuleEntity>();
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
        public BaseModuleEntity GetFrom(DataRow dataRow)
        {
this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToInt(dataRow[BaseModuleEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToInt(dataRow[BaseModuleEntity.FieldParentId]);
            this.Code = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldCode]);
            this.FullName = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldFullName]);
            this.Category = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldCategory]);
            this.ImageIndex = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldImageIndex]);
            this.SelectedImageIndex = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldSelectedImageIndex]);
            this.NavigateUrl = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldNavigateUrl]);
            this.Target = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldTarget]);
            this.FormName = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldFormName]);
            this.AssemblyName = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldAssemblyName]);
            this.PermissionItemCode = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldPermissionItemCode]);
            this.PermissionScopeTables = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldPermissionScopeTables]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseModuleEntity.FieldSortCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseModuleEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseModuleEntity.FieldDeletionStateCode]);
            this.IsPublic = BaseBusinessLogic.ConvertToInt(dataRow[BaseModuleEntity.FieldIsPublic]);
            this.Expand = BaseBusinessLogic.ConvertToInt(dataRow[BaseModuleEntity.FieldExpand]);
            this.AllowEdit = BaseBusinessLogic.ConvertToInt(dataRow[BaseModuleEntity.FieldAllowEdit]);
            this.AllowDelete = BaseBusinessLogic.ConvertToInt(dataRow[BaseModuleEntity.FieldAllowDelete]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseModuleEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseModuleEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseModuleEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseModuleEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader);;
            this.Id = BaseBusinessLogic.ConvertToInt(dataReader[BaseModuleEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToInt(dataReader[BaseModuleEntity.FieldParentId]);
            this.Code = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldCode]);
            this.FullName = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldFullName]);
            this.Category = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldCategory]);
            this.ImageIndex = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldImageIndex]);
            this.SelectedImageIndex = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldSelectedImageIndex]);
            this.NavigateUrl = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldNavigateUrl]);
            this.Target = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldTarget]);
            this.FormName = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldFormName]);
            this.AssemblyName = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldAssemblyName]);
            this.PermissionItemCode = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldPermissionItemCode]);
            this.PermissionScopeTables = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldPermissionScopeTables]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseModuleEntity.FieldSortCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseModuleEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseModuleEntity.FieldDeletionStateCode]);
            this.IsPublic = BaseBusinessLogic.ConvertToInt(dataReader[BaseModuleEntity.FieldIsPublic]);
            this.Expand = BaseBusinessLogic.ConvertToInt(dataReader[BaseModuleEntity.FieldExpand]);
            this.AllowEdit = BaseBusinessLogic.ConvertToInt(dataReader[BaseModuleEntity.FieldAllowEdit]);
            this.AllowDelete = BaseBusinessLogic.ConvertToInt(dataReader[BaseModuleEntity.FieldAllowDelete]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseModuleEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseModuleEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseModuleEntity.FieldModifiedBy]);
            return this;
        }
    }
}
