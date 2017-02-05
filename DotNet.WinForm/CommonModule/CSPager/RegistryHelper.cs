//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using Microsoft.Win32;

namespace DotNet.WinForm
{
    public sealed class RegistryHelper
    {
        private static string softwareKey = @"Software\DeepLand\OrderWater";

        /// <summary>
        /// Gets the value by registry key. If the key does not exist, return empty string.
        /// </summary>
        /// <param name="key">registry key</param>
        /// <returns>Returns the value of the specified key.</returns>
        public static string GetValue(string key)
        {
            const string parameter = "key";
            if (null == key)
            {
                throw new ArgumentNullException(parameter);
            }

            string strRet = string.Empty;
            try
            {
                RegistryKey regKey = Registry.CurrentUser.OpenSubKey(softwareKey);
                strRet = regKey.GetValue(key).ToString();
            }
            catch
            {
                strRet = "";
            }
            return strRet;
        }

        /// <summary>
        /// Saves the key and the value to registry.
        /// </summary>
        /// <param name="key">registry key</param>
        /// <param name="value">the value of the key</param>
        /// <returns>Returns true if successful, otherwise return false.</returns>
        public static bool SaveValue(string key, string value)
        {
            const string parameter1 = "key";
            const string parameter2 = "value";
            if (null == key)
            {
                throw new ArgumentNullException(parameter1);
            }

            if (null == value)
            {
                throw new ArgumentNullException(parameter2);
            }

            bool bReturn = false;
            RegistryKey reg;
            reg = Registry.CurrentUser.OpenSubKey(softwareKey, true);

            if (null == reg)
            {
                reg = Registry.CurrentUser.CreateSubKey(softwareKey);
            }
            reg.SetValue(key, value);

            return bReturn;
        }
    }
}