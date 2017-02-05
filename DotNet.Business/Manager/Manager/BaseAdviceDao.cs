//-----------------------------------------------------------
// All Rights Reserved , Copyright (C) 2008 , ESSE , Ltd .
//-----------------------------------------------------------

using System;
using System.Data;

namespace DotNet.Common.Business
{
    using DotNet.Common.Model;
    using DotNet.Common.Utilities;
    using DotNet.Common.DbUtilities;

    /// <summary>
    /// BUBaseAdvice
    /// 建议
    ///		
    ///		2007.12.16 版本：3.0 JiRiGaLa 重新优化代码
    ///		2006.12.01 版本：2.0 DaLeng
    ///     2006.11.29 版本：1.0 JiRiGaLa 
    ///		
    /// 版本：3.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.12.16</date>
    /// </author> 
    /// </summary>
    public class BaseAdviceDao : BaseDao
    {
        public BaseAdviceDao()
        {
            base.CurrentTableName = BaseAdviceTable.TableName;
        }

        public BaseAdviceDao(IDbHelper dbHelper): this()
        {
            this.DbHelper = dbHelper;
        }

        public BaseAdviceDao(IDbHelper dbHelper, BaseUserInfo userInfo) : this(dbHelper)
        {
            this.UserInfo = userInfo;
        }

        #region private void SetEntity(OleDbSQLBuilder sqlBuilder, BaseAdviceEntity myAdviceEntity) 设置实体
        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">SQL生成器</param>
        /// <param name="myAdviceEntity">实体对象</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseAdviceEntity myAdviceEntity)
        {
            sqlBuilder.SetValue(BaseAdviceTable.FieldTitle, myAdviceEntity.Title);
            sqlBuilder.SetValue(BaseAdviceTable.FieldContent, myAdviceEntity.Content);
            sqlBuilder.SetValue(BaseAdviceTable.FieldPhone, myAdviceEntity.Phone);
            sqlBuilder.SetValue(BaseAdviceTable.FieldEmail, myAdviceEntity.Email);
            sqlBuilder.SetValue(BaseAdviceTable.FieldOICQ, myAdviceEntity.OICQ);
            sqlBuilder.SetValue(BaseAdviceTable.FieldMSN, myAdviceEntity.MSN);
            sqlBuilder.SetValue(BaseAdviceTable.FieldIPAddress, myAdviceEntity.IPAddress);
            sqlBuilder.SetValue(BaseAdviceTable.FieldPublicState, myAdviceEntity.PublicState);
            sqlBuilder.SetValue(BaseAdviceTable.FieldPriorityID, myAdviceEntity.PriorityID);
            sqlBuilder.SetValue(BaseAdviceTable.FieldDisposeStateID, myAdviceEntity.DisposeStateID);
            sqlBuilder.SetValue(BaseAdviceTable.FieldSendTo, myAdviceEntity.SendTo);
            sqlBuilder.SetValue(BaseAdviceTable.FieldSortCode, myAdviceEntity.SortCode);
            sqlBuilder.SetValue(BaseAdviceTable.FieldDescription, myAdviceEntity.Description);
            sqlBuilder.SetValue(BaseAdviceTable.FieldEnabled, myAdviceEntity.Enabled);
        }
        #endregion

        #region public String AddEntity(BaseAdviceEntity myAdviceEntity) 添加实体
        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="addressBookEntity">实体对象</param>
        /// <returns>代码</returns>
        public String AddEntity(BaseAdviceEntity myAdviceEntity)
        {
            String id = BaseSequenceDao.Instance.NewGuid();
            SQLBuilder sqlBuilder = new SQLBuilder(this.DbHelper);
            sqlBuilder.BeginInsert(BaseAdviceTable.TableName);
            sqlBuilder.SetValue(BaseAdviceTable.FieldID, id);
            this.SetEntity(sqlBuilder, myAdviceEntity);
            if (this.UserInfo != null)
            {
                sqlBuilder.SetValue(BaseAdviceTable.FieldCreateUserID, this.UserInfo.ID);
            }
            sqlBuilder.SetDBNow(BaseAdviceTable.FieldCreateDate);
            return sqlBuilder.EndInsert() > 0 ? id : String.Empty;
        }
        #endregion

        #region public int UpdateEntity(BaseAdviceEntity myAdviceEntity) 更新实体
        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="addressBookEntity">实体对象</param>
        /// <returns>影响行数</returns>
        public int UpdateEntity(BaseAdviceEntity myAdviceEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(this.DbHelper);
            sqlBuilder.BeginUpdate(BaseAdviceTable.TableName);
            this.SetEntity(sqlBuilder, myAdviceEntity);
            sqlBuilder.SetValue(BaseAdviceTable.FieldModifyUserID, this.UserInfo.ID);
            sqlBuilder.SetDBNow(BaseAdviceTable.FieldModifyDate);
            sqlBuilder.SetWhere(BaseAdviceTable.FieldID, myAdviceEntity.ID);
            return sqlBuilder.EndUpdate();
        }
        #endregion

        #region public override DataTable GetList() 获得建议列表
        /// <summary>
        /// 获得建议列表
        /// </summary>
        /// <returns>数据表</returns>
        public override DataTable GetList()
        {
            String sqlQuery = " SELECT * "
                             + ",(SELECT Fullname FROM " + BaseItemDetailsTable.TableName + " WHERE ID = A.PriorityID) AS PriorityFullName "
                             + ",(SELECT Fullname FROM " + BaseItemDetailsTable.TableName + " WHERE ID = A.DisposeStateID) AS DisposeStateFullName "
                             + ",(SELECT Fullname FROM " + BaseStaffTable.TableName + " WHERE ID = A.SendTo) AS SendToFullName "
                            + " FROM " + BaseAdviceTable.TableName + " AS A "
                            + " ORDER BY " + BaseAdviceTable.FieldSortCode;
            DataTable dataTable = new DataTable(BaseAdviceTable.TableName);
            this.DbHelper.Fill(dataTable, sqlQuery);
            return dataTable;
        }
        #endregion

