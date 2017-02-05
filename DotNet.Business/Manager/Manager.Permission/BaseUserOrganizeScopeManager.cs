//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseUserScopeManager
    /// 用户组织机构权限域
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
    public partial class BaseUserScopeManager : BaseManager, IBaseManager
    {
        ////
        ////
        //// 授权范围管理部分
        ////
        ////

        #region public string[] GetOrganizeIds(string userId, string permissionItemCode) 获取员工的权限主键数组
        /// <summary>
        /// 获取员工的权限主键数组
        /// </summary>
        /// <param name="userId">员工代吗</param>
        /// <param name="permissionItemCode">权限代码</param>
        /// <returns>主键数组</returns>
        public string[] GetOrganizeIds(string userId, string permissionItemCode)
        {
            string[] returnValue = null;

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, BaseUserEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, userId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, BaseOrganizeEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, this.GetIdByCode(permissionItemCode)));

            DataTable dataTable = this.GetDataTable(parameters);
            returnValue = BaseBusinessLogic.FieldToArray(dataTable, BasePermissionScopeEntity.FieldTargetId);
            return returnValue;
        }
        #endregion

        //
        // 授予授权范围的实现部分
        //

        #region private string GrantOrganize(BasePermissionScopeManager permissionScopeManager, string id, string userId, string grantOrganizeId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="Id">主键</param>
        /// <param name="userId">员工主键</param>
        /// <param name="grantOrganizeId">权限主键</param>
        /// <returns>主键</returns>
        private string GrantOrganize(BasePermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string grantOrganizeId)
        {
            string returnValue = string.Empty;

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, BaseUserEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, userId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, BaseOrganizeEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetId, grantOrganizeId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, this.GetIdByCode(permissionItemCode)));
            // Nick Deng 优化数据权限设置，没有权限和其他任意一种权限互斥
            // 即当没有权限时，该用户对应该数据权限的其他权限都应删除
            // 当该用户拥有对应该数据权限的其他权限时，删除该用户的没有权限的权限
            BasePermissionScopeEntity resourcePermissionScopeEntity = new BasePermissionScopeEntity();
            DataTable dt = new DataTable();
            if (!this.Exists(parameters))
            {
                resourcePermissionScopeEntity.PermissionId = int.Parse(this.GetIdByCode(permissionItemCode));
                resourcePermissionScopeEntity.ResourceCategory = BaseUserEntity.TableName;
                resourcePermissionScopeEntity.ResourceId = userId;
                resourcePermissionScopeEntity.TargetCategory = BaseOrganizeEntity.TableName;
                resourcePermissionScopeEntity.TargetId = grantOrganizeId;
                resourcePermissionScopeEntity.Enabled = 1;
                resourcePermissionScopeEntity.DeletionStateCode = 0;
                returnValue = permissionScopeManager.Add(resourcePermissionScopeEntity);
                if (grantOrganizeId != ((int)PermissionScope.None).ToString())
                {
                    parameters = new List<KeyValuePair<string, object>>();
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, BaseUserEntity.TableName));
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, userId));
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, BaseOrganizeEntity.TableName));
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetId, ((int)PermissionScope.None).ToString()));
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, this.GetIdByCode(permissionItemCode)));
                    if (this.Exists(parameters))
                    {
                        dt = permissionScopeManager.GetDataTable(parameters);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            permissionScopeManager.DeleteEntity(dt.Rows[0]["Id"].ToString());
                        }
                    }
                }
                else
                {
                    parameters = new List<KeyValuePair<string, object>>();
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, BaseUserEntity.TableName));
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, userId));
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, BaseOrganizeEntity.TableName));
                    parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, this.GetIdByCode(permissionItemCode)));

                    dt = permissionScopeManager.GetDataTable(parameters);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["TargetId"].ToString() != ((int)PermissionScope.None).ToString())
                        {
                            permissionScopeManager.DeleteEntity(dt.Rows[0]["Id"].ToString());
                        }
                    }
                }
            }
            return returnValue;
        }
        #endregion

        #region public string GrantOrganize(string userId, string permissionItemId) 员工授予权限
        /// <summary>
        /// 员工授予权限
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <param name="organizeId">权组织机构限主键</param>
        /// <returns>主键</returns>
        public string GrantOrganize(string userId, string permissionItemCode, string grantOrganizeId)
        {
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            return this.GrantOrganize(permissionScopeManager, userId, permissionItemCode, grantOrganizeId);
        }
        #endregion

        public int GrantOrganizes(string userId, string permissionItemCode, string[] grantOrganizeIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < grantOrganizeIds.Length; i++)
            {
                this.GrantOrganize(permissionScopeManager, userId, permissionItemCode, grantOrganizeIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantOrganizes(string[] userIds, string permissionItemCode, string grantOrganizeId)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                this.GrantOrganize(permissionScopeManager, userIds[i], permissionItemCode, grantOrganizeId);
                returnValue++;
            }
            return returnValue;
        }

        public int GrantOrganizes(string[] userIds, string permissionItemCode, string[] grantOrganizeIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < grantOrganizeIds.Length; j++)
                {
                    this.GrantOrganize(permissionScopeManager, userIds[i], permissionItemCode, grantOrganizeIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }


        //
        //  撤销授权范围的实现部分
        //

        #region private int RevokeOrganize(BasePermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string revokeOrganizeId) 为了提高授权的运行速度
        /// <summary>
        /// 为了提高授权的运行速度
        /// </summary>
        /// <param name="permissionScopeManager">权限域读写器</param>
        /// <param name="userId">员工主键</param>
        /// <param name="revokeOrganizeId">权限主键</param>
        /// <returns>主键</returns>
        private int RevokeOrganize(BasePermissionScopeManager permissionScopeManager, string userId, string permissionItemCode, string revokeOrganizeId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceCategory, BaseUserEntity.TableName));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldResourceId, userId));
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetCategory, BaseOrganizeEntity.TableName));
            if (!string.IsNullOrEmpty(revokeOrganizeId))
            {
                parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldTargetId, revokeOrganizeId));
            }
            parameters.Add(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldPermissionItemId, this.GetIdByCode(permissionItemCode)));
            return permissionScopeManager.Delete(parameters);
        }
        #endregion

        #region public int RevokeOrganize(string userId, string permissionItemId) 员工撤销授权
        /// <summary>
        /// 员工撤销授权
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>主键</returns>
        public int RevokeOrganize(string userId, string permissionItemCode)
        {
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo, this.CurrentTableName);
            return this.RevokeOrganize(permissionScopeManager, userId, permissionItemCode, null);
        }
        #endregion

        #region public int RevokeOrganize(string userId, string permissionItemId) 员工撤销授权
        /// <summary>
        /// 员工撤销授权
        /// </summary>
        /// <param name="userId">员工主键</param>
        /// <param name="permissionItemId">权限主键</param>
        /// <returns>主键</returns>
        public int RevokeOrganize(string userId, string permissionItemCode, string revokeOrganizeId)
        {
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            return this.RevokeOrganize(permissionScopeManager, userId, permissionItemCode, revokeOrganizeId);
        }
        #endregion

        public int RevokeOrganizes(string userId, string permissionItemCode, string[] revokeOrganizeIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo, this.CurrentTableName);
            for (int i = 0; i < revokeOrganizeIds.Length; i++)
            {
                this.RevokeOrganize(permissionScopeManager, userId, permissionItemCode, revokeOrganizeIds[i]);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeOrganizes(string[] userIds, string permissionItemCode, string revokeOrganizeId)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                this.RevokeOrganize(permissionScopeManager, userIds[i], permissionItemCode, revokeOrganizeId);
                returnValue++;
            }
            return returnValue;
        }

        public int RevokeOrganizes(string[] userIds, string permissionItemCode, string[] revokeOrganizeIds)
        {
            int returnValue = 0;
            BasePermissionScopeManager permissionScopeManager = new BasePermissionScopeManager(DbHelper, UserInfo);
            for (int i = 0; i < userIds.Length; i++)
            {
                for (int j = 0; j < revokeOrganizeIds.Length; j++)
                {
                    this.RevokeOrganize(permissionScopeManager, userIds[i], permissionItemCode, revokeOrganizeIds[j]);
                    returnValue++;
                }
            }
            return returnValue;
        }
    }
}