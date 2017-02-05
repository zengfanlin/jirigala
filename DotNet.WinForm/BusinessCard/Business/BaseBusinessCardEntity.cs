//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace DotNet.WinForm
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseBusinessCardEntity
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
    [Serializable]
    [DataContract]
    public class BaseBusinessCardEntity
    {
        private string id = null;
        /// <summary>
        /// Id
        /// </summary>
        [DataMember]
        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        private string fullName = null;
        /// <summary>
        /// FullName
        /// </summary>
        [DataMember]
        public string FullName
        {
            get
            {
                return this.fullName;
            }
            set
            {
                this.fullName = value;
            }
        }

        private string title = null;
        /// <summary>
        /// Title
        /// </summary>
        [DataMember]
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
            }
        }

        private string company = null;
        /// <summary>
        /// Company
        /// </summary>
        [DataMember]
        public string Company
        {
            get
            {
                return this.company;
            }
            set
            {
                this.company = value;
            }
        }

        private string phone = null;
        /// <summary>
        /// Phone
        /// </summary>
        [DataMember]
        public string Phone
        {
            get
            {
                return this.phone;
            }
            set
            {
                this.phone = value;
            }
        }

        private string postalcode = null;
        /// <summary>
        /// Postalcode
        /// </summary>
        [DataMember]
        public string Postalcode
        {
            get
            {
                return this.postalcode;
            }
            set
            {
                this.postalcode = value;
            }
        }

        private string mobile = null;
        /// <summary>
        /// Mobile
        /// </summary>
        [DataMember]
        public string Mobile
        {
            get
            {
                return this.mobile;
            }
            set
            {
                this.mobile = value;
            }
        }

        private string address = null;
        /// <summary>
        /// Address
        /// </summary>
        [DataMember]
        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
            }
        }

        private string email = null;
        /// <summary>
        /// Email
        /// </summary>
        [DataMember]
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        private string officePhone = null;
        /// <summary>
        /// OfficePhone
        /// </summary>
        [DataMember]
        public string OfficePhone
        {
            get
            {
                return this.officePhone;
            }
            set
            {
                this.officePhone = value;
            }
        }

        private string qQ = null;
        /// <summary>
        /// QQ
        /// </summary>
        [DataMember]
        public string QQ
        {
            get
            {
                return this.qQ;
            }
            set
            {
                this.qQ = value;
            }
        }

        private string fax = null;
        /// <summary>
        /// Fax
        /// </summary>
        [DataMember]
        public string Fax
        {
            get
            {
                return this.fax;
            }
            set
            {
                this.fax = value;
            }
        }

        private string web = null;
        /// <summary>
        /// Web
        /// </summary>
        [DataMember]
        public string Web
        {
            get
            {
                return this.web;
            }
            set
            {
                this.web = value;
            }
        }

        private string bankName = null;
        /// <summary>
        /// BankName
        /// </summary>
        [DataMember]
        public string BankName
        {
            get
            {
                return this.bankName;
            }
            set
            {
                this.bankName = value;
            }
        }

        private string bankAccount = null;
        /// <summary>
        /// BankAccount
        /// </summary>
        [DataMember]
        public string BankAccount
        {
            get
            {
                return this.bankAccount;
            }
            set
            {
                this.bankAccount = value;
            }
        }

        private string taxAccount = null;
        /// <summary>
        /// TaxAccount
        /// </summary>
        [DataMember]
        public string TaxAccount
        {
            get
            {
                return this.taxAccount;
            }
            set
            {
                this.taxAccount = value;
            }
        }

        private bool personal = false;
        /// <summary>
        /// TaxAccount
        /// </summary>
        [DataMember]
        public bool Personal
        {
            get
            {
                return this.personal;
            }
            set
            {
                this.personal = value;
            }
        }

        private string description = null;
        /// <summary>
        /// Description
        /// </summary>
        [DataMember]
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        private string sortCode = null;
        /// <summary>
        /// SortCode
        /// </summary>
        [DataMember]
        public string SortCode
        {
            get
            {
                return this.sortCode;
            }
            set
            {
                this.sortCode = value;
            }
        }

        private string createUserId = null;
        /// <summary>
        /// CreateUserId
        /// </summary>
        [DataMember]
        public string CreateUserId
        {
            get
            {
                return this.createUserId;
            }
            set
            {
                this.createUserId = value;
            }
        }

        private string createOn = null;
        /// <summary>
        /// CreateOn
        /// </summary>
        [DataMember]
        public string CreateOn
        {
            get
            {
                return this.createOn;
            }
            set
            {
                this.createOn = value;
            }
        }

        private string modifiedUserId = null;
        /// <summary>
        /// ModifiedUserId
        /// </summary>
        [DataMember]
        public string ModifiedUserId
        {
            get
            {
                return this.modifiedUserId;
            }
            set
            {
                this.modifiedUserId = value;
            }
        }

        private string modifiedOn = null;
        /// <summary>
        /// ModifiedOn
        /// </summary>
        [DataMember]
        public string ModifiedOn
        {
            get
            {
                return this.modifiedOn;
            }
            set
            {
                this.modifiedOn = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseBusinessCardEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseBusinessCardEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseBusinessCardEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseBusinessCardEntity GetSingle(DataTable dataTable)
        {
            if ((dataTable == null) || (dataTable.Rows.Count == 0))
            {
                return null;
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.GetFrom(dataRow);
                break;
            }
            return this;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseBusinessCardEntity GetFrom(DataRow dataRow)
        {
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[BaseBusinessCardTable.FieldId]);
            this.FullName = BaseBusinessLogic.ConvertToString(dataRow[BaseBusinessCardTable.FieldFullName]);
            this.Title = BaseBusinessLogic.ConvertToString(dataRow[BaseBusinessCardTable.FieldTitle]);
            this.Company = BaseBusinessLogic.ConvertToString(dataRow[BaseBusinessCardTable.FieldCompany]);
            this.Phone = BaseBusinessLogic.ConvertToString(dataRow[BaseBusinessCardTable.FieldPhone]);
            this.Postalcode = BaseBusinessLogic.ConvertToString(dataRow[BaseBusinessCardTable.FieldPostalcode]);
            this.Mobile = BaseBusinessLogic.ConvertToString(dataRow[BaseBusinessCardTable.FieldMobile]);
            this.Address = BaseBusinessLogic.ConvertToString(dataRow[BaseBusinessCardTable.FieldAddress]);
            this.Email = BaseBusinessLogic.ConvertToString(dataRow[BaseBusinessCardTable.FieldEmail]);
            this.OfficePhone = BaseBusinessLogic.ConvertToString(dataRow[BaseBusinessCardTable.FieldOfficePhone]);
            this.QQ = BaseBusinessLogic.ConvertToString(dataRow[BaseBusinessCardTable.FieldQQ]);
            this.Fax = BaseBusinessLogic.ConvertToString(dataRow[BaseBusinessCardTable.FieldFax]);
            this.Web = BaseBusinessLogic.ConvertToString(dataRow[BaseBusinessCardTable.FieldWeb]);
            this.BankName = BaseBusinessLogic.ConvertToString(dataRow[BaseBusinessCardTable.FieldBankName]);
            this.BankAccount = BaseBusinessLogic.ConvertToString(dataRow[BaseBusinessCardTable.FieldBankAccount]);
            this.TaxAccount = BaseBusinessLogic.ConvertToString(dataRow[BaseBusinessCardTable.FieldTaxAccount]);
            this.Personal = BaseBusinessLogic.ConvertIntToBoolean(dataRow[BaseBusinessCardTable.FieldPersonal]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseBusinessCardTable.FieldDescription]);
            this.SortCode = BaseBusinessLogic.ConvertToString(dataRow[BaseBusinessCardTable.FieldSortCode]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseBusinessCardTable.FieldCreateUserId]);
            this.CreateOn = BaseBusinessLogic.ConvertToString(dataRow[BaseBusinessCardTable.FieldCreateOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseBusinessCardTable.FieldModifiedUserId]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToString(dataRow[BaseBusinessCardTable.FieldModifiedOn]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseBusinessCardEntity GetFrom(IDataReader dataReader)
        {
            this.Id = BaseBusinessLogic.ConvertToString(dataReader[BaseBusinessCardTable.FieldId]);
            this.FullName = BaseBusinessLogic.ConvertToString(dataReader[BaseBusinessCardTable.FieldFullName]);
            this.Title = BaseBusinessLogic.ConvertToString(dataReader[BaseBusinessCardTable.FieldTitle]);
            this.Company = BaseBusinessLogic.ConvertToString(dataReader[BaseBusinessCardTable.FieldCompany]);
            this.Phone = BaseBusinessLogic.ConvertToString(dataReader[BaseBusinessCardTable.FieldPhone]);
            this.Postalcode = BaseBusinessLogic.ConvertToString(dataReader[BaseBusinessCardTable.FieldPostalcode]);
            this.Mobile = BaseBusinessLogic.ConvertToString(dataReader[BaseBusinessCardTable.FieldMobile]);
            this.Address = BaseBusinessLogic.ConvertToString(dataReader[BaseBusinessCardTable.FieldAddress]);
            this.Email = BaseBusinessLogic.ConvertToString(dataReader[BaseBusinessCardTable.FieldEmail]);
            this.OfficePhone = BaseBusinessLogic.ConvertToString(dataReader[BaseBusinessCardTable.FieldOfficePhone]);
            this.QQ = BaseBusinessLogic.ConvertToString(dataReader[BaseBusinessCardTable.FieldQQ]);
            this.Fax = BaseBusinessLogic.ConvertToString(dataReader[BaseBusinessCardTable.FieldFax]);
            this.Web = BaseBusinessLogic.ConvertToString(dataReader[BaseBusinessCardTable.FieldWeb]);
            this.BankName = BaseBusinessLogic.ConvertToString(dataReader[BaseBusinessCardTable.FieldBankName]);
            this.BankAccount = BaseBusinessLogic.ConvertToString(dataReader[BaseBusinessCardTable.FieldBankAccount]);
            this.TaxAccount = BaseBusinessLogic.ConvertToString(dataReader[BaseBusinessCardTable.FieldTaxAccount]);
            this.Personal = BaseBusinessLogic.ConvertIntToBoolean(dataReader[BaseBusinessCardTable.FieldPersonal]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseBusinessCardTable.FieldDescription]);
            this.SortCode = BaseBusinessLogic.ConvertToString(dataReader[BaseBusinessCardTable.FieldSortCode]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseBusinessCardTable.FieldCreateUserId]);
            this.CreateOn = BaseBusinessLogic.ConvertToString(dataReader[BaseBusinessCardTable.FieldCreateOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseBusinessCardTable.FieldModifiedUserId]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToString(dataReader[BaseBusinessCardTable.FieldModifiedOn]);
            return this;
        }
    }
}