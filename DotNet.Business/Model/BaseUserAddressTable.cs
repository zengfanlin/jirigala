//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;

namespace DotNet.Business
{
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
    public partial class BaseUserAddressEntity
    {
        ///<summary>
        /// 用户送货地址表
        ///</summary>
        [NonSerialized]
        public static string TableName = "BaseUserAddress";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldUserId = "UserId";

        ///<summary>
        /// 联系人（收货人）
        ///</summary>
        [NonSerialized]
        public static string FieldRealName = "RealName";

        ///<summary>
        /// 省主键
        ///</summary>
        [NonSerialized]
        public static string FieldProvinceId = "ProvinceId";

        ///<summary>
        /// 省
        ///</summary>
        [NonSerialized]
        public static string FieldProvince = "Province";

        ///<summary>
        /// 市主键
        ///</summary>
        [NonSerialized]
        public static string FieldCityId = "CityId";

        ///<summary>
        /// 市
        ///</summary>
        [NonSerialized]
        public static string FieldCity = "City";

        ///<summary>
        /// 区/县主键
        ///</summary>
        [NonSerialized]
        public static string FieldAreaId = "AreaId";

        ///<summary>
        /// 区/县
        ///</summary>
        [NonSerialized]
        public static string FieldArea = "Area";

        ///<summary>
        /// 街道地址
        ///</summary>
        [NonSerialized]
        public static string FieldAddress = "Address";

        ///<summary>
        /// 邮政编码
        ///</summary>
        [NonSerialized]
        public static string FieldPostCode = "PostCode";

        ///<summary>
        /// 联系电话
        ///</summary>
        [NonSerialized]
        public static string FieldPhone = "Phone";

        ///<summary>
        /// 传真
        ///</summary>
        [NonSerialized]
        public static string FieldFax = "Fax";

        ///<summary>
        /// 手机
        ///</summary>
        [NonSerialized]
        public static string FieldMobile = "Mobile";

        ///<summary>
        /// 电子邮件
        ///</summary>
        [NonSerialized]
        public static string FieldEmail = "Email";

        ///<summary>
        /// 送货方式
        ///</summary>
        [NonSerialized]
        public static string FieldDeliverCategory = "DeliverCategory";

        ///<summary>
        /// 排序码
        ///</summary>
        [NonSerialized]
        public static string FieldSortCode = "SortCode";

        ///<summary>
        /// 删除标记
        ///</summary>
        [NonSerialized]
        public static string FieldDeletionStateCode = "DeletionStateCode";

        ///<summary>
        /// 有效标志
        ///</summary>
        [NonSerialized]
        public static string FieldEnabled = "Enabled";

        ///<summary>
        /// 描述
        ///</summary>
        [NonSerialized]
        public static string FieldDescription = "Description";

        ///<summary>
        /// 创建日期
        ///</summary>
        [NonSerialized]
        public static string FieldCreateOn = "CreateOn";

        ///<summary>
        /// 创建用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldCreateUserId = "CreateUserId";

        ///<summary>
        /// 创建用户
        ///</summary>
        [NonSerialized]
        public static string FieldCreateBy = "CreateBy";

        ///<summary>
        /// 修改日期
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedOn = "ModifiedOn";

        ///<summary>
        /// 修改用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedUserId = "ModifiedUserId";

        ///<summary>
        /// 修改用户
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedBy = "ModifiedBy";
    }
}
