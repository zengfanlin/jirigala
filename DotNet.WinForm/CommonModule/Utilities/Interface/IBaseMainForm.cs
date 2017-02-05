//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.WinForm
{
    /// <summary>
    /// IBaseMainForm
    /// 主窗口的接口
    /// 
    /// 修改纪录
    ///
    ///		2008.10.29 版本：1.1 JiRiGaLa 重新命名。
    ///		2008.05.04 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.05.04</date>
    /// </author> 
    /// </summary>
    public interface IBaseMainForm
	{
        /// <summary>
        /// 初始化窗体
        /// </summary>
        void InitForm();

        /// <summary>
        /// 初始化服务
        /// </summary>
        void InitService();

        /// <summary>
        /// 检查菜单
        /// </summary>
        void CheckMenu();
    }
}