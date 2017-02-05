//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Reflection;

namespace DotNet.Utilities
{
    /// <summary>
    /// EnumDescription
    /// 枚举状态的说明。
    /// 
    /// 修改纪录
    /// 
    ///		2011.10.13 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.10.13</date>
    /// </author> 
    /// </summary>    
    public static class EnumExtensions
    {
        public static string ToDescription(this Enum enumeration) 
        {
            Type type = enumeration.GetType();
            MemberInfo[] memInfo = type.GetMember(enumeration.ToString());
            if (null != memInfo && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(EnumDescription), false);
                if (null != attrs && attrs.Length > 0)
                {
                    return ((EnumDescription)attrs[0]).Text;
                }
            }
            return enumeration.ToString(); 
        }
    }
}