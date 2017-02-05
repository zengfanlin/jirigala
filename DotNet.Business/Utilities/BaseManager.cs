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
    ///	BaseManager
    /// 通用基类部分
    /// 
    /// 总觉得自己写的程序不上档次，这些新技术也玩玩，也许做出来的东西更专业了。
    /// 修改纪录
    /// 
    ///		2012.02.04 版本：1.5 JiRiGaLa 文件进行分割，简化处理。
    ///		2010.06.23 版本：1.4 JiRiGaLa 删除简化了一些重复的函数功能。
    ///		2007.11.22 版本：1.3 JiRiGaLa 创建没有BaseSystemInfo的构造函数。
    ///		2007.11.20 版本：1.2 JiRiGaLa 完善有数据库连接、当前用户信息的构造函数、增加NonSerialized。
    ///		2007.11.15 版本：1.1 JiRiGaLa 设置 SetParameter 函数功能。
    ///		2007.08.01 版本：1.0 JiRiGaLa 提炼了最基础的方法部分、觉得这些是很有必要的方法。
    ///
    /// 版本：1.5
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.02.04</date>
    /// </author> 
    /// </summary>
    public abstract partial class BaseManager : IBaseManager
    {
        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="organizeEntity">实体</param>
        // public void SetEntityExpand(SQLBuilder sqlBuilder);

        /// <summary>
        /// 数据表主键，需要用单一字段做为主键，建议默认为Id字段
        /// </summary>
        public string PrimaryKey = "Id";

        /// <summary>
        /// 是否自增量？大并发数据主键生成需要用这个方法
        /// 不是所有的情况下，都是在进行插入操作的，也不都是有Id字段的
        /// </summary>
        public bool Identity = true;

        /// <summary>
        /// 插入数据时，是否需要返回主键
        /// 默认都是需要插入操作时都要返回主键的
        /// </summary>
        public bool ReturnId = true;

        /// <summary>
        /// 当前控制的表名
        /// </summary>
        public string CurrentTableName { get; set; }

        private static object locker = new Object();

        protected IDbHelper dbHelper = null;
        /// <summary>
        /// 当前的数据库连接
        /// </summary>
        public IDbHelper DbHelper
        {
            set
            {
                dbHelper = value;
            }
            get
            {
                if (dbHelper == null)
                {
                    lock (locker)
                    {
                        if (dbHelper == null)
                        {
                            dbHelper = DbHelperFactory.GetHelper();
                            // 是自动打开关闭数据库状态
                            dbHelper.AutoOpenClose = true;
                        }
                    }
                }
                return dbHelper;
            }
        }

        protected BaseUserInfo UserInfo = null;

        public BaseManager()
        {
        }

        public BaseManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        public BaseManager(IDbHelper dbHelper, BaseUserInfo userInfo)
            : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        public BaseManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            CurrentTableName = tableName;
        }

        /// <summary>
        /// 设置数据库连接
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public void SetConnection(IDbHelper dbHelper)
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 设置当前用户
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        public void SetConnection(BaseUserInfo userInfo)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 设置数据库连接、当前用户
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">当前用户</param>
        public void SetConnection(IDbHelper dbHelper, BaseUserInfo userInfo)
        {
            this.SetConnection(dbHelper);
            UserInfo = userInfo;
        }

        public virtual void SetParameter(IDbHelper dbHelper)
        {
            DbHelper = dbHelper;
        }

        public virtual void SetParameter(BaseUserInfo userInfo)
        {
            UserInfo = userInfo;
        }

        public virtual void SetParameter(IDbHelper dbHelper, BaseUserInfo userInfo)
        {
            DbHelper = dbHelper;
            UserInfo = userInfo;
        }

        //
        // 类对应的数据库最终操作
        //
        public virtual string AddEntity(object entity)
        {
            return string.Empty;
        }

        public virtual int UpdateEntity(object entity)
        {
            return 0;
        }

        public virtual int DeleteEntity(object id)
        {
            return DeleteEntity(new KeyValuePair<string, object>(BaseBusinessLogic.FieldId, id));
        }

        public virtual int DeleteEntity(params KeyValuePair<string, object>[] parameters)
        {
            List<KeyValuePair<string, object>> parametersList = new List<KeyValuePair<string, object>>();
            for (int i = 0; i < parameters.Length; i++)
            {
                parametersList.Add(parameters[i]);
            }
            return DbLogic.Delete(DbHelper, this.CurrentTableName, parametersList);
        }

        //
        // 对象事件触发器（编写程序的人员，可以不实现这些方法）
        //
        public virtual bool AddBefore()
        {
            // 这个函数需要覆盖
            return true;
        }

        public virtual bool AddAfter()
        {
            // 这个函数需要覆盖
            return true;
        }

        public virtual bool UpdateBefore()
        {
            // 这个函数需要覆盖
            return true;
        }

        public virtual bool UpdateAfter()
        {
            // 这个函数需要覆盖
            return true;
        }

        public virtual bool GetBefore(string id)
        {
            // 这个函数需要覆盖
            return true;
        }

        public virtual bool GetAfter(string id)
        {
            // 这个函数需要覆盖
            return true;
        }

        public virtual bool DeleteBefore(string id)
        {
            // 这个函数需要覆盖
            return true;
        }
        public virtual bool DeleteAfter(string id)
        {
            // 这个函数需要覆盖
            return true;
        }

        //
        // 批量操作保存
        //
        public virtual int BatchSave(DataTable dataTable)
        {
            return 0;
        }

        //
        // 状态码的获取
        //

        private string returnStatusCode = StatusCode.Error.ToString();
        /// <summary>
        /// 运行状态返回值
        /// </summary>
        public string ReturnStatusCode
        {
            get
            {
                return this.returnStatusCode;
            }
            set
            {
                this.returnStatusCode = value;
            }
        }

        private string returnStatusMessage = string.Empty;
        /// <summary>
        /// 运行状态的信息
        /// </summary>
        public string ReturnStatusMessage
        {
            get
            {
                return this.returnStatusMessage;
            }
            set
            {
                this.returnStatusMessage = value;
            }
        }

        public string GetStateMessage()
        {
            return this.GetStateMessage(this.ReturnStatusCode);
        }

        public string GetStateMessage(string statusCode)
        {
            if (String.IsNullOrEmpty(statusCode))
            {
                return string.Empty;
            }
            StatusCode status = (StatusCode)Enum.Parse(typeof(StatusCode), statusCode, true);
            return this.GetStateMessage(status);
        }

        #region public string GetStateMessage(StatusCode statusCode) 获得状态的信息
        /// <summary>
        /// 获得状态的信息
        /// </summary>
        /// <param name="statusCode">程序运行状态</param>
        /// <returns>返回信息</returns>
        public string GetStateMessage(StatusCode statusCode)
        {
            string returnValue = string.Empty;
            switch (statusCode)
            {
                case StatusCode.DbError:
                    returnValue = AppMessage.MSG0002;
                    break;
                case StatusCode.Error:
                    returnValue = AppMessage.MSG0001;
                    break;
                case StatusCode.OK:
                    returnValue = AppMessage.MSG9965;
                    break;
                case StatusCode.UserNotFound:
                    returnValue = AppMessage.MSG9966;
                    break;
                case StatusCode.PasswordError:
                    returnValue = AppMessage.MSG9967;
                    break;
                case StatusCode.LogOnDeny:
                    returnValue = AppMessage.MSG9968;
                    break;
                case StatusCode.ErrorOnLine:
                    returnValue = AppMessage.MSG0048;
                    break;
                case StatusCode.ErrorMacAddress:
                    returnValue = AppMessage.MSG0049;
                    break;
                case StatusCode.ErrorIPAddress:
                    returnValue = AppMessage.MSG0050;
                    break;
                case StatusCode.ErrorOnLineLimit:
                    returnValue = AppMessage.MSG0051;
                    break;
                case StatusCode.PasswordCanNotBeNull:
                    returnValue = AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9961);
                    break;
                case StatusCode.PasswordCanNotBeRepeat:
                    returnValue = AppMessage.Format(AppMessage.MSG0102);
                    break;
                case StatusCode.ErrorDeleted:
                    returnValue = AppMessage.MSG0005;
                    break;
                case StatusCode.SetPasswordOK:
                    returnValue = AppMessage.Format(AppMessage.MSG9963, AppMessage.MSG9964);
                    break;
                case StatusCode.OldPasswordError:
                    returnValue = AppMessage.Format(AppMessage.MSG0040, AppMessage.MSG9961);
                    break;
                case StatusCode.ChangePasswordOK:
                    returnValue = AppMessage.Format(AppMessage.MSG9962, AppMessage.MSG9964);
                    break;
                case StatusCode.OKAdd:
                    returnValue = AppMessage.MSG0009;
                    break;
                case StatusCode.CanNotLock:
                    returnValue = AppMessage.MSG0043;
                    break;
                case StatusCode.LockOK:
                    returnValue = AppMessage.MSG0044;
                    break;
                case StatusCode.OKUpdate:
                    returnValue = AppMessage.MSG0010;
                    break;
                case StatusCode.OKDelete:
                    returnValue = AppMessage.MSG0013;
                    break;
                case StatusCode.Exist:
                    // "编号已存在,不可以重复."
                    returnValue = AppMessage.Format(AppMessage.MSG0008, AppMessage.MSG9955);
                    break;
                case StatusCode.ErrorCodeExist:
                    // "编号已存在,不可以重复."
                    returnValue = AppMessage.Format(AppMessage.MSG0008, AppMessage.MSG9977);
                    break;
                case StatusCode.ErrorNameExist:
                    // "名称已存在,不可以重复."
                    returnValue = AppMessage.Format(AppMessage.MSG0008, AppMessage.MSG9978);
                    break;
                case StatusCode.ErrorValueExist:
                    // "值已存在,不可以重复."
                    returnValue = AppMessage.Format(AppMessage.MSG0008, AppMessage.MSG9800);
                    break;
                case StatusCode.ErrorUserExist:
                    // "用户名已存在,不可以重复."
                    returnValue = AppMessage.Format(AppMessage.MSG0008, AppMessage.MSG9957);
                    break;
                case StatusCode.ErrorDataRelated:
                    returnValue = AppMessage.MSG0033;
                    break;
                case StatusCode.ErrorChanged:
                    returnValue = AppMessage.MSG0006;
                    break;

                case StatusCode.UserNotEmail:
                    returnValue = AppMessage.MSG9910;
                    break;

                case StatusCode.UserLocked:
                    returnValue = AppMessage.MSG9911;
                    break;

                case StatusCode.WaitForAudit:
                case StatusCode.UserNotActive:
                    returnValue = AppMessage.MSG9912;
                    break;

                case StatusCode.UserIsActivate:
                    returnValue = AppMessage.MSG9913;
                    break;

                case StatusCode.NotFound:
                    returnValue = AppMessage.MSG9956;
                    break;

                case StatusCode.ErrorLogOn:
                    returnValue = AppMessage.MSG9000;
                    break;

                case StatusCode.UserDuplicate:
                    returnValue = AppMessage.Format(AppMessage.MSG0008, AppMessage.MSG9957);
                    break;

                //// 开始审核
                //case AuditStatus.StartAudit:
                //    returnValue = AppMessage.MSG0009;
                //    break;
                //// 审核通过
                //case AuditStatus.AuditPass:
                //    returnValue = AppMessage.MSG0009;
                //    break;
                //// 待审核
                //case AuditStatus.WaitForAudit:
                //    returnValue = AppMessage.MSG0010;
                //    break;
                //// 审核退回
                //case AuditStatus.AuditReject:
                //    returnValue = AppMessage.MSG0009;
                //    break;
                //// 审核结束
                //case AuditStatus.AuditComplete:
                //    returnValue = AppMessage.MSG0010;
                //    break;
                //// 提交成功。
                //case AuditStatus.SubmitOK:
                //    returnValue = AppMessage.MSG0009;
                //    break;
            }
            return returnValue;
        }
        #endregion

        #region public int BatchSetCode(string[] ids, string[] codes) 重置编号
        /// <summary>
        /// 重置编号
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <param name="codes">编号数组</param>
        /// <returns>影响行数</returns>
        public int BatchSetCode(string[] ids, string[] codes)
        {
            int returnValue = 0;
            for (int i = 0; i < ids.Length; i++)
            {
                returnValue += this.SetProperty(ids[i], new KeyValuePair<string, object>(BaseBusinessLogic.FieldCode, codes[i]));
            }
            return returnValue;
        }
        #endregion

        ///
        /// 重新生成排序码
        ///

        #region public int BatchSetSortCode(string[] ids) 重置排序码
        /// <summary>
        /// 重置排序码
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int BatchSetSortCode(string[] ids)
        {
            int returnValue = 0;
            BaseSequenceManager sequenceManager = new BaseSequenceManager(dbHelper);
            string[] sortCodes = sequenceManager.GetBatchSequence(this.CurrentTableName, ids.Length);
            for (int i = 0; i < ids.Length; i++)
            {
                returnValue += this.SetProperty(ids[i], new KeyValuePair<string, object>(BaseBusinessLogic.FieldSortCode, sortCodes[i]));
            }
            return returnValue;
        }
        #endregion

        #region public virtual int ResetSortCode() 重新设置表的排序码
        /// <summary>
        /// 重新设置表的排序码
        /// </summary>
        /// <returns>影响行数</returns>
        public virtual int ResetSortCode()
        {
            int returnValue = 0;
            DataTable dataTable = this.GetDataTable(BaseBusinessLogic.FieldSortCode);
            BaseSequenceManager sequenceManager = new BaseSequenceManager(dbHelper);
            string[] sortCode = sequenceManager.GetBatchSequence(this.CurrentTableName, dataTable.Rows.Count);
            int i = 0;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                returnValue += this.SetProperty(dataRow[BaseBusinessLogic.FieldId].ToString(), new KeyValuePair<string, object>(BaseBusinessLogic.FieldSortCode, sortCode[i]));
                i++;
            }
            return returnValue;
        }
        #endregion

        #region public virtual int ChangeEnabled(object id) 变更有效状态
        /// <summary>
        /// 变更有效状态
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public virtual int ChangeEnabled(object id)
        {
            int returnValue = 0;
            string sqlQuery = " UPDATE " + this.CurrentTableName
                            + " SET " + BaseBusinessLogic.FieldEnabled + " = (CASE " + BaseBusinessLogic.FieldEnabled + " WHEN 0 THEN 1 WHEN 1 THEN 0 END) "
                            + " WHERE (" + BaseBusinessLogic.FieldId + " = " + DbHelper.GetParameter(BaseBusinessLogic.FieldId) + ")";
            string[] names = new string[1];
            Object[] values = new Object[1];
            names[0] = BaseBusinessLogic.FieldId;
            values[0] = id;
            returnValue = DbHelper.ExecuteNonQuery(sqlQuery, DbHelper.MakeParameters(names, values));
            return returnValue;
        }
        #endregion
    }
}