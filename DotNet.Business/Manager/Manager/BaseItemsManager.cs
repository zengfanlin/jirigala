//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseItemsManager 
    /// 主键管理表结构定义部分（程序OK）
    ///
	/// 注意事项;
	///		Id 为主键
	///		CreateOn不为空，默认值
	///		ParentId、FullName 需要建立唯一索引
	///		CategoryId 是为了解决多重数据库兼容的问题
	///		ParentId 是为了解决形成树行结构的问题
	///
	/// 修改记录
    ///
    ///     2007.12.03 版本：4.3 JiRiGaLa  进行规范化整理。
    ///     2007.06.03 版本：4.2 JiRiGaLa  进行改进整理。
    ///     2007.05.31 版本：4.1 JiRiGaLa  进行改进整理。
    ///		2007.01.15 版本：4.0 JiRiGaLa  重新整理主键。
    ///		2007.01.03 版本：3.0 JiRiGaLa  进行大批量主键整理。
    ///		2006.12.05 版本：2.0 JiRiGaLa  GetFullName 方法更新。
	///		2006.01.23 版本：1.0 JiRiGaLa  获取ItemDetails方法的改进。
	///		2004.11.12 版本：1.0 JiRiGaLa  主键进行了绝对的优化，基本上看上去还过得去了。
    ///     2007.12.03 版本：2.2 JiRiGaLa  进行规范化整理。
    ///     2007.05.30 版本：2.1 JiRiGaLa  整理主键，调整GetFrom()方法,增加AddEntity(),UpdateEntity(),DeleteEntity()
    ///		2007.01.15 版本：2.0 JiRiGaLa  重新整理主键。
	///		2006.02.06 版本：1.1 JiRiGaLa  重新调整主键的规范化。
	///		2005.10.03 版本：1.0 JiRiGaLa  表中添加是否可删除，可修改字段。
	///
	/// 版本：2.2
	/// </summary>
	/// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.12.03</date>
	/// </author>
	/// </summary>
    public partial class BaseItemsManager : BaseManager
    {
        #region public string Add(BaseItemsEntity itemsEntity, out string statusCode) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="itemsEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>主键</returns>
        public string Add(BaseItemsEntity itemsEntity, out string statusCode)
        {
            string returnValue = string.Empty;
            // 检查编号是否重复
            if (this.Exists(new KeyValuePair<string, object>(BaseItemsEntity.FieldParentId, itemsEntity.ParentId), new KeyValuePair<string, object>(BaseItemsEntity.FieldCode, itemsEntity.Code)))
            {
                // 编号已重复
                statusCode = StatusCode.ErrorCodeExist.ToString();
            }
            else
            {
                // 检查名称是否重复
                if (this.Exists(new KeyValuePair<string, object>(BaseItemsEntity.FieldParentId, itemsEntity.ParentId), new KeyValuePair<string, object>(BaseItemsEntity.FieldFullName, itemsEntity.FullName)))
                {
                    // 名称已重复
                    statusCode = StatusCode.ErrorNameExist.ToString();
                }
                else
                {
                    returnValue = this.AddEntity(itemsEntity);
                    // 运行成功
                    statusCode = StatusCode.OKAdd.ToString();
                }
            }
            return returnValue;
        }
        #endregion

        #region public int Update(BaseItemsEntity itemsEntity, out string statusCode) 更新
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="itemsEntity">实体</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>影响行数</returns>
        public int Update(BaseItemsEntity itemsEntity, out string statusCode)
        {
            int returnValue = 0;
            // 检查是否已被其他人修改            
            //if (DbLogic.IsModifed(DbHelper, this.CurrentTableName, itemsEntity.Id, itemsEntity.ModifiedUserId, itemsEntity.ModifiedOn))
            //{
            //    // 数据已经被修改
            //    statusCode = StatusCode.ErrorChanged.ToString();
            //}
            //else
            //{
                // 检查编号是否重复
                if (this.Exists(new KeyValuePair<string, object>(BaseItemsEntity.FieldParentId, itemsEntity.ParentId), new KeyValuePair<string, object>(BaseItemsEntity.FieldCode, itemsEntity.Code), itemsEntity.Id))
                {
                    // 编号已重复
                    statusCode = StatusCode.ErrorCodeExist.ToString();
                }
                else
                {
                    // 检查名称是否重复
                    if (this.Exists(new KeyValuePair<string, object>(BaseItemsEntity.FieldParentId, itemsEntity.ParentId), new KeyValuePair<string, object>(BaseItemsEntity.FieldFullName, itemsEntity.FullName), itemsEntity.Id))
                    {
                        // 名称已重复
                        statusCode = StatusCode.ErrorNameExist.ToString();
                    }
                    else
                    {
                        returnValue = this.UpdateEntity(itemsEntity);
                        if (returnValue == 1)
                        {
                            statusCode = StatusCode.OKUpdate.ToString();
                        }
                        else
                        {
                            statusCode = StatusCode.ErrorDeleted.ToString();
                        }
                    }
                }
            //}
            return returnValue;
        }
        #endregion

        #region public void CreateTable(string tableName, out string statusCode)
        /// <summary>
        /// 创建表结构
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="statusCode">状态返回码</param>
        /// <param name="statusMessage">状态返回信息</param>
        public void CreateTable(string tableName, out string statusCode)
        {
            statusCode = StatusCode.Error.ToString();
            string commandText = string.Empty;
            if (this.DbHelper.CurrentDbType == CurrentDbType.Access)
                // Access 中没有使用临时表，故直接返回成的标识
                statusCode = StatusCode.OK.ToString();
            else if (this.DbHelper.CurrentDbType == CurrentDbType.SqlServer)
            {
                commandText = @"
CREATE TABLE [dbo].[#tableName#](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[ItemCode] [nvarchar](40) NULL,
	[ItemName] [nvarchar](100)  NULL,
	[ItemValue] [nvarchar](100)  NULL,
	[Enabled] [int] NOT NULL CONSTRAINT [DF_#tableName#_Enabled]  DEFAULT ((1)),
	[AllowEdit] [int] NOT NULL CONSTRAINT [DF_#tableName#_AllowEdit]  DEFAULT ((1)),
	[AllowDelete] [int] NOT NULL CONSTRAINT [DF_#tableName#_AllowDelete]  DEFAULT ((1)),
	[IsPublic] [int] NOT NULL CONSTRAINT [DF_#tableName#_IsPublic]  DEFAULT ((1)),
	[DeletionStateCode] [int] NOT NULL CONSTRAINT [DF_#tableName#_DeleteMark]  DEFAULT ((0)),
	[SortCode] [int] NULL,
	[Description] [nvarchar](200)  NULL,
	[CreateOn] [smalldatetime] NOT NULL CONSTRAINT [DF_#tableName#_CreateOn]  DEFAULT (GETDATE()),
	[CreateUserId] [nvarchar](20)  NULL,
	[CreateBy] [nvarchar](20)  NULL,
	[ModifiedOn] [smalldatetime] NOT NULL CONSTRAINT [DF_#tableName#_ModifiedOn]  DEFAULT (GETDATE()),
	[ModifiedUserId] [nvarchar](20)  NULL,
	[ModifiedBy] [nvarchar](20)  NULL,
    CONSTRAINT [PK_#tableName#] PRIMARY KEY CLUSTERED 
    (
	    [Id] ASC
    )WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]";
                // 替换表明
                commandText = commandText.Replace("#tableName#", tableName);
                // 执行数据库指令
                this.DbHelper.ExecuteNonQuery(commandText);
                // 创建成功
                statusCode = StatusCode.OK.ToString();
            }
            else if (this.DbHelper.CurrentDbType == CurrentDbType.Oracle)
            {
                commandText = @"
create table #tableName# 
(
    Id                 INT                  not null,
    ParentId           INT,
    ItemCode           NVARCHAR2(200),
    ItemName           NVARCHAR2(200)       not null,
    ItemValue          NVARCHAR2(200),
    AllowEdit          INT                  default 1 not null,
    AllowDelete        INT                  default 1 not null,
    IsPublic           INT                  default 1 not null,
    Enabled            INT                  default 1 not null,
    DeletionStateCode  INT                  default 0,
    SortCode           INT,
    Description        NVARCHAR2(800),
    CreateOn           DATE,
    CreateUserId       NVARCHAR2(50),
    CreateBy           NVARCHAR2(50),
    ModifiedOn         DATE,
    ModifiedUserId     NVARCHAR2(50),
    ModifiedBy         NVARCHAR2(50),
    constraint PK_#tableName# primary key (Id)
)";
                // 替换表明
                commandText = commandText.Replace("#tableName#", tableName);
                // 创建表结构
                this.DbHelper.ExecuteNonQuery(commandText);
                commandText = "CREATE SEQUENCE SEQ_" + tableName + " MINVALUE 1 MAXVALUE 9999999999999999999 START WITH 1 INCREMENT BY 1 CACHE 20";
                // 创建序列
                this.DbHelper.ExecuteNonQuery(commandText);
                // 运行成功
                statusCode = StatusCode.OK.ToString();
            }
        }
        #endregion

        #region public override int BatchSave(DataTable dataTable) 批量进行保存
        /// <summary>
        /// 批量进行保存
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        public override int BatchSave(DataTable dataTable)
        {
            int returnValue = 0;
            BaseItemsEntity itemsEntity = new BaseItemsEntity();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                // 删除状态
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    string id = dataRow[BaseItemsEntity.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        if (itemsEntity.AllowDelete == 1)
                        {
                            returnValue += this.Delete(id);
                        }
                    }
                }
                // 被修改过
                if (dataRow.RowState == DataRowState.Modified)
                {
                    string id = dataRow[BaseItemsEntity.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        itemsEntity.GetFrom(dataRow);
                        // 判断是否允许编辑
                        if (itemsEntity.AllowEdit == 1)
                        {
                            returnValue += this.UpdateEntity(itemsEntity);
                        }
                        else
                        {
                            // 不允许编辑，但是排序还是允许的
                            returnValue += this.SetProperty(itemsEntity.Id, new KeyValuePair<string, object>(BaseItemsEntity.FieldSortCode, itemsEntity.SortCode));
                        }
                    }
                }
                // 添加状态
                if (dataRow.RowState == DataRowState.Added)
                {
                    itemsEntity.GetFrom(dataRow);
                    returnValue += this.AddEntity(itemsEntity).Length > 0 ? 1 : 0;
                }
                if (dataRow.RowState == DataRowState.Unchanged)
                {
                    continue;
                }
                if (dataRow.RowState == DataRowState.Detached)
                {
                    continue;
                }
            }
            return returnValue;
        }
        #endregion

	}
}