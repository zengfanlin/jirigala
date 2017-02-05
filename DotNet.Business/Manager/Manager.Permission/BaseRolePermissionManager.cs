//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseRolePermissionManager
    /// 角色权限
    /// 
    /// 修改纪录
    ///
    ///     2010.04.23 版本：1.1 JiRiGaLa Enabled 不允许为NULL的错误解决。
    ///     2008.05.23 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.05.23</date>
    /// </author>
    /// </summary>
    public partial class BaseRolePermissionManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseRolePermissionManager()
        {
            base.CurrentTableName = BasePermissionEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseRolePermissionManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseRolePermissionManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseRolePermissionManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseRolePermissionManager(IDbHelper dbHelper, BaseUserInfo userInfo)
            : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public BaseRolePermissionManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        #region public string[] GetPermissionItemIds(string roleId) 获取角色的权限主键数组
        /// <summary>
        /// 获取角色的权限主键数组
        /// </summary>
        /// <param name="roleId">角色代吗</param>
        /// <returns>主键数组</returns>
        public string[] GetPermissionItemIds(string roleId)
        {
            string[] returnValue = null;

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceCategory, BaseRoleEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceId, roleId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldDeletionStateCode, 0));

            returnValue = this.GetProperties(parameters, BasePermissionEntity.FieldPermissionItemId);
            return returnValue;
        }
        #endregion

        #region public string[] GetRoleIds(string permissionItemId) 获取角色主键数组
        /// <summary>
        /// 获取角色主键数组
        /// </summary>
        /// <param name="permissionItemId">操作权限</param>
        /// <returns>主键数组</returns>
        public string[] GetRoleIds(string permissionItemId)
        {
            string[] returnValue = null;

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceCategory, BaseRoleEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldPermissionItemId, permissionItemId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldDeletionStateCode, 0));

            returnValue = this.GetProperties(parameters, BasePermissionEntity.FieldResourceId);
            return returnValue;
        }
        #endregion
        
        //
        // 授予权限的实现部分
        //

        #region private string Grant(BasePermissionManager permissionManager, string id, string roleId, string permissionItemId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionManager">资源权限读写器</param>
        /// <param name="Id">主键</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>主键</returns>
        private string Grant(BasePermissionManager permissionManager, string roleId, string permissionItemId)
        {
            string returnValue = string.Empty;
            BasePermissionEntity resourcePermission = new BasePermissionEntity();
            resourcePermission.ResourceCategory = BaseRoleEntity.TableName;
            resourcePermission.ResourceId = roleId;
            resourcePermission.PermissionId = int.Parse(permissionItemId);
            // 防止不允许为NULL的错误发生
            resourcePermission.Enabled = 1;
            return permissionManager.Add(resourcePermission);
        }
        #endregion

        #region public string Grant(string roleId, string permissionItemId) 角色授予权限
        /// <summary>
        /// 角色授予权限
        /// </summary>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">权限主键</param>
        public string Grant(string roleId, string permissionItemId)
        {
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            return this.Grant(permissionManager, roleId, permissionItemId);
        }
        #endregion

        public int Grant(string roleId, string[] permissionItemIds)
        {
            int returnValue = 0;
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < permissionItemIds.Length; i++)
            {
                this.Grant(permissionManager, roleId, permissionItemIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int Grant(string[] roleIds, string permissionItemId)
        {
            int returnValue = 0;
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < roleIds.Length; i++)
            {
                this.Grant(permissionManager, roleIds[i], permissionItemId);
                returnValue++;
            }
            return returnValue;
        }

        public int Grant(string[] roleIds, string[] permissionItemIds)
        {
            int returnValue = 0;
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < roleIds.Length; i++)
            {
                for (int j = 0; j < permissionItemIds.Length; j++)
                {
                    this.Grant(permissionManager, roleIds[i], permissionItemIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  撤销权限的实现部分
        //

        #region private int Revoke(BasePermissionManager permissionManager, string roleId, string permissionItemId) 为了提高撤销的运行速度
        /// <summary>
        /// 为了提高撤销的运行速度
        /// </summary>
        /// <param name="permissionManager">资源权限读写器</param>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响行数</returns>
        private int Revoke(BasePermissionManager permissionManager, string roleId, string permissionItemId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceCategory, BaseRoleEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceId, roleId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldPermissionItemId, permissionItemId));
            return permissionManager.Delete(parameters);
        }
        #endregion

        #region public int Revoke(string roleId, string permissionItemId) 撤销角色权限
        /// <summary>
        /// 撤销角色权限
        /// </summary>
        /// <param name="roleId">角色主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响行数</returns>
        public int Revoke(string roleId, string permissionItemId)
        {
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            return this.Revoke(permissionManager, roleId, permissionItemId);
        }
        #endregion

        public int Revoke(string roleId, string[] permissionItemIds)
        {
            int returnValue = 0;
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < permissionItemIds.Length; i++)
            {
                returnValue += this.Revoke(permissionManager, roleId, permissionItemIds[i]);
            }
            return returnValue;
        }

        public int Revoke(string[] roleIds, string permissionItemId)
        {
            int returnValue = 0;
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < roleIds.Length; i++)
            {
                returnValue += this.Revoke(permissionManager, roleIds[i], permissionItemId);
            }
            return returnValue;
        }

        public int Revoke(string[] roleIds, string[] permissionItemIds)
        {
            int returnValue = 0;
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < roleIds.Length; i++)
            {
                for (int j = 0; j < permissionItemIds.Length; j++)
                {
                    returnValue += this.Revoke(permissionManager, roleIds[i], permissionItemIds[j]);
                }
            }
            return returnValue;
        }

        #region public int RevokeAll(string roleId) 撤销角色全部权限
        /// <summary>
        /// 撤销角色全部权限
        /// </summary>
        /// <param name="roleId">角色主键</param>
        /// <returns>影响行数</returns>
        public int RevokeAll(string roleId)
        {
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceCategory, BaseRoleEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceId, roleId));
            return permissionManager.Delete(parameters);
        }
        #endregion
    }
}