//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
	/// BaseItemDetailsManager 
    /// 主键管理表结构定义部分（程序OK）
    ///
	/// 注意事项;
	///		ID 为主键
	///		CreateOn不为空，默认值
	///		ParentId、FullName 需要建立唯一索引
	///		CategoryId 是为了解决多重数据库兼容的问题
	///		ParentId 是为了解决形成树行结构的问题
	///
	/// 修改记录
    ///
    ///     2011.03.29 版本：4.5 JiRiGaLa  允许重复的名称，但是不允许编号和名称都重复。
    ///     2009.07.01 版本：4.4 JiRiGaLa  按某种权限获取主键列表。
    ///     2007.12.03 版本：4.3 JiRiGaLa  进行规范化整理。
    ///     2007.06.03 版本：4.2 JiRiGaLa  进行改进整理。
    ///     2007.05.31 版本：4.1 JiRiGaLa  进行改进整理。
    ///		2007.01.15 版本：4.0 JiRiGaLa  重新整理主键。
    ///		2007.01.03 版本：3.0 JiRiGaLa  进行大批量主键整理。
    ///		2006.12.05 版本：2.0 JiRiGaLa  GetFullName 方法更新。
	///		2006.01.23 版本：1.0 JiRiGaLa  获取ItemDetails方法的改进。
	///		2004.11.12 版本：1.0 JiRiGaLa  主键进行了绝对的优化，基本上看上去还过得去了。
    ///     2007.12.03 版本：2.2 JiRiGaLa  进行规范化整理。
    ///     2007.05.30 版本：2.1 JiRiGaLa  整理主键，调整GetFrom()方法,增加AddEntity(),UpdateEntity(),DeleteEntity()
    ///		2007.01.15 版本：2.0 JiRiGaLa  重新整理主键。
	///		2006.02.06 版本：1.1 JiRiGaLa  重新调整主键的规范化。
	///		2005.10.03 版本：1.0 JiRiGaLa  表中添加是否可删除，可修改字段。
	///
	/// 版本：2.2
	/// </summary>
	/// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.12.03</date>
	/// </author>
	/// </summary>
    public partial class BaseItemDetailsManager : BaseManager //, IBaseItemDetailsManager
    {
        public BaseItemDetailsManager(IDbHelper dbHelper, string tableName)
            : this(dbHelper)
        {
            CurrentTableName = tableName;
        }

        #region public string Add(BaseItemDetailsEntity itemDetailsEntity, out string statusCode) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="itemDetailsEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>主键</returns>
        public string Add(BaseItemDetailsEntity itemDetailsEntity, out string statusCode)
        {
            string returnValue = string.Empty;
            // 检查编号是否重复
            //if (!String.IsNullOrEmpty(itemDetailsEntity.ItemCode))
            //{
            //    if (this.Exists(BaseItemDetailsEntity.FieldItemCode, itemDetailsEntity.ItemCode))
            //    {
            //        // 编号已重复
            //        statusCode = StatusCode.ErrorCodeExist.ToString();
            //        return returnValue;
            //    }
            //}
            //if (!String.IsNullOrEmpty(itemDetailsEntity.ItemName))
            //{
            //    // 检查名称是否重复
            //    if (this.Exists(BaseItemDetailsEntity.FieldItemName, itemDetailsEntity.ItemName))
            //    {
            //        // 名称已重复
            //        statusCode = StatusCode.ErrorFullNameExist.ToString();
            //        return returnValue;
            //    }
            //}

            //if (!String.IsNullOrEmpty(itemDetailsEntity.ItemValue))
            //{
            //    // 检查值是否重复
            //    if (this.Exists(BaseItemDetailsEntity.FieldItemValue, itemDetailsEntity.ItemValue))
            //    {
            //        // 值已重复
            //        statusCode = StatusCode.ErrorValueExist.ToString();
            //        return returnValue;
            //    }
            //}

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldItemCode, itemDetailsEntity.ItemCode));
            parameters.Add(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldItemName, itemDetailsEntity.ItemName));
            parameters.Add(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldDeletionStateCode, 0));

            if (this.Exists(parameters))
            {
                // 名称已重复
                statusCode = StatusCode.Exist.ToString();
                return returnValue;
            }
            // 运行成功
            returnValue = this.AddEntity(itemDetailsEntity);
            statusCode = StatusCode.OKAdd.ToString();
            return returnValue;
        }
        #endregion

        #region public int Update(BaseItemDetailsEntity itemDetailsEntity, out string statusCode) 更新
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="itemDetailsEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>影响行数</returns>
        public int Update(BaseItemDetailsEntity itemDetailsEntity, out string statusCode)
        {
            int returnValue = 0;
            // 检查是否已被其他人修改            
            //if (DbLogic.IsModifed(DbHelper, this.CurrentTableName, itemDetailsEntity.Id, itemDetailsEntity.ModifiedUserId, itemDetailsEntity.ModifiedOn))
            //{
            //    // 数据已经被修改
            //    statusCode = StatusCode.ErrorChanged.ToString();
            //}
            // 检查编号是否重复
            // if (this.Exists(BaseItemDetailsEntity.FieldItemCode, itemDetailsEntity.ItemCode, itemDetailsEntity.Id))
            // if (this.Exists(BaseItemDetailsEntity.FieldItemValue, itemDetailsEntity.ItemValue, itemDetailsEntity.Id))
            // 检查名称是否重复

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldItemCode, itemDetailsEntity.ItemCode));
            parameters.Add(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldItemName, itemDetailsEntity.ItemName));
            parameters.Add(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldDeletionStateCode, 0));

            if (this.Exists(parameters, itemDetailsEntity.Id))
            {
                // 名称已重复
                statusCode = StatusCode.Exist.ToString();
                return returnValue;
            }
            returnValue = this.UpdateEntity(itemDetailsEntity);
            if (returnValue == 1)
            {
                statusCode = StatusCode.OKUpdate.ToString();
            }
            else
            {
                statusCode = StatusCode.ErrorDeleted.ToString();
            }
            return returnValue;
        }
        #endregion

        #region public int BatchSave(DataTable dataTable) 批量进行保存
        /// <summary>
        /// 批量进行保存
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        public override int BatchSave(DataTable dataTable)
        {
            int returnValue = 0;
            BaseItemDetailsEntity itemDetailsEntity = new BaseItemDetailsEntity();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                // 删除状态
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    string id = dataRow[BaseItemDetailsEntity.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        if (itemDetailsEntity.AllowDelete == 1)
                        {
                            returnValue += this.Delete(id);
                        }
                    }
                }
                // 被修改过
                if (dataRow.RowState == DataRowState.Modified)
                {
                    string id = dataRow[BaseItemDetailsEntity.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        itemDetailsEntity.GetFrom(dataRow);
                        // 判断是否允许编辑
                        if (itemDetailsEntity.AllowEdit == 1)
                        {
                            returnValue += this.UpdateEntity(itemDetailsEntity);
                        }
                        else
                        {
                            // 不允许编辑，但是排序还是允许的
                            returnValue += this.SetProperty(id, new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldSortCode, itemDetailsEntity.SortCode));
                        }
                    }
                }
                // 添加状态
                if (dataRow.RowState == DataRowState.Added)
                {
                    itemDetailsEntity.GetFrom(dataRow);
                    returnValue += this.AddEntity(itemDetailsEntity).Length > 0 ? 1 : 0;
                }
                if (dataRow.RowState == DataRowState.Unchanged)
                {
                    continue;
                }
                if (dataRow.RowState == DataRowState.Detached)
                {
                    continue;
                }
            }
            return returnValue;
        }
        #endregion

        #region public DataTable GetDataTableByPermission(string userId, string resourceCategory, string permissionItemCode) 按某种权限获取主键列表
        /// <summary>
        /// 按某种权限获取主键列表
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByPermission(string userId, string resourceCategory, string permissionItemCode = "Resource.ManagePermission")
        {
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            string[] ids = permissionScopeManager.GetResourceScopeIds(userId, resourceCategory, permissionItemCode);
            DataTable dataTable = this.GetDataTable(ids);
            dataTable.DefaultView.Sort = BaseItemDetailsEntity.FieldSortCode;
            return dataTable;
        }
        #endregion
    }
}