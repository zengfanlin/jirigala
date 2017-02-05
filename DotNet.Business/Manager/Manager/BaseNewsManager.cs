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
    ///	新闻表
    ///	
    ///	修改记录
    /// 
    ///     2010.08.23 版本：2.6 JiRiGaLa    每个人管理每个人自己的文章。
    ///     2008.10.04 版本：2.5 JiRiGaLa    移动文件时的覆盖文件问题解决。
    ///     2007.05.30 版本：2.4 JiRiGaLa    ErrorDeleted，ErrorChanged 状态进行改进整理。
    ///	    2007.05.29 版本：2.3 JiRiGaLa    BatchSave，ErrorDataRelated，force 进行改进整理。
    ///	    2007.05.23 版本：2.2 JiRiGaLa    ReturnStatusCode，ReturnStatusMessage 进行改进。
    ///	    2007.05.12 版本：2.1 JiRiGaLa    BatchSave 进行改进。
    ///	    2007.01.04 版本：2.0 JiRiGaLa    重新整理主键。
    ///	    2006.02.12 版本：1.2 JiRiGaLa    调整主键的规范化。
    ///	    2006.02.12 版本：1.2 JiRiGaLa    调整主键的规范化。
    ///	    2004.11.19 版本：1.1 JiRiGaLa    增加职员类别判断部分。
    ///     2004.11.18 版本：1.0 JiRiGaLa    主键进行了绝对的优化，这是个好东西啊，平时要多用，用得要灵活些。
    ///		
    /// 版本：2.5
    /// </remarks>
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.10.04</date>
    /// </author> 
    /// </remarks>
    public partial class BaseNewsManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 只有草稿状态的才可以删除
        /// </summary>
        /// <param name="ids">主键</param>
        /// <returns>影响行数</returns>
        public override int SetDeleted(object[] ids, bool enabled = false, bool modifiedUser = false)
        {
            int returnValue = 0;
            for (int i = 0; i < ids.Length; i++)
            {
                // if (this.GetEntity(ids[i].ToString()).AuditStatus.Equals(AuditStatus.Draft.ToString()))
                // {
                returnValue += this.SetDeleted(ids[i], enabled, modifiedUser);
                //}
            }
            return returnValue;
        }


        public BaseNewsEntity GetNews(string id)
        {
            // 阅读次数要加一
            this.UpdateReadCount(id);
            return this.GetEntity(id);
        }

        private int UpdateReadCount(string id)
        {
            // 阅读次数要加一
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            sqlBuilder.SetFormula(BaseNewsEntity.FieldReadCount, BaseNewsEntity.FieldReadCount + " + 1 ");
            sqlBuilder.SetWhere(BaseNewsEntity.FieldId, id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 从数据库中读取文件
        /// </summary>
        /// <param name="id">文件主键</param>
        /// <returns>文件</returns>
        public string ShowNews(string id)
        {
            // 阅读次数要加一
            this.UpdateReadCount(id);
            // 下载文件
            string fileContent = null;
            string sqlQuery = " SELECT " + BaseNewsEntity.FieldContents
                            + "   FROM " + base.CurrentTableName
                            + "  WHERE " + BaseNewsEntity.FieldId + " = " + DbHelper.GetParameter(BaseNewsEntity.FieldId);
            IDataReader dataReader = null;
            try
            {
                dataReader = DbHelper.ExecuteReader(sqlQuery, new IDbDataParameter[] { DbHelper.MakeParameter(BaseNewsEntity.FieldId, id) });
                if (dataReader.Read())
                {
                    fileContent = dataReader[BaseNewsEntity.FieldContents].ToString();
                }
            }
            catch (System.Exception ex)
            {
                // 在本地记录异常
                BaseExceptionManager.LogException(DbHelper, UserInfo, ex);
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
            }
            return fileContent;
        }

        public string Upload(string folderId, string title, string contents)
        {
            // 检查是否已经存在
            string returnValue = this.GetId(new KeyValuePair<string, object>(BaseNewsEntity.FieldFolderId, folderId), new KeyValuePair<string, object>(BaseNewsEntity.FieldTitle, title));
            if (!String.IsNullOrEmpty(returnValue))
            {
                // 更新数据
                this.UpdateFile(returnValue, title, contents);
            }
            else
            {
                // 添加数据
                BaseNewsEntity fileEntity = new BaseNewsEntity();
                fileEntity.FolderId = folderId;
                fileEntity.Title = title;
                fileEntity.Contents = contents;
                returnValue = this.AddEntity(fileEntity);
            }
            return returnValue;
        }

        #region public DataTable GetDataTableByFolder(string folderid) 获取信息
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="folderid">主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByFolder(string folderid)
        {
            string sqlQuery = string.Empty;
            sqlQuery = " SELECT " + BaseNewsEntity.FieldId
                    + "        ," + BaseNewsEntity.FieldFolderId
                    + "        ," + BaseNewsEntity.FieldCode
                    + "        ," + BaseNewsEntity.FieldTitle
                    + "        ," + BaseNewsEntity.FieldHomePage
                    + "        ," + BaseNewsEntity.FieldSubPage
                    + "        ," + BaseNewsEntity.FieldFilePath
                    + "        ," + BaseNewsEntity.FieldFileSize
                    + "        ," + BaseNewsEntity.FieldReadCount
                    + "        ," + BaseNewsEntity.FieldCategoryCode
                    + "        ," + BaseNewsEntity.FieldDescription
                    + "        ," + BaseNewsEntity.FieldAuditStatus
                    + "        ," + BaseNewsEntity.FieldEnabled
                    + "        ," + BaseNewsEntity.FieldDeletionStateCode
                    + "        ," + BaseNewsEntity.FieldSortCode
                    + "        ," + BaseNewsEntity.FieldCreateUserId
                    + "        ," + BaseNewsEntity.FieldCreateBy
                    + "        ," + BaseNewsEntity.FieldCreateOn
                    + "        ," + BaseNewsEntity.FieldModifiedUserId
                    + "        ," + BaseNewsEntity.FieldModifiedBy
                    + "        ," + BaseNewsEntity.FieldModifiedOn
                    + "       , (SELECT " + BaseFolderEntity.FieldFolderName
                                + " FROM " + BaseFolderEntity.TableName
                                + " WHERE " + BaseFolderEntity.FieldId + " = " + BaseNewsEntity.FieldFolderId + ") AS FolderFullName "
                    + " FROM " + base.CurrentTableName
                    + " WHERE " + BaseNewsEntity.FieldFolderId + " = " + DbHelper.GetParameter(BaseNewsEntity.FieldFolderId)
                    + " ORDER BY " + BaseNewsEntity.FieldSortCode + " DESC ";
            return DbHelper.Fill(sqlQuery, new IDbDataParameter[] { DbHelper.MakeParameter(BaseNewsEntity.FieldFolderId, folderid) });
        }
        #endregion

        #region public string Add(BaseNewsEntity fileEntity, out string statusCode) 添加文件
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
        public string Add(BaseNewsEntity fileEntity, out string statusCode)
        {
            statusCode = string.Empty;
            string returnValue = string.Empty;
            // 检查是否重复
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseNewsEntity.FieldFolderId, fileEntity.FolderId));
            parameters.Add(new KeyValuePair<string, object>(BaseNewsEntity.FieldTitle, fileEntity.Title));
            parameters.Add(new KeyValuePair<string, object>(BaseNewsEntity.FieldDeletionStateCode, 0));

            if (this.Exists(parameters))
            {
                // 名称已重复
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                returnValue = this.AddEntity(fileEntity);
                // 运行成功
                statusCode = StatusCode.OKAdd.ToString();
            }
            return returnValue;
        }
        #endregion

        public int Update(BaseNewsEntity fileEntity, out string statusCode)
        {
            statusCode = string.Empty;
            int returnValue = this.UpdateEntity(fileEntity);
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

        public int UpdateFile(string id, string fileName, string contents)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            sqlBuilder.SetValue(BaseNewsEntity.FieldTitle, fileName);
            sqlBuilder.SetValue(BaseNewsEntity.FieldContents, contents);
            sqlBuilder.SetValue(BaseNewsEntity.FieldFileSize, contents.Length);
            sqlBuilder.SetValue(BaseNewsEntity.FieldModifiedUserId, UserInfo.Id);
            sqlBuilder.SetValue(BaseNewsEntity.FieldModifiedBy, UserInfo.RealName);
            sqlBuilder.SetDBNow(BaseNewsEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseNewsEntity.FieldId, id);
            return sqlBuilder.EndUpdate();
        }

        #region public DataTable Search(string searchValue) 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="search">查询</param>
        /// <returns>数据表</returns>
        public DataTable Search(string searchValue)
        {
            return this.Search(string.Empty, string.Empty, searchValue);
        }
        #endregion

        public DataTable Search(string departmetId, string userId, string searchValue)
        {
            return this.Search(departmetId, userId, string.Empty, searchValue);
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
        public DataTable Search(string departmetId, string userId, string categoryCode, string searchValue)
        {
            return Search(departmetId, userId, categoryCode, searchValue, null, null);
        }
        #endregion

        public DataTable Search(string departmetId, string userId, string categoryCode, string searchValue, bool? enabled, bool? deletionStateCode)
        {
            // 一、这里是将Boolean值转换为int类型。
            int delete = 0;
            if (deletionStateCode != null)
            {
                delete = (bool)deletionStateCode ? 1 : 0;
            }

            // 二、这里是开始进行动态SQL语句拼接，字段名、表明都进行了常量定义，表名字段名发生变化时，很容易就知道程序哪里都调用了这些。
            string sqlQuery = string.Empty;
            sqlQuery = " SELECT " + BaseNewsEntity.FieldId
                    + "        ," + BaseNewsEntity.FieldFolderId
                    + "        ," + BaseNewsEntity.FieldDepartmentId
                    + "        ," + BaseNewsEntity.FieldDepartmentName
                    + "        ," + BaseNewsEntity.FieldCategoryCode
                    + "        ," + BaseNewsEntity.FieldCode
                    + "        ," + BaseNewsEntity.FieldTitle
                    + "        ," + BaseNewsEntity.FieldIntroduction
                    + "        ," + BaseNewsEntity.FieldHomePage
                    + "        ," + BaseNewsEntity.FieldSubPage
                    + "        ," + BaseNewsEntity.FieldFilePath
                    + "        ," + BaseNewsEntity.FieldFileSize
                    + "        ," + BaseNewsEntity.FieldReadCount
                    + "        ," + BaseNewsEntity.FieldDescription
                    + "        ," + BaseNewsEntity.FieldAuditStatus
                    + "        ," + BaseNewsEntity.FieldEnabled
                    + "        ," + BaseNewsEntity.FieldDeletionStateCode
                    + "        ," + BaseNewsEntity.FieldSortCode
                    + "        ," + BaseNewsEntity.FieldCreateUserId
                    + "        ," + BaseNewsEntity.FieldCreateBy
                    + "        ," + BaseNewsEntity.FieldCreateOn
                    + "        ," + BaseNewsEntity.FieldModifiedUserId
                    + "        ," + BaseNewsEntity.FieldModifiedBy
                    + "        ," + BaseNewsEntity.FieldModifiedOn
                    + " FROM " + this.CurrentTableName
                    + " WHERE " + BaseNewsEntity.FieldDeletionStateCode + " = " + delete;

            if (enabled != null)
            {
                int isEnabled = (bool)enabled ? 1 : 0;
                sqlQuery += " AND " + BaseNewsEntity.FieldEnabled + " = " + isEnabled;
            }
            if (!string.IsNullOrEmpty(departmetId))
            {
                sqlQuery += " AND " + BaseNewsEntity.FieldDepartmentId + " = '" + departmetId + "' ";
            }
            // 三、我们认为 userId 这个查询条件是安全，不是人为输入的参数，所以直接进行了SQL语句拼接
            if (!String.IsNullOrEmpty(userId))
            {
                sqlQuery += " AND " + BaseNewsEntity.FieldCreateUserId + " = " + userId;
            }
            /*
            if (!String.IsNullOrEmpty(folderId))
            {
                sqlQuery += " AND " + BaseNewsEntity.FieldCategoryCode + " = " + folderId;
            }
            */

            if (!String.IsNullOrEmpty(categoryCode))
            {
                sqlQuery += " AND " + BaseNewsEntity.FieldCategoryCode + " = '" + categoryCode + "'";
            }

            // 四、这里是进行参数化的准备，因为是多个不确定的查询参数，所以用了List。
            List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();

            // 五、这里看查询条件是否为空
            searchValue = searchValue.Trim();
            if (!String.IsNullOrEmpty(searchValue))
            {
                // 六、这里是进行支持多种数据库的参数化查询
                sqlQuery += " AND (" + BaseNewsEntity.FieldTitle + " LIKE " + DbHelper.GetParameter(BaseNewsEntity.FieldTitle);
                sqlQuery += " OR " + BaseNewsEntity.FieldDepartmentName + " LIKE " + DbHelper.GetParameter(BaseNewsEntity.FieldDepartmentName);
                sqlQuery += " OR " + BaseNewsEntity.FieldCategoryCode + " LIKE " + DbHelper.GetParameter(BaseNewsEntity.FieldCategoryCode);
                sqlQuery += " OR " + BaseNewsEntity.FieldCreateBy + " LIKE " + DbHelper.GetParameter(BaseNewsEntity.FieldCreateBy);
                sqlQuery += " OR " + BaseNewsEntity.FieldContents + " LIKE " + DbHelper.GetParameter(BaseNewsEntity.FieldContents);
                sqlQuery += " OR " + BaseNewsEntity.FieldDescription + " LIKE " + DbHelper.GetParameter(BaseNewsEntity.FieldDescription) + ")";

                // 七、这里是判断，用户是否已经输入了%
                if (searchValue.IndexOf("%") < 0)
                {
                    searchValue = "%" + searchValue + "%";
                }

                // 八、这里生成支持多数据库的参数
                dbParameters.Add(DbHelper.MakeParameter(BaseNewsEntity.FieldTitle, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseNewsEntity.FieldDepartmentName, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseNewsEntity.FieldCategoryCode, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseNewsEntity.FieldCreateBy, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseNewsEntity.FieldContents, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseNewsEntity.FieldDescription, searchValue));
            }
            sqlQuery += " ORDER BY " + BaseNewsEntity.FieldSortCode + " DESC ";

            // 九、这里是将List转换为数组，进行数据库查询
            return DbHelper.Fill(sqlQuery, dbParameters.ToArray());
        }

        /// <summary>
        /// 移动（要考虑文件的覆盖问题，文件名重复了，需要覆盖文件的）
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="folderId">文件夹主键</param>
        /// <returns>影响行数</returns>
        public int MoveTo(string id, string folderId)
        {
            // 有重名的文件，需要进行覆盖
            string fileName = this.GetProperty(id, BaseNewsEntity.FieldTitle);
            this.Delete(new KeyValuePair<string, object>(BaseNewsEntity.FieldFolderId, folderId), new KeyValuePair<string, object>(BaseNewsEntity.FieldTitle, fileName));
            return this.SetProperty(id, new KeyValuePair<string, object>(BaseNewsEntity.FieldFolderId, folderId));
        }

        /// <summary>
        /// 按目录删除文件
        /// </summary>
        /// <param name="folderId">文件夹主键</param>
        /// <returns>影响行数</returns>
        public int DeleteByFolder(string folderId)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseNewsEntity.FieldFolderId, folderId));
        }
    }
}