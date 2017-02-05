//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , JoinMore TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Utilities;
    using DotNet.Business;

    /// <summary>
    /// FrmDigitalSignature.cs
    /// 数字证书签名
    ///		
    /// 修改记录
    ///     
    ///     2011.05.14 版本：1.0 JiRiGaLa  用户修改密码页面编写。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.05.14</date>
    /// </author> 
    /// </summary>
    public partial class FrmDigitalSignature : BaseForm
    {
        public FrmDigitalSignature()
        {
            this.ShowDialogOnly = true;
            InitializeComponent();
        }

        /// <summary>
        /// 需要签名的数据
        /// </summary>
        public FrmDigitalSignature(string dataToSign)
            : this()
        {
            this.DataToSign = dataToSign;
        }

        private string assemblyName = string.Empty;
        /// <summary>
        /// 应用程序窗体所在命名空间
        /// </summary>
        public string AssemblyName
        {
            get
            {
                return assemblyName;
            }
            set
            {
                assemblyName = value;
            }
        }

        private string businessId = string.Empty;
        /// <summary>
        /// 业务数据主键
        /// </summary>
        public string BusinessId
        {
            get
            {
                return businessId;
            }
            set
            {
                businessId = value;
            }
        }

        private string dataToSign = string.Empty;
        /// <summary>
        /// 需要签名的数据
        /// </summary>
        public string DataToSign
        {
            get
            {
                return dataToSign;
            }
            set
            {
                dataToSign = value;
            }
        }

        /// <summary>
        /// 安全通讯密码
        /// </summary>
        public string CommunicationPassword
        {
            get
            {
                return this.txtCommunicationPassword.Text;
            }
        }

        private string privateKey = string.Empty;
        /// <summary>
        /// 私钥
        /// </summary>
        public string PrivateKey
        {
            get
            {
                return privateKey;
            }
            set
            {
                privateKey = value;
            }
        }

        private string signedData = string.Empty;
        /// <summary>
        /// 签名结果
        /// </summary>
        public string SignedData
        {
            get
            {
                return signedData;
            }
            set
            {
                signedData = value;
            }
        }

        /// <summary>
        /// 当修改通讯密码后触发的事件
        /// </summary>
        /// <param name="assemblyName">应用程序窗体所在命名空间</param>
        /// <param name="businessId">业务数据主键</param>
        /// <param name="password">通讯密码</param>
        public delegate bool OnChekCommunicationPasswordEventHandler(string assemblyName, string businessId, string password);

        /// <summary>
        /// 修改通讯密码后触发的事件委托
        /// </summary>
        public event OnChekCommunicationPasswordEventHandler OnChekCommunicationPassword;

        public override void FormOnLoad()
        {
            // 这里应该还要检查是否已经生成了数字签名，若没生成，应该需要提醒的功能。
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
        }

        private void btnSelectDigitalSignature_Click(object sender, EventArgs e)
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

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        public override bool CheckInput()
        {
            // 是否没有输入数字证书路径
            if (this.txtDigitalSignature.Text.Length == 0)
            {
                MessageBox.Show("请选择签名密钥文件存放位置。", AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btnSelectDigitalSignature.Focus();
                return false;
            }
            else
            {
                if (!System.IO.File.Exists(this.txtDigitalSignature.Text))
                {
                    this.txtDigitalSignature.Text = string.Empty;
                    MessageBox.Show("请选择签名密钥文件存放位置。", AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.btnSelectDigitalSignature.Focus();
                    return false;
                }
            }
            // 密码强度检查
            if (BaseSystemInfo.CheckPasswordStrength)
            {
                if (this.txtSignedPassword.Text.Length == 0)
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSGS864), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtSignedPassword.Focus();
                    return false;
                }
                else
                {
                    if (!DotNetService.Instance.LogOnService.SignedPassword(UserInfo, this.txtSignedPassword.Text))
                    {
                        MessageBox.Show(AppMessage.Format(AppMessage.MSG0040, AppMessage.MSGS864), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtSignedPassword.Focus();
                        this.txtSignedPassword.SelectAll();
                        return false;
                    }
                }

                // 确认安全通讯密码
                if (this.txtCommunicationPassword.Text.Length == 0)
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSGS964), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtCommunicationPassword.Focus();
                    return false;
                }
                else
                {
                    // 通讯密码在服务器端是否正确
                    if (OnChekCommunicationPassword != null)
                    {
                        bool chekCommunicationPassword = OnChekCommunicationPassword(this.AssemblyName, this.BusinessId, this.txtCommunicationPassword.Text);
                        if (!chekCommunicationPassword)
                        {
                            MessageBox.Show(AppMessage.Format(AppMessage.MSG0040, AppMessage.MSGS964), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.txtCommunicationPassword.Focus();
                            this.txtCommunicationPassword.SelectAll();
                            return false;
                        }
                    }
                    else
                    {
                        if (!DotNetService.Instance.LogOnService.CommunicationPassword(UserInfo, this.txtCommunicationPassword.Text))
                        {
                            MessageBox.Show(AppMessage.Format(AppMessage.MSG0040, AppMessage.MSGS964), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.txtCommunicationPassword.Focus();
                            this.txtCommunicationPassword.SelectAll();
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        #endregion

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                // 丛文件中读取签名密码是否正确
                this.PrivateKey = SecretUtil.GetPrivateKey(this.txtDigitalSignature.Text, this.txtSignedPassword.Text);
                if (string.IsNullOrEmpty(this.PrivateKey))
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0040, AppMessage.MSGS864), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtSignedPassword.Focus();
                    this.txtSignedPassword.SelectAll();
                    return;
                }
                if (!string.IsNullOrEmpty(this.DataToSign))
                {
                    this.SignedData = SecretUtil.HashAndSign(this.DataToSign, this.PrivateKey);
                    this.DialogResult = DialogResult.OK;                    
                }
                this.Close();
            }
        }
    }
}