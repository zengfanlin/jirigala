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
    /// BaseItemDetailsManager
    /// 选项明细表（资源明细表结构）
    ///
    /// 修改纪录
    ///
    ///		2010-07-28 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010-07-28</date>
    /// </author>
    /// </summary>
    public partial class BaseItemDetailsManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseItemDetailsManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            }
            if (string.IsNullOrEmpty(base.CurrentTableName))
            {
                base.CurrentTableName = BaseItemDetailsEntity.TableName;
            }
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseItemDetailsManager(string tableName)
            :this()
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseItemDetailsManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseItemDetailsManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseItemDetailsManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BaseItemDetailsManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="itemDetailsEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseItemDetailsEntity itemDetailsEntity)
        {
            return this.AddEntity(itemDetailsEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="itemDetailsEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BaseItemDetailsEntity itemDetailsEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(itemDetailsEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="itemDetailsEntity">实体</param>
        public int Update(BaseItemDetailsEntity itemDetailsEntity)
        {
            return this.UpdateEntity(itemDetailsEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseItemDetailsEntity GetEntity(int id)
        {
            return GetEntity(id.ToString());
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseItemDetailsEntity GetEntity(string id)
        {
            BaseItemDetailsEntity itemDetailsEntity = new BaseItemDetailsEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldId, id)));
            return itemDetailsEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="itemDetailsEntity">实体</param>
        public string AddEntity(BaseItemDetailsEntity itemDetailsEntity)
        {
            string sequence = string.Empty;
            if (itemDetailsEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                itemDetailsEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseItemDetailsEntity.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BaseItemDetailsEntity.FieldId, itemDetailsEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseItemDetailsEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseItemDetailsEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(sequence))
                        {
                            BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                            sequence = sequenceManager.GetSequence(this.CurrentTableName);
                        }
                        itemDetailsEntity.Id = int.Parse(sequence);
                        sqlBuilder.SetValue(BaseItemDetailsEntity.FieldId, itemDetailsEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, itemDetailsEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseItemDetailsEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseItemDetailsEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseItemDetailsEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseItemDetailsEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseItemDetailsEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseItemDetailsEntity.FieldModifiedOn);
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
        /// <param name="itemDetailsEntity">实体</param>
        public int UpdateEntity(BaseItemDetailsEntity itemDetailsEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, itemDetailsEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseItemDetailsEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseItemDetailsEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseItemDetailsEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseItemDetailsEntity.FieldId, itemDetailsEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        partial void SetEntityExpand(SQLBuilder sqlBuilder, BaseItemDetailsEntity itemDetailsEntity);

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="itemDetailsEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseItemDetailsEntity itemDetailsEntity)
        {
            sqlBuilder.SetValue(BaseItemDetailsEntity.FieldParentId, itemDetailsEntity.ParentId);
            sqlBuilder.SetValue(BaseItemDetailsEntity.FieldItemCode, itemDetailsEntity.ItemCode);
            sqlBuilder.SetValue(BaseItemDetailsEntity.FieldItemName, itemDetailsEntity.ItemName);
            sqlBuilder.SetValue(BaseItemDetailsEntity.FieldItemValue, itemDetailsEntity.ItemValue);
            sqlBuilder.SetValue(BaseItemDetailsEntity.FieldAllowEdit, itemDetailsEntity.AllowEdit);
            sqlBuilder.SetValue(BaseItemDetailsEntity.FieldAllowDelete, itemDetailsEntity.AllowDelete);
            sqlBuilder.SetValue(BaseItemDetailsEntity.FieldIsPublic, itemDetailsEntity.IsPublic);
            sqlBuilder.SetValue(BaseItemDetailsEntity.FieldEnabled, itemDetailsEntity.Enabled);
            sqlBuilder.SetValue(BaseItemDetailsEntity.FieldDeletionStateCode, itemDetailsEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseItemDetailsEntity.FieldSortCode, itemDetailsEntity.SortCode);
            sqlBuilder.SetValue(BaseItemDetailsEntity.FieldDescription, itemDetailsEntity.Description);
            SetEntityExpand(sqlBuilder, itemDetailsEntity);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseItemDetailsEntity.FieldId, id));
        }
    }
}
