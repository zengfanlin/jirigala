//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseUserManager
    /// 用户管理
    /// 
    /// 修改纪录
    /// 
    ///		2012.04.12 版本：1.0 JiRiGaLa	主键整理。
    /// 
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.04.12</date>
    /// </author> 
    /// </summary>
    public partial class BaseUserManager : BaseManager
    {
        public DataTable GetDataTableByRole(string roleId)
        {
            string tableName = BaseUserRoleEntity.TableName;
            if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
            {
                tableName = BaseSystemInfo.SystemCode + "UserRole";
            }

            string sqlQuery = " SELECT * FROM " + BaseUserEntity.TableName
                            + " WHERE " + BaseUserEntity.FieldEnabled + "=1 "
                            + "       AND " + BaseUserEntity.FieldDeletionStateCode + "= 0 ";
                            
                            // Access 中数据类型要匹配
                            switch (BaseSystemInfo.UserCenterDbType)
                            {
                                case CurrentDbType.Access:
                                    sqlQuery += "       AND (" + BaseUserEntity.FieldRoleId + "=" + roleId + "";
                                    break;
                                default:
                                    sqlQuery += "       AND (" + BaseUserEntity.FieldRoleId + "='" + roleId + "'";
                                    break;
                            }
                            sqlQuery += "            OR " + BaseUserEntity.FieldId + " IN "
                            + "           (SELECT + " + BaseUserRoleEntity.FieldUserId
                            + "              FROM " + tableName;

                            switch (BaseSystemInfo.UserCenterDbType)
                            {
                                case CurrentDbType.Access:
                                    sqlQuery += "             WHERE " + BaseUserRoleEntity.FieldRoleId + " = " + roleId + "";
                                    break;
                                default:
                                    sqlQuery += "             WHERE " + BaseUserRoleEntity.FieldRoleId + " = '" + roleId + "'";
                                    break;
                            }                            

                            sqlQuery += "               AND " + BaseUserRoleEntity.FieldEnabled + " = 1"
                            + "                AND " + BaseUserRoleEntity.FieldDeletionStateCode + " = 0)) "
                            + " ORDER BY  " + BaseUserEntity.FieldSortCode;
            return DbHelper.Fill(sqlQuery);
        }


        public int ClearUser(string roleId)
        {
            int returnValue = 0;
            returnValue = this.SetProperty(
                new KeyValuePair<string, object>(BaseUserEntity.FieldRoleId, roleId)
                , new KeyValuePair<string, object>(BaseUserEntity.FieldRoleId, null));

            string tableName = BaseUserRoleEntity.TableName;
            if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
            {
                tableName = BaseSystemInfo.SystemCode + "UserRole";
            }

            BaseUserRoleManager userRoleManager = new BaseUserRoleManager(this.DbHelper, this.UserInfo, tableName);
            returnValue += userRoleManager.Delete(new KeyValuePair<string, object>(BaseUserRoleEntity.FieldRoleId, roleId));
            return returnValue;
        }

        public int ClearRole(string userId)
        {
            int returnValue = 0;
            returnValue += this.SetProperty(new KeyValuePair<string, object>(BaseUserEntity.FieldId, userId), new KeyValuePair<string, object>(BaseUserEntity.FieldRoleId, null));

            string tableName = BaseUserRoleEntity.TableName;
            if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
            {
                tableName = BaseSystemInfo.SystemCode + "UserRole";
            }

            BaseUserRoleManager userRoleManager = new BaseUserRoleManager(this.DbHelper, this.UserInfo, tableName);
            returnValue += userRoleManager.Delete(new KeyValuePair<string, object>(BaseUserRoleEntity.FieldUserId, userId));
            return returnValue;
        }

        /// <summary>
        /// 用户是否在某个角色中
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="realName">角色</param>
        /// <returns>存在</returns>
        public bool IsInRole(string userId, string realName)
        {
            bool returnValue = false;
            if (string.IsNullOrEmpty(realName))
            {
                return false;
            }
            BaseRoleManager roleManager = new BaseRoleManager(this.DbHelper, this.UserInfo);
            string roleId = roleManager.GetId(new KeyValuePair<string, object>(BaseRoleEntity.FieldDeletionStateCode, 0)
                , new KeyValuePair<string, object>(BaseRoleEntity.FieldRealName, realName));
            if (string.IsNullOrEmpty(roleId))
            {
                return false;
            }
            string[] roleIds = GetAllRoleIds(userId);
            returnValue = StringUtil.Exists(roleIds, roleId);
            return returnValue;
        }

        /// <summary>
        /// 用户是否在某个角色中
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="roleCode">角色编号</param>
        /// <returns>存在</returns>
        public bool IsInRoleByCode(string userId, string code)
        {
            bool returnValue = false;
            if (string.IsNullOrEmpty(code))
            {
                return false;
            }

            string tableName = BaseRoleEntity.TableName;
            if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
            {
                tableName = BaseSystemInfo.SystemCode + "Role";
            }
            BaseRoleManager roleManager = new BaseRoleManager(this.DbHelper, this.UserInfo, tableName);
            string roleId = roleManager.GetId(
                new KeyValuePair<string, object>(BaseRoleEntity.FieldDeletionStateCode, 0)
                , new KeyValuePair<string, object>(BaseRoleEntity.FieldCode, code));
            if (string.IsNullOrEmpty(roleId))
            {
                return false;
            }
            string[] roleIds = GetAllRoleIds(userId);
            returnValue = StringUtil.Exists(roleIds, roleId);
            return returnValue;
        }

        #region public string[] GetRoleIds(string userId) 获取员工的角色主键数组
        /// <summary>
        /// 获取员工的角色主键数组
        /// </summary>
        /// <param name="userId">员工代吗</param>
        /// <returns>主键数组</returns>
        public string[] GetRoleIds(string userId)
        {
            string tableName = BaseUserRoleEntity.TableName;
            if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
            {
                tableName = BaseSystemInfo.SystemCode + "UserRole";
            }

            // 被删除的角色不应该显示出来
            string sqlQuery = " SELECT RoleId  "
                            + "   FROM " + tableName
                            + "  WHERE (UserId = " + userId + ") "
                            + "    AND (RoleId IN (SELECT Id FROM BaseRole WHERE (DeletionStateCode = 0))) AND (DeletionStateCode = 0) ";
            DataTable dataTable = DbHelper.Fill(sqlQuery);
            return BaseBusinessLogic.FieldToArray(dataTable, BaseUserRoleEntity.FieldRoleId);
        }
        #endregion

        #region public string[] GetRoleIds(string userId) 获取员工的角色主键数组
        /// <summary>
        /// 获取员工的角色主键数组
        /// </summary>
        /// <param name="userId">员工代吗</param>
        /// <returns>主键数组</returns>
        public string[] GetAllRoleIds(string userId)
        {
            string tableName = BaseUserRoleEntity.TableName;
            if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
            {
                tableName = BaseSystemInfo.SystemCode + "UserRole";
            }
            string roleTableName = BaseRoleEntity.TableName;
            if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
            {
                roleTableName = BaseSystemInfo.SystemCode + "Role";
            }

            // 被删除的角色不应该显示出来
            string sqlQuery = " SELECT RoleId "
                            + "   FROM BaseUser "
                            + "  WHERE (DeletionStateCode = 0) AND (Enabled = 1) AND (Id = " + userId + ") "
                            + "  UNION "
                            + " SELECT RoleId "
                            + "   FROM " + tableName
                            + "  WHERE (DeletionStateCode = 0) AND (Enabled = 1) AND (UserId = " + userId + ") AND (RoleId IN (SELECT Id FROM " + roleTableName + " WHERE (DeletionStateCode = 0))) ";
            DataTable dataTable = DbHelper.Fill(sqlQuery);
            return BaseBusinessLogic.FieldToArray(dataTable, BaseUserRoleEntity.FieldRoleId);
        }
        #endregion

        #region public string[] GetUserIdsInRole(string roleId) 获取员工的角色主键数组
        /// <summary>
        /// 获取员工的角色主键数组
        /// </summary>
        /// <param name="roleId">角色代吗</param>
        /// <returns>主键数组</returns>
        public string[] GetUserIdsInRole(string roleId)
        {
            string tableName = BaseUserRoleEntity.TableName;
            if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
            {
                tableName = BaseSystemInfo.SystemCode + "UserRole";
            }

            // 需要显示未被删除的用户
            string sqlQuery = " SELECT Id AS USERID FROM BaseUser WHERE (RoleId = " + roleId + ") AND (DeletionStateCode = 0) AND (Enabled = 1) "
                            + " UNION SELECT UserId FROM " + tableName + " WHERE (RoleId = " + roleId + ") AND (UserId IN (SELECT Id FROM BaseUser WHERE (DeletionStateCode = 0))) AND (DeletionStateCode = 0) ";
            DataTable dataTable = DbHelper.Fill(sqlQuery);
            return BaseBusinessLogic.FieldToArray(dataTable, BaseUserRoleEntity.FieldUserId);
        }
        #endregion

        public string[] GetUserIds(string[] roleIds)
        {
            string tableName = BaseUserRoleEntity.TableName;
            if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
            {
                tableName = BaseSystemInfo.SystemCode + "UserRole";
            }

            string[] userIds = null;
            if (roleIds != null && roleIds.Length > 0)
            {
                // 需要显示未被删除的用户
                string sqlQuery = " SELECT Id AS UserId FROM BaseUser WHERE (RoleId IN ( " + StringUtil.ArrayToList(roleIds) + ")) AND (DeletionStateCode = 0) AND (Enabled = 1) "
                                + " UNION SELECT UserId FROM " + tableName + " WHERE (RoleId IN (" + StringUtil.ArrayToList(roleIds) + ")) " 
                                + "  AND (UserId IN (SELECT Id FROM BaseUser WHERE (DeletionStateCode = 0))) AND (DeletionStateCode = 0) ";
                DataTable dataTable = DbHelper.Fill(sqlQuery);
                userIds = BaseBusinessLogic.FieldToArray(dataTable, BaseUserRoleEntity.FieldUserId);
            }
            return userIds;
        }

        
        //
        // 加入到角色
        //


        #region public string AddToRole(string userId, string roleId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="Id">主键</param>
        /// <param name="userId">用户主键</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>主键</returns>
        public string AddToRole(string userId, string roleId)
        {
            string returnValue = string.Empty;
            BaseUserRoleEntity userRoleEntity = new BaseUserRoleEntity();
            userRoleEntity.UserId = int.Parse(userId);
            userRoleEntity.RoleId = int.Parse(roleId);
            userRoleEntity.Enabled = 1;
            userRoleEntity.DeletionStateCode = 0;
            string tableName = BaseUserRoleEntity.TableName;
            if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
            {
                tableName = BaseSystemInfo.SystemCode + "UserRole";
            }
            BaseUserRoleManager userRoleManager = new BaseUserRoleManager(this.DbHelper, this.UserInfo, tableName);
            return userRoleManager.Add(userRoleEntity);
        }
        #endregion

        public int AddToRole(string userId, string[] roleIds)
        {
            int returnValue = 0;
            for (int i = 0; i < roleIds.Length; i++)
            {
                this.AddToRole(userId, roleIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int AddToRole(string[] userIds, string roleId)
        {
            int returnValue = 0;
            for (int i = 0; i < userIds.Length; i++)
            {
                this.AddToRole(userIds[i], roleId);
                returnValue++;
            }
            return returnValue;
        }

        public int AddToRole(string[] userIds, string[] roleIds)
        {
            int returnValue = 0;
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < roleIds.Length; j++)
                {
                    this.AddToRole(userIds[i], roleIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  从角色中删除员工
        //

        #region public int RemoveFormRole(string userId, string roleId) 撤销角色权限
        /// <summary>
        /// 从角色中删除员工
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>影响行数</returns>
        public int RemoveFormRole(string userId, string roleId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseUserRoleEntity.FieldUserId, userId));
            parameters.Add(new KeyValuePair<string, object>(BaseUserRoleEntity.FieldRoleId, roleId));
            string tableName = BaseUserRoleEntity.TableName;
            if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
            {
                tableName = BaseSystemInfo.SystemCode + "UserRole";
            }
            BaseUserRoleManager userRoleManager = new BaseUserRoleManager(this.DbHelper, this.UserInfo, tableName);
            return userRoleManager.Delete(parameters);
        }
        #endregion

        public int RemoveFormRole(string userId, string[] roleIds)
        {
            int returnValue = 0;
            for (int i = 0; i < roleIds.Length; i++)
            {
                returnValue += this.RemoveFormRole(userId, roleIds[i]);
            }
            return returnValue;
        }

        public int RemoveFormRole(string[] userIds, string roleId)
        {
            int returnValue = 0;
            for (int i = 0; i < userIds.Length; i++)
            {
                // 删除用户角色
                returnValue += this.RemoveFormRole(userIds[i], roleId);
                // 如果该角色是用户默认角色，将用户默认角色置空
                this.SetProperty(new KeyValuePair<string, object>(BaseUserEntity.FieldId, userIds[i]), new KeyValuePair<string, object>(BaseUserEntity.FieldRoleId, roleId), new KeyValuePair<string, object>(BaseUserEntity.FieldRoleId, null));
            }
            return returnValue;
        }

        public int RemoveFormRole(string[] userIds, string[] roleIds)
        {
            int returnValue = 0;
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < roleIds.Length; j++)
                {
                    returnValue += this.RemoveFormRole(userIds[i], roleIds[j]);
                }
            }
            return returnValue;
        }
    }
}