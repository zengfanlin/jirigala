//-------------------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2011 , Hairihan TECH, Ltd. 
//-------------------------------------------------------------------------------------

namespace DotNet.Service
{
    /// <summary>
    /// Singleton
    /// 单实例
    /// 
    /// 修改纪录
    /// 
    ///		2007.12.30 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.12.30</date>
    /// </author> 
    /// </summary>
    public class Singleton<T>
    {
        private static T _instance;

        public Singleton()
        {
        }

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    // 获得实例，使用这个方法的前提是t要有公有的、无参数的构造函数
                    _instance = (T)System.Activator.CreateInstance(typeof(T));
                }
                return _instance;
            }
        }
    }
}