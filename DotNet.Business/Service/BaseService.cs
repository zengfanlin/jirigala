//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd. 
//-------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;

namespace DotNet.Service
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseService
    /// 基础服务类。
    /// 
    /// 修改纪录
    /// 
    ///		2010.07.14 版本：1.0 JiRiGaLa 创建。
    /// 
    /// 版本：1.3
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010.07.14</date>
    /// </author> 
    /// </summary>
    public class BaseService
    {
        /// <summary>
        /// 用户中心数据库连接
        /// </summary>
        private readonly string UserCenterDbConnection = BaseSystemInfo.UserCenterDbConnection;

        #region public void Load()
        /// <summary>
        /// 加载服务层
        /// </summary>
        public void Load()
        {
        }
        #endregion
    }
}
