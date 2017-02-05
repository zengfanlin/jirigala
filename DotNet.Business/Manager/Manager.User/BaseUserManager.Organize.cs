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
        /// <summary>
        /// 用户是否在某部门
        /// </summary>
        /// <param name="organizeName">部门名称</param>
        /// <returns>存在</returns>
        public bool IsInOrganize(string organizeName)
        {
            return IsInOrganize(this.UserInfo.Id, organizeName);
        }

        /// <summary>
        /// 用户是否在某部门
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="organizeName">部门名称</param>
        /// <returns>存在</returns>
        public bool IsInOrganize(string userId, string organizeName)
        {
            bool returnValue = false;
            // 把部门的主键找出来
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldFullName, organizeName));
            parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldDeletionStateCode, 0));
            BaseOrganizeManager organizeManager = new BaseOrganizeManager(this.UserInfo);
            string organizeId = organizeManager.GetId(parameters);
            if (string.IsNullOrEmpty(organizeId))
            {
                return returnValue;
            }
            // 用户组织机构关联关系
            string[] organizeIds = GetAllOrganizeIds(userId);
            // 用户的部门是否存在这些部门里
            returnValue = StringUtil.Exists(organizeIds, organizeId);         
            return returnValue;
        }


        #region public DataTable GetDataTableByDepartment(string departmentId)
        /// <summary>
        /// 按部门获取部门用户
        /// </summary>
        /// <param name="departmentId">部门主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByDepartment(string departmentId)
        {
            string sqlQuery = " SELECT " + BaseUserEntity.TableName + ".* "
                // + " ,(SELECT " + BaseOrganizeEntity.FieldCode + " FROM " + BaseOrganizeEntity.TableName + " WHERE Id = " + BaseUserEntity.TableName + ".CompanyId) AS CompanyCode"
                // + " ,(SELECT " + BaseOrganizeEntity.FieldFullName + " FROM " + BaseOrganizeEntity.TableName + " WHERE Id = " + BaseUserEntity.TableName + ".CompanyId) AS CompanyFullname "
                // + " ,(SELECT " + BaseOrganizeEntity.FieldCode + " From " + BaseOrganizeEntity.TableName + " WHERE Id = " + BaseUserEntity.TableName + ".DepartmentId) AS DepartmentCode"
                // + " ,(SELECT " + BaseOrganizeEntity.FieldFullName + " FROM " + BaseOrganizeEntity.TableName + " WHERE Id = " + BaseUserEntity.TableName + ".DepartmentId) AS DepartmentName "
                // + " ,(SELECT " + BaseRoleEntity.FieldRealName + " FROM " + BaseRoleEntity.TableName + " WHERE Id = RoleId) AS RoleName "
                + " FROM " + BaseUserEntity.TableName;

            sqlQuery += " WHERE (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDeletionStateCode + " = 0 ";
            sqlQuery += " AND " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldEnabled + " = 1 ) ";

            if (!String.IsNullOrEmpty(departmentId))
            {
                // 从用户表
                sqlQuery += " AND ((" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDepartmentId + " = '" + departmentId + "') ";
                // 从兼职表读取用户 
                sqlQuery += " OR " + BaseUserEntity.FieldId + " IN ("
                        + " SELECT " + BaseUserOrganizeEntity.FieldUserId
                        + "   FROM " + BaseUserOrganizeEntity.TableName
                        + "  WHERE (" + BaseUserOrganizeEntity.TableName + "." + BaseUserOrganizeEntity.FieldDeletionStateCode + " = 0 ) "
                        + "       AND (" + BaseUserOrganizeEntity.TableName + "." + BaseUserOrganizeEntity.FieldDepartmentId + " = '" + departmentId + "'))) ";

            }
            sqlQuery += " ORDER BY " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldSortCode;
            return DbHelper.Fill(sqlQuery);
        }
        #endregion

        #region public DataTable GetDataTableByOrganizes(string[] organizeIds) 按工作组、部门、公司获用户列表
        /// <summary>
        /// 按工作组、部门、公司获用户列表
        /// </summary>
        /// <param name="organizeIds">主键数组</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByOrganizes(string[] organizeIds)
        {
            string organizeList = BaseBusinessLogic.ObjectsToList(organizeIds);
            string sqlQuery = " SELECT * "
                + " FROM " + BaseUserEntity.TableName
                // 从用户表里去找
                + " WHERE (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDeletionStateCode + " = 0 ) "
                + "       AND (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldWorkgroupId + " IN ( " + organizeList + ") "
                + "       OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDepartmentId + " IN (" + organizeList + ") "
                + "       OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldSubCompanyId + " IN (" + organizeList + ") "
                + "       OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldCompanyId + " IN (" + organizeList + ")) "
                // 从用户兼职表里去取用户
                + " OR " + BaseUserEntity.FieldId + " IN ("
                        + " SELECT " + BaseUserOrganizeEntity.FieldUserId
                        + "   FROM " + BaseUserOrganizeEntity.TableName
                        + "  WHERE (" + BaseUserOrganizeEntity.TableName + "." + BaseUserOrganizeEntity.FieldDeletionStateCode + " = 0 ) "
                        + "       AND (" + BaseUserOrganizeEntity.TableName + "." + BaseUserOrganizeEntity.FieldWorkgroupId + " IN ( " + organizeList + ") "
                        + "       OR " + BaseUserOrganizeEntity.TableName + "." + BaseUserOrganizeEntity.FieldDepartmentId + " IN (" + organizeList + ") "
                        + "       OR " + BaseUserOrganizeEntity.TableName + "." + BaseUserOrganizeEntity.FieldCompanyId + " IN (" + organizeList + "))) "
                + " ORDER BY " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldSortCode;
            return DbHelper.Fill(sqlQuery);
        }
        #endregion

        public DataTable GetChildrenUsers(string organizeId)
        {
            string[] organizeIds = null;
            BaseOrganizeManager organizeManager = new BaseOrganizeManager(this.DbHelper, this.UserInfo);
            switch (DbHelper.CurrentDbType)
            {
                case CurrentDbType.Access:
                case CurrentDbType.SqlServer:
                    string organizeCode = organizeManager.GetCodeById(organizeId);
                    organizeIds = organizeManager.GetChildrensIdByCode(BaseOrganizeEntity.FieldCode, organizeCode);
                    break;
                case CurrentDbType.Oracle:
                    organizeIds = organizeManager.GetChildrensId(BaseOrganizeEntity.FieldId, organizeId, BaseOrganizeEntity.FieldParentId);
                    break;
            }
            return this.GetDataTableByOrganizes(organizeIds);
        }

        public string[] GetUserIds(string organizeId)
        {
            // 要注意不能重复发信息，只能发一次。
            string[] companyUsers = null; // 按公司查找用户
            string[] departmentUsers = null; // 按部门查找用户
            string[] workgroupUsers = null; // 按工作组查找用户
            if (!String.IsNullOrEmpty(organizeId))
            {
                // 这里获得的是用户主键，不是员工主键
                BaseStaffManager staffManager = new BaseStaffManager(DbHelper);
                companyUsers = staffManager.GetIds(new KeyValuePair<string, object>(BaseStaffEntity.FieldCompanyId, organizeId));
                departmentUsers = staffManager.GetIds(new KeyValuePair<string, object>(BaseStaffEntity.FieldDepartmentId, organizeId));
                workgroupUsers = staffManager.GetIds(new KeyValuePair<string, object>(BaseStaffEntity.FieldWorkgroupId, organizeId));
            }
            string[] userIds = StringUtil.Concat(companyUsers, departmentUsers, workgroupUsers);
            return userIds;
        }

        public string[] GetUserIds(string[] organizeIds, string[] roleIds)
        {
            // 要注意不能重复发信息，只能发一次。
            string[] companyUsers = null; // 按公司查找用户
            string[] departmentUsers = null; // 按部门查找用户
            string[] workgroupUsers = null; // 按工作组查找用户
            if (organizeIds != null)
            {
                // 这里获得的是用户主键，不是员工主键
                companyUsers = this.GetProperties(BaseUserEntity.FieldCompanyId, organizeIds, BaseUserEntity.FieldId);
                departmentUsers = this.GetProperties(BaseUserEntity.FieldDepartmentId, organizeIds, BaseUserEntity.FieldId);
                workgroupUsers = this.GetProperties(BaseUserEntity.FieldWorkgroupId, organizeIds, BaseUserEntity.FieldId);
            }
            string[] roleUsers = null;
            if (roleIds != null)
            {
                BaseUserManager userManager = new BaseUserManager(DbHelper);
                roleUsers = userManager.GetUserIds(roleIds);
            }
            string[] userIds = StringUtil.Concat(companyUsers, departmentUsers, workgroupUsers, roleUsers);
            return userIds;
        }

        public string[] GetUserIds(string[] userIds, string[] organizeIds, string[] roleIds)
        {
            return StringUtil.Concat(userIds, this.GetUserIds(organizeIds, roleIds));
        }

        #region public DataTable SearchByDepartment(string departmentId, string searchValue)  按部门获取部门用户,包括子部门的用户
        /// <summary>
        /// 按部门获取部门用户,包括子部门的用户
        /// </summary>
        /// <param name="departmentId">部门主键</param>
        /// <returns>数据表</returns>
        public DataTable SearchByDepartment(string departmentId, string searchValue)
        {
            string sqlQuery = " SELECT " + BaseUserEntity.TableName + ".* "
                + " FROM " + BaseUserEntity.TableName;
            sqlQuery += " WHERE (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDeletionStateCode + " = 0 ";
            sqlQuery += " AND " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldEnabled + " = 1 ) ";
            if (!String.IsNullOrEmpty(departmentId))
            {
                /*
                用非递归调用的建议方法
                sqlQuery += " AND " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDepartmentId 
                    + " IN ( SELECT " + BaseOrganizeEntity.FieldId 
                    + " FROM " + BaseOrganizeEntity.TableName 
                    + " WHERE " + BaseOrganizeEntity.FieldId + " = " + departmentId + " OR " + BaseOrganizeEntity.FieldParentId + " = " + departmentId + ")";
                */
                BaseOrganizeManager organizeManager = new BaseOrganizeManager(this.DbHelper, this.UserInfo);
                string[] organizeIds = organizeManager.GetChildrensId(BaseOrganizeEntity.FieldId, departmentId, BaseOrganizeEntity.FieldParentId);
                if (organizeIds != null && organizeIds.Length > 0)
                {
                    sqlQuery += " AND (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldCompanyId + " IN (" + StringUtil.ArrayToList(organizeIds) + ")"
                     + " OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDepartmentId + " IN (" + StringUtil.ArrayToList(organizeIds) + ")"
                     + " OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldWorkgroupId + " IN (" + StringUtil.ArrayToList(organizeIds) + "))";
                }
            }
            List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();
            searchValue = searchValue.Trim();
            if (!String.IsNullOrEmpty(searchValue))
            {
                sqlQuery += " AND (" + BaseUserEntity.FieldUserName + " LIKE " + DbHelper.GetParameter(BaseUserEntity.FieldUserName);
                sqlQuery += " OR " + BaseUserEntity.FieldCode + " LIKE " + DbHelper.GetParameter(BaseUserEntity.FieldCode);
                sqlQuery += " OR " + BaseUserEntity.FieldRealName + " LIKE " + DbHelper.GetParameter(BaseUserEntity.FieldRealName);
                sqlQuery += " OR " + BaseUserEntity.FieldDepartmentName + " LIKE " + DbHelper.GetParameter(BaseUserEntity.FieldDepartmentName) + ")";
                if (searchValue.IndexOf("%") < 0)
                {
                    searchValue = "%" + searchValue + "%";
                }
                dbParameters.Add(DbHelper.MakeParameter(BaseUserEntity.FieldUserName, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseUserEntity.FieldCode, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseUserEntity.FieldRealName, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseUserEntity.FieldDepartmentName, searchValue));
            }
            sqlQuery += " ORDER BY " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldSortCode;
            return DbHelper.Fill(sqlQuery, dbParameters.ToArray());
        }
        #endregion

        #region public string[] GetOrganizeIds(string userId) 获取员工的角色主键数组
        /// <summary>
        /// 获取员工的角色主键数组
        /// </summary>
        /// <param name="userId">员工代吗</param>
        /// <returns>主键数组</returns>
        public string[] GetAllOrganizeIds(string userId)
        {
            // 被删除的不应该显示出来
            string sqlQuery = @" SELECT CompanyId AS Id
                                  FROM BaseUser
                                 WHERE DeletionStateCode = 0 AND Enabled =1 AND CompanyId IS NOT NULL  AND (Id = {userId})
                                 UNION
                                SELECT DepartmentId AS Id
                                  FROM BaseUser
                                 WHERE DeletionStateCode = 0 AND Enabled =1  AND DepartmentId IS NOT NULL AND (Id = {userId})
                                 UNION
                                SELECT WorkgroupId AS Id
                                  FROM BaseUser
                                 WHERE DeletionStateCode = 0 AND Enabled =1  AND WorkgroupId IS NOT NULL AND (Id = {userId})
                                 UNION
                                SELECT CompanyId AS Id
                                  FROM BaseUserOrganize
                                 WHERE DeletionStateCode = 0 AND Enabled =1  AND CompanyId IS NOT NULL AND (UserId = {userId})
                                 UNION
                                SELECT DepartmentId AS Id
                                  FROM BaseUserOrganize
                                 WHERE DeletionStateCode = 0 AND Enabled =1  AND DepartmentId IS NOT NULL AND (UserId = {userId})
                                 UNION
                                SELECT WorkgroupId AS Id
                                  FROM BaseUserOrganize
                                 WHERE DeletionStateCode = 0 AND Enabled =1  AND WorkgroupId IS NOT NULL AND (UserId = {userId}) ";
            sqlQuery = sqlQuery.Replace("{userId}", userId);
            DataTable dataTable = DbHelper.Fill(sqlQuery);
            return BaseBusinessLogic.FieldToArray(dataTable, BaseUserEntity.FieldId);
        }
        #endregion
    }
}