//------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2008 , ESSE , Ltd. 
//------------------------------------------------------------

using System;
using System.Data;
using System.Reflection;
using System.Diagnostics;

namespace ESSE.Common.Service
{
    using ESSE.Common;
    using ESSE.Common.Domain;
    using ESSE.Common.Utilities;
    using ESSE.Common.DbUtilities;
    using ESSE.Common.Persistence;

    /// <summary>
    /// ImpersonationService
    /// 
    /// 修改纪录
    /// 
    ///		2007.08.18 版本：2.3 JiRiGaLa 将 文件名修改为 ImpersonationService 。
    ///		2007.08.15 版本：2.1 JiRiGaLa 改进运行速度采用 WebService 变量定义 方式处理数据。
    ///		2007.08.14 版本：2.0 JiRiGaLa 改进运行速度采用 Instance 方式处理数据。
    ///		2007.08.16 版本：2.2 JiRiGaLa 将 Impersonation 函数转移到此类中。
    ///		2007.08.15 版本：2.1 JiRiGaLa 改进运行速度采用 WebService 变量定义 方式处理数据。
    ///		2007.08.14 版本：2.0 JiRiGaLa 改进运行速度采用 Instance 方式处理数据。
    ///		2007.08.02 JiRiGaLa 建立代码。
    ///		
    /// 版本：2.3
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.08.18</date>
    /// </author> 
    /// </summary>
    public class ImpersonationService : System.MarshalByRefObject
    {
        private static ImpersonationService instance = null;
        private static Object locker = new Object();

        public static ImpersonationService Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new ImpersonationService();
                        }
                    }
                }
                return instance;
            }
        }

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