//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;

namespace DotNet.Utilities
{
    /// <summary>
    ///	BaseSortLogic
    /// 通用排序逻辑基类（程序OK）
    /// 
    /// 修改纪录
    /// 
    ///		2010.10.09 版本：   1.4 JiRiGaLa 更新函数名为*Id。
    ///		2007.12.10 版本：   1.3 JiRiGaLa 改进 序列产生码的长度问题。
    ///		2007.11.01 版本：   1.2 JiRiGaLa 改进 BUOperatorInfo 去掉这个变量，可以提高性能，提高速度，基类的又一次飞跃。
    ///		2007.03.01 版本：   1.0 JiRiGaLa 将主键从 BUBaseBusinessLogic 类分离出来。
    ///	
    /// 版本：1.3
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.12.10</date>
    /// </author> 
    /// </summary>
    public class BaseSortLogic
    {
        //
        // 排序操作在内存中的运算方式定义
        //

        #region public static string GetNextId(DataTable dataTable, string id) 获取下一条记录主键
        /// <summary>
        /// 获取下一条记录主键
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="tableName">当前表</param>
        /// <param name="id">当前主键</param>
        /// <returns>主键</returns>
        public static string GetNextId(DataTable dataTable, string id)
        {
            return GetNextId(dataTable.DefaultView, id, BaseBusinessLogic.FieldId);
        }
        #endregion

        #region  public static string GetNextId(DataView dataView, string id) 获取下一条记录主键
        /// <summary>
        /// 获取下一条记录主键
       /// </summary>
       /// <param name="dataView"></param>
       /// <param name="id"></param>
       /// <returns></returns>
        public static string GetNextId(DataView dataView, string id)
        {
            return GetNextId(dataView, id, BaseBusinessLogic.FieldId);
        }
        public static string GetNextIdDyn(dynamic lstT, string id)
        {
            return GetNextIdDyn(lstT, id, BaseBusinessLogic.FieldId);
        }
        public static string GetNextIdDyn(dynamic lstT, string id, string field)
        {
            string returnValue = string.Empty;
            bool find = false;
            foreach (dynamic t in lstT)
            {
                if (find)
                {
                    returnValue = ReflectionUtil.GetProperty(t,field).ToString();
                    break;
                }
                if (ReflectionUtil.GetProperty(t, field).ToString().Equals(id))
                {
                    find = true;
                }
            }
            return returnValue;
        }
        #endregion

        #region public static string GetNextId(DataTable dataTable, string id, string field) 获取下一条记录主键
        /// <summary>
        /// 获取下一条记录主键
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="tableName">当前表</param>
        /// <param name="id">当前主键Id</param>
        /// <param name="field">当前字段</param>
        /// <returns>主键</returns>
        public static string GetNextId(DataTable dataTable, string id, string field)
        {
            return GetNextId(dataTable.DefaultView, id, field);
        }
        #endregion

        #region public static string GetNextId(DataView dataView, string id, string field) 获取下一条记录 具体方法
        /// <summary>
        /// 获取下一条记录 具体方法
       /// </summary>
       /// <param name="dataView"></param>
       /// <param name="id"></param>
       /// <param name="field"></param>
       /// <returns></returns>
        public static string GetNextId(DataView dataView, string id, string field)
        {
            string returnValue = string.Empty;
            bool find = false;
            foreach (DataRowView dataRow in dataView)
            {
                if (find)
                {
                    returnValue = dataRow[field].ToString();
                    break;
                }
                if (dataRow[field].ToString().Equals(id))
                {
                    find = true;
                }
            }
            return returnValue;
        }
        #endregion



        #region public static string GetPreviousId(DataTable dataTable, string id) 获取上一条记录主键
        /// <summary>
        /// 获取上一条记录主键
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="tableName">当前表</param>
        /// <param name="id">当前主键</param>
        /// <returns>主键</returns>
        public static string GetPreviousId(DataTable dataTable, string id)
        {
            return GetPreviousId(dataTable.DefaultView, id, BaseBusinessLogic.FieldId);
        }
        #endregion