        #region public DataTable GetListByUser() 获得我负责的建议列表
        /// <summary>
        /// 获得我负责的建议列表
        /// </summary>
        /// <returns>数据表</returns>
        public DataTable GetListByUser()
        {
            String sqlQuery = " SELECT * "
                             + ",(SELECT Fullname FROM " + BaseItemDetailsTable.TableName + " WHERE ID = A.PriorityID) AS PriorityFullName "
                             + ",(SELECT Fullname FROM " + BaseItemDetailsTable.TableName + " WHERE ID = A.DisposeStateID) AS DisposeStateFullName "
                             + ",(SELECT Fullname FROM " + BaseStaffTable.TableName + " WHERE ID = A.SendTo) AS SendToFullName "
                             + " FROM " + BaseAdviceTable.TableName + " AS A "
                             + " WHERE (" + BaseAdviceTable.FieldSendTo + " = ? )"
                             + " ORDER BY " + BaseAdviceTable.FieldSortCode;
            String[] names = new String[1];
            Object[] values = new Object[1];
            names[0] = BaseAdviceTable.FieldSendTo;
            values[0] = this.UserInfo.ID;
            DataTable dataTable = new DataTable(BaseAdviceTable.TableName);
            this.DbHelper.Fill(dataTable, sqlQuery, this.DbHelper.MakeParameters(names, values));
            return dataTable;
        }
        #endregion

        #region public DataTable Search(String search) 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="search">查询字符</param>
        /// <returns>数据表</returns>
        public DataTable Search(String search)
        {
            if (search.Length == 0)
            {
                return this.GetList();
            }
            search = BaseBusinessLogic.Instance.GetSearchString(search);
            String sqlQuery = " SELECT * "
                            + ",(SELECT Fullname FROM " + BaseItemDetailsTable.TableName + " WHERE ID = A.PriorityID) AS PriorityFullName "
                            + ",(SELECT Fullname FROM " + BaseItemDetailsTable.TableName + " WHERE ID = A.DisposeStateID) AS DisposeStateFullName "
                            + ",(SELECT Fullname FROM " + BaseStaffTable.TableName + " WHERE ID = A.SendTo) AS SendToFullName "
                            + " FROM " + BaseAdviceTable.TableName + " AS A "
                            + " WHERE ((" + BaseAdviceTable.FieldTitle + " LIKE ? )"
                            + " OR (" + BaseAdviceTable.FieldContent + " LIKE ? ))"
                            + " ORDER BY " + BaseAdviceTable.FieldSortCode;
            String[] names = new String[2];
            Object[] values = new Object[2];
            names[0] = BaseAdviceTable.FieldTitle;
            values[0] = search;
            names[1] = BaseAdviceTable.FieldContent;
            values[1] = search;
            DataTable dataTable = new DataTable(BaseAdviceTable.TableName);
            this.DbHelper.Fill(dataTable, sqlQuery, this.DbHelper.MakeParameters(names, values));
            return dataTable;
        }
        #endregion

        #region public DataTable SearchByStaff(String search) 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="search">查询字符</param>
        /// <returns>数据表</returns>
        public DataTable SearchByStaff(String search)
        {
            if (search.Length == 0)
            {
                return this.GetListByUser();
            }
            search = BaseBusinessLogic.Instance.GetSearchString(search);
            String sqlQuery = " SELECT * "
                            + ",(SELECT Fullname FROM " + BaseItemDetailsTable.TableName + " WHERE ID = A.PriorityID) AS PriorityFullName "
                            + ",(SELECT Fullname FROM " + BaseItemDetailsTable.TableName + " WHERE ID = A.DisposeStateID) AS DisposeStateFullName "
                            + ",(SELECT Fullname FROM " + BaseStaffTable.TableName + " WHERE ID = A.SendTo) AS SendToFullName "
                            + " FROM " + BaseAdviceTable.TableName + " AS A "
                            + " WHERE (((" + BaseAdviceTable.FieldTitle + " LIKE ? )"
                            + " OR (" + BaseAdviceTable.FieldContent + " LIKE ? ))"
                            + " AND (" + BaseAdviceTable.FieldSendTo + " = ? ))"
                            + " ORDER BY " + BaseAdviceTable.FieldSortCode;
            String[] names = new String[3];
            Object[] values = new Object[3];
            names[0] = BaseAdviceTable.FieldTitle;
            values[0] = search;
            names[1] = BaseAdviceTable.FieldContent;
            values[1] = search;
            names[2] = BaseAdviceTable.FieldSendTo;
            values[2] = this.UserInfo.ID;
            DataTable dataTable = new DataTable(BaseAdviceTable.TableName);
            this.DbHelper.Fill(dataTable, sqlQuery, this.DbHelper.MakeParameters(names, values));
            return dataTable;
        }
        #endregion

        #region public int SetPublicState(String[] ids, int publicState)
        /// <summary>
        /// 更新公开状态
        /// </summary>
        /// <param name="id">备忘录ID数组</param>
        /// <param name="publicState">原先状态</param>
        /// <returns>影响行数</returns>
        public int SetPublicState(String[] ids, int publicState)
        {
            int returnValue = 0;
            String id = String.Empty;
            for (int i = 0; i < ids.Length; i++)
            {
                id = ids[i];
                this.SetProperty(id, BaseAdviceTable.FieldPublicState, publicState.ToString());
            }
            return returnValue;
        }
        #endregion
    }
}