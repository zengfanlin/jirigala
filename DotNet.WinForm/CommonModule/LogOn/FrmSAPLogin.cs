//------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2009 , Jirisoft , Ltd. 
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DotNet.Common.UILayer.WinForm.Login
{
    using DotNet.Business;
    using DotNet.Utilities;
    using DotNet.WinForm;

    /// <summary>
    /// FrmSAPLogin
    /// 
    /// 修改纪录
    ///
    ///		2009.01.19 版本：1.5 JiRiGaLa SAP登录问题解决。
    ///		2009.01.19 版本：1.4 JiRiGaLa 下拉框为用户的真实姓名问题解决。
    ///		2008.03.21 版本：1.3 JiRiGaLa 用户名密码不能记录的错误进行改进。
    ///		2007.09.17 版本：1.2 JiRiGaLa 窗体上按 ESC 按钮退不出的错误修正。
    ///		2007.08.05 版本：1.1 JiRiGaLa 用户名记录起来，提示信息显示，默认允许登录次数。
    ///		2007.06.12 版本：1.0 JiRiGaLa 整理文件。
    ///		
    /// 版本：1.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.09.17</date>
    /// </author> 
    /// </summary>
    public partial class FrmSAPLogin : BaseForm
    {
        public DataTable DTUser = new DataTable(BaseUserTable.TableName);    // 用户列表
        private int AllowLoginCount     = 3;    // 允许错误登录次数 
        private int LoginCount          = 0;    // 已登录次数

        public FrmSAPLogin()
        {
            InitializeComponent();
        }

        #region private void SetHelp()
        /// <summary>
        /// 设置帮助
        /// </summary>
        private void SetHelp()
        {
            this.HelpButton = true;
        }
        #endregion

        #region private void SetButtonState() 设置按钮状态
        /// <summary>
        /// 设置按钮状态
        /// </summary>
        private void SetButtonState()
        {
            this.btnRequestAnAccount.Visible = BaseConfiguration.Instance.AllowUserRegister;
            if (BaseSystemInfo.AllowNullPassword)
            {
                this.labPasswordReq.Visible = false;
            }
            if (BaseSystemInfo.Logined)
            {
                this.CancelButton = this.btnCancel;
                this.btnCancel.Show();
                this.btnExit.Hide();
            }
            else
            {
                this.CancelButton = this.btnExit;
                this.btnExit.Show();
                this.btnCancel.Hide();
            }            
        }
        #endregion

        /// <summary>
        /// 解析SAP连接字符串，赋值连接对象
        /// </summary>
        /// <param name="SapLogon"></param>
        /// <param name="sapConnection"></param>
        /// <returns></returns>
        private bool ParseSapConnection(SAPLogonCtrl.SAPLogonControlClass SapLogon, String sapConnection)
        {
            try
            {
                string[] split = sapConnection.Split(new Char[] { ';', '=' });
                SapLogon.Client = split[3];
                SapLogon.Language = split[11];
                SapLogon.User = split[7];
                SapLogon.Password = split[9];
                SapLogon.ApplicationServer = split[1];
                SapLogon.SystemNumber = 0;
                return true;
            }
            catch (Exception exception)
            {
                this.ProcessException(exception);
            }
            return true;
        }

        private String SapLogon(String userName, String password, out String statusCode, out String statusMessage)
        {
            String returnValue = String.Empty;

            statusCode = StatusCode.OK.ToString();
            statusMessage = String.Empty;
            // 写入SAP
            try
            {
                String connectString = ConfigHelper.GetValue("SAPConnectionString").ToString().Replace("{Username}", userName).Replace("{Password}", password);
                SAPLogonCtrl.SAPLogonControlClass SapLogon = new SAPLogonCtrl.SAPLogonControlClass();
                if (!ParseSapConnection(SapLogon, connectString))
                {
                    statusCode = "-2";
                    statusMessage = "SAP连接串格式错误。";
                    return returnValue;
                }
                // 以下建立与R3的通信机制     
                SAPLogonCtrl.Connection EnterSap = (SAPLogonCtrl.Connection)SapLogon.NewConnection();//建立连接 
                if (EnterSap.Logon(0, true) == false)
                {
                    statusCode = "-1";
                    statusMessage = "连接SAP失败。";
                    return returnValue;
                }
                returnValue = userName;
            }
            // 写入SAP失败
            catch (Exception exception)
            {
                this.ProcessException(exception);
            }
            return userName;
        }

        #region private void GetLoginInfo() 获取现有的登录信息
        /// <summary>
        /// 获取现有的登录信息
        /// </summary>
        private void GetLoginInfo()
        {
            if (BaseSystemInfo.SavePassword)
            {
                // 读取注册表信息
                try
                {
                    RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(@"Software\" + BaseConfiguration.COMPANY_NAME + "\\" + BaseConfiguration.Instance.SoftName, false);
                    if (registryKey != null)
                    {
                        // 这里是保存用户名的读取
                        // this.cmbUser.Text = (String)registryKey.GetValue(BaseConfiguration.CURRENT_USERNAME);
                        this.cmbUser.SelectedValue = (String)registryKey.GetValue(BaseConfiguration.CURRENT_USERNAME);
                        // this.txtPassword.Text = (String)registryKey.GetValue(BaseConfiguration.CURRENT_PASSWORD);
                    }
                }
                catch
                {
                }
            }
        }
        #endregion

        #region private void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        private void FormOnLoad()
        {
            // 设置鼠标繁忙状态
            this.Cursor = Cursors.WaitCursor;
            this.FormLoaded = false;
            this.DTUser = ServiceManager.Instance.LoginService.GetUserDT(this.UserInfo);
            // 职员需要按用户名排序问题解决
            this.DTUser.DefaultView.Sort = BaseUserTable.FieldRealname;
            // 解决用户名密码记不住的问题
            // foreach (DataRowView dataRowView in this.DTUser.DefaultView)
            // {
            //     this.cmbUser.Items.Add(dataRowView[BaseUserTable.FieldUsername].ToString());
            // }
            // 显示用户真实姓名，保存用户名
            this.cmbUser.DataSource = this.DTUser.DefaultView;
            this.cmbUser.DisplayMember = BaseUserTable.FieldRealname;
            this.cmbUser.ValueMember = BaseUserTable.FieldUsername;
            
            // 默认焦点在用户名输入上
            this.cmbUser.Focus();
            // 获取现有的登录信息
            this.GetLoginInfo();
            // 当前的输入焦点停留在密码编辑框上，呵呵不错的改进。
            if (this.cmbUser.Text.Length > 0)
            {
                this.ActiveControl = this.txtPassword;
                this.txtPassword.Focus();
            }
            // 多语言国际化加载
            this.Localization(this);
            // 设置帮助
            this.SetHelp();
            // 设置按钮状态
            this.SetButtonState();
            this.FormLoaded = true;
            // 设置鼠标默认状态
            this.Cursor = Cursors.Default;
        }
        #endregion

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // 设置鼠标繁忙状态
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // 加载窗体
                this.FormOnLoad();
            }
            catch (Exception exception)
            {
                this.ProcessException(exception);
            }
            finally
            {
                // 设置鼠标默认状态
                this.Cursor = Cursors.Default;
            }
        }

        private void cmbUsername_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.FormLoaded)
            {
                this.txtPassword.Clear();
                this.txtPassword.Focus();
            }
        }

        #region private bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        private bool CheckInput()
        {
            // 是否没有输入用户名
            if (this.cmbUser.Text.Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9957), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cmbUser.Focus();
                return false;
            }
            if (!BaseSystemInfo.AllowNullPassword)
            {
                if (this.txtPassword.Text.Length == 0)
                {
                    MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9964), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtPassword.Focus();
                    return false;
                }
            }
            this.btnConfirm.Focus();
            return true;
        }
        #endregion

        #region private void CheckAllowLoginCount() 允许登录次数已经到了
        /// <summary>
        /// 允许登录次数已经到了
        /// </summary>
        private void CheckAllowLoginCount()
        {
            if (this.LoginCount >= this.AllowLoginCount)
            {
                this.txtPassword.Clear();
                this.cmbUser.Enabled = false;
                this.txtPassword.Enabled = false;
                this.btnConfirm.Enabled = false;
                return;
            }
        }
        #endregion

        #region private bool Login()
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns>是否成功</returns>
        private bool Login()
        {
            // 忙状态
            this.Cursor = Cursors.WaitCursor;
            String statusCode = String.Empty;
            String statusMessage = String.Empty;
            try
            {
                String userName = this.cmbUser.SelectedValue.ToString();
                String password = this.txtPassword.Text;
                userName = this.SapLogon(userName, password, out statusCode, out statusMessage);
                // 判断是否登录成功
                if (String.IsNullOrEmpty(userName))
                {
                    return false;
                }
                BaseUserInfo userInfo = ServiceManager.Instance.LoginService.LoginByUserName(this.UserInfo, userName, out statusCode, out statusMessage);
                // BaseUserInfo userInfo = ServiceManager.Instance.LoginService.Login(this.UserInfo, userName, password, out statusCode, out statusMessage);
                if (statusCode == StatusCode.OK.ToString())
                {
                    // 检查身份
                    if ((userInfo != null) && (userInfo.ID.Length > 0))
                    {
                        // 职员登录，保存登录信息
                        this.Login(userInfo);
                        // 保存登录信息
                        this.SaveLoginInfo(userInfo);                        
                        // 这里是登录功能部分
                        if (this.Parent == null)
                        {
                            this.Hide();
                            if (!BaseSystemInfo.Logined)
                            {
                                Form MainForm = CacheManager.Instance.GetForm(BaseSystemInfo.MainAssembly, BaseConfiguration.Instance.MainForm);
                                ((IBaseMainForm)MainForm).InitService();
                                ((IBaseMainForm)MainForm).InitForm();
                                MainForm.Show();
                            }
                        }
                        // 这里表示已经登录系统了
                        BaseSystemInfo.Logined = true;
                        // 登录次数归零，允许重新登录
                        this.LoginCount = 0;
                        // 打开这个窗体的主窗口
                        if (this.Owner != null)
                        {
                            ((IBaseMainForm)this.Owner).InitForm();
                            ((IBaseMainForm)this.Owner).CheckMenu();                            
                            return true;
                        }
                        if (this.Parent != null)
                        {
                            // 重新获取登录状态信息
                            ((IBaseMainForm)this.Parent.Parent).InitService();
                            ((IBaseMainForm)this.Parent.Parent).InitForm();
                            ((IBaseMainForm)this.Parent.Parent).CheckMenu();
                            this.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show(statusMessage, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtPassword.Focus();
                    this.txtPassword.SelectAll();
                    return false;
                }
            }
            catch (Exception exception)
            {
                this.ProcessException(exception);
            }
            finally
            {
                // 已经忙完了
                this.Cursor = Cursors.Default;
            }
            return true;
        }
        #endregion	

        #region private void Login(BaseUserInfo userInfo) 职员登录，保存登录信息
        /// <summary>
        /// 职员登录，保存登录信息
        /// </summary>
        /// <param name="userInfo">职员实体</param>
        private void Login(BaseUserInfo userInfo)
        {
            BaseSystemInfo.Login(userInfo);
        }
        #endregion

        #region private void SaveLoginInfo(BaseUserInfo userInfo) 将登录信息保存到注册表中
        /// <summary>
        /// 将登录信息保存到注册表中
        /// </summary>
        /// <param name="userInfo">登登录用户</param>
        private void SaveLoginInfo(BaseUserInfo userInfo)
        {
            // 设置鼠标繁忙状态
            this.Cursor = Cursors.WaitCursor;
            if (BaseSystemInfo.SavePassword)
            {
                try
                {
                    // 默认的信息写入注册表,呵呵需要改进一下
                    RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(@"Software\" + BaseConfiguration.COMPANY_NAME + "\\" + BaseConfiguration.Instance.SoftName);
                    registryKey.SetValue(BaseConfiguration.CURRENT_USERNAME, userInfo.Username);
                    // RegistryKey.SetValue(BaseConfiguration.CURRENT_USERNAME, this.cmbUsername.SelectedValue);
                    // RegistryKey.SetValue(BaseConfiguration.CURRENT_USERNAME, this.cmbUsername.SelectedText);
                    registryKey.SetValue(BaseConfiguration.CURRENT_PASSWORD, userInfo.Password);
                }
                catch (Exception exception)
                {
                    this.ProcessException(exception);
                }
                finally
                {
                    // 设置鼠标默认状态
                    this.Cursor = Cursors.Default;
                }
            }
        }
        #endregion

        private void txtPassword_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                // 检查输入的有效性
                if (this.CheckInput())
                {
                    // 用户登录
                    this.Login();
                }
            }
        }

        private void btnRequestAnAccount_Click(object sender, EventArgs e)
        {
            String assemblyName = "DotNet.WinForm.User";
            String formName = "FrmRequestAnAccount";
            Form frmRequestAnAccount = CacheManager.Instance.GetForm(assemblyName, formName);
            if (frmRequestAnAccount.ShowDialog() == DialogResult.OK)
            {
                // 不能老申请帐户吧，当作攻击的一种类型
                this.btnRequestAnAccount.Enabled = false;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 验证用户输入
            if (this.CheckInput())
            {
                // 已经登录次数 ++
                this.LoginCount ++;
                // 用户登录
                this.Login();
                // 允许登录次数已经到了
                this.CheckAllowLoginCount();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}