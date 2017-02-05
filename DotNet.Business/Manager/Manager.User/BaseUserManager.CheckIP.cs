//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    /// <summary>
    /// BaseUserManager
    /// 用户管理
    /// 
    /// 修改纪录
    /// 
    ///		2011.10.17 版本：1.0 JiRiGaLa	主键整理。
    /// 
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.10.17</date>
    /// </author> 
    /// </summary>
    public partial class BaseUserManager : BaseManager
    {
        #region private bool CheckIPAddress(string ipAddress, string userId) 检查用户IP地址
        /// <summary>
        /// 检查用户IP地址
        /// </summary>
        /// <param name="ipAddress">IP地址</param>
        /// <returns>是否符合限制</returns>
        private bool CheckIPAddress(string ipAddress, string userId)
        {
            bool returnValue = false;

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldParameterId, userId));
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldCategoryId, "IPAddress"));
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldEnabled, 1));

            DataTable dt = DbLogic.GetDataTable(this.DbHelper, BaseParameterEntity.TableName, parameters);
            if (dt.Rows.Count > 0)
            {
                string parameterCode = string.Empty;
                string parameterCotent = string.Empty;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    parameterCode = dt.Rows[i][BaseParameterEntity.FieldParameterCode].ToString();
                    parameterCotent = dt.Rows[i][BaseParameterEntity.FieldParameterContent].ToString();
                    switch (parameterCode)
                    {
                        // 匹配单个IP
                        case "Single":
                            returnValue = CheckSingleIPAddress(ipAddress, parameterCotent);
                            break;
                        // 匹配ip地址段
                        case "Range":
                            returnValue = CheckIPAddressWithRange(ipAddress, parameterCotent);
                            break;
                        // 匹配带掩码的地址段
                        case "Mask":
                            returnValue = CheckIPAddressWithMask(ipAddress, parameterCotent);
                            break;
                    }
                    if (returnValue) break;
                }
            }
            return returnValue;
        }
        /// <summary>
        /// 检查是否匹配单个IP
        /// </summary>
        /// <param name="ipAddress"></param>
        /// <param name="sourceIp"></param>
        /// <returns></returns>
        private bool CheckSingleIPAddress(string ipAddress, string sourceIp)
        {
            return ipAddress.Equals(sourceIp);
        }
        /// <summary>
        /// 检查是否匹配地址段
        /// </summary>
        /// <param name="ipAddress">192.168.0.8</param>
        /// <param name="ipRange">192.168.0.1-192.168.0.10</param>
        /// <returns></returns>
        private bool CheckIPAddressWithRange(string ipAddress, string ipRange)
        {
            //先判断符合192.168.0.1-192.168.0.10 的正则表达式

            //在判断ipAddress是否有效
            string startIp = ipRange.Split('-')[0];
            string endIp = ipRange.Split('-')[1];
            //如果大于等于 startip 或者 小于等于endip
            if (CompareIp(ipAddress, startIp) == 2 && CompareIp(ipAddress, endIp) == 0 || CompareIp(ipAddress, startIp) == 1 || CompareIp(ipAddress, endIp) == 1)
            {
                return true;
            }
            return false;

        }
        /// <summary>
        /// 比较两个IP地址，比较前可以先判断是否是IP地址
        /// </summary>
        /// <param name="ip1"></param>
        /// <param name="ip2"></param>
        /// <returns>1：相等;  0：ip1小于ip2 ; 2：ip1大于ip2；-1 不符合ip正则表达式 </returns>
        public int CompareIp(string ip1, string ip2)
        {
            //if (!IsIP(ip1) || !IsIP(ip2))
            //{
            //    return -1;

            //}

            String[] arr1 = ip1.Split('.');
            String[] arr2 = ip2.Split('.');
            for (int i = 0; i < arr1.Length; i++)
            {
                int a1 = int.Parse(arr1[i]);
                int a2 = int.Parse(arr2[i]);
                if (a1 > a2)
                {
                    return 2;
                }
                else if (a1 < a2)
                {
                    return 0;
                }
            }
            return 1;

        }
        /// <summary>
        /// 检查是否匹配带通配符的IP地址
        /// </summary>
        /// <param name="ipAddress">192.168.1.1</param>
        /// <param name="ipWithMask">192.168.1.*</param>
        /// <returns></returns>
        private bool CheckIPAddressWithMask(string ipAddress, string ipWithMask)
        {
            //先判断是否符合192.168.1.*

            //然后判断
            string[] arr1 = ipAddress.Split('.');
            string[] arr2 = ipWithMask.Split('.');
            for (int i = 0; i < arr1.Length; i++)
            {
                if (!(arr2[i].Equals("*") || arr1[i].Equals(arr2[i])))
                {
                    return false;
                }
            }
            return true;
        }

        #endregion

        private bool CheckIPAddress(string[] ipAddress, string userId)
        {
            bool returnValue = false;
            for (int i = 0; i < ipAddress.Length; i++)
            {
                if (this.CheckIPAddress(ipAddress[i], userId))
                {
                    returnValue = true;
                    break;
                }
            }
            return returnValue;
        }

        #region private bool CheckMacAddress(string macAddress, string userId) 检查用户的网卡Mac地址
        /// <summary>
        /// 检查用户的网卡Mac地址
        /// </summary>
        /// <param name="macAddress">Mac地址</param>
        /// <returns>是否符合限制</returns>
        private bool CheckMacAddress(string macAddress, string userId)
        {
            bool returnValue = false;

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldParameterId, userId));
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldCategoryId, "MacAddress"));
            parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldEnabled, 1));

            DataTable dt = DbLogic.GetDataTable(this.DbHelper, BaseParameterEntity.TableName, parameters);
            if (dt.Rows.Count > 0)
            {
                string parameterCode = string.Empty;
                string parameterCotent = string.Empty;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    parameterCode = dt.Rows[i][BaseParameterEntity.FieldParameterCode].ToString();
                    parameterCotent = dt.Rows[i][BaseParameterEntity.FieldParameterContent].ToString();
                    returnValue = (macAddress.ToLower()).Equals(parameterCotent.ToLower());//简单格式化一下
                    if (returnValue) break;
                }
            }
            return returnValue;
        }
        #endregion

        private bool CheckMacAddress(string[] macAddress, string userId)
        {
            bool returnValue = false;
            for (int i = 0; i < macAddress.Length; i++)
            {
                if (this.CheckMacAddress(macAddress[i], userId))
                {
                    returnValue = true;
                    break;
                }
            }
            return returnValue;
        }
    }
}