        #region  public static string GetPreviousId(DataView dataView, string id) 获取上一条记录主键
        /// <summary>
        /// 获取上一条记录主键
       /// </summary>
       /// <param name="dataView"></param>
       /// <param name="id"></param>
       /// <returns></returns>
        public static string GetPreviousId(DataView dataView, string id)
        {
            return GetPreviousId(dataView, id, BaseBusinessLogic.FieldId);
        }
        #endregion

        #region public static string GetPreviousId(DataTable dataTable, string id) 获取上一条记录主键
        /// <summary>
        /// 获取上一条记录主键
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="tableName">当前表</param>
        /// <param name="id">当前主键</param>
        /// <param name="field">当前字段</param>
        /// <returns>主键</returns>
        public static string GetPreviousId(DataTable dataTable, string id, string field)
        {
            return GetPreviousId(dataTable.DefaultView, id, field);
        }
        #endregion

        #region  public static string GetPreviousId(DataView dataView, string id, string field) 获取上一条记录主键 具体方法
        /// <summary>
        ///  获取上一条记录主键 具体方法
       /// </summary>
       /// <param name="dataView"></param>
       /// <param name="id"></param>
       /// <param name="field"></param>
       /// <returns></returns>
        public static string GetPreviousId(DataView dataView, string id, string field)
        {
            string returnValue = string.Empty;
            foreach (DataRowView dataRow in dataView)
            {
                if (dataRow[field].ToString().Equals(id))
                {
                    break;
                }
                returnValue = dataRow[field].ToString();
            }
            return returnValue;
        }
        #endregion



        #region public static int Swap(DataTable dataTable, string id, string targetId) 两条记录交换排序顺序
        /// <summary>
        /// 两条记录交换排序顺序
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="id">要移动的记录主键</param>
        /// <param name="targetId">目标记录主键</param>
        /// <returns>影响行数</returns>
        public static int Swap(DataTable dataTable, string id, string targetId)
        {
            int returnValue = 0;
            string sortCode = BaseBusinessLogic.GetProperty(dataTable, id, BaseBusinessLogic.FieldSortCode);
            string targetSortCode = BaseBusinessLogic.GetProperty(dataTable, targetId, BaseBusinessLogic.FieldSortCode);
            returnValue = BaseBusinessLogic.SetProperty(dataTable, id, BaseBusinessLogic.FieldSortCode, targetSortCode);
            returnValue += BaseBusinessLogic.SetProperty(dataTable, targetId, BaseBusinessLogic.FieldSortCode, sortCode);
            return returnValue;
        }
        public static int SwapDyn(dynamic lstT, string id, string targetId)
        {
            int returnValue = 0;
            string sortCode = BaseBusinessLogic.GetPropertyDyn(lstT, id, BaseBusinessLogic.FieldSortCode);
            string targetSortCode = BaseBusinessLogic.GetPropertyDyn(lstT, targetId, BaseBusinessLogic.FieldSortCode);
            returnValue = BaseBusinessLogic.SetPropertyDyn(lstT, id, BaseBusinessLogic.FieldSortCode, targetSortCode);
            returnValue += BaseBusinessLogic.SetPropertyDyn(lstT, targetId, BaseBusinessLogic.FieldSortCode, sortCode);         
            return returnValue;
        }
        #endregion

        public static string GetPreviousIdDyn(dynamic lstT, string id)
        {
            return GetPreviousIdDyn(lstT, id, BaseBusinessLogic.FieldId);
        }
        public static string GetPreviousIdDyn(dynamic lstT, string id, string field)
        {
            string returnValue = string.Empty;
            foreach (dynamic t in lstT)
            {
                if (ReflectionUtil.GetProperty(t,field).ToString().Equals(id))
                {
                    break;
                }
                returnValue = ReflectionUtil.GetProperty(t, field).ToString().ToString();
            }
            return returnValue;
        }
    }
}