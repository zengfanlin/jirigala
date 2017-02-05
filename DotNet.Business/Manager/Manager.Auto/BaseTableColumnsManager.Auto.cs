//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseTableColumnsManager
    /// 表字段结构定义说明
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
    public partial class BaseTableColumnsManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseTableColumnsManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            }
            base.CurrentTableName = BaseTableColumnsEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseTableColumnsManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseTableColumnsManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseTableColumnsManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseTableColumnsManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BaseTableColumnsManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseTableColumnsEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseTableColumnsEntity baseTableColumnsEntity)
        {
            return this.AddEntity(baseTableColumnsEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseTableColumnsEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BaseTableColumnsEntity baseTableColumnsEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(baseTableColumnsEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="baseTableColumnsEntity">实体</param>
        public int Update(BaseTableColumnsEntity baseTableColumnsEntity)
        {
            return this.UpdateEntity(baseTableColumnsEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseTableColumnsEntity GetEntity(int id)
        {
            BaseTableColumnsEntity baseTableColumnsEntity = new BaseTableColumnsEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseTableColumnsEntity.FieldId, id)));
            return baseTableColumnsEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="baseTableColumnsEntity">实体</param>
        public string AddEntity(BaseTableColumnsEntity baseTableColumnsEntity)
        {
            string sequence = string.Empty;
            if (baseTableColumnsEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                baseTableColumnsEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseTableColumnsEntity.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BaseTableColumnsEntity.FieldId, baseTableColumnsEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseTableColumnsEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseTableColumnsEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (baseTableColumnsEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            baseTableColumnsEntity.Id = int.Parse(sequence);
                        }
                        sqlBuilder.SetValue(BaseTableColumnsEntity.FieldId, baseTableColumnsEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, baseTableColumnsEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseTableColumnsEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseTableColumnsEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseTableColumnsEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseTableColumnsEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseTableColumnsEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseTableColumnsEntity.FieldModifiedOn);
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
        /// <param name="baseTableColumnsEntity">实体</param>
        public int UpdateEntity(BaseTableColumnsEntity baseTableColumnsEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, baseTableColumnsEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseTableColumnsEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseTableColumnsEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseTableColumnsEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseTableColumnsEntity.FieldId, baseTableColumnsEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        partial void SetEntityExpand(SQLBuilder sqlBuilder, BaseTableColumnsEntity tableColumnsEntity);

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="tableColumnsEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseTableColumnsEntity tableColumnsEntity)
        {
            sqlBuilder.SetValue(BaseTableColumnsEntity.FieldTableCode, tableColumnsEntity.TableCode);
            sqlBuilder.SetValue(BaseTableColumnsEntity.FieldColumnCode, tableColumnsEntity.ColumnCode);
            sqlBuilder.SetValue(BaseTableColumnsEntity.FieldColumnName, tableColumnsEntity.ColumnName);
            sqlBuilder.SetValue(BaseTableColumnsEntity.FieldIsPublic, tableColumnsEntity.IsPublic);
            sqlBuilder.SetValue(BaseTableColumnsEntity.FieldEnabled, tableColumnsEntity.Enabled);
            sqlBuilder.SetValue(BaseTableColumnsEntity.FieldAllowEdit, tableColumnsEntity.AllowEdit);
            sqlBuilder.SetValue(BaseTableColumnsEntity.FieldAllowDelete, tableColumnsEntity.AllowDelete);
            sqlBuilder.SetValue(BaseTableColumnsEntity.FieldDeletionStateCode, tableColumnsEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseTableColumnsEntity.FieldSortCode, tableColumnsEntity.SortCode);
            sqlBuilder.SetValue(BaseTableColumnsEntity.FieldDescription, tableColumnsEntity.Description);
            SetEntityExpand(sqlBuilder, tableColumnsEntity);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseTableColumnsEntity.FieldId, id));
        }
    }
}
