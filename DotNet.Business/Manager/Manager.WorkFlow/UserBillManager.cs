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
    ///	BaseUserBillManager
    /// 用户审批单据
    /// 工作流_用户单据表名
    /// 
    /// 修改纪录
    /// 
    ///		2011.09.06 版本：1.0 JiRiGaLa	创建。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.09.06</date>
    /// </author> 
    /// </summary>
    public partial class BaseUserBillManager : BaseNewsManager
    {
        public BaseUserBillManager()
        {
            base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType, BaseSystemInfo.WorkFlowDbConnection);
            this.CurrentTableName = "BaseWorkFlowUserBill";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseUserBillManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseUserBillManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseUserBillManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseUserBillManager(IDbHelper dbHelper, BaseUserInfo userInfo)
            : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public BaseUserBillManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 检索数据
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="categoryCode">单据类别</param>
        /// <param name="searchValue">关键字</param>
        /// <param name="enabled">是否有效</param>
        /// <param name="deletionStateCode">是否删除</param>
        /// <returns></returns>
        public DataTable SearchBill(string userId, string categoryId, string categorybillFullName, string searchValue, bool? enabled, bool? deletionStateCode)
        {
            int delete = 0;
            if (deletionStateCode != null)
            {
                delete = (bool)deletionStateCode ? 1 : 0;
            }
            string sqlQuery = string.Empty;
            sqlQuery = " SELECT " + BaseWorkFlowBillTemplateEntity.FieldId
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldCategoryCode
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldTitle
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldCode
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldIntroduction
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldAuditStatus
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldModifiedUserId
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldModifiedBy
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldModifiedOn
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldCreateOn
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldSortCode
                    + " FROM " + this.CurrentTableName
                    + " WHERE " + BaseWorkFlowBillTemplateEntity.FieldDeletionStateCode + " = " + delete;
            if (enabled != null)
            {
                int isEnabled = (bool)enabled ? 1 : 0;
                sqlQuery += " AND " + BaseWorkFlowBillTemplateEntity.FieldEnabled + " = " + isEnabled;
            }
            if (!String.IsNullOrEmpty(userId))
            {
                sqlQuery += " AND " + BaseWorkFlowBillTemplateEntity.FieldCreateUserId + " = " + userId;
            }
            if (!string.IsNullOrEmpty(categoryId))
            {
                BaseWorkFlowBillTemplateManager templateManager = new BaseWorkFlowBillTemplateManager(this.DbHelper, this.UserInfo);
                DataTable dataTable = templateManager.Search(string.Empty, categoryId, string.Empty, null, false);
                string categoryIds = BaseBusinessLogic.FieldToList(dataTable, BaseWorkFlowBillTemplateEntity.FieldId);
                if (!string.IsNullOrEmpty(categoryIds))
                {
                    sqlQuery += " AND (" + BaseWorkFlowBillTemplateEntity.FieldCategoryCode + " IN (" + categoryIds + ")) ";
                }
            }
            if (!String.IsNullOrEmpty(categorybillFullName))
            {
                sqlQuery += " AND " + BaseWorkFlowBillTemplateEntity.FieldCategoryCode + " = '" + categorybillFullName + "'";
            }
            List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();
            searchValue = searchValue.Trim();
            if (!String.IsNullOrEmpty(searchValue))
            {
                sqlQuery += " AND (" + BaseWorkFlowBillTemplateEntity.FieldTitle + " LIKE " + DbHelper.GetParameter(BaseWorkFlowBillTemplateEntity.FieldTitle);
                sqlQuery += " OR " + BaseWorkFlowBillTemplateEntity.FieldCode + " LIKE " + DbHelper.GetParameter(BaseWorkFlowBillTemplateEntity.FieldCode);
                sqlQuery += " OR " + BaseWorkFlowBillTemplateEntity.FieldCategoryCode + " LIKE " + DbHelper.GetParameter(BaseWorkFlowBillTemplateEntity.FieldCategoryCode);
                sqlQuery += " OR " + BaseWorkFlowBillTemplateEntity.FieldModifiedBy + " LIKE " + DbHelper.GetParameter(BaseWorkFlowBillTemplateEntity.FieldModifiedBy);
                sqlQuery += " OR " + BaseWorkFlowBillTemplateEntity.FieldIntroduction + " LIKE " + DbHelper.GetParameter(BaseWorkFlowBillTemplateEntity.FieldIntroduction) + ")";
                if (searchValue.IndexOf("%") < 0)
                {
                    searchValue = "%" + searchValue + "%";
                }
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowBillTemplateEntity.FieldTitle, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowBillTemplateEntity.FieldCode, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowBillTemplateEntity.FieldCategoryCode, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowBillTemplateEntity.FieldModifiedBy, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowBillTemplateEntity.FieldIntroduction, searchValue));
            }
            sqlQuery += " ORDER BY " + BaseWorkFlowBillTemplateEntity.FieldSortCode + " DESC ";
            return DbHelper.Fill(sqlQuery, dbParameters.ToArray());
        }
    }
}