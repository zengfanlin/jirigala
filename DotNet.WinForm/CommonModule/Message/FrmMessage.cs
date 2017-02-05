//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmMessage.cs
    /// 即时通讯
    ///		
    /// 修改记录
    /// 
    ///     2011.12.25 版本：1.4 JiRiGaLa  当在别的地方登录时，这里需要退出。
    ///     2011.09.27 版本：1.3 JiRiGaLa  修正多用户出错的问题，组织机构的方法需要释放。
    ///     2011.09.21 版本：1.2 JiRiGaLa  在闲状态出错时的友善处理。
    ///     2009.08.27 版本：1.1 JiRiGaLa  按用户主键发送即时信息。
    ///     2007.10.30 版本：1.0 JiRiGaLa  即时通讯。
    ///		
    /// 版本：1.4
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.12.25</date>
    /// </author> 
    /// </summary>
    public partial class FrmMessage : BaseForm
    {
        /// <summary>
        /// 用户表
        /// </summary>
        private DataTable DTUser = new DataTable(BaseUserEntity.TableName);

        /// <summary>
        /// 业务角色
        /// </summary>
        private DataTable DTApplicationRole = new DataTable(BaseRoleEntity.TableName);

        /// <summary>
        /// 用户群组
        /// </summary>
        private DataTable DTUserGroup = new DataTable(BaseRoleEntity.TableName);

        /// <summary>
        /// 组织机构表
        /// </summary>
        private DataTable DTOrganize = new DataTable(BaseOrganizeEntity.TableName);

        /// <summary>
        /// 消息检测的线程
        /// </summary>
        private Thread MessageThread = null;

        /// <summary>
        /// 在线检测的线程
        /// </summary>
        private Thread OnLineThread = null;

        public FrmMessage()
        {
            InitializeComponent();
            if (!this.DesignMode)
            {
                // 记录表单的位置
                if (BaseSystemInfo.MainForm.Equals("SDIMainForm"))
                {
                    FormPostion formPostion = new FormPostion();
                    formPostion.RegistryPath = "Hairihan TECH" + "\\" + BaseSystemInfo.RootMenuCode + "\\FormPostion\\" + this.Name + "\\" + UserInfo.Id;
                    formPostion.Parent = this;
                }
            }
        }

        public delegate bool OnReceiveMessageEventHandler(BaseMessageEntity messageEntity);

        //Pcsky 2012.05.02 未使用的功能，禁用
        //public event OnReceiveMessageEventHandler OnReceiveMessage;

        // 已打开的窗口列表
        private ArrayList receiveUserList = new ArrayList();
        public ArrayList ReceiveUserList
        {
            get
            {
                return receiveUserList;
            }
            set
            {
                receiveUserList = value;
            }
        }

        #region private void BindData(bool reloadTree) 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        /// <param name="reloadTree">重新加载树</param>
        private void BindData(bool reloadTree)
        {
            // 加载树
            if (reloadTree)
            {
                this.LoadOrganizeTree();
                this.LoadApplicationRole();
                this.LoadUserGroup();
            }
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 设置按钮状态
            // this.SetControlState();
            // 若是在忙碌状态，退出本程序
            // if (!this.FormLoaded || this.Busyness)
            //{
            //    return;
            //}

            // 设置鼠标繁忙状态，并保留原先的状态
            Cursor holdCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            // 设置开关变量
            this.Busyness = true;
            this.FormLoaded = false;

            // 设置窗体的显示位置
            if (this.WindowState == FormWindowState.Normal)
            {
                Rectangle rectangle = System.Windows.Forms.SystemInformation.VirtualScreen;
                int width = rectangle.Width;
                int height = rectangle.Height;
                this.Left = width - this.Width;
            }

            try
            {
                DotNetService dotNetService = new DotNetService();
                this.DTOrganize = dotNetService.MessageService.GetInnerOrganizeDT(this.UserInfo);
                this.DTApplicationRole = dotNetService.RoleService.GetApplicationRole(this.UserInfo);
                this.DTUserGroup = dotNetService.RoleService.GetUserGroup(this.UserInfo);
                if (dotNetService.MessageService is ICommunicationObject)
                {
                    ((ICommunicationObject)dotNetService.MessageService).Close();
                }
                // 过滤数据
                // BaseBusinessLogic.SetFilter(this.DTOrganize, BaseOrganizeEntity.FieldEnabled, "1");
                // 只显示内部部门
                // BUBaseBusinessLogic.SetFilter(this.DTOrganize, BaseOrganizeEntity.FieldIsInnerOrganize, "1");
                // this.DTOrganize.AcceptChanges();
                // 绑定屏幕数据
                this.BindData(true);
                if (this.tvOrganize.Nodes.Count > 0)
                {
                    this.tvOrganize.Nodes[0].Expand();
                }
                // 阅读消息
                // this.timerMessage.Enabled = true;
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

            if (BaseSystemInfo.UseMessage)
            {
                this.MessageThread = new Thread(new ThreadStart(this.CheckNewMessage));
                MessageThread.Start();
                this.OnLineThread = new Thread(new ThreadStart(this.CheckOnLineState));
                OnLineThread.Start();
            }

            this.FormLoaded = true;
            this.Busyness = false;
        }
        #endregion

        //#region private void LoadTree() 加载树
        ///// <summary>
        ///// 加载树
        ///// </summary>
        //private void LoadTree()
        //{
        //    // 开始更新控件，屏幕不刷新，提高效率。
        //    this.tvOrganize.BeginUpdate();
        //    this.tvOrganize.Nodes.Clear();
        //    TreeNode treeNode = new TreeNode();
        //    this.LoadOrganizeTree(treeNode);
        //    // 更新控件，屏幕一次性刷新，提高效率。
        //    this.tvOrganize.EndUpdate();
        //}
        //#endregion

        //#region private void LoadOrganizeTree(TreeNode treeNode)
        ///// <summary>
        ///// 加载组织机构树的主键
        ///// </summary>
        ///// <param name="treeNode">当前节点</param>
        //private void LoadOrganizeTree(TreeNode treeNode)
        //{
        //    /*
        //    if ((BaseSystemInfo.UseScopeAdmin) && !UserInfo.IsAdministrator)
        //    {
        //    }
        //    */
        //    // 即时消息组件没必要按权限范围过滤，这里假设直接跟内部用户沟通用的
        //    // BaseInterfaceLogic.CheckTreeParentId(this.DTOrganize, BaseOrganizeEntity.FieldId, BaseOrganizeEntity.FieldParentId);
        //    BaseInterfaceLogic.LoadTreeNodes(this.DTOrganize, BaseOrganizeEntity.FieldId, BaseOrganizeEntity.FieldParentId, BaseOrganizeEntity.FieldFullName, this.tvOrganize, treeNode);
        //}
        //#endregion

        #region private void LoadOrganizeTree() 加载树
        /// <summary>
        /// 加载树
        /// </summary>
        private void LoadOrganizeTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvOrganize.BeginUpdate();
            this.tvOrganize.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadOrganizeTree(treeNode);
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvOrganize.EndUpdate();
        }
        #endregion

        #region private void LoadOrganizeTree(TreeNode treeNode)
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadOrganizeTree(TreeNode treeNode)
        {
            /*
            if ((BaseSystemInfo.UseScopeAdmin) && !UserInfo.IsAdministrator)
            {
            }
            */
            // 即时消息组件没必要按权限范围过滤，这里假设直接跟内部用户沟通用的
            this.LoadTreeNodes(this.DTOrganize, BaseOrganizeEntity.FieldId, BaseOrganizeEntity.FieldParentId, BaseOrganizeEntity.FieldFullName, this.tvOrganize, treeNode);
        }
        #endregion

        #region private void LoadTreeNodes(DataTable dataTable, string fieldId, string fieldParentId, string fieldFullName, TreeView treeView, TreeNode treeNode, bool loadTree = true)
        /// <summary>
        /// 加载树型结构的主键
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="fieldId">主键</param>
        /// <param name="fieldParentId">上级字段</param>
        /// <param name="fieldFullName">全称</param>
        /// <param name="treeNode">当前树结点</param>
        private void LoadTreeNodes(DataTable dataTable, string fieldId, string fieldParentId, string fieldFullName, TreeView treeView, TreeNode treeNode, bool loadTree = true)
        {
            BaseOrganizeEntity organizeEntity = new BaseOrganizeEntity();
            // 查找 ParentId 字段的值是否在 Id字段 里
            // 一般情况是简单的数据过滤，就没必要进行严格的检查了，进行了严格的检查，反而降低运行效率
            DataRow[] dataRows = null;
            if (treeNode.Tag == null)
            {
                if (dataTable.Columns[fieldId].DataType == typeof(int)
                    || (dataTable.Columns[fieldId].DataType == typeof(Int16))
                    || (dataTable.Columns[fieldId].DataType == typeof(Int32))
                    || (dataTable.Columns[fieldId].DataType == typeof(Int64))
                    || dataTable.Columns[fieldId].DataType == typeof(decimal))
                {
                    dataRows = dataTable.Select(fieldParentId + " IS NULL OR " + fieldParentId + " = 0");
                }
                else
                {
                    dataRows = dataTable.Select(fieldParentId + " IS NULL OR " + fieldParentId + " = ''");
                }
            }
            else
            {
                dataRows = dataTable.Select(fieldParentId + "=" + ((BaseOrganizeEntity)treeNode.Tag).Id.ToString());
            }
            foreach (DataRow dataRow in dataRows)
            {
                // 节点不为空，并且是当前节点的子节点
                if ((treeNode.Tag != null) && !(((BaseOrganizeEntity)treeNode.Tag).Id.ToString().Equals(dataRow[fieldParentId].ToString())))
                {
                    continue;
                }
                // 当前节点的子节点, 加载根节点
                if (dataRow.IsNull(fieldParentId)
                    || (dataRow[fieldParentId].ToString() == "0")
                    || (dataRow[fieldParentId].ToString().Length == 0)
                    || ((treeNode.Tag != null) && (((BaseOrganizeEntity)treeNode.Tag).Id.ToString().Equals(dataRow[fieldParentId].ToString()))))
                {
                    TreeNode newTreeNode = new TreeNode();
                    newTreeNode.Text = dataRow[fieldFullName].ToString();
                    newTreeNode.Tag = new BaseOrganizeEntity(dataRow);
                    if ((treeNode.Tag == null))
                    {
                        // 树的根节点加载
                        treeView.Nodes.Add(newTreeNode);
                    }
                    else
                    {
                        // 节点的子节点加载，第一层节点需要展开                        
                        treeNode.Nodes.Add(newTreeNode);
                    }
                    if (loadTree)
                    {
                        // 递归调用本函数
                        LoadTreeNodes(dataTable, fieldId, fieldParentId, fieldFullName, treeView, newTreeNode, loadTree);
                    }
                }
            }
        }
        #endregion

        #region private void LoadRole() 加载业务角色
        /// <summary>
        /// 加载业务角色
        /// </summary>
        private void LoadApplicationRole()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvApplicationRole.BeginUpdate();
            this.tvApplicationRole.Nodes.Clear();

            BaseRoleEntity roleEntity = null;
            foreach (DataRow dataRow in this.DTApplicationRole.Rows)
            {
                roleEntity = new BaseRoleEntity(dataRow);
                // 当前节点的子节点, 加载根节点
                TreeNode treeNode = new TreeNode();
                treeNode.Text = roleEntity.RealName;
                // treeNode.Tag = roleEntity;
                treeNode.Tag = roleEntity.Id;
                this.tvApplicationRole.Nodes.Add(treeNode);
            }
            this.tvApplicationRole.EndUpdate();
        }
        #endregion

        #region private void LoadUserGroup() 加载角色
        /// <summary>
        /// 加载角色
        /// </summary>
        private void LoadUserGroup()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvUserGroup.BeginUpdate();
            this.tvUserGroup.Nodes.Clear();

            BaseRoleEntity roleEntity = null;
            foreach (DataRow dataRow in this.DTUserGroup.Rows)
            {
                roleEntity = new BaseRoleEntity(dataRow);
                // 当前节点的子节点, 加载根节点
                TreeNode treeNode = new TreeNode();
                treeNode.Text = roleEntity.RealName;
                treeNode.Tag = roleEntity.Id;
                // treeNode.Tag = roleEntity;
                this.tvUserGroup.Nodes.Add(treeNode);
            }
            this.tvUserGroup.EndUpdate();
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 加载系统信息
            // 名字可能会变掉，重新登录或者扮演时
            this.Text += " (" + UserInfo.RealName + ")";
            if (this.UserInfo.IsAdministrator)
            {
                this.mitmFrmWorkReportList.Enabled = true;
                this.mitmFrmUserPermission.Enabled = true;
                this.mitmFrmUserEdit.Enabled = true;
                this.mitmFrmUserRoleAdmin.Enabled = true;
                this.mitmFrmUserPermission.Enabled = true;
                this.mitmFrmUserPermissionAdmin.Enabled = true;
                this.mitmFrmStaffAddressEdit.Enabled = true;
                this.mitmApplicationRole.Enabled = true;
                this.mitmFrmLogByUser.Enabled = true;
            }
            else
            {
                this.mitmFrmWorkReportList.Enabled = false;
                this.mitmFrmUserPermission.Enabled = false;
                this.mitmFrmUserEdit.Enabled = false;
                this.mitmFrmUserRoleAdmin.Enabled = false;
                this.mitmFrmUserPermission.Enabled = false;
                this.mitmFrmUserPermissionAdmin.Enabled = false;
                this.mitmFrmStaffAddressEdit.Enabled = false;
                this.mitmApplicationRole.Enabled = false;
                this.mitmFrmLogByUser.Enabled = false;
            }
        }
        #endregion

        // 定义与方法同签名的委托
        private delegate void CallFormOnLoad();

        // 监测新信息
        delegate void SetGetNewMessage();

        private void CheckNewMessage()
        {
            while (!this.ExitApplication)
            {
                // this.Text += " (" + UserInfo.RealName + ")";
                if (this.FormLoaded && (!this.Busyness))
                {
                    this.GetNewMessage();
                    Thread.Sleep(4 * 1000 + BaseRandom.GetRandom(100, 1000));
                }
                Thread.Sleep(1000 + BaseRandom.GetRandom(100, 1000));
            }
        }

        private void GetNewMessage()
        {
            if (!this.ExitApplication)
            {
                if (this.FormLoaded && (!this.Busyness))
                {
                    if (this.tvOrganize.InvokeRequired)
                    {
                        if (!this.ExitApplication)
                        {
                            SetGetNewMessage getNewMessage = new SetGetNewMessage(this.GetNewMessage);
                            if (getNewMessage != null)
                            {
                                this.Invoke(getNewMessage);
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            // 获取最新即时通讯消息
                            DotNetService dotNetService = new DotNetService();
                            //  这里获取用户的登录凭证，看与本地的是否一致？
                            string openId = string.Empty;
                            DataTable dataTable = dotNetService.MessageService.GetDataTableNew(this.UserInfo, out openId);
                            if ((dataTable != null) && (dataTable.Rows.Count > 0))
                            {
                                BaseMessageEntity messageEntity = new BaseMessageEntity();
                                for (int i = 0; i < dataTable.Rows.Count; i++)
                                {
                                    messageEntity.GetFrom(dataTable.Rows[i]);
                                    if (messageEntity.FunctionCode.Equals("Message"))
                                    {
                                        this.ShowMessage(messageEntity);
                                    }
                                    else
                                    {
                                        this.ShowRemind(messageEntity);
                                    }
                                    // 将信息标记为已阅读
                                    dotNetService.MessageService.Read(UserInfo, messageEntity.Id);
                                }
                                if (dotNetService.MessageService is ICommunicationObject)
                                {
                                    ((ICommunicationObject)dotNetService.MessageService).Close();
                                }
                            }
                            // 若检查在线状态，根本就无法登录了，所以加上这样的判断
                            if (BaseSystemInfo.CheckOnLine && !UserInfo.OpenId.Equals(openId))
                            {
                                if (Program.frmMessage != null)
                                {
                                    Program.frmMessage.ExitApplication = true;
                                    Program.frmMessage.AbortThread();
                                    Program.frmMessage.Close();
                                    Program.frmMessage.Dispose();
                                }
                                // 修改当前用户的登录状态
                                BaseSystemInfo.UserIsLogOn = false;
                                if (MessageBox.Show(AppMessage.MSG0300, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Stop) == System.Windows.Forms.DialogResult.OK)
                                {
                                    Application.Exit();
                                }
                            }
                        }
                        catch (System.Exception ex)
                        {
                            // 在本地记录异常
                            FileUtil.WriteException(UserInfo, ex);
                        }
                    }
                }
            }
        }

        private void CheckOnLineState()
        {
            while (!this.ExitApplication)
            {
                if (this.FormLoaded && (!this.Busyness))
                {
                    // 若已经是最小化、或者被隐藏起来了，就不用获取在线状态，可以提高效率
                    if (this.WindowState != FormWindowState.Minimized || this.Visible)
                    {
                        this.GetOnLineState();
                        Thread.Sleep(10 * 1000 + BaseRandom.GetRandom(100, 20000));
                    }
                }
                // 2010.09.08 当在线人数过多时会影响性能
                Thread.Sleep(10 * 1000 + BaseRandom.GetRandom(100, 20000));
            }
        }

        private void lblRemind_Click(object sender, EventArgs e)
        {
            // if (this.lblRemind.Tag != null)
            // {
            //    FrmMessageRead frmMessageRead = new FrmMessageRead(this.lblRemind.Tag.ToString(), this.lblRemind.Tag.ToString());
            //    this.lblRemind.Text = string.Empty;
            //    this.lblRemind.Tag = null;
            //    frmMessageRead.Show();
            // }
        }

        #region private bool UserLoaded(TreeNode treeNode) 是否已经加载了用户
        /// <summary>
        /// 是否已经加载了用户
        /// </summary>
        /// <param name="TreeNode">目标节点</param>
        /// <returns>是否</returns>
        private bool UserLoaded(TreeNode treeNode)
        {
            bool returnValue = false;
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                if (treeNode.Nodes[i].ImageIndex > 2)
                {
                    returnValue = true;
                    break;
                }
            }
            return returnValue;
        }
        #endregion

        #region private void GetUserList(TreeNode selectedNode) 获得表格里的用户
        /// <summary>
        /// 获得表格里的用户
        /// </summary>
        private void GetUserList(TreeNode selectedNode)
        {
            // 设置鼠标繁忙状态，并保留原先的状态
            // Cursor holdCursor = this.Cursor;
            // this.Cursor = Cursors.WaitCursor;

            // 当前是空节点
            if (selectedNode == null)
            {
                return;
            }
            // 当前节点是用户节点
            if (selectedNode.StateImageIndex > 2)
            {
                return;
            }
            // 是否已经加了用户节点
            if (selectedNode.Nodes.Count != 0)
            {
                // return;
            }
            // 检查是否已经加载了用户
            if (this.UserLoaded(selectedNode))
            {
                selectedNode.Nodes.Clear();
            }
            try
            {
                DotNetService dotNetService = new DotNetService();
                string id = ((BaseOrganizeEntity)selectedNode.Tag).Id.ToString();
                if (this.tcMessage.SelectedTab == this.tpOrganize)
                {
                    this.DTUser = dotNetService.MessageService.GetUserDTByOrganize(UserInfo, id);
                }
                else
                {
                    this.DTUser = dotNetService.MessageService.GetUserDTByRole(UserInfo, id);
                }
                if (dotNetService.MessageService is ICommunicationObject)
                {
                    ((ICommunicationObject)dotNetService.MessageService).Close();
                }
                // 过滤数据
                // BaseBusinessLogic.SetFilter(this.DTStaff, BaseStaffEntity.FieldEnabled, "1");
                // BaseBusinessLogic.SetFilter(this.DTStaff, BaseStaffEntity.FieldDeletionStateCode, "0");
                foreach (DataRow dataRow in this.DTUser.Rows)
                {
                    if (!String.IsNullOrEmpty(dataRow[BaseUserEntity.FieldId].ToString()))
                    {
                        TreeNode treeNode = new TreeNode();
                        treeNode.Tag = new BaseUserEntity(dataRow);
                        treeNode.Text = dataRow[BaseUserEntity.FieldRealName].ToString();
                        this.SetTreeNodeState(treeNode, dataRow[BaseUserEntity.FieldUserOnLine].ToString());
                        selectedNode.Nodes.Add(treeNode);
                    }
                }
            }
            catch (System.Exception ex)
            {
                this.WriteException(ex);
            }
            // 设置鼠标默认状态，原来的光标状态
            // this.Cursor = holdCursor;
        }
        #endregion

        private void tvTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.FormLoaded)
            {
                TreeView treeView = (TreeView)sender;
                if (treeView.SelectedNode != null)
                {
                    if (treeView.SelectedNode.Tag != null)
                    {
                        // 当前节点是用户节点
                        if ((treeView.SelectedNode.SelectedImageIndex < 2) && !this.UserLoaded(treeView.SelectedNode))
                        {
                            this.GetUserList(treeView.SelectedNode);
                        }
                    }
                }
            }
        }

        #region private void MessageChek() 阅读消息状态
        /*
        private DateTime LastChekDate = DateTime.MinValue;
        
        /// <summary>
        /// 阅读消息状态
        /// </summary>
        private void MessageChek()
        {
            DotNetService dotNetService = new DotNetService();
            string[] returnValue = dotNetService.MessageService.MessageChek(UserInfo, BaseSystemInfo.OnLineState, string.Empty);
            if (dotNetService.MessageService is ICommunicationObject)
            {
                ((ICommunicationObject)dotNetService.MessageService).Close();
            }
            // 0.新信息的个数
            // 1.最后检查时间
            // 2.最新消息的发出者
            // 3.最新消息的发出者名称
            // 4.最新消息的主键
            // 5.最新信息的内容
            if (!String.IsNullOrEmpty(returnValue[0]))
            {
                int newMessageCount = int.Parse(returnValue[0]);
                if (newMessageCount == 0)
                {
                    // this.lblRemind.Text = string.Empty;
                    // this.helpProvider.SetHelpString(this.lblRemind, string.Empty);
                    // this.lblRemind.Tag = null;
                    return;
                }
                if (!String.IsNullOrEmpty(returnValue[1]))
                {
                    DateTime lastChekDate = DateTime.Parse(returnValue[1]);
                    if (!lastChekDate.Equals(this.LastChekDate))
                    {
                        this.LastChekDate = lastChekDate;
                        // this.lblRemind.Text = "(" + returnValue[0] + ")" + returnValue[3];
                        // this.helpProvider.SetHelpString(this.lblRemind, returnValue[3]);
                        // this.lblRemind.Tag = returnValue[2];
                        if (this.frmMessageRemind == null)
                        {
                            this.frmMessageRemind = new FrmMessageRemind();
                        }
                        else
                        {
                            this.frmMessageRemind.OnReceiveMessage(returnValue[5]);
                        }
                        frmMessageRemind.Show(this);
                    }
                }
            }
        }
        */
        #endregion

        FrmMessageRemind frmMessageRemind = null;

        public void ShowRemind(BaseMessageEntity messageEntity)
        {
            if (this.frmMessageRemind == null || !this.frmMessageRemind.Visible)
            {
                this.frmMessageRemind = new FrmMessageRemind();
                frmMessageRemind.Show(this);
            }
            this.frmMessageRemind.OnReceiveMessage(messageEntity);
        }

        public FrmMessageRead ShowMessageRead(string receiverId, IWin32Window owner, FormStartPosition formStartPosition)
        {
            FrmMessageRead frmMessageRead = null;
            if (!this.ReceiveUserList.Contains(receiverId))
            {
                this.ReceiveUserList.Add(receiverId);
                frmMessageRead = new FrmMessageRead(receiverId);
                frmMessageRead.FrmMessageOwner = this;
                frmMessageRead.Owner = this;
                frmMessageRead.StartPosition = formStartPosition;
                // Pcsky 2012.05.02 未使用的功能，禁用
                // this.OnReceiveMessage += frmMessageRead.OnReceiveMessage;
                frmMessageRead.Show();
            }
            else
            {
                for (int i = 0; i < this.OwnedForms.Length; i++)
                {
                    if (this.OwnedForms[i] is FrmMessageRead)
                    {
                        if (((FrmMessageRead)this.OwnedForms[i]).ReceiverId.Equals(receiverId))
                        {
                            frmMessageRead = (FrmMessageRead)this.OwnedForms[i];
                            frmMessageRead.FrmMessageOwner = this;
                            frmMessageRead.Activate();
                        }
                    }
                }
            }
            return frmMessageRead;
        }

        public FrmMessageRead ShowMessageRead(string receiverId, IWin32Window owner)
        {
            return this.ShowMessageRead(receiverId, owner, FormStartPosition.WindowsDefaultLocation);
        }

        public FrmMessageRead ShowMessageRead(string receiverId)
        {
            return this.ShowMessageRead(receiverId, this);
        }

        public void ShowMessage(BaseMessageEntity messageEntity)
        {
            if (!string.IsNullOrEmpty(messageEntity.CreateUserId))
            {
                // 检查窗体，是否已经打开了窗体
                FrmMessageRead frmMessageRead = this.ShowMessageRead(messageEntity.CreateUserId, this);
                if (frmMessageRead != null)
                {
                    frmMessageRead.OnReceiveMessage(messageEntity);
                }
            }
        }

        private void tvTree_DoubleClick(object sender, EventArgs e)
        {
            TreeView treeView = (TreeView)sender;
            if (treeView.SelectedNode != null)
            {
                if (treeView.SelectedNode.Tag != null)
                {
                    // 当前节点是用户节点
                    if (treeView.SelectedNode.SelectedImageIndex > 2)
                    {
                        // 不允许自己跟自己通讯
                        if (!UserInfo.Id.Equals(((BaseUserEntity)treeView.SelectedNode.Tag).Id.ToString()))
                        {
                            this.ShowMessageRead(((BaseUserEntity)treeView.SelectedNode.Tag).Id.ToString(), this, FormStartPosition.CenterScreen);
                        }
                    }
                }
            }
        }

        private void tvTree_Click(object sender, EventArgs e)
        {
            TreeView treeView = (TreeView)sender;
            if ((treeView.SelectedNode != null) && (treeView.SelectedNode.Tag != null) && (treeView.SelectedNode.SelectedImageIndex > 2))
            {
                // 当前节点是用户节点
                treeView.ContextMenuStrip = this.cMnuUser;
            }
            else
            {
                treeView.ContextMenuStrip = null;
            }
        }

        private void MoveUserTo(string userId, TreeNode targetTreeNode)
        {
            // 目标机构信息
            string companyId = null;
            string companyName = string.Empty;
            string departmentId = null;
            string departmentName = string.Empty;
            string workgroupId = null;
            string workgroupName = string.Empty;

            BaseUserEntity userEntity = DotNetService.Instance.UserService.GetEntity(this.UserInfo, userId);
            string staffId = DotNetService.Instance.StaffService.GetId(this.UserInfo, BaseStaffEntity.FieldUserId, userEntity.Id);
            BaseStaffEntity staffEntity = DotNetService.Instance.StaffService.GetEntity(this.UserInfo, staffId);
            // 获得目标节点公司信息,其实只要从当前节点一直往上遍历就可以了，直接被拖到公司的，部门、工作自然就null了
            while (targetTreeNode != null)
            {
                string targetOrganizeCategory = ((BaseOrganizeEntity)targetTreeNode.Tag).Category;
                if (!string.IsNullOrEmpty(targetOrganizeCategory))
                {
                    if (targetOrganizeCategory == "WorkGroup")
                    {
                        workgroupId = ((BaseOrganizeEntity)targetTreeNode.Tag).Id.ToString();
                        workgroupName = ((BaseOrganizeEntity)targetTreeNode.Tag).FullName;
                    }

                    if (targetOrganizeCategory == "Department"
                        || targetOrganizeCategory == "SubDepartment")
                    {
                        departmentId = ((BaseOrganizeEntity)targetTreeNode.Tag).Id.ToString();
                        departmentName = ((BaseOrganizeEntity)targetTreeNode.Tag).FullName;
                    }

                    if (targetOrganizeCategory == "Company"
                        || targetOrganizeCategory == "SubCompany")
                    {
                        companyId = ((BaseOrganizeEntity)targetTreeNode.Tag).Id.ToString();
                        companyName = ((BaseOrganizeEntity)targetTreeNode.Tag).FullName;
                        break;
                    }
                }
                targetTreeNode = targetTreeNode.Parent;
            }

            userEntity.CompanyId = companyId;
            userEntity.CompanyName = companyName;
            userEntity.DepartmentId = departmentId;
            userEntity.DepartmentName = departmentName;
            userEntity.WorkgroupId = workgroupId;
            userEntity.WorkgroupName = workgroupName;

            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            DotNetService.Instance.UserService.UpdateUser(this.UserInfo, userEntity, out statusCode, out statusMessage);

            staffEntity.CompanyId = companyId;
            staffEntity.DepartmentId = departmentId;
            DotNetService.Instance.StaffService.UpdateStaff(this.UserInfo, staffEntity, out statusCode, out statusMessage);
        }

        private void tvOrganize_DragDrop(object sender, DragEventArgs e)
        {
            if (this.UserInfo.IsAdministrator == true)
            {
                // 定义一个中间变量
                TreeNode treeNode;
                // 判断拖动的是否为TreeNode类型，不是的话不予处理
                if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false))
                {
                    // 定义一个位置点的变量，保存当前光标所处的坐标点
                    Point point;
                    // 拖放的目标节点
                    TreeNode targetTreeNode;
                    // 获取当前光标所处的坐标
                    point = ((TreeView)sender).PointToClient(new Point(e.X, e.Y));
                    // 根据坐标点取得处于坐标点位置的节点
                    targetTreeNode = ((TreeView)sender).GetNodeAt(point);
                    // 是公司节点或部门节点时才可以使用。
                    if ((targetTreeNode.SelectedImageIndex <= 2) && (targetTreeNode.Parent != null))
                    {
                        // 获取被拖动的节点
                        treeNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                        // 判断拖动的节点与目标节点是否是同一个,同一个不予处理
                        if (BaseInterfaceLogic.TreeNodeCanMoveTo(treeNode, targetTreeNode))
                        {
                            if (BaseSystemInfo.ShowInformation)
                            {
                                // 是否移动模块
                                if (MessageBox.Show(AppMessage.Format(AppMessage.MSG0038, treeNode.Text, targetTreeNode.Text), AppMessage.MSG0000, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                {
                                    return;
                                }
                            }
                            this.MoveUserTo(((BaseUserEntity)treeNode.Tag).Id.ToString(), targetTreeNode);
                            // 往目标节点中加入被拖动节点的一份克隆
                            this.tvOrganize.SelectedNode = targetTreeNode;
                            //刷新拖入的节点用户
                            if (targetTreeNode != null)
                            {
                                if (targetTreeNode.Tag != null)
                                {
                                    // 当前节点是用户节点
                                    if (targetTreeNode.SelectedImageIndex < 2)
                                    {
                                        this.GetUserList(targetTreeNode);
                                    }
                                }
                            }
                            // 将被拖动的节点移除
                            treeNode.Remove();
                        }
                    }
                }
            }
        }

        private void tvOrganize_DragEnter(object sender, DragEventArgs e)
        {
            // 拖动效果设成移动
            e.Effect = DragDropEffects.Move;
        }

        private void tvOrganize_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // 开始进行拖放操作，并将拖放的效果设置成移动,只有用户节点可以拖动,只有管理员可以操作。
            if ((this.tvOrganize.SelectedNode.SelectedImageIndex > 2) && this.UserInfo.IsAdministrator)
                this.DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void SetTreeNodeState(TreeNode treeNode, string onLineState)
        {
            int imageIndex = 16; // 默认为离线状态

            if (!string.IsNullOrEmpty(onLineState))
            {
                int onLine = int.Parse(onLineState);
                if (onLine > 0)
                {
                    imageIndex = 14 + onLine;
                }
            }

            treeNode.ImageIndex = imageIndex;
            treeNode.SelectedImageIndex = imageIndex;
        }

        private void SetTreeViewOnLineState(DataTable dataTable, TreeView treeView)
        {
            TreeNode treeNode = null;
            for (int i = 0; i < treeView.Nodes.Count; i++)
            {
                treeNode = treeView.Nodes[i];
                string state = "0";
                while (treeNode != null)
                {
                    if (treeNode.ImageIndex > 2)
                    {
                        state = "0";
                        DataRow[] dataRow = dataTable.Select(BaseUserEntity.FieldId + "='" + ((BaseUserEntity)treeNode.Tag).Id.ToString() + "'");
                        for (int j = 0; j < dataRow.Length; j++)
                        {
                            if (dataRow[j][BaseUserEntity.FieldId].ToString() == ((BaseUserEntity)treeNode.Tag).Id.ToString())
                            {
                                state = dataRow[j][BaseUserEntity.FieldUserOnLine].ToString();
                                break;
                            }
                        }
                        this.SetTreeNodeState(treeNode, state);
                    }
                    if (!this.ExitApplication)
                    {
                        treeNode = treeNode.NextVisibleNode;
                    }
                }
            }
        }

        // 在线状态检查
        delegate void SetGetOnLineState();

        private void GetOnLineState()
        {
            if (!this.Visible)
            {
                return;
            }
            if (this.FormLoaded && (!this.Busyness))
            {
                if (this.tvOrganize.InvokeRequired)
                {
                    SetGetOnLineState onLineState = new SetGetOnLineState(this.GetOnLineState);
                    this.Invoke(onLineState);
                }
                else
                {
                    try
                    {
                        // DataTable dataTable = DotNetService.Instance.MessageService.GetOnLineState(UserInfo);
                        DotNetService dotNetService = new DotNetService();
                        DataTable dataTable = dotNetService.MessageService.GetOnLineState(this.UserInfo);
                        if (dotNetService.MessageService is ICommunicationObject)
                        {
                            ((ICommunicationObject)dotNetService.MessageService).Close();
                        }
                        if (this.tcMessage.SelectedTab == this.tpOrganize)
                        {
                            this.SetTreeViewOnLineState(dataTable, this.tvOrganize);
                        }
                        if (this.tcMessage.SelectedTab == this.tpApplicationRole)
                        {
                            this.SetTreeViewOnLineState(dataTable, this.tvApplicationRole);
                        }
                        if (this.tcMessage.SelectedTab == this.tpUserGroup)
                        {
                            this.SetTreeViewOnLineState(dataTable, this.tvUserGroup);
                        }
                    }
                    catch (System.Exception ex)
                    {
                        // 在本地记录异常
                        FileUtil.WriteException(UserInfo, ex);
                    }
                }
            }
        }

        private void bwGetNewMessage_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Busyness = true;
            this.GetNewMessage();
            this.Busyness = false;
        }

        private void bwGetOnLineState_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Busyness = true;
            this.GetOnLineState();
            this.Busyness = false;
        }

        /// <summary>
        /// 强制终止多线程
        /// </summary>
        public void AbortThread()
        {
            if (this.MessageThread != null)
            {
                this.MessageThread.Abort();
            }
            if (this.OnLineThread != null)
            {
                this.OnLineThread.Abort();
            }
        }

        private void FrmMessage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.ExitApplication)
            {
                this.AbortThread();
            }
            else
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        //
        // 快捷菜单部分
        //
        private TreeView GetSelectedTreeView()
        {
            TreeView treeView = null;
            if (this.tcMessage.SelectedTab == this.tpOrganize)
            {
                treeView = this.tvOrganize;
            }
            if (this.tcMessage.SelectedTab == this.tpApplicationRole)
            {
                treeView = this.tvApplicationRole;
            }
            if (this.tcMessage.SelectedTab == this.tpUserGroup)
            {
                treeView = this.tvUserGroup;
            }
            return treeView;
        }

        private void picHome_Click(object sender, EventArgs e)
        {
            string url = @"http://www.hairihan.com.cn/dotnet.html?OpenId={OpenId}";
            if (ConfigurationManager.AppSettings["HomePage"] != null)
            {
                url = ConfigurationManager.AppSettings["HomePage"];
            }
            url = this.UserInfo.GetUserParameter(url);
            System.Diagnostics.Process.Start(url);
        }

        private void picAddress_Click(object sender, EventArgs e)
        {
            FrmStaffAddressAdmin frmStaffAddressAdmin = new FrmStaffAddressAdmin();
            frmStaffAddressAdmin.Show();
        }

        private void picDocument_Click(object sender, EventArgs e)
        {
            FrmFileAdmin frmFileAdmin = new FrmFileAdmin();
            frmFileAdmin.Show();
        }

        private void picOA_Click(object sender, EventArgs e)
        {
            FrmCodeGenerator frmCodeGenerator = new FrmCodeGenerator();
            frmCodeGenerator.Show();
            // System.Diagnostics.Process.Start(picOA.Tag.ToString());
        }

        private void picShareAnIdea_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(picShareAnIdea.Tag.ToString());
        }

        private void mitmFrmMessageSend_Click(object sender, EventArgs e)
        {
            TreeView treeView = this.GetSelectedTreeView();
            if (treeView.SelectedNode != null)
            {
                FrmMessageSend frmMessageSend = new FrmMessageSend();
                frmMessageSend.Show(this);
                // 当前节点是用户节点
                if (treeView.SelectedNode.SelectedImageIndex == 16)
                {
                    frmMessageSend.SetSendTo(((BaseUserEntity)treeView.SelectedNode.Tag).Id.ToString(), treeView.SelectedNode.Text);
                }
                
            }
        }

        private void mitmFrmWorkReportAdd_Click(object sender, EventArgs e)
        {
            if (this.tvOrganize.SelectedNode != null)
            {
                // 用反射获得窗体
                string assemblyName = "DotNet.WinForm.WorkReport";
                string formName = "FrmWorkReportAdd";
                Type type = CacheManager.Instance.GetType(assemblyName, formName);
                Form frmWorkReportAdd = (Form)Activator.CreateInstance(type, ((BaseUserEntity)this.tvOrganize.SelectedNode.Tag).Id.ToString(), this.tvOrganize.SelectedNode.Text);
                frmWorkReportAdd.Show(this);
            }
        }

        private void mitmFrmWorkReportList_Click(object sender, EventArgs e)
        {
            if (this.tvOrganize.SelectedNode != null)
            {
                // 用反射获得窗体
                string assemblyName = "DotNet.WinForm.WorkReport";
                string formName = "FrmWorkReportList";
                Type type = CacheManager.Instance.GetType(assemblyName, formName);
                Form frmWorkReportList = (Form)Activator.CreateInstance(type, ((BaseUserEntity)this.tvOrganize.SelectedNode.Tag).Id.ToString(), this.tvOrganize.SelectedNode.Text);
                frmWorkReportList.Show(this);
            }
        }

        private void mitmFrmUserPermission_Click(object sender, EventArgs e)
        {
            TreeView treeView = this.GetSelectedTreeView();
            if (treeView.SelectedNode != null)
            {
                // 用反射获得窗体
                string assemblyName = "DotNet.WinForm";
                string formName = "FrmUserPermission";
                Type type = CacheManager.Instance.GetType(assemblyName, formName);
                Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(type, ((BaseUserEntity)treeView.SelectedNode.Tag).Id.ToString(), treeView.SelectedNode.Text);
                frmUserPermissionAdmin.Show(this);
            }
        }

        private void mitmFrmUserEdit_Click(object sender, EventArgs e)
        {
            TreeView treeView = this.GetSelectedTreeView();
            if (treeView.SelectedNode != null)
            {
                // 用反射获得窗体
                string assemblyName = "DotNet.WinForm";
                string formName = "FrmAccountEdit";
                Type type = CacheManager.Instance.GetType(assemblyName, formName);
                Form frmStaffEdit = (Form)Activator.CreateInstance(type, ((BaseUserEntity)treeView.SelectedNode.Tag).Id.ToString());
                frmStaffEdit.Show(this);
            }
        }

        private void mitmFrmUserRoleAdmin_Click(object sender, EventArgs e)
        {
            TreeView treeView = this.GetSelectedTreeView();
            if (treeView.SelectedNode != null)
            {
                // 用反射获得窗体
                string assemblyName = "DotNet.WinForm";
                string formName = "FrmUserRoleAdmin";
                Type type = CacheManager.Instance.GetType(assemblyName, formName);
                Form frmRoleUserAdmin = (Form)Activator.CreateInstance(type, ((BaseUserEntity)treeView.SelectedNode.Tag).Id.ToString(), treeView.SelectedNode.Text);
                frmRoleUserAdmin.Show(this);
            }
        }

        private void mitmFrmUserPermissionAdmin_Click(object sender, EventArgs e)
        {
            TreeView treeView = this.GetSelectedTreeView();
            if (treeView.SelectedNode != null)
            {
                // 用反射获得窗体
                string assemblyName = "DotNet.WinForm";
                string formName = "FrmUserPermission";
                Type type = CacheManager.Instance.GetType(assemblyName, formName);
                Form frmUserPermissionAdmin = (Form)Activator.CreateInstance(type, ((BaseUserEntity)treeView.SelectedNode.Tag).Id.ToString(), treeView.SelectedNode.Text);
                frmUserPermissionAdmin.Show(this);
            }
        }

        private void mitmApplicationRole_Click(object sender, EventArgs e)
        {
            TreeView treeView = this.GetSelectedTreeView();
            if (treeView.SelectedNode != null)
            {
                // 用反射获得窗体
                string assemblyName = "DotNet.WinForm";
                string formName = "FrmRoleAdmin";
                Type type = CacheManager.Instance.GetType(assemblyName, formName);
                Form frmRoleAdmin = (Form)Activator.CreateInstance(type, "ApplicationRole");
                frmRoleAdmin.Show(this);
            }
        }

        private void mitmUserGroup_Click(object sender, EventArgs e)
        {
            TreeView treeView = this.GetSelectedTreeView();
            if (treeView.SelectedNode != null)
            {
                // 用反射获得窗体
                string assemblyName = "DotNet.WinForm";
                string formName = "FrmRoleAdmin";
                Type type = CacheManager.Instance.GetType(assemblyName, formName);
                Form frmRoleAdmin = (Form)Activator.CreateInstance(type, "UserGroup");
                frmRoleAdmin.Show(this);
            }
        }

        private void mitmFrmStaffAddressEdit_Click(object sender, EventArgs e)
        {
            TreeView treeView = this.GetSelectedTreeView();
            if (treeView.SelectedNode != null)
            {
                // 用反射获得窗体
                string assemblyName = "DotNet.WinForm";
                string formName = "FrmStaffAddressEdit";
                Type type = CacheManager.Instance.GetType(assemblyName, formName);
                string staffId = DotNetService.Instance.StaffService.GetId(this.UserInfo, BaseStaffEntity.FieldUserId, ((BaseUserEntity)treeView.SelectedNode.Tag).Id.ToString());
                Form frmStaffAddressEdit = (Form)Activator.CreateInstance(type, staffId);
                frmStaffAddressEdit.Show(this);
            }
        }

        private void mitmFrmLogByUser_Click(object sender, EventArgs e)
        {
            TreeView treeView = this.GetSelectedTreeView();
            if (treeView.SelectedNode != null)
            {
                // 用反射获得窗体
                string assemblyName = "DotNet.WinForm";
                string formName = "FrmLogByUser";
                Type type = CacheManager.Instance.GetType(assemblyName, formName);
                string id = string.Empty;
                if (this.tvOrganize.SelectedNode.Tag is DataRow)
                {
                    id = (this.tvOrganize.SelectedNode.Tag as DataRow)[BaseOrganizeEntity.FieldId].ToString();
                }
                else
                {
                    id = this.tvOrganize.SelectedNode.Tag.ToString();
                }
                Form frmLogByUser = (Form)Activator.CreateInstance(type, id, treeView.SelectedNode.Text);
                frmLogByUser.Show(this);
            }
        }

        private void tvTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            TreeView treeView = this.GetSelectedTreeView();
            if (treeView.GetNodeAt(e.X, e.Y) != null)
            {
                treeView.SelectedNode = treeView.GetNodeAt(e.X, e.Y);
            }
        }

        private void FrmMessage_Activated(object sender, EventArgs e)
        {
            // 名字可能会变掉，重新登录或者扮演时，重新登录等时会发生这个事情
            this.Text = AppMessage.MessageService + "(" + UserInfo.RealName + ")";
        }
    }
}