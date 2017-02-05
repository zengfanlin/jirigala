//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{

    /// <summary>
    ///	IBaseManager
    /// 通用接口部分
    /// 
    /// 总觉得自己写的程序不上档次，这些新技术也玩玩，也许做出来的东西更专业了。
    /// 修改纪录
    /// 
    ///		2007.11.01 版本：1.9 JiRiGaLa 改进 BUOperatorInfo 去掉这个变量，可以提高性能，提高速度，基类的又一次飞跃。
    ///		2007.05.23 版本：1.8 JiRiGaLa 修改完善了 对象事件触发器，完善了GetDataTable, ref 方法部分。
    ///		2007.05.20 版本：1.7 JiRiGaLa 修改完善了 对象事件触发器，完善了GetDataTable方法部分。
    ///		2007.05.19 版本：1.6 JiRiGaLa 修改完善了 Delete，Exists方法部分，累了休息一下下，争取周六周日两天内完成。
    ///		2007.05.18 版本：1.5 JiRiGaLa 规范了一些接口的标准方法，进行了补充。
    ///		2007.05.17 版本：1.4 JiRiGaLa 重新调整主键的规范化，整体上又上升了一个层次了。
    ///		2006.02.05 版本：1.3 JiRiGaLa 重新调整主键的规范化。
    ///		2005.08.19 版本：1.2 JiRiGaLa 参数进行改进
    ///		2004.07.23 版本：1.1 JiRiGaLa 增加了接口ClearProperty、GetFromDS 的定义。
    ///		2004.07.21 版本：1.0 JiRiGaLa 提炼了最基础的方法部分、觉得这些是很有必要的方法。
    ///
    /// 版本：1.8
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.23</date>
    /// </author> 
    /// </summary>
    public interface IBaseManager
    {
        /// <summary>
        /// 当前表名
        /// </summary>
        string CurrentTableName { get; set; }

        //
        // 类对应的数据库最终操作
        //
        
        string AddEntity(object entity);
        int UpdateEntity(object entity);
        int DeleteEntity(object id);
        
        //
        // 对象事件触发器（编写程序的人员，可以不实现这些方法）
        //

        bool AddBefore();
        bool AddAfter();
        bool UpdateBefore();
        bool UpdateAfter();
        bool GetBefore(string id);
        bool GetAfter(string id);
        bool DeleteBefore(string id);
        bool DeleteAfter(string id);

        //
        // 添加逻辑编写
        //
        // string Add();

        //
        // 更新逻辑编写
        //
        // int Update();

        //
        // 批量操作保存
        //
        
        int BatchSave(DataTable dataTable);

        //
        // 读取多条记录
        //
        
        DataTable GetDataTable(string order);
        DataTable GetDataTable(int topLimit, string order);
        DataTable GetDataTable(string name, Object[] values, string order);
        DataTable GetDataTable(string[] ids);
        DataTable GetDataTable(KeyValuePair<string, object> parameter, string order);
        DataTable GetDataTable(KeyValuePair<string, object> parameter, int topLimit, string order);
        DataTable GetDataTable(List<KeyValuePair<string, object>> parameters, string order);
        DataTable GetDataTable(List<KeyValuePair<string, object>> parameters, int topLimit, string order);

        //
        // 读取多条记录
        //
        List<T> GetListById<T>(string id)where T : new();
        List<T> GetListByCategory<T>(string categoryId) where T : new();
        List<T> GetList<T>(int topLimit = 0, string order = null) where T : new();
        List<T> GetList<T>(string order) where T : new();
        List<T> GetList<T>(string[] ids) where T : new();
        List<T> GetList<T>(string name, Object[] values, string order = null) where T : new();        
        List<T> GetList<T>(KeyValuePair<string, object> parameter, string order) where T : new();
        List<T> GetList<T>(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, string order) where T : new();
        List<T> GetList<T>(KeyValuePair<string, object> parameter, int topLimit, string order)where T:new ();
        List<T> GetList<T>(List<KeyValuePair<string, object>> parameters, string order)where T:new ();
        List<T> GetList<T>(List<KeyValuePair<string, object>> parameters, int topLimit, string order) where T : new();
        List<T> GetList<T>(params KeyValuePair<string, object>[] parameters) where T : new();
        //
        // 读取属性
        //

        string GetProperty(object id, string targetField);
        string GetProperty(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, string targetField);
        string GetProperty(List<KeyValuePair<string, object>> parameters, string targetField);
        string GetId(KeyValuePair<string, object> parameter);
        string GetId(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2);
        string GetId(List<KeyValuePair<string, object>> parameters);
        string GetId(params KeyValuePair<string, object>[] parameters);

        //
        // 获得属性数组
        //

        string[] GetIds();
        string[] GetIds(KeyValuePair<string, object> parameter);
        string[] GetIds(string name, Object[] values);
        string[] GetIds(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2);
        string[] GetIds(List<KeyValuePair<string, object>> parameters);

        string[] GetProperties(string order);
        string[] GetProperties(int topLimit, string targetField);
        string[] GetProperties(KeyValuePair<string, object> parameter, string targetField);
        string[] GetProperties(KeyValuePair<string, object> parameter, int topLimit, string targetField);
        string[] GetProperties(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, string targetField);
        string[] GetProperties(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, int topLimit, string targetField);
        string[] GetProperties(List<KeyValuePair<string, object>> parameters, string targetField);
        string[] GetProperties(List<KeyValuePair<string, object>> parameters, int topLimit, string targetField);

        //
        // 设置属性
        //

        int SetProperty(KeyValuePair<string, object> parameter);
        int SetProperty(object id, KeyValuePair<string, object> parameter);
        int SetProperty(object id, List<KeyValuePair<string, object>> parameters);
        int SetProperty(object[] ids, KeyValuePair<string, object> parameter);
        int SetProperty(object[] ids, List<KeyValuePair<string, object>> parameters);
        int SetProperty(string name, object[] values, KeyValuePair<string, object> parameter);
        int SetProperty(string name, object[] values, List<KeyValuePair<string, object>> parameters);
        int SetProperty(KeyValuePair<string, object> whereParameter1, KeyValuePair<string, object> whereParameter2, KeyValuePair<string, object> parameter);
        int SetProperty(KeyValuePair<string, object> whereParameter, KeyValuePair<string, object> parameter);
        int SetProperty(List<KeyValuePair<string, object>> whereParameters, KeyValuePair<string, object> parameter);
        int SetProperty(KeyValuePair<string, object> whereParameter, List<KeyValuePair<string, object>> parameters);
        int SetProperty(List<KeyValuePair<string, object>> whereParameters, List<KeyValuePair<string, object>> parameters);

        //
        // 判断数据是否存在
        //

        bool Exists(object id);
        bool Exists(params KeyValuePair<string, object>[] parameters);
        bool Exists(KeyValuePair<string, object> parameter, object id);
        bool Exists(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter);
        bool Exists(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, object id);
        bool Exists(KeyValuePair<string, object> parameter1, KeyValuePair<string, object> parameter2, KeyValuePair<string, object> parameter);
        bool Exists(List<KeyValuePair<string, object>> parameters, object id);

        //
        // 删除数据部分
        // force 是否强制删除关联数据
        //

        int Delete();
        int Delete(object id);
        int Delete(object[] ids);
        int Delete(string name, object[] values);
        int Delete(params KeyValuePair<string, object>[] parameters);
        int Delete(List<KeyValuePair<string, object>> parameters);
        int Truncate();


        /// 直接执行一些SQL语句的方法

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <returns>影响行数</returns>
        int ExecuteNonQuery(string commandText);

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>影响行数</returns>
        int ExecuteNonQuery(string commandText, IDbDataParameter[] dbParameters);
        
        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <returns>object</returns>
        object ExecuteScalar(string commandText);

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>Object</returns>
        object ExecuteScalar(string commandText, IDbDataParameter[] dbParameters);

        /// <summary>
        /// 填充数据表
        /// </summary>
        /// <param name="commandText">查询</param>
        /// <returns>数据表</returns>
        DataTable Fill(string commandText);

        /// <summary>
        /// 填充数据表
        /// </summary>
        /// <param name="commandText">sql查询</param>
        /// <param name="dbParameters">参数集</param>
        /// <returns>数据表</returns>
        DataTable Fill(string commandText, IDbDataParameter[] dbParameters);
    }
}