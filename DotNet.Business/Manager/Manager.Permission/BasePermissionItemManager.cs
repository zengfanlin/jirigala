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
    /// BasePermissionItemManager
    /// 基本权限（程序OK）
    /// 
    /// 修改纪录
    ///
    ///     2008.05.09 版本：2.9 JiRiGaLa 命名为 BaseOperationManager 整理优化主键。
    ///     2007.11.30 版本：2.8 JiRiGaLa 命名为 BUBasePermission 整理优化主键，删除 Instance 属性。
    ///     2007.11.08 版本：2.7 JiRiGaLa 整理多余的主键（OK）。
    ///	    2007.07.24 版本：2.6 JiRiGaLa 改进 Instance 方法。
    ///	    2007.07.19 版本：2.5 JiRiGaLa BatchDelete 命名规范化。
    ///	    2007.05.29 版本：2.4 JiRiGaLa ErrorDeleted，ErrorChanged 状态进行改进整理。
    ///	    2007.05.26 版本：2.3 JiRiGaLa BatchSave，ErrorDataRelated，force 进行改进整理。
    ///	    2007.05.23 版本：2.2 JiRiGaLa ReturnStatusCode，ReturnStatusMessage 进行改进。
    ///	    2007.05.12 版本：2.1 JiRiGaLa BatchSave 进行改进。
    ///	    2007.01.04 版本：2.0 JiRiGaLa 重新整理主键。
    ///	    2006.02.12 版本：1.2 JiRiGaLa 调整主键的规范化。
    ///	    2006.02.12 版本：1.2 JiRiGaLa 调整主键的规范化。
    ///	    2004.11.19 版本：1.1 JiRiGaLa 增加员工类别判断部分。
    ///     2004.11.18 版本：1.0 JiRiGaLa 主键进行了绝对的优化，这是个好东西啊，平时要多用，用得要灵活些。
    ///     
    /// 版本：2.8
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.11.30</date>
    /// </author>
    /// </summary>
    public partial class BasePermissionItemManager : BaseManager
    {
        private static readonly object PermissionItemLock = new object();

        /// <summary>
        /// 获取一个操作权限的主键
        /// 若不存在就自动增加一个
        /// </summary>
        /// <param name="permissionItemCode">操作权限编号</param>
        /// <param name="permissionItemName">操作权限名称</param>
        /// <returns>主键</returns>
        public string GetIdByAdd(string permissionItemCode, string permissionItemName = null)
        {
            // 判断当前判断的权限是否存在，否则很容易出现前台设置了权限，后台没此项权限
            // 需要自动的能把前台判断过的权限，都记录到后台来

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldCode, permissionItemCode));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldDeletionStateCode, 0));

            BasePermissionItemEntity permissionItemEntity = new BasePermissionItemEntity();
            permissionItemEntity = new BasePermissionItemEntity(this.GetDataTable(parameters, BasePermissionItemEntity.FieldId));

            string permissionItemId = string.Empty;
            if (permissionItemEntity != null)
            {
                permissionItemId = permissionItemEntity.Id.ToString();
            }
            
            // 若是在调试阶段、有没在的权限被判断了，那就自动加入这个权限，不用人工加入权限了，工作效率会提高很多，
            // 哪些权限是否有被调用什么的，还可以进行一些诊断
            #if (DEBUG)
                if (String.IsNullOrEmpty(permissionItemId))
                {
                    // 这里需要进行一次加锁，方式并发冲突发生
                    lock (PermissionItemLock)
                    {
                        permissionItemEntity.Code = permissionItemCode;
                        if (string.IsNullOrEmpty(permissionItemName))
                        {
                            permissionItemEntity.FullName = permissionItemCode;
                        }
                        else
                        {
                            permissionItemEntity.FullName = permissionItemName;
                        }
                        permissionItemEntity.ParentId = null;
                        permissionItemEntity.IsScope = 0;
                        permissionItemEntity.AllowDelete = 1;
                        permissionItemEntity.AllowEdit = 1;
                        permissionItemEntity.Enabled = 1;
                        // 这里是防止主键重复？
                        // permissionEntity.ID = BaseBusinessLogic.NewGuid();
                        permissionItemId = this.AddEntity(permissionItemEntity);
                    }
                }
                else
                {
                    // 更新最后一次访问日期，设置为当前服务器日期
                    SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
                    sqlBuilder.BeginUpdate(this.CurrentTableName);
                    sqlBuilder.SetDBNow(BasePermissionItemEntity.FieldLastCall);
                    sqlBuilder.SetWhere(BasePermissionItemEntity.FieldId, permissionItemId);
                    sqlBuilder.EndUpdate();
                }
                #endif

            return permissionItemId;
        }


        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="code">编号</param>
        /// <param name="fullName">名称</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>主键</returns>
        public string AddByDetail(string code, string fullName, out string statusCode)
        {
            BasePermissionItemEntity permissionItemEntity = new BasePermissionItemEntity();
            permissionItemEntity.Code = code;
            permissionItemEntity.FullName = fullName;
            return this.Add(permissionItemEntity, out statusCode);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="permissionEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>主键</returns>
        public string Add(BasePermissionItemEntity permissionItemEntity, out string statusCode)
        {
            string returnValue = string.Empty;
            // 检查编号是否重复
            if (this.Exists(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldDeletionStateCode, 0), new KeyValuePair<string, object>(BasePermissionItemEntity.FieldCode, permissionItemEntity.Code)))
            {
                // 编号已重复
                statusCode = StatusCode.ErrorCodeExist.ToString();
            }
            else
            {
                returnValue = this.AddEntity(permissionItemEntity);
                // 运行成功
                statusCode = StatusCode.OKAdd.ToString();
            }
            return returnValue;
        }

        /// <summary>
        /// 获取一个
        /// </summary>
        /// <param name="code">编号</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByCode(string code)
        {
            return this.GetDataTable(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldCode, code));
        }

        /// <summary>
        /// 获取一个
        /// </summary>
        /// <param name="code">编号</param>
        /// <param name="permissionEntity">实体</param>
        /// <returns>数据表</returns>
        public DataTable GetByCode(string code, BasePermissionItemEntity permissionItemEntity)
        {
            DataTable dataTable = this.GetDataTable(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldCode, code));
            permissionItemEntity.GetSingle(dataTable);
            return dataTable;
        }

        /// <summary>
        /// 更新一个
        /// </summary>
        /// <param name="permissionEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>影响行数</returns>
        public int Update(BasePermissionItemEntity permissionItemEntity, out string statusCode)
        {
            int returnValue = 0;
            // 检查是否已被其他人修改            
            //if (DbLogic.IsModifed(DbHelper, BasePermissionEntity.TableName, permissionEntity.Id, permissionEntity.ModifiedUserId, permissionEntity.ModifiedOn))
            //{
            //    // 数据已经被修改
            //    statusCode = StatusCode.ErrorChanged.ToString();
            //}
            //else
            //{
                // 检查编号是否重复
            if (this.Exists(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldDeletionStateCode, 0), new KeyValuePair<string, object>(BasePermissionItemEntity.FieldCode, permissionItemEntity.Code), permissionItemEntity.Id))
                {
                    // 文件夹名已重复
                    statusCode = StatusCode.ErrorCodeExist.ToString();
                }
                else
                {
                    // 进行更新操作
                    returnValue = this.UpdateEntity(permissionItemEntity);
                    if (returnValue == 1)
                    {
                        statusCode = StatusCode.OKUpdate.ToString();
                    }
                    else
                    {
                        // 数据可能被删除
                        statusCode = StatusCode.ErrorDeleted.ToString();
                    }
                }
            //}
            return returnValue;
        }

        /// <summary>
        /// 删除一个
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            // 删除关联数据
            int returnValue = 0;
            returnValue = this.DeleteEntity(id);
            /*
            BUBaseModulePermission ModulePermission = new BUBaseModulePermission(OleDbHelper, userInfo);
            // 是否强制删除关联数据
            if (force)
            {
                returnValue = ModulePermission.Delete(BUBaseModulePermission.FieldPermissionId, id);
                returnValue += this.DeleteEntity(id);
                this.ReturnStatusCode = StatusCode.OKDelete;
            }
            else
            {
                // 检查是否有关联数据存在
                if (ModulePermission.Exists(BUBaseModulePermission.FieldPermissionId, id))
                {
                    // 已有关联数据
                    this.ReturnStatusCode = StatusCode.ErrorDataRelated;
                }
                else
                {
                    returnValue = this.DeleteEntity(id);
                    this.ReturnStatusCode = StatusCode.OKDelete;
                }
            }            
            */
            return returnValue;
        }


        /// <summary>
        /// 获得用户授权范围
        /// </summary>
        /// <param name="staffId">员工主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByUser(string userId, string permissionItemCode)
        {
            DataTable returnValue = new DataTable(this.CurrentTableName);
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            // 这里需要判断,是系统权限？
            bool isRole = false;
            BaseUserManager userManager = new BaseUserManager(this.DbHelper, this.UserInfo);
            // 用户管理员
            isRole = userManager.IsInRoleByCode(userId, "UserAdmin");
            if (isRole)
            {
                
                parameters.Add(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldCategoryCode, "System"));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldEnabled, 1));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldDeletionStateCode, 0));
                returnValue = this.GetDataTable(parameters, BasePermissionItemEntity.FieldSortCode);
                returnValue.TableName = this.CurrentTableName;
                return returnValue;
            }

            // 这里需要判断,是业务权限？
            isRole = userManager.IsInRoleByCode(userId, "Admin");
            if (isRole)
            {
                parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldCategoryCode, "Application"));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldEnabled, 1));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldDeletionStateCode, 0));
                returnValue = this.GetDataTable(parameters, BasePermissionItemEntity.FieldSortCode);
                returnValue.TableName = this.CurrentTableName;
                return returnValue;
            }

            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            string[] permissionItemIds = permissionScopeManager.GetTreeResourceScopeIds(userId, BasePermissionItemEntity.TableName, permissionItemCode, true);
            // 有效的，未被删除的
            parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldId, permissionItemIds));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldDeletionStateCode, 0));

            returnValue = this.GetDataTable(parameters, BasePermissionItemEntity.FieldSortCode);
            returnValue.TableName = this.CurrentTableName;
            return returnValue;
        }


        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        public override int BatchSave(DataTable dataTable)
        {
            int returnValue = 0;
            BasePermissionItemEntity permissionItemEntity = new BasePermissionItemEntity();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                // 删除状态
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    string id = dataRow[BasePermissionItemEntity.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        if (dataRow[BasePermissionItemEntity.FieldAllowDelete, DataRowVersion.Original].ToString().Equals("1"))
                        {
                            returnValue += this.DeleteEntity(id);
                        }
                    }
                }
                // 被修改过
                if (dataRow.RowState == DataRowState.Modified)
                {
                    string id = dataRow[BasePermissionItemEntity.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        permissionItemEntity.GetFrom(dataRow);
                        // 判断是否允许编辑
                        if (permissionItemEntity.AllowEdit == 1)
                        {
                            returnValue += this.UpdateEntity(permissionItemEntity);
                        }
                        else
                        {
                            // 不允许编辑，但是排序还是允许的
                            returnValue += this.SetProperty(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldId, id), new KeyValuePair<string, object>(BasePermissionItemEntity.FieldSortCode, permissionItemEntity.SortCode));
                        }
                    }
                }
                // 添加状态
                if (dataRow.RowState == DataRowState.Added)
                {
                    permissionItemEntity.GetFrom(dataRow);
                    returnValue += this.AddEntity(permissionItemEntity).Length > 0 ? 1 : 0;
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

        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="parentId">父级主键</param>
        /// <returns>影响行数</returns>
        public int MoveTo(string id, string parentId)
        {
            return this.SetProperty(id, new KeyValuePair<string, object>(BaseOrganizeEntity.FieldParentId, parentId));
        }
	}
}