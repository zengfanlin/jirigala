//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Utilities;

    /// <summary>
    ///	BaseCheckInput
    /// 通用输入检查基类
    /// 
    /// 修改纪录
    ///		2007.05.21 版本：1.0 JiRiGaLa U盘坏了，还真闹心啊。
    ///	
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.21</date>
    /// </author> 
    /// </summary>
    public class BaseCheckInput
    {
        #region public static bool CheckEmpty(System.Windows.Forms.Control Control, string message) 判断字符串是否为空
        /// <summary>
        /// 判断字符串是否为空
        /// </summary>
        /// <param name="Control">输入控件</param>
        /// <param name="message">提示信息</param>
        /// <returns>是否为空</returns>
        public static bool CheckEmpty(System.Windows.Forms.Control Control, string message)
        {
            // 返回值
            bool returnValue = true;
            if (Control.Text.Length == 0)
            {
                returnValue = false;
                Control.Focus();
                Control.Select();
                if (message.Length > 0)
                {
                    System.Windows.Forms.MessageBox.Show(message, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return returnValue;
        }
        #endregion

        #region public static bool CheckEmail(System.Windows.Forms.Control Control, string message) 判断字符串是否为电子邮件地址
        /// <summary>
        /// 判断字符串是否为电子邮件地址
        /// </summary>
        /// <param name="Control">输入控件</param>
        /// <param name="message">提示信息</param>
        /// <returns>是否电子邮件地址</returns>
        public static bool CheckEmail(System.Windows.Forms.Control Control, string message)
        {
            // 返回值
            bool returnValue = true;
            string email = Control.Text;
            // 文件夹名字验证，需要多一些才可以
            if (!ValidateUtil.IsEmail(email))
            {
                MessageBox.Show(message, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Control.Focus();
                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        public static bool CheckFolderName(System.Windows.Forms.Control Control, string message)
        {
            // 返回值
            bool returnValue = true;
            string folderName = Control.Text;
            // 文件夹名字验证，需要多一些才可以
            if (!ValidateUtil.CheckFolderName(folderName))
            {
                MessageBox.Show(message, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Control.Focus();
                returnValue = false;
            }
            return returnValue;
        }

        public static bool CheckFileName(System.Windows.Forms.Control Control, string message)
        {
            // 返回值
            bool returnValue = true;
            string fileName = Control.Text;
            if (!ValidateUtil.CheckFileName(fileName))
            {
                MessageBox.Show(message, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Control.Focus();
                returnValue = false;
            }
            return returnValue;
        }

        public static bool CheckPasswordStrength(System.Windows.Forms.Control Control)
        {
            // 返回值
            bool returnValue = true;
            string password = Control.Text;
            if (!ValidateUtil.CheckPasswordStrength(password))
            {
                MessageBox.Show(AppMessage.MSG8000, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Control.Focus();
                returnValue = false;
            }
            return returnValue;
        }
    }
}