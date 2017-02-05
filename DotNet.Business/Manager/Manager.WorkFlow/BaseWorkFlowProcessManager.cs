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
	/// BaseWorkFlowManager
	/// 流程管理的表结构定义部分
	/// 
	///	修改纪录
	///		2007.03.15 版本：2.0 JiRiGaLa	规范表结构。
	///		2006.05.11 版本：1.1 JiRiGaLa	重新调整主键的规范化。
	/// 
	/// 版本：1.0
	/// 
	/// <author>
	///		<name>JiRiGaLa</name>
	///		<date>2006.05.11</date>
	/// </author> 
	/// </summary>
	public partial class BaseWorkFlowProcessManager : BaseManager
	{
        /// <summary>
        /// 获取反射调用的类
        /// 回写状态时用
        /// </summary>
        /// <param name="code">当前工作流主键</param>
        /// <returns></returns>
        public IWorkFlowManager GetWorkFlowManagerByCode(string code)
        {
            string id = this.GetIdByCode(code);
            return GetWorkFlowManager(id);
        }

        public IWorkFlowManager GetWorkFlowManager(string id)
        {
            IWorkFlowManager workFlowManager = null;
            BaseWorkFlowProcessEntity  workFlowProcessEntity = this.GetEntity(id);
            if (!string.IsNullOrEmpty(workFlowProcessEntity.CallBackClass))
            {
                // 这里本来是想动态创建类库 编码外包[100]
                Type objType = Type.GetType(workFlowProcessEntity.CallBackClass, true);
                workFlowManager = (IWorkFlowManager)Activator.CreateInstance(objType);
                workFlowManager.SetUserInfo(this.UserInfo);
                if (!string.IsNullOrEmpty(workFlowProcessEntity.CallBackTable))
                {
                    workFlowManager.CurrentTableName = workFlowProcessEntity.CallBackTable;
                }
            }
            // workFlowManager = new BaseUserBillManager(this.DbHelper, this.UserInfo);
            return workFlowManager;
        }

        /// <summary>
        /// 获取具体的审批流程
        /// </summary>
        /// <param name="workFlowCode">工作流程编号</param>
        /// <returns>流程</returns>
        public string GetProcessId(BaseUserInfo userInfo, string workFlowCode)
        {
            // 这里处理单据编号
            string workFlowId = string.Empty;
            // 1：按用户的审核是否存在
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldCode, workFlowCode));
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldUserId, userInfo.Id));
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldAuditCategoryCode, "ByUser"));
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldEnabled, 1));
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldDeletionStateCode, 0));
            workFlowId = this.GetProperty(parameters, BaseWorkFlowProcessEntity.FieldId);
            if (string.IsNullOrEmpty(workFlowId))
            {
                // 2: 找部门的审核是否存在
                parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldCode, workFlowCode));
                parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldOrganizeId, userInfo.DepartmentId));
                parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldAuditCategoryCode, "ByOrganize"));
                parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldEnabled, 1));
                parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldDeletionStateCode, 0));
                workFlowId = this.GetProperty(parameters, BaseWorkFlowProcessEntity.FieldId);
            }
            if (string.IsNullOrEmpty(workFlowId))
            {
                // 3：若找不到用户的接着找按单据的审核是否存在
                parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldCode, workFlowCode));
                parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldAuditCategoryCode, "ByTemplate"));
                parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldEnabled, 1));
                parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldDeletionStateCode, 0));
                workFlowId = this.GetProperty(parameters, BaseWorkFlowProcessEntity.FieldId);
            }
            return workFlowId;
        }
        
		#region public DataTable GetListByOrganize(string organizeId) 按部门获得列表
		/// <summary>
		/// 按部门获得列表
		/// </summary>
		/// <param name="organizeId">部门主键</param>
		/// <returns>记录集</returns>
		public DataTable GetListByOrganize(string organizeId)
		{
			return this.GetDataTable(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldOrganizeId, organizeId));
		}
		#endregion

		#region public string Add(BaseWorkFlowProcessEntity workFlowProcessEntity, out string statusCode)
		/// <summary>
		/// 添加
		/// </summary>
		/// <param name="workFlowEntity">实体</param>
		/// <param name="statusCode">返回状态码</param>
		/// <returns>主键</returns>
		public string Add(BaseWorkFlowProcessEntity workFlowProcessEntity, out string statusCode)
		{
			string returnValue = string.Empty;
			// 检查编号是否重复
			if (this.Exists(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldDeletionStateCode, 0), new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldCode, workFlowProcessEntity.Code)))
			{
				// 编号已重复
				statusCode = StatusCode.ErrorCodeExist.ToString();
			}
			else
			{
				returnValue = this.AddEntity(workFlowProcessEntity);
				// 运行成功
				statusCode = StatusCode.OKAdd.ToString();
			}
			return returnValue;
		}
		#endregion

		#region public int Update(BaseWorkFlowProcessEntity workFlowProcessEntity, out string statusCode)
		/// <summary>
		/// 更新
		/// </summary>
		/// <param name="workFlowProcessEntity">实体</param>
		/// <param name="statusCode">返回状态码</param>
		/// <returns>影响行数</returns>
		public int Update(BaseWorkFlowProcessEntity workFlowProcessEntity, out string statusCode)
		{
			int returnValue = 0;
			// 检查编号是否重复
			if (this.Exists(new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldDeletionStateCode, 0), new KeyValuePair<string, object>(BaseWorkFlowProcessEntity.FieldCode, workFlowProcessEntity.Code), workFlowProcessEntity.Id))
			{
				// 文件夹名已重复
				statusCode = StatusCode.ErrorCodeExist.ToString();
			}
			else
			{
				// 进行更新操作
				returnValue = this.UpdateEntity(workFlowProcessEntity);
				if (returnValue == 1)
				{
					statusCode = StatusCode.OKUpdate.ToString();
				}
				else
				{
					// 数据可能被删除
					statusCode = StatusCode.ErrorDeleted.ToString();
				}
			}
			return returnValue;
		}
		#endregion

		#region public new int BatchSave(DataTable dataTable) 批量进行保存
		/// <summary>
		/// 批量进行保存
		/// </summary>
		/// <param name="dataSet">数据权限</param>
		/// <returns>影响行数</returns>
		public new int BatchSave(DataTable dataTable)
		{
			int returnValue = 0;
			foreach (DataRow dataRow in dataTable.Rows)
			{
				BaseWorkFlowProcessEntity workFlowProcessEntity = new BaseWorkFlowProcessEntity(dataRow);
				// 删除状态
				if (dataRow.RowState == DataRowState.Deleted)
				{
					string id = dataRow[BaseWorkFlowProcessEntity.FieldId, DataRowVersion.Original].ToString();
					if (id.Length > 0)
					{
						returnValue += this.Delete(id);
					}
				}
				// 被修改过
				if (dataRow.RowState == DataRowState.Modified)
				{
					string id = dataRow[BaseWorkFlowProcessEntity.FieldId, DataRowVersion.Original].ToString();
					if (id.Length > 0)
					{
                        workFlowProcessEntity.GetFrom(dataRow);
						// 判断是否允许编辑
						returnValue += this.Update(workFlowProcessEntity);
					}
				}
				// 添加状态
				if (dataRow.RowState == DataRowState.Added)
				{
                    workFlowProcessEntity.GetFrom(dataRow);
					returnValue += this.Add(workFlowProcessEntity).Length > 0 ? 1 : 0;
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

        #region public override DataTable GetDataTable(string id) 按主键获取记录
        /// <summary>
        /// 按主键获取记录
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public override DataTable GetDataTable(string id)
        {
           string sqlQuery = @"SELECT * 
                                      ,( SELECT BaseWorkFlowBillTemplate.Title 
                                          FROM BaseWorkFlowBillTemplate
                                          WHERE BaseWorkFlowBillTemplate.Id 
                                                  = BaseWorkFlowProcess.BillTemplateId 
                                                    ) AS BillTemplateName
                                      ,( Case BaseWorkFlowProcess.AuditCategoryCode 
                                           WHEN 'ByTemplate' THEN '按模版流程' 
                                           WHEN 'ByOrganize' THEN '按组织机构流程'
                                           WHEN 'ByUser' THEN '按用户流程' 
                                           END 
                                             ) AS AuditCategoryName
                                  FROM BaseWorkFlowProcess 
                                  WHERE Id = '" + id + "'";
           return dbHelper.Fill(sqlQuery);
        }
        #endregion
    }
}