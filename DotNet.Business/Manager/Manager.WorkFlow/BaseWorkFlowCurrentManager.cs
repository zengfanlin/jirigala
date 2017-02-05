//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Transactions;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseWorkFlowCurrentManager
    /// 流程管理.
    /// 
    /// 修改纪录
    ///		
    ///		2012.04.03 版本：4.0 JiRiGaLa	整理优化审批流程组件。
    ///		2010.10.11 版本：3.1 JiRiGaLa	发送提醒信息功能完善。
    ///		2010.10.11 版本：3.0 JiRiGaLa	流转历史、自动流转进行改进、审核流程进行彻底的测试完善。
    ///		2008.03.17 版本：2.0 JiRiGaLa	流转的单子到底到哪里了信息显示不够 进行改进。
    ///		2007.07.18 版本：1.0 JiRiGaLa	编写主键。
    /// 
    /// 版本：4.0
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.04.03</date>
    /// </author>
    /// </summary>
    public partial class BaseWorkFlowCurrentManager : BaseManager, IBaseManager
    {
        public string GetCurrentId(string categoryCode, string objectId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldCategoryCode, categoryCode));
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldObjectId, objectId));
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldDeletionStateCode, 0));
            return this.GetId(parameters);
        }

        /// <summary>
        /// 获取反射调用的类
        /// 回写状态时用
        /// </summary>
        /// <param name="currentId">当前工作流主键</param>
        /// <returns></returns>
        public IWorkFlowManager GetWorkFlowManager(string currentId)
        {
            IWorkFlowManager workFlowManager = new BaseUserBillManager();

            BaseWorkFlowCurrentEntity workFlowCurrentEntity = this.GetEntity(currentId);
            workFlowManager.SetUserInfo(this.UserInfo);
            workFlowManager.CurrentTableName = workFlowCurrentEntity.CategoryCode;
            
            string workFlowId = this.GetEntity(currentId).WorkFlowId.ToString();
            if (!workFlowId.Equals("0"))
            {
                BaseWorkFlowProcessManager workFlowProcessManager = new BaseWorkFlowProcessManager(this.DbHelper, this.UserInfo);
                BaseWorkFlowProcessEntity workFlowProcessEntity = new BaseWorkFlowProcessEntity();
                if (!string.IsNullOrEmpty(workFlowId))
                {
                    workFlowProcessEntity = workFlowProcessManager.GetEntity(workFlowId);
                }
                if (!string.IsNullOrEmpty(workFlowProcessEntity.CallBackClass))
                {
                    // 这里本来是想动态创建类库 编码外包[100]
                    Type objType = Type.GetType(workFlowProcessEntity.CallBackClass, true);
                    workFlowManager = (IWorkFlowManager)Activator.CreateInstance(objType);
                    workFlowManager.SetUserInfo(this.UserInfo);
                }
                if (!string.IsNullOrEmpty(workFlowProcessEntity.CallBackTable))
                {
                    // 这里本来是想动态创建类库 编码外包[100]
                    workFlowManager.CurrentTableName = workFlowProcessEntity.CallBackTable;
                }
            }
            // workFlowManager = new BaseUserBillManager(this.DbHelper, this.UserInfo);
            return workFlowManager;
        }

        /// <summary>
        /// 发送即时通讯提醒
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="auditStatus">审核状态</param>
        /// <param name="auditIdea">审核意见</param>
        /// <param name="userId">发送给用户主键</param>
        /// <param name="roleId">发送给角色主键</param>
        /// <returns>影响行数</returns>
        public int SendRemindMessage(string id, AuditStatus auditStatus, string auditIdea, string[] userIds, string[] organizeIds, string[] roleIds)
        {
            int returnValue = 0;
            // 发送请求审核的信息
            BaseMessageEntity messageEntity = new BaseMessageEntity();
            messageEntity.Id = BaseBusinessLogic.NewGuid();
            // 这里是回调的类，用反射要回调的
            messageEntity.FunctionCode = this.GetType().ToString();
            messageEntity.ObjectId = id;
            // 这里是网页上的显示地址
            // messageEntity.Title = this.GetUrl(id);
            // messageEntity.Content = BaseBusinessLogic.GetAuditStatus(auditStatus) + "：" + this.GetEntity(id).Title + " 请查收"
            //    + Environment.NewLine
            //    + this.GetUrl(id)
            //    + auditIdea;
            messageEntity.IsNew = 1;
            messageEntity.ReadCount = 0;
            messageEntity.Enabled = 1;
            messageEntity.DeletionStateCode = 0;
            BaseMessageManager messageManager = new BaseMessageManager(this.UserInfo);
            returnValue = messageManager.BatchSend(userIds, organizeIds, roleIds, messageEntity, false);
            return returnValue;
        }

        /// <summary>
        /// 获取第一步审核的
        /// </summary>
        /// <param name="categoryCode">单据分类</param>
        /// <param name="workFlowCode">审批流程编号</param>
        /// <returns>审核步骤</returns>
        public BaseWorkFlowActivityEntity GetFirstActivityEntity(string workFlowCode, string categoryCode = null)
        {
            BaseWorkFlowActivityEntity workFlowActivityEntity = null;

            string workFlowId = string.Empty;
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            // 这里是获取用户的工作流, 按用户主键，按模板编号
            if (string.IsNullOrEmpty(workFlowCode))
            {
                parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowBillTemplateEntity.FieldCategoryCode, categoryCode));
                parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowBillTemplateEntity.FieldDeletionStateCode, 0));
                BaseWorkFlowBillTemplateManager templateManager = new BaseWorkFlowBillTemplateManager(this.DbHelper, this.UserInfo);
                DataTable dt = templateManager.GetDataTable(parameters);
                BaseWorkFlowBillTemplateEntity templateEntity = new BaseWorkFlowBillTemplateEntity(dt);
                if (!string.IsNullOrEmpty(templateEntity.Id))
                {
                    workFlowCode = this.UserInfo.Id + "_" + templateEntity.Id;
                }
            }
            if (string.IsNullOrEmpty(workFlowCode))
            {
                return null;
            }
            // 1. 先检查工作流是否存在？
            BaseWorkFlowProcessManager workFlowProcessManager = new BaseWorkFlowProcessManager(this.DbHelper, this.UserInfo);

            parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldCode, workFlowCode));
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldDeletionStateCode, 0));

            string[] names = new string[] { BaseWorkFlowProcessEntity.FieldCode, BaseWorkFlowProcessEntity.FieldEnabled, BaseWorkFlowProcessEntity.FieldDeletionStateCode };  // 2010.01.25 LiangMingMing 将 BaseWorkFlowProcessEntity.FieldCode 改 BaseWorkFlowProcessEntity.FieldId
            object[] values = new object[] { workFlowCode, 1, 0 };
            workFlowId = workFlowProcessManager.GetId(parameters);
            if (string.IsNullOrEmpty(workFlowId))
            {
                return null;
            }
            // 2. 查找第一步是按帐户审核？还是按角色审核？
            BaseWorkFlowActivityManager workFlowActivityManager = new BaseWorkFlowActivityManager(this.DbHelper, this.UserInfo);
            // 2010.01.25 LiangMingMing 新加了两个参数new string[] { BaseWorkFlowActivityEntity.FieldWorkFlowId }, new string[] { Convert.ToString(workFlowId) },（具体获取哪个流程的步骤）

            parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowActivityEntity.FieldWorkFlowId, workFlowId.ToString()));
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowActivityEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowActivityEntity.FieldDeletionStateCode, 0));

            DataTable dataTable = workFlowActivityManager.GetDataTable(parameters);
            // 3. 取第一个排序的数据
            if (dataTable.Rows.Count == 0)
            {
                return null;
            }
            workFlowActivityEntity = new BaseWorkFlowActivityEntity(dataTable.Rows[0]);
            if ((workFlowActivityEntity.AuditUserId == null) && (workFlowActivityEntity.AuditRoleId == null))
            {
                return null;
            }
            return workFlowActivityEntity;
        }

        public BaseWorkFlowActivityEntity GetNextWorkFlowActivity(BaseWorkFlowCurrentEntity workFlowCurrentEntity)
        {
            BaseWorkFlowActivityEntity workFlowActivityEntity = null;
            DataTable dataTable = null;

            // 工作流主键
            string workFlowId = workFlowCurrentEntity.WorkFlowId.ToString();

            // 1. 从工作流审核步骤里选取审核步骤
            BaseWorkFlowStepManager workFlowStepManager = new BaseWorkFlowStepManager(this.DbHelper, this.UserInfo);

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowStepEntity.FieldCategoryCode, workFlowCurrentEntity.CategoryCode));
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowStepEntity.FieldObjectId, workFlowCurrentEntity.ObjectId));
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowStepEntity.FieldWorkFlowId, workFlowId));
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowStepEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowStepEntity.FieldDeletionStateCode, 0));

            dataTable = workFlowStepManager.GetDataTable(parameters, BaseWorkFlowStepEntity.FieldSortCode);

            if (dataTable.Rows.Count > 0)
            {
                dataTable.Columns.Remove(BaseWorkFlowStepEntity.FieldId);
                dataTable.Columns[BaseWorkFlowStepEntity.FieldActivityId].ColumnName = BaseWorkFlowStepEntity.FieldId;
            }
            else
            {
                // 2. 从工作流审核模板里选取审核步骤 下一步是多少？按工作流进行查找审核步骤
                BaseWorkFlowActivityManager workFlowActivityManager = new BaseWorkFlowActivityManager(this.DbHelper, this.UserInfo);

                parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowActivityEntity.FieldWorkFlowId, workFlowId));
                parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowActivityEntity.FieldEnabled, 1));
                parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowActivityEntity.FieldDeletionStateCode, 0));

                dataTable = workFlowActivityManager.GetDataTable(parameters, BaseWorkFlowActivityEntity.FieldSortCode);
            }

            // 审核步骤主键
            string activityId = string.Empty;
            if (workFlowCurrentEntity.ActivityId != null)
            {
                activityId = workFlowCurrentEntity.ActivityId.ToString();
            }
            if (dataTable.Rows.Count == 0)
            {
                return workFlowActivityEntity;
            }
            string nextActivityId = string.Empty;
            if (!string.IsNullOrEmpty(activityId))
            {
                nextActivityId = BaseSortLogic.GetNextId(dataTable, activityId.ToString());
            }
            else
            {
                nextActivityId = dataTable.Rows[0][BaseWorkFlowActivityEntity.FieldId].ToString();
            }
            if (!string.IsNullOrEmpty(nextActivityId))
            {
                // workFlowActivityEntity = workFlowActivityManager.GetEntity(nextActivityId);
                DataRow dataRow = BaseBusinessLogic.GetDataRow(dataTable, nextActivityId);
                workFlowActivityEntity = new BaseWorkFlowActivityEntity(dataRow);
            }
            return workFlowActivityEntity;
        }

        #region private string AddHistory(BaseWorkFlowCurrentEntity workFlowCurrentEntity) 添加到工作流审批流程历史
        private string AddHistory(BaseWorkFlowCurrentEntity workFlowCurrentEntity)
        {
            BaseWorkFlowHistoryEntity workFlowHistoryEntity = new BaseWorkFlowHistoryEntity();

            // 这些是待审核信息
            workFlowHistoryEntity.CurrentFlowId = workFlowCurrentEntity.Id;
            workFlowHistoryEntity.WorkFlowId = workFlowCurrentEntity.WorkFlowId;
            workFlowHistoryEntity.ActivityId = workFlowCurrentEntity.ActivityId;
            workFlowHistoryEntity.ActivityFullName = workFlowCurrentEntity.ActivityFullName;

            workFlowHistoryEntity.ToUserId = workFlowCurrentEntity.ToUserId;
            workFlowHistoryEntity.ToUserRealName = workFlowCurrentEntity.ToUserRealName;
            workFlowHistoryEntity.ToRoleId = workFlowCurrentEntity.ToRoleId;
            workFlowHistoryEntity.ToRoleRealName = workFlowCurrentEntity.ToRoleRealName;
            if (string.IsNullOrEmpty(workFlowCurrentEntity.ToDepartmentId))
            {
                workFlowHistoryEntity.ToDepartmentId = this.UserInfo.DepartmentId;
                workFlowHistoryEntity.ToDepartmentName = this.UserInfo.DepartmentName;
            }
            else
            {
                workFlowHistoryEntity.ToDepartmentId = workFlowCurrentEntity.ToDepartmentId;
                workFlowHistoryEntity.ToDepartmentName = workFlowCurrentEntity.ToDepartmentName;
            }

            workFlowHistoryEntity.AuditUserId = workFlowCurrentEntity.AuditUserId;
            workFlowHistoryEntity.AuditUserRealName = workFlowCurrentEntity.AuditUserRealName;

            workFlowHistoryEntity.AuditIdea = workFlowCurrentEntity.AuditIdea;
            workFlowHistoryEntity.AuditStatus = workFlowCurrentEntity.AuditStatus;
            workFlowHistoryEntity.AuditStatusName = workFlowCurrentEntity.AuditStatusName;

            workFlowHistoryEntity.SendDate = workFlowCurrentEntity.AuditDate;
            workFlowHistoryEntity.AuditDate = DateTime.Now;
            workFlowHistoryEntity.Description = workFlowCurrentEntity.Description;
            workFlowHistoryEntity.SortCode = workFlowCurrentEntity.SortCode;
            workFlowHistoryEntity.DeletionStateCode = workFlowCurrentEntity.DeletionStateCode;
            workFlowHistoryEntity.Enabled = workFlowCurrentEntity.Enabled;

            BaseWorkFlowHistoryManager workFlowHistoryManager = new BaseWorkFlowHistoryManager(DbHelper, UserInfo);
            return workFlowHistoryManager.AddEntity(workFlowHistoryEntity);
        }

        /// <summary>
        /// 添加到工作流审批流程历史
        /// </summary>
        /// <param name="currentId">当前工作流主键</param>
        /// <returns>主键</returns>
        private string AddHistory(string currentId)
        {
            // 读取一下，然后添加到历史记录表里
            BaseWorkFlowCurrentEntity workFlowCurrentEntity = this.GetEntity(currentId);
            return this.AddHistory(workFlowCurrentEntity);
        }
        #endregion

        #region public DataTable GetDataTableByPage(string userId, string searchValue, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = null, string sortDire = null)
        /// <summary>
        /// 按条件分页查询
        /// </summary>
        /// <param name="userId">查看用户</param>
        /// <param name="searchValue">查询字段</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDire">排序方向</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByPage(string userId, string searchValue, string categoryCode, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = "CreateOn", string sortDire = "DESC")
        {
            string whereConditional = BaseWorkFlowCurrentEntity.FieldDeletionStateCode + " = 0 ";
            if (!string.IsNullOrEmpty(categoryCode))
                whereConditional += " AND " + BaseWorkFlowCurrentEntity.FieldCategoryCode + " = '" + categoryCode + "'";
            searchValue = searchValue.Trim();
            if (!string.IsNullOrEmpty(searchValue))
            {
                searchValue = StringUtil.GetSearchString(searchValue);
                whereConditional += " AND (" + BaseWorkFlowCurrentEntity.FieldCreateBy + " LIKE " + searchValue;

                whereConditional += " OR " + BaseWorkFlowCurrentEntity.FieldObjectFullName + " LIKE " + searchValue;
                whereConditional += " OR " + BaseWorkFlowCurrentEntity.FieldActivityFullName + " LIKE " + searchValue;
                whereConditional += " OR " + BaseWorkFlowCurrentEntity.FieldToDepartmentName + " LIKE " + searchValue;
                whereConditional += " OR " + BaseWorkFlowCurrentEntity.FieldToUserRealName + " LIKE " + searchValue;
                whereConditional += " OR " + BaseWorkFlowCurrentEntity.FieldToRoleRealName + " LIKE " + searchValue;
                whereConditional += " OR " + BaseWorkFlowCurrentEntity.FieldAuditUserRealName + " LIKE " + searchValue;

                whereConditional += " OR " + BaseWorkFlowCurrentEntity.FieldModifiedBy + " LIKE " + searchValue + ")";
            }
            return GetDataTableByPage(out recordCount, pageIndex, pageSize, sortExpression, sortDire, this.CurrentTableName, whereConditional, "*");
        }
        #endregion

    }
}