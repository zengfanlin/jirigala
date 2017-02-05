//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;

namespace DotNet.Business
{
   using DotNet.Utilities;

   /// <summary>
   /// SQLBuilder
   /// SQL语句生成器（适合简单的添加、删除、更新等语句，可以写出编译时强类型检查的效果）
   /// 
   /// 修改记录
   ///     2012.3.17  版本：3.7 zhangyi   修改注释
   ///     2010.06.20 版本：3.1 JiRiGaLa	支持Oracle序列功能改进。
   ///     2010.06.13 版本：3.0 JiRiGaLa	改进为支持静态方法，不用数据库Open、Close的方式，AutoOpenClose开关。
   ///     2008.08.30 版本：2.3 JiRiGaLa	确认 BeginSelect 方法的正确性。
   ///     2008.08.29 版本：2.2 JiRiGaLa	改进 public string SetWhere(string targetFiled, Object[] targetValue) 方法。
   ///     2008.08.29 版本：2.1 JiRiGaLa	修正 BeginSelect、BeginInsert、BeginUpdate、BeginDelete。
   ///     2008.05.07 版本：2.0 JiRiGaLa	改进为多种数据库的支持类型。
   ///     2007.05.20 版本：1.8 JiRiGaLa	改进了OleDbCommand使其可以在多个事件穿插使用。
   ///     2006.02.22 版本：1.7 JiRiGaLa	改进了OleDbCommand使其可以在多个事件穿插使用。
   ///		2006.02.05 版本：1.6 JiRiGaLa	重新调整主键的规范化。
   ///		2006.01.20 版本：1.5 JiRiGaLa   修改主键,货币型的插入。
   ///		2005.12.29 版本：1.4 JiRiGaLa   修改主键,将公式的功能完善,提高效率。
   ///		2005.12.29 版本：1.3 JiRiGaLa   修改主键,将公式的功能完善,提高效率。
   ///		2005.08.08 版本：1.2 JiRiGaLa   修改主键，修改格式。
   ///		2005.12.30 版本：1.1 JiRiGaLa   数据库连接进行优化。
   ///		2005.12.29 版本：1.0 JiRiGaLa   主键创建。
   ///		
   /// 版本：3.0
   ///
   /// <author>
   ///		<name>JiRiGaLa</name>
   ///		<date>2010.06.13</date>
   /// </author> 
   /// </summary>
   public partial class SQLBuilder
   {
      /// <summary>
      /// 是否采用自增量的方式
      /// </summary>
      private bool Identity = false;
      /// <summary>
      ///  是否需要返回主键
      /// </summary>
      private bool ReturnId = true;
      /// <summary>
      /// 主键
      /// </summary>
      private string PrimaryKey = "Id";

      private DbOperation sqlOperation = DbOperation.Update;

      private string CommandText = string.Empty;

      private string TableName = string.Empty;
      private string InsertValue = string.Empty;
      private string InsertField = string.Empty;
      private string UpdateSql = string.Empty;
      private string SelectSql = string.Empty;
      private string WhereSql = string.Empty;

      private IDbHelper DbHelper = null;

      private Dictionary<String, Object> parameters = new Dictionary<String, Object>();

      private SQLBuilder()
      {
         this.parameters = new Dictionary<String, Object>();
      }

      public SQLBuilder(IDbHelper dbHelper)
         : this()
      {
         DbHelper = dbHelper;
      }

      public SQLBuilder(IDbHelper dbHelper, bool identity)
         : this(dbHelper)
      {
         Identity = identity;
      }

      public SQLBuilder(IDbHelper dbHelper, bool identity, bool returnId)
         : this(dbHelper)
      {
         Identity = identity;
         ReturnId = returnId;
      }

