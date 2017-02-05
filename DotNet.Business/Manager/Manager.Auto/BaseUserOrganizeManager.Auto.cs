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
    /// BaseUserOrganizeManager
    /// 用户-组织结构关系表
    ///
    /// 修改纪录
    ///
    ///		2010-09-25 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010-09-25</date>
    /// </author>
    /// </summary>
    public partial class BaseUserOrganizeManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseUserOrganizeManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            }
            base.CurrentTableName = BaseUserOrganizeEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseUserOrganizeManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseUserOrganizeManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseUserOrganizeManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseUserOrganizeManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BaseUserOrganizeManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userOrganizeEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseUserOrganizeEntity userOrganizeEntity)
        {
            return this.AddEntity(userOrganizeEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userOrganizeEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BaseUserOrganizeEntity userOrganizeEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(userOrganizeEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="userOrganizeEntity">实体</param>
        public int Update(BaseUserOrganizeEntity userOrganizeEntity)
        {
            return this.UpdateEntity(userOrganizeEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseUserOrganizeEntity GetEntity(int id)
        {
            BaseUserOrganizeEntity userOrganizeEntity = new BaseUserOrganizeEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseUserOrganizeEntity.FieldId, id)));
            return userOrganizeEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="userOrganizeEntity">实体</param>
        public string AddEntity(BaseUserOrganizeEntity userOrganizeEntity)
        {
            string sequence = string.Empty;
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseUserOrganizeEntity.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BaseUserOrganizeEntity.FieldId, userOrganizeEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseUserOrganizeEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseUserOrganizeEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (userOrganizeEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            userOrganizeEntity.Id = int.Parse(sequence);
                        }
                        sqlBuilder.SetValue(BaseUserOrganizeEntity.FieldId, userOrganizeEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, userOrganizeEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseUserOrganizeEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseUserOrganizeEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseUserOrganizeEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseUserOrganizeEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseUserOrganizeEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseUserOrganizeEntity.FieldModifiedOn);
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
        /// <param name="userOrganizeEntity">实体</param>
        public int UpdateEntity(BaseUserOrganizeEntity userOrganizeEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, userOrganizeEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseUserOrganizeEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseUserOrganizeEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseUserOrganizeEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseUserOrganizeEntity.FieldId, userOrganizeEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        partial void SetEntityExpand(SQLBuilder sqlBuilder, BaseUserOrganizeEntity userOrganizeEntity);

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="userOrganizeEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseUserOrganizeEntity userOrganizeEntity)
        {
            sqlBuilder.SetValue(BaseUserOrganizeEntity.FieldUserId, userOrganizeEntity.UserId);
            sqlBuilder.SetValue(BaseUserOrganizeEntity.FieldCompanyId, userOrganizeEntity.CompanyId);
            sqlBuilder.SetValue(BaseUserOrganizeEntity.FieldDepartmentId, userOrganizeEntity.DepartmentId);
            sqlBuilder.SetValue(BaseUserOrganizeEntity.FieldWorkgroupId, userOrganizeEntity.WorkgroupId);
            sqlBuilder.SetValue(BaseUserOrganizeEntity.FieldRoleId, userOrganizeEntity.RoleId);
            sqlBuilder.SetValue(BaseUserOrganizeEntity.FieldEnabled, userOrganizeEntity.Enabled);
            sqlBuilder.SetValue(BaseUserOrganizeEntity.FieldDescription, userOrganizeEntity.Description);
            sqlBuilder.SetValue(BaseUserOrganizeEntity.FieldDeletionStateCode, userOrganizeEntity.DeletionStateCode);
            SetEntityExpand(sqlBuilder, userOrganizeEntity);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseUserOrganizeEntity.FieldId, id));
        }        
    }
}
