//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

namespace DotNet.Utilities
{
    /// <summary>
    /// StateCode
    /// 程序运行状态。
    /// 
    /// 修改纪录
    /// 
    ///		2007.12.09 版本：1.1 JiRiGaLa 重新命名为 StatusCode。
    ///		2007.12.04 版本：1.0 JiRiGaLa 重新调整主键的规范化。
    ///		
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.18</date>
    /// </author> 
    /// </summary>    
    #region public enum StatusCode 程序运行状态
    public enum StatusCode
    {
        /// <summary>
        /// 00 数据库连接错误。
        /// </summary>
        [EnumDescription("数据库连接错误")]
        DbError = 0,                 
        Error = 9,                      // 09 发生错误。
        OK = 10,                        // 10 运行成功。
        OKAdd = 11,                     // 11 添加成功。
        CanNotLock = 12,                // 12 不能锁定数据。
        LockOK = 13,                    // 13 成功锁定数据。
        OKUpdate = 14,                  // 14 更新数据成功。
        OKDelete = 15,                  // 15 删除成功。
        Exist = 16,                     // 16 数据已重复,不可以重复。
        ErrorCodeExist = 17,            // 17 编号已存在,不可以重复。
        ErrorNameExist = 18,            // 18 名称已重复
        ErrorValueExist = 19,           // 19 值已重复
        ErrorUserExist = 20,            // 20 用户名已重复
        ErrorDataRelated = 22,          // 22 数据已经被引用，有关联数据在。
        ErrorDeleted = 23,              // 23 数据已被其他人删除。
        ErrorChanged = 24,              // 24 数据已被其他人修改。
        NotFound = 25,                  // 25 为找到记录。
        UserNotFound = 26,              // 26 用户没有找到。
        PasswordError = 27,             // 27 密码错误。
        LogOnDeny = 28,                 // 28 登录被拒绝。
        ErrorOnLine = 29,               // 29 只允许登录一次
        ErrorMacAddress = 30,           // 30 是否检查用户的网卡Mac地址
        ErrorIPAddress = 31,            // 31 是否检查用户IP地址
        ErrorOnLineLimit = 32,          // 32 同时在线用户数量限制
        PasswordCanNotBeNull = 33,      // 33 密码不允许为空。
        PasswordCanNotBeRepeat = 34,    // 34 密码不允许重复。
        SetPasswordOK = 35,             // 35 设置密码成功。
        OldPasswordError = 36,          // 36 原密码错误。
        ChangePasswordOK = 37,          // 37 修改密码成功。
        UserNotEmail = 38,              // 38 用户没有电子邮件地址。
        UserLocked = 39,                // 39 用户被锁定。
        UserNotActive = 40,             // 40 用户还未被激活。
        UserIsActivate = 41,            // 41 用户已被激活，不用重复激活。
        ErrorLogOn = 42,                // 42 用户名或密码错误。
        WaitForAudit = 43,              // 43 用户还在待审核状态。
        UserDuplicate = 44              // 44 用户还在待审核状态。
    }
    #endregion
}