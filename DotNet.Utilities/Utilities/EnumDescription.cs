//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.Utilities
{
    /// <summary>
    /// EnumDescription
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
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.02.04</date>
    /// </author> 
    /// </summary>    
    public class EnumDescription : Attribute
    {
        private string _text;

        public string Text
        {
            get
            {
                return _text;
            }
        }

        public EnumDescription(string text)
        {
            _text = text;
        }
    }
}