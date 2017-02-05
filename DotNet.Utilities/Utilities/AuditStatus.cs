//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.Utilities
{
    /// <summary>
    /// AuditStatus
    /// 审核状态。
    /// 
    /// 修改纪录
    /// 
    ///     2011.10.13 版本：1.0 JiRiGaLa 改进枚举类型的说明。
    ///		2009.09.04 版本：1.0 JiRiGaLa 重新调整主键的规范化。
    ///		
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2009.09.04</date>
    /// </author> 
    /// </summary>    
    #region public enum AuditStatus 审核状态
    public enum AuditStatus
    {
        /// <summary>
        /// 00 草稿状态
        /// </summary>
        [EnumDescription("草稿")]
        Draft = 0,

        /// <summary>
        /// 01 开始审核,送审
        /// </summary>
        [EnumDescription("提交")]
        StartAudit = 1,

        /// <summary>
        /// 02 审核通过
        /// </summary>
        [EnumDescription("通过")]
        AuditPass = 2,

        /// <summary>
        /// 03 待审核
        /// </summary>
        [EnumDescription("待审")]
        WaitForAudit = 3,

        /// <summary>
        /// 04 转发
        /// </summary>
        [EnumDescription("转发")]
        Transmit = 4,

        /// <summary>
        /// 05 已退回
        /// </summary>
        [EnumDescription("退回")]
        AuditReject = 5,

        /// <summary>
        /// 06 审核结束
        /// </summary>
        [EnumDescription("完成")]
        AuditComplete = 6,

        /// <summary>
        /// 07 撤销,废弃
        /// </summary>
        [EnumDescription("废弃")]
        AuditQuash = 7
    }
    #endregion
}