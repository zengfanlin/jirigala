//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// IMessageService
    /// 即时通讯组件接口
    /// 
    /// 修改纪录
    /// 
    ///		2010.10.17 版本：1.1 JiRiGaLa 整理接口函数注释。
    ///		2008.04.15 版本：1.0 JiRiGaLa 创建主键。
    ///		
    /// 版本：1.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.04.15</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface IMessageService
    {
        /// <summary>
        /// 获得内部部门（公司的组织机构）
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetInnerOrganizeDT(BaseUserInfo userInfo);

        /// <summary>
        /// 按组织机构获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="organizeId">部门主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetUserDTByOrganize(BaseUserInfo userInfo, string organizeId);

        /// <summary>
        /// 按角色获取用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="roleId">角色主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetUserDTByRole(BaseUserInfo userInfo, string roleId);

        /// <summary>
        /// 发送即时消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="receiverId">接收者主键</param>
        /// <param name="contents">内容</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Send(BaseUserInfo userInfo, string receiverId, string contents);

        /// <summary>
        /// 发送系统提示消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="receiverId">接收者主键</param>
        /// <param name="contents">内容</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Remind(BaseUserInfo userInfo, string receiverId, string contents);

        /// <summary>
        /// 批量发送即时消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="receiverIds">接收者主键组</param>
        /// <param name="organizeIds">组织机构主键组</param>
        /// <param name="roleIds">角色主键组</param>
        /// <param name="messageEntity">消息实体</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int BatchSend(BaseUserInfo userInfo, string[] receiverIds, string[] organizeIds, string[] roleIds, BaseMessageEntity messageEntity);

        /// <summary>
        /// 广播消息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="message">消息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Broadcast(BaseUserInfo userInfo, string message);

        /// <summary>
        /// 获取消息状态
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="onLineState">用户在线状态</param>
        /// <param name="lastChekDate">最后检查时间</param>
        /// <returns>消息状态数组</returns>
        [OperationContract]
        string[] MessageChek(BaseUserInfo userInfo, int onLineState, string lastChekTime);

        /// <summary>
        /// 获取用户的新信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="openId">单点登录标识</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTableNew(BaseUserInfo userInfo, out string openId);

        /// <summary>
        /// 获取特定用户的新信息
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="receiverId">当前交互的用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable ReadFromReceiver(BaseUserInfo userInfo, string receiverId);

        /// <summary>
        /// 阅读短信
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        [OperationContract]
        void Read(BaseUserInfo userInfo, string id);

        /// <summary>
        /// 检查在线状态
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="onLineState">用户在线状态</param>
        /// <returns>离线人数</returns>
        [OperationContract]
        int CheckOnLine(BaseUserInfo userInfo, int onLineState);

        /// <summary>
        /// 获取在线用户列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetOnLineState(BaseUserInfo userInfo);
    }
}