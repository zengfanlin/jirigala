//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseUserScopeManager
    /// 用户权限域
    /// 
    /// 修改纪录
    ///
    ///     2008.05.24 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.05.24</date>
    /// </author>
    /// </summary>
    public partial class BaseUserScopeManager : BaseManager, IBaseManager
    {
        public BaseUserScopeManager()
        {
            base.CurrentTableName = BasePermissionScopeEntity.TableName;
        }

        public BaseUserScopeManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        public BaseUserScopeManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        public BaseUserScopeManager(IDbHelper dbHelper, BaseUserInfo userInfo)
            : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        public BaseUserScopeManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        public new string GetIdByCode(string permissionItemCode)
        {
            string tableName = BasePermissionScopeEntity.TableName;
            if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
            {
                tableName = BaseSystemInfo.SystemCode + "PermissionItem";
            }
            BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(DbHelper, this.UserInfo, tableName);
            // 这里应该是若不存在就自动加一个操作权限
            return permissionItemManager.GetIdByAdd(permissionItemCode);
        }

        public int ClearUserPermissionScope(string userId, string permissionItemCode)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, BaseUserEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, userId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, this.GetIdByCode(permissionItemCode)));
            
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            return permissionScopeManager.Delete(parameters);
        }

        public int RevokeAll(string userId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, BaseUserEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, userId));
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            return permissionScopeManager.Delete(parameters);
        }
    }
}