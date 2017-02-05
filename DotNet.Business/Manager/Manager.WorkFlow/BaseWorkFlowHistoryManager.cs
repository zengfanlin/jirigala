//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <remarks>
    /// BaseWorkFlowHistoryManager
    /// 获取权限
    /// 
    /// 修改纪录
    ///
    ///     2007.07.18 版本：1.0 JiRiGaLa Get
    ///     
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.07.18</date>
    /// </author>
    /// </remarks>
    public partial class BaseWorkFlowHistoryManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 获取审核记录
        /// </summary>
        /// <param name="currentFlowId">当前流程主键</param>
        /// <returns>审核记录</returns>
        public string GetAuditRecord(string currentFlowId)
        {
            string retuanValue = string.Empty;
            // 需要审核的人列表
            string auditList = string.Empty;
            if (!string.IsNullOrEmpty(currentFlowId))
            {
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowHistoryEntity.FieldCurrentFlowId, currentFlowId));
                parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowHistoryEntity.FieldDeletionStateCode, 0));

                DataTable dtAuditRecord = this.GetDataTable(parameters, BaseWorkFlowHistoryEntity.FieldSortCode);
                foreach (DataRow dataRow in dtAuditRecord.Rows)
                {
                    auditList += dataRow[BaseWorkFlowHistoryEntity.FieldToDepartmentName].ToString()
                    + "["
                    + dataRow[BaseWorkFlowHistoryEntity.FieldAuditUserRealName].ToString() + " "
                    + BaseBusinessLogic.GetAuditStatus(dataRow[BaseWorkFlowHistoryEntity.FieldAuditStatus].ToString())
                    + dataRow[BaseWorkFlowHistoryEntity.FieldAuditDate].ToString() 
                    + "] → ";
                }
                auditList = auditList.TrimEnd().TrimEnd('→');
            }
            return auditList;
        }
    }
}
