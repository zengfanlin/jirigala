//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseUserManager
    /// 用户管理
    /// 
    /// 修改纪录
    /// 
    ///		2011.10.17 版本：1.0 JiRiGaLa	主键整理。
    /// 
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.10.17</date>
    /// </author> 
    /// </summary>
    public partial class BaseUserManager : BaseManager
    {
        /// <summary>
        /// 用户密码加密处理功能
        /// 
        /// 用户的密码到底如何加密，数据库中如何存储用户的密码？
        /// 若是明文方式存储，在管理上会有很多漏洞，虽然调试时不方便，当时加密的密码相对是安全的，
        /// 而且最好是密码是不可逆的，这样安全性更高一些，各种不同的系统，这里适当的处理一下就饿可以了。
        /// </summary>
        /// <param name="password">用户密码</param>
        /// <returns>处理后的密码</returns>
        public virtual string EncryptUserPassword(string password)
        {
            // 这里也可以选择不进行处理，不加密
            // return password;
            return DotNet.Utilities.SecretUtil.md5(password, 32);
        }

        /// <summary>
        /// 设置密码
        /// </summary>
        /// <param name="userId">被设置的员工主键</param>
        /// <param name="password">新密码</param>
        /// <returns>影响行数</returns>
        public virtual int SetPassword(string userId, string password)
        {
            #if (DEBUG)
                int milliStart = Environment.TickCount;
            #endif

            int returnValue = 0;
            
            // 密码强度检查
            /*
            if (BaseSystemInfo.CheckPasswordStrength)
            {
                if (password.Length == 0)
                {
                    this.ReturnStatusCode = StatusCode.PasswordCanNotBeNull.ToString();
                    return returnValue;
                }
            }
            */

            // 加密密码
            if (BaseSystemInfo.ServerEncryptPassword)
            {
                password = this.EncryptUserPassword(password);
            }
            // 设置密码字段
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldUserPassword, password));
            parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldChangePasswordDate, null));
            returnValue = this.SetProperty(new KeyValuePair<string, object>(BaseUserEntity.FieldId, userId), parameters);
            if (returnValue == 1)
            {
                this.ReturnStatusCode = StatusCode.SetPasswordOK.ToString();
            }
            else
            {
                // 数据可能被删除
                this.ReturnStatusCode = StatusCode.ErrorDeleted.ToString();
            }
            
            // 写入调试信息
            #if (DEBUG)
                int milliEnd = Environment.TickCount;
                Trace.WriteLine(DateTime.Now.ToString(BaseSystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " " + " BaseUserManager.SetPassword(" + userId + ")");
            #endif

            return returnValue;
        }

        /// <summary>
        /// 批量设置密码
        /// </summary>
        /// <param name="userIds">被设置的员工主键</param>
        /// <param name="password">新密码</param>
        /// <returns>影响行数</returns>
        public virtual int BatchSetPassword(string[] userIds, string password)
        {
            #if (DEBUG)
                int milliStart = Environment.TickCount;
            #endif

            int returnValue = 0;
            // 密码强度检查
            /*
            if (BaseSystemInfo.CheckPasswordStrength)
            {
                if (password.Length == 0)
                {
                    statusCode = StatusCode.PasswordCanNotBeNull.ToString();
                    return returnValue;
                }
            }
            */
            // 加密密码
            if (BaseSystemInfo.ServerEncryptPassword)
            {
                password = this.EncryptUserPassword(password);
            }

            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldUserPassword, password));
            parameters.Add(new KeyValuePair<string, object>(BaseUserEntity.FieldChangePasswordDate, null));
            // 设置密码字段
            returnValue += this.SetProperty(userIds, parameters);

            if (returnValue > 0)
            {
                this.ReturnStatusCode = StatusCode.SetPasswordOK.ToString();
            }
            else
            {
                // 数据可能被删除
                this.ReturnStatusCode = StatusCode.ErrorDeleted.ToString();
            }

            // 写入调试信息
            #if (DEBUG)
                int milliEnd = Environment.TickCount;
                Trace.WriteLine(DateTime.Now.ToString(BaseSystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " " + " BaseUserManager.SetPassword()");
            #endif

            return returnValue;
        }


        /// <summary>
        /// 批量设置通讯密码
        /// </summary>
        /// <param name="userIds">被设置的员工主键</param>
        /// <param name="password">新密码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <returns>影响行数</returns>
        public virtual int BatchSetCommunicationPassword(string[] userIds, string password, out string statusCode)
        {
            #if (DEBUG)
                int milliStart = Environment.TickCount;
            #endif

            int returnValue = 0;
            // 密码强度检查
            if (BaseSystemInfo.CheckPasswordStrength)
            {
                if (password.Length == 0)
                {
                    statusCode = StatusCode.PasswordCanNotBeNull.ToString();
                    return returnValue;
                }
            }
            // 加密密码
            if (BaseSystemInfo.ServerEncryptPassword)
            {
                password = this.EncryptUserPassword(password);
            }
            for (int i = 0; i < userIds.Length; i++)
            {
                // 设置密码字段
                returnValue = this.SetProperty(userIds, new KeyValuePair<string, object>(BaseUserEntity.FieldCommunicationPassword, password));
            }
            if (returnValue > 0)
            {
                statusCode = StatusCode.SetPasswordOK.ToString();
            }
            else
            {
                // 数据可能被删除
                statusCode = StatusCode.ErrorDeleted.ToString();
            }

            // 写入调试信息
            #if (DEBUG)
                int milliEnd = Environment.TickCount;
                Trace.WriteLine(DateTime.Now.ToString(BaseSystemInfo.TimeFormat) + " Ticks: " + TimeSpan.FromMilliseconds(milliEnd - milliStart).ToString() + " " + " BaseUserManager.SetPassword()");
            #endif

            return returnValue;
        }
    }
}