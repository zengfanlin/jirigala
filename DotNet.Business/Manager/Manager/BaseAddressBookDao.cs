//------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2008 , ESSE , Ltd. 
//------------------------------------------------------------

using System;
using System.Data;

namespace DotNet.Common.Business
{
    using DotNet.Common.Model;
    using DotNet.Common.Utilities;
    using DotNet.Common.DbUtilities;

    /// <summary>
    /// BaseAddressBookDao
    /// 
    /// 修改纪录
    ///     2007.2.28 版本：1.0 JiRiGaLa     
    ///     
    /// 版本：2.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.02.28</date>
    /// </author>
	/// </summary>
    [Serializable]
    public class BaseAddressBookDao : BaseDao
    {
        public String PreviousID    = String.Empty;    // 上一个记录代码。
        public String NextID        = String.Empty;    // 下一个记录代码。

        public BaseAddressBookDao()
        {
            base.CurrentTableName = BaseAddressBookTable.TableName;
        }

		private String defaultorder;
		public String DefaultOrder
		{
			get
			{
                defaultorder = BaseAddressBookTable.FieldSortCode;
				return defaultorder;
			}
		}
		
        #region public void ClearProperty() 清空内容
        /// <summary>
		/// 清空内容
		/// </summary>
        public void ClearProperty(BaseAddressBookEntity addressBookEntity)
		{
            addressBookEntity.FullName = String.Empty;
            addressBookEntity.CompanyName = String.Empty;
            addressBookEntity.Adress = String.Empty;
            addressBookEntity.Duty = String.Empty;
            addressBookEntity.Telephone = String.Empty;
            addressBookEntity.Mobile = String.Empty;
            addressBookEntity.Mail = String.Empty;
            addressBookEntity.Relation = String.Empty;
        }                                           
		#endregion

        #region public BaseAddressBookEntity GetFrom(DataRow myDataRow, BaseAddressBookEntity addressBookEntity) 从数据行读取
        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="myDataRow">数据行</param>
        /// <returns>通讯录的基类表结构定义</returns>
        public BaseAddressBookEntity GetFrom(DataRow myDataRow, BaseAddressBookEntity addressBookEntity)
        {
            addressBookEntity.ID = myDataRow[BaseAddressBookTable.FieldID].ToString();      // 代码
            addressBookEntity.FullName = myDataRow[BaseAddressBookTable.FieldFullName].ToString();// 联系人
            addressBookEntity.CompanyName = myDataRow[BaseAddressBookTable.FieldCompanyName].ToString();         // 公司名称 
            addressBookEntity.Adress = myDataRow[BaseAddressBookTable.FieldAdress].ToString();  // 地址
            addressBookEntity.Duty = myDataRow[BaseAddressBookTable.FieldDuty].ToString();    // 职务
            addressBookEntity.Telephone = myDataRow[BaseAddressBookTable.FieldTelephone].ToString();           // 电话
            addressBookEntity.Mobile = myDataRow[BaseAddressBookTable.FieldMobile].ToString();  // 手机
            addressBookEntity.Mail = myDataRow[BaseAddressBookTable.FieldMail].ToString();    // 邮件
            addressBookEntity.Relation = myDataRow[BaseAddressBookTable.FieldRelation].ToString();// 关系
            addressBookEntity.Enabled = myDataRow[BaseAddressBookTable.FieldEnabled].ToString().Equals("1"); // 有效性
            addressBookEntity.Description = myDataRow[BaseAddressBookTable.FieldDescription].ToString();         // 排序
            addressBookEntity.SortCode = myDataRow[BaseAddressBookTable.FieldSortCode].ToString();// 备注
            addressBookEntity.CreateUserID = myDataRow[BaseAddressBookTable.FieldCreateUserID].ToString();       // 创建者
            addressBookEntity.CreateDate = myDataRow[BaseAddressBookTable.FieldCreateDate].ToString();          // 创建时间
            addressBookEntity.ModifyUserID = myDataRow[BaseAddressBookTable.FieldModifyUserID].ToString();       // 最后修改者
            addressBookEntity.ModifyDate = myDataRow[BaseAddressBookTable.FieldModifyDate].ToString();          // 最后修改时间
            return addressBookEntity;
        }
        #endregion

