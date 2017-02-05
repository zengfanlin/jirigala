//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseMessageManager（程序OK）
    /// 消息表
    ///
    /// 修改记录
    ///     
    ///     2009.03.16 版本：2.1 JiRiGaLa 已发信息查询功能整理。
    ///     2009.02.20 版本：2.0 JiRiGaLa 主键分类，表结构进行改进，主键重新整理。
    ///     2008.04.15 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.15</date>
    /// </author>
    /// </summary>
    public partial class BaseMessageManager : BaseManager
    {
        private string Query = " SELECT * FROM " + BaseMessageEntity.TableName;

        #region public int Send(BaseMessageEntity messageEntity, bool saveSend = true) 添加短信，只能发给一个人
        /// <summary>
        /// 添加一条短信，只能发给一个人，在数据库中加入两条记录
        /// </summary>
        /// <param name="messageEntity">添加对象</param>
        /// <returns>影响行数</returns>
        public int Send(BaseMessageEntity messageEntity, bool saveSend = true)
        {
            string[] receiverIds = new string[1];
            receiverIds[0] = messageEntity.ReceiverId.ToString();
            return this.Send(messageEntity, receiverIds, saveSend);
        }
        #endregion

        #region public int Send(BaseMessageEntity messageEntity, string[] receiverIds, bool saveSend = true) 添加短信，可以发给多个人
        /// <summary>
        /// 添加短信，可以发给多个人
        /// </summary>
        /// <param name="messageEntity">实体</param>
        /// <param name="receiverIds">接收者ID组</param>
        /// <returns>影响行数</returns>
        public int Send(BaseMessageEntity messageEntity, string[] receiverIds, bool saveSend = true)
        {
            BaseUserManager userManager = new BaseUserManager(DbHelper, UserInfo);
            // 每发一条短信，数据库中需要记录两条记录，他们的CreateUserId都为创建者ID。
            // 接收者多人的话，不要重复设置创建人的记录了，即对发送者来说，只要记录一条记录就够了  
            int returnValue = 0;
            messageEntity.CategoryCode = MessageCategory.Receiver.ToString();
            messageEntity.IsNew = (int)MessageStateCode.New;
            messageEntity.IPAddress = UserInfo.IPAddress;
            messageEntity.ParentId = null;
            messageEntity.DeletionStateCode = 0;
            messageEntity.Enabled = 1;
            returnValue++;

            BaseUserEntity userEntity = null;
            for (int i = 0; i < receiverIds.Length; i++)
            {
                messageEntity.ParentId = null;
                messageEntity.Id = Guid.NewGuid().ToString();
                messageEntity.CategoryCode = MessageCategory.Receiver.ToString();
                messageEntity.ReceiverId = receiverIds[i];
                userEntity = userManager.GetEntity(receiverIds[i]);
                if (userEntity != null && !string.IsNullOrEmpty(userEntity.Id))
                {
                    messageEntity.ReceiverRealName = userEntity.RealName;
                    // 发给了哪个部门的人，意义不大，是来自哪个部门的人，意义更大一些
                    // messageEntity.DepartmentId = userEntity.DepartmentId;
                    // messageEntity.DepartmentName = userEntity.DepartmentName;
                }
                messageEntity.Enabled = 1;
                messageEntity.IsNew = 1;
                if (messageEntity.ReceiverId.Equals(UserInfo.Id))
                {
                    messageEntity.IsNew = (int)MessageStateCode.Old;
                }
                // 接收信息
                string parentId = this.Add(messageEntity, false, false);
                if (saveSend)
                {
                    // 已发送信息
                    messageEntity.Id = Guid.NewGuid().ToString();
                    messageEntity.ParentId = parentId;
                    messageEntity.CategoryCode = MessageCategory.Send.ToString();
                    messageEntity.DeletionStateCode = 0;
                    messageEntity.Enabled = 0;
                    this.Add(messageEntity, false, false);
                }
                returnValue++;
            }
            return returnValue;
        }
        #endregion

        #region public int Send(BaseMessageEntity messageEntity, string organizeId, bool saveSend = true) 按部门群发短信
        /// <summary>
        /// 按部门群发短信
        /// </summary>
        /// <param name="messageEntity">实体</param>
        /// <param name="organizeId">部门主键</param>
        /// <returns>影响行数</returns>
        public int Send(BaseMessageEntity messageEntity, string organizeId, bool saveSend = true)
        {
            int returnValue = 0;
            int i = 0;
            BaseUserManager userManager = new BaseUserManager(DbHelper, UserInfo);
            DataTable dataTable = userManager.GetChildrenUsers(organizeId);
            string[] receiverIds = new string[dataTable.Rows.Count];
            foreach (DataRow dataRow in dataTable.Rows)
            {
                receiverIds[i++] = dataRow[BaseMessageEntity.FieldId].ToString();
            }
            returnValue = this.Send(messageEntity, receiverIds, saveSend);
            return returnValue;
        }
        #endregion

        public int BatchSend(string[] receiverIds, string organizeId, string roleId, BaseMessageEntity messageEntity, bool saveSend = true)
        {
            string[] organizeIds = null;
            string[] roleIds = null;
            if (!string.IsNullOrEmpty(organizeId))
            {
                organizeIds = new string[] { organizeId };
            }
            if (!string.IsNullOrEmpty(roleId))
            {
                roleIds = new string[] { roleId };
            }
            return BatchSend(receiverIds, organizeIds, roleIds, messageEntity, saveSend);
        }

        public int BatchSend(string receiverId, string organizeId, string roleId, BaseMessageEntity messageEntity, bool saveSend = true)
        {
            string[] receiverIds = null;
            string[] organizeIds = null;
            string[] roleIds = null;
            if (!string.IsNullOrEmpty(receiverId))
            {
                receiverIds = new string[] { receiverId };
            }
            if (!string.IsNullOrEmpty(organizeId))
            {
                organizeIds = new string[] { organizeId };
            }
            if (!string.IsNullOrEmpty(roleId))
            {
                roleIds = new string[] { roleId };
            }
            return BatchSend(receiverIds, organizeIds, roleIds, messageEntity, saveSend);
        }

        #region public int BatchSend(string[] receiverIds, string[] organizeIds, string[] roleIds, BaseMessageEntity messageEntity, bool saveSend  = true) 批量发送消息
        /// <summary>
        /// 批量发送消息
        /// </summary>
        /// <param name="receiverIds">接收者主键组</param>
        /// <param name="organizeIds">组织机构主键组</param>
        /// <param name="roleIds">角色主键组</param>
        /// <param name="content">内容</param>
        /// <returns>影响行数</returns>
        public int BatchSend(string[] receiverIds, string[] organizeIds, string[] roleIds, BaseMessageEntity messageEntity, bool saveSend = true)
        {
            BaseUserManager userManager = new BaseUserManager(DbHelper, UserInfo);
            receiverIds = userManager.GetUserIds(receiverIds, organizeIds, roleIds);
            return this.Send(messageEntity, receiverIds, saveSend);
        }
        #endregion

        #region public int GetNewCount() 获取新信息个数
        /// <summary>
        /// 获取新信息个数
        /// </summary>
        /// <returns>记录个数</returns>
        public int GetNewCount()
        {
            return this.GetNewCount(MessageFunction.Message);
        }
        #endregion

        #region public int GetNewCount(MessageFunction messageFunction) 获取新信息个数
        /// <summary>
        /// 获取新信息个数，类别应该是收的信息，不是发的信息
        /// </summary>
        /// <returns>记录个数</returns>
        public int GetNewCount(MessageFunction messageFunction)
        {
            int returnValue = 0;
            string sqlQuery = " SELECT COUNT(*) "
                            + "   FROM " + BaseMessageEntity.TableName
                            + "  WHERE (" + BaseMessageEntity.FieldIsNew + " = " + ((int)MessageStateCode.New).ToString() + " ) "
                            + "        AND (" + BaseMessageEntity.FieldCategoryCode + " = 'Receiver' )"
                            + "        AND (" + BaseMessageEntity.FieldReceiverId + " = '" + UserInfo.Id + "' )"
                            + "        AND (" + BaseMessageEntity.FieldDeletionStateCode + " = 0 )"
                            + "        AND (" + BaseMessageEntity.FieldFunctionCode + " = '" + messageFunction.ToString() + "' )";
            object returnObject = DbHelper.ExecuteScalar(sqlQuery);
            if (returnObject != null)
            {
                returnValue = int.Parse(returnObject.ToString());
            }
            return returnValue;
        }
        #endregion

        #region public BaseMessageEntity GetNewOne() 获取最新一条信息
        /// <summary>
        /// 获取最新一条信息
        /// </summary>
        /// <returns>记录个数</returns>
        public BaseMessageEntity GetNewOne()
        {
            BaseMessageEntity messageEntity = new BaseMessageEntity();
            string sqlQuery = " SELECT * "
                            + "   FROM (SELECT * FROM " + BaseMessageEntity.TableName + " WHERE (" + BaseMessageEntity.FieldIsNew + " = " + ((int)MessageStateCode.New).ToString() + " ) "
                            + "         AND (" + BaseMessageEntity.FieldReceiverId + " = '" + UserInfo.Id + "') "
                            + " ORDER BY " + BaseMessageEntity.FieldCreateOn + " DESC) "
                            + " WHERE ROWNUM = 1 ";
            DataTable dataTable = DbHelper.Fill(sqlQuery);
            return messageEntity.GetSingle(dataTable);
        }
        #endregion

        #region public string[] MessageChek() 检查信息状态
        /// <summary>
        /// 检查信息状态
        /// </summary>
        /// <returns>信息状态数组</returns>
        public string[] MessageChek()
        {
            string[] returnValue = new string[6];
            // 0.新信息的个数
            int messageCount = this.GetNewCount();
            returnValue[0] = messageCount.ToString();
            if (messageCount > 0)
            {
                BaseMessageEntity messageEntity = this.GetNewOne();
                DateTime lastChekDate = DateTime.MinValue;
                if (messageEntity.CreateOn != null)
                {
                    // 1.最后检查时间
                    lastChekDate = Convert.ToDateTime(messageEntity.CreateOn);
                    returnValue[1] = lastChekDate.ToString(BaseSystemInfo.DateTimeFormat);
                }
                returnValue[2] = messageEntity.CreateUserId; // 2.最新消息的发出者
                returnValue[3] = messageEntity.CreateBy; // 3.最新消息的发出者名称
                returnValue[4] = messageEntity.Id;            // 4.最新消息的主键
                returnValue[5] = messageEntity.Contents;       // 5.最新信息的内容
            }
            return returnValue;
        }
        #endregion

        #region public DataTable Read(string id) 阅读短信
        /// <summary>
        /// 阅读短信
        /// </summary>
        /// <param name="id">短信ID</param>
        /// <returns>数据权限</returns>
        public DataTable Read(string id)
        {
            // 这里需要改进一下，运行一个高性能的sql语句就可以了，效率会高一些
            DataTable dataTable = this.GetDataTableById(id);
            BaseMessageEntity messageEntity = new BaseMessageEntity(dataTable);
            this.OnRead(messageEntity, id);
            dataTable = this.GetDataTableById(id);
            return dataTable;
        }
        #endregion

        #region private int OnRead(BaseMessageEntity messageEntity, string id) 阅读短信后设置状态值和阅读次数
        /// <summary>
        /// 阅读短信后设置状态值和阅读次数
        /// </summary>
        /// <param name="messageEntity">实体</param>
        /// <param name="id">短信主键</param>
        /// <returns>影响的条数</returns>
        private int OnRead(BaseMessageEntity messageEntity, string id)
        {
            int returnValue = 0;
            // 针对“已发送”的情况
            if (messageEntity.ReceiverId == UserInfo.Id)
            {
                // 针对“删除的信息”的情况
                if (messageEntity.IsNew == (int)MessageStateCode.New)
                {
                    SQLBuilder sqlBuilder = new SQLBuilder(this.DbHelper);
                    sqlBuilder.BeginUpdate(this.CurrentTableName);
                    sqlBuilder.SetValue(BaseMessageEntity.FieldIsNew, ((int)MessageStateCode.Old).ToString());
                    sqlBuilder.SetDBNow(BaseMessageEntity.FieldReadDate);
                    sqlBuilder.SetWhere(BaseMessageEntity.FieldId, id);
                    sqlBuilder.EndUpdate();
                }
            }
            // 增加阅读次数
            messageEntity.ReadCount++;
            this.SetProperty(id, new KeyValuePair<string, object>(BaseMessageEntity.FieldReadCount, messageEntity.ReadCount.ToString()));
            returnValue++;
            return returnValue;
        }
        #endregion

        #region public DataTable ReadFromReceiver(string receiverId) 获取当前即时聊天者的所有新信息
        /// <summary>
        /// 获取当前即时聊天者的所有新信息
        /// </summary>
        /// <param name="receiverID">目标聊天者</param>
        /// <returns>数据表</returns>
        public DataTable ReadFromReceiver(string receiverId)
        {
            // 读取发给我的信息
            string sqlQuery = this.Query
                            + " WHERE (" + BaseMessageEntity.FieldIsNew + " = " + ((int)MessageStateCode.New).ToString() + " ) "
                            + " AND (" + BaseMessageEntity.FieldReceiverId + " = '" + UserInfo.Id + "' ) "
                            + " AND (" + BaseMessageEntity.FieldCreateUserId + " = '" + receiverId + "' ) "
                            + " ORDER BY " + BaseMessageEntity.FieldSortCode;
            DataTable dataTable = DbHelper.Fill(sqlQuery);
            // 标记为已读
            string id = string.Empty;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                // 这是别人发过来的信息
                if (dataRow[BaseMessageEntity.FieldReceiverId].ToString() == UserInfo.Id)
                {
                    id = dataRow[BaseMessageEntity.FieldId].ToString();
                    this.SetProperty(id, new KeyValuePair<string, object>(BaseMessageEntity.FieldIsNew, (int)MessageStateCode.Old));
                }
            }
            return dataTable;
        }
        #endregion

        #region public DataTable GetDataTableNew() 获取我的未读短信列表
        /// <summary>
        /// 获取我的未读短信列表
        /// </summary>		
        /// <returns>数据表</returns>
        public DataTable GetDataTableNew()
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseMessageEntity.FieldReceiverId, this.UserInfo.Id));
            parameters.Add(new KeyValuePair<string, object>(BaseMessageEntity.FieldCategoryCode, "Receiver"));
            parameters.Add(new KeyValuePair<string, object>(BaseMessageEntity.FieldIsNew, (int)MessageStateCode.New));
            parameters.Add(new KeyValuePair<string, object>(BaseMessageEntity.FieldDeletionStateCode, 0));
            parameters.Add(new KeyValuePair<string, object>(BaseMessageEntity.FieldEnabled, 1));
            return this.GetDataTable(parameters, 20, BaseMessageEntity.FieldCreateUserId + "," + BaseMessageEntity.FieldCreateOn);

            /*
            string sqlQuery = "   SELECT TOP 10 * "
                            + "     FROM " + BaseMessageEntity.TableName
                            + "    WHERE " + BaseMessageEntity.FieldIsNew + " = " + ((int)MessageStateCode.New).ToString()
                            + "          AND " + BaseMessageEntity.FieldReceiverId + " = " + DbHelper.GetParameter(BaseMessageEntity.FieldReceiverId)
                            + "          AND " + BaseMessageEntity.FieldDeletionStateCode + " = 0 "
                            + "          AND " + BaseMessageEntity.FieldEnabled + " = 1 "
                            + " ORDER BY " + BaseMessageEntity.FieldCreateUserId
                            + "          ," + BaseMessageEntity.FieldCreateOn;
            DataTable dataTable = new DataTable(BaseMessageEntity.TableName);
            DbHelper.Fill(dataTable, sqlQuery, new IDbDataParameter[] { DbHelper.MakeParameter(BaseMessageEntity.FieldReceiverId, UserInfo.Id) });
            return dataTable;
            */
        }
        #endregion

        #region public DataTable SearchNewList(string searchValue) 查询我的未读短信列表
        /// <summary>
        /// 查询我的未读短信列表
        /// </summary>
        /// <param name="search">查询字符</param>
        /// <returns>数据权限</returns>
        public DataTable SearchNewList(string searchValue)
        {
            if (searchValue.Length == 0)
            {
                return this.GetDataTableNew();
            }
            DataTable dataTable = new DataTable(BaseMessageEntity.TableName);
            string sqlQuery = this.Query
                            + " WHERE ((" + BaseMessageEntity.FieldContents + " LIKE " + DbHelper.GetParameter(BaseMessageEntity.FieldContents) + " ) "
                            + " OR ( " + BaseMessageEntity.FieldTitle + " LIKE " + DbHelper.GetParameter(BaseMessageEntity.FieldReceiverId) + " ) "
                            + " OR ( " + BaseMessageEntity.FieldReceiverRealName + " LIKE " + DbHelper.GetParameter(BaseMessageEntity.FieldReceiverId) + " )) "
                            + " AND (" + BaseMessageEntity.FieldIsNew + " = " + ((int)MessageStateCode.New).ToString() + " ) "
                            + " AND (" + BaseMessageEntity.FieldReceiverId + " = " + DbHelper.GetParameter(BaseMessageEntity.FieldReceiverId) + " ) "
                            + " ORDER BY " + BaseMessageEntity.FieldSortCode;
            string[] names = new string[4];
            Object[] values = new Object[4];
            for (int i = 0; i < 3; i++)
            {
                names[i] = BaseMessageEntity.FieldContents;
                values[i] = searchValue;
            }
            names[3] = BaseMessageEntity.FieldReceiverId;
            values[3] = UserInfo.Id;
            DbHelper.Fill(dataTable, sqlQuery, DbHelper.MakeParameters(names, values));
            return dataTable;
        }
        #endregion

        #region public DataTable GetOldDT() 获取我的已读短信列表
        /// <summary>
        /// 获取我的已读短信列表
        /// </summary>		
        /// <returns>数据权限</returns>
        public DataTable GetOldDT()
        {
            DataTable dataTable = new DataTable(BaseMessageEntity.TableName);
            string sqlQuery = this.Query
                            + " WHERE (" + BaseMessageEntity.FieldIsNew + " = " + ((int)MessageStateCode.Old).ToString() + " ) "
                            + " AND (" + BaseMessageEntity.FieldReceiverId + " = " + DbHelper.GetParameter(BaseMessageEntity.FieldReceiverId) + " ) "
                            + " ORDER BY " + BaseMessageEntity.FieldSortCode;
            string[] names = new string[1];
            Object[] values = new Object[1];
            names[0] = BaseMessageEntity.FieldReceiverId;
            values[0] = UserInfo.Id;
            DbHelper.Fill(dataTable, sqlQuery, DbHelper.MakeParameters(names, values));
            return dataTable;
        }
        #endregion

        #region public DataTable SearchOldDT(string searchValue) 查询我的已读短信列表
        /// <summary>
        /// 查询我的已读短信列表
        /// </summary>
        /// <param name="search">查询字符</param>
        /// <returns>数据权限</returns>
        public DataTable SearchOldDT(string searchValue)
        {
            if (searchValue.Length == 0)
            {
                return this.GetOldDT();
            }
            DataTable dataTable = new DataTable(BaseMessageEntity.TableName);
            string sqlQuery = this.Query
                            + " WHERE ((" + BaseMessageEntity.FieldContents + " LIKE " + DbHelper.GetParameter(BaseMessageEntity.FieldContents) + " ) "
                            + " OR (" + BaseMessageEntity.FieldReceiverRealName + " LIKE " + DbHelper.GetParameter(BaseMessageEntity.FieldReceiverId) + " ) "
                            + " OR (" + BaseMessageEntity.FieldCreateOn + " LIKE " + DbHelper.GetParameter(BaseMessageEntity.FieldCreateOn) + " )) "
                            + " AND (" + BaseMessageEntity.FieldIsNew + " = " + ((int)MessageStateCode.Old).ToString() + " ) "
                            + " AND (" + BaseMessageEntity.FieldReceiverId + " = " + DbHelper.GetParameter(BaseMessageEntity.FieldReceiverId) + " ) "
                            + " ORDER BY " + BaseMessageEntity.FieldSortCode;
            string[] names = new string[4];
            Object[] values = new Object[4];
            for (int i = 0; i < 3; i++)
            {
                names[i] = BaseMessageEntity.FieldContents;
                values[i] = searchValue;
            }
            names[3] = BaseMessageEntity.FieldReceiverId;
            values[3] = UserInfo.Id;
            DbHelper.Fill(dataTable, sqlQuery, DbHelper.MakeParameters(names, values));
            return dataTable;
        }
        #endregion

        #region public DataTable GetDataTableByFunction(string categoryId, string functionId, string userId) 按消息功能获取消息列表
        /// <summary>
        /// 按消息功能获取消息列表
        /// </summary>
        /// <param name="categoryCode">消息分类</param>
        /// <param name="functionCode">消息功能</param>
        /// <param name="userId">用户主键</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByFunction(string categoryCode, string functionCode, string userId)
        {
            string sqlQuery = this.Query
                            + "    WHERE (" + BaseMessageEntity.FieldDeletionStateCode + " = 0 ) "
                            + "          AND (" + BaseMessageEntity.FieldCategoryCode + " = '" + categoryCode + "') ";
            if (!String.IsNullOrEmpty(functionCode))
            {
                sqlQuery += "          AND (" + BaseMessageEntity.FieldFunctionCode + " = '" + functionCode + "' ) ";
            }
            if (categoryCode.Equals(MessageCategory.Send.ToString()))
            {
                // 已经发送出去的信息
                sqlQuery += "          AND (" + BaseMessageEntity.FieldCreateUserId + " = " + DbHelper.GetParameter(BaseMessageEntity.FieldReceiverId) + ") ";
            }
            else
            {
                // 已收到的信息
                sqlQuery += "          AND (" + BaseMessageEntity.FieldReceiverId + " = " + DbHelper.GetParameter(BaseMessageEntity.FieldReceiverId) + ") ";
            }

            sqlQuery += " ORDER BY " + BaseMessageEntity.FieldIsNew + " DESC "
                     + "          ," + BaseMessageEntity.FieldCreateOn;
            DataTable dataTable = new DataTable(BaseMessageEntity.TableName);
            DbHelper.Fill(dataTable, sqlQuery, new IDbDataParameter[] { DbHelper.MakeParameter(BaseMessageEntity.FieldReceiverId, userId) });
            return dataTable;
        }
        #endregion

        public DataTable GetReceiveDT()
        {
            return this.GetDataTableByFunction(MessageCategory.Receiver.ToString(), MessageFunction.Message.ToString(), UserInfo.Id);
        }

        public DataTable SearchReceiveDT(string searchValue)
        {
            if (searchValue.Length == 0)
            {
                return this.GetReceiveDT();
            }
            searchValue = StringUtil.GetSearchString(searchValue);

            string sqlQuery = this.Query
                            + "    WHERE (" + BaseMessageEntity.FieldDeletionStateCode + " = 0 ) "
                            + "          AND (" + BaseMessageEntity.FieldCategoryCode + " = '" + MessageCategory.Receiver.ToString() + "') ";
            sqlQuery += "          AND (" + BaseMessageEntity.FieldFunctionCode + " = '" + MessageFunction.Message.ToString() + "' ) ";
            // 已收到的信息
            sqlQuery += "          AND (" + BaseMessageEntity.FieldReceiverId + " = " + DbHelper.GetParameter(BaseMessageEntity.FieldReceiverId) + ") ";

            sqlQuery += " AND ((" + BaseMessageEntity.FieldTitle + " LIKE " + DbHelper.GetParameter(BaseMessageEntity.FieldTitle) + " ) "
                      + " OR (" + BaseMessageEntity.FieldContents + " LIKE " + DbHelper.GetParameter(BaseMessageEntity.FieldContents) + " ) "
                      + " OR (" + BaseMessageEntity.FieldCreateBy + " LIKE " + DbHelper.GetParameter(BaseMessageEntity.FieldCreateBy) + " )) ";


            sqlQuery += " ORDER BY " + BaseMessageEntity.FieldIsNew + " DESC "
                     + "          ," + BaseMessageEntity.FieldCreateOn + " DESC "
                     + "          ," + BaseMessageEntity.FieldCreateUserId;
            DataTable dataTable = new DataTable(BaseMessageEntity.TableName);

            string[] names = new string[4];
            Object[] values = new Object[4];
            names[0] = BaseMessageEntity.FieldReceiverId;
            values[0] = UserInfo.Id;
            names[1] = BaseMessageEntity.FieldTitle;
            values[1] = searchValue;
            names[2] = BaseMessageEntity.FieldContents;
            values[2] = searchValue;
            names[3] = BaseMessageEntity.FieldCreateBy;
            values[3] = UserInfo.Id;
            DbHelper.Fill(dataTable, sqlQuery, DbHelper.MakeParameters(names, values));
            return dataTable;
        }

        public DataTable GetWarningDT()
        {
            return this.GetDataTableByFunction(MessageCategory.Receiver.ToString(), MessageFunction.Warning.ToString(), UserInfo.Id);
        }

        public DataTable GetWarningDT(string userId)
        {
            return this.GetDataTableByFunction(MessageCategory.Receiver.ToString(), MessageFunction.Warning.ToString(), userId);
        }

        public DataTable GetWarningDT(string userId, int topN)
        {
            return this.SearchWarningDT(string.Empty, userId, topN);
        }

        public DataTable SearchWarningDT(string searchValue)
        {
            return this.SearchWarningDT(searchValue, UserInfo.Id);
        }

        public DataTable SearchWarningDT(string search, string userId)
        {
            return SearchWarningDT(search, userId, 0);
        }

        public DataTable SearchWarningDT(string search, string userId, int topN)
        {
            if (search.Length == 0 && topN == 0)
            {
                return this.GetWarningDT();
            }
            search = StringUtil.GetSearchString(search);

            string sqlQuery = " SELECT ";
            if (topN != 0)
            {
                sqlQuery += " TOP " + topN.ToString();
            }
            sqlQuery += " * FROM " + BaseMessageEntity.TableName

                            + "    WHERE (" + BaseMessageEntity.FieldDeletionStateCode + " = 0 ) "
                            + "          AND (" + BaseMessageEntity.FieldCategoryCode + " = '" + MessageCategory.Receiver.ToString() + "') ";
            sqlQuery += "          AND (" + BaseMessageEntity.FieldFunctionCode + " = '" + MessageFunction.Warning.ToString() + "' ) ";
            // 已收到的信息
            sqlQuery += "          AND (" + BaseMessageEntity.FieldReceiverId + " = " + DbHelper.GetParameter(BaseMessageEntity.FieldReceiverId) + ") ";

            List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();
            dbParameters.Add(DbHelper.MakeParameter(BaseMessageEntity.FieldReceiverId, userId));

            if (!String.IsNullOrEmpty(search))
            {
                sqlQuery += " AND ((" + BaseMessageEntity.FieldTitle + " LIKE " + DbHelper.GetParameter(BaseMessageEntity.FieldTitle) + " ) "
                          + " OR (" + BaseMessageEntity.FieldContents + " LIKE " + DbHelper.GetParameter(BaseMessageEntity.FieldContents) + " ) "
                          + " OR (" + BaseMessageEntity.FieldCreateBy + " LIKE " + DbHelper.GetParameter(BaseMessageEntity.FieldCreateBy) + " )) ";

                dbParameters.Add(DbHelper.MakeParameter(BaseMessageEntity.FieldTitle, search));
                dbParameters.Add(DbHelper.MakeParameter(BaseMessageEntity.FieldContents, search));
                dbParameters.Add(DbHelper.MakeParameter(BaseMessageEntity.FieldCreateBy, search));
            }

            sqlQuery += " ORDER BY " + BaseMessageEntity.FieldIsNew + " DESC "
                     + "          ," + BaseMessageEntity.FieldCreateOn + " DESC ";
            DataTable dataTable = new DataTable(BaseMessageEntity.TableName);

            DbHelper.Fill(dataTable, sqlQuery, dbParameters.ToArray());
            return dataTable;
        }

        #region public DataTable GetSendDT() 获取我的已发送短信列表
        /// <summary>
        /// 获取我的已发送短信列表
        /// </summary>		
        /// <returns>数据权限</returns>
        public DataTable GetSendDT()
        {
            string sqlQuery = this.Query
                            + " WHERE (" + BaseMessageEntity.FieldCategoryCode + " = '" + (MessageCategory.Send).ToString() + "') "
                            + " AND (" + BaseMessageEntity.FieldDeletionStateCode + " = 0) "
                            + " AND (" + BaseMessageEntity.FieldCreateUserId + " = '" + UserInfo.Id + "') "
                            + " ORDER BY " + BaseMessageEntity.FieldSortCode;
            return DbHelper.Fill(sqlQuery);
        }
        #endregion

        #region public DataTable SearchSendDT(string searchValue) 查询我的已发送短信列表
        /// <summary>
        /// 查询我的已发送短信列表
        /// </summary>
        /// <param name="search">查询字符</param>
        /// <returns>数据权限</returns>
        public DataTable SearchSendDT(string searchValue)
        {
            if (searchValue.Length == 0)
            {
                return this.GetSendDT();
            }
            searchValue = StringUtil.GetSearchString(searchValue);
            DataTable dataTable = new DataTable(BaseMessageEntity.TableName);
            string sqlQuery = this.Query
                            + " WHERE ((" + BaseMessageEntity.FieldContents + " LIKE " + DbHelper.GetParameter(BaseMessageEntity.FieldContents) + " ) "
                            + " OR (" + BaseMessageEntity.FieldReceiverRealName + " LIKE " + DbHelper.GetParameter(BaseMessageEntity.FieldReceiverRealName) + " ) "
                            + " OR (" + BaseMessageEntity.FieldCreateOn + " LIKE " + DbHelper.GetParameter(BaseMessageEntity.FieldCreateOn) + " )) "
                            + " AND (" + BaseMessageEntity.FieldDeletionStateCode + " = 0) "
                            + " AND (" + BaseMessageEntity.FieldCategoryCode + " = '" + (MessageCategory.Send).ToString() + "') "
                            + " AND (" + BaseMessageEntity.FieldCreateUserId + " = " + DbHelper.GetParameter(BaseMessageEntity.FieldCreateUserId) + " ) "
                            + " ORDER BY " + BaseMessageEntity.FieldSortCode;
            string[] names = new string[4];
            Object[] values = new Object[4];
            names[0] = BaseMessageEntity.FieldContents;
            values[0] = searchValue;
            names[1] = BaseMessageEntity.FieldReceiverRealName;
            values[1] = searchValue;
            names[2] = BaseMessageEntity.FieldCreateOn;
            values[2] = searchValue;
            names[3] = BaseMessageEntity.FieldCreateUserId;
            values[3] = UserInfo.Id;
            DbHelper.Fill(dataTable, sqlQuery, DbHelper.MakeParameters(names, values));
            return dataTable;
        }
        #endregion

        #region public DataTable GetDeletedDT() 获取我的删除的短信列表
        /// <summary>
        /// 获取我的删除的短信列表
        /// </summary>		
        /// <returns>数据权限</returns>
        public DataTable GetDeletedDT()
        {
            DataTable dataTable = new DataTable(BaseMessageEntity.TableName);
            string sqlQuery = this.Query
                            + " WHERE (" + BaseMessageEntity.FieldDeletionStateCode + " = 1 ) "
                            + " AND (" + BaseMessageEntity.FieldReceiverId + " = " + DbHelper.GetParameter(BaseMessageEntity.FieldReceiverId) + " ) "
                            + " ORDER BY " + BaseMessageEntity.FieldSortCode;
            DbHelper.Fill(dataTable, sqlQuery, new IDbDataParameter[] { DbHelper.MakeParameter(BaseMessageEntity.FieldReceiverId, UserInfo.Id) });
            return dataTable;
        }
        #endregion

        #region public DataTable SearchDeletedDT(string searchValue) 查询我的已删除短信列表
        /// <summary>
        /// 查询我的已删除短信列表
        /// </summary>
        /// <param name="search">查询字符</param>
        /// <returns>数据权限</returns>
        public DataTable SearchDeletedDT(string searchValue)
        {
            if (searchValue.Length == 0)
            {
                return this.GetDeletedDT();
            }
            DataTable dataTable = new DataTable(BaseMessageEntity.TableName);
            string sqlQuery = this.Query
                            + " WHERE ((" + BaseMessageEntity.FieldContents + " LIKE ? ) "
                            + " OR ( " + BaseMessageEntity.FieldReceiverRealName + " LIKE ? ) "
                            + " OR (" + BaseMessageEntity.FieldCreateOn + " LIKE ? )) "
                            + " AND (" + BaseMessageEntity.FieldDeletionStateCode + " = 1 ) "
                            + " AND (" + BaseMessageEntity.FieldReceiverId + " = ? ) "
                            + " ORDER BY " + BaseMessageEntity.FieldSortCode;
            string[] names = new string[4];
            Object[] values = new Object[4];
            for (int i = 0; i < 3; i++)
            {
                names[i] = BaseMessageEntity.FieldContents;
                values[i] = searchValue;
            }
            names[3] = BaseMessageEntity.FieldReceiverId;
            values[3] = UserInfo.Id;
            DbHelper.Fill(dataTable, sqlQuery, DbHelper.MakeParameters(names, values));
            return dataTable;
        }
        #endregion
    }
}