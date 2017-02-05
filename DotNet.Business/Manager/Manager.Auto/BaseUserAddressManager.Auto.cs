//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseUserAddressManager
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
    public partial class BaseUserAddressManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseUserAddressManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            }
            base.CurrentTableName = BaseUserAddressEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseUserAddressManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseUserAddressManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseUserAddressManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseUserAddressManager(IDbHelper dbHelper, BaseUserInfo userInfo)
            : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public BaseUserAddressManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userAddressEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseUserAddressEntity userAddressEntity)
        {
            return this.AddEntity(userAddressEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userAddressEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BaseUserAddressEntity userAddressEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(userAddressEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="userAddressEntity">实体</param>
        public int Update(BaseUserAddressEntity userAddressEntity)
        {
            return this.UpdateEntity(userAddressEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseUserAddressEntity GetEntity(string id)
        {
            BaseUserAddressEntity userAddressEntity = new BaseUserAddressEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseUserAddressEntity.FieldId, id)));
            return userAddressEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="userAddressEntity">实体</param>
        public string AddEntity(BaseUserAddressEntity userAddressEntity)
        {
            string sequence = string.Empty;
            sequence = userAddressEntity.Id;
            if (userAddressEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                userAddressEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseUserAddressEntity.FieldId);
            if (userAddressEntity.Id is string)
            {
                this.Identity = false;
            }
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BaseUserAddressEntity.FieldId, userAddressEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseUserAddressEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseUserAddressEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(userAddressEntity.Id))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            userAddressEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(BaseUserAddressEntity.FieldId, userAddressEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, userAddressEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseUserAddressEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseUserAddressEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseUserAddressEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseUserAddressEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseUserAddressEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseUserAddressEntity.FieldModifiedOn);
            if (DbHelper.CurrentDbType == CurrentDbType.SqlServer && this.Identity)
            {
                sequence = sqlBuilder.EndInsert().ToString();
            }
            else
            {
                sqlBuilder.EndInsert();
            }
            return sequence;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="userAddressEntity">实体</param>
        public int UpdateEntity(BaseUserAddressEntity userAddressEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, userAddressEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseUserAddressEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseUserAddressEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseUserAddressEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseUserAddressEntity.FieldId, userAddressEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        partial void SetEntityExpand(SQLBuilder sqlBuilder, BaseUserAddressEntity userAddressEntity);

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="userAddressEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseUserAddressEntity userAddressEntity)
        {
            sqlBuilder.SetValue(BaseUserAddressEntity.FieldUserId, userAddressEntity.UserId);
            sqlBuilder.SetValue(BaseUserAddressEntity.FieldRealName, userAddressEntity.RealName);
            sqlBuilder.SetValue(BaseUserAddressEntity.FieldProvinceId, userAddressEntity.ProvinceId);
            sqlBuilder.SetValue(BaseUserAddressEntity.FieldProvince, userAddressEntity.Province);
            sqlBuilder.SetValue(BaseUserAddressEntity.FieldCityId, userAddressEntity.CityId);
            sqlBuilder.SetValue(BaseUserAddressEntity.FieldCity, userAddressEntity.City);
            sqlBuilder.SetValue(BaseUserAddressEntity.FieldAreaId, userAddressEntity.AreaId);
            sqlBuilder.SetValue(BaseUserAddressEntity.FieldArea, userAddressEntity.Area);
            sqlBuilder.SetValue(BaseUserAddressEntity.FieldAddress, userAddressEntity.Address);
            sqlBuilder.SetValue(BaseUserAddressEntity.FieldPostCode, userAddressEntity.PostCode);
            sqlBuilder.SetValue(BaseUserAddressEntity.FieldPhone, userAddressEntity.Phone);
            sqlBuilder.SetValue(BaseUserAddressEntity.FieldFax, userAddressEntity.Fax);
            sqlBuilder.SetValue(BaseUserAddressEntity.FieldMobile, userAddressEntity.Mobile);
            sqlBuilder.SetValue(BaseUserAddressEntity.FieldEmail, userAddressEntity.Email);
            sqlBuilder.SetValue(BaseUserAddressEntity.FieldDeliverCategory, userAddressEntity.DeliverCategory);
            sqlBuilder.SetValue(BaseUserAddressEntity.FieldSortCode, userAddressEntity.SortCode);
            sqlBuilder.SetValue(BaseUserAddressEntity.FieldDeletionStateCode, userAddressEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseUserAddressEntity.FieldEnabled, userAddressEntity.Enabled);
            sqlBuilder.SetValue(BaseUserAddressEntity.FieldDescription, userAddressEntity.Description);
            SetEntityExpand(sqlBuilder, userAddressEntity);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseUserAddressEntity.FieldId, id));
        }        
    }
}
