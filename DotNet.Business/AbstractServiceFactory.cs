//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Configuration;
using System.Reflection;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// AbstractServiceFactory
    /// 
    /// 修改纪录
    /// 
    ///		2007.12.27 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.12.27</date>
    /// </author> 
    /// </summary>
    public abstract class AbstractServiceFactory
    {
        // Look up the Dao implementation we should be using
        // private static readonly string serviceFactoryClass = ConfigurationManager.AppSettings["ServiceFactory"];
        
        public AbstractServiceFactory() 
        {
        }

        public virtual IServiceFactory GetServiceFactory()
        {
            return GetServiceFactory(BaseSystemInfo.Service);
        }

        public virtual IServiceFactory GetServiceFactory(string servicePath)
        {
            string className = servicePath + "." + BaseSystemInfo.ServiceFactory;
            return (IServiceFactory)Assembly.Load(servicePath).CreateInstance(className);
        }

        public virtual IServiceFactory GetServiceFactory(string servicePath, string serviceFactoryClass)
        {
            string className = servicePath + "." + serviceFactoryClass;
            return (IServiceFactory)Assembly.Load(servicePath).CreateInstance(className);
        }
    }
}