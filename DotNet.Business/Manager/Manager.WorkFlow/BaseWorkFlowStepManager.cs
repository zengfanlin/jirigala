//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Collections.Generic;

namespace DotNet.Business
{
    /// <summary>
    /// BaseWorkFlowStepManager
    /// 流程步骤管理.
    /// 
    /// 修改纪录
    ///		
    ///		2011.11.26 版本：1.0 JiRiGaLa	编写主键。
    /// 
    /// 版本：1.0
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.11.26</date>
    /// </author>
    /// </summary>
    public partial class BaseWorkFlowStepManager : BaseManager, IBaseManager
    {
        #region public int ReplaceUser(string oldUserId, string newUserId) 替换当前步骤中的人员
        /// <summary>
        /// 替换当前步骤中的人员
        /// </summary>
        /// <param name="oldUserId">原来的工号</param>
        /// <param name="newUserId">新的工号</param>
        /// <returns>影响行数</returns>
        public int ReplaceUser(string oldUserId, string newUserId)
        {
            BaseUserManager userManager = new BaseUserManager(this.UserInfo);
            BaseUserEntity newUserEntity = userManager.GetEntity(newUserId);
            SQLBuilder sqlBuilder = new SQLBuilder(this.DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldAuditUserId, newUserEntity.Id);
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldAuditUserCode, newUserEntity.Code);
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldAuditUserRealName, newUserEntity.RealName);
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldAuditDepartmentId, newUserEntity.DepartmentId);
            sqlBuilder.SetValue(BaseWorkFlowStepEntity.FieldAuditDepartmentName, newUserEntity.DepartmentName);
            sqlBuilder.SetWhere(BaseWorkFlowStepEntity.FieldAuditUserId, oldUserId, "OldUserId");
            return sqlBuilder.EndUpdate();
        }
        #endregion

        /// <summary>
        /// 删除用户的审核步骤
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <returns>影响行数</returns>
        public int DeleteAuditStepByUser(string userId)
        {
            int returnValue = 0;
            // 1: 若还有当前审核中的记录，不能被删除掉
            BaseWorkFlowCurrentManager manager = new BaseWorkFlowCurrentManager(this.DbHelper, this.UserInfo);
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>(3);
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldAuditUserId, userId));
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldDeletionStateCode, 0));
            if (!manager.Exists(parameters))
            {
                // 2: 删除用户的审核步骤。
                returnValue = this.SetProperty(new KeyValuePair<string, object>(BaseWorkFlowStepEntity.FieldAuditUserId, userId), new KeyValuePair<string, object>(BaseWorkFlowStepEntity.FieldDeletionStateCode, 1));
                // 3: 同时把用户设置为无效。
                if (returnValue > 0)
                {
                    BaseUserManager userManager = new BaseUserManager(this.UserInfo);
                    userManager.SetProperty(new KeyValuePair<string, object>(BaseUserEntity.FieldId, userId), new KeyValuePair<string, object>(BaseUserEntity.FieldEnabled, 0));
                }
            }
            return returnValue;
        }
    }
}