      #region private void PrepareCommand() 获得数据库连接相关
      /// <summary>
      /// 获得数据库连接
      /// </summary>
      private void PrepareCommand()
      {
         // 写入调试信息
         #if (DEBUG)
                  int milliStart = Environment.TickCount;
                  Trace.WriteLine(DateTime.Now.ToString(BaseSystemInfo.TimeFormat) + " :Begin: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
         #endif

         this.sqlOperation = DbOperation.Update;
         this.CommandText = string.Empty;
         this.TableName = string.Empty;
         this.InsertValue = string.Empty;
         this.InsertField = string.Empty;
         this.UpdateSql = string.Empty;
         this.WhereSql = string.Empty;

         // 判断是否为空，要区别静态方法与动态调用方法
         if (!DbHelper.AutoOpenClose)
         {
            DbHelper.GetDbCommand().Parameters.Clear();
         }

         // 写入调试信息
         #if (DEBUG)
                  int milliEnd = Environment.TickCount;
                  Trace.WriteLine(DateTime.Now.ToString(BaseSystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " :End: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
         #endif
      }
      #endregion

      #region public void BeginSelect(string tableName) 开始查询
      /// <summary>
      /// 开始查询
      /// </summary>
      /// <param name="tableName">目标表</param>
      public void BeginSelect(string tableName)
      {
         Begin(tableName, DbOperation.Select);
      }
      #endregion

      #region public void BeginInsert(string tableName) 开始插入
      /// <summary>
      /// 开始插入
      /// </summary>
      /// <param name="tableName">目标表</param>
      public void BeginInsert(string tableName)
      {
         Begin(tableName, DbOperation.Insert);
      }
      #endregion

      #region public void BeginInsert(string tableName, bool identity) 开始插入 传入是否自增
      /// <summary>
      /// 开始插入  传入是否自增
      /// </summary>
      /// <param name="tableName">目标表</param>
      /// <param name="identity">自增量方式</param>
      public void BeginInsert(string tableName, bool identity)
      {
         Identity = identity;
         Begin(tableName, DbOperation.Insert);
      }
      #endregion

      #region public void BeginInsert(string tableName, string primaryKey) 开始插入 传入主键
      /// <summary>
      /// 开始插入 传入主键
      /// </summary>
      /// <param name="tableName">目标表</param>
      /// <param name="primaryKey">主键</param>
      public void BeginInsert(string tableName, string primaryKey)
      {
         PrimaryKey = primaryKey;
         Begin(tableName, DbOperation.Insert);
      }
      #endregion

      #region public BeginUpdate(string tableName) 开始更新
      /// <summary>
      /// 开始更新
      /// </summary>
      /// <param name="tableName">目标表</param>
      public void BeginUpdate(string tableName)
      {
         Begin(tableName, DbOperation.Update);
      }
      #endregion

      #region public void BeginDelete(string tableName) 开始删除
      /// <summary>
      /// 开始删除
      /// </summary>
      /// <param name="tableName">目标表</param>
      public void BeginDelete(string tableName)
      {
         Begin(tableName, DbOperation.Delete);
      }
      #endregion

      #region public void BeginInsert(string tableName,string primaryKey, bool identity) 开始插入 传入是否自增
      /// <summary>
      /// 开始插入  传入是否自增
      /// </summary>
      /// <param name="tableName">目标表</param>
      /// <param name="primaryKey">主键</param>
      /// <param name="identity">自增量方式</param>
      public void BeginInsert(string tableName, string primaryKey, bool identity)
      {
          Identity = identity;
          PrimaryKey = primaryKey;
          Begin(tableName, DbOperation.Insert);
      }
      #endregion

      #region private void Begin(string tableName, DbOperation dbOperation) 开始增删改查
      /// <summary>
      /// 开始查询语句
      /// </summary>
      /// <param name="tableName">目标表</param>
      /// <param name="dbOperation">语句操作类别</param>
      private void Begin(string tableName, DbOperation dbOperation)
      {
         // 写入调试信息
         #if (DEBUG)
                  int milliStart = Environment.TickCount;
                  Trace.WriteLine(DateTime.Now.ToString(BaseSystemInfo.TimeFormat) + " :Begin: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
         #endif

         this.PrepareCommand();
         this.TableName = tableName;
         this.sqlOperation = dbOperation;

         // 写入调试信息
         #if (DEBUG)
                  int milliEnd = Environment.TickCount;
                  Trace.WriteLine(DateTime.Now.ToString(BaseSystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " :End: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
         #endif
      }
      #endregion

      #region public void SetFormula(string targetFiled, string formula, string relation) 设置公式
      /// <summary>
      /// 设置公式
      /// </summary>
      /// <param name="targetFiled">目标字段</param>
      /// <param name="targetFiled">目标字段</param>
      public void SetFormula(string targetFiled, string formula)
      {
         string relation = " = ";
         this.SetFormula(targetFiled, formula, relation);
      }
      /// <summary>
      /// 设置公式
      /// </summary>
      /// <param name="targetFiled">目标字段</param>
      /// <param name="targetFiled">目标字段</param>
      public void SetFormula(string targetFiled, string formula, string relation)
      {
         if (sqlOperation == DbOperation.Insert)
         {
            InsertField += targetFiled + ", ";
            InsertValue += formula + ", ";
         }
         if (sqlOperation == DbOperation.Update)
         {
            UpdateSql += targetFiled + relation + formula + ", ";
         }
      }
      #endregion

      #region public void SetDBNow(string targetFiled) 设置为当前时间
      /// <summary>
      /// 设置为当前时间
      /// </summary>
      /// <param name="targetFiled">目标字段</param>
      public void SetDBNow(string targetFiled)
      {
         if (sqlOperation == DbOperation.Insert)
         {
            InsertField += targetFiled + ", ";
            InsertValue += DbHelper.GetDBNow() + ", ";
         }
         if (sqlOperation == DbOperation.Update)
         {
            UpdateSql += targetFiled + " = " + DbHelper.GetDBNow() + ", ";
         }
      }
      #endregion

      #region public void SetNull(string targetFiled) 设置为Null值
      /// <summary>
      /// 设置为Null值
      /// </summary>
      /// <param name="targetFiled">目标字段</param>
      public void SetNull(string targetFiled)
      {
         this.SetValue(targetFiled, null);
      }
      #endregion

      #region public void SetValue(string targetFiled, object targetValue) 设置值
      /// <summary>
      /// 设置值
      /// </summary>
      /// <param name="targetFiled">目标字段</param>
      /// <param name="targetValue">值</param>
      public void SetValue(string targetFiled, object targetValue, string targetFiledName = null)
      {
         if (targetFiledName == null)
         {
            targetFiledName = targetFiled;
         }
         switch (this.sqlOperation)
         {
            case DbOperation.Update:
               if (targetValue == null)
               {
                  this.UpdateSql += targetFiled + " = Null, ";
               }
               else
               {
                  if (targetValue.ToString().Length > 0)
                  {
                     // 判断数据库连接类型
                     this.UpdateSql += targetFiled + " = " + DbHelper.GetParameter(targetFiledName) + ", ";
                     this.AddParameter(targetFiledName, targetValue);
                  }
                  else
                  {
                     this.UpdateSql += targetFiled + " = '', ";
                  }
               }
               break;
            case DbOperation.Insert:
               if (DbHelper.CurrentDbType == CurrentDbType.SqlServer)
               {
                  if (this.Identity && targetFiled == this.PrimaryKey)
                  {
                     // 自增量，不需要赋值
                  }
                  else
                  {
                     this.InsertField += targetFiled + ", ";
                  }
               }
               else if (DbHelper.CurrentDbType == CurrentDbType.Access)
               {
                   if (this.Identity && targetFiled == this.PrimaryKey)
                   {
                       // 自增量，不需要赋值  
                   }
                   else
                   {
                       this.InsertField += targetFiled + ", ";
                   }
               }
               else
               {
                  this.InsertField += targetFiled + ", ";
               }

               if (targetValue == null)
               {
                  if (DbHelper.CurrentDbType == CurrentDbType.SqlServer)
                  {
                     if (this.Identity && targetFiled == this.PrimaryKey)
                     {
                        // 自增量，不需要赋值
                     }
                     else
                     {
                        this.InsertValue += " Null, ";
                     }
                  }
                  else if (DbHelper.CurrentDbType == CurrentDbType.Access)
                  {
                      if (this.Identity && targetFiled == this.PrimaryKey)
                      {
                          // 自增量，不需要赋值
                      }
                      else
                      {
                          this.InsertValue += " Null, ";
                      }
                  }
                  else
                  {
                     this.InsertValue += " Null, ";
                  }
               }
               else
               {
                  if (this.Identity && targetFiled == this.PrimaryKey && DbHelper.CurrentDbType == CurrentDbType.SqlServer)
                  {
                     // 自增量，不需要赋值
                  }
                  else
                  {
                     this.InsertValue += DbHelper.GetParameter(targetFiledName) + ", ";
                     this.AddParameter(targetFiledName, targetValue);
                  }
               }
               break;
         }
      }
      #endregion

      #region private void AddParameter(string targetFiled, object targetValue) 添加参数
      /// <summary>
      /// 添加参数
      /// </summary>
      /// <param name="targetFiled">目标字段</param>
      /// <param name="targetValue">值</param>
      private void AddParameter(string targetFiled, object targetValue)
      {
         this.parameters.Add(targetFiled, targetValue);
      }
      #endregion

      #region public string SetWhere(string[] targetFileds, Object[] targetValues, string relation = " AND ") 设置条件
      /// <summary>
      /// 设置条件
      /// </summary>
      /// <param name="targetFileds">目标字段</param>
      /// <param name="targetValues">值</param>
      /// <param name="relation">条件 AND OR</param>
      /// <returns>条件语句</returns>
      public string SetWhere(string[] targetFileds, Object[] targetValues, string relation = " AND ")
      {
         for (int i = 0; i < targetFileds.Length; i++)
         {
            this.SetWhere(targetFileds[i], targetValues[i], targetFileds[i], relation);
         }
         string returnValue = this.WhereSql;
         return returnValue;
      }
      #endregion

      #region public string SetWhere(string targetFiled, object targetValue, string targetFiledName = null, string relation = " AND ") 设置条件
      /// <summary>
      /// 设置条件
      /// </summary>
      /// <param name="targetFiled">目标字段</param>
      /// <param name="targetValue">值</param>
      /// <param name="relation">条件 AND OR</param>
      /// <returns>条件语句</returns>
      public string SetWhere(string targetFiled, object targetValue, string targetFiledName = null, string relation = " AND ")
      {
         if (string.IsNullOrEmpty(targetFiledName))
         {
            targetFiledName = targetFiled;
         }
         if (WhereSql.Length == 0)
         {
            WhereSql = " WHERE ";
         }
         else
         {
            WhereSql += relation;
         }
         // 这里需要对 null 进行处理
         if ((targetValue == null) || ((targetValue is string) && string.IsNullOrEmpty((string)targetValue)))
         {
            this.WhereSql += targetFiled + " IS NULL ";
         }
         else
         {
            this.WhereSql += targetFiled + " = " + DbHelper.GetParameter(targetFiledName);
            this.AddParameter(targetFiledName, targetValue);
         }
         return this.WhereSql;
      }
      #endregion

      #region public string SetWhere(string targetFiled, Object[] targetValues) "In" 设置条件
      /// <summary>
      /// 设置条件
      /// </summary>
      /// <param name="targetFiled">字段名</param>
      /// <param name="targetValues">字段值</param>
      /// <returns>条件语句</returns>
      public string SetWhere(string targetFiled, Object[] targetValues)
      {
         if (WhereSql.Length == 0)
         {
            WhereSql = " WHERE ";
         }
         this.WhereSql += targetFiled + " IN (" + BaseBusinessLogic.ObjectsToList(targetValues) + ")";
         return this.WhereSql;
      }
      #endregion



      #region public int EndSelect() 结束查询
      /// <summary>
      /// 结束查询
      /// </summary>
      /// <returns>影响行数</returns>
      public int EndSelect()
      {
         return this.Execute();
      }
      #endregion

      #region public int EndInsert() 结束插入
      /// <summary>
      /// 结束插入
      /// </summary>
      /// <returns>影响行数</returns>
      public int EndInsert()
      {
         return this.Execute();
      }
      #endregion

      #region public int EndUpdate() 结束更新
      /// <summary>
      /// 结束更新
      /// </summary>
      /// <returns>影响行数</returns>
      public int EndUpdate()
      {
         return this.Execute();
      }
      #endregion

      #region public int EndDelete() 结束删除
      /// <summary>
      /// 结束删除
      /// </summary>
      /// <returns>影响行数</returns>
      public int EndDelete()
      {
         return this.Execute();
      }
      #endregion



      #region private int Execute() 执行语句
      /// <summary>
      /// 执行语句
      /// </summary>
      /// <returns>影响行数</returns>
      private int Execute()
      {
          // 处理返回值
          int returnValue = 0;

         // 写入调试信息
         #if (DEBUG)
                  int milliStart = Environment.TickCount;
                  Trace.WriteLine(DateTime.Now.ToString(BaseSystemInfo.TimeFormat) + " :Begin: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
         #endif

         if (this.sqlOperation == DbOperation.Select)
         {
            this.CommandText = " SELECT * FROM " + this.TableName + this.WhereSql;
         }
         if (this.sqlOperation == DbOperation.Insert)
         {
            this.InsertField = this.InsertField.Substring(0, InsertField.Length - 2);
            this.InsertValue = this.InsertValue.Substring(0, InsertValue.Length - 2);
            this.CommandText = " INSERT INTO " + this.TableName + "(" + InsertField + ") VALUES(" + InsertValue + ") ";
            // 采用了自增量的方式
            if (this.Identity)
            {
               switch (DbHelper.CurrentDbType)
               {
                  case CurrentDbType.SqlServer:
                     // 需要返回主键
                     if (this.ReturnId)
                     {
                        this.CommandText += "; SELECT SCOPE_IDENTITY(); ";
                     }
                     break;
                  case CurrentDbType.Access:
                     // 需要返回主键
                     if (this.ReturnId)
                     {
                         string ReturnIdStr = " SELECT @@identity AS ID FROM " + this.TableName + "; ";
                         returnValue = int.Parse(DbHelper.ExecuteScalar(ReturnIdStr).ToString());
                     }
                     break;
               }
            }
         }
         if (this.sqlOperation == DbOperation.Update)
         {
            this.UpdateSql = this.UpdateSql.Substring(0, UpdateSql.Length - 2);
            this.CommandText = " UPDATE " + this.TableName + " SET " + this.UpdateSql + this.WhereSql;
         }
         if (this.sqlOperation == DbOperation.Delete)
         {
            this.CommandText = " DELETE FROM " + this.TableName + this.WhereSql;
         }

         // 参数进行规范化
         List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();
         foreach (string key in this.parameters.Keys)
         {
            dbParameters.Add(DbHelper.MakeParameter(key, this.parameters[key]));
         }
         
         if (this.Identity && this.sqlOperation == DbOperation.Insert && DbHelper.CurrentDbType == CurrentDbType.SqlServer)
         {
            // 读取返回值
            if (this.ReturnId)
            {
               returnValue = int.Parse(DbHelper.ExecuteScalar(this.CommandText, dbParameters.ToArray()).ToString());
            }
            else
            {
               // 执行语句
               returnValue = DbHelper.ExecuteNonQuery(this.CommandText, dbParameters.ToArray());
            }
         }
         else
         {
            // 执行语句
            returnValue = DbHelper.ExecuteNonQuery(this.CommandText, dbParameters.ToArray());
         }

         if (this.Identity)
         {
            switch (DbHelper.CurrentDbType)
            {
               case CurrentDbType.Access:
                  // 需要返回主键
                  if (this.ReturnId)
                  {
                     this.CommandText = " SELECT @@identity AS ID FROM " + this.TableName + "; ";
                     returnValue = int.Parse(DbHelper.ExecuteScalar(this.CommandText).ToString());
                  }
                  break;
            }
         }

         if (!DbHelper.AutoOpenClose)
         {
         }
         // 清除查询参数
         this.parameters.Clear();
         DbHelper.GetDbCommand().Parameters.Clear();

         // 写入调试信息
         #if (DEBUG)
                  int milliEnd = Environment.TickCount;
                  Trace.WriteLine(DateTime.Now.ToString(BaseSystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " :End: " + MethodBase.GetCurrentMethod().ReflectedType.Name + "." + MethodBase.GetCurrentMethod().Name);
         #endif

         return returnValue;
      }
      #endregion
   }
}