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
    /// BasePermissionManager
    /// 操作权限表
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
    public partial class BasePermissionManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BasePermissionManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            }
            base.CurrentTableName = BasePermissionEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BasePermissionManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BasePermissionManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BasePermissionManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BasePermissionManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BasePermissionManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="resourcePermissionEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BasePermissionEntity resourcePermissionEntity)
        {
            return this.AddEntity(resourcePermissionEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="resourcePermissionEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BasePermissionEntity resourcePermissionEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(resourcePermissionEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="resourcePermissionEntity">实体</param>
        public int Update(BasePermissionEntity resourcePermissionEntity)
        {
            return this.UpdateEntity(resourcePermissionEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BasePermissionEntity GetEntity(int id)
        {
            BasePermissionEntity resourcePermissionEntity = new BasePermissionEntity(this.GetDataTable(new KeyValuePair<string, object>(BasePermissionEntity.FieldId, id)));
            return resourcePermissionEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="resourcePermissionEntity">实体</param>
        public string AddEntity(BasePermissionEntity resourcePermissionEntity)
        {
            string sequence = string.Empty;
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BasePermissionEntity.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BasePermissionEntity.FieldId, resourcePermissionEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BasePermissionEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BasePermissionEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (resourcePermissionEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            resourcePermissionEntity.Id = int.Parse(sequence);
                        }
                        sqlBuilder.SetValue(BasePermissionEntity.FieldId, resourcePermissionEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, resourcePermissionEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BasePermissionEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BasePermissionEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BasePermissionEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BasePermissionEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BasePermissionEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BasePermissionEntity.FieldModifiedOn);
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
        /// <param name="resourcePermissionEntity">实体</param>
        public int UpdateEntity(BasePermissionEntity resourcePermissionEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, resourcePermissionEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BasePermissionEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BasePermissionEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BasePermissionEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BasePermissionEntity.FieldId, resourcePermissionEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        partial void SetEntityExpand(SQLBuilder sqlBuilder, BasePermissionEntity permissionEntity);

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="permissionEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BasePermissionEntity permissionEntity)
        {
            sqlBuilder.SetValue(BasePermissionEntity.FieldResourceId, permissionEntity.ResourceId);
            sqlBuilder.SetValue(BasePermissionEntity.FieldResourceCategory, permissionEntity.ResourceCategory);
            sqlBuilder.SetValue(BasePermissionEntity.FieldPermissionItemId, permissionEntity.PermissionId);
            sqlBuilder.SetValue(BasePermissionEntity.FieldPermissionConstraint, permissionEntity.PermissionConstraint);
            sqlBuilder.SetValue(BasePermissionEntity.FieldEnabled, permissionEntity.Enabled);
            sqlBuilder.SetValue(BasePermissionEntity.FieldDeletionStateCode, permissionEntity.DeletionStateCode);
            sqlBuilder.SetValue(BasePermissionEntity.FieldDescription, permissionEntity.Description);
            SetEntityExpand(sqlBuilder, permissionEntity);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(BasePermissionEntity.FieldId, id));
        }        
    }
}
