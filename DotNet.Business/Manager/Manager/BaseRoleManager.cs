//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseRoleManager 
    /// 角色表结构定义部分
    ///
    /// 修改记录
    ///
    ///     2008.04.09 版本：1.0 JiRiGaLa 创建主键。
    ///     
    /// 
    /// 版本：1.0
    /// </summary>
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.09</date>
    /// </author>
    /// </summary>
    public partial class BaseRoleManager : BaseManager //, IBaseRoleManager
    {
        #region public DataTable GetDataTableBySystem(string systemId) 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="systemId">系统主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableBySystem(string systemId)
        {
            List<KeyValuePair<string, object>> parametersList = new List<KeyValuePair<string, object>>();
            parametersList.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldSystemId, systemId));
            parametersList.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldDeletionStateCode, 0));
            return this.GetDataTable(parametersList, BaseRoleEntity.FieldSortCode);
            
            /*
            string sqlQuery = " SELECT " + BaseRoleEntity.TableName + ".*,"
                            + " (SELECT COUNT(*) FROM " + BaseUserRoleEntity.TableName + " WHERE (Enabled = 1) AND (RoleId = " + BaseRoleEntity.TableName + ".Id)) AS UserCount "
                            + " FROM " + BaseRoleEntity.TableName
                            + " WHERE " + BaseRoleEntity.FieldSystemId + " = " + "'" + systemId + "'"
                            + " ORDER BY " + BaseRoleEntity.FieldSortCode;
            return DbHelper.Fill(sqlQuery);
            */
        }
        #endregion

        #region public DataTable GetDataTableByOrganize(string systemId) 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByOrganize(string organizeId)
        {
            List<KeyValuePair<string, object>> parametersList = new List<KeyValuePair<string, object>>();
            parametersList.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldOrganizeId, organizeId));
            parametersList.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldDeletionStateCode, 0));
            return this.GetDataTable(parametersList, BaseRoleEntity.FieldSortCode);
            /*
            string sqlQuery = " SELECT " + BaseRoleEntity.TableName + ".*,"
                            + " (SELECT COUNT(*) FROM " + BaseUserRoleEntity.TableName + " WHERE (Enabled = 1) AND (RoleId = " + BaseRoleEntity.TableName + ".Id)) AS UserCount "
                            + " FROM " + BaseRoleEntity.TableName
                            + " WHERE " + BaseRoleEntity.FieldSystemId + " = " + "'" + systemId + "'"
                            + " ORDER BY " + BaseRoleEntity.FieldSortCode;
            return DbHelper.Fill(sqlQuery);
            */
        }
        #endregion

        #region public DataTable GetDataTableByOrganize(string systemId) 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByName(string RoleName)
        {
            List<KeyValuePair<string, object>> parametersList = new List<KeyValuePair<string, object>>();
            parametersList.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldRealName, RoleName));
            parametersList.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldDeletionStateCode, 0));
            return this.GetDataTable(parametersList, BaseRoleEntity.FieldSortCode);
        }
        #endregion

        #region public DataTable Search(string systemId, string searchValue,string categoryCode=null) 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="systemId">系统主键</param>
        /// <param name="search">查询字符串</param>
        /// <returns>数据表</returns>
        public DataTable Search(string systemId, string searchValue,string categoryCode=null)
        {
            string sqlQuery = null;
            //if (String.IsNullOrEmpty(searchValue))
            //{
            //    if (String.IsNullOrEmpty(systemId))
            //    {
            //        return this.GetDataTable();
            //    }
            //    else
            //    {
            //        return this.GetDataTableBySystem(systemId);
            //    }
            //}
            //string sqlQuery = " SELECT " + BaseRoleEntity.TableName + ".*,"
            //                + " (SELECT COUNT(*) FROM " + BaseUserRoleEntity.TableName + " WHERE (Enabled = 1) AND (RoleId = " + BaseRoleEntity.TableName + ".Id)) AS StaffCount "
            //                + " FROM " + BaseRoleEntity.TableName
            //                + " WHERE (" + BaseRoleEntity.TableName + "." + BaseRoleEntity.FieldRealName + " LIKE '" + searchValue + "'"
            //                + " OR " + BaseRoleEntity.TableName + "." + BaseRoleEntity.FieldDescription + " LIKE '" + searchValue + "')";
            sqlQuery += " SELECT * FROM "+ BaseRoleEntity.TableName + " WHERE " + BaseRoleEntity.FieldDeletionStateCode + " = 0 ";

            if(!string.IsNullOrEmpty(searchValue))
            {
                searchValue = StringUtil.GetSearchString(searchValue);
                sqlQuery += "  AND (" + BaseRoleEntity.FieldRealName + " LIKE '" + searchValue + "'"
                            + " OR " + BaseRoleEntity.FieldDescription + " LIKE '" + searchValue + "')";
            }
            if (!String.IsNullOrEmpty(systemId))
            {
                sqlQuery += " AND " + BaseRoleEntity.FieldSystemId + " = '" + systemId + "'";
            }
            if (!String.IsNullOrEmpty(categoryCode))
            {
                sqlQuery += " AND " +  BaseRoleEntity.FieldCategoryCode + " = '" + categoryCode + "'";
            }
            sqlQuery += " ORDER BY " + BaseRoleEntity.FieldSortCode;
            return DbHelper.Fill(sqlQuery);
        }
        #endregion

        #region public string Add(BaseRoleEntity roleEntity, out string statusCode) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="roleEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>主键</returns>
        public string Add(BaseRoleEntity roleEntity, out string statusCode)
        {
            string returnValue = string.Empty;
            // 检查名称是否重复
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldSystemId, roleEntity.SystemId));
            parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldRealName, roleEntity.RealName));
            parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldDeletionStateCode, 0));

            if (this.Exists(parameters))
            {
                // 名称是否重复
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                returnValue = this.AddEntity(roleEntity);
                // 运行成功
                statusCode = StatusCode.OKAdd.ToString();
            }
            return returnValue;
        }
        #endregion

        #region public int Update(BaseRoleEntity roleEntity, out string statusCode) 更新
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="roleEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>影响行数</returns>
        public int Update(BaseRoleEntity roleEntity, out string statusCode)
        {
            int returnValue = 0;
            // 检查是否已被其他人修改
            
            if (DbLogic.IsModifed(DbHelper, this.CurrentTableName, roleEntity.Id, roleEntity.ModifiedUserId, roleEntity.ModifiedOn))
            {
                // 数据已经被修改
                statusCode = StatusCode.ErrorChanged.ToString();
            }
            else
            {
                // 检查名称是否重复
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldSystemId, roleEntity.SystemId));
                parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldRealName, roleEntity.RealName));
                parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldDeletionStateCode, 0));
                if (this.Exists(parameters, roleEntity.Id))
                {
                    // 名称已重复
                    statusCode = StatusCode.ErrorNameExist.ToString();
                }
                else
                {
                    returnValue = this.UpdateEntity(roleEntity);
                    if (returnValue == 1)
                    {
                        statusCode = StatusCode.OKUpdate.ToString();
                    }
                    else
                    {
                        statusCode = StatusCode.ErrorDeleted.ToString();
                    }
                }
            }
            return returnValue;
        }
        #endregion

        #region public int Delete(string id) 删除
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            int returnValue = 0;
            // 删除角色权限结构定义
            // returnValue = DbLogic.Delete(DbHelper, BaseRoleModuleOperationTable.TableName, BaseRoleModuleOperationTable.FieldRoleId, id);
            // 删除员工角色表结构定义部分
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseUserRoleEntity.FieldRoleId, id));
            returnValue += DbLogic.Delete(DbHelper, BaseUserRoleEntity.TableName, parameters);
            // 删除角色的表结构定义部分
            parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldId, id));
            returnValue += DbLogic.Delete(DbHelper, BaseRoleEntity.TableName, parameters);
            return returnValue;
        }
        #endregion

        #region public int BatchDelete(string id) 批量删除
        /// <summary>
        /// 批量删除
        /// </summary>
        /// <param name="id">主键数组</param>
        /// <returns>影响行数</returns>
        public int BatchDelete(string[] ids)
        {
            int returnValue = 0;
            for (int i = 0; i < ids.Length; i++)
            {
                returnValue += this.Delete(ids[i]);
            }
            return returnValue;
        }
        #endregion

        #region public int MoveTo(string id, string targetOrganizeId) 移动
        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="targetSystemId">目标主键</param>
        /// <returns>影响行数</returns>
        public int MoveTo(string id, string targetSystemId)
        {
            return this.SetProperty(id, new KeyValuePair<string, object>(BaseRoleEntity.FieldSystemId, targetSystemId));
        }
        #endregion

        #region public int BatchMoveTo(string[] ids, string targetOrganizeId) 批量移动
        /// <summary>
        /// 批量移动
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <param name="targetOrganizeId">目标主键</param>
        /// <returns>影响行数</returns>
        public int BatchMoveTo(string[] ids, string targetOrganizeId)
        {
            int returnValue = 0;
            for (int i = 0; i < ids.Length; i++)
            {
                returnValue += this.MoveTo(ids[i], targetOrganizeId);
            }
            return returnValue;
        }
        #endregion

        #region public int BatchSave(List<BaseRoleEntity> roleEntites) 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        public int BatchSave(List<BaseRoleEntity> roleEntites)
        {
            /*
            foreach (BaseRoleEntity roleEntity in roleEntites)
            {
                // 删除状态
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    string id = dataRow[BaseRoleEntity.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        returnValue += this.Delete(id);
                    }
                }
                // 被修改过
                if (dataRow.RowState == DataRowState.Modified)
                {
                    string id = dataRow[BaseRoleEntity.FieldId, DataRowVersion.Original].ToString();
                    if (!String.IsNullOrEmpty(id))
                    {
                        roleEntity.GetFrom(dataRow);
                        returnValue += this.UpdateEntity(roleEntity);
                    }
                }
                // 添加状态
                if (dataRow.RowState == DataRowState.Added)
                {
                    roleEntity.GetFrom(dataRow);
                    returnValue += this.AddEntity(roleEntity).Length > 0 ? 1 : 0;
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
            */

            int returnValue = 0;
            foreach (BaseRoleEntity roleEntity in roleEntites)
            {
                returnValue += this.UpdateEntity(roleEntity);
            }
            return returnValue;
        }
        #endregion

        #region public int ResetSortCode(string systemId) 重置排序码
        /// <summary>
        /// 重置排序码
        /// </summary>
        /// <param name="systemId">系统主键</param>
        public int ResetSortCode(string systemId)
        {
            int returnValue = 0;
            DataTable dataTable = this.GetDataTableBySystem(systemId);
            string id = string.Empty;
            BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper);
            string[] sortCode = sequenceManager.GetBatchSequence(BaseRoleEntity.TableName, dataTable.Rows.Count);
            int i = 0;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                id = dataRow[BaseRoleEntity.FieldId].ToString();
                returnValue += this.SetProperty(id, new KeyValuePair<string, object>(BaseRoleEntity.FieldSortCode, sortCode[i]));
                i++;
            }
            return returnValue;
        }
        #endregion

        #region public DataTable GetDataTableByPage(string userId, string bugCategory, string serviceState, string searchValue, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = null, string sortDire = null)

       /// <summary>
       /// 分页查询
       /// </summary>
       /// <param name="userInfo"></param>
       /// <param name="categoryCode">分类编码</param>
        /// <param name="searchValue">查询字段</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDire">排序方向</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByPage(BaseUserInfo userInfo, string categoryCode, string searchValue, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = null, string sortDire = null)
        {
            string whereConditional = BaseRoleEntity.FieldDeletionStateCode + " = 0 ";

            if (!string.IsNullOrEmpty(categoryCode))
            {
                whereConditional += " AND " + BaseRoleEntity.FieldCategoryCode + " = '" + categoryCode + "'";
            }

            if (!string.IsNullOrEmpty(searchValue))
            {
                searchValue = "'"+StringUtil.GetSearchString(searchValue)+"'";
                whereConditional += " AND (" + BaseRoleEntity.FieldRealName + " LIKE " + searchValue;
                whereConditional += " OR " + BaseRoleEntity.FieldCategoryCode + " LIKE " + searchValue;
                whereConditional += " OR " + BaseRoleEntity.FieldCode + " LIKE " + searchValue+ ")";
            }
            return GetDataTableByPage(out recordCount, pageIndex, pageSize, sortExpression, sortDire, this.CurrentTableName, whereConditional, "*");
        }
        #endregion
    }
}
