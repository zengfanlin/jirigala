//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.International.Converters.PinYinConverter;

namespace DotNet.Utilities
{
    public class StringUtil
    {
        /// <summary>
        /// 获取子查询条件，这需要处理多个模糊匹配的字符
        /// </summary>
        /// <param name="field">字段</param>
        /// <param name="search">模糊查询</param>
        /// <returns>表达式</returns>
        public static string GetLike(string field, string search)
        {
            string returnValue = string.Empty;
            for (int i = 0; i < search.Length; i++)
            {
                returnValue += field + " LIKE '%" + search[i] + "%' AND ";
            }
            if (!string.IsNullOrEmpty(returnValue))
            {
                returnValue = returnValue.Substring(0, returnValue.Length - 5);
            }
            returnValue = "(" + returnValue + ")";
            return returnValue;
        }

        #region public static string GetSearchString(string searchValue, string allLike = null) 获取查询字符串
        /// <summary>
        /// 获取查询字符串
        /// </summary>
        /// <param name="search">查询字符</param>
        /// <param name="allLike">是否所有的匹配都查询，建议传递"%"字符</param>
        /// <returns>字符串</returns>
        public static string GetSearchString(string searchValue, bool allLike = false)
        {
            searchValue = searchValue.Trim();
            searchValue = SecretUtil.SqlSafe(searchValue);
            if (searchValue.Length > 0)
            {
                searchValue = searchValue.Replace('[', '_');
                searchValue = searchValue.Replace(']', '_');
            }
            if (searchValue == "%")
            {
                searchValue = "[%]";
            }
            if ((searchValue.Length > 0) && (searchValue.IndexOf('%') < 0) && (searchValue.IndexOf('_') < 0))
            {
                if (allLike)
                {
                    string searchLike = string.Empty;
                    for (int i = 0; i < searchValue.Length; i++)
                    {
                        searchLike += "%" + searchValue[i];
                    }
                    searchValue = searchLike + "%";
                }
                else
                {
                    searchValue = "%" + searchValue + "%";
                }
            }
            return searchValue;
        }
        #endregion

