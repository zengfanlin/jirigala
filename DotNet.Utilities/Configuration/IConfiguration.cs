//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd.  
//-----------------------------------------------------------------

using System;

namespace DotNet.Utilities
{
    /// <summary>
    /// IConfiguration
    /// 读取配置文件接口定义
    /// 
    /// 修改纪录
    /// 
    ///		2009.07.08 版本：1.0 JiRiGaLa 创建代码。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2009.07.08</date>
    /// </author> 
    /// </summary>
    public interface IConfiguration
    {
        string GetValue(String key);
    }
}
