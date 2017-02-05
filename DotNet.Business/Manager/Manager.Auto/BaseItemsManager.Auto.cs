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
    /// BaseItemsManager
    /// 选项主表（资源）
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
    public partial class BaseItemsManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseItemsManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            }
            base.CurrentTableName = BaseItemsEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseItemsManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseItemsManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseItemsManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseItemsManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BaseItemsManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="itemsEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseItemsEntity itemsEntity)
        {
            return this.AddEntity(itemsEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="itemsEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BaseItemsEntity itemsEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(itemsEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="itemsEntity">实体</param>
        public int Update(BaseItemsEntity itemsEntity)
        {
            return this.UpdateEntity(itemsEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseItemsEntity GetEntity(int id)
        {
            return GetEntity(id.ToString());
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseItemsEntity GetEntity(string id)
        {
            BaseItemsEntity itemsEntity = new BaseItemsEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseItemsEntity.FieldId, id)));
            return itemsEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="itemsEntity">实体</param>
        public string AddEntity(BaseItemsEntity itemsEntity)
        {
            string sequence = string.Empty;
            if (itemsEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                itemsEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseItemsEntity.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BaseItemsEntity.FieldId, itemsEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseItemsEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseItemsEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
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
                        itemsEntity.Id = int.Parse(sequence);
                        sqlBuilder.SetValue(BaseItemsEntity.FieldId, itemsEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, itemsEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseItemsEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseItemsEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseItemsEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseItemsEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseItemsEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseItemsEntity.FieldModifiedOn);
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
        /// <param name="itemsEntity">实体</param>
        public int UpdateEntity(BaseItemsEntity itemsEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, itemsEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseItemsEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseItemsEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseItemsEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseItemsEntity.FieldId, itemsEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        partial void SetEntityExpand(SQLBuilder sqlBuilder, BaseItemsEntity itemsEntity);

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="itemsEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseItemsEntity itemsEntity)
        {
            sqlBuilder.SetValue(BaseItemsEntity.FieldParentId, itemsEntity.ParentId);
            sqlBuilder.SetValue(BaseItemsEntity.FieldCode, itemsEntity.Code);
            sqlBuilder.SetValue(BaseItemsEntity.FieldFullName, itemsEntity.FullName);
            sqlBuilder.SetValue(BaseItemsEntity.FieldTargetTable, itemsEntity.TargetTable);
            sqlBuilder.SetValue(BaseItemsEntity.FieldIsTree, itemsEntity.IsTree);
            sqlBuilder.SetValue(BaseItemsEntity.FieldUseItemCode, itemsEntity.UseItemCode);
            sqlBuilder.SetValue(BaseItemsEntity.FieldUseItemName, itemsEntity.UseItemName);
            sqlBuilder.SetValue(BaseItemsEntity.FieldUseItemValue, itemsEntity.UseItemValue);
            sqlBuilder.SetValue(BaseItemsEntity.FieldAllowEdit, itemsEntity.AllowEdit);
            sqlBuilder.SetValue(BaseItemsEntity.FieldAllowDelete, itemsEntity.AllowDelete);
            sqlBuilder.SetValue(BaseItemsEntity.FieldDeletionStateCode, itemsEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseItemsEntity.FieldDescription, itemsEntity.Description);
            sqlBuilder.SetValue(BaseItemsEntity.FieldEnabled, itemsEntity.Enabled);
            sqlBuilder.SetValue(BaseItemsEntity.FieldSortCode, itemsEntity.SortCode);
            SetEntityExpand(sqlBuilder, itemsEntity);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseItemsEntity.FieldId, id));
        }        
    }
}