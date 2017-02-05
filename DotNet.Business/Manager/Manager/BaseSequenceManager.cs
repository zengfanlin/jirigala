//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Diagnostics;

namespace DotNet.Business
{
    using DotNet.Utilities;

	/// <summary>
   /// 序列产生器
    /// BaseSequenceManager
	/// 
	/// 核心思想:
	/// 当前读取到的就是是最新的,每次读取后进行了更新
	/// 考虑到处理的简单方便以及新能的提高,可以采用多线程技术
	/// 
	/// 修改纪录
	/// 
    ///		2010.07.04 版本：3.2 JiRiGaLa	用代码批量生成器产生序列生成器代码，规范化代码，用锁的机制防止B/S并发问题。
    ///		2010.06.03 版本：3.1 JiRiGaLa	去掉单实例的做法、防止并发问题发生。
    ///		2010.01.25 版本：3.0 JiRiGaLa	序号生成算法优化。
    ///		2008.09.09 版本：2.0 JiRiGaLa	主键整理。
	///		2007.07.20 版本：1.9 JiRiGaLa	序列产生器，增加锁机制，并整理优化主键。
	///		2006.02.07 版本：1.8 JiRiGaLa	重新调整主键的规范化。
	///		2005.10.06 版本：1.7 JiRiGaLa	添加是否补充0位的属性。	
    ///		2005.08.08 版本：1.6 JiRiGaLa	命名方式等进行改进。
    ///		2005.07.15 版本：1.5 JiRiGaLa	主键格式进行改进。
    ///		2004.07.21 版本：1.4 JiRiGaLa	改进了主键的编排、参数名称规范化。
    ///		2004.06.29 版本：1.3 JiRiGaLa	将思路重新整理完整,把最得意的程序改进到更上一层楼。
    ///		2004.06.15 版本：1.2 JiRiGaLa	查询当前序号的优化，若找不到表自动添加一笔。
    ///		2004.02.22 版本：1.1 JiRiGaLa	表字段名字进行了修改,一些继承属性也进行了修改。
    ///		2003.10.16 版本：1.0 JiRiGaLa	改进成以后可以扩展到多种数据库的结构形式。
    ///		 
	/// 版本：2.0
	///
	/// <author>
	///		<name>JiRiGaLa</name>
    ///		<date>2010.01.25</date>
	/// </author> 
	/// </summary>
    public partial class BaseSequenceManager : BaseManager, IBaseManager
    {
        public bool     FillZeroPrefix          = true;     // 是否前缀补零
        public int      DefaultSequence         = 10000000; // 默认升序序列号
        public int      DefaultReduction       = 09999999; // 默认降序序列号
        public string   DefaultPrefix           = "";       // 默认的前缀
        public string   DefaultSeparator         = "";       // 默认分隔符
        public int      DefaultStep             = 1;        // 递增或者递减数步调
        public int      DefaultSequenceLength   = 8;        // 默认的排序码长度
        public int      SequenceLength          = 8;        // 序列长度
        public bool     UsePrefix               = true;     // 是否采用前缀，补充0方式
		public int      DefaultIsVisable   = 1;        // 默认的可见性

        private static readonly object SequenceLock = new object();

        public BaseSequenceManager(IDbHelper dbHelper, bool identity) : this()
        {
            this.DbHelper = dbHelper;
            this.Identity = identity;
        }

        /// <summary>
        /// 按名称获取实体
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <returns>实体</returns>
        BaseSequenceEntity GetEntityByName(string fullName)
        {
            BaseSequenceEntity sequenceEntity = null;
            DataTable dataTable = this.GetDataTable(new KeyValuePair<string, object>(BaseSequenceEntity.FieldFullName, fullName));
            if (dataTable.Rows.Count > 0)
            {
                sequenceEntity = new BaseSequenceEntity(dataTable);
            }
            return sequenceEntity;
        }

