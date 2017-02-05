//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// SDIMainForm
    /// 
    /// 修改纪录
    /// 
    ///     2012.05.22 班本：3.1 JiRiGaLa B\S，C\S 菜单严格区分。
    ///     2011.12.12 班本：3.0 JiRiGaLa 集成菜单。
    ///     2011.10.29 版本：2.1 张广梁 增加锁屏功能
    ///		2009.11.11 版本：2.0 JiRiGaLa 美化图标。
    ///		2007.10.29 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：3.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.05.22</date>
    /// </author> 
    /// </summary>
    public partial class SDIMainForm : BaseForm, IBaseMainForm // Form
    {
        private bool isLockSystem = true;

        /// <summary>
        /// 是否锁定系统
        /// </summary>
        public bool IsLockSystem
        {
            get { return isLockSystem; }
            set { isLockSystem = value; }
        }

        private int lockWaitMinute = 60;

        /// <summary>
        /// 锁定等待时间分钟
        /// </summary>
        public int LockWaitMinute
        {
            get { return lockWaitMinute; }
            set { lockWaitMinute = value; }
        }

        public SDIMainForm()
        {
            InitializeComponent();
            if (!this.DesignMode)
            {
                // 获得图标
                this.GetIcon();
            }
        }

        new public void GetIcon()
        {
            if (System.IO.File.Exists(BaseSystemInfo.AppIco))
            {
                this.notifyIcon.Icon = new Icon(BaseSystemInfo.AppIco);
            }
        }

        public void InitService()
        {
            Program.InitService(UserInfo);
            // Thread Thread = new Thread(new ThreadStart(Program.InitService));
            // Thread.Start();
        }

        #region private void LoadChildrenForm(string assemblyName, string formName)
        /// <summary>
        /// 加载选定的子窗口
        /// </summary>
        /// <param name="assemblyName">程序集</param>
        /// <param name="selectedNodeName">当前选择的窗体名称</param>
        private void LoadChildrenForm(string assemblyName, string formName, bool showIntask)
        {
            if (formName.Length == 0)
            {
                return;
            }
            // 是否已经打开了？若已经打开了这个窗体，那就不用重复打开了
            foreach (Form childrenForm in this.OwnedForms)
            {
                if (childrenForm.Name == formName)
                {
                    childrenForm.Visible = true;
                    childrenForm.Activate();
                    return;
                }
            }
            // 一些特殊的页面处理，重新登录时，需要把其他页面都自动关闭了。
            switch (formName)
            {
                case "FrmLogOn":
                    // 关闭所有打开的窗口
                    foreach (Form childrenForm in this.MdiChildren)
                    {
                        childrenForm.Close();
                    }
                    this.ShowChildrenForm(assemblyName, formName, true);
                    break;
                case "FrmScreenLock":
                    {
                        tmrLock.Stop();
                        // 隐藏notifyIcon
                        this.notifyIcon.Visible = false;
                        // 隐藏子窗口
                        foreach (Form childrenForm in this.OwnedForms)
                        {
                            childrenForm.Visible = false;
                        }
                        DotNet.WinForm.FrmScreenLock lcForm = new FrmScreenLock();
                        if (lcForm.ShowDialog(this) == DialogResult.OK)
                        {
                            // 显示notifyIcon
                            this.notifyIcon.Visible = true;
                            // 显示子窗口
                            foreach (Form childrenForm in this.OwnedForms)
                            {
                                childrenForm.Visible = true;
                            }
                            LoadFormLockInfo();
                        }
                    }
                    break;
                default:
                    this.ShowChildrenForm(assemblyName, formName, true);
                    return;
            }
        }
        #endregion

        /// <summary>
        /// 反射显示窗体
        /// </summary>
        /// <param name="assemblyName">命名空间</param>
        /// <param name="formName">窗体名称</param>
        /// <returns>对象</returns>
        private object CreateInstance(string assemblyName, string formName)
        {
            // 这里用了缓存技术，若已经被创建过就不反复创建了
            Assembly assembly = CacheManager.Instance.Load(assemblyName);
            Type type = assembly.GetType(assemblyName + "." + formName, true, false);
            return Activator.CreateInstance(type);
        }

        private void ShowChildrenForm(string assemblyName, string formName)
        {
            ShowChildrenForm(assemblyName, formName, false);
        }

        private void ShowChildrenForm(string assemblyName, string formName, bool showInTaskbar)
        {
            Form childrenForm = (Form)this.CreateInstance(assemblyName, formName);
            if (childrenForm != null)
            {
                childrenForm.Name = formName;
                childrenForm.Owner = this;
                childrenForm.ShowInTaskbar = showInTaskbar;
                childrenForm.Show();
            }
        }

        private void mitm_Click(object sender, EventArgs e)
        {
            // 这里是获取表单的名称
            string formName = ((ToolStripMenuItem)sender).Name.Substring(4);
            // 这里是获取命名空间
            string assemblyName = BaseSystemInfo.MainAssembly;
            if (((ToolStripMenuItem)sender).Tag != null)
            {
                assemblyName = ((ToolStripMenuItem)sender).Tag.ToString();
            }
            if (formName.Substring(0, 3).Equals("Url"))
            {
                string url = assemblyName;
                url = this.UserInfo.GetUrl(url);
                if (!string.IsNullOrEmpty(url))
                {
                    System.Diagnostics.Process.Start(url);
                }
                return;
            }
            // 这里是加载窗体，不会重复加载窗体
            this.LoadChildrenForm(assemblyName, formName, true);
        }

        private void mitmFrmLogOn_Click(object sender, EventArgs e)
        {
            // 按配置的登录页面进行登录
            this.LoadChildrenForm(BaseSystemInfo.MainAssembly, BaseSystemInfo.LogOnForm, true);
        }

        private DateTime LastChekDate = DateTime.MinValue;

        public void CallMessager()
        {
            this.CallMessager(true);
        }

        /// <summary>
        ///  即时通讯
        /// </summary>
        /// <param name="show">显示</param>
        public void CallMessager(bool show)
        {
            // 若还没登录，就应该退出了。
            if (!BaseSystemInfo.UserIsLogOn)
            {
                return;
            }
            if (Program.frmMessage == null)
            {
                Program.frmMessage = new FrmMessage();
            }
            if (show)
            {
                Program.frmMessage.Visible = true;
                // Program.FrmMessage.ShowInTaskbar = true;
                Program.frmMessage.Show();
                Program.frmMessage.WindowState = FormWindowState.Normal;
                Program.frmMessage.Activate();
            }
            else
            {
                // 加载窗体
                // Program.FrmMessage.WindowState = FormWindowState.Minimized;
                Program.frmMessage.Show();
                Program.frmMessage.Hide();
            }
        }

        private void btnMessage_Click(object sender, EventArgs e)
        {
            this.CallMessager();
        }

        private void mitmFrmMessage_Click(object sender, EventArgs e)
        {
            this.CallMessager();
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (BaseSystemInfo.UserIsLogOn)
            {
                if (BaseSystemInfo.UseMessage)
                {
                    this.CallMessager();
                }
                else
                {
                    FrmUserAdmin frmUserAdmin = new FrmUserAdmin();
                    frmUserAdmin.ShowDialog();
                }
            }
        }

        private void AddApplictionsMenuItem(ToolStripMenuItem mitmAppliction)
        {
            // 判断是否已经加载过菜单了
            if (mitmAppliction.Tag != null)
            {
                return;
            }
            ToolStripMenuItem mitm = null;
            string moduleCode = string.Empty;
            string id = BaseBusinessLogic.GetProperty(ClientCache.Instance.DTMoule, BaseModuleEntity.FieldCode, "Appliction", BaseModuleEntity.FieldId);
            if (string.IsNullOrEmpty(id))
            {
                return;
            }
            // 从所有的系统菜单里进行循环
            foreach (DataRow dataRow in ClientCache.Instance.DTMoule.Select(BaseModuleEntity.FieldParentId + "=" + id.ToString(), BaseModuleEntity.FieldSortCode))
            {
                // 判断有些特殊的处理，跳过
                moduleCode = dataRow[BaseModuleEntity.FieldCode].ToString();
                if (string.IsNullOrEmpty(moduleCode) || moduleCode.Equals("FrmBusinessCardAdmin") || moduleCode.Equals("FrmCodeGenerator"))
                {
                    continue;
                }
                // 是否显示的，是否有权限的，才可以访问菜单
                if (this.ModuleIsVisible(moduleCode) && this.IsModuleAuthorized(moduleCode))
                {
                    id = dataRow[BaseModuleEntity.FieldId].ToString();
                    mitm = new ToolStripMenuItem(dataRow[BaseModuleEntity.FieldFullName].ToString());
                    mitm.Name = "mitmUrl" + id;
                    mitm.Tag = dataRow[BaseModuleEntity.FieldAssemblyName].ToString();
                    mitm.Click += mitm_Click;
                    mitmAppliction.DropDownItems.Add(mitm);
                }
            }
            // 打上已经加载菜单的标志，提高程序效率不反复执行程序
            mitmAppliction.Tag = "Url";
        }

        #region private void CheckMenu() 获得的菜单
        /// <summary>
        /// 获得的菜单
        /// </summary>
        public void CheckMenu()
        {
            this.notifyIcon.BalloonTipTitle = BaseSystemInfo.SoftFullName + " (" + this.UserInfo.RealName + ")";
            this.notifyIcon.BalloonTipText = BaseSystemInfo.SoftFullName + " (" + this.UserInfo.RealName + ")";
            this.notifyIcon.Text = BaseSystemInfo.SoftFullName + " (" + this.UserInfo.RealName + ")";

            this.contextMenuStrip.Tag = null;
            // 申请帐户
            this.CheckMenuItem(this.mitmFrmRequestAnAccount);
            // 我的联系方式
            this.CheckMenuItem(this.mitmFrmStaffAddressEdit);
            // 没有员工帐号，这个就不显示了
            this.mitmFrmStaffAddressEdit.Visible = !String.IsNullOrEmpty(UserInfo.StaffId);

            this.mtspStaffAddress.Visible = this.mitmFrmRequestAnAccount.Visible
                || this.mitmFrmStaffAddressEdit.Visible;

            this.mitmOnLine1.Visible = BaseSystemInfo.UseMessage && BaseSystemInfo.UserIsLogOn;
            this.mitmOnLine2.Visible = BaseSystemInfo.UseMessage && BaseSystemInfo.UserIsLogOn;
            this.mitmOnLine3.Visible = BaseSystemInfo.UseMessage && BaseSystemInfo.UserIsLogOn;
            this.mitmOnLine4.Visible = BaseSystemInfo.UseMessage && BaseSystemInfo.UserIsLogOn;

            // 发送消息
            this.CheckMenuItem(this.mitmFrmMessageSend);
            if (this.mitmFrmMessageSend.Visible)
            {
                this.mitmFrmMessageSend.Visible = BaseSystemInfo.UseMessage;
            }
            // 即时通讯
            this.CheckMenuItem(this.mitmFrmMessage);
            if (this.mitmFrmMessage.Visible)
            {
                this.mitmFrmMessage.Visible = BaseSystemInfo.UseMessage;
            }
            // 广播消息
            this.CheckMenuItem(this.mitmFrmMessageBroadcast);
            if (this.mitmFrmMessageBroadcast.Visible)
            {
                this.mitmFrmMessageBroadcast.Visible = BaseSystemInfo.UseMessage;
            }
            this.mtspMessage.Visible = this.mitmFrmMessageSend.Visible
                || this.mitmFrmMessage.Visible
                || this.mitmFrmMessageBroadcast.Visible;

            // 用户审核
            this.CheckMenuItem(this.mitmFrmUserAudit);
            // 用户管理
            this.CheckMenuItem(this.mitmFrmUserAdmin);
            this.mtspUserAdmin.Visible = this.mitmFrmRequestAnAccount.Visible || this.mitmFrmUserAudit.Visible || this.mitmFrmUserAdmin.Visible;

            // 扮演用户
            this.CheckMenuItem(this.mitmFrmImpersonation);
            // 用户授权
            this.CheckMenuItem(this.mitmFrmAccredit);
            this.mtspImpersonation.Visible = this.mitmFrmAccredit.Visible || this.mitmFrmImpersonation.Visible;

            // 组织机构管理
            this.CheckMenuItem(this.mitmFrmOrganizeAdmin);
            // 角色管理
            this.CheckMenuItem(this.mitmFrmRoleAdmin);
            // 员工管理
            this.CheckMenuItem(this.mitmFrmStaffAdmin);
            // 岗位管理
            this.CheckMenuItem(this.mitmFrmOrganizeRoleAdmin);
            // 内部通讯录
            this.CheckMenuItem(this.mitmFrmStaffAddressAdmin);

            this.mtspStaffAdmin.Visible = this.CheckMenuItem(this.mitmFrmOrganizeAdmin)
                || this.CheckMenuItem(this.mitmFrmRoleAdmin)
                || this.CheckMenuItem(this.mitmFrmStaffAdmin)
                || this.CheckMenuItem(this.mitmFrmStaffAddressAdmin);

            // 权限部分
            this.CheckMenuItem(this.mitmFrmPermissionItemAdmin);
            this.CheckMenuItem(this.mitmFrmModuleAdmin);
            this.CheckMenuItem(this.mitmFrmUserPermissionAdmin);
            this.CheckMenuItem(this.mitmFrmRolePermissionAdmin);
            this.CheckMenuItem(this.mitmFrmOrganizePermissionAdmin);

            this.mtspPermissionAdmin.Visible = this.CheckMenuItem(this.mitmFrmPermissionItemAdmin)
                || this.CheckMenuItem(this.mitmFrmModuleAdmin)
                || this.CheckMenuItem(this.mitmFrmUserPermissionAdmin)
                || this.CheckMenuItem(this.mitmFrmRolePermissionAdmin)
                || this.CheckMenuItem(this.mitmFrmOrganizePermissionAdmin);

            // 文档管理
            this.CheckMenuItem(this.mitmFrmFileAdmin);

            // 软件频道
            this.CheckMenuItem(this.mitmAppliction);
            if (this.mitmAppliction.Enabled)
            {
                // 名片管理
                this.CheckMenuItem(this.mitmFrmBusinessCardAdmin);
                // 代码批量生成器
                this.CheckMenuItem(this.mitmFrmCodeGenerator);
                this.mtspCodeGenerator.Visible = this.CheckMenuItem(this.mitmFrmBusinessCardAdmin) || this.CheckMenuItem(this.mitmFrmCodeGenerator);
            }
            this.mtspAppliction.Visible = this.mitmAppliction.Visible;
            // 这里添加软件频道的菜单
            this.AddApplictionsMenuItem(this.mitmAppliction);

            // 工作流管理
            if (BaseSystemInfo.UseWorkFlow)
            {
                this.CheckMenuItem(this.mitmWinWorkFlow);
                if (this.mitmWinWorkFlow.Enabled)
                {
                    this.mitmWinWorkFlow.Visible = BaseSystemInfo.UseWorkFlow;

                    this.CheckMenuItem(this.mitmFrmWorkFlowStatr);
                    this.CheckMenuItem(this.mitmFrmWorkFlowWaitForAudit);
                    this.CheckMenuItem(this.mitmFrmWorkFlowMonitor);
                    this.CheckMenuItem(this.mitmFrmWorkFlowProcessAdmin);
                }
            }

            // 基础编码管理
            this.CheckMenuItem(this.mitmFrmItemsAdmin);
            // 这个默认情况下，不会显示，显示状态也不能赋值，要注意
            this.CheckMenuItem(this.mitmFrmSequenceAdmin);
            this.mtspItemsAdmin.Visible = this.CheckMenuItem(this.mitmFrmItemsAdmin) || this.CheckMenuItem(this.mitmFrmSequenceAdmin);

            // 系统日志部分
            this.CheckMenuItem(this.mitmLogAdmin);
            if (this.mitmLogAdmin.Enabled)
            {
                // 这个默认情况下，不会显示，显示状态也不能赋值，要注意
                this.CheckMenuItem(this.mitmFrmLogGeneral);
                this.CheckMenuItem(this.mitmFrmSystemLogByDate);
                this.CheckMenuItem(this.mitmFrmLogByModule);
                this.CheckMenuItem(this.mitmFrmLogByUser);
                this.CheckMenuItem(this.mitmFrmExceptionAdmin);
                this.mitmLogAdmin.Visible = this.CheckMenuItem(this.mitmFrmLogGeneral) || this.CheckMenuItem(this.mitmFrmSystemLogByDate) || this.CheckMenuItem(this.mitmFrmLogByModule) || this.CheckMenuItem(this.mitmFrmLogByUser) || this.CheckMenuItem(this.mitmFrmExceptionAdmin);
                this.mitmLogAdmin.Enabled = this.CheckMenuItem(this.mitmFrmLogGeneral) || this.CheckMenuItem(this.mitmFrmSystemLogByDate) || this.CheckMenuItem(this.mitmFrmLogByModule) || this.CheckMenuItem(this.mitmFrmLogByUser) || this.CheckMenuItem(this.mitmFrmExceptionAdmin);
            }

            // 我的权限
            this.CheckMenuItem(this.mitmSystemAdmin);
            this.CheckMenuItem(this.mitmFrmUserPermission);
            this.mtspSystemAdmin.Visible = this.CheckMenuItem(this.mitmSystemAdmin) || this.CheckMenuItem(this.mitmFrmUserPermission);

            // 修改密码
            this.CheckMenuItem(this.mitmFrmUserChangePassword);
            // 系统配置
            this.CheckMenuItem(this.mitmFrmConfig);
            // 系统配置
            this.CheckMenuItem(this.mitmFrmScreenLock);
            // 关于本软件
            // this.CheckMenuItem(this.mitmFrmAboutThis);
            // this.mtspSupport.Visible = this.mitmFrmAboutThis.Visible;
        }
        #endregion

        #region private bool CheckMenuItem(ToolStripMenuItem toolStripMenuItem)
        /// <summary>
        /// 检查菜单的权限及有效性
        /// </summary>
        /// <param name="toolStripMenuItem">菜单项</param>
        private bool CheckMenuItem(ToolStripMenuItem toolStripMenuItem)
        {
            bool returnValue = true;
            string moduleCode = toolStripMenuItem.Name.Substring(4);
            returnValue = this.ModuleIsVisible(moduleCode);
            toolStripMenuItem.Visible = returnValue;
            // 已经是可见的，再判断是否有效的？若这么写，就错了
            // if (toolStripMenuItem.Visible)
            //{
            if (UserInfo.IsAdministrator)
            {
                toolStripMenuItem.Enabled = true;
            }
            else
            {
                toolStripMenuItem.Enabled = this.IsModuleAuthorized(moduleCode);
                // 没有权限的，进行隐藏处理
                //toolStripMenuItem.Visible = toolStripMenuItem.Enabled;
            }
            // }
            return returnValue;
        }
        #endregion

        // 定义与方法同签名的委托
        private delegate void CallFormMessager(bool show);

        #region public void InitForm() 显示状态信息
        /// <summary>
        /// 初始化窗体
        /// </summary>
        public void InitForm()
        {
            this.notifyIcon.BalloonTipTitle = BaseSystemInfo.SoftFullName;
            this.notifyIcon.BalloonTipText = BaseSystemInfo.SoftFullName;
            this.notifyIcon.Text = BaseSystemInfo.SoftFullName;

            // 获取用户的权限
            ClientCache.Instance.GetUserPermission(UserInfo);
            // CallFormMessager CallFormMessager = new CallFormMessager(CallMessager);
            // CallFormMessager.BeginInvoke(false, null, null);
            // 这里是呼叫即时通讯部分
            this.CallMessager(false);
            // 隐藏本窗口
            this.Hide();
        }
        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 这里需要隐藏主窗体
            this.Hide();
            // 这里显示登录窗体
            Form logOnForm = CacheManager.Instance.GetForm(BaseSystemInfo.MainAssembly, BaseSystemInfo.LogOnForm);
            logOnForm.ShowDialog(this);
        }

        private void contextMenuStrip_Opened(object sender, EventArgs e)
        {
            if (this.contextMenuStrip.Tag == null)
            {
                this.CheckMenu();
                // this.contextMenuStrip.Tag = "Loaded";
            }
        }

        private void mItemExit_Click(object sender, EventArgs e)
        {
            this.ExitApplication = true;
            if (Program.frmMessage != null)
            {
                Program.frmMessage.ExitApplication = true;
                Program.frmMessage.AbortThread();
                Program.frmMessage.Close();
                Program.frmMessage.Dispose();
            }
            this.Close();
        }

        /*
        protected override void WndProc(ref System.Windows.Forms.Message message)
        {       
            switch (message.Msg)
            {
                   
                case 17:
                    // 退出应用程序                    
                    this.ExitApplication = true;
                    DotNetService.LogOnService.OnExit(UserInfo);
                    this.Dispose();
                    break;
                default:
                    base.WndProc(ref message);
                    break;
            }
        }
        */

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*
            if (!this.ExitApplication)
            {
                e.Cancel = true;
                this.Hide();
            }
            else
            {
            */

            if (BaseSystemInfo.UserIsLogOn)
            {
                /*
                简化一下，退出时没必要问是否退出了省事一些。
                #if (!DEBUG)
                    if (MessageBox.Show(AppMessage.MSG0204, AppMessage.MSG0000, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                #endif
                */

                if (Program.frmMessage != null)
                {
                    Program.frmMessage.ExitApplication = true;
                    Program.frmMessage.Dispose();
                }
                // 退出应用程序
                DotNetService dotNetService = new DotNetService();
                dotNetService.LogOnService.OnExit(UserInfo);
                if (dotNetService.LogOnService is ICommunicationObject)
                {
                    ((ICommunicationObject)dotNetService.LogOnService).Close();
                }
            }
        }

        private void SDIMainForm_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        #region 自动锁屏
        private void LoadFormLockInfo()
        {
            // 是否锁定系统，默认是锁定状态
            this.tmrLock.Enabled = false;
            string isLockSystem = DotNetService.Instance.ParameterService.GetParameter(UserInfo, "User", UserInfo.Id, "IsLockSystem");
            if (string.IsNullOrEmpty(isLockSystem))
            {
                this.tmrLock.Enabled = true;
                this.IsLockSystem = true;
            }
            else
            {
                if (isLockSystem.Equals(true.ToString()))
                {
                    this.tmrLock.Enabled = true;
                    this.IsLockSystem = true;
                }
            }
            // 锁定等待时间，默认是60分钟
            string lockWaitMinute = DotNetService.Instance.ParameterService.GetParameter(UserInfo, "User", UserInfo.Id, "LockWaitMinute");
            if (string.IsNullOrEmpty(lockWaitMinute))
            {
                this.LockWaitMinute = 60;
            }
            else
            {
                this.LockWaitMinute = int.Parse(lockWaitMinute);
            }
            // 设定锁屏
            // if (tmrLock.Enabled == false)
            // {
            //    tmrLock.Start();
            // }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct LASTINPUTINFO
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public uint dwTime;
        }

        [DllImport("user32.dll")]
        public static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        public long GetIdleTick()
        {
            LASTINPUTINFO vLastInputInfo = new LASTINPUTINFO();
            vLastInputInfo.cbSize = Marshal.SizeOf(vLastInputInfo);
            if (!GetLastInputInfo(ref vLastInputInfo))
            {
                return 0;
            }
            return Environment.TickCount - (long)vLastInputInfo.dwTime;
        }
        #endregion

        private void mitmOnLine_Click(object sender, EventArgs e)
        {
            // 1.修改用户在线状态
            DotNetService dotNetService = new DotNetService();
            int onLineState = int.Parse(((ToolStripMenuItem)sender).Tag.ToString());
            dotNetService.LogOnService.OnLine(UserInfo, onLineState);
            if (dotNetService.LogOnService is ICommunicationObject)
            {
                ((ICommunicationObject)dotNetService.LogOnService).Close();
            }
            BaseSystemInfo.OnLineState = onLineState;
            // 2.修改按钮状态
            this.mitmOnLine1.Enabled = true;
            this.mitmOnLine2.Enabled = true;
            this.mitmOnLine3.Enabled = true;
            this.mitmOnLine4.Enabled = true;
            this.mitmOnLine5.Enabled = true;
            ((ToolStripMenuItem)sender).Enabled = false;
        }
    }
}