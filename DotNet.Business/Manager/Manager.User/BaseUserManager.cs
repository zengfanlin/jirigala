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
    ///     2011.10.17 版本：4.5 JiRiGaLa   拆分代码，按核心业务逻辑进行划分，简化代码。
    ///     2011.10.05 版本：4.4 张广梁     增加 public DataTable SearchByDepartment(string departmentId,string searchValue) ，获得部门和子部门的人员
    ///     2011.09.22 版本：4.3 张广梁     完善public DataTable GetAuthorizeDT(string permissionItemCode, string userId = null) 增加有效期的验证
    ///     2011.07.21 版本：4.2 zgl        修正检查IP和MAC的业务逻辑，如果没有设置IP或MAC时不执行检查
    ///     2011.07.05 版本：4.1 zgl        增加几个检查Ip的方法。
    ///     2011.07.04 版本：4.0 JiRiGaLa	用户名、密码的登录程序改进。
    ///     2011.06.29 版本：3.9 JiRiGaLa	每次登录时是否产生了一个新的OpenId。
    ///     2011.06.14 版本：3.8 JiRiGaLa	用户登录时间限制、锁定日期限制。
    ///     2011.02.12 版本：3.7 JiRiGaLa	按备注也可以查询。
    ///     2009.09.11 版本：3.6 JiRiGaLa	用户的审核状态功能改进。
    ///     2008.05.13 版本：3.6 JiRiGaLa	登录时数据获取进行了优化配置。
    ///     2008.03.18 版本：3.4 JiRiGaLa	登录、重新登录、扮演时的在线状态进行更新。
    ///     2007.10.02 版本：3.3 JiRiGaLa	登录限制改进。
    ///     2007.10.01 版本：3.2 JiRiGaLa	参数传递方式改进 IDbHelper dbHelper, BaseUserInfo userInfo。
    ///     2007.06.11 版本：3.1 JiRiGaLa	设置密码，修改密码进行大修改。
    ///     2006.12.15 版本：3.0 JiRiGaLa	程序排版重新整理一次。
    ///     2006.12.11 版本：2.2 JiRiGaLa	登录部分写入日志。
    ///     2006.12.02 版本：2.1 JiRiGaLa	登录部分的主键改进。
    ///     2006.11.23 版本：2.0 JiRiGaLa	结构优化整理。
    ///		2006.02.02 版本：1.0 JiRiGaLa	书写格式进行整理。
    ///		2005.01.23 版本：1.0 JiRiGaLa	主键整理。
    /// 
    /// 版本：4.5
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.10.17</date>
    /// </author> 
    /// </summary>
    public partial class BaseUserManager : BaseManager
    {
        public BaseUserInfo ConvertToUserInfo(BaseUserEntity userEntity)
        {
            BaseUserInfo userInfo = new BaseUserInfo();
            return ConvertToUserInfo(userEntity, userInfo);
        }

        public BaseUserInfo ConvertToUserInfo(BaseUserEntity userEntity, BaseUserInfo userInfo)
        {
            userInfo.OpenId = userEntity.OpenId;
            userInfo.Id = userEntity.Id.ToString();
            userInfo.Code = userEntity.Code;
            userInfo.UserName = userEntity.UserName;
            userInfo.RealName = userEntity.RealName;
            userInfo.RoleId = userEntity.RoleId;
            userInfo.CompanyId = userEntity.CompanyId;
            userInfo.CompanyName = userEntity.CompanyName;
            userInfo.SubCompanyId = userEntity.SubCompanyId;
            userInfo.SubCompanyName = userEntity.SubCompanyName;
            userInfo.DepartmentId = userEntity.DepartmentId;
            userInfo.DepartmentName = userEntity.DepartmentName;
            userInfo.WorkgroupId = userEntity.WorkgroupId;
            userInfo.WorkgroupName = userEntity.WorkgroupName;
            if (userEntity.SecurityLevel == null)
            {
                userEntity.SecurityLevel = 0;
            }
            userInfo.SecurityLevel = (int)userEntity.SecurityLevel;
            if (userEntity.RoleId != null)
            {
                // 获取角色名称
                BaseRoleManager roleManager = new BaseRoleManager(DbHelper, UserInfo);
                BaseRoleEntity roleEntity = roleManager.GetEntity(userEntity.RoleId);
                if (roleEntity.Id > 0)
                {
                    userInfo.RoleName = roleEntity.RealName;
                }
            }
            return userInfo;
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userCode">用户编号</param>
        public BaseUserEntity GetEntityByCode(string userCode)
        {
            BaseUserEntity userEntity = null;

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldCode, userCode));
            parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldDeletionStateCode, 0));
            DataTable dt = this.GetDataTable(parameters);
            if (dt.Rows.Count > 0)
            {
                userEntity = new BaseUserEntity(dt);
            }
            return userEntity;
        }

        /// <summary>
        /// 判断用户是否已经登录了？
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>是否已经登录了</returns>
        public bool UserIsLogOn(BaseUserInfo userInfo)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldId, userInfo.Id));
            parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldOpenId, userInfo.OpenId));
            parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldDeletionStateCode, 0));
            string id = this.GetId(parameters);
            if (string.IsNullOrEmpty(id))
            {
                return false;
            }
            if (!userInfo.Id.Equals(id))
            {
                return false;
            }
            return true;
        }

        public bool IsAdministrator(string userId)
        {
            // 用户是超级管理员
            if (userId.Equals("Administrator"))
            {
                return true;
            }
            BaseUserEntity userEntity = this.GetEntity(userId);
            if (userEntity.Code != null && userEntity.Code.Equals("Administrator"))
            {
                return true;
            }
            if (userEntity.UserName != null && userEntity.UserName.Equals("Administrator"))
            {
                return true;
            }

            string tableName = BaseUserRoleEntity.TableName;
            if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
            {
                tableName = BaseSystemInfo.SystemCode + "Role";
            }
            // 用户的默认角色是超级管理员
            BaseRoleManager roleManager = new BaseRoleManager(this.DbHelper, this.UserInfo, tableName);
            // 用户默认角色是否为超级管理员
            BaseRoleEntity roleEntity = null;
            if (userEntity.RoleId != null)
            {
                roleEntity = roleManager.GetEntity(userEntity.RoleId);
                if (roleEntity.Code != null && roleEntity.Code.Equals(DefaultRole.Administrators.ToString()))
                {
                    return true;
                }
            }

            // 用户在超级管理员群里
            string[] roleIds = this.GetAllRoleIds(userId);
            for (int i = 0; i < roleIds.Length; i++)
            {
                if (roleIds[i].Equals(DefaultRole.Administrators.ToString()))
                {
                    return true;
                }
                roleEntity = roleManager.GetEntity(roleIds[i]);
                if (roleEntity.Code != null && roleEntity.Code.Equals(DefaultRole.Administrators.ToString()))
                {
                    return true;
                }
            }
            return false;
        }

        #region public BaseUserInfo AccountActivation(string openId, out string statusCode)
        /// <summary>
        /// 激活帐户
        /// </summary>
        /// <param name="openId">唯一识别码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>用户实体</returns>
        public BaseUserInfo AccountActivation(string openId, out string statusCode)
        {
            // 1.用户是否存在？
            BaseUserInfo userInfo = null;
            // 用户没有找到状态
            statusCode = StatusCode.UserNotFound.ToString();
            // 检查是否有效的合法的参数
            if (!String.IsNullOrEmpty(openId))
            {
                BaseUserManager userManager = new BaseUserManager(DbHelper);
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldOpenId, openId));
                parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldDeletionStateCode, 0));
                DataTable dataTable = userManager.GetDataTable(parameters);
                if (dataTable.Rows.Count == 1)
                {
                    BaseUserEntity userEntity = new BaseUserEntity(dataTable);
                    // 3.用户是否被锁定？
                    if (userEntity.Enabled == 0)
                    {
                        statusCode = StatusCode.UserLocked.ToString();
                        return userInfo;
                    }
                    if (userEntity.Enabled == 1)
                    {
                        // 2.用户是否已经被激活？
                        statusCode = StatusCode.UserIsActivate.ToString();
                        return userInfo;
                    }
                    if (userEntity.Enabled == -1)
                    {
                        // 4.成功激活用户
                        statusCode = StatusCode.OK.ToString();
                        userManager.SetProperty(new KeyValuePair<string, object>(BaseUserEntity.FieldId, userEntity.Id), new KeyValuePair<string, object>(BaseUserEntity.FieldEnabled, 1));
                        return userInfo;
                    }
                }
            }
            return userInfo;
        }
        #endregion

        #region private int ChangeOnLine(string id) 登录、重新登录、扮演时的在线状态进行更新
        /// <summary>
        /// 登录、重新登录、扮演时的在线状态进行更新
        /// </summary>
        /// <param name="id">当前用户</param>
        /// <returns>是否在线</returns>
        private int ChangeOnLine(string id)
        {
            int returnValue = 0;
            // 是自己在线，然后重新登录为别人时，需要把自己注销掉
            if (UserInfo != null && !string.IsNullOrEmpty(UserInfo.Id))
            {
                if (!string.IsNullOrEmpty(UserInfo.OpenId) && !UserInfo.Id.Equals(id))
                {
                    // 要设置为下线状态，这里要判断游客状态
                    returnValue += this.OnExit(UserInfo.Id);
                }
            }
            // 用户在线
            returnValue += this.OnLine(id);

            return returnValue;
        }
        #endregion

        #region public BaseUserInfo Impersonation(string id) 扮演用户
        /// <summary>
        /// 扮演用户
        /// </summary>
        /// <param name="id">用户主键</param>
        /// <returns>用户类</returns>
        public BaseUserInfo Impersonation(string id, out string statusCode)
        {
            BaseUserInfo userInfo = null;
            // 获得登录信息
            DataTable dataTableLogOn = this.GetDataTableById(id);
            BaseUserEntity userEntity = new BaseUserEntity();
            userEntity.GetSingle(dataTableLogOn);
            // 只允许登录一次，需要检查是否自己重新登录了，或者自己扮演自己了
            if (!UserInfo.Id.Equals(id))
            {
                if (BaseSystemInfo.CheckOnLine)
                {
                    if (userEntity.UserOnLine > 0)
                    {
                        statusCode = StatusCode.ErrorOnLine.ToString();
                        return userInfo;
                    }
                }
            }
            userInfo = this.ConvertToUserInfo(userEntity);
            if (userEntity.IsStaff.Equals("1"))
            {
                // 获得员工的信息
                BaseStaffEntity staffEntity = new BaseStaffEntity();
                BaseStaffManager staffManager = new BaseStaffManager(DbHelper, UserInfo);
                DataTable dataTableStaff = staffManager.GetDataTableById(id);
                staffEntity.GetSingle(dataTableStaff);
                userInfo = staffManager.ConvertToUserInfo(staffEntity, userInfo);
            }
            statusCode = StatusCode.OK.ToString();
            // 登录、重新登录、扮演时的在线状态进行更新
            this.ChangeOnLine(id);
            return userInfo;
        }
        #endregion

        #region public DataTable GetDataTable() 获取列表
        /// <summary>
        /// 获取列表
        /// </summary>
        /// <returns>数据表</returns>
        public DataTable GetDataTable()
        {
            string sqlQuery = " SELECT " + BaseUserEntity.TableName + ".* "
                            + "        , ( SELECT " + BaseRoleEntity.FieldRealName
                                        + "  FROM " + BaseRoleEntity.TableName
                                        + " WHERE " + BaseRoleEntity.FieldId + " = " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldRoleId + ") AS RoleName "
                            + "   FROM " + BaseUserEntity.TableName
                            + " WHERE " + BaseUserEntity.FieldDeletionStateCode + "= 0 "
                            + " AND " + BaseUserEntity.FieldIsVisible + "= 1 "
                //+ "       AND " + BaseUserEntity.FieldEnabled + "= 1 "  //如果Enabled = 1，只显示有效用户
                            + " ORDER BY " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldSortCode;
            return DbHelper.Fill(sqlQuery);
        }
        #endregion

        public DataTable GetDataTableByIds(string[] userIds)
        {
            string sqlQuery = " SELECT " + BaseUserEntity.TableName + ".* "
                            + "        , ( SELECT " + BaseRoleEntity.FieldRealName
                                        + "  FROM " + BaseRoleEntity.TableName
                                        + " WHERE " + BaseRoleEntity.FieldId + " = " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldRoleId + ") AS RoleName "
                            + "   FROM " + BaseUserEntity.TableName;
            // 是否需要过滤数据，要考虑安全性
            //if (userIds != null && userIds.Length > 0)
            //{
            sqlQuery += " WHERE Id IN (" + BaseBusinessLogic.ObjectsToList(userIds) + ")";
            //}
            sqlQuery += " ORDER BY " + BaseUserEntity.FieldSortCode;
            return DbHelper.Fill(sqlQuery);
        }

        #region private int ResetVisitInfo(string id) 重置访问情况
        /// <summary>
        /// 重置访问情况
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        private int ResetVisitInfo(string id)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            sqlBuilder.SetNull(BaseUserEntity.FieldFirstVisit);
            sqlBuilder.SetNull(BaseUserEntity.FieldPreviousVisit);
            sqlBuilder.SetNull(BaseUserEntity.FieldLastVisit);
            sqlBuilder.SetValue(BaseUserEntity.FieldLogOnCount, 0);
            sqlBuilder.SetWhere(BaseUserEntity.FieldId, id);
            return sqlBuilder.EndUpdate();
        }
        #endregion

        #region public int ResetVisitInfo(string[] ids) 重置
        /// <summary>
        /// 重置
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int ResetVisitInfo(string[] ids)
        {
            int returnValue = 0;
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i].Length > 0)
                {
                    returnValue += this.ResetVisitInfo(ids[i]);
                }
            }
            return returnValue;
        }
        #endregion

        #region private int ResetData() 重置数据
        /// <summary>
        /// 重置数据
        /// </summary>
        /// <returns>影响行数</returns>
        private int ResetData()
        {
            // 删除不存在的数据，进行数据同步
            int returnValue = 0;
            string sqlQuery = " DELETE FROM " + BaseUserEntity.TableName
                            + " WHERE Id NOT IN (SELECT Id FROM " + BaseStaffEntity.TableName + ") ";
            returnValue += DbHelper.ExecuteNonQuery(sqlQuery);
            // 更新排序顺序情况
            sqlQuery = " UPDATE " + BaseUserEntity.TableName
                     + " SET SortCode = " + BaseStaffEntity.TableName + "." + BaseStaffEntity.FieldSortCode
                     + " FROM " + BaseStaffEntity.TableName
                     + " WHERE " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldId + " = " + BaseStaffEntity.TableName + "." + BaseStaffEntity.FieldId;
            returnValue += DbHelper.ExecuteNonQuery(sqlQuery);
            return returnValue;
        }
        #endregion

        #region private int ResetVisitInfo() 重置访问情况
        /// <summary>
        /// 重置访问情况
        /// </summary>
        /// <returns>影响行数</returns>
        private int ResetVisitInfo()
        {
            int returnValue = 0;
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            sqlBuilder.SetNull(BaseUserEntity.FieldFirstVisit);
            sqlBuilder.SetNull(BaseUserEntity.FieldPreviousVisit);
            sqlBuilder.SetNull(BaseUserEntity.FieldLastVisit);
            sqlBuilder.SetValue(BaseUserEntity.FieldLogOnCount, 0);
            returnValue = sqlBuilder.EndUpdate();
            return returnValue;
        }
        #endregion

        #region public int Reset() 重新设置数据
        /// <summary>
        /// 重新设置数据
        /// </summary>
        /// <returns>影响行数</returns>
        public int Reset()
        {
            int returnValue = 0;
            returnValue += this.ResetData();
            returnValue += this.ResetVisitInfo();
            return returnValue;
        }
        #endregion

        #region public int CheckUserStaff()
        /// <summary>
        /// 用户已经被删除的员工的UserId设置为Null，说白了，是需要整理数据
        /// </summary>
        /// <returns>影响行数</returns>
        public int CheckUserStaff()
        {
            string sqlQuery = " UPDATE BaseStaff SET UserId = null WHERE UserId NOT IN ( SELECT Id FROM BASEUSER WHERE DeletionStateCode = 0 ) ";
            return DbHelper.ExecuteNonQuery(sqlQuery);
        }
        #endregion

        /// <summary>
        /// 获取在线人数
        /// </summary>
        public string GetOnLineCount()
        {
            string sqlQuery = " SELECT COUNT(Id) AS UserCount "
                            + "   FROM " + this.CurrentTableName
                            + "  WHERE Enabled = 1 AND UserOnLine = 1";
            return DbHelper.ExecuteScalar(sqlQuery).ToString();
        }

        public string GetLogOnCount(int days)
        {
            string sqlQuery = " SELECT COUNT(Id) AS UserCount "
                            + "   FROM " + this.CurrentTableName
                            + "  WHERE Enabled = 1 AND (DATEADD(d, " + days.ToString() + ", " + BaseUserEntity.FieldLastVisit + ") > " + DbHelper.GetDBNow() + ")";
            return DbHelper.ExecuteScalar(sqlQuery).ToString();
        }

        public string GetRegistrationCount(int days)
        {
            string sqlQuery = " SELECT COUNT(Id) AS UserCount "
                            + "   FROM " + this.CurrentTableName
                            + "  WHERE Enabled = 1 AND (DATEADD(d, " + days.ToString() + ", " + BaseUserEntity.FieldCreateOn + ") > " + DbHelper.GetDBNow() + ")";
            return DbHelper.ExecuteScalar(sqlQuery).ToString();
        }

        #region public override int BatchSave(DataTable dataTable) 批量保存
        /// <summary>
        /// 批量保存
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        public override int BatchSave(DataTable dataTable)
        {
            int returnValue = 0;
            BaseUserEntity userEntity = new BaseUserEntity();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                // 删除状态
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    string id = dataRow[BaseUserEntity.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        returnValue += this.Delete(id);
                    }
                }
                // 被修改过
                if (dataRow.RowState == DataRowState.Modified)
                {
                    string id = dataRow[BaseUserEntity.FieldId, DataRowVersion.Original].ToString();
                    if (!String.IsNullOrEmpty(id))
                    {
                        userEntity.GetFrom(dataRow);
                        returnValue += this.UpdateEntity(userEntity);
                    }
                }
                // 添加状态
                if (dataRow.RowState == DataRowState.Added)
                {
                    userEntity.GetFrom(dataRow);
                    returnValue += this.AddEntity(userEntity).Length > 0 ? 1 : 0;
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
        #endregion

        public DataTable Search(string search = null, string[] roleIds = null, bool? enabled = true, string auditStates = null,string departmentId=null)
        {
            return Search(string.Empty, search, roleIds, enabled, auditStates,departmentId);
        }

        public DataTable Search(string permissionScopeItemCode, string search, string[] roleIds, bool? enabled, string auditStates,string departmentId)
        {
            search = StringUtil.GetSearchString(search);
            string sqlQuery = " SELECT " + BaseUserEntity.TableName + ".* "
                            + "," + BaseRoleEntity.TableName + "." + BaseRoleEntity.FieldRealName + " AS RoleName "
                            + " FROM " + BaseUserEntity.TableName
                            + "      LEFT OUTER JOIN " + BaseRoleEntity.TableName
                            + "      ON " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldRoleId + " = " + BaseRoleEntity.TableName + "." + BaseRoleEntity.FieldId
                // 被删除的排出在外比较好一些
                            + " WHERE " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDeletionStateCode + " = 0 "
                            + " AND " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldIsVisible + " = 1 ";
            if (!String.IsNullOrEmpty(search))
            {
                sqlQuery += " AND (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldUserName + " LIKE '" + search + "'"
                            + " OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldCode + " LIKE '" + search + "'"
                            + " OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldRealName + " LIKE '" + search + "'"
                            + " OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldQuickQuery + " LIKE '" + search + "'"
                            + " OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDepartmentName + " LIKE '" + search + "'"
                            + " OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDescription + " LIKE '" + search + "')";
            }
            if (!string.IsNullOrEmpty(departmentId))
            {
                BaseOrganizeManager organizeManager = new BaseOrganizeManager(this.DbHelper, this.UserInfo);
                string[] organizeIds = organizeManager.GetChildrensId(BaseOrganizeEntity.FieldId, departmentId, BaseOrganizeEntity.FieldParentId);
                if (organizeIds != null && organizeIds.Length > 0)
                {
                    sqlQuery += " AND (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldCompanyId + " IN (" + StringUtil.ArrayToList(organizeIds) + ")"
                     + " OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDepartmentId + " IN (" + StringUtil.ArrayToList(organizeIds) + ")"
                     + " OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldWorkgroupId + " IN (" + StringUtil.ArrayToList(organizeIds) + "))";
                }
            }
            if (!String.IsNullOrEmpty(auditStates))
            {
                sqlQuery += " AND (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldAuditStatus + " = '" + auditStates + "')";
            }
            if (enabled != null)
            {
                sqlQuery += " AND (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldEnabled + " = " + ((bool)enabled ? 1:0) + ")";
            }
            if ((roleIds != null) && (roleIds.Length > 0))
            {
                string roles = StringUtil.ArrayToList(roleIds, "'");
                sqlQuery += " AND (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldRoleId + " IN (" + roles + ") ";
                sqlQuery += "      OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldId + " IN (" + "SELECT " + BaseUserRoleEntity.FieldUserId + " FROM " + BaseUserRoleEntity.TableName + " WHERE " + BaseUserRoleEntity.FieldRoleId + " IN (" + roles + ")" + "))";
            }

            // 是否过滤用户， 获得组织机构列表， 这里需要一个按用户过滤得功能
            if ((!UserInfo.IsAdministrator) && (BaseSystemInfo.UsePermissionScope))
            {
                // string permissionScopeItemCode = "Resource.ManagePermission";
                BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(this.DbHelper, this.UserInfo);
                string permissionScopeItemId = permissionItemManager.GetId(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldCode, permissionScopeItemCode));
                if (!string.IsNullOrEmpty(permissionScopeItemId))
                {
                    // 从小到大的顺序进行显示，防止错误发生
                    BaseUserScopeManager userPermissionScopeManager = new BaseUserScopeManager(this.DbHelper, this.UserInfo);
                    string[] organizeIds = userPermissionScopeManager.GetOrganizeIds(this.UserInfo.Id, permissionScopeItemId);

                    // 没有任何数据权限
                    if (StringUtil.Exists(organizeIds, ((int)PermissionScope.None).ToString()))
                    {
                        sqlQuery += " AND (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldId + " = NULL ) ";
                    }
                    // 按详细设定的数据
                    if (StringUtil.Exists(organizeIds, ((int)PermissionScope.Detail).ToString()))
                    {
                        BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
                        string[] userIds = permissionScopeManager.GetUserIds(UserInfo.Id, permissionScopeItemCode);
                        sqlQuery += " AND (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldId + " IN (" + BaseBusinessLogic.ObjectsToList(userIds) + ")) ";
                    }
                    // 自己的数据，仅本人
                    if (StringUtil.Exists(organizeIds, ((int)PermissionScope.User).ToString()))
                    {
                        sqlQuery += " AND (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldId + " = " + this.UserInfo.Id + ") ";
                    }
                    // 用户所在工作组数据
                    if (StringUtil.Exists(organizeIds, ((int)PermissionScope.UserWorkgroup).ToString()))
                    {
                        sqlQuery += " AND (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldWorkgroupId + " = " + this.UserInfo.WorkgroupId + ") ";
                    }
                    // 用户所在部门数据
                    if (StringUtil.Exists(organizeIds, ((int)PermissionScope.UserDepartment).ToString()))
                    {
                        sqlQuery += " AND (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDepartmentId + " = " + this.UserInfo.DepartmentId + ") ";
                    }
                    // 用户所在分支机构数据
                    if (StringUtil.Exists(organizeIds, ((int)PermissionScope.UserSubCompany).ToString()))
                    {
                        sqlQuery += " AND (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldSubCompanyId + " = " + this.UserInfo.SubCompanyId + ") ";
                    }
                    // 用户所在公司数据
                    if (StringUtil.Exists(organizeIds, ((int)PermissionScope.UserCompany).ToString()))
                    {
                        sqlQuery += " AND (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldCompanyId + " = " + this.UserInfo.CompanyId + ") ";
                    }
                    // 全部数据，这里就不用设置过滤条件了
                    if (StringUtil.Exists(organizeIds, ((int)PermissionScope.All).ToString()))
                    {
                    }
                }
            }
            sqlQuery += " ORDER BY " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldSortCode;
            return DbHelper.Fill(sqlQuery);
        }

        #region public DataTable GetDataTableByPage(BaseUserInfo userInfo, string departmentId, string searchValue, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = null, string sortDire = null) 分页查询
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="departmentId">部门编号</param>
        /// <param name="searchValue">查询字段</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDire">排序方向</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByPage(BaseUserInfo userInfo, string departmentId,string searchValue, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = null, string sortDire = null)
        {
            string whereConditional = BaseRoleEntity.FieldDeletionStateCode + " = 0 ";

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
                    whereConditional += " AND (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldCompanyId + " IN (" + StringUtil.ArrayToList(organizeIds) + ")"
                     + " OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDepartmentId + " IN (" + StringUtil.ArrayToList(organizeIds) + ")"
                     + " OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldWorkgroupId + " IN (" + StringUtil.ArrayToList(organizeIds) + "))";
                }
            }

            if (!string.IsNullOrEmpty(searchValue))
            {
                searchValue = "'" + StringUtil.GetSearchString(searchValue) + "'";
                whereConditional += " AND (" + BaseUserEntity.FieldRealName + " LIKE " + searchValue;
                whereConditional += " OR " + BaseUserEntity.FieldUserName + " LIKE " + searchValue + ")";
            }
            return GetDataTableByPage(out recordCount, pageIndex, pageSize, sortExpression, sortDire, this.CurrentTableName, whereConditional, "*");
        }

        #endregion
    }
}