        /// <summary>
        /// 获取添加
        /// </summary>
        /// <param name="fullName">序列名</param>
        /// <param name="defaultSequence">序列</param>
        /// <param name="defaultReduction">降序序列</param>
        /// <returns>序列实体</returns>
        BaseSequenceEntity GetEntityByAdd(string fullName)
        {
            BaseSequenceEntity sequenceEntity = null;            
            sequenceEntity = this.GetEntityByName(fullName);
            if (sequenceEntity == null)
            {
                sequenceEntity = new BaseSequenceEntity();
                // 这里是为了多种数据库的兼容
                sequenceEntity.Id = BaseBusinessLogic.NewGuid();
                sequenceEntity.FullName = fullName;
                sequenceEntity.Sequence = this.DefaultSequence;
                sequenceEntity.Reduction = this.DefaultReduction;
                sequenceEntity.Step = DefaultStep;
                sequenceEntity.Prefix = DefaultPrefix;
                sequenceEntity.Separator = DefaultSeparator;
				sequenceEntity.IsVisible = DefaultIsVisable;
                this.Add(sequenceEntity);
            }

            return sequenceEntity;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sequenceEntity">实体</param>
        public string Add(BaseSequenceEntity sequenceEntity, out string statusCode)
        {
            string returnValue = string.Empty;
            // 检查是否重复
            if (this.Exists(new KeyValuePair<string, object>(BaseSequenceEntity.FieldFullName, sequenceEntity.FullName)))
            {
                // 名称已重复
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                returnValue = this.AddEntity(sequenceEntity);
                // 运行成功
                statusCode = StatusCode.OKAdd.ToString();
            }
            return returnValue;
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="businessCardEntity">实体</param>
        public int Update(BaseSequenceEntity sequenceEntity, out string statusCode)
        {
            int returnValue = 0;
            // 检查名称是否重复
            if (this.Exists(new KeyValuePair<string, object>(BaseSequenceEntity.FieldFullName, sequenceEntity.FullName), sequenceEntity.Id))
            {
                // 名称已重复
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                // 进行更新操作
                returnValue = this.UpdateEntity(sequenceEntity);
                if (returnValue == 1)
                {
                    statusCode = StatusCode.OKUpdate.ToString();
                }
                else
                {
                    // 数据可能被删除
                    statusCode = StatusCode.ErrorDeleted.ToString();
                }
            }
            return returnValue;
        }


        //
        // 读取序列的
        //


        /// <summary>
        /// 获取序列
        /// </summary>
        /// <param name="sequenceEntity">序列实体</param>
        /// <returns>序列</returns>
        string GetSequence(BaseSequenceEntity sequenceEntity)
        {
            string sequence = sequenceEntity.Sequence.ToString();
            if (this.FillZeroPrefix)
            {
                sequence = StringUtil.RepeatString("0", (this.SequenceLength - sequenceEntity.Sequence.ToString().Length)) + sequenceEntity.Sequence.ToString();
            }
            if (this.UsePrefix)
            {
                sequence = sequenceEntity.Prefix + sequenceEntity.Separator + sequence;
            }
            return sequence;
        }

        /// <summary>
        /// 获取降序列
        /// </summary>
        /// <param name="sequenceEntity">序列实体</param>
        /// <returns>降序列</returns>
        string GetReduction(BaseSequenceEntity sequenceEntity)
        {
            string reduction = sequenceEntity.Reduction.ToString();
            if (this.FillZeroPrefix)
            {
                reduction = StringUtil.RepeatString("0", (this.SequenceLength - sequenceEntity.Reduction.ToString().Length)) + sequenceEntity.Reduction.ToString();
            }
            if (this.UsePrefix)
            {
                reduction = sequenceEntity.Prefix + sequenceEntity.Separator + reduction;
            }
            return reduction;
        }
        

        //
        // 一 获取序列原值(没有序列时，涉及到并发问题、锁机制)
        //


        #region public string GetOldSequence(string fullName) 获得原序列号
        /// <summary>
        /// 获得原序列号
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="fullName">序列名称</param>
        /// <returns>序列号</returns>
        public string GetOldSequence(string fullName)
        {
            return this.GetOldSequence(fullName, this.DefaultSequence, this.DefaultSequenceLength, this.FillZeroPrefix);
        }
        #endregion

        #region public string GetOldSequence(string fullName, int defaultSequence) 获得原序列号
        /// <summary>
        /// 获得原序列号
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <param name="defaultSequence">默认序列</param>
        /// <returns>序列号</returns>
        public string GetOldSequence(string fullName, int defaultSequence)
        {
            return this.GetOldSequence(fullName, defaultSequence, this.DefaultSequenceLength, this.FillZeroPrefix);
        }
        #endregion

        #region public string GetOldSequence(string fullName, int defaultSequence, int sequenceLength) 获得原序列号
        /// <summary>
        /// 获得原序列
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <param name="defaultSequence">默认序列</param>
        /// <param name="sequenceLength">序列长度</param>
        /// <returns>序列号</returns>
        public string GetOldSequence(string fullName, int defaultSequence, int sequenceLength)
        {
            return this.GetOldSequence(fullName, defaultSequence, sequenceLength, false);
        }
        #endregion

        #region public string GetOldSequence(string fullName, int defaultSequence, int sequenceLength, bool fillZeroPrefix) 获取序原列号
        /// <summary>
        /// 获得原序列号
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <param name="defaultSequence">默认序列</param>
        /// <param name="sequenceLength">序列长度</param>
        /// <param name="fillZeroPrefix">是否填充补零</param>
        /// <returns>序列号</returns>
        public string GetOldSequence(string fullName, int defaultSequence, int sequenceLength, bool fillZeroPrefix)
        {
            string sequence = string.Empty;
            // 这里用锁的机制，提高并发控制能力
            lock (SequenceLock)
            {
                this.SequenceLength = sequenceLength;
                this.FillZeroPrefix = fillZeroPrefix;
                this.DefaultReduction = defaultSequence;
                this.DefaultSequence = defaultSequence + 1;

                BaseSequenceEntity sequenceEntity = GetEntityByAdd(fullName);
                sequence = GetSequence(sequenceEntity);
            }
            return sequence;
        }
        #endregion



        //
        // 三 获取新序列(没有序列时，涉及到并发问题、锁机制，更新序列时会有锁机制)
        //

        public string GetOracleSequence(string fullName)
        {
            // 当前是自增量，并且是Oracle数据库
            return DbHelper.ExecuteScalar("SELECT SEQ_" + fullName.ToUpper() + ".NEXTVAL FROM DUAL ").ToString();
        }

        public string GetDB2Sequence(string fullName)
        {
            // 当前是自增量，并且是DB2数据库
            return DbHelper.ExecuteScalar("SELECT NEXTVAL FOR SEQ_" + fullName.ToUpper() + " FROM sysibm.sysdummy1").ToString();
        }

        #region public string GetSequence(string fullName) 获得序列号
        /// <summary>
        /// 获得序列号
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <returns>序列号</returns>
        public string GetSequence(string fullName)
        {
            if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
            {
                return GetOracleSequence(fullName);
            }
            if (DbHelper.CurrentDbType == CurrentDbType.DB2)
            {
                return GetDB2Sequence(fullName);
            }
            return this.GetSequence(fullName, this.DefaultSequence, this.DefaultSequenceLength, this.FillZeroPrefix);
        }
        #endregion

        #region public string GetSequence(string fullName, int defaultSequence) 获得序列号
        /// <summary>
        /// 获得序列号
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <param name="defaultSequence">默认序列</param>
        /// <returns>序列号</returns>
        public string GetSequence(string fullName, int defaultSequence)
        {
            return this.GetSequence(fullName, defaultSequence, this.DefaultSequenceLength, this.FillZeroPrefix);
        }
        #endregion

        #region public string GetSequence(string fullName, int defaultSequence, int sequenceLength) 获得序列号
        /// <summary>
        /// 获得序列
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <param name="defaultSequence">默认序列</param>
        /// <param name="sequenceLength">序列长度</param>
        /// <returns>序列号</returns>
        public string GetSequence(string fullName, int defaultSequence, int sequenceLength)
        {
            return this.GetSequence(fullName, defaultSequence, sequenceLength, false);
        }
        #endregion

        #region public string GetSequence(string fullName, int defaultSequence, int sequenceLength, bool fillZeroPrefix) 获取序列号
        /// <summary>
        /// 获得序列
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <param name="defaultSequence">默认序列</param>
        /// <param name="sequenceLength">序列长度</param>
        /// <param name="fillZeroPrefix">是否填充零</param>
        /// <returns>序列实体</returns>
        public string GetSequence(string fullName, int defaultSequence, int sequenceLength, bool fillZeroPrefix)
        {
            this.DefaultSequence = defaultSequence;
            this.SequenceLength = sequenceLength;
            this.FillZeroPrefix = fillZeroPrefix;
            this.DefaultReduction = defaultSequence - 1;

            // 写入调试信息
            #if (DEBUG)
                int milliStart = Environment.TickCount;
                Trace.WriteLine(DateTime.Now.ToString(BaseSystemInfo.TimeFormat) + " :Begin: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
            #endif

            BaseSequenceEntity sequenceEntity = null;

            // 这里用锁的机制，提高并发控制能力
            lock (SequenceLock)
            {

                switch (DbHelper.CurrentDbType)
                {
                    case CurrentDbType.Access:
                    case CurrentDbType.MySql:
                    case CurrentDbType.SqlServer:
                        sequenceEntity = this.GetEntityByAdd(fullName);
                        this.UpdateSequence(fullName);
                        break;
                    case CurrentDbType.Oracle:
                        // 这里加锁机制。
                        if (DbHelper.InTransaction)
                        {
                            // 不可以影响别人的事务
                            sequenceEntity = this.GetSequenceByLock(fullName, defaultSequence);
                            if (this.ReturnStatusCode == StatusCode.LockOK.ToString())
                            {
                                if (this.UpdateSequence(fullName) > 0)
                                {
                                    this.ReturnStatusCode = StatusCode.LockOK.ToString();
                                }
                                else
                                {
                                    this.ReturnStatusCode = StatusCode.CanNotLock.ToString();
                                }
                            }
                        }
                        else
                        {
                            // 开始事务
                            IDbTransaction dbTransaction = DbHelper.BeginTransaction();
                            try
                            {
                                this.ReturnStatusCode = StatusCode.CanNotLock.ToString();
                                sequenceEntity = this.GetSequenceByLock(fullName, defaultSequence);
                                if (this.ReturnStatusCode == StatusCode.LockOK.ToString())
                                {
                                    this.ReturnStatusCode = StatusCode.CanNotLock.ToString();
                                    if (this.UpdateSequence(fullName) > 0)
                                    {
                                        // 提交事务
                                        dbTransaction.Commit();
                                        this.ReturnStatusCode = StatusCode.LockOK.ToString();
                                    }
                                    else
                                    {
                                        // 回滚事务
                                        dbTransaction.Rollback();
                                    }
                                }
                                else
                                {
                                    // 回滚事务
                                    dbTransaction.Rollback();
                                }
                            }
                            catch (System.Exception ex)
                            {
                                System.Console.WriteLine(ex);
                                // 回滚事务
                                dbTransaction.Rollback();
                                this.ReturnStatusCode = StatusCode.CanNotLock.ToString();
                            }
                        }
                        break;
                }
            }

            // 写入调试信息
            #if (DEBUG)
                int milliEnd = Environment.TickCount;
                Trace.WriteLine(DateTime.Now.ToString(BaseSystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " :End: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
            #endif

            return GetSequence(sequenceEntity);
        }
        #endregion

        #region protected int UpdateSequence(string fullName) 更新升序序列
        /// <summary>
        /// 更新升序序列
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="fullName">序列名称</param>
        /// <returns>影响行数</returns>
        protected int UpdateSequence(string fullName)
        {
            return this.UpdateSequence(fullName, 1);
        }
        #endregion

        #region protected int UpdateSequence(string fullName, int sequenceCount) 更新升序序列
        /// <summary>
        /// 更新升序序列
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <param name="sequenceCount">序列个数</param>
        /// <returns>影响行数</returns>
        protected int UpdateSequence(string fullName, int sequenceCount)
        {
            // 更新数据库里的值
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            sqlBuilder.SetFormula(BaseSequenceEntity.FieldSequence, BaseSequenceEntity.FieldSequence + " + " + sequenceCount.ToString() + " * " + BaseSequenceEntity.FieldStep);
            sqlBuilder.SetWhere(BaseSequenceEntity.FieldFullName, fullName);
            return sqlBuilder.EndUpdate();
        }
        #endregion
        

        //
        // 三 获取降序序列(没有序列时，涉及到并发问题、锁机制，更新序列时会有锁机制)
        //


        #region public string GetReduction(string fullName) 获取倒序序列号
        /// <summary>
        /// 获取倒序序列号
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <returns>序列号</returns>
        public string GetReduction(string fullName)
        {
            return this.GetReduction(fullName, this.DefaultSequence);
        }
        #endregion

        #region public string GetReduction(string fullName, int defaultSequence) 获取倒序序列号
        /// <summary>
        /// 获取倒序序列号
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <param name="defaultSequence">默认序列值</param>
        /// <returns>序列号</returns>
        public string GetReduction(string fullName, int defaultSequence)
        {            
            // 写入调试信息
            #if (DEBUG)
                int milliStart = Environment.TickCount;
                Trace.WriteLine(DateTime.Now.ToString(BaseSystemInfo.TimeFormat) + " :Begin: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
            #endif

            BaseSequenceEntity sequenceEntity = null;

            // 这里用锁的机制，提高并发控制能力
            lock (SequenceLock)
            {

                this.DefaultReduction = defaultSequence;
                this.DefaultSequence = defaultSequence + 1;

                switch (DbHelper.CurrentDbType)
                {
                    case CurrentDbType.Access:
                    case CurrentDbType.MySql:
                    case CurrentDbType.SqlServer:
                        sequenceEntity = GetEntityByAdd(fullName);
                        this.UpdateReduction(fullName);
                        break;
                    case CurrentDbType.Oracle:
                        if (DbHelper.InTransaction)
                        {
                            // 不可以影响别人的事务
                            sequenceEntity = this.GetSequenceByLock(fullName, defaultSequence);
                            if (this.ReturnStatusCode == StatusCode.LockOK.ToString())
                            {
                                if (this.UpdateReduction(fullName) > 0)
                                {
                                    this.ReturnStatusCode = StatusCode.LockOK.ToString();
                                }
                                else
                                {
                                    this.ReturnStatusCode = StatusCode.CanNotLock.ToString();
                                }
                            }
                        }
                        else
                        {
                            // 这里加锁机制。
                            try
                            {
                                // 开始事务
                                DbHelper.BeginTransaction();
                                this.ReturnStatusCode = StatusCode.CanNotLock.ToString();
                                sequenceEntity = this.GetSequenceByLock(fullName, defaultSequence);
                                if (this.ReturnStatusCode == StatusCode.LockOK.ToString())
                                {
                                    this.ReturnStatusCode = StatusCode.CanNotLock.ToString();
                                    if (this.UpdateReduction(fullName) > 0)
                                    {
                                        // 提交事务
                                        DbHelper.CommitTransaction();
                                        this.ReturnStatusCode = StatusCode.LockOK.ToString();
                                    }
                                    else
                                    {
                                        // 回滚事务
                                        DbHelper.RollbackTransaction();
                                    }
                                }
                                else
                                {
                                    // 回滚事务
                                    DbHelper.RollbackTransaction();
                                }
                            }
                            catch
                            {
                                // 回滚事务
                                DbHelper.RollbackTransaction();
                                this.ReturnStatusCode = StatusCode.CanNotLock.ToString();
                            }
                        }
                        break;
                }
            }
            
            // 写入调试信息
            #if (DEBUG)
                int milliEnd = Environment.TickCount;
                Trace.WriteLine(DateTime.Now.ToString(BaseSystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " :End: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
            #endif

            return GetReduction(sequenceEntity);
        }
        #endregion

        #region protected int UpdateReduction(string fullName)
        /// <summary>
        /// 更新降序序列
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <returns>影响行数</returns>
        protected int UpdateReduction(string fullName)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            sqlBuilder.SetFormula(BaseSequenceEntity.FieldReduction, BaseSequenceEntity.FieldReduction + " - " + BaseSequenceEntity.FieldStep);
            sqlBuilder.SetWhere(BaseSequenceEntity.FieldFullName, fullName);
            return sqlBuilder.EndUpdate();
        }
        #endregion

        #region protected BaseSequenceEntity GetSequenceByLock(string fullName, int defaultSequence) 获得序列
        /// <summary>
        /// 获得序列
        /// </summary>
        /// <param name="fullName">序列名</param>
        /// <param name="defaultSequence">默认序列</param>
        /// <returns>序列实体</returns>
        protected BaseSequenceEntity GetSequenceByLock(string fullName, int defaultSequence)
        {
            BaseSequenceEntity sequenceEntity = new BaseSequenceEntity();
            // 这里主要是为了判断是否存在
            sequenceEntity = this.GetEntityByName(fullName);
            if (sequenceEntity == null)
            {
                // 这里添加记录时加锁机制。
                // 是否已经被锁住
                this.ReturnStatusCode = StatusCode.CanNotLock.ToString();
                for (int i = 0; i < BaseSystemInfo.LockNoWaitCount; i++)
                {
                    // 被锁定的记录数
                    int lockCount = DbLogic.LockNoWait(DbHelper, BaseSequenceEntity.TableName, new KeyValuePair<string, object>(BaseSequenceEntity.FieldFullName, BaseSequenceEntity.TableName));
                    if (lockCount > 0)
                    {

                        sequenceEntity.FullName = fullName;
                        sequenceEntity.Reduction = defaultSequence - 1;
                        sequenceEntity.Sequence = defaultSequence;
                        sequenceEntity.Step = DefaultStep;
                        this.AddEntity(sequenceEntity);

                        this.ReturnStatusCode = StatusCode.LockOK.ToString();
                        break;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(BaseRandom.GetRandom(1, BaseSystemInfo.LockNoWaitTickMilliSeconds));
                    }
                }
                if (this.ReturnStatusCode == StatusCode.LockOK.ToString())
                {
                    // JiRiGaLa 这个是否能省略
                    sequenceEntity = this.GetEntityByName(fullName);
                }
            }
            else
            {
                // 若记录已经存在，加锁，然后读取记录。
                // 是否已经被锁住
                this.ReturnStatusCode = StatusCode.CanNotLock.ToString();
                for (int i = 0; i < BaseSystemInfo.LockNoWaitCount; i++)
                {
                    // 被锁定的记录数
                    int lockCount = DbLogic.LockNoWait(DbHelper, BaseSequenceEntity.TableName, new KeyValuePair<string, object>(BaseSequenceEntity.FieldFullName, fullName));
                    if (lockCount > 0)
                    {
                        sequenceEntity = this.GetEntityByName(fullName);
                        this.ReturnStatusCode = StatusCode.LockOK.ToString();
                        break;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(BaseRandom.GetRandom(1, BaseSystemInfo.LockNoWaitTickMilliSeconds));
                    }
                }
            }
            return sequenceEntity;
        }
        #endregion
        

        //
        // 四 批量获取新序列(没有序列时，涉及到并发问题、锁机制，更新序列时会有锁机制)
        //


        #region public string[] GetBatchSequence(string fullName, int sequenceCount) 获取序列号数组
        /// <summary>
        /// 获取序列号数组
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <param name="sequenceCount">序列个数</param>
        /// <returns>序列号</returns>
        public string[] GetBatchSequence(string fullName, int sequenceCount)
        {
            return this.GetBatchSequence(fullName, sequenceCount, this.DefaultSequence);
        }
        #endregion

        #region private string[] GetSequence(BaseSequenceEntity sequenceEntity, int sequenceCount) 批量产生主键
        /// <summary>
        /// 批量产生主键
        /// </summary>
        /// <param name="sequenceEntity">实体</param>
        /// <param name="sequenceCount">序列个数</param>
        /// <returns>主键数组</returns>
        private string[] GetSequence(BaseSequenceEntity sequenceEntity, int sequenceCount)
        {
            string[] returnValue = new string[sequenceCount];
            for (int i = 0; i < sequenceCount; i++)
            {
                returnValue[i] = GetSequence(sequenceEntity);
                sequenceEntity.Sequence += sequenceEntity.Step;
            }
            return returnValue;
        }
        #endregion

        #region public string[] GetBatchSequence(string fullName, int sequenceCount, int defaultSequence) 获取序列号数组
        /// <summary>
        /// 获取序列号数组
        /// </summary>
        /// <param name="fullName">序列名称</param>
        /// <param name="sequenceCount">序列个数</param>
        /// <param name="defaultSequence">默认序列</param>
        /// <returns>序列号</returns>
        public string[] GetBatchSequence(string fullName, int sequenceCount, int defaultSequence)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = Environment.TickCount;
                Trace.WriteLine(DateTime.Now.ToString(BaseSystemInfo.TimeFormat) + " :Begin: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
            #endif

            string[] returnValue = new string[sequenceCount];

            // 这里用锁的机制，提高并发控制能力
            lock (SequenceLock)
            {
                this.DefaultSequence = defaultSequence;
                switch (DbHelper.CurrentDbType)
                {
                    case CurrentDbType.Access:
                    case CurrentDbType.MySql:
                    case CurrentDbType.SqlServer:
                        BaseSequenceEntity sequenceEntity = this.GetEntityByAdd(fullName);
                        this.UpdateSequence(fullName, sequenceCount);
                        // 这里循环产生ID数组
                        returnValue = this.GetSequence(sequenceEntity, sequenceCount);
                        break;
                    case CurrentDbType.DB2:
                        for (int i = 0; i < sequenceCount; i++)
                        {
                            returnValue[i] = GetDB2Sequence(fullName);
                        }
                        break;
                    case CurrentDbType.Oracle:
                        for (int i = 0; i < sequenceCount; i++)
                        {
                            returnValue[i] = GetOracleSequence(fullName);
                        }
                        break;
                }
            }

            // 写入调试信息
            #if (DEBUG)
                int milliEnd = Environment.TickCount;
                Trace.WriteLine(DateTime.Now.ToString(BaseSystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " :End: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
            #endif

            return returnValue;
        }
        #endregion


        //
        // 重置序列(暂不考虑并发问题)
        //


        #region public int Reset(string[] ids) 批量重置
        /// <summary>
        /// 批量重置
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        public int Reset(string[] ids)
        {
            int returnValue = 0;
            BaseSequenceEntity sequenceEntity = null;
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            for (int i = 0; i < ids.Length; i++)
            {
                if (ids[i].Length > 0)
                {
                    // 若有相应的表，那就把序列号都计算好
                    sequenceEntity = this.GetEntity(ids[i]);
                    string commandText = string.Format(@" UPDATE BaseSequence
                                               SET Sequence = (SELECT MAX(SortCode) + 1  AS MaxSortCode FROM {0})
	                                               , Reduction = ( SELECT MIN(SortCode) -1 AS MinSortCode FROM {0})
                                             WHERE FullName = '{0}' ", sequenceEntity.FullName);
                    try
                    {
                        this.ExecuteNonQuery(commandText);
                    }
                    catch
                    {
                        sqlBuilder.BeginUpdate(this.CurrentTableName);
                        sqlBuilder.SetValue(BaseSequenceEntity.FieldSequence, this.DefaultSequence);
                        sqlBuilder.SetValue(BaseSequenceEntity.FieldReduction, this.DefaultReduction);
                        sqlBuilder.SetWhere(BaseSequenceEntity.FieldId, ids[i]);
                        returnValue += sqlBuilder.EndUpdate();
                    }
                }
            }
            return returnValue;
        }
        #endregion
    }
}