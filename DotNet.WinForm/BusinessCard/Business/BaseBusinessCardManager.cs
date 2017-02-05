//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;

namespace DotNet.WinForm
{
    using DotNet.Utilities;
    using DotNet.Business;

    /// <summary>
    /// BaseBusinessCardManager
    /// 名片管理
    ///
    /// 修改纪录
    ///
    ///		2008-11-06 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008-11-06</date>
    /// </author>
    /// </summary>
    public class BaseBusinessCardManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseBusinessCardManager()
        {
            base.CurrentTableName = BaseBusinessCardTable.TableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseBusinessCardManager(IDbHelper dbHelper) : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">操作员信息</param>
        public BaseBusinessCardManager(BaseUserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">操作员信息</param>
        public BaseBusinessCardManager(IDbHelper dbHelper, BaseUserInfo userInfo)
            : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="businessCardEntity">实体</param>
        public string Add(BaseBusinessCardEntity businessCardEntity)
        {
            return this.AddEntity(businessCardEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="businessCardEntity">实体</param>
        public int Update(BaseBusinessCardEntity businessCardEntity)
        {
            return this.UpdateEntity(businessCardEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseBusinessCardEntity GetEntity(string id)
        {
            DataTable dataTable = this.GetDataTableById(id);
            BaseBusinessCardEntity businessCardEntity = new BaseBusinessCardEntity(dataTable);
            return businessCardEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="businessCardEntity">实体</param>
        public string AddEntity(BaseBusinessCardEntity businessCardEntity)
        {
            string returnValue = string.Empty;
            if (String.IsNullOrEmpty(businessCardEntity.Id) || String.IsNullOrEmpty(businessCardEntity.SortCode))
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper);
                string sequence = sequenceManager.GetSequence(BaseBusinessCardTable.TableName);
                if (String.IsNullOrEmpty(businessCardEntity.Id))
                {
                    businessCardEntity.Id = sequence;
                }
                if (String.IsNullOrEmpty(businessCardEntity.SortCode))
                {
                    businessCardEntity.SortCode = sequence;
                }
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginInsert(this.CurrentTableName);
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldId, businessCardEntity.Id);
            this.SetEntity(sqlBuilder, businessCardEntity);
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldCreateBy, UserInfo.RealName);
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldCreateUserId, UserInfo.Id);
            sqlBuilder.SetDBNow(BaseBusinessCardTable.FieldCreateOn);
            return sqlBuilder.EndInsert() > 0 ? businessCardEntity.Id : string.Empty;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="businessCardEntity">实体</param>
        public int UpdateEntity(BaseBusinessCardEntity businessCardEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, businessCardEntity);
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldModifiedBy, UserInfo.RealName);
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldModifiedUserId, UserInfo.Id);
            sqlBuilder.SetDBNow(BaseBusinessCardTable.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseBusinessCardTable.FieldId, businessCardEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="businessCardEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseBusinessCardEntity businessCardEntity)
        {
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldFullName, businessCardEntity.FullName);
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldTitle, businessCardEntity.Title);
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldCompany, businessCardEntity.Company);
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldPhone, businessCardEntity.Phone);
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldPostalcode, businessCardEntity.Postalcode);
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldMobile, businessCardEntity.Mobile);
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldAddress, businessCardEntity.Address);
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldEmail, businessCardEntity.Email);
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldOfficePhone, businessCardEntity.OfficePhone);
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldQQ, businessCardEntity.QQ);
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldFax, businessCardEntity.Fax);
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldWeb, businessCardEntity.Web);
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldBankName, businessCardEntity.BankName);
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldBankAccount, businessCardEntity.BankAccount);
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldTaxAccount, businessCardEntity.TaxAccount);
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldPersonal, businessCardEntity.Personal ? 1:0);
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldSortCode, businessCardEntity.SortCode);
            sqlBuilder.SetValue(BaseBusinessCardTable.FieldDescription, businessCardEntity.Description);
        }
    }
}