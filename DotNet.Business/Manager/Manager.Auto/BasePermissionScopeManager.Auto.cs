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
    /// BasePermissionScopeManager
    /// 数据权限表
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
    public partial class BasePermissionScopeManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BasePermissionScopeManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            }
            base.CurrentTableName = BasePermissionScopeEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BasePermissionScopeManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BasePermissionScopeManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BasePermissionScopeManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BasePermissionScopeManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BasePermissionScopeManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseResourcePermissionScopeEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BasePermissionScopeEntity baseResourcePermissionScopeEntity)
        {
            return this.AddEntity(baseResourcePermissionScopeEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseResourcePermissionScopeEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BasePermissionScopeEntity baseResourcePermissionScopeEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(baseResourcePermissionScopeEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="baseResourcePermissionScopeEntity">实体</param>
        public int Update(BasePermissionScopeEntity baseResourcePermissionScopeEntity)
        {
            return this.UpdateEntity(baseResourcePermissionScopeEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BasePermissionScopeEntity GetEntity(int id)
        {
            BasePermissionScopeEntity baseResourcePermissionScopeEntity = new BasePermissionScopeEntity(this.GetDataTable(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldId, id)));
            return baseResourcePermissionScopeEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="baseResourcePermissionScopeEntity">实体</param>
        public string AddEntity(BasePermissionScopeEntity baseResourcePermissionScopeEntity)
        {
            string sequence = string.Empty;
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BasePermissionScopeEntity.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BasePermissionScopeEntity.FieldId, baseResourcePermissionScopeEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BasePermissionScopeEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BasePermissionScopeEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (baseResourcePermissionScopeEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            baseResourcePermissionScopeEntity.Id = int.Parse(sequence);
                        }
                        sqlBuilder.SetValue(BasePermissionScopeEntity.FieldId, baseResourcePermissionScopeEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, baseResourcePermissionScopeEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BasePermissionScopeEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BasePermissionScopeEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BasePermissionScopeEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BasePermissionScopeEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BasePermissionScopeEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BasePermissionScopeEntity.FieldModifiedOn);
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
        /// <param name="baseResourcePermissionScopeEntity">实体</param>
        public int UpdateEntity(BasePermissionScopeEntity baseResourcePermissionScopeEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, baseResourcePermissionScopeEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BasePermissionScopeEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BasePermissionScopeEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BasePermissionScopeEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BasePermissionScopeEntity.FieldId, baseResourcePermissionScopeEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        partial void SetEntityExpand(SQLBuilder sqlBuilder, BasePermissionScopeEntity permissionScopeEntity);

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="permissionScopeEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BasePermissionScopeEntity permissionScopeEntity)
        {
            sqlBuilder.SetValue(BasePermissionScopeEntity.FieldResourceCategory, permissionScopeEntity.ResourceCategory);
            sqlBuilder.SetValue(BasePermissionScopeEntity.FieldResourceId, permissionScopeEntity.ResourceId);
            sqlBuilder.SetValue(BasePermissionScopeEntity.FieldTargetCategory, permissionScopeEntity.TargetCategory);
            sqlBuilder.SetValue(BasePermissionScopeEntity.FieldTargetId, permissionScopeEntity.TargetId);
            sqlBuilder.SetValue(BasePermissionScopeEntity.FieldPermissionItemId, permissionScopeEntity.PermissionId);
            sqlBuilder.SetValue(BasePermissionScopeEntity.FieldPermissionConstraint, permissionScopeEntity.PermissionConstraint);
            sqlBuilder.SetValue(BasePermissionScopeEntity.FieldStartDate, permissionScopeEntity.StartDate);
            sqlBuilder.SetValue(BasePermissionScopeEntity.FieldEndDate, permissionScopeEntity.EndDate);
            sqlBuilder.SetValue(BasePermissionScopeEntity.FieldEnabled, permissionScopeEntity.Enabled);
            sqlBuilder.SetValue(BasePermissionScopeEntity.FieldDeletionStateCode, permissionScopeEntity.DeletionStateCode);
            sqlBuilder.SetValue(BasePermissionScopeEntity.FieldDescription, permissionScopeEntity.Description);
            SetEntityExpand(sqlBuilder, permissionScopeEntity);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(BasePermissionScopeEntity.FieldId, id));
        }        
    }
}
