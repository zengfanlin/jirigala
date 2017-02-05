//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseFolderManager
    /// 文件夹表
    /// 
    /// 修改纪录
    /// 
    /// 2012-05-17 版本：1.0 JiRiGaLa 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>JiRiGaLa</name>
    /// <date>2012-05-17</date>
    /// </author>
    /// </summary>
    public partial class BaseFolderManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseFolderManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            }
            base.CurrentTableName = BaseFolderEntity.TableName;
            base.PrimaryKey = "Id";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseFolderManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseFolderManager(IDbHelper dbHelper): this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseFolderManager(BaseUserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseFolderManager(IDbHelper dbHelper, BaseUserInfo userInfo) : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public BaseFolderManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName) : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseFolderEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseFolderEntity baseFolderEntity)
        {
            return this.AddEntity(baseFolderEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseFolderEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(BaseFolderEntity baseFolderEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(baseFolderEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="baseFolderEntity">实体</param>
        public int Update(BaseFolderEntity baseFolderEntity)
        {
            return this.UpdateEntity(baseFolderEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseFolderEntity GetEntity(string id)
        {
            BaseFolderEntity baseFolderEntity = new BaseFolderEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseFolderEntity.FieldId, id)));
            return baseFolderEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="baseFolderEntity">实体</param>
        public string AddEntity(BaseFolderEntity baseFolderEntity)
        {
            string sequence = string.Empty;
            this.Identity = false; 
            if (baseFolderEntity.SortCode == null || baseFolderEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                baseFolderEntity.SortCode = int.Parse(sequence);
            }
            if (baseFolderEntity.Id != null)
            {
                sequence = baseFolderEntity.Id.ToString();
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseFolderEntity.FieldId);
            if (!this.Identity) 
            {
                if (string.IsNullOrEmpty(baseFolderEntity.Id)) 
                { 
                    sequence = BaseBusinessLogic.NewGuid(); 
                    baseFolderEntity.Id = sequence ;
                }
                sqlBuilder.SetValue(BaseFolderEntity.FieldId, baseFolderEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseFolderEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseFolderEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(baseFolderEntity.Id))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            baseFolderEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(BaseFolderEntity.FieldId, baseFolderEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, baseFolderEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseFolderEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseFolderEntity.FieldCreateBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseFolderEntity.FieldCreateOn);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseFolderEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseFolderEntity.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseFolderEntity.FieldModifiedOn);
            if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.SqlServer || DbHelper.CurrentDbType == CurrentDbType.Access))
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
        /// <param name="baseFolderEntity">实体</param>
        public int UpdateEntity(BaseFolderEntity baseFolderEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, baseFolderEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseFolderEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseFolderEntity.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseFolderEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseFolderEntity.FieldId, baseFolderEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        partial void SetEntityExpand(SQLBuilder sqlBuilder, BaseFolderEntity folderEntity);

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="folderEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseFolderEntity folderEntity)
        {
            sqlBuilder.SetValue(BaseFolderEntity.FieldParentId, folderEntity.ParentId);
            sqlBuilder.SetValue(BaseFolderEntity.FieldFolderName, folderEntity.FolderName);
            sqlBuilder.SetValue(BaseFolderEntity.FieldStateCode, folderEntity.StateCode);
            sqlBuilder.SetValue(BaseFolderEntity.FieldSortCode, folderEntity.SortCode);
            sqlBuilder.SetValue(BaseFolderEntity.FieldAllowEdit, folderEntity.AllowEdit);
            sqlBuilder.SetValue(BaseFolderEntity.FieldAllowDelete, folderEntity.AllowDelete);
            sqlBuilder.SetValue(BaseFolderEntity.FieldIsPublic, folderEntity.IsPublic);
            sqlBuilder.SetValue(BaseFolderEntity.FieldEnabled, folderEntity.Enabled);
            sqlBuilder.SetValue(BaseFolderEntity.FieldDeletionStateCode, folderEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseFolderEntity.FieldDescription, folderEntity.Description);
            SetEntityExpand(sqlBuilder, folderEntity);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseFolderEntity.FieldId, id));
        }
    }
}
