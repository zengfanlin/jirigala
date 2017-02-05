//-----------------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2010 , Hairihan TECH, Ltd.  
//-----------------------------------------------------------------------------

using System.Data;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// ILogOnService
    /// 
    /// 修改纪录
    /// 
    ///		2009.04.15 版本：1.0 JiRiGaLa 添加接口定义。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2009.04.15</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface ILogOnService
    {
        /// <summary>
        /// 获得登录用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetUserDT(BaseUserInfo userInfo);

        /// <summary>
        /// 获得内部员工列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns></returns>
        [OperationContract]
        DataTable GetStaffUserDT(BaseUserInfo userInfo);

        /// <summary>
        /// 激活用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="openId">唯一识别码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>用户实体</returns>
        [OperationContract]
        BaseUserInfo AccountActivation(BaseUserInfo userInfo, string openId, out string statusCode, out string statusMessage);

        /// <summary>
        /// 按唯一识别码登录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="openId">唯一识别码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>用户实体</returns>
        [OperationContract]
        BaseUserInfo LogOnByOpenId(BaseUserInfo userInfo, string openId, out string statusCode, out string statusMessage);

        /// <summary>
        /// 按用户名登录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userName">用户名</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>用户实体</returns>
        [OperationContract]
        BaseUserInfo LogOnByUserName(BaseUserInfo userInfo, string userName, out string statusCode, out string statusMessage);

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>登录实体类</returns>
        [OperationContract]
        BaseUserInfo UserLogOn(BaseUserInfo userInfo, string userName, string password, bool createOpenId, out string statusCode, out string statusMessage);

        /// <summary>
        /// 用户在线
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="onLineState">用户在线状态</param>
        [OperationContract(IsOneWay = true)]
        void OnLine(BaseUserInfo userInfo, int onLineState);

        /// <summary>
        /// 用户离线
        /// </summary>
        /// <param name="userInfo">用户</param>
        [OperationContract(IsOneWay = true)]
        void OnExit(BaseUserInfo userInfo);

        /// <summary>
        /// 检查在线状态(服务器专用)
        /// </summary>
        /// <returns>离线人数</returns>
        [OperationContract]
        int ServerCheckOnLine();

        /// <summary>
        /// 设置密码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userIds">被设置的用户主键</param>
        /// <param name="password">新密码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetPassword(BaseUserInfo userInfo, string[] userIds, string password, out string statusCode, out string statusMessage);
        
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="oldPassword">原始密码</param>
        /// <param name="newPassword">新密码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int ChangePassword(BaseUserInfo userInfo, string oldPassword, string newPassword, out string statusCode, out string statusMessage);

        /// <summary>
        /// 修改通讯密码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="oldPassword">原始密码</param>
        /// <param name="newPassword">新密码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int ChangeCommunicationPassword(BaseUserInfo userInfo, string oldPassword, string newPassword, out string statusCode, out string statusMessage);

        /// <summary>
        /// 验证通讯密码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="communicationPassword">通讯密码</param>
        /// <param name="ipAddress">IP地址</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>是否正确</returns>
        [OperationContract]
        bool CommunicationPassword(BaseUserInfo userInfo, string communicationPassword);

        /// <summary>
        /// 设置通讯密码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userIds">被设置的用户主键</param>
        /// <param name="password">新密码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int SetCommunicationPassword(BaseUserInfo userInfo, string[] userIds, string password, out string statusCode, out string statusMessage);

        // 
        // 数字证书签名相关
        //

        /// <summary>
        /// 创建数字证书签名
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="password">密码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>私钥</returns>
        [OperationContract]
        string CreateDigitalSignature(BaseUserInfo userInfo, string password, out string statusCode, out string statusMessage);

        /// <summary>
        /// 获取当前用户的公钥
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userId">用户主键</param>
        /// <returns>公钥</returns>
        [OperationContract]
        string GetPublicKey(BaseUserInfo userInfo, string userId);

        /// <summary>
        /// 修改数字签名密码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="oldPassword">原始密码</param>
        /// <param name="newPassword">新密码</param>
        /// <param name="statusCode">返回状态码</param>
        /// <param name="statusMessage">返回状消息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int ChangeSignedPassword(BaseUserInfo userInfo, string oldPassword, string newPassword, out string statusCode, out string statusMessage);

        /// <summary>
        /// 验证数字签名密码
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="communicationPassword">通讯密码</param>
        /// <param name="ipAddress">IP地址</param>
        /// <returns>是否正确</returns>
        [OperationContract]
        bool SignedPassword(BaseUserInfo userInfo, string communicationPassword);

        /// <summary>
        /// 锁定用户
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="userName">用户名</param>
        /// <returns>是否成功锁定</returns>
        [OperationContract]
        bool LockUser(BaseUserInfo userInfo, string userName);
    }
}