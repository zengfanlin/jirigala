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
    /// BaseRoleManager
    /// 角色表
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
    public partial class BaseRoleManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseRoleManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            }
            base.CurrentTableName = BaseRoleEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseRoleManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseRoleManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseRoleManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseRoleManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BaseRoleManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="roleEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseRoleEntity roleEntity)
        {
            return this.AddEntity(roleEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="roleEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BaseRoleEntity roleEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(roleEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="roleEntity">实体</param>
        public int Update(BaseRoleEntity roleEntity)
        {
            return this.UpdateEntity(roleEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseRoleEntity GetEntity(int? id)
        {
            return GetEntity(id.ToString());
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseRoleEntity GetEntity(string id)
        {
            BaseRoleEntity roleEntity = new BaseRoleEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseRoleEntity.FieldId, id)));
            return roleEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="roleEntity">实体</param>
        public string AddEntity(BaseRoleEntity roleEntity)
        {
            string sequence = string.Empty;
            if (roleEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                roleEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseRoleEntity.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BaseRoleEntity.FieldId, roleEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseRoleEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseRoleEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (roleEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            roleEntity.Id = int.Parse(sequence);
                        }
                        sqlBuilder.SetValue(BaseRoleEntity.FieldId, roleEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, roleEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseRoleEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseRoleEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseRoleEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseRoleEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseRoleEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseRoleEntity.FieldModifiedOn);
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
        /// <param name="roleEntity">实体</param>
        public int UpdateEntity(BaseRoleEntity roleEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, roleEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseRoleEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseRoleEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseRoleEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseRoleEntity.FieldId, roleEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        partial void SetEntityExpand(SQLBuilder sqlBuilder, BaseRoleEntity roleEntity);

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="roleEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseRoleEntity roleEntity)
        {
            sqlBuilder.SetValue(BaseRoleEntity.FieldSystemId, roleEntity.SystemId);
            sqlBuilder.SetValue(BaseRoleEntity.FieldOrganizeId, roleEntity.OrganizeId);
            sqlBuilder.SetValue(BaseRoleEntity.FieldCode, roleEntity.Code);
            sqlBuilder.SetValue(BaseRoleEntity.FieldRealName, roleEntity.RealName);
            sqlBuilder.SetValue(BaseRoleEntity.FieldCategoryCode, roleEntity.CategoryCode);
            sqlBuilder.SetValue(BaseRoleEntity.FieldAllowEdit, roleEntity.AllowEdit);
            sqlBuilder.SetValue(BaseRoleEntity.FieldAllowDelete, roleEntity.AllowDelete);
            sqlBuilder.SetValue(BaseRoleEntity.FieldSortCode, roleEntity.SortCode);
            sqlBuilder.SetValue(BaseRoleEntity.FieldDeletionStateCode, roleEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseRoleEntity.FieldEnabled, roleEntity.Enabled);
            sqlBuilder.SetValue(BaseRoleEntity.FieldDescription, roleEntity.Description);
            SetEntityExpand(sqlBuilder, roleEntity);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return Delete(new KeyValuePair<string, object>(BaseRoleEntity.FieldId, id));
        }        
    }
}