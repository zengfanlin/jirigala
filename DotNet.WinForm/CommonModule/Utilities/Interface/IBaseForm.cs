//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.WinForm
{
    /// <summary>
    /// IBaseForm
    /// 通用窗口的接口
    /// 
    /// 修改纪录
    ///
    ///		2008.05.04 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.05.04</date>
    /// </author> 
    /// </summary>
    public interface IBaseForm
	{
        /// <summary>
        /// 置顶
        /// </summary>
        int SetTop();

        /// <summary>
        /// 上移
        /// </summary>
        int SetUp();

        /// <summary>
        /// 下移
        /// </summary>
        int SetDown();

        /// <summary>
        /// 置底
        /// </summary>
        int SetBottom();

        /// <summary>
        /// 设置排序按钮可用状态
        /// </summary>
        /// <param name="enabled">可用</param>
        void SetSortButton(bool enabled);

        /// <summary>
        /// 添加
        /// </summary>
        string Add();

        /// <summary>
        /// 编辑
        /// </summary>
        void Edit();

        /// <summary>
        /// 删除
        /// </summary>
        int Delete();

        /// <summary>
        /// 保存
        /// </summary>
        void Save();
        
        /// <summary>
        /// 设置控件状态
        /// </summary>
        void SetControlState();

        /// <summary>
        /// 控制按钮状态事件
        /// </summary>
        event BaseForm.SetControlStateEventHandler OnButtonStateChange;
    }
}