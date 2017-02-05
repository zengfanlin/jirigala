//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Globalization;
using System.Reflection;

namespace DotNet.Utilities
{
    /// <summary>
    ///	AppMessage
    /// 通用讯息控制基类
    /// 
    /// 修改纪录
    /// 
    ///		2007.05.17 版本：1.0	JiRiGaLa 建立，为了提高效率分开建立了类。
    ///	
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.17</date>
    /// </author> 
    /// </summary>
    public partial class AppMessage
    {
        #region public static int GetLanguageResource(object targetObject) 从当前指定的语言包读取信息
        /// <summary>
        /// 从当前指定的语言包读取信息
        /// </summary>
        /// <returns>设置多语言的属性个数</returns>
        public static int GetLanguageResource(object targetObject)
        {
            int returnValue = 0;
            string name = string.Empty;
            Type type = targetObject.GetType();
            // Type type = typeof(TargetObject);
            FieldInfo[] fieldInfo = type.GetFields(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Instance);
            FieldInfo currentFieldInfo;
            string messages = string.Empty;
            for (int i = 0; i < fieldInfo.Length; i++)
            {
                name = fieldInfo[i].Name;
                currentFieldInfo = fieldInfo[i];
                messages = ResourceManagerWrapper.Instance.Get(name);
                if (messages.Length > 0)
                {
                    currentFieldInfo.SetValue(targetObject, messages);
                    returnValue++;
                }
            }
            return returnValue;
        }
        #endregion

        #region public static int GetLanguageResource() 从当前指定的语系包读取信息
        /// <summary>
        /// 从当前指定的语系包读取信息，用了反射循环遍历
        /// </summary>
        /// <returns></returns>
        public static int GetLanguageResource()
        {
            AppMessage appMessage = new AppMessage();
            return GetLanguageResource(appMessage);
        }
        #endregion

        #region public static string Format(string value, params string[] messages) 格式化一个资源字符串
        /// <summary>
        /// 格式化一个资源字符串
        /// </summary>
        /// <param name="value">目标字符串</param>
        /// <param name="messages">传入的信息</param>
        /// <returns>字符串</returns>
        public static string Format(string value, params string[] messages)
        {
            return String.Format(CultureInfo.CurrentCulture, value, messages);
        }
        #endregion

        #region public static string GetMessage(string id) 读取一个资源定义
        /// <summary>
        /// 读取一个资源定义
        /// </summary>
        /// <param name="id">资源主键</param>
        /// <returns>字符串</returns>
        public static string GetMessage(string id)
        {
            return ResourceManagerWrapper.Instance.Get(id);
        }
        #endregion

        #region public static string GetMessage(string id, params string[] messages)
        /// <summary>
        /// 读取一个资源定义
        /// </summary>
        /// <param name="id">资源主键</param>
        /// <param name="messages">传入的信息</param>
        /// <returns>字符串</returns>
        public static string GetMessage(string id, params string[] messages)
        {
            return String.Format(CultureInfo.CurrentCulture, ResourceManagerWrapper.Instance.Get(id), messages);
        }
        #endregion
    }
}