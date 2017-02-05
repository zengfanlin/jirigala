//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseRoleScopeManager
    /// 角色权限域
    /// 
    /// 修改纪录
    ///
    ///     2011.03.13 版本：2.0 JiRiGaLa 重新整理代码。
    ///     2008.05.24 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：2.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.03.13</date>
    /// </author>
    /// </summary>
    public partial class BaseRoleScopeManager : BaseManager, IBaseManager
    {
        ////
        ////
        //// 授权范围管理部分
        ////
        ////

        #region public string[] GetRoleIds(string roleId, string permissionItemCode) 获取员工的权限主键数组
        /// <summary>
        /// 获取员工的权限主键数组
        /// </summary>
        /// <param name="roleId">员工代吗</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <returns>主键数组</returns>
        public string[] GetRoleIds(string roleId, string permissionItemCode)
        {
            string[] returnValue = null;
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, BaseRoleEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, roleId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, BaseRoleEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, this.GetIdByCode(permissionItemCode)));
            DataTable dataTable = this.GetDataTable(parameters);
            returnValue = BaseBusinessLogic.FieldToArray(dataTable, BasePermissionScopeEntity.FieldTargetId);
            return returnValue;
        }
        #endregion

        //
        // 授予授权范围的实现部分
        //

        #region private string GrantRole(BasePermissionScopeManager permissionScopeManager, string id, string roleId, string grantRoleId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="Id">主键</param>
        /// <param name="roleId">员工主键</param>
        /// <param name="grantRoleId">权限主键</param>
        /// <returns>主键</returns>
        private string GrantRole(BasePermissionScopeManager permissionScopeManager, string roleId, string permissionItemCode, string grantRoleId)
        {
            string returnValue = string.Empty;
            BasePermissionScopeEntity resourcePermissionScopeEntity = new BasePermissionScopeEntity();
            resourcePermissionScopeEntity.PermissionId = int.Parse(this.GetIdByCode(permissionItemCode));
            resourcePermissionScopeEntity.ResourceCategory = BaseRoleEntity.TableName;
            resourcePermissionScopeEntity.ResourceId = roleId;
            resourcePermissionScopeEntity.TargetCategory = BaseRoleEntity.TableName;
            resourcePermissionScopeEntity.TargetId = grantRoleId;
            resourcePermissionScopeEntity.Enabled = 1;
            resourcePermissionScopeEntity.DeletionStateCode = 0;
            return permissionScopeManager.Add(resourcePermissionScopeEntity);
        }
        #endregion

        #region public string GrantRole(string roleId, string permissionItemId) 员工授予权限
        /// <summary>
        /// 员工授予权限
        /// </summary>
        /// <param name="roleId">员工主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="organizeId">权组织机构限主键</param>
        /// <returns>主键</returns>
        public string GrantRole(string roleId, string permissionItemCode, string grantRoleId)
        {
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            return this.GrantRole(permissionScopeManager, roleId, permissionItemCode, grantRoleId);
        }
        #endregion

        public int GrantRoles(string roleId, string permissionItemCode, string[] grantRoleIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            for (int i = 0; i < grantRoleIds.Length; i++)
            {
                this.GrantRole(permissionScopeManager, roleId, permissionItemCode, grantRoleIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantRoles(string[] roleIds, string permissionItemCode, string grantRoleId)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                this.GrantRole(permissionScopeManager, roleIds[i], permissionItemCode, grantRoleId);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantRoles(string[] roleIds, string permissionItemCode, string[] grantRoleIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                for (int j = 0; j < grantRoleIds.Length; j++)
                {
                    this.GrantRole(permissionScopeManager, roleIds[i], permissionItemCode, grantRoleIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  撤销授权范围的实现部分
        //

        #region private int RevokeRole(BasePermissionScopeManager permissionScopeManager, string roleId, string permissionItemCode, string revokeRoleId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="roleId">员工主键</param>
        /// <param name="revokeRoleId">权限主键</param>
        /// <returns>主键</returns>
        private int RevokeRole(BasePermissionScopeManager permissionScopeManager, string roleId, string permissionItemCode, string revokeRoleId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, BaseRoleEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, roleId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, BaseRoleEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetId, revokeRoleId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, this.GetIdByCode(permissionItemCode)));
            return permissionScopeManager.Delete(parameters);
        }
        #endregion

        #region public int RevokeRole(string roleId, string permissionItemId) 员工撤销授权
        /// <summary>
        /// 员工撤销授权
        /// </summary>
        /// <param name="roleId">员工主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>主键</returns>
        public int RevokeRole(string roleId, string permissionItemCode, string revokeRoleId)
        {
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            return this.RevokeRole(permissionScopeManager, roleId, permissionItemCode, revokeRoleId);
        }
        #endregion

        public int RevokeRoles(string roleId, string permissionItemCode, string[] revokeRoleIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            for (int i = 0; i < revokeRoleIds.Length; i++)
            {
                this.RevokeRole(permissionScopeManager, roleId, permissionItemCode, revokeRoleIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeRoles(string[] roleIds, string permissionItemCode, string revokeRoleId)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                this.RevokeRole(permissionScopeManager, roleIds[i], permissionItemCode, revokeRoleId);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeRoles(string[] roleIds, string permissionItemCode, string[] revokeRoleIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                for (int j = 0; j < revokeRoleIds.Length; j++)
                {
                    this.RevokeRole(permissionScopeManager, roleIds[i], permissionItemCode, revokeRoleIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }
    }
}