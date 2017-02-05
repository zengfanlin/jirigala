//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace DotNet.WinForm
{
    using DotNet.Utilities;
    using DotNet.Business;

    public partial class MDIMainForm : Form, IBaseMainForm
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
        /// <summary>
        /// 当前用户信息
        /// 这里表示是只读的
        /// 问题点：无法获得登录用户的相关信息 解决：采用继承基类的用户信息
        /// </summary>
        public BaseUserInfo UserInfo
        {
            get
            {
                return BaseSystemInfo.UserInfo;
            }
        }

        public MDIMainForm()
        {
            InitializeComponent();
        }

        public void InitService()
        {
            Program.InitService(UserInfo);
            // Thread Thread = new Thread(new ThreadStart(Program.InitService));
            // Thread.Start();
        }

        /// <summary>
        /// 设置用户信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        public void SetUserInfo(string userName, string password)
        {
        }

        #region public void InitForm() 显示状态信息
        /// <summary>
        /// 初始化窗体
        /// </summary>
        public void InitForm()
        {
            // 获取用户的权限
            ClientCache.Instance.GetUserPermission(UserInfo);
            this.CheckMenu();
        }
        #endregion

        #region private void CheckMenu() 获得的菜单
        /// <summary>
        /// 获得的菜单
        /// </summary>
        public void CheckMenu()
        {
            // 这里是加载菜单
            if (BaseSystemInfo.UserIsLogOn)
            {
                this.LoadTree();
            }
        }
        #endregion

        #region private void LoadTree() 加载树形结构数据
        /// <summary>
        /// 加载树形结构数据
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvModule.BeginUpdate();
            this.tvModule.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTreeModule(treeNode);
            if (BaseInterfaceLogic.TargetNode != null)
            {
                this.tvModule.SelectedNode = BaseInterfaceLogic.TargetNode;
                BaseInterfaceLogic.ExpandTreeNode(this.tvModule);
                this.tvModule.SelectedNode.EnsureVisible();
                this.tvModule.SelectedNode.Expand();
            }
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvModule.EndUpdate();
        }
        #endregion

        #region private void LoadTreeModule(TreeNode treeNode)
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeModule(TreeNode treeNode)
        {
            foreach (DataRow dataRow in ClientCache.Instance.DTUserMoule.Rows)
            {
                // 判断不为空的当前节点的子节点
                if ((treeNode.Tag != null) && (!((BaseModuleEntity)treeNode.Tag).Id.ToString().Equals(dataRow[BaseModuleEntity.FieldParentId].ToString())))
                {
                    continue;
                }
                // 当前节点的子节点, 加载根节点
                if ((dataRow.IsNull(BaseModuleEntity.FieldParentId) || (dataRow[BaseModuleEntity.FieldParentId].ToString().Length == 0) || (dataRow[BaseModuleEntity.FieldParentId].ToString().Equals("0")) || (dataRow[BaseModuleEntity.FieldCode].ToString().Equals(BaseSystemInfo.RootMenuCode)) || ((treeNode.Tag != null) && ((BaseModuleEntity)treeNode.Tag).Id.ToString().Equals(dataRow[BaseModuleEntity.FieldParentId].ToString()))))
                {
                    BaseModuleEntity moduleEntity = new BaseModuleEntity(dataRow);
                    TreeNode newTreeNode = new TreeNode();
                    newTreeNode.Text = moduleEntity.FullName;
                    newTreeNode.Tag = moduleEntity;
                    newTreeNode.Checked = (moduleEntity.Enabled == 1);
                    
                    /*
                    if (newTreeNode.Level < 2 || dataRow[BaseModuleEntity.FieldExpand].ToString().Equals("1"))
                    {
                        newTreeNode.Expand();
                    }
                    else
                    {
                        newTreeNode.Collapse(true);
                    }
                    */

                    if ((treeNode.Tag == null) || ((treeNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString().Length == 0))
                    {
                        // 树的根节点加载，只加载指定的系统
                        if (dataRow[BaseModuleEntity.FieldCode].ToString().Equals(BaseSystemInfo.RootMenuCode))
                        {
                            this.tvModule.Nodes.Add(newTreeNode);
                        }
                    }
                    else
                    {
                        // 节点的子节点加载
                        treeNode.Nodes.Add(newTreeNode);
                        if (treeNode.Level < 1)
                        {
                            treeNode.Expand();
                        }
                    }
                    // 递归调用本函数
                    this.LoadTreeModule(newTreeNode);
                }
            }
        }
        #endregion

        #region private void LoadChildrenForm(string assemblyName, string formName)
        /// <summary>
        /// 加载选定的子窗口
        /// </summary>
        /// <param name="assemblyName">程序集</param>
        /// <param name="selectedNodeName">当前选择的窗体名称</param>
        private void LoadChildrenForm(string assemblyName, string formName)
        {
            if (formName.Length == 0)
            {
                return;
            }
            // 是否已经打开了？
            foreach (Form childrenForm in this.MdiChildren)
            {
                if (childrenForm.Name == formName)
                {
                    childrenForm.Visible = true;
                    childrenForm.Activate();
                    return;
                }
            }
            // 一些特殊的页面处理。
            switch (formName)
            {
                case "FormLogOn":
                    // 关闭所有打开的窗口
                    foreach (Form childrenForm in this.MdiChildren)
                    {
                        childrenForm.Close();
                    }
                    this.ShowChildrenForm(assemblyName, formName);
                    break;
                case "FrmScreenLock":
                    {
                        tmrLock.Stop();
                        DotNet.WinForm.FrmScreenLock lcForm = new FrmScreenLock();
                        if (lcForm.ShowDialog(this) == DialogResult.OK)
                        {
                            LoadFormLockInfo();
                        }
                    }
                    break;
                default:
                    this.ShowChildrenForm(assemblyName, formName);
                    return;
            }
        }
        #endregion

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

        public long getIdleTick()
        {
            LASTINPUTINFO vLastInputInfo = new LASTINPUTINFO();
            vLastInputInfo.cbSize = Marshal.SizeOf(vLastInputInfo);
            if (!GetLastInputInfo(ref vLastInputInfo))
            {
                return 0;
            }
            return Environment.TickCount - (long)vLastInputInfo.dwTime;
        }

        private void tmrLock_Tick(object sender, EventArgs e)
        {

        }
        #endregion

        // 这里是性能改进，为了只加载一次，命名空间不一样时需要改进一下此方法
        private object CreateInstance(string assemblyName, string formName)
        {
            Assembly assembly = Assembly.Load(assemblyName);
            Type type = assembly.GetType(assemblyName + "." + formName, true, false);
            return Activator.CreateInstance(type);
        }

        private Form ShowChildrenForm(string assemblyName, string formName)
        {
            Form childrenForm = (Form)this.CreateInstance(assemblyName, formName);
            if (childrenForm != null)
            {
                childrenForm.Name = formName;
                childrenForm.MdiParent = this;
                childrenForm.ShowInTaskbar = false;
                if (childrenForm is IBaseForm)
                {
                    ((IBaseForm)childrenForm).OnButtonStateChange += new BaseForm.SetControlStateEventHandler(SetControlState);
                }
                childrenForm.Show();
            }
            return childrenForm;
        }

        /// <summary>
        /// 设置按钮的可用状态
        /// </summary>
        /// <param name="setTop">置顶</param>
        /// <param name="setUp">上移</param>
        /// <param name="setDown">下移</param>
        /// <param name="setBottom">置底</param>
        /// <param name="add">添加</param>
        /// <param name="edit">编辑</param>
        /// <param name="batchDelete">批量删除</param>
        /// <param name="batchSave">批量保存</param>
        public void SetControlState(bool setTop, bool setUp, bool setDown, bool setBottom, bool add, bool edit, bool batchDelete, bool batchSave)
        {
            this.tsbSetTop.Enabled = setTop;
            this.tsbSetUp.Enabled = setUp;
            this.tsbSetDown.Enabled = setDown;
            this.tsbSetBottom.Enabled = setBottom;
            this.tsbAdd.Enabled = add;
            this.tsbEdit.Enabled = edit;
            this.tsbDelete.Enabled = batchDelete;
            this.tsbSave.Enabled = batchSave;
        }

        private void MDIMainForm_MdiChildActivate(object sender, EventArgs e)
        {
            if ((this.ActiveMdiChild != null) && (this.ActiveMdiChild is IBaseForm))
            {
                ((IBaseForm)this.ActiveMdiChild).SetControlState();
            }
            else
            {
                // 没有子窗体了
                this.SetControlState(false, false, false, false, false, false, false, false);
            }
        }

        private void tsbSetTop_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                ((IBaseForm)this.ActiveMdiChild).SetTop();
            }
        }

        private void tsbSetUp_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                ((IBaseForm)this.ActiveMdiChild).SetUp();
            }

        }

        private void tsbSetDown_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                ((IBaseForm)this.ActiveMdiChild).SetDown();
            }
        }

        private void tsbSetBottom_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                ((IBaseForm)this.ActiveMdiChild).SetBottom();
            }
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                ((IBaseForm)this.ActiveMdiChild).Add();
            }
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                ((IBaseForm)this.ActiveMdiChild).Edit();
            }
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                ((IBaseForm)this.ActiveMdiChild).Delete();
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null)
            {
                ((IBaseForm)this.ActiveMdiChild).Save();
            }
        }

        private void MDIMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BaseSystemInfo.UserIsLogOn)
            {
                if (MessageBox.Show(AppMessage.MSG0204, AppMessage.MSG0000, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
                if (Program.frmMessage != null)
                {
                    Program.frmMessage.ExitApplication = true;
                    Program.frmMessage.Dispose();
                }
                // 退出应用程序
                DotNetService.Instance.LogOnService.OnExit(UserInfo);
            }
        }

        private void MDIMainForm_Load(object sender, EventArgs e)
        {
            Form logOnForm = CacheManager.Instance.GetForm(BaseSystemInfo.MainAssembly, BaseSystemInfo.LogOnForm);
            logOnForm.ShowDialog(this);
        }

        private void tvModule_DoubleClick(object sender, EventArgs e)
        {
            if (this.tvModule.SelectedNode != null && this.tvModule.SelectedNode.Tag != null)
            {
                if (!string.IsNullOrEmpty(((BaseModuleEntity)this.tvModule.SelectedNode.Tag).Target))
                {
                    if (!string.IsNullOrEmpty(((BaseModuleEntity)this.tvModule.SelectedNode.Tag).Code))
                    {
                        string assemblyName = ((BaseModuleEntity)this.tvModule.SelectedNode.Tag).Target;
                        string formName = ((BaseModuleEntity)this.tvModule.SelectedNode.Tag).Code;
                        this.LoadChildrenForm(assemblyName, formName);
                    }
                }
            }
        }

        private void btnLogOnWeb_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://localhost:2866/Default.aspx?OpenId=" + UserInfo.OpenId);
        }

        private void btn_Click(object sender, EventArgs e)
        {
            string formName = ((Button)sender).Text;
            string assemblyName = BaseSystemInfo.MainAssembly;
            if (((Button)sender).Tag != null)
            {
                assemblyName = ((Button)sender).Tag.ToString();
            }
            this.LoadChildrenForm(assemblyName, formName);
        }

        private void MDIMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}