//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseOrganizePermissionManager
    /// 组织机构权限
    /// 
    /// 修改纪录
    ///
    ///     2012.03.22 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.03.22</date>
    /// </author>
    /// </summary>
    public partial class BaseOrganizePermissionManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseOrganizePermissionManager()
        {
            base.CurrentTableName = BasePermissionEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseOrganizePermissionManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseOrganizePermissionManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseOrganizePermissionManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseOrganizePermissionManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BaseOrganizePermissionManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        #region public string[] GetPermissionItemIds(string organizeId) 获取组织机构的权限主键数组
        /// <summary>
        /// 获取组织机构的权限主键数组
        /// </summary>
        /// <param name="organizeId">组织机构代吗</param>
        /// <returns>主键数组</returns>
        public string[] GetPermissionItemIds(string organizeId)
        {
            string[] returnValue = null;

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceCategory, BaseOrganizeEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceId, organizeId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldDeletionStateCode, 0));

            returnValue = this.GetProperties(parameters, BasePermissionEntity.FieldPermissionItemId);
            return returnValue;
        }
        #endregion

        #region public string[] GetOrganizeIds(string permissionItemId) 获取组织机构主键数组
        /// <summary>
        /// 获取组织机构主键数组
        /// </summary>
        /// <param name="permissionItemId">操作权限</param>
        /// <returns>主键数组</returns>
        public string[] GetOrganizeIds(string permissionItemId)
        {
            string[] returnValue = null;

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceCategory, BaseOrganizeEntity.TableName));
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

        #region private string Grant(BasePermissionManager permissionManager, string id, string organizeId, string permissionItemId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionManager">资源权限读写器</param>
        /// <param name="Id">主键</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>主键</returns>
        private string Grant(BasePermissionManager permissionManager, string organizeId, string permissionItemId)
        {
            string returnValue = string.Empty;
            BasePermissionEntity resourcePermission = new BasePermissionEntity();
            resourcePermission.ResourceCategory = BaseOrganizeEntity.TableName;
            resourcePermission.ResourceId = organizeId;
            resourcePermission.PermissionId = int.Parse(permissionItemId);
            // 防止不允许为NULL的错误发生
            resourcePermission.Enabled = 1;
            return permissionManager.Add(resourcePermission);
        }
        #endregion

        #region public string Grant(string organizeId, string permissionItemId) 组织机构授予权限
        /// <summary>
        /// 组织机构授予权限
        /// </summary>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="permissionItemId">权限主键</param>
        public string Grant(string organizeId, string permissionItemId)
        {
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            return this.Grant(permissionManager, organizeId, permissionItemId);
        }
        #endregion

        public int Grant(string organizeId, string[] permissionItemIds)
        {
            int returnValue = 0;
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < permissionItemIds.Length; i++)
            {
                this.Grant(permissionManager, organizeId, permissionItemIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int Grant(string[] organizeIds, string permissionItemId)
        {
            int returnValue = 0;
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < organizeIds.Length; i++)
            {
                this.Grant(permissionManager, organizeIds[i], permissionItemId);
                returnValue++;
            }
            return returnValue;
        }

        public int Grant(string[] organizeIds, string[] permissionItemIds)
        {
            int returnValue = 0;
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < organizeIds.Length; i++)
            {
                for (int j = 0; j < permissionItemIds.Length; j++)
                {
                    this.Grant(permissionManager, organizeIds[i], permissionItemIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  撤销权限的实现部分
        //

        #region private int Revoke(BasePermissionManager permissionManager, string organizeId, string permissionItemId) 为了提高撤销的运行速度
        /// <summary>
        /// 为了提高撤销的运行速度
        /// </summary>
        /// <param name="permissionManager">资源权限读写器</param>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响行数</returns>
        private int Revoke(BasePermissionManager permissionManager, string organizeId, string permissionItemId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceCategory, BaseOrganizeEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceId, organizeId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldPermissionItemId, permissionItemId));
            return permissionManager.Delete(parameters);
        }
        #endregion

        #region public int Revoke(string organizeId, string permissionItemId) 撤销组织机构权限
        /// <summary>
        /// 撤销组织机构权限
        /// </summary>
        /// <param name="organizeId">组织机构主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响行数</returns>
        public int Revoke(string organizeId, string permissionItemId)
        {
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            return this.Revoke(permissionManager, organizeId, permissionItemId);
        }
        #endregion

        public int Revoke(string organizeId, string[] permissionItemIds)
        {
            int returnValue = 0;
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < permissionItemIds.Length; i++)
            {
                returnValue += this.Revoke(permissionManager, organizeId, permissionItemIds[i]);
            }
            return returnValue;
        }

        public int Revoke(string[] organizeIds, string permissionItemId)
        {
            int returnValue = 0;
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < organizeIds.Length; i++)
            {
                returnValue += this.Revoke(permissionManager, organizeIds[i], permissionItemId);
            }
            return returnValue;
        }

        public int Revoke(string[] organizeIds, string[] permissionItemIds)
        {
            int returnValue = 0;
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < organizeIds.Length; i++)
            {
                for (int j = 0; j < permissionItemIds.Length; j++)
                {
                    returnValue += this.Revoke(permissionManager, organizeIds[i], permissionItemIds[j]);
                }
            }
            return returnValue;
        }

        #region public int RevokeAll(string organizeId) 撤销组织机构全部权限
        /// <summary>
        /// 撤销组织机构全部权限
        /// </summary>
        /// <param name="organizeId">组织机构主键</param>
        /// <returns>影响行数</returns>
        public int RevokeAll(string organizeId)
        {
            BasePermissionManager permissionManager = new BasePermissionManager(DbHelper, UserInfo, this.CurrentTableName);
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceCategory, this.CurrentTableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionEntity.FieldResourceId, organizeId));
            return permissionManager.Delete(parameters);
        }
        #endregion
    }
}