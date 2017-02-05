//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Data;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// ISequenceService
    /// 序列接口
    /// 
    /// 修改纪录
    /// 
    ///		2011.02.24 版本：1.1 JiRiGaLa 获取原来序列号的功能完善。
    ///		2008.10.10 版本：1.0 JiRiGaLa 创建主键。
    ///		
    /// 版本：1.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.02.24</date>
    /// </author> 
    /// </summary>
    [ServiceContract]
    public interface ISequenceService
    {
        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>实体</returns>
        [OperationContract]
        BaseSequenceEntity GetEntity(BaseUserInfo userInfo, string id);

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="sequenceEntity">序列实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>主键</returns>
        [OperationContract]
        string Add(BaseUserInfo userInfo, BaseSequenceEntity sequenceEntity, out string statusCode, out string statusMessage);

        /// <summary>
        /// 更新序列
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="sequenceEntity">序列实体</param>
        /// <param name="statusCode">状态码</param>
        /// <param name="statusMessage">状态信息</param>
        /// <returns>影响行数</returns>
        [OperationContract]
        int Update(BaseUserInfo userInfo, BaseSequenceEntity sequenceEntity, out string statusCode, out string statusMessage);
        
        /// <summary>
        /// 获取序列号列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        [OperationContract]
        DataTable GetDataTable(BaseUserInfo userInfo);

        /// <summary>
        /// 获取序列号
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">序列名称</param>
        /// <returns>序列号</returns>
        [OperationContract]
        string GetSequence(BaseUserInfo userInfo, string fullName);

        /// <summary>
        /// 获取原序列号
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">序列名称</param>
        /// <param name="defaultSequence">默认序列</param>
        /// <param name="sequenceLength">序列长度</param>
        /// <param name="fillZeroPrefix">是否填充补零</param>
        /// <returns>序列号</returns>
        [OperationContract]
        string GetOldSequence(BaseUserInfo userInfo, string fullName, int defaultSequence, int sequenceLength, bool fillZeroPrefix);

        /// <summary>
        /// 获取新序列号
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">序列名称</param>
        /// <param name="defaultSequence">默认序列</param>
        /// <param name="sequenceLength">序列长度</param>
        /// <param name="fillZeroPrefix">是否填充补零</param>
        /// <returns>序列号</returns>
        [OperationContract]
        string GetNewSequence(BaseUserInfo userInfo, string fullName, int defaultSequence, int sequenceLength, bool fillZeroPrefix);
       
        /// <summary>
        /// 获取序列号
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">序列名称</param>
        /// <param name="count">个数</param>
        /// <returns>序列号</returns>
        [OperationContract]
        string[] GetBatchSequence(BaseUserInfo userInfo, string fullName, int count);
        
        /// <summary>
        /// 获取倒序序列号
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="fullName">序列名称</param>
        /// <returns>序列号</returns>
        [OperationContract]
        string GetReduction(BaseUserInfo userInfo, string fullName);

        /// <summary>
        /// 批量重置
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>数据表</returns>
        [OperationContract]
        int Reset(BaseUserInfo userInfo, string[] ids);

        /// <summary>
        /// 批量删除日志
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">主键</param>
        /// <returns>数据表</returns>
        [OperationContract]
        int Delete(BaseUserInfo userInfo, string id);

        /// <summary>
        /// 批量删除权限
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="ids">主键数组</param>
        /// <returns>数据表</returns>
        [OperationContract]
        int BatchDelete(BaseUserInfo userInfo, string[] ids);
    }
}