        #region public String Add(BaseAddressBookEntity addressBookEntity) 添加
        /// <summary>
		/// 添加
		/// </summary>
        /// <param name="addressBookEntity">实体</param>
		/// <returns>代码</returns>
        public String Add(BaseAddressBookEntity addressBookEntity)
		{
			String returnValue = String.Empty;
            String sequence = BaseSequenceDao.Instance.GetSequence(this.DbHelper, BaseAddressBookTable.TableName);
            SQLBuilder mySQLBuilder = new SQLBuilder(this.DbHelper);
            int enabled = addressBookEntity.Enabled ? 1 : 0;
            mySQLBuilder.BeginInsert(BaseAddressBookTable.TableName);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldID, sequence);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldFullName, addressBookEntity.FullName);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldCompanyName, addressBookEntity.CompanyName);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldAdress, addressBookEntity.Adress);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldDuty, addressBookEntity.Duty);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldTelephone, addressBookEntity.Telephone);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldMobile, addressBookEntity.Mobile);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldMail, addressBookEntity.Mail);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldRelation, addressBookEntity.Relation);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldEnabled, enabled);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldDescription, addressBookEntity.Description);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldSortCode, sequence);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldCreateUserID, this.UserInfo.ID);
            mySQLBuilder.SetDBNow(BaseAddressBookTable.FieldCreateDate);
            returnValue = mySQLBuilder.EndInsert() > 0 ? sequence : String.Empty;
			return returnValue;
		}
		#endregion

        #region public int Update(BaseAddressBookEntity addressBookEntity) 更新
        /// <summary>
		/// 更新
		/// </summary>
        /// <param name="addressBookEntity">实体</param>
        /// <returns>影响行数</returns>
        public int Update(BaseAddressBookEntity addressBookEntity)
		{
			int returnValue	= 0;
			SQLBuilder mySQLBuilder = new SQLBuilder(this.DbHelper);
            mySQLBuilder.BeginUpdate(BaseAddressBookTable.TableName);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldFullName, addressBookEntity.FullName);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldCompanyName, addressBookEntity.CompanyName);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldAdress, addressBookEntity.Adress);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldDuty, addressBookEntity.Duty);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldTelephone, addressBookEntity.Telephone);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldMobile, addressBookEntity.Mobile);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldMail, addressBookEntity.Mail);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldRelation, addressBookEntity.Relation);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldEnabled, addressBookEntity.Enabled);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldDescription, addressBookEntity.Description);
            mySQLBuilder.SetValue(BaseAddressBookTable.FieldModifyUserID, this.UserInfo.ID);
            mySQLBuilder.SetDBNow(BaseAddressBookTable.FieldModifyDate);
            mySQLBuilder.SetWhere(BaseAddressBookTable.FieldID, addressBookEntity.ID);
			returnValue = mySQLBuilder.EndUpdate();
			return returnValue;
		}
		#endregion

        #region public int SetState(String[] id, int enabled) 设置有效
        /// <summary>
        /// 设置有效
        /// </summary>
        /// <param name="id">通讯录代码</param>
        /// <param name="enabled">有效</param>
        /// <returns>影响行数</returns>
        public int SetState(String[] ids, int enabled)
        {
            int returnValue = 0;
            String id = String.Empty;
            try
            {
                // 事务开始
                this.DbHelper.BeginTransaction();
                for (int i = 0; i < ids.Length; i++)
                {
                    id = ids[i];
                    returnValue += this.SetProperty(id, BaseAddressBookTable.FieldEnabled, enabled.ToString());
                }
                this.DbHelper.CommitTransaction();
            }
            catch (Exception exception)
            {
                // 事务回滚
                this.DbHelper.RollbackTransaction();
                BaseExceptionDao.Instance.LogException(this.DbHelper, this.UserInfo, exception);
                throw exception;
            }
            return returnValue;
        }
        #endregion   

        #region public DataTable GetPreviousNextID(String id) 获得代码列表
        /// <summary>
        /// 获得代码列表中的，上一条，小一条记录的代码
        /// </summary>
        /// <param name="id">通讯录ID</param>
        /// <returns>数据集</returns>
        public DataTable GetPreviousNextID(String id)
        {
            String sqlQuery = " SELECT ID "
                            + " FROM " + BaseAddressBookTable.TableName
                            + " ORDER BY " + this.DefaultOrder;
            DataTable myDataTable = new DataTable(BaseAddressBookTable.TableName);
            this.DbHelper.Fill(myDataTable, sqlQuery);
            this.NextID = BaseSortLogic.Instance.GetNextID(myDataTable, id);
            this.PreviousID = BaseSortLogic.Instance.GetPreviousID(myDataTable, id);
            return myDataTable;
        }
        #endregion

        #region public DataTable Search(String search) 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="search">查询字符</param>
        /// <returns>数据集</returns>
        public DataTable Search(String search)
        {
            // 2007.02.28 若没有查询内容，为了让速度更快列出数据，进行了改进。
            if (search.Length == 0)
            {
                return this.GetList();
            }
            DataTable myDataTable = new DataTable(BaseAddressBookTable.TableName);
            String sqlQuery = " SELECT * "
                            + " FROM " + BaseAddressBookTable.TableName
                            + " WHERE ((" + BaseAddressBookTable.FieldFullName + " LIKE ? )"
                            + " OR (" + BaseAddressBookTable.FieldCompanyName + " LIKE ? )"
                            + " OR (" + BaseAddressBookTable.FieldAdress + " LIKE ? )"
                        + " OR (" + BaseAddressBookTable.FieldDuty + " LIKE ? )"
                            + " OR (" + BaseAddressBookTable.FieldMail + " LIKE ? )"
                            + " OR (" + BaseAddressBookTable.FieldTelephone + " LIKE ? )"
                            + " OR (" + BaseAddressBookTable.FieldMobile + " LIKE ? )"
                            + " OR (" + BaseAddressBookTable.FieldDescription + " LIKE ? )"
                            + " OR (" + BaseAddressBookTable.FieldRelation + " LIKE ? ))"
                            + " AND (" + BaseAddressBookTable.FieldCreateUserID + " = ? )"
                            + " ORDER BY " + this.DefaultOrder;      
            String[] names = new String[10];
            Object[] values = new Object[10];
            names[0] = BaseAddressBookTable.FieldFullName;
            values[0] = search;
            names[1] = BaseAddressBookTable.FieldCompanyName;
            values[1] = search;
            names[2] = BaseAddressBookTable.FieldAdress;
            values[2] = search;
            names[3] = BaseAddressBookTable.FieldDuty;
            values[3] = search;
            names[4] = BaseAddressBookTable.FieldMail;
            values[4] = search;
            names[5] = BaseAddressBookTable.FieldTelephone;
            values[5] = search;
            names[6] = BaseAddressBookTable.FieldMobile;
            values[6] = search;
            names[7] = BaseAddressBookTable.FieldDescription;
            values[7] = search;
            names[8] = BaseAddressBookTable.FieldRelation;
            values[8] = search;
            values[9] = BaseAddressBookTable.FieldCreateUserID;
            values[9] = this.UserInfo.ID;
            this.DbHelper.Fill(myDataTable, sqlQuery, this.DbHelper.MakeParameters(names, values));
            return myDataTable;
        }
        #endregion
	}
}