//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseOrganizeEntity
    /// 组织机构、部门表
    ///
    /// 修改纪录
    ///
    ///		2010-07-15 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010-07-15</date>
    /// </author>
    /// </summary>
    [Serializable]
    public partial class BaseOrganizeEntity : BaseEntity
    {
        private int? id = null;
        /// <summary>
        /// 主键
        /// </summary>
        public int? Id
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

        private string parentId = null;
        /// <summary>
        /// 父级主键
        /// </summary>
        public string ParentId
        {
            get
            {
                return this.parentId;
            }
            set
            {
                this.parentId = value;
            }
        }

        private string code = null;
        /// <summary>
        /// 编号
        /// </summary>
        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        private string shortName = null;
        /// <summary>
        /// 简称
        /// </summary>
        public string ShortName
        {
            get
            {
                return this.shortName;
            }
            set
            {
                this.shortName = value;
            }
        }

        private string fullName = null;
        /// <summary>
        /// 名称
        /// </summary>
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

        private string category = null;
        /// <summary>
        /// 分类
        /// </summary>
        public string Category
        {
            get
            {
                return this.category;
            }
            set
            {
                this.category = value;
            }
        }

        private string outerPhone = null;
        /// <summary>
        /// 外线电话
        /// </summary>
        public string OuterPhone
        {
            get
            {
                return this.outerPhone;
            }
            set
            {
                this.outerPhone = value;
            }
        }

        private string innerPhone = null;
        /// <summary>
        /// 内线电话
        /// </summary>
        public string InnerPhone
        {
            get
            {
                return this.innerPhone;
            }
            set
            {
                this.innerPhone = value;
            }
        }

        private string fax = null;
        /// <summary>
        /// 传真
        /// </summary>
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

        private string postalcode = null;
        /// <summary>
        /// 邮编
        /// </summary>
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

        private string address = null;
        /// <summary>
        /// 地址
        /// </summary>
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

        private string web = null;
        /// <summary>
        /// 网址
        /// </summary>
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

        private int? isInnerOrganize = 0;
        /// <summary>
        /// 内部组织机构
        /// </summary>
        public int? IsInnerOrganize
        {
            get
            {
                return this.isInnerOrganize;
            }
            set
            {
                this.isInnerOrganize = value;
            }
        }

        private string bank = null;
        /// <summary>
        /// 开户行
        /// </summary>
        public string Bank
        {
            get
            {
                return this.bank;
            }
            set
            {
                this.bank = value;
            }
        }

        private string bankAccount = null;
        /// <summary>
        /// 银行帐号
        /// </summary>
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

        private int? deletionStateCode = 0;
        /// <summary>
        /// 删除标记
        /// </summary>
        public int? DeletionStateCode
        {
            get
            {
                return this.deletionStateCode;
            }
            set
            {
                this.deletionStateCode = value;
            }
        }

        private int? enabled = 0;
        /// <summary>
        /// 有效
        /// </summary>
        public int? Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                this.enabled = value;
            }
        }

        private int? sortCode = 0;
        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode
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

        private string description = null;
        /// <summary>
        /// 描述
        /// </summary>
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

        private DateTime? createOn = null;
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateOn
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

        private string createUserId = null;
        /// <summary>
        /// 创建用户主键
        /// </summary>
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

        private string createBy = null;
        /// <summary>
        /// 创建用户
        /// </summary>
        public string CreateBy
        {
            get
            {
                return this.createBy;
            }
            set
            {
                this.createBy = value;
            }
        }

        private DateTime? modifiedOn = null;
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? ModifiedOn
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

        private string modifiedUserId = null;
        /// <summary>
        /// 修改用户主键
        /// </summary>
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

        private string modifiedBy = null;
        /// <summary>
        /// 修改用户
        /// </summary>
        public string ModifiedBy
        {
            get
            {
                return this.modifiedBy;
            }
            set
            {
                this.modifiedBy = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseOrganizeEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseOrganizeEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseOrganizeEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseOrganizeEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseOrganizeEntity GetSingle(DataTable dataTable)
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
        /// 从数据表读取实体列表
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public List<BaseOrganizeEntity> GetList(DataTable dataTable)
        {
            List<BaseOrganizeEntity> entites = new List<BaseOrganizeEntity>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                entites.Add(GetFrom(dataRow));
            }
            return entites;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseOrganizeEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToInt(dataRow[BaseOrganizeEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToString(dataRow[BaseOrganizeEntity.FieldParentId]);
            this.Code = BaseBusinessLogic.ConvertToString(dataRow[BaseOrganizeEntity.FieldCode]);
            this.ShortName = BaseBusinessLogic.ConvertToString(dataRow[BaseOrganizeEntity.FieldShortName]);
            this.FullName = BaseBusinessLogic.ConvertToString(dataRow[BaseOrganizeEntity.FieldFullName]);
            this.Category = BaseBusinessLogic.ConvertToString(dataRow[BaseOrganizeEntity.FieldCategory]);
            this.Layer = BaseBusinessLogic.ConvertToInt(dataRow[BaseOrganizeEntity.FieldLayer]);
            this.OuterPhone = BaseBusinessLogic.ConvertToString(dataRow[BaseOrganizeEntity.FieldOuterPhone]);
            this.InnerPhone = BaseBusinessLogic.ConvertToString(dataRow[BaseOrganizeEntity.FieldInnerPhone]);
            this.Fax = BaseBusinessLogic.ConvertToString(dataRow[BaseOrganizeEntity.FieldFax]);
            this.Postalcode = BaseBusinessLogic.ConvertToString(dataRow[BaseOrganizeEntity.FieldPostalcode]);
            this.Address = BaseBusinessLogic.ConvertToString(dataRow[BaseOrganizeEntity.FieldAddress]);
            this.Web = BaseBusinessLogic.ConvertToString(dataRow[BaseOrganizeEntity.FieldWeb]);
            this.IsInnerOrganize = BaseBusinessLogic.ConvertToInt(dataRow[BaseOrganizeEntity.FieldIsInnerOrganize]);
            this.Bank = BaseBusinessLogic.ConvertToString(dataRow[BaseOrganizeEntity.FieldBank]);
            this.BankAccount = BaseBusinessLogic.ConvertToString(dataRow[BaseOrganizeEntity.FieldBankAccount]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseOrganizeEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseOrganizeEntity.FieldEnabled]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseOrganizeEntity.FieldSortCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseOrganizeEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseOrganizeEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseOrganizeEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseOrganizeEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseOrganizeEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseOrganizeEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseOrganizeEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseOrganizeEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader);
            this.Id = BaseBusinessLogic.ConvertToInt(dataReader[BaseOrganizeEntity.FieldId]);
            this.ParentId = BaseBusinessLogic.ConvertToString(dataReader[BaseOrganizeEntity.FieldParentId]);
            this.Code = BaseBusinessLogic.ConvertToString(dataReader[BaseOrganizeEntity.FieldCode]);
            this.ShortName = BaseBusinessLogic.ConvertToString(dataReader[BaseOrganizeEntity.FieldShortName]);
            this.FullName = BaseBusinessLogic.ConvertToString(dataReader[BaseOrganizeEntity.FieldFullName]);
            this.Category = BaseBusinessLogic.ConvertToString(dataReader[BaseOrganizeEntity.FieldCategory]);
            this.Layer = BaseBusinessLogic.ConvertToInt(dataReader[BaseOrganizeEntity.FieldLayer]);
            this.OuterPhone = BaseBusinessLogic.ConvertToString(dataReader[BaseOrganizeEntity.FieldOuterPhone]);
            this.InnerPhone = BaseBusinessLogic.ConvertToString(dataReader[BaseOrganizeEntity.FieldInnerPhone]);
            this.Fax = BaseBusinessLogic.ConvertToString(dataReader[BaseOrganizeEntity.FieldFax]);
            this.Postalcode = BaseBusinessLogic.ConvertToString(dataReader[BaseOrganizeEntity.FieldPostalcode]);
            this.Address = BaseBusinessLogic.ConvertToString(dataReader[BaseOrganizeEntity.FieldAddress]);
            this.Web = BaseBusinessLogic.ConvertToString(dataReader[BaseOrganizeEntity.FieldWeb]);
            this.IsInnerOrganize = BaseBusinessLogic.ConvertToInt(dataReader[BaseOrganizeEntity.FieldIsInnerOrganize]);
            this.Bank = BaseBusinessLogic.ConvertToString(dataReader[BaseOrganizeEntity.FieldBank]);
            this.BankAccount = BaseBusinessLogic.ConvertToString(dataReader[BaseOrganizeEntity.FieldBankAccount]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseOrganizeEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseOrganizeEntity.FieldEnabled]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseOrganizeEntity.FieldSortCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseOrganizeEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseOrganizeEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseOrganizeEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseOrganizeEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseOrganizeEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseOrganizeEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseOrganizeEntity.FieldModifiedBy]);
            return this;
        }
    }
}