        #region  public static bool Exists(string[] ids, string targetString) 判断是否包含的方法
        /// <summary>
        /// 判断是否包含的方法
        /// </summary>
        /// <param name="ids">数组</param>
        /// <param name="targetString">目标值</param>
        /// <returns>包含</returns>
        public static bool Exists(string[] ids, string targetString)
        {
            bool returnValue = false;
            if (ids != null && !string.IsNullOrEmpty(targetString))
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    if (ids[i].Equals(targetString))
                    {
                        returnValue = true;
                        break;
                    }
                }
            }
            return returnValue;
        }
        #endregion

        public static string[] Concat(string[] ids, string id)
        {
            return Concat(ids, new string[] { id });
        }

        #region 合并数组
        /// <summary>
        /// 合并数组
        /// </summary>
        /// <param name="ids">数组</param>
        /// <returns>数组</returns>
        public static string[] Concat(params string[][] ids)
        {
            // 进行合并
            Hashtable hashValues = new Hashtable();
            if (ids != null)
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    if (ids[i] != null)
                    {
                        for (int j = 0; j < ids[i].Length; j++)
                        {
                            if (ids[i][j] != null)
                            {
                                if (!hashValues.ContainsKey(ids[i][j]))
                                {
                                    hashValues.Add(ids[i][j], ids[i][j]);
                                }
                            }
                        }
                    }
                }
            }
            // 返回合并结果
            string[] returnValues = new string[hashValues.Count];
            IDictionaryEnumerator enumerator = hashValues.GetEnumerator();
            int key = 0;
            while (enumerator.MoveNext())
            {
                returnValues[key] = (string)(enumerator.Key.ToString());
                key++;
            }
            return returnValues;
        }
        #endregion

        #region 从目标数组中去除某个值 public static string[] Remove(string[] ids, string id)
        /// <summary>
        /// 从目标数组中去除某个值
        /// </summary>
        /// <param name="ids">数组</param>
        /// <param name="id">目标值</param>
        /// <returns>数组</returns>
        public static string[] Remove(string[] ids, string id)
        {
            // 进行合并
            Hashtable hashValues = new Hashtable();
            if (ids != null)
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    if (ids[i] != null && (!ids[i].Equals(id)))
                    {
                        if (!hashValues.ContainsKey(ids[i]))
                        {
                            hashValues.Add(ids[i], ids[i]);
                        }
                    }
                }
            }
            // 返回合并结果
            string[] returnValues = new string[hashValues.Count];
            IDictionaryEnumerator enumerator = hashValues.GetEnumerator();
            int key = 0;
            while (enumerator.MoveNext())
            {
                returnValues[key] = (string)(enumerator.Key.ToString());
                key++;
            }
            return returnValues;
        }
        #endregion


        public static string ArrayToList(string[] ids)
        {
            return ArrayToList(ids, string.Empty);
        }

        public static string ArrayToList(string[] ids, string separativeSign)
        {
            int rowCount = 0;
            string returnValue = string.Empty;
            foreach (string id in ids)
            {
                rowCount++;
                returnValue += separativeSign + id + separativeSign + ",";
            }
            if (rowCount == 0)
            {
                returnValue = "";
            }
            else
            {
                returnValue = returnValue.TrimEnd(',');
            }
            return returnValue;
        }

        #region public static string RepeatString(string targetString, int repeatCount) 重复字符串
        /// <summary>
        /// 重复字符串
        /// </summary>
        /// <param name="targetString">目标字符串</param>
        /// <param name="repeatCount">重复次数</param>
        /// <returns>结果字符串</returns>
        public static string RepeatString(string targetString, int repeatCount)
        {
            string returnValue = string.Empty;
            for (int i = 0; i < repeatCount; i++)
            {
                returnValue += targetString;
            }
            return returnValue;
        }
        #endregion

        /// <summary>
        /// 获取汉字的拼音首字母
        /// </summary>
        /// <param name="targetValue">目标汉字</param>
        /// <returns>拼音</returns>
        public static string GetFirstPinyin(string targetValue)
        {
            string returnValue = string.Empty;
            if (!string.IsNullOrEmpty(targetValue))
            {
                foreach (Char c in targetValue)
                {
                    if (ChineseChar.IsValidChar(c))
                    {
                        ChineseChar chineseChar = new ChineseChar(c);
                        // 汉字的所有拼音拼写
                        ReadOnlyCollection<string> pinyins = chineseChar.Pinyins;
                        returnValue += pinyins[0].Substring(0, 1).ToUpper();
                    }
                }
            }
            return returnValue;
        }

        /// <summary>
        /// 获取汉字的拼音
        /// </summary>
        /// <param name="targetValue">目标汉字</param>
        /// <param name="pinYinOnly">只要拼音</param>
        /// <returns>拼音</returns>
        public static string GetPinyin(string targetValue, bool pinYinOnly = true)
        {
            string returnValue = string.Empty;
            if (!string.IsNullOrEmpty(targetValue))
            {
                foreach (Char c in targetValue)
                {
                    if (ChineseChar.IsValidChar(c))
                    {
                        ChineseChar chineseChar = new ChineseChar(c);
                        // 汉字的所有拼音拼写
                        ReadOnlyCollection<string> pinyins = chineseChar.Pinyins;
                        returnValue += pinyins[0].Substring(0, pinyins[0].Length - 1).ToLower();
                    }
                    else
                    {
                        if (!pinYinOnly)
                        {
                            returnValue += c;
                        }
                    }
                }
            }
            return returnValue;
        }

        /// <summary>
        /// 删除不可见字符
        /// </summary>
        /// <param name="sourceString"></param>
        /// <returns></returns>
        public static string DeleteUnVisibleChar(string sourceString)
        {
            var sBuilder = new StringBuilder(131);
            for (int i = 0; i < sourceString.Length; i++)
            {
                int Unicode = sourceString[i];
                if (Unicode >= 16)
                {
                    sBuilder.Append(sourceString[i].ToString());
                }
            }
            return sBuilder.ToString();
        }
    }
}