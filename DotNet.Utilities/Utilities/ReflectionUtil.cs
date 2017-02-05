//-----------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace DotNet.Utilities
{
    public sealed class ReflectionUtil
    {
        private ReflectionUtil()
        {
        }

        public static BindingFlags bf = BindingFlags.DeclaredOnly | BindingFlags.Public |
                                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;

        public static object InvokeMethod(object obj, string methodName, object[] args)
        {
            object objReturn = null;
            Type type = obj.GetType();
            objReturn = type.InvokeMember(methodName, bf | BindingFlags.InvokeMethod, null, obj, args);
            return objReturn;
        }

        public static void SetField(object obj, string name, object value)
        {
            FieldInfo fi = obj.GetType().GetField(name, bf);
            fi.SetValue(obj, value);
        }

        public static object GetField(object obj, string name)
        {
            FieldInfo fi = obj.GetType().GetField(name, bf);
            return fi.GetValue(obj);
        }

        /// <summary>
        /// 设置对象属性的值
        /// </summary>
        public static void SetProperty(object obj, string name, object value)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(name, bf);
            object objValue = ChangeType2(value, propertyInfo.PropertyType);
            propertyInfo.SetValue(obj, objValue, null);
        }
        public static object ChangeType2(object value, Type conversionType)
        {
            if (value is DBNull || value == null||string.IsNullOrWhiteSpace(value.ToString()))
                return null;
            if (conversionType.IsGenericType && conversionType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                System.ComponentModel.NullableConverter nullableConverter
                    = new System.ComponentModel.NullableConverter(conversionType);
                conversionType = nullableConverter.UnderlyingType;
            }

            return Convert.ChangeType(value, conversionType);
        }
        /// <summary>
        /// 获取对象属性的值
        /// </summary>
        public static object GetProperty(object obj, string name)
        {
            PropertyInfo propertyInfo = obj.GetType().GetProperty(name, bf);
            return propertyInfo.GetValue(obj, null);
        }

        /// <summary>
        /// 获取对象属性信息（组装成字符串输出）
        /// </summary>
        public static List<string> GetPropertyNames(object obj)
        {
            List<string> nameList = new List<string>();
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties(bf);

            foreach (PropertyInfo property in propertyInfos)
            {
                nameList.Add(property.Name);
            }

            return nameList;
        }

        /// <summary>
        /// 获取对象属性信息（组装成字符串输出）
        /// </summary>
        public static Dictionary<string,string> GetPropertyNameTypes(object obj)
        {
            Dictionary<string, string> nameList = new Dictionary<string, string>();
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties(bf);

            foreach (PropertyInfo property in propertyInfos)
            {
                nameList.Add(property.Name, property.PropertyType.FullName);
            }

            return nameList;
        }

        public static DataTable CreateTable(object objSource)
        {
            DataTable table = null;
            IEnumerable objList = objSource as IEnumerable;
            foreach (object obj in objList)
            {
                if (table == null)
                {
                    List<string> nameList = ReflectionUtil.GetPropertyNames(obj);
                    table = new DataTable("");
                    DataColumn column;

                    foreach (string name in nameList)
                    {
                        column = new DataColumn();
                        column.DataType = System.Type.GetType("System.String");
                        column.ColumnName = name;
                        column.Caption = name;
                        table.Columns.Add(column);
                    }
                }

                DataRow row = table.NewRow();
                PropertyInfo[] propertyInfos = obj.GetType().GetProperties(bf);
                foreach (PropertyInfo property in propertyInfos)
                {
                    row[property.Name] = property.GetValue(obj, null);                    
                }
                table.Rows.Add(row);
            }

            return table;
        }
    }
}