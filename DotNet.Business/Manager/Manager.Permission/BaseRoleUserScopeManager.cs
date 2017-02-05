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
    /// 角色用户权限域
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

        #region public string[] GetUserIds(string roleId, string permissionItemCode) 获取员工的权限主键数组
        /// <summary>
        /// 获取员工的权限主键数组
        /// </summary>
        /// <param name="roleId">员工代吗</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <returns>主键数组</returns>
        public string[] GetUserIds(string roleId, string permissionItemCode)
        {
            string[] returnValue = null;

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, BaseRoleEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, roleId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, BaseUserEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, this.GetIdByCode(permissionItemCode)));

            DataTable dataTable = this.GetDataTable(parameters);
            returnValue = BaseBusinessLogic.FieldToArray(dataTable, BasePermissionScopeEntity.FieldTargetId);
            return returnValue;
        }
        #endregion

        //
        // 授予授权范围的实现部分
        //

        #region private string GrantUser(BasePermissionScopeManager permissionScopeManager, string id, string roleId, string grantUserId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="Id">主键</param>
        /// <param name="roleId">员工主键</param>
        /// <param name="grantUserId">权限主键</param>
        /// <returns>主键</returns>
        private string GrantUser(BasePermissionScopeManager permissionScopeManager, string roleId, string permissionItemCode, string grantUserId)
        {
            string returnValue = string.Empty;
            BasePermissionScopeEntity resourcePermissionScopeEntity = new BasePermissionScopeEntity();
            resourcePermissionScopeEntity.PermissionId = int.Parse(this.GetIdByCode(permissionItemCode));
            resourcePermissionScopeEntity.ResourceCategory = BaseRoleEntity.TableName;
            resourcePermissionScopeEntity.ResourceId = roleId;
            resourcePermissionScopeEntity.TargetCategory = BaseUserEntity.TableName;
            resourcePermissionScopeEntity.TargetId = grantUserId;
            resourcePermissionScopeEntity.Enabled = 1;
            resourcePermissionScopeEntity.DeletionStateCode = 0;
            return permissionScopeManager.Add(resourcePermissionScopeEntity);
        }
        #endregion

        #region public string GrantUser(string roleId, string permissionItemId) 员工授予权限
        /// <summary>
        /// 员工授予权限
        /// </summary>
        /// <param name="roleId">员工主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="organizeId">权组织机构限主键</param>
        /// <returns>主键</returns>
        public string GrantUser(string roleId, string permissionItemCode, string grantUserId)
        {
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            return this.GrantUser(permissionScopeManager, roleId, permissionItemCode, grantUserId);
        }
        #endregion

        public int GrantUsers(string roleId, string permissionItemCode, string[] grantUserIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            for (int i = 0; i < grantUserIds.Length; i++)
            {
                this.GrantUser(permissionScopeManager, roleId, permissionItemCode, grantUserIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantUsers(string[] roleIds, string permissionItemCode, string grantUserId)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                this.GrantUser(permissionScopeManager, roleIds[i], permissionItemCode, grantUserId);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantUsers(string[] roleIds, string permissionItemCode, string[] grantUserIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                for (int j = 0; j < grantUserIds.Length; j++)
                {
                    this.GrantUser(permissionScopeManager, roleIds[i], permissionItemCode, grantUserIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  撤销授权范围的实现部分
        //

        #region private int RevokeUser(BasePermissionScopeManager permissionScopeManager, string roleId, string permissionItemCode, string revokeUserId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="roleId">员工主键</param>
        /// <param name="revokeUserId">权限主键</param>
        /// <returns>主键</returns>
        private int RevokeUser(BasePermissionScopeManager permissionScopeManager, string roleId, string permissionItemCode, string revokeUserId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, BaseRoleEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, roleId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, BaseUserEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetId, revokeUserId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, this.GetIdByCode(permissionItemCode)));
            return permissionScopeManager.Delete(parameters);
        }
        #endregion

        #region public int RevokeUser(string roleId, string permissionItemCode, string revokeUserId) 员工撤销授权
        /// <summary>
        /// 员工撤销授权
        /// </summary>
        /// <param name="roleId">员工主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>主键</returns>
        public int RevokeUser(string roleId, string permissionItemCode, string revokeUserId)
        {
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            return this.RevokeUser(permissionScopeManager, roleId, permissionItemCode, revokeUserId);
        }
        #endregion

        public int RevokeUsers(string roleId, string permissionItemCode, string[] revokeUserIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            for (int i = 0; i < revokeUserIds.Length; i++)
            {
                this.RevokeUser(permissionScopeManager, roleId, permissionItemCode, revokeUserIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeUsers(string[] roleIds, string permissionItemCode, string revokeUserId)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                this.RevokeUser(permissionScopeManager, roleIds[i], permissionItemCode, revokeUserId);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeUsers(string[] roleIds, string permissionItemCode, string[] revokeUserIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            for (int i = 0; i < roleIds.Length; i++)
            {
                for (int j = 0; j < revokeUserIds.Length; j++)
                {
                    this.RevokeUser(permissionScopeManager, roleIds[i], permissionItemCode, revokeUserIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }
    }
}