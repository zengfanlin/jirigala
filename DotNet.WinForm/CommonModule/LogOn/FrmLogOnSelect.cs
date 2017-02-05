//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmLogOnSelect
    /// 
    /// 修改纪录
    /// 
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
    public partial class FrmLogOnSelect : BaseForm
    {
        public DataTable DTStaff = new DataTable(BaseStaffEntity.TableName);    // 员工列表
        
        private int AllowLogOnCount     = 3;    // 允许错误登录次数 
        private int LogOnCount          = 0;    // 已登录次数

        public FrmLogOnSelect()
        {
            InitializeComponent();
        }

        #region public override void SetHelp()
        /// <summary>
        /// 设置帮助
        /// </summary>
        public override void SetHelp()
        {
            this.HelpButton = true;
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 密码强度检查
            this.labPasswordReq.Visible = BaseSystemInfo.CheckPasswordStrength;
            if (BaseSystemInfo.UserIsLogOn)
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

        #region private void GetLogOnInfo() 获取现有的登录信息
        /// <summary>
        /// 获取现有的登录信息
        /// </summary>
        private void GetLogOnInfo()
        {
            if (BaseSystemInfo.RememberPassword)
            {
                // 读取注册表信息
                try
                {
                    RegistryKey RegistryKey = Registry.LocalMachine.OpenSubKey(@"Software\" + "Hairihan TECH" + "\\" + BaseSystemInfo.SoftName, false);
                    if (RegistryKey != null)
                    {
                        this.txtUserName.Text = (string)RegistryKey.GetValue("CurrentUserName");
                        // this.cmbUserName.SelectedValue = (string)RegistryKey.GetValue(BaseConfiguration.CURRENT_USERNAME);
                        // this.txtPassword.Text  = (string)RegistryKey.GetValue(BaseConfiguration.CURRENT_PASSWORD);
                    }
                }
                catch
                {
                }
            }
        }
        #endregion

        /// <summary>
        /// 选择项类，用于ComboBox或者ListBox添加项
        /// </summary>
        public class ListItem
        {
            private string id = string.Empty;
            private string name = string.Empty;

            public ListItem(string sid, string sname)
            {
                id = sid;
                name = sname;
            }

            public override string ToString()
            {
                return this.name;
            }

            public string Id
            {
                get
                {
                    return this.id;
                }
                set
                {
                    this.id = value;
                }
            }

            public string Name
            {
                get
                {
                    return this.name;
                }
                set
                {
                    this.name = value;
                }
            }
        }

        #region private void GetLogOnTo() 获取配置文件选项
        /// <summary>
        /// 获取配置文件选项
        /// </summary>
        private void GetLogOnTo()
        {
            Dictionary<String, String> logOnTo = UserConfigHelper.GetLogOnTo();
            foreach(KeyValuePair<String, String> keyValue in logOnTo)
            {
                ListItem item = new ListItem(keyValue.Key, keyValue.Value);
                this.cmbLogOnTo.Items.Add(item);
            }
            this.cmbLogOnTo.ValueMember = "Id";
            this.cmbLogOnTo.DisplayMember = "Name";
            if (this.cmbLogOnTo.Items.Count > 0)
            {
                this.cmbLogOnTo.SelectedIndex = 0;
            }
        }
        #endregion

        private void SetLogOnTo(string logOnTo)
        {
            if (!String.IsNullOrEmpty(logOnTo))
            {
                for (int i = 0; i < this.cmbLogOnTo.Items.Count; i++)
                {
                    if (((ListItem)this.cmbLogOnTo.Items[i]).Id.Equals(logOnTo))
                    {
                        this.cmbLogOnTo.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // this.BackgroundImage = Image.FromFile(BaseSystemInfo.AppPath + @"\Resource\Images\LogOn.jpg");
            // 这里加速显示，会显得运行速度很快
            // this.Refresh();

            // this.DTStaff = DotNetService.Instance.UserService.Load(UserInfo);
            // 员工需要按用户名排序问题解决
            // this.DTStaff.DefaultView.Sort = BUBaseStaff.FieldUserName;

            // 解决用户名密码记不住的问题
            // foreach (DataRowView dataRowView in this.DTStaff.DefaultView)
            // {
            //     this.cmbUserName.Items.Add(dataRowView[BUBaseStaff.FieldUserName].ToString());
            // }

            // this.cmbUserName.DataSource = this.DTStaff.DefaultView;
            // this.cmbUserName.DisplayMember = BUBaseStaff.FieldUserName;
            // this.cmbUserName.ValueMember = BUBaseStaff.FieldId;

            this.GetLogOnTo();

            // 默认焦点在用户名输入上
            // this.ActiveControl = this.txtUserName;
            this.txtUserName.Focus();
            if (BaseSystemInfo.RememberPassword)
            {
                // 读取注册表信息
                try
                {
                    RegistryKey RegistryKey = Registry.LocalMachine.OpenSubKey(@"Software\" + "Hairihan TECH" + "\\" + BaseSystemInfo.SoftName, false);
                    if (RegistryKey != null)
                    {
                        this.txtUserName.Text = (string)RegistryKey.GetValue("CurrentUserName");
                        this.SetLogOnTo((string)RegistryKey.GetValue("LogOnTo"));
                        // this.cmbUserName.SelectedValue = (string)RegistryKey.GetValue(BaseConfiguration.CURRENT_USERNAME);
                        // this.txtPassword.Text       = (string)RegistryKey.GetValue(BaseConfiguration.CURRENT_PASSWORD);
                    }
                }
                catch
                {
                }
            }
            // 当前的输入焦点停留在密码编辑框上，呵呵不错的改进。
            if (this.txtUserName.Text.Length > 0)
            {
                this.ActiveControl = this.txtPassword;
                this.txtPassword.Focus();
            }
        }
        #endregion

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        public override bool CheckInput()
        {
            // 允许登录次数已经到了
            if (this.LogOnCount == this.AllowLogOnCount)
            {
                this.txtPassword.Clear();
                this.txtUserName.Enabled = false;
                this.txtPassword.Enabled = false;
                this.btnConfirm.Enabled = false;
                return false;
            }
            // 是否没有输入用户名
            if (this.txtUserName.Text.Length == 0)
            {
                MessageBox.Show(AppMessage.Format(AppMessage.MSG0007, AppMessage.MSG9957), AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtUserName.Focus();
                return false;
            }
            // 密码强度检查
            if (BaseSystemInfo.CheckPasswordStrength)
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

        #region private void CheckAllowLogOnCount() 允许登录次数已经到了
        /// <summary>
        /// 允许登录次数已经到了
        /// </summary>
        private void CheckAllowLogOnCount()
        {
            if (this.LogOnCount >= this.AllowLogOnCount)
            {
                this.txtPassword.Clear();
                this.txtUserName.Enabled = false;
                this.txtPassword.Enabled = false;
                this.btnConfirm.Enabled = false;
                return;
            }
        }
        #endregion

        #region private bool LogOn()
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <returns>是否成功</returns>
        private bool LogOn()
        {
            if (!BaseSystemInfo.UserIsLogOn && this.cmbLogOnTo.Enabled)
            {
                UserConfigHelper.LogOnTo = ((ListItem)this.cmbLogOnTo.SelectedItem).Id;
                // 读取配置文件
                UserConfigHelper.GetConfig();
            }

            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            DotNetService dotNetService = new DotNetService();
            BaseUserInfo userInfo = dotNetService.LogOnService.UserLogOn(UserInfo, this.txtUserName.Text, this.txtPassword.Text, true, out statusCode, out statusMessage);
            if (dotNetService.LogOnService is ICommunicationObject)
            {
                ((ICommunicationObject)dotNetService.LogOnService).Close();
            }
            if (statusCode == StatusCode.OK.ToString())
            {
                // 检查身份
                if ((userInfo != null) && (userInfo.Id.Length > 0))
                {
                    BaseSystemInfo.UserInfo = userInfo;
                    if (BaseSystemInfo.RememberPassword)
                    {
                        this.SaveLogOnInfo();
                    }

                    // 这里是登录功能部分
                    if (this.Parent == null)
                    {
                        this.Hide();
                        if (!BaseSystemInfo.UserIsLogOn)
                        {
                            Form mainForm = CacheManager.Instance.GetForm(BaseSystemInfo.MainAssembly, BaseSystemInfo.MainForm);
                            ((IBaseMainForm)mainForm).InitService();
                            ((IBaseMainForm)mainForm).InitForm();
                            mainForm.Show();
                        }
                    }
                    // 这里表示已经登录系统了
                    BaseSystemInfo.UserIsLogOn = true;
                    // 登录次数归零，允许重新登录
                    this.LogOnCount = 0;                        

                    // 打开这个窗体的主窗口
                    if (this.Owner != null)
                    {
                        ((IBaseMainForm)this.Owner).InitService();
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
            return true;
        }
        #endregion	

        #region private void SaveLogOnInfo() 将登录信息保存到XML文件中
        /// <summary>
        /// 将登录信息保存到XML文件中
        /// </summary>
        private void SaveLogOnInfo()
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            if (BaseSystemInfo.RememberPassword)
            {
                try
                {
                    // 默认的信息写入注册表,呵呵需要改进一下
                    RegistryKey RegistryKey = Registry.LocalMachine.CreateSubKey(@"Software\" + "Hairihan TECH" + "\\" + BaseSystemInfo.SoftName);
                    RegistryKey.SetValue("CurrentUserName", this.txtUserName.Text);
                    // RegistryKey.SetValue(BaseConfiguration.CURRENT_USERNAME, this.cmbUserName.SelectedValue);
                    // RegistryKey.SetValue(BaseConfiguration.CURRENT_USERNAME, this.cmbUserName.SelectedText);
                    RegistryKey.SetValue("CurrentPassword", this.txtPassword.Text);
                }
                catch (Exception ex)
                {
                    this.ProcessException(ex);
                }
                finally
                {
                    // 设置鼠标默认状态，原来的光标状态
                    this.Cursor = holdCursor;
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
                    this.LogOn();
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            // 验证用户输入
            if (this.CheckInput())
            {
                // 已经登录次数 ++
                this.LogOnCount ++;
                // 用户登录
                this.LogOn();
                // 允许登录次数已经到了
                this.CheckAllowLogOnCount();
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