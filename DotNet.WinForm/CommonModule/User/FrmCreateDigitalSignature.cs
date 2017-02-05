//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Windows.Forms;
using System.Xml;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;
    

    /// <summary>
    /// FrmCreateDigitalSignature.cs
    /// 创建签名密钥
    ///		
    /// 修改记录
    ///     
    ///     2011.05.19 版本：1.3 JiRiGaLa  写入文件时的异常处理，重新生成密钥等。
    ///     2011.05.19 版本：1.2 JiRiGaLa  目标文件是否存在？是否覆盖的提醒？
    ///     2011.05.19 版本：1.1 JiRiGaLa  生成密钥时判断是否已经生成。
    ///     2011.05.12 版本：1.0 JiRiGaLa  用户修改密码页面编写。
    ///		
    /// 版本：1.3
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.05.19</date>
    /// </author> 
    /// </summary>
    public partial class FrmCreateDigitalSignature : BaseForm
    {
        public FrmCreateDigitalSignature()
        {
            // 已弹出窗口方式运行
            this.ShowDialogOnly = true;
            InitializeComponent();
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 密码强度检查
            this.lblConfirmPasswordReq.Visible = BaseSystemInfo.CheckPasswordStrength;
            this.lblNewPasswordReq.Visible = BaseSystemInfo.CheckPasswordStrength;
        }
        #endregion

        public override void FormOnLoad()
        {
            // 这里读取用户参数，用户把数字证书导出到什么文件夹了，就记录下来。
            string filePath = DotNetService.Instance.ParameterService.GetParameter(UserInfo, "User", this.UserInfo.Id, "DigitalSignatureFilePath");
            this.txtOutput.Text = filePath;

            base.FormOnLoad();

            // 这里提示签名是否已经生成过，若已在银行报备过签名，需要重新向银行提交新签名。
            string publicKey = DotNetService.Instance.LogOnService.GetPublicKey(UserInfo, UserInfo.Id);
            if (!string.IsNullOrEmpty(publicKey))
            {
                MessageBox.Show("签名密钥已成功生成过，若在银已行报备过此数字签名，重新生成后需向银行提交新数字签名备案。", AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #region private void ClearPassword() 清除密码
        /// <summary>
        /// 清除密码
        /// </summary>
        private void ClearPassword()
        {
            this.txtPassword.Text = string.Empty;
            this.txtConfirmPassword.Text = string.Empty;
            this.txtPassword.Focus();
        }
        #endregion

        #region public override bool CheckInput() 加查输入的有效性
        /// <summary>
        /// 加查输入的有效性
        /// </summary>
        public override bool CheckInput()
        {
            // 密码强度检查
            if (BaseSystemInfo.CheckPasswordStrength)
            {
                // 密码为空
                if (this.txtPassword.Text.Length == 0)
                {
                    // 判断是否为确认按钮
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9959), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtPassword.Focus();
                    return false;
                }
                // 确认密码为空
                if (this.txtConfirmPassword.Text.Length == 0)
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9960), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtConfirmPassword.Focus();
                    return false;
                }
                if (!BaseCheckInput.CheckPasswordStrength(this.txtPassword))
                {
                    return false;
                }
            }
            // 密码不一致
            if (this.txtConfirmPassword.Text != this.txtPassword.Text)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0039, AppMessage.MSG9959, AppMessage.MSG9960), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ClearPassword();
                return false;
            }
            if (string.IsNullOrEmpty(this.txtOutput.Text))
            {
                MessageBox.Show("请选择数字证书输出目录。", AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }
        #endregion

        /// <summary>
        /// 保存签名密钥
        /// </summary>
        /// <param name="privateKey">密钥</param>
        /// <param name="password">签名密码</param>
        /// <returns>是否成功</returns>
        private bool SaveDigitalSignature(string privateKey, string password)
        {
            bool returnValue = false;

            // 01: 保存文件路径
            string fileName = this.txtOutput.Text + "\\" + UserInfo.RealName + ".Key";
            // 这里需要判断文件是否已经存在
            if (System.IO.File.Exists(fileName))
            {
                if (MessageBox.Show("签名密钥" + UserInfo.RealName + ".Key" + "已存在，您确认要覆盖原文件吗？", AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) != DialogResult.OK)
                {
                    // 文件已经存在，不能覆盖的为好，或者需要提醒才可以。
                    return returnValue;
                }
            }
            XmlDocument xmlDocument = new XmlDocument();
            XmlNode xmlNode = xmlDocument.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDocument.AppendChild(xmlNode);
            XmlNode root = xmlDocument.CreateElement("DigitalSignature");
            xmlDocument.AppendChild(root);  

            XmlElement xmlElement = xmlDocument.CreateElement("Key");
            // 02: 当前用户的Id保存到xml文件
            xmlElement.SetAttribute("Id", UserInfo.Id);
            // 03：当前的用户名为文件名
            xmlElement.SetAttribute("UserName", UserInfo.UserName);
            // 04：当前的用户名签名密码(加密保存,单向加密)
            xmlElement.SetAttribute("SignedPassword", SecretUtil.md5(password, 32));
            // 05: 当前创建日期保存到xml文件
            xmlElement.SetAttribute("CreateOn", DateTime.Now.ToString(BaseSystemInfo.DateTimeFormat));
            // 06: 当前私钥保存到xml文件
            xmlElement.SetAttribute("PrivateKey", privateKey);
            root.AppendChild(xmlElement);
            // 07: 这里需要加密保存
            // xmlDocument.Save("C:\\DigitalSignature.xml");
            // 08: 加密文件内容
            string keyFile = SecretUtil.Encrypt(xmlDocument.InnerXml);
            try
            {
                // 09: 创建二进制加密文件
                FileUtil.WriteBinaryFile(fileName, keyFile);
                // 10：打开生成文件所在的目录
                // Process.Start(this.txtOutput.Text);
                // 11：记住用户参数
                DotNetService.Instance.ParameterService.SetParameter(UserInfo, "User", this.UserInfo.Id, "DigitalSignatureFilePath", this.txtOutput.Text);
                returnValue = true;
            }
            catch
            {
                MessageBox.Show("保存签名密钥文件失败、请重新生成签名密钥。", AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                returnValue = false;
            }
            return returnValue;
        }

        /// <summary>
        /// 当创建数字签名后触发的事件
        /// </summary>
        /// <param name="userId">用户主键</param>
        public delegate void AfterCreateDigitalSignatureEventHandler(string userId);

        /// <summary>
        /// 创建数字签名后触发的事件委托
        /// </summary>
        public event AfterCreateDigitalSignatureEventHandler AfterCreateDigitalSignature;

        #region private bool CreateDigitalSignature(string oldPassword, string newPassword) 修改密码
        /// <summary>
        /// 创建数字证书
        /// </summary>
        private bool CreateDigitalSignature()
        {
            bool returnValue = false;
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            string privateKey = DotNetService.Instance.LogOnService.CreateDigitalSignature(UserInfo, this.txtPassword.Text, out statusCode, out statusMessage);
            if (statusCode == StatusCode.OK.ToString())
            {
                if (this.SaveDigitalSignature(privateKey, this.txtPassword.Text))
                {
                    // 这里调用创建成功后的委托事件。
                    if (AfterCreateDigitalSignature != null)
                    {
                        AfterCreateDigitalSignature(this.UserInfo.Id);
                    }
                    else
                    {
                        if (BaseSystemInfo.ShowInformation)
                        {
                            // 提示信息。
                            MessageBox.Show("签名密钥文件创建成功、请妥善保管好签名密钥文件。", AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    this.DialogResult = DialogResult.OK;
                    returnValue = true;
                }
            }
            else
            {
                MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        #region private string SettingOutput() 设置输出路径
        /// <summary>
        /// 设置输出路径
        /// </summary>
        /// <returns>输出路径</returns>
        private string SettingOutput()
        {
            string returnValue = string.Empty;
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "选择数字证书输出目录:";
            if (System.IO.Directory.Exists(this.txtOutput.Text))
            {
                folderBrowserDialog.SelectedPath = this.txtOutput.Text;
            }
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                returnValue = folderBrowserDialog.SelectedPath;
                this.txtOutput.Text = returnValue;
            }
            return returnValue;
        }
        #endregion

        private void btnOutput_Click(object sender, EventArgs e)
        {
            this.SettingOutput();
        }

        private void btnClearOutput_Click(object sender, EventArgs e)
        {
            this.txtOutput.Text = string.Empty;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 检查输入的有效性
            if (this.CheckInput())
            {
                // 更新用户的密码
                if (this.CreateDigitalSignature())
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}