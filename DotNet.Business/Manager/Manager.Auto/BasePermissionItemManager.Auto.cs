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
    /// BasePermissionItemManager
    /// 操作权限项定义
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
    public partial class BasePermissionItemManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BasePermissionItemManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            }
            base.CurrentTableName = BasePermissionItemEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BasePermissionItemManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BasePermissionItemManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BasePermissionItemManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BasePermissionItemManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BasePermissionItemManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="permissionItemEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BasePermissionItemEntity permissionItemEntity)
        {
            return this.AddEntity(permissionItemEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="permissionItemEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BasePermissionItemEntity permissionItemEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(permissionItemEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="permissionItemEntity">实体</param>
        public int Update(BasePermissionItemEntity permissionItemEntity)
        {
            return this.UpdateEntity(permissionItemEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BasePermissionItemEntity GetEntity(int id)
        {
            return GetEntity(id.ToString());
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BasePermissionItemEntity GetEntity(string id)
        {
            BasePermissionItemEntity permissionItemEntity = new BasePermissionItemEntity(this.GetDataTable(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldId, id)));
            return permissionItemEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="permissionItemEntity">实体</param>
        public string AddEntity(BasePermissionItemEntity permissionItemEntity)
        {
            string sequence = string.Empty;
            if (permissionItemEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                permissionItemEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BasePermissionItemEntity.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BasePermissionItemEntity.FieldId, permissionItemEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BasePermissionItemEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BasePermissionItemEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (permissionItemEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            permissionItemEntity.Id = int.Parse(sequence);
                        }
                        sqlBuilder.SetValue(BasePermissionItemEntity.FieldId, permissionItemEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, permissionItemEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BasePermissionItemEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BasePermissionItemEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BasePermissionItemEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BasePermissionItemEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BasePermissionItemEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BasePermissionItemEntity.FieldModifiedOn);
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
        /// <param name="permissionItemEntity">实体</param>
        public int UpdateEntity(BasePermissionItemEntity permissionItemEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, permissionItemEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BasePermissionItemEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BasePermissionItemEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BasePermissionItemEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BasePermissionItemEntity.FieldId, permissionItemEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        partial void SetEntityExpand(SQLBuilder sqlBuilder, BasePermissionItemEntity permissionItemEntity);

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="permissionItemEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BasePermissionItemEntity permissionItemEntity)
        {
            sqlBuilder.SetValue(BasePermissionItemEntity.FieldParentId, permissionItemEntity.ParentId);
            sqlBuilder.SetValue(BasePermissionItemEntity.FieldCode, permissionItemEntity.Code);
            sqlBuilder.SetValue(BasePermissionItemEntity.FieldFullName, permissionItemEntity.FullName);
            sqlBuilder.SetValue(BasePermissionItemEntity.FieldCategoryCode, permissionItemEntity.CategoryCode);
            sqlBuilder.SetValue(BasePermissionItemEntity.FieldIsScope, permissionItemEntity.IsScope);
            sqlBuilder.SetValue(BasePermissionItemEntity.FieldIsPublic, permissionItemEntity.IsPublic);
            sqlBuilder.SetValue(BasePermissionItemEntity.FieldAllowEdit, permissionItemEntity.AllowEdit);
            sqlBuilder.SetValue(BasePermissionItemEntity.FieldAllowDelete, permissionItemEntity.AllowDelete);
            sqlBuilder.SetValue(BasePermissionItemEntity.FieldLastCall, permissionItemEntity.LastCall);
            sqlBuilder.SetValue(BasePermissionItemEntity.FieldEnabled, permissionItemEntity.Enabled);
            sqlBuilder.SetValue(BasePermissionItemEntity.FieldDeletionStateCode, permissionItemEntity.DeletionStateCode);
            sqlBuilder.SetValue(BasePermissionItemEntity.FieldSortCode, permissionItemEntity.SortCode);
            sqlBuilder.SetValue(BasePermissionItemEntity.FieldDescription, permissionItemEntity.Description);
            SetEntityExpand(sqlBuilder, permissionItemEntity);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(BasePermissionItemEntity.FieldId, id));
        }        
    }
}
