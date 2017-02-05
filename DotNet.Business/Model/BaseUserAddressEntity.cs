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
    /// BaseUserAddressEntity
    /// 用户送货地址表
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
    public partial class BaseUserAddressEntity : BaseEntity
    {
        private string id = null;
        /// <summary>
        /// 主键
        /// </summary>
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

        private string userId = null;
        /// <summary>
        /// 用户主键
        /// </summary>
        public string UserId
        {
            get
            {
                return this.userId;
            }
            set
            {
                this.userId = value;
            }
        }

        private string realName = null;
        /// <summary>
        /// 联系人（收货人）
        /// </summary>
        public string RealName
        {
            get
            {
                return this.realName;
            }
            set
            {
                this.realName = value;
            }
        }

        private string provinceId = null;
        /// <summary>
        /// 省主键
        /// </summary>
        public string ProvinceId
        {
            get
            {
                return this.provinceId;
            }
            set
            {
                this.provinceId = value;
            }
        }

        private string province = null;
        /// <summary>
        /// 省
        /// </summary>
        public string Province
        {
            get
            {
                return this.province;
            }
            set
            {
                this.province = value;
            }
        }

        private string cityId = null;
        /// <summary>
        /// 市主键
        /// </summary>
        public string CityId
        {
            get
            {
                return this.cityId;
            }
            set
            {
                this.cityId = value;
            }
        }

        private string city = null;
        /// <summary>
        /// 市
        /// </summary>
        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
            }
        }

        private string areaId = null;
        /// <summary>
        /// 区/县主键
        /// </summary>
        public string AreaId
        {
            get
            {
                return this.areaId;
            }
            set
            {
                this.areaId = value;
            }
        }

        private string area = null;
        /// <summary>
        /// 区/县
        /// </summary>
        public string Area
        {
            get
            {
                return this.area;
            }
            set
            {
                this.area = value;
            }
        }

        private string address = null;
        /// <summary>
        /// 街道地址
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

        private string postCode = null;
        /// <summary>
        /// 邮政编码
        /// </summary>
        public string PostCode
        {
            get
            {
                return this.postCode;
            }
            set
            {
                this.postCode = value;
            }
        }

        private string phone = null;
        /// <summary>
        /// 联系电话
        /// </summary>
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

        private string mobile = null;
        /// <summary>
        /// 手机
        /// </summary>
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

        private string email = null;
        /// <summary>
        /// 电子邮件
        /// </summary>
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

        private string deliverCategory = null;
        /// <summary>
        /// 送货方式
        /// </summary>
        public string DeliverCategory
        {
            get
            {
                return this.deliverCategory;
            }
            set
            {
                this.deliverCategory = value;
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
        /// 有效标志
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
        public BaseUserAddressEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseUserAddressEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseUserAddressEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseUserAddressEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseUserAddressEntity GetSingle(DataTable dataTable)
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
        public List<BaseUserAddressEntity> GetList(DataTable dataTable)
        {
            List<BaseUserAddressEntity> entites = new List<BaseUserAddressEntity>();
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
        public BaseUserAddressEntity GetFrom(DataRow dataRow)
        {
            this.GetFromExpand(dataRow);
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[BaseUserAddressEntity.FieldId]);
            this.UserId = BaseBusinessLogic.ConvertToString(dataRow[BaseUserAddressEntity.FieldUserId]);
            this.RealName = BaseBusinessLogic.ConvertToString(dataRow[BaseUserAddressEntity.FieldRealName]);
            this.ProvinceId = BaseBusinessLogic.ConvertToString(dataRow[BaseUserAddressEntity.FieldProvinceId]);
            this.Province = BaseBusinessLogic.ConvertToString(dataRow[BaseUserAddressEntity.FieldProvince]);
            this.CityId = BaseBusinessLogic.ConvertToString(dataRow[BaseUserAddressEntity.FieldCityId]);
            this.City = BaseBusinessLogic.ConvertToString(dataRow[BaseUserAddressEntity.FieldCity]);
            this.AreaId = BaseBusinessLogic.ConvertToString(dataRow[BaseUserAddressEntity.FieldAreaId]);
            this.Area = BaseBusinessLogic.ConvertToString(dataRow[BaseUserAddressEntity.FieldArea]);
            this.Address = BaseBusinessLogic.ConvertToString(dataRow[BaseUserAddressEntity.FieldAddress]);
            this.PostCode = BaseBusinessLogic.ConvertToString(dataRow[BaseUserAddressEntity.FieldPostCode]);
            this.Phone = BaseBusinessLogic.ConvertToString(dataRow[BaseUserAddressEntity.FieldPhone]);
            this.Fax = BaseBusinessLogic.ConvertToString(dataRow[BaseUserAddressEntity.FieldFax]);
            this.Mobile = BaseBusinessLogic.ConvertToString(dataRow[BaseUserAddressEntity.FieldMobile]);
            this.Email = BaseBusinessLogic.ConvertToString(dataRow[BaseUserAddressEntity.FieldEmail]);
            this.DeliverCategory = BaseBusinessLogic.ConvertToString(dataRow[BaseUserAddressEntity.FieldDeliverCategory]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserAddressEntity.FieldSortCode]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserAddressEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseUserAddressEntity.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseUserAddressEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseUserAddressEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseUserAddressEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseUserAddressEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseUserAddressEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseUserAddressEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseUserAddressEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseUserAddressEntity GetFrom(IDataReader dataReader)
        {
            this.GetFromExpand(dataReader);
            this.Id = BaseBusinessLogic.ConvertToString(dataReader[BaseUserAddressEntity.FieldId]);
            this.UserId = BaseBusinessLogic.ConvertToString(dataReader[BaseUserAddressEntity.FieldUserId]);
            this.RealName = BaseBusinessLogic.ConvertToString(dataReader[BaseUserAddressEntity.FieldRealName]);
            this.ProvinceId = BaseBusinessLogic.ConvertToString(dataReader[BaseUserAddressEntity.FieldProvinceId]);
            this.Province = BaseBusinessLogic.ConvertToString(dataReader[BaseUserAddressEntity.FieldProvince]);
            this.CityId = BaseBusinessLogic.ConvertToString(dataReader[BaseUserAddressEntity.FieldCityId]);
            this.City = BaseBusinessLogic.ConvertToString(dataReader[BaseUserAddressEntity.FieldCity]);
            this.AreaId = BaseBusinessLogic.ConvertToString(dataReader[BaseUserAddressEntity.FieldAreaId]);
            this.Area = BaseBusinessLogic.ConvertToString(dataReader[BaseUserAddressEntity.FieldArea]);
            this.Address = BaseBusinessLogic.ConvertToString(dataReader[BaseUserAddressEntity.FieldAddress]);
            this.PostCode = BaseBusinessLogic.ConvertToString(dataReader[BaseUserAddressEntity.FieldPostCode]);
            this.Phone = BaseBusinessLogic.ConvertToString(dataReader[BaseUserAddressEntity.FieldPhone]);
            this.Fax = BaseBusinessLogic.ConvertToString(dataReader[BaseUserAddressEntity.FieldFax]);
            this.Mobile = BaseBusinessLogic.ConvertToString(dataReader[BaseUserAddressEntity.FieldMobile]);
            this.Email = BaseBusinessLogic.ConvertToString(dataReader[BaseUserAddressEntity.FieldEmail]);
            this.DeliverCategory = BaseBusinessLogic.ConvertToString(dataReader[BaseUserAddressEntity.FieldDeliverCategory]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserAddressEntity.FieldSortCode]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserAddressEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseUserAddressEntity.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseUserAddressEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseUserAddressEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseUserAddressEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseUserAddressEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseUserAddressEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseUserAddressEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseUserAddressEntity.FieldModifiedBy]);
            return this;
        }
    }
}
