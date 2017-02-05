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
    /// FrmChangeSignedPassword.cs
    /// 修改签名密码
    ///		
    /// 修改记录
    ///     
    ///     2011.05.19 版本：1.3 JiRiGaLa  修改签名密钥后需要覆盖签名文件。
    ///     2011.05.19 版本：1.2 JiRiGaLa  修改签名密钥时，需要验证原来的密码是否正确，文件中的密码。
    ///     2011.05.19 版本：1.1 JiRiGaLa  修改密钥签名密码时，核对原来的密码是否正确。
    ///     2011.05.12 版本：1.0 JiRiGaLa  用户修改密码页面编写。
    ///		
    /// 版本：1.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.05.19</date>
    /// </author> 
    /// </summary>
    public partial class FrmChangeSignedPassword : BaseForm
    {
        public FrmChangeSignedPassword()
        {
            this.ShowDialogOnly = true;
            InitializeComponent();
        }

        public override void FormOnLoad()
        {
            // 这里读取用户参数，用户把数字证书导出到什么文件夹了，就记录下来。
            string filePath = DotNetService.Instance.ParameterService.GetParameter(UserInfo, "User", this.UserInfo.Id, "DigitalSignatureFilePath");
            if (!string.IsNullOrEmpty(filePath))
            {
                string fileName = filePath + "\\" + UserInfo.RealName + ".Key";
                if (System.IO.File.Exists(fileName))
                {
                    this.txtDigitalSignature.Text = fileName;
                }
            }
            
            base.FormOnLoad();

            // 这里提示签名是否已经生成过，若已在银行报备过签名，需要重新向银行提交新签名。
            string publicKey = DotNetService.Instance.LogOnService.GetPublicKey(UserInfo, UserInfo.Id);
            if (string.IsNullOrEmpty(publicKey))
            {
                MessageBox.Show("请先创建签名密钥。", AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnConfirm.Enabled = false;
            }
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
            this.lblOldPasswordReq.Visible = BaseSystemInfo.CheckPasswordStrength;
        }
        #endregion

        #region private void ClearNewPassword() 清除密码
        /// <summary>
        /// 清除密码
        /// </summary>
        private void ClearNewPassword()
        {
            this.txtNewPassword.Text = string.Empty;
            this.txtConfirmPassword.Text = string.Empty;
            this.txtNewPassword.Focus();
        }
        #endregion

        #region private void ClearOldPassword() 清除密码
        /// <summary>
        /// 清除密码
        /// </summary>
        private void ClearOldPassword()
        {
            this.txtOldPassword.Text = string.Empty;
            this.txtOldPassword.Focus();
        }
        #endregion

        private void btnDigitalSignature_Click(object sender, EventArgs e)
        {
            // 这里读取用户参数，用户把数字证书导出到什么文件夹了，就记录下来。
            string filePath = DotNetService.Instance.ParameterService.GetParameter(UserInfo, "User", this.UserInfo.Id, "DigitalSignatureFilePath");
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (!string.IsNullOrEmpty(filePath))
            {
                openFileDialog.InitialDirectory = filePath;
            }
            // openFileDialog.Filter = "签名密钥(*.Key)|*.Key";
            openFileDialog.Filter = "签名密钥(*.Key)|" + this.UserInfo.RealName + ".Key";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "选择签名密钥";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = System.IO.Path.GetDirectoryName(openFileDialog.FileName);
                DotNetService.Instance.ParameterService.SetParameter(UserInfo, "User", this.UserInfo.Id, "DigitalSignatureFilePath", filePath);
                this.txtDigitalSignature.Text = openFileDialog.FileName;
            }
        }

        #region public override bool CheckInput() 加查输入的有效性
        /// <summary>
        /// 加查输入的有效性
        /// </summary>
        public override bool CheckInput()
        {
            // 密码强度检查
            if (BaseSystemInfo.CheckPasswordStrength)
            {
                // 原密码为空
                if (this.txtOldPassword.Text.Length == 0)
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9961), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtOldPassword.Focus();
                    return false;
                }
                // 新密码为空
                if (this.txtNewPassword.Text.Length == 0)
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9959), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtNewPassword.Focus();
                    return false;
                }
                // 确认密码为空
                if (this.txtConfirmPassword.Text.Length == 0)
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9960), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtConfirmPassword.Focus();
                    return false;
                }
                if (!BaseCheckInput.CheckPasswordStrength(this.txtNewPassword))
                {
                    return false;
                }
            }
            // 新密码不一致
            if (this.txtConfirmPassword.Text != this.txtNewPassword.Text)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0039, AppMessage.MSG9959, AppMessage.MSG9960), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.ClearNewPassword();
                return false;
            }
            if (this.txtDigitalSignature.Text.Length == 0)
            {
                MessageBox.Show("请选择签名密钥文件存放位置。", AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnSelectDigitalSignature.Focus();
                return false;
            }else
            {
               if (!System.IO.File.Exists(this.txtDigitalSignature.Text))
               {
                   this.txtDigitalSignature.Text = string.Empty;
                    MessageBox.Show("请选择签名密钥文件存放位置。", AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.btnSelectDigitalSignature.Focus();
                    return false;
               }
            }
            return true;
        }
        #endregion

        /// <summary>
        /// 当修改数字签名后触发的事件
        /// </summary>
        /// <param name="userId">用户主键</param>
        public delegate void AfterChangeDigitalSignatureEventHandler(string userId);

        /// <summary>
        /// 修改数字签名后触发的事件委托
        /// </summary>
        public event AfterChangeDigitalSignatureEventHandler AfterChangeDigitalSignature;

        #region private bool ChangeSignedPassword() 修改签名密码
        /// <summary>
        /// 修改签名密码
        /// </summary>
        private bool ChangeSignedPassword()
        {
            bool returnValue = false;

            // 1：这里判断签名文件中的签名密码是否正确？
            string privateKey = string.Empty;
            string signedPassword = string.Empty;
            try
            {
                signedPassword = SecretUtil.GetSignedPassword(txtDigitalSignature.Text);
                if (!signedPassword.Equals(SecretUtil.md5(this.txtOldPassword.Text, 32)))
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0040, AppMessage.MSG9961), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtOldPassword.Focus();
                    this.txtOldPassword.SelectAll();
                    return false;
                }
                // 2：同时可以把私钥读取出来。
                privateKey = SecretUtil.GetPrivateKey(this.txtDigitalSignature.Text, this.txtOldPassword.Text);
            }
            catch
            {
                MessageBox.Show("修改签名密码失败、请重修改签名密码。", AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            // 3：判断服务器上的签名密码是否正确？
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            DotNetService.Instance.LogOnService.ChangeSignedPassword(UserInfo, this.txtOldPassword.Text, this.txtNewPassword.Text, out statusCode, out statusMessage);
            if (statusCode == StatusCode.ChangePasswordOK.ToString())
            {
                // 4：保存签名密钥
                this.SaveDigitalSignature(privateKey, this.txtNewPassword.Text);

                // 修改数字签名后的方法
                if (AfterChangeDigitalSignature != null)
                {
                    AfterChangeDigitalSignature(this.UserInfo.Id);
                }
                else
                {
                    if (BaseSystemInfo.ShowInformation)
                    {
                        // 提示修改成功
                        MessageBox.Show("修改签名密码成功、请妥善保管好签名密钥文件。", AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                this.DialogResult = DialogResult.OK;
                returnValue = true;
            }
            else
            {
                if (statusCode == StatusCode.PasswordCanNotBeNull.ToString())
                {
                    this.ClearOldPassword();
                }
                if (statusCode == StatusCode.OldPasswordError.ToString())
                {
                    this.ClearOldPassword();
                }
                MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                returnValue = false;
            }
            return returnValue;
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
            string fileName = this.txtDigitalSignature.Text;
            
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
            // 04：当前的用户名签名密码(加密保存)
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
                // Process.Start(this.txtDigitalSignature.Text);
                // 11：记住用户参数
                // DotNetService.Instance.ParameterService.SetParameter(UserInfo, "User", this.UserInfo.Id, "DigitalSignatureFilePath", this.txtOutput.Text);
                // MessageBox.Show("修改签名密码成功、请妥善保管好签名密钥文件。", AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("修改签名密码失败、请重修改签名密码。", AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                returnValue = false;
            }
            return returnValue;
        }


        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 检查输入的有效性
            if (this.CheckInput())
            {
                // 更新用户的签名密码
                if (this.ChangeSignedPassword())
                {
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