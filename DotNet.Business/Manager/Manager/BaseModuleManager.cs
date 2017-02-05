//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseModuleManager
    /// 模块(菜单)类（程序OK）
    /// 
    /// 修改记录
    /// 
    ///     2008.05.19 版本：3.0 JiRiGaLa   将模块访问权限进行完善，按两种权限分配机制。
    ///     2007.12.05 版本：2.1 JiRiGaLa   整理主键、完善排序顺序功能。
    ///     2007.06.06 版本：2.0 JiRiGaLa   整理主键顺序，注释,规范主键。
    ///     2007.05.30 版本：1.3 JiRiGaLa   进行改进整理。
    ///     2006.06.01 版本：1.2 JiRiGaLa   添加了一个GetList()方法
    ///		2006.02.06 版本：1.2 JiRiGaLa   重新调整主键的规范化。
    ///		2004.05.18 版本：1.0 JiRiGaLa   改进表结构,添加表结构定义部分,优化菜单生成的方法
    ///		2003.12.29 版本：1.1 JiRiGaLa   改进成以后可以扩展到多种数据库的结构形式
    ///
    /// 版本：3.0
    /// 
    /// </summary>
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.05.19</date>
    /// </author>
    public partial class BaseModuleManager : BaseManager
    {
        #region public DataTable GetRootList()
        /// <summary>
        /// GetRoot 的主键
        /// </summary>
        /// <returns>数据表</returns>
        public DataTable GetRootList()
        {
            return this.GetDataTableByParent(string.Empty);
        }
        #endregion

        /// <summary>
        /// 获取用户有权限访问的模块主键
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <returns>主键数组</returns>
        public string[] GetIdsByUser(string userId)
        {
            // 公开的模块谁都可以访问
            string[] openModuleIds = null;

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldIsPublic, 1));
            parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldDeletionStateCode, 0));

            openModuleIds = this.GetIds(parameters);

            string[] twoModuleIds = null;

            if (!string.IsNullOrEmpty(userId))
            {
                // 按第一个解决方案进行计算 （用户 ---> 权限 --- 权限 <--- 菜单）
                // 获取用户的所有权限ID数组
                // BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo);
                // DataTable dtPermission = permissionManager.GetPermissionByUser(UserInfo.Id);
                // string[] permissionItemIds = BaseBusinessLogic.FieldToArray(dtPermission, BasePermissionItemEntity.FieldId);

                /*
                string[] oneModuleIds = new string[0];
                if ((permissionItemIds != null) && (permissionItemIds.Length > 0))
                {
                    // 获取所有跟这个权限有关联的模块ID数组
                    string sqlQuery = string.Empty;
                    sqlQuery = " SELECT " + BasePermissionEntity.FieldResourceId
                                + "   FROM " + BasePermissionEntity.TableName
                                + "  WHERE " + BasePermissionEntity.FieldResourceCategory + " = '" + BaseModuleEntity.TableName + "' "
                                + "        AND " + BasePermissionEntity.FieldPermissionItemId + " IN (" + BaseBusinessLogic.ObjectsToList(permissionItemIds) + ")";

                    dtPermission = DbHelper.Fill(sqlQuery);
                    oneModuleIds = BaseBusinessLogic.FieldToArray(dtPermission, BasePermissionEntity.FieldResourceId);
                }
                */

                // 按第二个解决方案进行计算 （用户 ---> 模块访问权限 ---> 菜单）
                string tableName = BasePermissionScopeEntity.TableName;
                if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
                {
                    tableName = BaseSystemInfo.SystemCode + "PermissionScope";
                }
                BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo, tableName);
                // 模块访问，连同用户本身的，还有角色的，全部获取出来
                string permissionItemCode = "Resource.AccessPermission";
                twoModuleIds = permissionScopeManager.GetResourceScopeIds(userId, BaseModuleEntity.TableName, permissionItemCode);

                // 这些模块是有效的才可以
                parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldId, twoModuleIds));
                parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldEnabled, 1));
                parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldDeletionStateCode, 0));
                twoModuleIds = this.GetProperties(parameters, BaseModuleEntity.FieldId);

                // 这里应该还缺少组织机构的模块权限，应该补上才对
            }
            // 返回相应的模块列表
            string[] moduleIds = StringUtil.Concat(openModuleIds, twoModuleIds);
            return moduleIds;
        }


        #region public DataTable GetDataTableByUser(string userId)
        /// <summary>
        /// 某个用户可以访问的所有菜单列表
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByUser(string userId)
        {
            string[] moduleIds = this.GetIdsByUser(userId);
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldId, moduleIds));
            parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldDeletionStateCode, 0));
            return this.GetDataTable(parameters, BaseModuleEntity.FieldSortCode);
        }
        #endregion

        /// <summary>
        /// 获得用户授权范围
        /// </summary>
        /// <param name="staffId">员工主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByPermission(string userId, string permissionItemScopeCode)
        {
            DataTable returnValue = new DataTable(this.CurrentTableName);
            //string[] names = null;
            //object[] values = null;

            // 这里需要判断,是系统权限？
            bool isRole = false;
            BaseUserManager userManager = new BaseUserManager(this.DbHelper, this.UserInfo);
            // 用户管理员
            isRole = userManager.IsInRoleByCode(userId, "UserAdmin");
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            if (isRole)
            {
                parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldCategory, "System"));
                parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldEnabled, 1));
                parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldDeletionStateCode, 0));

                returnValue = this.GetDataTable(parameters, BaseModuleEntity.FieldSortCode);
                returnValue.TableName = this.CurrentTableName;
                return returnValue;
            }

            // 这里需要判断,是业务权限？
            isRole = userManager.IsInRoleByCode(userId, "Admin");
            if (isRole)
            {
                parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldCategory, "Application"));
                parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldEnabled, 1));
                parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldDeletionStateCode, 0));
                returnValue = this.GetDataTable(parameters, BaseModuleEntity.FieldSortCode);
                returnValue.TableName = this.CurrentTableName;
                return returnValue;
            }

            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            string[] moduleIds = permissionScopeManager.GetTreeResourceScopeIds(userId, BaseModuleEntity.TableName, permissionItemScopeCode, true);
            // 有效的，未被删除的
            parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldId, moduleIds));
            parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldDeletionStateCode, 0));

            returnValue = this.GetDataTable(parameters, BaseModuleEntity.FieldSortCode);
            returnValue.TableName = this.CurrentTableName;
            return returnValue;
        }

        #region public string Add(string fullName)
        /// <summary>
        /// Add 添加的主键
        /// </summary>
        /// <param name="paramobject">对象</param>
        /// <returns>主键</returns>
        public string Add(string fullName)
        {
            string statusCode = string.Empty;
            BaseModuleEntity moduleEntity = new BaseModuleEntity();
            moduleEntity.FullName = fullName;
            return this.Add(moduleEntity, out statusCode);
        }
        #endregion

        #region public string Add(BaseModuleEntity moduleEntity, out string statusCode) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="moduleEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>返回</returns>
        public string Add(BaseModuleEntity moduleEntity, out string statusCode)
        {
            string returnValue = string.Empty;
            // 检查名称是否重复
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldCode, moduleEntity.Code));
            parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldFullName, moduleEntity.FullName));
            parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldDeletionStateCode, 0));

            if (this.Exists(parameters))
            {
                // 名称已重复
                statusCode = StatusCode.ErrorCodeExist.ToString();
            }
            else
            {
                returnValue = this.AddEntity(moduleEntity);
                // 运行成功
                statusCode = StatusCode.OKAdd.ToString();
            }
            return returnValue;
        }
        #endregion

        #region public int Update(BaseModuleEntity moduleEntity, out string statusCode) 更新
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="moduleEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>返回</returns>
        public int Update(BaseModuleEntity moduleEntity, out string statusCode)
        {
            int returnValue = 0;
            // 检查是否已被其他人修改            
            //if (DbLogic.IsModifed(DbHelper, BaseModuleEntity.TableName, moduleEntity.Id, moduleEntity.ModifiedUserId, moduleEntity.ModifiedOn))
            //{
            //    // 数据已经被修改
            //    statusCode = StatusCode.ErrorChanged.ToString();
            //}
            //else
            //{

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldCode, moduleEntity.Code));
            parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldFullName, moduleEntity.FullName));
            parameters.Add(new KeyValuePair<string, object>(BaseModuleEntity.FieldDeletionStateCode, 0));

            // 检查编号是否重复
            if ((moduleEntity.Code.Length > 0) && (this.Exists(parameters, moduleEntity.Id)))
            {
                // 编号已重复
                statusCode = StatusCode.ErrorCodeExist.ToString();
            }
            else
            {
                returnValue = this.UpdateEntity(moduleEntity);
                if (returnValue == 1)
                {
                    statusCode = StatusCode.OKUpdate.ToString();
                }
                else
                {
                    statusCode = StatusCode.ErrorDeleted.ToString();
                }
            }
            //}
            return returnValue;
        }
        #endregion

        #region public override int BatchSave(DataTable dataTable) 批量进行保存
        /// <summary>
        /// 批量进行保存
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        public override int BatchSave(DataTable dataTable)
        {
            int returnValue = 0;
            BaseModuleEntity moduleEntity = new BaseModuleEntity();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                // 删除状态
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    string id = dataRow[BaseModuleEntity.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        if (dataRow[BaseModuleEntity.FieldAllowDelete, DataRowVersion.Original].ToString().Equals("1"))
                        {
                            returnValue += this.DeleteEntity(id);
                        }
                    }
                }
                // 被修改过
                if (dataRow.RowState == DataRowState.Modified)
                {
                    string id = dataRow[BaseModuleEntity.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        moduleEntity.GetFrom(dataRow);
                        // 判断是否允许编辑
                        if (moduleEntity.AllowEdit == 1)
                        {
                            returnValue += this.UpdateEntity(moduleEntity);
                        }
                    }
                }
                // 添加状态
                if (dataRow.RowState == DataRowState.Added)
                {
                    moduleEntity.GetFrom(dataRow);
                    returnValue += this.AddEntity(moduleEntity).Length > 0 ? 1 : 0;
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
            this.ReturnStatusCode = StatusCode.OK.ToString();
            return returnValue;
        }
        #endregion

        #region public int ResetSortCode(string parentId) 重置排序码
        /// <summary>
        /// 重置排序码
        /// </summary>
        /// <param name="parentId">父节点主键</param>
        public int ResetSortCode(string parentId)
        {
            int returnValue = 0;
            DataTable dataTable = this.GetDataTableByParent(parentId);
            string id = string.Empty;
            BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper);
            string[] sortCode = sequenceManager.GetBatchSequence(BaseModuleEntity.TableName, dataTable.Rows.Count);
            int i = 0;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                id = dataRow[BaseModuleEntity.FieldId].ToString();
                returnValue += this.SetProperty(id, new KeyValuePair<string, object>(BaseModuleEntity.FieldSortCode, sortCode[i]));
                i++;
            }
            return returnValue;
        }
        #endregion
    }
}