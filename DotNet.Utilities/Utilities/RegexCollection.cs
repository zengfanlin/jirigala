//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.Utilities
{
    /// <summary>
    /// EnumRegex
    /// 枚举状态的说明。
    /// 
    /// 修改纪录
    /// 
    ///		2012.02.04 版本：1.1 JiRiGaLa 重新排版。
    ///		2011.10.13 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：1.1
    /// 
    /// <author>
    ///		<name>zgl</name>
    ///		<date>2012.04.11</date>
    /// </author> 
    /// </summary>    
    public static class RegexCollection 
    {
        public static string PositiveInteger = @"^[0-9]*[1-9][0-9]*$";// 正整数正则表达式
        public static string Integer = @"^-?\d+$";// 整数正则表达式
        public static string Float = @"^[+|-]?\d*\.?\d*$";// 浮点数正则表达式
    }
}