//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.Utilities
{
    /// <summary>
    /// BaseSystemInfo
    /// 这是系统的核心基础信息部分
    /// 
    /// 修改记录
    ///		2012.04.14 版本：1.0 JiRiGaLa	主键创建。
    ///		
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.04.14</date>
    /// </author>
    /// </summary>
    public partial class BaseSystemInfo
    {
        private static BaseUserInfo userInfo = null;

        /// <summary>
        /// 当前登录系统的用户信息
        /// </summary>
        public static BaseUserInfo UserInfo
        {
            get
            {
                if (userInfo == null)
                {
                    userInfo = new BaseUserInfo();
                    // IP地址
                    if (String.IsNullOrEmpty(userInfo.IPAddress))
                    {
                        userInfo.IPAddress = MachineInfo.GetIPAddress();
                    }
                    //Mac地址  add by zgl
                    if (String.IsNullOrEmpty(userInfo.MACAddress))
                    {
                        userInfo.MACAddress = MachineInfo.GetMacAddress();
                    }

                    // 主键
                    if (String.IsNullOrEmpty(userInfo.Id))
                    {
                        userInfo.Id = MachineInfo.GetIPAddress();
                    }
                    // 用户名
                    if (String.IsNullOrEmpty(userInfo.UserName))
                    {
                        userInfo.UserName = System.Environment.MachineName;
                    }
                    // 真实姓名
                    if (String.IsNullOrEmpty(userInfo.RealName))
                    {
                        userInfo.RealName = System.Environment.UserName;
                    }
                    userInfo.ServiceUserName = BaseSystemInfo.ServiceUserName;
                    userInfo.ServicePassword = BaseSystemInfo.ServicePassword;
                }
                return userInfo;
            }
            set
            {
                userInfo = value;
            }
        }

        /// <summary>
        /// 验证用户是否是授权的用户
        /// 不是任何人都可以调用服务的，将来这里还可以进行扩展的
        /// 例如用IP地址限制等等
        /// 这里应该能抛出异常才可以
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>验证成功</returns>
        public static bool IsAuthorized(BaseUserInfo userInfo)
        {
            if (userInfo == null)
            {
                return false;
            }
            // 若系统设置的用户名是空的，那就不用判断了
            if (string.IsNullOrEmpty(ServiceUserName))
            {
                return true;
            }
            // 若系统设置的用密码是空的，那就不用判断了
            if (string.IsNullOrEmpty(ServicePassword))
            {
                return true;
            }
            // 调用服务器的用户名、密码都对了，才可以调用服务程序，否则认为是非授权的操作
            if (ServiceUserName.Equals(userInfo.ServiceUserName) && ServicePassword.Equals(userInfo.ServicePassword))
            {
                return true;
            }
            return false;
        }
    }
}