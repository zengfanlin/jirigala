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
    /// BaseFileManager
    /// 文件新闻表
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
    public partial class BaseFileManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseFileManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            }
            base.CurrentTableName = BaseFileEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseFileManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseFileManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">操作员信息</param>
        public BaseFileManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">操作员信息</param>
        public BaseFileManager(IDbHelper dbHelper, BaseUserInfo userInfo)
            : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">操作员信息</param>
        /// <param name="tableName">指定表名</param>
        public BaseFileManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="fileEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseFileEntity fileEntity)
        {
            return this.AddEntity(fileEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="fileEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BaseFileEntity fileEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(fileEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="BaseFileEntity">实体</param>
        public int Update(BaseFileEntity fileEntity)
        {
            return this.UpdateEntity(fileEntity);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="fileEntity">实体</param>
        public string AddEntity(BaseFileEntity fileEntity)
        {
            string sequence = string.Empty;
            sequence = fileEntity.Id;
            if (fileEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                fileEntity.SortCode = int.Parse(sequence);
            }
            if (fileEntity.Id is string)
            {
                this.Identity = false;
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseFileEntity.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BaseFileEntity.FieldId, fileEntity.Id);
            }
            else
            {
                if (!this.ReturnId && DbHelper.CurrentDbType == CurrentDbType.Oracle)
                {
                    sqlBuilder.SetFormula(BaseFileEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                }
                else
                {
                    if (this.Identity && DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        if (string.IsNullOrEmpty(fileEntity.Id))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            fileEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(BaseFileEntity.FieldId, fileEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, fileEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseFileEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseFileEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseFileEntity.FieldCreateOn);
            // 这里主要是为了列表里的数据库更好看
            sqlBuilder.SetValue(BaseFileEntity.FieldModifiedUserId, fileEntity.ModifiedUserId);
            sqlBuilder.SetValue(BaseFileEntity.FieldModifiedBy, fileEntity.ModifiedBy);
            sqlBuilder.SetValue(BaseFileEntity.FieldModifiedOn, fileEntity.ModifiedOn);
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
        /// <param name="fileEntity">实体</param>
        public int UpdateEntity(BaseFileEntity fileEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, fileEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseFileEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseFileEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseFileEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseFileEntity.FieldId, fileEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        partial void SetEntityExpand(SQLBuilder sqlBuilder, BaseFileEntity fileEntity);

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="BaseFileEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseFileEntity fileEntity)
        {
            sqlBuilder.SetValue(BaseFileEntity.FieldFolderId, fileEntity.FolderId);
            sqlBuilder.SetValue(BaseFileEntity.FieldFileName, fileEntity.FileName);
            sqlBuilder.SetValue(BaseFileEntity.FieldFilePath, fileEntity.FilePath);
            sqlBuilder.SetValue(BaseFileEntity.FieldContents, fileEntity.Contents);
            if (fileEntity.Contents != null)
            {
                sqlBuilder.SetValue(BaseFileEntity.FieldFileSize, fileEntity.Contents.Length);
            }
            else
            {
                sqlBuilder.SetValue(BaseFileEntity.FieldFileSize, fileEntity.FileSize);
            }
            sqlBuilder.SetValue(BaseFileEntity.FieldReadCount, fileEntity.ReadCount);
            sqlBuilder.SetValue(BaseFileEntity.FieldDeletionStateCode, fileEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseFileEntity.FieldDescription, fileEntity.Description);
            sqlBuilder.SetValue(BaseFileEntity.FieldEnabled, fileEntity.Enabled);
            sqlBuilder.SetValue(BaseFileEntity.FieldSortCode, fileEntity.SortCode);
            SetEntityExpand(sqlBuilder, fileEntity);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseFileEntity.FieldId, id));
        }
    }
}
