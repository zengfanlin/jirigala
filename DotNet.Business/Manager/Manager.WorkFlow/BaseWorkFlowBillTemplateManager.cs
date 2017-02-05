//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <remarks>
    ///	WorkFlowBillTemplateManager
    /// 单据模板表
    /// 工作流_模板单据表名
    /// 
    /// 修改纪录
    /// 
    ///		2011.11.23 版本：2.0 JiRiGaLa	支持Excel模板。
    ///		2011.09.06 版本：1.0 JiRiGaLa	创建。
    ///		
    /// 版本：1.0
    /// </remarks>
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.04.27</date>
    /// </author> 
    /// </remarks>
    public partial class BaseWorkFlowBillTemplateManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 只有草稿状态的才可以删除
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns>影响行数</returns>
        public override int SetDeleted(object[] ids, bool enabled, bool modifiedUser = false)
        {
            int returnValue = 0;
            for (int i = 0; i < ids.Length; i++)
            {
                if (this.GetEntity(ids[i].ToString()).AuditStatus.Equals(AuditStatus.Draft.ToString()))
                {
                    returnValue += this.SetDeleted(ids[i], enabled, modifiedUser);
                }
            }
            return returnValue;
        }

        #region public string Add(BaseWorkFlowBillTemplateEntity entity, out string statusCode) 添加文件
        /// <summary>
        /// 添加文件
        /// </summary>
        /// <param name="folderId">文件夹主键</param>
        /// <param name="fileName">文件名</param>
        /// <param name="file">文件</param>
        /// <param name="category">文件分类</param>
        /// <param name="enabled">有效</param>
        /// <param name="statusCode">状态</param>
        /// <returns>主键</returns>
        public string Add(BaseWorkFlowBillTemplateEntity entity, out string statusCode)
        {
            statusCode = string.Empty;
            string returnValue = string.Empty;
            // 检查是否重复
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowBillTemplateEntity.FieldTitle, entity.Title));
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowBillTemplateEntity.FieldDeletionStateCode, 0));

            if (this.Exists(parameters))
            {
                // 名称已重复
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                returnValue = this.AddEntity(entity);
                // 运行成功
                statusCode = StatusCode.OKAdd.ToString();
            }
            return returnValue;
        }
        #endregion

        public int Update(BaseWorkFlowBillTemplateEntity entity, out string statusCode)
        {
            statusCode = string.Empty;
            int returnValue = this.UpdateEntity(entity);
            if (returnValue > 0)
            {
                statusCode = StatusCode.OKUpdate.ToString();
            }
            else
            {
                statusCode = StatusCode.ErrorDeleted.ToString();
            }
            return returnValue;
        }

        #region public DataTable Search(string searchValue) 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="search">查询</param>
        /// <returns>数据表</returns>
        public DataTable Search(string searchValue)
        {
            return this.Search(string.Empty, searchValue);
        }
        #endregion

        public DataTable Search(string userId, string searchValue)
        {
            return this.Search(userId, string.Empty,searchValue);
        }

        #region public DataTable Search(string userId, string categoryCode, string searchValue) 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="categoryCode">目录</param>
        /// <param name="searchValue">查询条件</param>
        /// <param name="deletionStateCode">删除标志</param>
        /// <returns>数据表</returns>
        public DataTable Search(string userId, string categoryCode, string searchValue)
        {
            return Search(userId, categoryCode, searchValue, null, null);
        }
        #endregion

        public DataTable Search(string userId, string categoryCode, string searchValue, bool? enabled, bool? deletionStateCode)
        {
            // 一、这里是将Boolean值转换为int类型。
            int delete = 0;
            if (deletionStateCode != null)
            {
                delete = (bool)deletionStateCode ? 1:0;
            }

            // 二、这里是开始进行动态SQL语句拼接，字段名、表明都进行了常量定义，表名字段名发生变化时，很容易就知道程序哪里都调用了这些。
            string sqlQuery = string.Empty;
            sqlQuery = " SELECT " + BaseWorkFlowBillTemplateEntity.FieldId
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldCategoryCode
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldCode
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldTitle
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldIntroduction
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldDescription
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldAuditStatus
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldUseWorkFlow
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldEnabled
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldDeletionStateCode
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldSortCode
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldCreateUserId
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldCreateBy
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldCreateOn
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldModifiedUserId
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldModifiedBy
                    + "        ," + BaseWorkFlowBillTemplateEntity.FieldModifiedOn
                    + " FROM " + this.CurrentTableName
                    + " WHERE " + BaseWorkFlowBillTemplateEntity.FieldDeletionStateCode + " = " + delete;

            if (enabled != null)
            {
                int isEnabled = (bool)enabled ? 1 : 0;
                sqlQuery += " AND " + BaseWorkFlowBillTemplateEntity.FieldEnabled + " = " + isEnabled;
            }
            // 三、我们认为 userId 这个查询条件是安全，不是人为输入的参数，所以直接进行了SQL语句拼接
            if (!String.IsNullOrEmpty(userId))
            {
                sqlQuery += " AND " + BaseWorkFlowBillTemplateEntity.FieldCreateUserId + " = " + userId;
            }
            /*
            if (!String.IsNullOrEmpty(folderId))
            {
                sqlQuery += " AND " + BaseWorkFlowBillTemplateEntity.FieldCategoryCode + " = " + folderId;
            }
            */

            if (!String.IsNullOrEmpty(categoryCode))
            {
                sqlQuery += " AND " + BaseWorkFlowBillTemplateEntity.FieldCategoryCode + " = '" + categoryCode + "'";
            }

            // 四、这里是进行参数化的准备，因为是多个不确定的查询参数，所以用了List。
            List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();

            // 五、这里看查询条件是否为空
            searchValue = searchValue.Trim();
            if (!String.IsNullOrEmpty(searchValue))
            {
                // 六、这里是进行支持多种数据库的参数化查询
                sqlQuery += " AND (" + BaseWorkFlowBillTemplateEntity.FieldTitle + " LIKE " + DbHelper.GetParameter(BaseWorkFlowBillTemplateEntity.FieldTitle);
                sqlQuery += " OR " + BaseWorkFlowBillTemplateEntity.FieldCategoryCode + " LIKE " + DbHelper.GetParameter(BaseWorkFlowBillTemplateEntity.FieldCategoryCode);
                sqlQuery += " OR " + BaseWorkFlowBillTemplateEntity.FieldCreateBy + " LIKE " + DbHelper.GetParameter(BaseWorkFlowBillTemplateEntity.FieldCreateBy);
                sqlQuery += " OR " + BaseWorkFlowBillTemplateEntity.FieldContents + " LIKE " + DbHelper.GetParameter(BaseWorkFlowBillTemplateEntity.FieldContents);
                sqlQuery += " OR " + BaseWorkFlowBillTemplateEntity.FieldDescription + " LIKE " + DbHelper.GetParameter(BaseWorkFlowBillTemplateEntity.FieldDescription) + ")";

                // 七、这里是判断，用户是否已经输入了%
                if (searchValue.IndexOf("%") < 0)
                {
                    searchValue = "%" + searchValue + "%";
                }

                // 八、这里生成支持多数据库的参数
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowBillTemplateEntity.FieldTitle, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowBillTemplateEntity.FieldCategoryCode, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowBillTemplateEntity.FieldCreateBy, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowBillTemplateEntity.FieldContents, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowBillTemplateEntity.FieldDescription, searchValue));
            }
            sqlQuery += " ORDER BY " + BaseWorkFlowBillTemplateEntity.FieldSortCode + " DESC ";
            
            // 九、这里是将List转换为数组，进行数据库查询
            return DbHelper.Fill(sqlQuery, dbParameters.ToArray());
        }


        public string GetAddPage(string idOrCode)
        {
            return GetPage(idOrCode, "AddPage", "HtmlBillEdit.aspx?TemplateId={Id}");
        }

        public string GetShowPage(string idOrCode)
        {
            return GetPage(idOrCode, "ShowPage", "HtmlBillShow.aspx?Id={Id}");
        }

        public string GetEditPage(string idOrCode)
        {
            return GetPage(idOrCode, "EditPage", "HtmlBillEdit.aspx?Id={Id}");
        }

        public string GetListPage(string idOrCode)
        {
            return GetPage(idOrCode, "ListPage", "UserDraftAdmin.aspx");
        }

        public string GetAdminPage(string idOrCode)
        {
            return GetPage(idOrCode, "AdminPage", "UserDraftAdmin.aspx");
        }

        public string GetPage(string idOrCode, string page = "ShowPage", string defultPage = "HtmlBillEdit.aspx?TemplateId={Id}")
        {
            string returnValue = this.GetProperty(idOrCode, page);
            if (string.IsNullOrEmpty(returnValue))
            {
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldCode, idOrCode));
                parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldDeletionStateCode, 0));
                // parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldEnabled, 1));
                returnValue = this.GetProperty(parameters, page);
                if (string.IsNullOrEmpty(returnValue))
                {
                    returnValue = defultPage;
                }
            }
            return returnValue;
        }

        public override int SetDeleted(object id, bool enabled = false,  bool modifiedUser = false)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldCategoryCode, id));
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldDeletionStateCode, 0));
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldEnabled, 0));
            BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.UserInfo);
            // 若现在还有流程在用这个模板,就不可以被删除
            if (!workFlowCurrentManager.Exists(parameters))
            {
                return base.SetDeleted(id, enabled, modifiedUser);
            }
            return 0;
        }
    }
}