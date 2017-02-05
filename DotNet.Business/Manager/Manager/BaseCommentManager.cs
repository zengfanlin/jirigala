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

    /// <summary>
    ///BaseCommentManager
    /// 评论的基类
    /// 
    /// 考虑了多数据问题，但是还没有解决好。
    /// 是否使用存储过程标志改进
    /// 表名，字段名映射改进，可以更换表名，字段名
    /// 方法修改为静态方法，调用简单化
    /// 添加的参数名也为字段名一致
    /// 修改了是否处理的默认值为-1，这样方便切换是否处理这个状态。
    /// 
    /// 修改纪录
    /// 
    ///		2009.10.30 版本：4.6 JiRiGaLa	    TableName 可以自由设置的功能。
    ///		2006.02.05 版本：4.6 JiRiGaLa	    重新调整主键的规范化。
    ///		2005.08.13 版本：1.0 JiRiGaLa		将缺少的主键彻底完善好。
    ///		2005.07.11 版本：1.0 JiRiGaLa		主键排版更友善化。
    ///		2005.02.02 版本：1.0 JiRiGaLa		主键进行改进，规范化。
    ///		2004.07.23 版本：1.0 JiRiGaLa		标准接口进行了改进，来了装箱拆箱的Object技术，以前也是一直想玩，这次真的玩了感觉不错。
    ///											增加大分类为:功能提示Prompt,待审核WaitingAudit，代办事件Todolist，描述Memo。
    ///											修改了方法的排序顺序、这样方便大规模生产、复制粘贴、然后修改修改程序就可以了。
    ///											Worked 需要修改，所以为了简单期间用了1、-1两个状态。
    ///											其实整个系统里ID字段是不可以随便变的，一定要保持一致，除非有特殊需要。
    ///		2004.07.21 版本：1.0 JiRiGaLa		添加异常处理，让程序更加完美了一些，哎程序想写好，真是无止境。
    ///											增加GetProperty、SetProperty两个方法部分，同时增加了接口定义部分。
    ///		2004.07.20 版本：1.0 JiRiGaLa		分类ID字段修改为CategoryId，这样更符合更专业一点。
    ///											优先等级也修改为PriorityId，因为ID是唯一字段，Code为客户自定义字段。
    ///											出于外数据库外键的考虑，还是修改为ID合适，不然无法做数据库完整性校验。
    ///											方法的参数改进，程序的错误隐患少了很多，主键也进一步整理了。
    ///		2004.07.20 版本：1.0 JiRiGaLa		被修改的评论用最新产生的ID，这样可以解决被修改的不被发现的问题，有点创新啊。
    ///											同时2个人修改同一个评论的问题，虽然第二个问题发生的概率几乎是零。
    ///		2004.03.31 版本：1.0 JiRiGaLa		修改一些方法，修改发布评论的人为ID，因为以后有同名可能性,
    ///											添加主键折叠方法，添加最后修改人字段，IPAddress地址等．
    ///											尽量去掉SqlServer独有的方法，尽量满足能支持多数据的需求．
    ///		2004.03.22 版本：1.0 JiRiGaLa		变量名等进行修改，使用表结构定义等
    /// 
    /// 版本：4.6
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2006.02.05</date>
    /// </author> 
    /// </summary>
    public partial class BaseCommentManager : BaseManager, IBaseManager
    {
        #region public string Add(string categoryCode, string objectId, string contents, string ipAddress) 添加评论
        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="categoryCode">分类区分</param>
        /// <param name="objectId">标志区分</param>
        /// <param name="title">标题</param>
        /// <param name="contents">内容</param>
        /// <param name="worked">是否处理过</param>
        /// <param name="priorityId">优先级别</param>
        /// <param name="important">重要性</param>
        /// <param name="ipAddress">IP地址</param>
        /// <returns>评论主键</returns>
        public string Add(string categoryCode, string objectId, string contents, string ipAddress)
        {
            BaseCommentEntity commentEntity = new BaseCommentEntity();
            commentEntity.CreateUserId = UserInfo.Id;
            commentEntity.CategoryCode = categoryCode;
            commentEntity.ObjectId = objectId;
            commentEntity.Contents = contents;
            commentEntity.DeletionStateCode = 0;
            commentEntity.Enabled = 0;
            commentEntity.IPAddress = ipAddress;
            commentEntity.CreateBy = UserInfo.RealName;
            return this.Add(commentEntity, false, false);
        }
        #endregion

        #region public int Update(string id, string categoryId, string title, string content, bool worked, string priorityId, bool important) 更新评论
        /// <summary>
        /// 更新评论
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="categoryCode">分类区分</param>
        /// <param name="title">标题</param>
        /// <param name="contents">内容</param>
        /// <param name="worked">是否处理过</param>
        /// <param name="priorityID">优先级别</param>
        /// <param name="important">重要性</param>
        /// <returns>影响行数</returns>
        public int Update(string id, string categoryCode, string title, string contents, bool worked, string priorityId, bool important)
        {
            BaseCommentEntity commentEntity = new BaseCommentEntity();
            commentEntity.Id = id;
            commentEntity.ModifiedUserId = UserInfo.Id;
            commentEntity.CategoryCode = categoryCode;
            commentEntity.Title = title;
            commentEntity.Contents = contents;
            // commentEntity.Worked = worked;
            // commentEntity.PriorityId = priorityId;
            // commentEntity.Important = important;
            return this.Update(commentEntity);
        }
        #endregion

        #region public int ChangeWorked(string id) 更新处理状态
        /// <summary>
        /// 更新处理状态
        /// </summary>
        /// <param name="id">评论主键</param>
        /// <returns>影响行数</returns>
        public int ChangeWorked(string id)
        {
            int returnValue = 0;
            /*
            string sqlQuery = " UPDATE " + BaseCommentEntity.TableName
                            + "    SET " + BaseCommentEntity.FieldWorked + " = (CASE " + BaseCommentEntity.FieldWorked + " WHEN 0 THEN 1 WHEN 1 THEN 0 END)"
                            + "  WHERE (" + BaseCommentEntity.FieldId + " = ? )";
            string[] names = new string[1];
            Object[] values = new Object[1];
            names[0] = BaseCommentEntity.FieldId;
            values[0] = id;
            returnValue = DbHelper.ExecuteNonQuery(sqlQuery, DbHelper.MakeParameters(names, values));
            
             */
            return returnValue;
        }
        #endregion

        #region public int SetWorked(string[] id, int worked) 设置评论处理
        /// <summary>
        /// 设置评论处理
        /// </summary>
        /// <param name="id">评论主键数组</param>
        /// <param name="worked">处理状态</param>
        /// <returns>影响行数</returns>
        public int SetWorked(string[] ids, int worked)
        {
            int returnValue = 0;
            string id = string.Empty;
            try
            {
                DbHelper.BeginTransaction();
                for (int i = 0; i < ids.Length; i++)
                {
                    id = ids[i];
                    // returnValue += this.SetProperty(id, BaseCommentEntity.FieldWorked, worked.ToString());
                }
                DbHelper.CommitTransaction();
            }
            catch (Exception ex)
            {
                DbHelper.RollbackTransaction();
                BaseExceptionManager.LogException(DbHelper, UserInfo, ex);
                throw ex;
            }
            return returnValue;
        }
        #endregion

        #region public int ChageWorked(IDbHelper dbHelper, string id, bool worked) 更新处理状态
        /// <summary>
        /// 更新处理状态
        /// </summary>
        /// <param name="id">评论主键</param>
        /// <param name="worked">处理状态</param>
        /// <returns>影响行数</returns>
        public int ChageWorked(IDbHelper dbHelper, string id, bool worked)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            // sqlBuilder.SetValue(BaseCommentEntity.FieldWorked, worked ? 1 : -1);
            sqlBuilder.SetWhere(BaseCommentEntity.FieldId, id);
            return sqlBuilder.EndUpdate();
        }
        #endregion

        #region public DataTable Search(string departmentId, string searchValue) 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="departmentId">部门主键</param>
        /// <param name="search">查询字符</param>
        /// <returns>数据表</returns>
        public DataTable Search(string departmentId, string searchValue)
        {
            return this.Search(departmentId, string.Empty, string.Empty, searchValue);
        }
        #endregion

        #region  public DataTable Search(string departmentId, string year, string month, string searchValue) 查询具体方法
        /// <summary>
        /// 查询具体方法
        /// </summary>
        /// <param name="departmentId">部门主键</param>
        /// <param name="year">年</param>
        /// <param name="month">月</param>
        /// <param name="searchValue">查询字符</param>
        /// <returns>数据表</returns>
        public DataTable Search(string departmentId, string year, string month, string searchValue)
        {
            DataTable dataTable = new DataTable(this.CurrentTableName);
            string sqlQuery = " SELECT * "
                                + " FROM " + this.CurrentTableName
                                + " WHERE (" + BaseCommentEntity.FieldDeletionStateCode + " = 0) ";

            if (!String.IsNullOrEmpty(departmentId))
            {
                sqlQuery += " AND " + BaseCommentEntity.FieldDepartmentId + " = '" + departmentId + "'";
            }

            List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();
            if (!String.IsNullOrEmpty(year) && (!year.Equals("All")))
            {
                sqlQuery += " AND YEAR(" + BaseCommentEntity.FieldCreateOn + ") = " + DbHelper.GetParameter("CurrentYear");
                dbParameters.Add(DbHelper.MakeParameter("CurrentYear", year));
            }
            if (!String.IsNullOrEmpty(month) && (!month.Equals("All")))
            {
                sqlQuery += " AND MONTH(" + BaseCommentEntity.FieldCreateOn + ") = " + DbHelper.GetParameter("CurrentMonth");
                dbParameters.Add(DbHelper.MakeParameter("CurrentMonth", month));
            }
            if (!String.IsNullOrEmpty(searchValue))
            {
                sqlQuery += " AND (" + BaseCommentEntity.FieldTitle + " LIKE " + DbHelper.GetParameter(BaseCommentEntity.FieldTitle);
                sqlQuery += " OR " + BaseCommentEntity.FieldCreateBy + " LIKE " + DbHelper.GetParameter(BaseCommentEntity.FieldCreateBy);
                sqlQuery += " OR " + BaseCommentEntity.FieldContents + " LIKE " + DbHelper.GetParameter(BaseCommentEntity.FieldContents) + ")";
                // += " OR (CONVERT (NVARCHAR(10), " + BaseCommentEntity.FieldCreateOn + ", 20) LIKE ? ) "
                searchValue = StringUtil.GetSearchString(searchValue);
                dbParameters.Add(DbHelper.MakeParameter(BaseCommentEntity.FieldTitle, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseCommentEntity.FieldCreateBy, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseCommentEntity.FieldContents, searchValue));
            }
            sqlQuery += " ORDER BY " + BaseCommentEntity.FieldSortCode + " DESC ";
            DbHelper.Fill(dataTable, sqlQuery, dbParameters.ToArray());
            return dataTable;
        }
        #endregion

        #region public DataTable GetPreviousNextId(string id) 获得主键列表中的，上一条，下一条记录的主键
        /// <summary>
        /// 获得主键列表中的，上一条，下一条记录的主键
        /// </summary>
        /// <param name="id">评论主键</param>
        /// <returns>数据表</returns>
        public DataTable GetPreviousNextId(string id)
        {
            string sqlQuery = "   SELECT Id "
                            + "     FROM " + BaseCommentEntity.TableName
                            + "    WHERE (" + BaseCommentEntity.FieldCreateUserId + " = ?) "
                            + " ORDER BY " + BaseCommentEntity.FieldSortCode;
            string[] names = new string[1];
            Object[] values = new Object[1];
            names[0] = BaseCommentEntity.FieldCreateUserId;
            values[0] = UserInfo.Id;
            DataTable dataTable = new DataTable(BaseCommentEntity.TableName);
            DbHelper.Fill(dataTable, sqlQuery, DbHelper.MakeParameters(names, values));
            // this.NextId = this.GetNextId(dataTable, UserInfo, id);
            // this.PreviousId = this.GetPreviousId(dataTable, UserInfo, id);
            return dataTable;
        }
        #endregion

        #region  public DataTable GetDataTableByCategory(string categoryCode, int topLimit) 获得最新评论列表
        /// <summary>
        /// 获得最新评论列表
        /// </summary>
        /// <param name="categoryCode">评论类别</param>
        /// <param name="topLimit">前几个</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByCategory(string categoryCode, int topLimit)
        {
            List<KeyValuePair<string, object>> parametersList = new List<KeyValuePair<string, object>>();
            parametersList.Add(new KeyValuePair<string, object>(BaseCommentEntity.FieldCategoryCode, categoryCode));
            parametersList.Add(new KeyValuePair<string, object>(BaseCommentEntity.FieldDeletionStateCode, 0));
            parametersList.Add(new KeyValuePair<string, object>(BaseCommentEntity.FieldEnabled, 1));
            return this.GetDataTable(parametersList, topLimit, BaseCommentEntity.FieldSortCode + " DESC");
        }
        #endregion

        #region public DataTable GetDataTableByCategory(string categoryId, string objectId) 获取评论列表
        /// <summary>
        /// 获取评论列表
        /// </summary>
        /// <param name="categoryCode">分类主键</param>
        /// <param name="objectId">标志主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByCategory(string categoryCode, string objectId)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseCommentEntity.FieldCategoryCode, categoryCode));
            parameters.Add(new KeyValuePair<string, object>(BaseCommentEntity.FieldObjectId, objectId));
            parameters.Add(new KeyValuePair<string, object>(BaseCommentEntity.FieldDeletionStateCode, 0));
            return this.GetDataTable(parameters, BaseCommentEntity.FieldCreateOn);
        }
        #endregion

        #region public DataTable GetDataTableByPage(BaseUserInfo userInfo, string departmentId, string searchValue, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = null, string sortDire = null) 分页查询
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="userInfo"></param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDire">排序方向</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByPage(BaseUserInfo userInfo,  out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = null, string sortDire = null)
        {
            string whereConditional = BaseRoleEntity.FieldDeletionStateCode + " = 0 ";
            return GetDataTableByPage(out recordCount, pageIndex, pageSize, sortExpression, sortDire, this.CurrentTableName, whereConditional, "*");
        }

        #endregion

    }
}