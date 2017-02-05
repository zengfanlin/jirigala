//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd. 
//-------------------------------------------------------------------------------------

using System;

namespace DotNet.Service
{

    /// <summary>
    /// ServerCache
    /// 服务器端缓存功能
    /// 
    /// 修改纪录
    ///
    ///		2008.02.03 版本：1.0 JiRiGaLa 窗体与数据库连接的分离。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.02.03</date>
    /// </author> 
    /// </summary>
    public class ServerCache
    {
        private static ServerCache instance = null;
        private static object locker = new Object();

        public static ServerCache Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (locker)
                    {
                        if (instance == null)
                        {
                            instance = new ServerCache();
                        }
                    }
                }
                return instance;
            }
        }

        private ServerCache()
        {
        }
    }
}