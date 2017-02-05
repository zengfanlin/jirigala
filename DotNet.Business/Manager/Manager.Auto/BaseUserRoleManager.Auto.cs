//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseUserRoleManager
    /// 用户-角色 关系
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
    public partial class BaseUserRoleManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseUserRoleManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            }
            base.CurrentTableName = BaseUserRoleEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseUserRoleManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseUserRoleManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseUserRoleManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseUserRoleManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BaseUserRoleManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userRoleEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseUserRoleEntity userRoleEntity)
        {
            return this.AddEntity(userRoleEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userRoleEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BaseUserRoleEntity userRoleEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(userRoleEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="userRoleEntity">实体</param>
        public int Update(BaseUserRoleEntity userRoleEntity)
        {
            return this.UpdateEntity(userRoleEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseUserRoleEntity GetEntity(int id)
        {
            BaseUserRoleEntity userRoleEntity = new BaseUserRoleEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseUserRoleEntity.FieldId, id)));
            return userRoleEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="userRoleEntity">实体</param>
        public string AddEntity(BaseUserRoleEntity userRoleEntity)
        {
            string sequence = string.Empty;
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseUserRoleEntity.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BaseUserRoleEntity.FieldId, userRoleEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseUserRoleEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseUserRoleEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (userRoleEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            userRoleEntity.Id = int.Parse(sequence);
                        }
                        sqlBuilder.SetValue(BaseUserRoleEntity.FieldId, userRoleEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, userRoleEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseUserRoleEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseUserRoleEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseUserRoleEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseUserRoleEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseUserRoleEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseUserRoleEntity.FieldModifiedOn);
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
        /// <param name="userRoleEntity">实体</param>
        public int UpdateEntity(BaseUserRoleEntity userRoleEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, userRoleEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseUserRoleEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseUserRoleEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseUserRoleEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseUserRoleEntity.FieldId, userRoleEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        partial void SetEntityExpand(SQLBuilder sqlBuilder, BaseUserRoleEntity userRoleEntity);

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="userRoleEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseUserRoleEntity userRoleEntity)
        {
            sqlBuilder.SetValue(BaseUserRoleEntity.FieldUserId, userRoleEntity.UserId);
            sqlBuilder.SetValue(BaseUserRoleEntity.FieldRoleId, userRoleEntity.RoleId);
            sqlBuilder.SetValue(BaseUserRoleEntity.FieldEnabled, userRoleEntity.Enabled);
            sqlBuilder.SetValue(BaseUserRoleEntity.FieldDescription, userRoleEntity.Description);
            sqlBuilder.SetValue(BaseUserRoleEntity.FieldDeletionStateCode, userRoleEntity.DeletionStateCode);
            SetEntityExpand(sqlBuilder, userRoleEntity);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseUserRoleEntity.FieldId, id));
        }        
    }
}
