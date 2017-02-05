//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

	/// <summary>
    /// BasePermissionScopeManager
	/// 资源权限范围
	///
    ///	修改纪录
    /// 
    ///     组织
    ///      ↓
    ///     角色 → 组织
    ///      ↓
    ///     用户
    ///     
    /// 
    ///     用户能有某种权限的所有员工      public string[] GetUserIds(string managerUserId, string permissionItemCode)
    ///                                     public string GetUserIdsSql(string managerUserId, string permissionItemCode)
    ///     
    ///     用户能有某种权限所有组织机构    public string[] GetOrganizeIds(string managerUserId, string permissionItemCode)
    ///                                     public string GetOrganizeIdsSql(string managerUserId, string permissionItemCode)
    ///     
    ///     用户能有某种权限的所有角色      public string[] GetAllRoleIds(string managerUserId, string permissionItemCode)
    ///                                     public string GetAllRoleIdsSql(string managerUserId, string permissionItemCode)
    ///     
    ///     2011.10.27 版本：4.3 张广梁 增加获得有效的委托列表的方法GetAuthoriedList。
    ///     2011.09.21 版本：4.2 张广梁 增加 public bool HasAuthorized(string[] names, object[] values,string startDate,string endDate)
    ///		2010.07.06 版本：4.1 JiRiGaLa permissionItemCode，permissionItemId 修改为 permissionItemCode，permissionItemId。
    ///		2007.03.03 版本：4.0 JiRiGaLa 核心的外部调用程序进行整理。
    ///		2007.03.03 版本：3.0 JiRiGaLa 调整主键的规范化。
    ///		2007.02.15 版本：2.0 JiRiGaLa 调整主键的规范化。
    ///	    2006.02.12 版本：1.2 JiRiGaLa 调整主键的规范化。
    ///     2005.08.14 版本：1.1 JiRiGaLa 添加了批量添加和批量删除。
    ///     2004.11.19 版本：1.0 JiRiGaLa 主键进行了绝对的优化，这是个好东西啊，平时要多用，用得要灵活些。
    ///     
    /// 版本：3.0
	///
	/// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.03.03</date>
	/// </author>
	/// </summary>
    public partial class BasePermissionScopeManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 是否按编号获得子节点，SQL2005以上或者Oracle数据库按ParentId,Id进行关联 
        /// </summary>
        public static bool UseGetChildrensByCode = false;
        
        #region public bool PermissionScopeExists(string permissionItemId, string resourceCategory, string resourceId, string targetCategory, string targetId) 检查是否存在
        /// <summary>
        /// 检查是否存在
        /// </summary>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="targetCategory">目标分类</param>
        /// <param name="targetId">目标主键</param>
        /// <returns>是否存在</returns>
        public bool PermissionScopeExists(string permissionItemId, string resourceCategory, string resourceId, string targetCategory, string targetId)
        {
            bool returnValue = true;

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, permissionItemId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, resourceCategory));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, resourceId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, targetCategory));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetId, targetId));
            
            // 检查是否存在
            if (!this.Exists(parameters))
            {
                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        public int PermissionScopeDelete(string permissionItemId, string resourceCategory, string resourceId, string targetCategory, string targetId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, resourceCategory));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, resourceId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, targetCategory));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetId, targetId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, permissionItemId));
            return this.Delete(parameters);
        }

        public string AddPermission(string resourceCategory, string resourceId, string targetCategory, string targetId)
        {
            BasePermissionScopeEntity resourcePermissionScope = new BasePermissionScopeEntity();
            resourcePermissionScope.ResourceCategory = resourceCategory;
            resourcePermissionScope.ResourceId = resourceId;
            resourcePermissionScope.TargetCategory = targetCategory;
            resourcePermissionScope.TargetId = targetId;
            resourcePermissionScope.Enabled = 1;
            resourcePermissionScope.DeletionStateCode = 0;
            return this.AddPermission(resourcePermissionScope);
        }

        #region public string AddPermission(BasePermissionScopeEntity resourcePermissionScope)
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="paramObject">对象</param>
        /// <returns>主键</returns>
        public string AddPermission(BasePermissionScopeEntity resourcePermissionScope)
        {
            string returnValue = string.Empty;
            // 检查记录是否重复
            if (!this.PermissionScopeExists(resourcePermissionScope.PermissionId.ToString(), resourcePermissionScope.ResourceCategory, resourcePermissionScope.ResourceId, resourcePermissionScope.TargetCategory, resourcePermissionScope.TargetId))
            {
                returnValue = this.AddEntity(resourcePermissionScope);
            }
            return returnValue;
        }
        #endregion

        /// <summary>
        /// 获得用户的权限范围设置
        /// </summary>
        /// <param name="managerUserId">用户主键</param>
        /// <param name="permissionItemCode">权限范围编号</param>
        /// <returns>用户的权限范围</returns>
        public PermissionScope GetUserPermissionScope(string managerUserId, string permissionItemCode)
        {
            string sqlQuery = this.GetOrganizeIdsSql(managerUserId, permissionItemCode);
            DataTable dataTable = DbHelper.Fill(sqlQuery);            
            string[] organizeIds = BaseBusinessLogic.FieldToArray(dataTable, BasePermissionScopeEntity.FieldTargetId);
            return BaseBusinessLogic.GetPermissionScope(organizeIds);
        }

        // 权限范围的判断

        //
        // 获得被某个权限管理范围内 组织机构的 ID、SQL、List
        //

        #region public string GetOrganizeIdsSql(string managerUserId, string permissionItemCode) 按某个权限获取组织机构 Sql
        /// <summary>
        /// 按某个权限获取组织机构 Sql
        /// </summary>
        /// <param name="managerUserId">管理用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>Sql</returns>
        public string GetOrganizeIdsSql(string managerUserId, string permissionItemCode)
        {
            BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(DbHelper);
            string permissionItemId = permissionItemManager.GetIdByCode(permissionItemCode);

            string sqlQuery = string.Empty;
            sqlQuery = " SELECT " + BasePermissionScopeEntity.FieldTargetId
                     + "   FROM " + BasePermissionScopeEntity.TableName
                // 有效的，并且不为空的组织机构主键
                     + "  WHERE (" + BasePermissionScopeEntity.FieldTargetCategory + " = '" + BaseOrganizeEntity.TableName + "') "
                     + "        AND ( " + BasePermissionScopeEntity.TableName + "." + BasePermissionScopeEntity.FieldDeletionStateCode + " = 0) "
                     + "        AND ( " + BasePermissionScopeEntity.TableName + "." + BasePermissionScopeEntity.FieldEnabled + " = 1) "
                     + "        AND ( " + BasePermissionScopeEntity.TableName + "." + BasePermissionScopeEntity.FieldTargetId + " IS NOT NULL) "
                // 自己直接由相应权限的组织机构
                     + "        AND ((" + BasePermissionScopeEntity.FieldResourceCategory + " = '" + BaseUserEntity.TableName + "' "
                     + "        AND " + BasePermissionScopeEntity.FieldResourceId + " = '" + managerUserId + "')"
                     + " OR (" + BasePermissionScopeEntity.FieldResourceCategory + " = '" + BaseRoleEntity.TableName + "' "
                     + "       AND " + BasePermissionScopeEntity.FieldResourceId + " IN ( "
                // 获得属于那些角色有相应权限的组织机构
                     + " SELECT " + BaseUserRoleEntity.FieldRoleId
                     + "   FROM " + BaseUserRoleEntity.TableName
                     + "  WHERE " + BaseUserRoleEntity.FieldUserId + " = '" + managerUserId + "'"
                     + "        AND " + BaseUserRoleEntity.FieldDeletionStateCode + " = 0 "
                     + "        AND " + BaseUserRoleEntity.FieldEnabled + " = 1"
                // 修正不会读取用户默认角色权限域范围BUG
                     + "  Union SELECT " + BaseUserEntity.FieldRoleId
                     + "  FROM " + BaseUserEntity.TableName
                     + "  WHERE " + BaseUserEntity.FieldId + " = '" + managerUserId + "'"
                     + "        AND " + BaseUserEntity.FieldDeletionStateCode + " = 0 "
                     + "        AND " + BaseUserEntity.FieldEnabled + " = 1"
                    + "))) "
                // 并且是指定的本权限
                     + " AND (" + BasePermissionScopeEntity.FieldPermissionItemId + " = '" + permissionItemId + "') ";
            return sqlQuery;
        }
        #endregion

        #region public string GetOrganizeIdsSqlByParentId(string managerUserId, string permissionItemCode) 按某个权限获取组织机构 Sql
        /// <summary>
        /// 按某个权限获取组织机构 Sql (按ParentId树形结构计算)
        /// </summary>
        /// <param name="managerUserId">管理用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>Sql</returns>
        public string GetOrganizeIdsSqlByParentId(string managerUserId, string permissionItemCode)
        {
            string sqlQuery = string.Empty;
            sqlQuery = " SELECT Id "
                     + "   FROM " + BaseOrganizeEntity.TableName
                     + "  WHERE " + BaseOrganizeEntity.TableName + "." + BaseOrganizeEntity.FieldEnabled + " = 1 "
                     + "        AND " + BaseOrganizeEntity.TableName + "." + BaseOrganizeEntity.FieldDeletionStateCode + " = 0 "
                     + "  START WITH Id IN (" + this.GetOrganizeIdsSql(managerUserId, permissionItemCode) + ") "
                     + " CONNECT BY PRIOR " + BaseOrganizeEntity.FieldId + " = " + BaseOrganizeEntity.FieldParentId;
            return sqlQuery;
        }
        #endregion

        #region public string GetOrganizeIdsSqlByCode(string managerUserId, string permissionItemCode) 按某个权限获取组织机构 Sql
        /// <summary>
        /// 按某个权限获取组织机构 Sql (按Code编号进行计算)
        /// </summary>
        /// <param name="managerUserId">管理用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>Sql</returns>
        public string GetOrganizeIdsSqlByCode(string managerUserId, string permissionItemCode)
        {
            string sqlQuery = string.Empty;
            sqlQuery = " SELECT " + BaseOrganizeEntity.FieldId + " AS " + BaseBusinessLogic.FieldId
                     + "   FROM " + BaseOrganizeEntity.TableName
                     + "         , ( SELECT " + DbHelper.PlusSign(BaseOrganizeEntity.FieldCode, "'%'") + " AS " + BaseOrganizeEntity.FieldCode
                     +          "      FROM " + BaseOrganizeEntity.TableName
                     + "     WHERE " + BaseOrganizeEntity.FieldId + " IN (" + this.GetOrganizeIdsSql(managerUserId, permissionItemCode) + ")) ManageOrganize "
                     + " WHERE (" + BaseOrganizeEntity.TableName + "." + BaseOrganizeEntity.FieldEnabled + " = 1 "
                     // 编号相似的所有组织机构获取出来
                     + "       AND " + BaseOrganizeEntity.TableName + "." + BaseOrganizeEntity.FieldCode + " LIKE ManageOrganize." + BaseOrganizeEntity.FieldCode + ")";
            return sqlQuery;
        }
        #endregion


        #region public string[] GetOrganizeIds(string managerUserId, string permissionItemCode = "Resource.ManagePermission", bool organizeIdOnly = true) 按某个权限获取组织机构 主键数组
        /// <summary>
        /// 按某个权限获取组织机构 主键数组
        /// </summary>
        /// <param name="managerUserId">管理用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <param name="organizeIdOnly">只返回组织机构主键</param>
        /// <returns>主键数组</returns>
        public string[] GetOrganizeIds(string managerUserId, string permissionItemCode = "Resource.ManagePermission", bool organizeIdOnly = true)
        {
            // 这里应该考虑，当前用户的管理权限是，所在公司？所在部门？所以在工作组等情况
            string sqlQuery = string.Empty;
            if (BasePermissionScopeManager.UseGetChildrensByCode)
            {
                sqlQuery = this.GetOrganizeIdsSqlByCode(managerUserId, permissionItemCode);
            }
            else
            {
                if (this.DbHelper.CurrentDbType == CurrentDbType.Oracle)
                {
                    sqlQuery = this.GetOrganizeIdsSqlByParentId(managerUserId, permissionItemCode);
                }
                else
                {
                    // edit by zgl 不默认获取子部门
                    // string[] ids = this.GetTreeResourceScopeIds(managerUserId, BaseOrganizeEntity.TableName, permissionItemCode, true);
                    string[] ids = this.GetTreeResourceScopeIds(managerUserId, BaseOrganizeEntity.TableName, permissionItemCode, false);
                    if (ids != null && ids.Length >0 && organizeIdOnly)
                    {
                        TransformPermissionScope(managerUserId, ref ids);
                    }
                    // 这里是否应该整理，自己的公司、部门、工作组的事情？
                    if (organizeIdOnly)
                    {
                        // 这里列出只是有效地，没被删除的组织机构主键
                        if (ids != null && ids.Length > 0)
                        {
                            BaseOrganizeManager organizeManager = new BaseOrganizeManager(this.DbHelper, this.UserInfo);
                            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                            parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldId, ids));
                            parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldEnabled, 1));
                            parameters.Add(new KeyValuePair<string, object>(BaseOrganizeEntity.FieldDeletionStateCode, 0));
                            ids = organizeManager.GetIds(parameters);
                        }
                    }
                    return ids;
                }
            }
            DataTable dataTable = DbHelper.Fill(sqlQuery);
            return BaseBusinessLogic.FieldToArray(dataTable, BaseOrganizeEntity.FieldId);
        }
        #endregion

        #region public DataTable GetOrganizeDT(string managerUserId, string permissionItemCode = "Resource.ManagePermission", bool childrens = true) 按某个权限获取组织机构 数据表
        /// <summary>
        /// 按某个权限获取组织机构 数据表
        /// </summary>
        /// <param name="managerUserId">管理用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <param name="childrens">获取子节点</param>
        /// <returns>数据表</returns>
        public DataTable GetOrganizeDT(string managerUserId, string permissionItemCode = "Resource.ManagePermission", bool childrens = true)
        {
            string whereQuery = string.Empty;
            PermissionScope permissionScope = PermissionScope.None;
            if (BasePermissionScopeManager.UseGetChildrensByCode)
            {
                whereQuery = this.GetOrganizeIdsSqlByCode(managerUserId, permissionItemCode);
            }
            else
            {
                if (this.DbHelper.CurrentDbType == CurrentDbType.Oracle)
                {
                    whereQuery = this.GetOrganizeIdsSqlByParentId(managerUserId, permissionItemCode);
                }
                else
                {
                    // edit by zgl on 2011.12.15, 不自动获取子部门
                    string[] ids = this.GetTreeResourceScopeIds(managerUserId, BaseOrganizeEntity.TableName, permissionItemCode, childrens);
                    permissionScope = TransformPermissionScope(managerUserId, ref ids);
                    // 需要进行适当的翻译，所在部门，所在公司，全部啥啥的。
                    whereQuery = StringUtil.ArrayToList(ids);
                }
            }
            if (string.IsNullOrEmpty(whereQuery))
            {
                whereQuery = " NULL ";
            }
            string sqlQuery = string.Empty;
            sqlQuery = " SELECT * FROM " + BaseOrganizeEntity.TableName
                     + " WHERE " + BaseOrganizeEntity.FieldDeletionStateCode + " = 0 "
                     + "   AND " + BaseOrganizeEntity.FieldEnabled + " = 1 "
                     + "   AND " + BaseOrganizeEntity.FieldIsInnerOrganize + " = 1 ";
            if (permissionScope != PermissionScope.All)
            {
                sqlQuery += " AND " + BaseOrganizeEntity.TableName + "." + BaseOrganizeEntity.FieldId + " IN (" + whereQuery + ") ";
            }
            sqlQuery += " ORDER BY " + BaseOrganizeEntity.FieldSortCode;
            return DbHelper.Fill(sqlQuery);
        }
        #endregion


        //
        // 获得被某个权限管理范围内 角色的 Id、SQL、List
        // 

        #region public string GetRoleIdsSql(string managerUserId, string permissionItemCode) 按某个权限获取角色 Sql
        /// <summary>
        /// 按某个权限获取角色 Sql
        /// </summary>
        /// <param name="managerUserId">管理用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>Sql</returns>
        public string GetRoleIdsSql(string managerUserId, string permissionItemCode)
        {
            BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(DbHelper);
            string permissionItemId = permissionItemManager.GetIdByCode(permissionItemCode);

            string sqlQuery = string.Empty;            
            // 被管理的角色 
            sqlQuery += " SELECT BasePermissionScope.TargetId AS " + BaseBusinessLogic.FieldId
                      + "   FROM BasePermissionScope "
                      + "  WHERE (BasePermissionScope.TargetId IS NOT NULL "
                      + "        AND BasePermissionScope.TargetCategory = '" + BaseRoleEntity.TableName + "' "
                      + "        AND ((BasePermissionScope.ResourceCategory = '" + BaseUserEntity.TableName + "' "
                      + "             AND BasePermissionScope.ResourceId = '" + managerUserId + "')"
                      // 以及 他所在的角色在管理的角色
                      + "        OR (BasePermissionScope.ResourceCategory = '" + BaseRoleEntity.TableName + "'"
                      + "            AND BasePermissionScope.ResourceId IN ( " 
                      +                             " SELECT RoleId " 
                      +                             "   FROM " + BaseUserRoleEntity.TableName
                      + "  WHERE (" + BaseUserRoleEntity.FieldUserId + " = '" + managerUserId + "' "
                      + "        AND " + BaseUserRoleEntity.FieldEnabled + " = 1))))"
                      // 并且是指定的本权限
                      + "        AND " + BasePermissionScopeEntity.FieldPermissionItemId + " = '" + permissionItemId + "')";

            // 被管理部门的列表
            string[] organizeIds = this.GetOrganizeIds(managerUserId, permissionItemCode);
            if (organizeIds.Length > 0)
            {
                string organizes = BaseBusinessLogic.ObjectsToList(organizeIds);
                if (!String.IsNullOrEmpty(organizes))
                {
                    // 被管理的组织机构包含的角色
                    sqlQuery += "  UNION "
                              + " SELECT " + BaseRoleEntity.TableName + "." + BaseRoleEntity.FieldId + " AS " + BaseBusinessLogic.FieldId
                              + "   FROM " + BaseRoleEntity.TableName
                              + "  WHERE " + BaseRoleEntity.TableName + "." + BaseRoleEntity.FieldEnabled + " = 1 "
                              + "    AND " + BaseRoleEntity.TableName + "." + BaseRoleEntity.FieldDeletionStateCode + " = 0 "
                              + "    AND " + BaseRoleEntity.TableName + "." + BaseRoleEntity.FieldOrganizeId + " IN (" + organizes + ") ";
                }
            }
            return sqlQuery;
        }
        #endregion

        #region public string[] GetRoleIds(string managerUserId, string permissionItemCode) 按某个权限获取角色 主键数组
        /// <summary>
        /// 按某个权限获取角色 主键数组
        /// </summary>
        /// <param name="managerUserId">管理用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetRoleIds(string managerUserId, string permissionItemCode)
        {
            string sqlQuery = this.GetRoleIdsSql(managerUserId, permissionItemCode);
            DataTable dataTable = DbHelper.Fill(sqlQuery);
            string[] ids = BaseBusinessLogic.FieldToArray(dataTable, BaseBusinessLogic.FieldId);
            // 这里列出只是有效地，没被删除的角色主键
            if (ids != null && ids.Length > 0)
            {
                BaseRoleManager roleManager = new BaseRoleManager(this.DbHelper, this.UserInfo);

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldId, ids));
                parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldEnabled, 1));
                parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldDeletionStateCode, 0));

                ids = roleManager.GetIds(parameters);
            }
            return ids;
        }
        #endregion

        #region public DataTable GetRoleDT(string managerUserId, string permissionItemCode) 按某个权限获取角色 数据表
        /// <summary>
        /// 按某个权限获取角色 数据表
        /// </summary>
        /// <param name="userId">管理用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>数据表</returns>
        public DataTable GetRoleDT(string userId, string permissionItemCode)
        {
            DataTable returnValue = new DataTable(BaseRoleEntity.TableName);
            //string[] names = null;
            //object[] values = null;

            // 这里需要判断,是系统权限？
            bool isRole = false;
            BaseUserManager userManager = new BaseUserManager(this.DbHelper, this.UserInfo);
            // 用户管理员,这里需要判断,是业务权限？
            isRole = userManager.IsInRoleByCode(userId, "UserAdmin") || userManager.IsInRoleByCode(userId, "Admin");
            if (isRole)
            {
                BaseRoleManager manager = new BaseRoleManager(this.DbHelper, this.UserInfo);

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldIsVisible, 1));
                parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldEnabled, 1));
                parameters.Add(new KeyValuePair<string, object>(BaseRoleEntity.FieldDeletionStateCode, 0));

                returnValue = manager.GetDataTable(parameters, BaseModuleEntity.FieldSortCode);
                returnValue.TableName = this.CurrentTableName;
                return returnValue;
            }

            string sqlQuery = string.Empty;
            sqlQuery = " SELECT * " 
                      + "  FROM " + BaseRoleEntity.TableName
                      + " WHERE " + BaseRoleEntity.FieldCreateUserId + " = '" + this.UserInfo.Id + "'"
                      + "    OR " + BaseRoleEntity.TableName + "." + BaseRoleEntity.FieldId + " IN ("
                                + this.GetRoleIdsSql(userId, permissionItemCode)
                                + " ) AND (" + BaseRoleEntity.FieldDeletionStateCode + " = 0) "
                                + " AND (" + BaseRoleEntity.FieldIsVisible + " = 1) "
                   + " ORDER BY " + BaseRoleEntity.FieldSortCode;
            return DbHelper.Fill(sqlQuery);
        }
        #endregion

        //
        // 获得被某个权限管理范围内 用户的 Id、SQL、List
        // 

        #region public string GetUserIdsSql(string managerUserId, string permissionItemCode) 按某个权限获取员工 Sql
        /// <summary>
        /// 按某个权限获取员工 Sql
        /// </summary>
        /// <param name="managerUserId">管理用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>Sql</returns>
        public string GetUserIdsSql(string managerUserId, string permissionItemCode)
        {
            BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(DbHelper);
            string permissionItemId = permissionItemManager.GetIdByCode(permissionItemCode);

            string sqlQuery = string.Empty;
            
            // 直接管理的用户
            sqlQuery = " SELECT BasePermissionScope.TargetId AS " + BaseBusinessLogic.FieldId
                     + "   FROM BasePermissionScope "
                     + "  WHERE (BasePermissionScope.TargetCategory = '" + BaseUserEntity.TableName + "'"
                     + "        AND BasePermissionScope.ResourceId = '" + managerUserId + "'"
                     + "        AND BasePermissionScope.ResourceCategory = '" + BaseUserEntity.TableName + "'"
                     + "        AND BasePermissionScope.PermissionId = '" + permissionItemId + "'"
                     + "        AND BasePermissionScope.TargetId IS NOT NULL) ";

            // 被管理部门的列表
            string[] organizeIds = this.GetOrganizeIds(managerUserId, permissionItemCode, false);
            if (organizeIds != null && organizeIds.Length > 0)
            {
                // 是否仅仅是自己的还有点儿问题
                if (StringUtil.Exists(organizeIds, ((int)PermissionScope.User).ToString()))
                {
                    sqlQuery += " UNION SELECT '" + this.UserInfo.Id + "' AS Id ";
                }
                else
                {
                    string organizes = BaseBusinessLogic.ObjectsToList(organizeIds);
                    if (!String.IsNullOrEmpty(organizes))
                    {
                        // 被管理的组织机构包含的用户，公司、部门、工作组
                        // sqlQuery += " UNION "
                        //         + " SELECT " + BaseStaffEntity.TableName + "." + BaseStaffEntity.FieldUserId + " AS " + BaseBusinessLogic.FieldId
                        //         + "   FROM " + BaseStaffEntity.TableName
                        //         + "  WHERE (" + BaseStaffEntity.TableName + "." + BaseStaffEntity.FieldCompanyId + " IN (" + organizes + ") "
                        //         + "     OR " + BaseStaffEntity.TableName + "." + BaseStaffEntity.FieldDepartmentId + " IN (" + organizes + ") "
                        //         + "     OR " + BaseStaffEntity.TableName + "." + BaseStaffEntity.FieldWorkgroupId + " IN (" + organizes + ")) ";

                        sqlQuery += " UNION "
                                 + " SELECT " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldId + " AS " + BaseBusinessLogic.FieldId
                                 + "   FROM " + BaseUserEntity.TableName
                                 + "  WHERE (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDeletionStateCode + " = 0 ) "
                                 + "        AND (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldEnabled + " = 1 ) "
                                 + "        AND (" + BaseUserEntity.TableName + "." + BaseUserEntity.FieldCompanyId + " IN (" + organizes + ") "
                                  + "            OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldSubCompanyId + " IN (" + organizes + ") "
                                 + "            OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDepartmentId + " IN (" + organizes + ") "
                                 + "            OR " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldWorkgroupId + " IN (" + organizes + ")) ";
                    }
                }
            }            

            // 被管理角色列表
            string[] roleIds = this.GetRoleIds(managerUserId, permissionItemCode);
            if (roleIds.Length > 0)
            {
                string roles = BaseBusinessLogic.ObjectsToList(roleIds);
                if (!String.IsNullOrEmpty(roles))
                {
                    // 被管理的角色包含的员工
                    sqlQuery += " UNION "
                             + " SELECT " + BaseUserRoleEntity.TableName + "." + BaseUserRoleEntity.FieldUserId + " AS " + BaseBusinessLogic.FieldId
                             + "   FROM " + BaseUserRoleEntity.TableName
                             + "  WHERE (" + BaseUserRoleEntity.TableName + "." + BaseUserRoleEntity.FieldEnabled + " = 1 "
                             + "        AND " + BaseUserRoleEntity.TableName + "." + BaseUserRoleEntity.FieldDeletionStateCode + " = 0 "
                             + "        AND " + BaseUserRoleEntity.TableName + "." + BaseUserRoleEntity.FieldRoleId + " IN (" + roles + ")) ";
                }
            }
            
            return sqlQuery;
        }
        #endregion

        #region public string[] GetUserIds(string managerUserId, string permissionItemCode) 按某个权限获取员工 主键数组
        /// <summary>
        /// 按某个权限获取员工 主键数组
        /// </summary>
        /// <param name="managerUserId">管理用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetUserIds(string managerUserId, string permissionItemCode)
        {
            string[] ids = this.GetTreeResourceScopeIds(managerUserId, BaseOrganizeEntity.TableName, permissionItemCode, true);
            // 是否为仅本人
            if (StringUtil.Exists(ids, ((int)PermissionScope.User).ToString()))
            {
                return new string[] { managerUserId };
            }

            string sqlQuery = this.GetUserIdsSql(managerUserId, permissionItemCode);
            DataTable dataTable = DbHelper.Fill(sqlQuery);

            // 这里应该考虑，当前用户的管理权限是，所在公司？所在部门？所以在工作组等情况
            if (ids != null && ids.Length > 0)
            {
                BaseUserManager userManager = new BaseUserManager(this.DbHelper, this.UserInfo);
                BaseUserEntity userEntity = userManager.GetEntity(managerUserId);
                for (int i = 0; i < ids.Length; i++)
                {
                    if (ids[i].Equals(((int)PermissionScope.User).ToString()))
                    {
                        ids[i] = userEntity.Id.ToString();
                        break;
                    }
                }
            }

            // 这里列出只是有效地，没被删除的角色主键
            if (ids != null && ids.Length > 0)
            {
                BaseUserManager userManager = new BaseUserManager(this.DbHelper, this.UserInfo);

                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldId, ids));
                parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldEnabled, 1));
                parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldDeletionStateCode, 0));

                string[] names = new string[] { BaseUserEntity.FieldId, BaseUserEntity.FieldEnabled, BaseUserEntity.FieldDeletionStateCode };
                Object[] values = new Object[] { ids, 1, 0 };
                ids = userManager.GetIds(parameters);
            }

            return ids;
        }
        #endregion

        #region public DataTable GetUserDT(string userId, string permissionItemCode) 按某个权限获取员工 数据表
        /// <summary>
        /// 按某个权限获取员工 数据表
        /// </summary>
        /// <param name="userId">管理用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>数据表</returns>
        public DataTable GetUserDT(string userId, string permissionItemCode)
        {
            //string[] names = null;
            //object[] values = null;
            DataTable returnValue = new DataTable(BaseRoleEntity.TableName);
            // 这里需要判断,是系统权限？
            bool isRole = false;
            BaseUserManager userManager = new BaseUserManager(this.DbHelper, this.UserInfo);
            // 用户管理员,这里需要判断,是业务权限？
            isRole = userManager.IsInRoleByCode(userId, "UserAdmin") || userManager.IsInRoleByCode(userId, "Admin");
            if (isRole)
            {
                BaseUserManager manager = new BaseUserManager(this.DbHelper, this.UserInfo);
       
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldIsVisible, 1));
                parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldEnabled, 1));
                parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldDeletionStateCode, 0));

                returnValue = manager.GetDataTable(parameters, BaseModuleEntity.FieldSortCode);
                returnValue.TableName = this.CurrentTableName;
                return returnValue;
            }

            string sqlQuery = string.Empty;
            sqlQuery = " SELECT * FROM " + BaseUserEntity.TableName;
            sqlQuery += " WHERE " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldDeletionStateCode + " = 0 "
                     + " AND " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldIsVisible + " = 1 "
                     + " AND " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldEnabled + " = 1 "
                     + " AND " + BaseUserEntity.TableName + "." + BaseUserEntity.FieldId + " IN ("
                     + this.GetUserIdsSql(userId, permissionItemCode)
                     + " ) "
                     + " ORDER BY " + BaseUserEntity.FieldSortCode;
            return DbHelper.Fill(sqlQuery);
        }
        #endregion

        #region public string[] GetTargetIds(string userId, string targetCategory, string permissionItemId)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="permissionItemId"></param>
        /// <returns>主键数组</returns>
        public string[] GetTargetIds(string userId, string targetCategory, string permissionItemId)
        {
            string[] returnValue = new string[0];

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, BaseUserEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, userId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, permissionItemId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, targetCategory));
            
            DataTable dataTable = this.GetDataTable(parameters);
            returnValue = BaseBusinessLogic.FieldToArray(dataTable, BasePermissionScopeEntity.FieldTargetId);
            return returnValue;
        }
        #endregion

        //
        // ResourcePermissionScope 权限判断
        //


        /// <summary>
        /// 转换用户的权限范围
        /// </summary>
        /// <param name="userId">目标用户</param>
        /// <param name="resourceIds">权限范围</param>
        /// <param name="userManager"></param>
        /// <returns></returns>
        public PermissionScope TransformPermissionScope(string userId, ref string[] resourceIds, BaseUserManager userManager = null)
        {
            PermissionScope permissionScope = Utilities.PermissionScope.None;
            if (resourceIds != null && resourceIds.Length > 0)
            {
                if (userManager == null)
                {
                    userManager = new BaseUserManager(DbHelper, UserInfo);
                }
                BaseUserEntity userEntity = userManager.GetEntity(userId);

                for (int i = 0; i < resourceIds.Length; i++)
                {
                    if (resourceIds[i].Equals(((int)PermissionScope.All).ToString()))
                    {
                        permissionScope = PermissionScope.All;
                        continue;
                    }
                    if (resourceIds[i].Equals(((int)PermissionScope.UserCompany).ToString()))
                    {
                        resourceIds[i] = userEntity.CompanyId;
                        permissionScope = PermissionScope.UserCompany;
                        continue;
                    }
                    if (resourceIds[i].Equals(((int)PermissionScope.UserSubCompany).ToString()))
                    {
                        resourceIds[i] = userEntity.SubCompanyId;
                        permissionScope = PermissionScope.UserSubCompany;
                        continue;
                    }
                    if (resourceIds[i].Equals(((int)PermissionScope.UserDepartment).ToString()))
                    {
                        resourceIds[i] = userEntity.DepartmentId;
                        permissionScope = PermissionScope.UserDepartment;
                        continue;
                    }
                    if (resourceIds[i].Equals(((int)PermissionScope.UserWorkgroup).ToString()))
                    {
                        resourceIds[i] = userEntity.WorkgroupId;
                        permissionScope = PermissionScope.UserWorkgroup;
                        continue;
                    }
                }
            }
            return permissionScope;
        }

        /// <summary>
        /// 获得用户的某个权限范围资源主键数组
        /// </summary>
        /// <param name="userId">用户</param>
        /// <param name="targetCategory">资源分类</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>主键数组</returns>
        public string[] GetResourceScopeIds(string userId, string targetCategory, string permissionItemCode)
        {
            string tableName = BasePermissionItemEntity.TableName;
            if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
            {
                tableName = BaseSystemInfo.SystemCode + "PermissionItem";
            }
            BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(DbHelper, UserInfo, tableName);
            string permissionItemId = permissionItemManager.GetId(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldCode, permissionItemCode));

            BaseUserManager userManager = new BaseUserManager(DbHelper, UserInfo);
            string defaultRoleId = userManager.GetProperty(userId, BaseUserEntity.FieldRoleId);

            tableName = BaseUserRoleEntity.TableName;
            if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
            {
                tableName = BaseSystemInfo.SystemCode + "UserRole";
            }

            this.CurrentTableName = "BasePermissionScope";
            if (!string.IsNullOrEmpty(BaseSystemInfo.SystemCode))
            {
                this.CurrentTableName = BaseSystemInfo.SystemCode + "PermissionScope";
            }

            string sqlQuery = string.Empty;
            sqlQuery =  
                        // 用户的权限
                          " SELECT TargetId "
                        + "   FROM " + this.CurrentTableName
                        + "  WHERE (" + this.CurrentTableName + ".ResourceCategory = '" + BaseUserEntity.TableName + "') "
                        + "        AND (ResourceId = '" + userId + "') "
                        + "        AND (TargetCategory = '" + targetCategory + "') "
                        + "        AND (PermissionId = '" + permissionItemId + "') "
                        + "        AND (Enabled = 1) "
                        + "        AND (DeletionStateCode = 0)"
                      
                        + " UNION "
               
                        // 用户归属的角色的权限                            
                        + " SELECT TargetId "
                        + "   FROM " + this.CurrentTableName
                        + "  WHERE (ResourceCategory  = '" + BaseRoleEntity.TableName + "') "
                        + "        AND (TargetCategory  = '" + targetCategory + "') "
                        + "        AND (PermissionId = '" + permissionItemId + "') "
                        + "        AND (DeletionStateCode = 0)"
                        + "        AND (Enabled = 1) "
                        + "        AND ((ResourceId IN ( "
                        + "             SELECT RoleId "
                        + "               FROM " + tableName
                        + "              WHERE (UserId  = '" + userId + "') "
                        + "                  AND (Enabled = 1) "
                        + "                  AND (DeletionStateCode = 0) ) ";
                        if (!string.IsNullOrEmpty(defaultRoleId))
                        {
                            // 用户的默认角色
                            sqlQuery += " OR (ResourceId = '" + defaultRoleId + "')";
                        }
                        sqlQuery += " ) " 
                        + " ) ";

            DataTable dataTable = DbHelper.Fill(sqlQuery);
            string[] resourceIds = BaseBusinessLogic.FieldToArray(dataTable, BasePermissionScopeEntity.FieldTargetId);

            // 按部门获取权限
            if (BaseSystemInfo.UseOrganizePermission)
            {
                sqlQuery = string.Empty;
                BaseUserEntity userEntity = new BaseUserManager(this.DbHelper).GetEntity(userId);
                sqlQuery = " SELECT TargetId "
                           + "   FROM " + this.CurrentTableName
                           + "  WHERE (" + this.CurrentTableName + ".ResourceCategory = '" +
                           BaseOrganizeEntity.TableName + "') "
                           + "        AND (ResourceId = '" + userEntity.CompanyId + "' OR "
                           + "              ResourceId = '" + userEntity.DepartmentId + "' OR "
                           + "              ResourceId = '" + userEntity.SubCompanyId + "' OR"
                           + "              ResourceId = '" + userEntity.WorkgroupId + "') "
                           + "        AND (TargetCategory = '" + targetCategory + "') "
                           + "        AND (PermissionId = '" + permissionItemId + "') "
                           + "        AND (Enabled = 1) "
                           + "        AND (DeletionStateCode = 0)";
                dataTable = DbHelper.Fill(sqlQuery);
                string[] resourceIdsByOrganize = BaseBusinessLogic.FieldToArray(dataTable,
                                                                                BasePermissionScopeEntity.FieldTargetId);
                resourceIds = StringUtil.Concat(resourceIds, resourceIdsByOrganize);
            }
            
            if (targetCategory.Equals(BaseOrganizeEntity.TableName))
            {
                TransformPermissionScope(userId, ref resourceIds, userManager);
            }
            return resourceIds;
        }

        /// <summary>
        /// 树型资源的权限范围
        /// 2011-03-17 吉日嘎拉
        /// 这个是嫩牛X的方法，值得收藏，值得分析
        /// </summary>
        /// <param name="userId">用户</param>
        /// <param name="targetCategory">资源分类</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <param name="childrens">是否含子节点</param>
        /// <returns>主键数组</returns>
        public string[] GetTreeResourceScopeIds(string userId, string tableName, string permissionItemCode, bool childrens)
        {
            string[] resourceScopeIds = null;
            resourceScopeIds = GetResourceScopeIds(userId, tableName, permissionItemCode);
            if (!childrens)
            {
                return resourceScopeIds;
            }
            string idList = StringUtil.ArrayToList(resourceScopeIds);
            // 若本来就没管理部门啥的，那就没必要进行递归操作了
            if (!string.IsNullOrEmpty(idList))
            {
                string sqlQuery = @" WITH PermissionScopeTree AS (SELECT ID 
                                                                FROM " + tableName + @"
                                                                WHERE (Id IN (" + idList + @") )
                                                                UNION ALL
                                                               SELECT ResourceTree.Id
                                                                 FROM " + tableName + @" AS ResourceTree INNER JOIN
                                                                      PermissionScopeTree AS A ON A.Id = ResourceTree.ParentId)
                                                   SELECT Id
                                                     FROM PermissionScopeTree ";
                DataTable dataTable = DbHelper.Fill(sqlQuery);
                string[] resourceIds = BaseBusinessLogic.FieldToArray(dataTable, "Id");
                return StringUtil.Concat(resourceScopeIds, resourceIds);
            }
            return resourceScopeIds;
        }

        #region public bool IsModuleAuthorized(BaseUserInfo userInfo, string moduleCode, string permissionItemCode) 是否有相应的权限
        /// <summary>
        /// 是否有相应的权限
        /// </summary>
        /// <param name=userInfo>用户</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>是否有权限</returns>
        public bool IsModuleAuthorized(BaseUserInfo userInfo, string moduleCode, string permissionItemCode)
        {
            // 先判断用户类别
            if (userInfo.IsAdministrator)
            {
                return true;
            }
            return this.IsModuleAuthorized(userInfo.Id, moduleCode, permissionItemCode);
        }
        #endregion

        #region public bool IsModuleAuthorized(string userId, string moduleCode, string permissionItemCode) 是否有相应的权限
        /// <summary>
        /// 是否有相应的权限
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemCode">权限编号</param>
        /// <returns>是否有权限</returns>
        public bool IsModuleAuthorized(string userId, string moduleCode, string permissionItemCode)
        {
            BaseModuleManager moduleManager = new BaseModuleManager(DbHelper);
            string moduleId = moduleManager.GetIdByCode(moduleCode);
            BasePermissionItemManager permissionItemManager = new BasePermissionItemManager(DbHelper);
            string permissionItemId = permissionItemManager.GetIdByCode(permissionItemCode);
            // 判断员工权限
            if (this.CheckUserModulePermission(userId, moduleId, permissionItemId))
            {
                return true;
            }
            // 判断员工角色权限
            if (this.CheckRoleModulePermission(userId, moduleId, permissionItemId))
            {
                return true;
            }
            return false;
        }
        #endregion

        #region private bool CheckUserModulePermission(string userId, string moduleId, string permissionItemId)
        /// <summary>
        /// 员工是否有模块权限
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>是否有权限</returns>
        private bool CheckUserModulePermission(string userId, string moduleId, string permissionItemId)
        {
            return CheckResourcePermissionScope(BaseModuleEntity.TableName, userId, BaseModuleEntity.TableName, moduleId, permissionItemId);
        }
        #endregion

        private bool CheckResourcePermissionScope(string resourceCategory, string resourceId, string targetCategory, string targetId, string permissionItemId)
        {
            string sqlQuery = " SELECT COUNT(*) "
                             + "  FROM BasePermissionScope "
                             + " WHERE (BasePermissionScope.ResourceCategory = '" + resourceCategory + "')"
                             + "       AND (BasePermissionScope.Enabled = 1) "
                             + "       AND (BasePermissionScope.DeletionStateCode = 0 )"
                             + "       AND (BasePermissionScope.ResourceId = '" + resourceId + "')"
                             + "       AND (BasePermissionScope.TargetCategory = '" + targetCategory + "')"
                             + "       AND (BasePermissionScope.TargetId = '" + targetId + "')"
                             + "       AND (BasePermissionScope.PermissionId = " + permissionItemId + "))";
            int rowCount = 0;

            object returnObject = DbHelper.ExecuteScalar(sqlQuery);
            if (returnObject != null)
            {
                rowCount = int.Parse(returnObject.ToString());
            }
            return rowCount > 0;
        }

        #region private bool CheckRoleModulePermission(string userId, string moduleId, string permissionItemId)
        /// <summary>
        /// 员工角色关系是否有模块权限
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>有角色权限</returns>
        private bool CheckRoleModulePermission(string userId, string moduleId, string permissionItemId)
        {
            return CheckRolePermissionScope(userId, BaseModuleEntity.TableName, moduleId, permissionItemId);
        }
        #endregion

        private bool CheckRolePermissionScope(string userId, string targetCategory, string targetId, string permissionItemId)
        {
            string sqlQuery = " SELECT COUNT(*) "
                            + "   FROM BasePermissionScope "
                            + "  WHERE (BasePermissionScope.ResourceCategory = '" + BaseRoleEntity.TableName + "') "
                            + "        AND (BasePermissionScope.Enabled = 1 "
                            + "        AND (BasePermissionScope.DeletionStateCode = 0 "
                            + "        AND (BasePermissionScope.ResourceId IN ( "
                                             + " SELECT BaseUserRole.RoleId "
                                             + "   FROM BaseUserRole "
                                             + "  WHERE BaseUserRole.UserId = '" + userId + "'"
                                             + "        AND BaseUserRole.Enabled = 1 "
                                             + "  UNION "
                                             + " SELECT " + BaseUserEntity.FieldRoleId
                                             + "   FROM " + BaseUserEntity.TableName
                                             + "  WHERE " + BaseUserEntity.FieldId + " = '" + userId + "'"
                                             + ")) "
                            + " AND (BasePermissionScope.TargetCategory = '" + targetCategory + "') "
                            + " AND (BasePermissionScope.TargetId = '" + targetId + "') "
                            + " AND (BasePermissionScope.PermissionId = " + permissionItemId + ")) ";
            int rowCount = 0;

            object returnObject = DbHelper.ExecuteScalar(sqlQuery);
            if (returnObject != null)
            {
                rowCount = int.Parse(returnObject.ToString());
            }
            return rowCount > 0;
        }

        public int GrantResourcePermissionScopeTarget(string resourceCategory, string resourceId, string targetCategory, string[] grantTargetIds, string permissionItemId, DateTime? startDate = null, DateTime? endDate = null)
        {
            int returnValue = 0;

            BasePermissionScopeEntity resourcePermissionScope = new BasePermissionScopeEntity();
            resourcePermissionScope.ResourceCategory = resourceCategory;
            resourcePermissionScope.ResourceId = resourceId;
            resourcePermissionScope.TargetCategory = targetCategory;
            resourcePermissionScope.PermissionId = int.Parse(permissionItemId);
            resourcePermissionScope.StartDate = startDate;
            resourcePermissionScope.EndDate = endDate;
            resourcePermissionScope.Enabled = 1;
            resourcePermissionScope.DeletionStateCode = 0;
            for (int i = 0; i < grantTargetIds.Length; i++)
            {
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, resourceCategory));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, resourceId));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, targetCategory));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetId, grantTargetIds[i]));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, permissionItemId));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldEnabled, 1));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldDeletionStateCode, 0));

                resourcePermissionScope.TargetId = grantTargetIds[i];
                if (!this.Exists(parameters))
                {
                    this.Add(resourcePermissionScope);
                    returnValue++;
                }
            }
            return returnValue;
        }

        public int GrantResourcePermissionScopeTarget(string resourceCategory, string[] resourceIds, string targetCategory, string grantTargetId, string permissionItemId)
        {
            int returnValue = 0;

            List<KeyValuePair<string, object>> parameters = null;
            BasePermissionScopeEntity resourcePermissionScope = new BasePermissionScopeEntity();
            resourcePermissionScope.ResourceCategory = resourceCategory;
            // resourcePermissionScope.ResourceId = resourceId;
            resourcePermissionScope.TargetCategory = targetCategory;
            resourcePermissionScope.PermissionId = int.Parse(permissionItemId);
            resourcePermissionScope.TargetId = grantTargetId;

            resourcePermissionScope.Enabled = 1;
            resourcePermissionScope.DeletionStateCode = 0;
            for (int i = 0; i < resourceIds.Length; i++)
            {
                parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, resourceCategory));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, resourceIds[i]));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, grantTargetId));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetId, targetCategory));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, permissionItemId));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldEnabled, 1));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldDeletionStateCode, 0));

				resourcePermissionScope.ResourceId = resourceIds[i];
                if (!this.Exists(parameters))
                {
                    this.Add(resourcePermissionScope);
                    returnValue++;
                }
            }
            return returnValue;
        }

        /// <summary>
        /// 52.撤消资源的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="revokeTargetIds">目标主键数组</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响的行数</returns>
        public int RevokeResourcePermissionScopeTarget(string resourceCategory, string resourceId, string targetCategory, string[] revokeTargetIds, string permissionItemId)
        {
            int returnValue = 0;
            for (int i = 0; i < revokeTargetIds.Length; i++)
            {
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, resourceCategory));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, resourceId));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, targetCategory));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetId, revokeTargetIds[i]));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, permissionItemId));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldEnabled, 1));
                // 逻辑删除
                returnValue += this.SetDeleted(parameters);
                // 物理删除
                //returnValue += this.Delete(parameters);
            }
            return returnValue;
        }

        /// <summary>
        /// 52.撤消资源的权限范围
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="resourceCategory">资源分类</param>
        /// <param name="resourceId">资源主键</param>
        /// <param name="targetCategory">目标类别</param>
        /// <param name="revokeTargetIds">目标主键数组</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>影响的行数</returns>
        public int RevokeResourcePermissionScopeTarget(string resourceCategory, string resourceId, string targetCategory, string permissionItemId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, resourceCategory));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, resourceId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, targetCategory));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, permissionItemId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldEnabled, 1));
            // 逻辑删除
            return this.SetDeleted(parameters);
            // 物理删除
            // return this.Delete(parameters);
        }

        public int RevokeResourcePermissionScopeTarget(string resourceCategory, string[] resourceIds, string targetCategory, string revokeTargetId, string permissionItemId)
        {
            int returnValue = 0;
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            for (int i = 0; i < resourceIds.Length; i++)
            {
                parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, resourceCategory));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, resourceIds[i]));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, targetCategory));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetId, revokeTargetId));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, permissionItemId));
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldEnabled, 1));
                // 逻辑删除
                returnValue += this.SetDeleted(parameters);
                // 物理删除
                //returnValue += this.Delete(parameters);
            }
            return returnValue;
        }

        #region public bool HasAuthorized(string[] names, object[] values, string startDate, string endDate) 判断某个时间范围内是否存在
        /// <summary>
        /// 判断某个时间范围内是否存在
        /// </summary>
        /// <param name="names"></param>
        /// <param name="values"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public bool HasAuthorized(List<KeyValuePair<string, object>> parameters, string startDate, string endDate)
        {
            bool returnValue = false;
            BasePermissionScopeManager manager = new BasePermissionScopeManager(this.DbHelper, this.UserInfo);
            returnValue = manager.Exists(parameters);
            /*
            if (returnValue)
            {
                // 再去判断时间
                string minDate = "1900-01-01 00:00:00";
                string maxDate = "3000-12-31 00:00:00";
                // 不用设置的太大
                string srcStartDate = manager.GetProperty(names, values, BasePermissionScopeEntity.FieldStartDate);
                string srcEndDate = manager.GetProperty(names, values, BasePermissionScopeEntity.FieldEndDate);
                if (string.IsNullOrEmpty(srcStartDate))
                {
                    srcStartDate = minDate;
                }
                if (string.IsNullOrEmpty(startDate))
                {
                    startDate = minDate;
                }
                if (string.IsNullOrEmpty(srcEndDate))
                {
                    srcEndDate = maxDate;
                }
                if (string.IsNullOrEmpty(endDate))
                {
                    endDate = maxDate;
                }
                // 满足这样的条件
                // 时间A(Start1-End1)，   时间B(Start2-End2)
                // Start1 <Start2   &&   Start2 <End1
                // Start1 <End2   &&   End2 <End1
                // Start2 <Start1   &&   End1 <End2
                if ((CheckDateScope(srcStartDate, startDate) && CheckDateScope(startDate, srcEndDate)) 
                    || (CheckDateScope(srcStartDate, endDate) && CheckDateScope(endDate, srcEndDate)) 
                    || (CheckDateScope(startDate, srcStartDate) && CheckDateScope(srcEndDate, endDate)))
                {
                    returnValue = true;
                }
                else 
                {
                    returnValue = false;
                }                   
            }
            */
            return returnValue;
        }
        #endregion

        #region  public int CheckDateScope(string smallDate,string bigDate) 检查日期大小
        /// <summary>
        /// 检查日期大小
        /// </summary>
        /// <param name="smallDate">开始日期</param>
        /// <param name="bigDate">结束日期</param>
        /// <returns>0：小于等于 1：大于等于</returns>
        public bool CheckDateScope(string smallDate, string bigDate)
        {
            // 开始日期是无限大
            // 结束日期是无限大
            return DateTime.Parse(smallDate) < DateTime.Parse(bigDate);
        }
        #endregion

        public DataTable Search(string resourceId, string resourceCategory, string targetCategory)
        {
            string sqlQuery = string.Empty;
            sqlQuery = "SELECT * FROM " + this.CurrentTableName
                            + " WHERE " + BasePermissionScopeEntity.FieldDeletionStateCode + " =0 "
                            + " AND " + BasePermissionScopeEntity.FieldEnabled + " =1 ";
            List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();
            if (!String.IsNullOrEmpty(resourceId))
            {
                sqlQuery += " AND " + BasePermissionScopeEntity.FieldResourceId + " = '" + resourceId + "'";
            }
            if (!String.IsNullOrEmpty(resourceCategory))
            {
                sqlQuery += " AND " + BasePermissionScopeEntity.FieldResourceCategory + " = '" + resourceCategory + "'";
            }
            if (!String.IsNullOrEmpty(targetCategory))
            {
                sqlQuery += " AND " + BasePermissionScopeEntity.FieldTargetCategory + " = '" + targetCategory + "'";
            }
            sqlQuery += " ORDER BY " + BasePermissionScopeEntity.FieldCreateOn + " DESC ";
            return DbHelper.Fill(sqlQuery);

            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    if (!string.IsNullOrEmpty(dt.Rows[i][BasePermissionScopeEntity.FieldEndDate].ToString()))
            //    {
            //        // 过期的不显示
            //        if (DateTime.Parse(dt.Rows[i][BasePermissionScopeEntity.FieldEndDate].ToString()).Date < DateTime.Now.Date)
            //        {
            //            dt.Rows.RemoveAt(i);
            //        }
            //    }
            //}
        }

        #region public DataTable GetAuthoriedList(string resourceCategory, string permissionItemId, string targetCategory, string targetId) 获得有效的委托列表
        public DataTable GetAuthoriedList(string resourceCategory, string permissionItemId, string targetCategory, string targetId)
        {
            string sqlQuery = string.Empty;
            sqlQuery = "SELECT * FROM " + this.CurrentTableName
                            + " WHERE " + BasePermissionScopeEntity.FieldDeletionStateCode + " =0 "
                            + " AND " + BasePermissionScopeEntity.FieldEnabled + " =1 ";
            if (!String.IsNullOrEmpty(resourceCategory))
            {
                sqlQuery += " AND " + BasePermissionScopeEntity.FieldResourceCategory + " = '" + resourceCategory + "'";
            }
            if (!String.IsNullOrEmpty(permissionItemId))
            {
                sqlQuery += " AND " + BasePermissionScopeEntity.FieldPermissionItemId + " = '" + permissionItemId + "'";
            }
            if (!String.IsNullOrEmpty(targetCategory))
            {
                sqlQuery += " AND " + BasePermissionScopeEntity.FieldTargetCategory + " = '" + targetCategory + "'";
            }
            if (!String.IsNullOrEmpty(targetId))
            {
                sqlQuery += " AND " + BasePermissionScopeEntity.FieldTargetId + " = '" + targetId + "'";
            }
            // 时间在startDate或者endDate之间为有效
            if (BaseSystemInfo.UserCenterDbType.Equals(CurrentDbType.SqlServer))
            {
                sqlQuery += " AND ((SELECT DATEDIFF(day, " + BasePermissionScopeEntity.FieldStartDate + ", GETDATE()))>=0"
                         + " OR (SELECT DATEDIFF(day, " + BasePermissionScopeEntity.FieldStartDate + ", GETDATE())) IS NULL)";
                sqlQuery += " AND ((SELECT DATEDIFF(day, " + BasePermissionScopeEntity.FieldEndDate+ ", GETDATE()))<=0"
                         + " OR (SELECT DATEDIFF(day, " + BasePermissionScopeEntity.FieldEndDate + ", GETDATE())) IS NULL)";
            }
            // TODO:其他数据库的兼容
            sqlQuery += " ORDER BY " + BasePermissionScopeEntity.FieldCreateOn + " DESC ";
            return DbHelper.Fill(sqlQuery);
        }
        #endregion
    }
}