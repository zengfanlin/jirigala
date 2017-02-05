//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseModulePermissionManager 
    /// 模块权限关系管理
    ///
    /// 修改记录
    /// 
    ///     2008.06.19 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    /// </summary>
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.06.19</date>
    /// </author>
    /// </summary>
    public class BasePermissionModuleManager : BaseManager
    {
        public BasePermissionModuleManager()
        {
            base.CurrentTableName = BasePermissionEntity.TableName;
        }

        public BasePermissionModuleManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        public BasePermissionModuleManager(IDbHelper dbHelper, BaseUserInfo userInfo)
            : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        public BasePermissionModuleManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        public string[] GetModuleIds(string permissionItemId)
        {
            string[] returnValue = null;

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceCategory, BaseModuleEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldPermissionItemId, permissionItemId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldDeletionStateCode, 0));

            DataTable dataTable = this.GetDataTable(parameters);
            returnValue = BaseBusinessLogic.FieldToArray(dataTable, BasePermissionEntity.FieldResourceId);
            return returnValue;
        }

        public string[] GetPermissionIds(string moduleId)
        {
            string[] returnValue = null;

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceCategory, BaseModuleEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceId, moduleId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldDeletionStateCode, 0));
            DataTable dataTable = this.GetDataTable(parameters);
            returnValue = BaseBusinessLogic.FieldToArray(dataTable, BasePermissionEntity.FieldPermissionItemId);
            return returnValue;
        }

        public int Add(string moduleId, string permissionItemId)
        {
            int returnValue = 0;

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceCategory, BaseModuleEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceId, moduleId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldPermissionItemId, permissionItemId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldDeletionStateCode, 0));

            // 检查记录是否重复
            if (!this.Exists(parameters))
            {
                BasePermissionEntity permissionEntity = new BasePermissionEntity();
                permissionEntity.ResourceId = moduleId;
                permissionEntity.ResourceCategory = BaseModuleEntity.TableName;
                permissionEntity.Enabled = 1;
                permissionEntity.DeletionStateCode = 0;
                permissionEntity.PermissionId = int.Parse(permissionItemId);
                BasePermissionManager permissionManager = new BasePermissionManager(this.DbHelper, this.UserInfo, this.CurrentTableName);
                permissionManager.AddEntity(permissionEntity);
                returnValue++;
            }
            return returnValue;           
        }

        public int Add(string[] moduleIds, string permissionItemId)
        {
            int returnValue = 0;
            for (int i = 0; i < moduleIds.Length; i++)
            {
                this.Add(moduleIds[i], permissionItemId);
                returnValue++;
            }
            return returnValue;
        }

        public int Add(string moduleId, string[] permissionItemIds)
        {
            int returnValue = 0;
            for (int i = 0; i < permissionItemIds.Length; i++)
            {
                this.Add(moduleId, permissionItemIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int Add(string[] moduleIds, string[] permissionItemIds)
        {
            int returnValue = 0;
            for (int i = 0; i < moduleIds.Length; i++)
            {
                for (int j = 0; i < permissionItemIds.Length; i++)
                {
                    this.Add(moduleIds[i], permissionItemIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }

        public int Delete(string moduleId, string permissionItemId)
        {
            int returnValue = 0;
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceCategory, BaseModuleEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceId, moduleId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldPermissionItemId, permissionItemId));
            BasePermissionManager manager = new BasePermissionManager(this.DbHelper, this.UserInfo);
            returnValue=manager.Delete(parameters);
            return returnValue;
        }

        public int Delete(string[] moduleIds, string permissionItemId)
        {
            int returnValue = 0;
            for (int i = 0; i < moduleIds.Length; i++)
            {
                returnValue += this.Delete(moduleIds[i], permissionItemId);
            }
            return returnValue;
        }

        public int Delete(string moduleId, string[] permissionItemIds)
        {
            int returnValue = 0;
            for (int i = 0; i < permissionItemIds.Length; i++)
            {
                returnValue += this.Delete(moduleId, permissionItemIds[i]);
            }
            return returnValue;
        }

        public int Delete(string[] moduleIds, string[] permissionItemIds)
        {
            int returnValue = 0;
            for (int i = 0; i < moduleIds.Length; i++)
            {
                for (int j = 0; i < permissionItemIds.Length; i++)
                {
                    returnValue += this.Delete(moduleIds[i], permissionItemIds[j]);
                }
            }
            return returnValue;
        }
    }
}