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
    /// BaseUserPermissionManager
    /// 用户权限
    /// 
    /// 修改纪录
    ///
    ///     2010.04.23 版本：1.2 JiRiGaLa Enabled 不允许为NULL的错误解决。
    ///     2008.10.23 版本：1.1 JiRiGaLa 修改为用户权限。
    ///     2008.05.23 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.05.23</date>
    /// </author>
    /// </summary>
    public class BaseUserPermissionManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseUserPermissionManager()
        {
            base.CurrentTableName = BasePermissionEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseUserPermissionManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseUserPermissionManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseUserPermissionManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseUserPermissionManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BaseUserPermissionManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 判断用户是否有有相应的权限
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>有权限</returns>
        public bool CheckPermission(string userId, string permissionItemCode)
        {
            BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(DbHelper);
            string permissionItemId = permissionItemManager.GetIdByCode(permissionItemCode);
            // 没有找到相应的权限
            if (String.IsNullOrEmpty(permissionItemId))
            {
                return false;
            }

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceCategory, BaseUserEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceId, userId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldEnabled, "1"));
            return DbLogic.Exists(DbHelper, this.CurrentTableName, parameters);
        }


        #region public string[] GetPermissionItemIds(string userId) 获取用户的权限主键数组
        /// <summary>
        /// 获取用户的权限主键数组
        /// </summary>
        /// <param name="userId">用户代吗</param>
        /// <returns>主键数组</returns>
        public string[] GetPermissionItemIds(string userId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceCategory, BaseUserEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceId, userId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldDeletionStateCode, 0));

            return this.GetProperties(parameters, BasePermissionEntity.FieldPermissionItemId);
        }
        #endregion

        #region public string[] GetUserIds(string permissionItemId) 获取用户主键数组
        /// <summary>
        /// 获取用户主键数组
        /// </summary>
        /// <param name="permissionItemId">操作权限主键</param>
        /// <returns>主键数组</returns>
        public string[] GetUserIds(string permissionItemId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldPermissionItemId, permissionItemId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceCategory, BaseUserEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldDeletionStateCode, 0));

            return this.GetProperties(parameters, BasePermissionEntity.FieldResourceId);
        }
        #endregion

        //
        // 授予权限的实现部分
        //

        #region private string Grant(BasePermissionManager permissionManager, string id, string userId, string permissionItemId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionManager">资源权限读写器</param>
        /// <param name="Id">主键</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>主键</returns>
        private string Grant(BasePermissionManager permissionManager, string id, string userId, string permissionItemId)
        {
            string returnValue = string.Empty;
            BasePermissionEntity resourcePermissionEntity = new BasePermissionEntity();
            resourcePermissionEntity.ResourceCategory = BaseUserEntity.TableName;
            resourcePermissionEntity.ResourceId = userId;
            resourcePermissionEntity.PermissionId = int.Parse(permissionItemId);
            resourcePermissionEntity.Enabled = 1;
            return permissionManager.Add(resourcePermissionEntity);
        }
        #endregion

        #region public string Grant(string userId, string permissionItemId) 用户授予权限
        /// <summary>
        /// 用户授予权限
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemId">权限主键</param>
        public string Grant(string userId, string permissionItemId)
        {
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            return this.Grant(permissionManager, string.Empty, userId, permissionItemId);
        }
        #endregion

        public int Grant(string userId, string[] permissionItemIds)
        {
            int returnValue = 0;
            BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper);
            string[] sequenceIds = sequenceManager.GetBatchSequence(BasePermissionEntity.TableName, permissionItemIds.Length);
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < permissionItemIds.Length; i++)
            {
                this.Grant(permissionManager, sequenceIds[i], userId, permissionItemIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int Grant(string[] userIds, string permissionItemId)
        {
            int returnValue = 0;
            BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper);
            string[] sequenceIds = sequenceManager.GetBatchSequence(BasePermissionEntity.TableName, userIds.Length);
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < userIds.Length; i++)
            {
                this.Grant(permissionManager, sequenceIds[i], userIds[i], permissionItemId);
                returnValue++;
            }
            return returnValue;
        }

        public int Grant(string[] userIds, string[] permissionItemIds)
        {
            int returnValue = 0;
            BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper);
            string[] sequenceIds = sequenceManager.GetBatchSequence(BasePermissionEntity.TableName, userIds.Length * permissionItemIds.Length);
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < permissionItemIds.Length; j++)
                {
                    this.Grant(permissionManager, sequenceIds[i * permissionItemIds.Length + j], userIds[i], permissionItemIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  撤销权限的实现部分
        //

        #region private int Revoke(BasePermissionManager permissionManager, string userId, string permissionItemId) 为了提高撤销的运行速度
        /// <summary>
        /// 为了提高撤销的运行速度
        /// </summary>
        /// <param name="permissionManager">资源权限读写器</param>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响行数</returns>
        private int Revoke(BasePermissionManager permissionManager, string userId, string permissionItemId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceCategory, BaseUserEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceId, userId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldPermissionItemId, permissionItemId));
            return permissionManager.Delete(parameters);
        }
        #endregion

        #region public int Revoke(string userId, string permissionItemId) 撤销员工权限
        /// <summary>
        /// 撤销员工权限
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响行数</returns>
        public int Revoke(string userId, string permissionItemId)
        {
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            return this.Revoke(permissionManager, userId, permissionItemId);
        }
        #endregion

        public int Revoke(string userId, string[] permissionItemIds)
        {
            int returnValue = 0;
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < permissionItemIds.Length; i++)
            {
                returnValue += this.Revoke(permissionManager, userId, permissionItemIds[i]);
            }
            return returnValue;
        }

        public int Revoke(string[] userIds, string permissionItemId)
        {
            int returnValue = 0;
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < userIds.Length; i++)
            {
                returnValue += this.Revoke(permissionManager, userIds[i], permissionItemId);
            }
            return returnValue;
        }

        public int Revoke(string[] userIds, string[] permissionItemIds)
        {
            int returnValue = 0;
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < permissionItemIds.Length; j++)
                {
                    returnValue += this.Revoke(permissionManager, userIds[i], permissionItemIds[j]);
                }
            }
            return returnValue;
        }

        #region public int RevokeAll(string userId) 撤销用户全部权限
        /// <summary>
        /// 撤销用户全部权限
        /// </summary>
        /// <param name="roleId">角色主键</param>
        /// <returns>影响行数</returns>
        public int RevokeAll(string userId)
        {
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceCategory, BaseUserEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceId, userId));
            return permissionManager.Delete(parameters);
        }
        #endregion
    }
}