//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseMessageManager
    /// 消息表
    /// 
    /// 修改纪录
    /// 
    /// 2012-07-03 版本：1.0 JiRiGaLa 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>JiRiGaLa</name>
    /// <date>2012-07-03</date>
    /// </author>
    /// </summary>
    public partial class BaseMessageManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseMessageManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            }
            base.CurrentTableName = BaseMessageEntity.TableName;
            base.PrimaryKey = "Id";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseMessageManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseMessageManager(IDbHelper dbHelper): this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseMessageManager(BaseUserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseMessageManager(IDbHelper dbHelper, BaseUserInfo userInfo) : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public BaseMessageManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName) : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseMessageEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseMessageEntity baseMessageEntity)
        {
            return this.AddEntity(baseMessageEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseMessageEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(BaseMessageEntity baseMessageEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(baseMessageEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="baseMessageEntity">实体</param>
        public int Update(BaseMessageEntity baseMessageEntity)
        {
            return this.UpdateEntity(baseMessageEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseMessageEntity GetEntity(string id)
        {
            BaseMessageEntity baseMessageEntity = new BaseMessageEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseMessageEntity.FieldId, id)));
            return baseMessageEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="baseMessageEntity">实体</param>
        public string AddEntity(BaseMessageEntity baseMessageEntity)
        {
            string sequence = string.Empty;
            this.Identity = false; 
            if (baseMessageEntity.SortCode == null || baseMessageEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                baseMessageEntity.SortCode = int.Parse(sequence);
            }
            if (baseMessageEntity.Id != null)
            {
                sequence = baseMessageEntity.Id.ToString();
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseMessageEntity.FieldId);
            if (!this.Identity) 
            {
                if (string.IsNullOrEmpty(baseMessageEntity.Id)) 
                { 
                    sequence = BaseBusinessLogic.NewGuid(); 
                    baseMessageEntity.Id = sequence ;
                }
                sqlBuilder.SetValue(BaseMessageEntity.FieldId, baseMessageEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseMessageEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseMessageEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(baseMessageEntity.Id))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            baseMessageEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(BaseMessageEntity.FieldId, baseMessageEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, baseMessageEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseMessageEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseMessageEntity.FieldCreateBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseMessageEntity.FieldCreateOn);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseMessageEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseMessageEntity.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseMessageEntity.FieldModifiedOn);
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
        /// <param name="baseMessageEntity">实体</param>
        public int UpdateEntity(BaseMessageEntity baseMessageEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, baseMessageEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(BaseMessageEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseMessageEntity.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(BaseMessageEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseMessageEntity.FieldId, baseMessageEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        // 这个是声明扩展方法
        partial void SetEntityExpand(SQLBuilder sqlBuilder, BaseMessageEntity baseMessageEntity);
        
        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="baseMessageEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseMessageEntity baseMessageEntity)
        {
            SetEntityExpand(sqlBuilder, baseMessageEntity);
            sqlBuilder.SetValue(BaseMessageEntity.FieldParentId, baseMessageEntity.ParentId);
            sqlBuilder.SetValue(BaseMessageEntity.FieldReceiverDepartmentId, baseMessageEntity.ReceiverDepartmentId);
            sqlBuilder.SetValue(BaseMessageEntity.FieldReceiverDepartmentName, baseMessageEntity.ReceiverDepartmentName);
            sqlBuilder.SetValue(BaseMessageEntity.FieldReceiverId, baseMessageEntity.ReceiverId);
            sqlBuilder.SetValue(BaseMessageEntity.FieldReceiverRealName, baseMessageEntity.ReceiverRealName);
            sqlBuilder.SetValue(BaseMessageEntity.FieldFunctionCode, baseMessageEntity.FunctionCode);
            sqlBuilder.SetValue(BaseMessageEntity.FieldCategoryCode, baseMessageEntity.CategoryCode);
            sqlBuilder.SetValue(BaseMessageEntity.FieldObjectId, baseMessageEntity.ObjectId);
            sqlBuilder.SetValue(BaseMessageEntity.FieldTitle, baseMessageEntity.Title);
            sqlBuilder.SetValue(BaseMessageEntity.FieldContents, baseMessageEntity.Contents);
            sqlBuilder.SetValue(BaseMessageEntity.FieldIsNew, baseMessageEntity.IsNew);
            sqlBuilder.SetValue(BaseMessageEntity.FieldReadCount, baseMessageEntity.ReadCount);
            sqlBuilder.SetValue(BaseMessageEntity.FieldReadDate, baseMessageEntity.ReadDate);
            sqlBuilder.SetValue(BaseMessageEntity.FieldTargetURL, baseMessageEntity.TargetURL);
            sqlBuilder.SetValue(BaseMessageEntity.FieldIPAddress, baseMessageEntity.IPAddress);
            sqlBuilder.SetValue(BaseMessageEntity.FieldCreateDepartmentId, baseMessageEntity.CreateDepartmentId);
            sqlBuilder.SetValue(BaseMessageEntity.FieldCreateDepartmentName, baseMessageEntity.CreateDepartmentName);
            sqlBuilder.SetValue(BaseMessageEntity.FieldDeletionStateCode, baseMessageEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseMessageEntity.FieldEnabled, baseMessageEntity.Enabled);
            sqlBuilder.SetValue(BaseMessageEntity.FieldDescription, baseMessageEntity.Description);
            sqlBuilder.SetValue(BaseMessageEntity.FieldSortCode, baseMessageEntity.SortCode);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseMessageEntity.FieldId, id));
        }
    }
}
