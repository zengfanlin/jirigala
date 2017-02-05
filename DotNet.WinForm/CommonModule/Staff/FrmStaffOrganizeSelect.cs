//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmStaffOrganizeSelect.cs
    /// 员工管理-选择员工窗体
    ///		
    /// 修改记录
    /// 
    ///     2007.08.15 版本：2.0 JiRiGaLa  Instance 实例调用模式，加快运行速度。 
    ///     2007.06.01 版本: 1.1 JiRiGaLa  页面整理，功能改进
    ///     2007.05.12 版本：1.0 JiRiGaLa  员工选择功能页面编写。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.06.01</date>
    /// </author> 
    /// </summary>
    public partial class FrmStaffOrganizeSelect : BaseForm
    {
        private DataTable DTOrganize    = new DataTable(BaseOrganizeEntity.TableName); // 组织机构 DataTable
        private DataTable DTStaffList   = new DataTable(BaseStaffEntity.TableName);   // 用户 DataTable

        public string CheckPermissionFullName   = string.Empty;   // 检查什么模块
        public string CheckModuleCode           = string.Empty;   // 检查什么模块
        public string CheckOperationCode       = string.Empty;   // 检查什么权限

        public bool AllowSelectOther = true;

        private string[] removeIds = null;
        /// <summary>
        /// 移出的主键数组
        /// </summary>
        public string[] RemoveIds
        {
            get
            {
                return this.removeIds;
            }
            set
            {
                this.removeIds = value;
            }
        }

        private string[] setSelectIds = null;
        /// <summary>
        /// 选中的主键数组
        /// </summary>
        public string[] SetSelectIds
        {
            get
            {
                return this.setSelectIds;
            }
            set
            {
                this.setSelectIds = value;
            }
        }

        private bool multiSelect = false;
        /// <summary>
        /// 是否允许多个选择
        /// </summary>
        public bool MultiSelect
        {
            get
            {
                return this.multiSelect;
            }
            set
            {
                this.multiSelect = value;
            }
        }

        private bool allowNull = false;
        /// <summary>
        /// 是否允许选择空
        /// </summary>
        public bool AllowNull
        {
            get
            {
                return this.allowNull;
            }
            set
            {
                this.allowNull = value;
            }
        }

        private bool allowSelect = true;
        /// <summary>
        /// 是否允许选择
        /// </summary>
        public bool AllowSelect
        {
            get
            {
                return this.allowSelect;
            }
            set
            {
                this.allowSelect = value;
                this.SetControlState();
            }
        }

        private string byPermissionCode = string.Empty;
        /// <summary>
        /// 按什么权限域获取员工列表
        /// </summary>
        public string PermissionItemScopeCode
        {
            get
            {
                return this.byPermissionCode;
            }
            set
            {
                this.byPermissionCode = value;
            }
        }

        private string selectedId = string.Empty;
        /// <summary>
        /// 被选中的员工主键
        /// </summary>
        public string SelectedId
        {
            get
            {
                return this.selectedId;
            }
            set
            {
                this.selectedId = value;
            }
        }

        private string selectedFullName = string.Empty;
        /// <summary>
        /// 被选中的员工全名
        /// </summary>
        public string SelectedFullName
        {
            get
            {
                return this.selectedFullName;
            }
            set
            {
                this.selectedFullName = value;
            }
        }

        private string openId = string.Empty;
        /// <summary>
        /// 打开节点
        /// </summary>
        public string OpenId
        {
            get
            {
                return this.openId;
            }
            set
            {
                this.openId = value;
            }
        }

        private string[] selectedIds = new string[0];    // 被选中的主键集
        /// <summary>
        /// 被选中的员工主键
        /// </summary>
        public string[] SelectedIds
        {
            get
            {
                return this.selectedIds;
            }
            set
            {
                this.selectedIds = value;
            }
        }

        public FrmStaffOrganizeSelect()
        {
            InitializeComponent();
        }

        public FrmStaffOrganizeSelect(string parentOrganizeId) : this()
        {
            this.ParentOrganizeId = parentOrganizeId;
        }

        private string parentOrganizeId = string.Empty;

        #region public string ParentOrganizeId 组织机构主键
        /// <summary>
        /// 组织机构主键
        /// </summary>
        public string ParentOrganizeId
        {
            get
            {
                if ((this.tvOrganize.SelectedNode != null) && (this.tvOrganize.SelectedNode.Tag != null))
                {
                    this.parentOrganizeId = (this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                }
                return this.parentOrganizeId;
            }
            set
            {
                this.parentOrganizeId = value;
            }
        }
        #endregion

        #region public string EntityID 用户主键
        /// <summary>
        /// 用户主键
        /// </summary>
        public string EntityID
        {
            get
            {
                string entityId = string.Empty;
                if (this.tvOrganize.SelectedNode != null)
                {
                    entityId = (this.tvOrganize.SelectedNode.Tag as DataRow)[BaseModuleEntity.FieldId].ToString();
                }
                return entityId;
            }
        }
        #endregion

        #region private void Localization() 多语言国际化加载
        /// <summary>
        /// 多语言国际化加载
        /// </summary>
        private void Localization()
        {
            BaseInterfaceLogic.SetLanguageResource(this);
        }
        #endregion

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
                this.LoadTree();

                if (this.tvOrganize.SelectedNode == null)
                {
                    if (this.tvOrganize.Nodes.Count > 0)
                    {
                        this.tvOrganize.SelectedNode = this.tvOrganize.Nodes[0];
                        if (String.IsNullOrEmpty(this.parentOrganizeId))
                        {
                            BaseInterfaceLogic.FindTreeNode(this.tvOrganize, this.parentOrganizeId);
                            if (BaseInterfaceLogic.TargetNode != null)
                            {
                                this.tvOrganize.SelectedNode = BaseInterfaceLogic.TargetNode;
                                // 展开当前选中节点的所有父节点
                                BaseInterfaceLogic.ExpandTreeNode(this.tvOrganize);
                            }
                        }
                        if (this.tvOrganize.SelectedNode != null)
                        {
                            // 让选中的节点可视，并用展开方式
                            this.tvOrganize.SelectedNode.Expand();
                            this.tvOrganize.SelectedNode.EnsureVisible();
                        }
                    }
                }
                // 获取员工列表
                this.GetStaffList();
            }
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdStaff);

            // 获取组织机构数据
            this.DTOrganize = this.GetOrganizeScope(this.PermissionItemScopeCode, true);
            // 加载树
            this.BindData(true);
        }
        #endregion

        #region private void LoadTree() 加载树
        /// <summary>
        /// 加载树
        /// </summary>
        private void LoadTree()
        {
            // 开始更新控件，屏幕不刷新，提高效率。
            this.tvOrganize.BeginUpdate();
            this.tvOrganize.Nodes.Clear();
            TreeNode treeNode = new TreeNode();
            this.LoadTreeOrganize(treeNode);
            BaseInterfaceLogic.FindTreeNode(this.tvOrganize, this.ParentOrganizeId);
            if (BaseInterfaceLogic.TargetNode != null)
            {
                this.tvOrganize.SelectedNode = BaseInterfaceLogic.TargetNode;
                BaseInterfaceLogic.ExpandTreeNode(this.tvOrganize);
                this.tvOrganize.SelectedNode.EnsureVisible();
                this.tvOrganize.SelectedNode.Expand();
            }
            // 更新控件，屏幕一次性刷新，提高效率。
            this.tvOrganize.EndUpdate();
        }
        #endregion

        #region private void LoadTreeOrganize(TreeNode treeNode)
        /// <summary>
        /// 加载组织机构树的主键
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        private void LoadTreeOrganize(TreeNode treeNode)
        {
            BaseInterfaceLogic.LoadTreeNodes(this.DTOrganize, BaseOrganizeEntity.FieldId, BaseOrganizeEntity.FieldParentId, BaseOrganizeEntity.FieldFullName, this.tvOrganize, treeNode);
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnSetNull.Visible = this.AllowNull;
            this.btnSelectAll.Enabled = false;
            this.btnInvertSelect.Enabled = false;
            this.btnConfirm.Enabled = false;

            if (this.DTStaffList.Rows.Count > 0)
            {
                if (this.MultiSelect)
                {
                    this.btnSelectAll.Enabled = true;
                    this.btnInvertSelect.Enabled = true;
                }
                this.btnConfirm.Enabled = true;
            }
            this.txtSearch.Visible = this.AllowSelectOther;
            this.btnSearch.Visible = this.AllowSelectOther;

            if ((this.DTOrganize.Rows.Count == 0) || (this.tvOrganize.Nodes.Count == 0))
            {
                this.btnConfirm.Enabled = false;
                this.chkContainChildren.Enabled = false;
            }
            else
            {
                this.chkContainChildren.Enabled = true;                
            }
        }
        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = this.txtSearch.Text.Trim();
            if (String.IsNullOrEmpty(search))
            {
                this.DTStaffList.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                search = StringUtil.GetSearchString(search);
                this.DTStaffList.DefaultView.RowFilter = 
                    
                    /*BaseStaffEntity.FieldUserName + " LIKE '" + search + "'"
                    + " OR " + BaseStaffEntity.FieldCode + " LIKE '" + search + "'"
                    + " OR " + BaseStaffEntity.FieldRealName + " LIKE '" + search + "'"
                    + " OR " + BaseStaffEntity.FieldDescription + " LIKE '" + search + "'";*/

                StringUtil.GetLike(BaseStaffEntity.FieldUserName, search)
                        + " OR " + StringUtil.GetLike(BaseStaffEntity.FieldCode, search)
                        + " OR " + StringUtil.GetLike(BaseStaffEntity.FieldRealName, search)
                        + " OR " + StringUtil.GetLike(BaseStaffEntity.FieldDescription, search);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.DTStaffList = DotNetService.Instance.StaffService.Search(UserInfo, string.Empty, this.txtSearch.Text);
            // 设置按钮状态
            this.SetControlState();
        }

        private void chkContainChildren_CheckedChanged(object sender, EventArgs e)
        {
            this.GetStaffList();
        }

        #region private void GetStaffList() 设置员工列表
        /// <summary>
        /// 设置员工列表
        /// </summary>
        private void GetStaffList()
        {
            // 总得有部门数据吧
            if (!String.IsNullOrEmpty(this.ParentOrganizeId))
            {
                // 这里按部门查询人员就可以了
                this.DTStaffList = DotNetService.Instance.StaffService.GetDataTableByDepartment(UserInfo, this.ParentOrganizeId, this.chkContainChildren.Checked);
                this.grdStaff.AutoGenerateColumns = false;
                this.grdStaff.DataSource = this.DTStaffList.DefaultView;
            }
            // 设置按钮状态
            this.SetControlState();
        }
        #endregion

        private void tvOrganize_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (this.FormLoaded)
            {
                if (this.parentOrganizeId.Length > 0)
                {
                    // 设置鼠标繁忙状态，并保留原先的状态
                    Cursor holdCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;
                    try
                    {
                        this.GetStaffList();
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
        }

        private void grdStaff_DoubleClick(object sender, EventArgs e)
        {
            this.btnConfirm.PerformClick();
        }

        #region private void GetSelecteID() 获得已被选择的权限主键
        /// <summary>
        /// 获得已被选择的权限主键数组
        /// </summary>
        private void GetSelectedId()
        {
            DataRow dataRow = BaseInterfaceLogic.GetSelecteRow(this.grdStaff, "colSelected");
            if (dataRow == null)
            {
                // 默认当前的行
                dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdStaff);
            }
            if (dataRow != null)
            {
                this.SelectedId = dataRow[BaseStaffEntity.FieldId].ToString();
                this.SelectedFullName = dataRow[BaseStaffEntity.FieldRealName].ToString();
            }
        }
        #endregion

        #region private bool CheckPermission(string userId, string staffFullName) 检查权限
        /// <summary>
        /// 检查权限
        /// </summary>
        /// <param name="staffId">员工主键</param>
        /// <param name="staffFullName">员工姓名</param>
        /// <returns>是否有权限</returns>
        private bool CheckPermission(string staffId, string staffFullName)
        {
            bool returnValue = true;
            //if ((this.CheckModuleCode.Length > 0) && (this.CheckOperationCode.Length > 0))
            //{
            //    if (ModuleOperationCheckService.Instance.IsAuthorized(UserInfo, staffId, this.CheckModuleCode, this.CheckOperationCode))
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        MessageBox.Show(staffFullName + "无权限：" + this.CheckPermissionFullName, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return false;
            //    }
            //}
            return returnValue;
        }
        #endregion

        #region private bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        private bool CheckInput(string id, string fullName)
        {
            bool returnValue = false;
            if (this.CheckPermission(id, fullName))
            {
                returnValue = true;
            }
            else
            {
                return false;
            }
            if (!returnValue)
            {
                MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        private void grdStaff_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.MultiSelect)
            {
                DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdStaff);
                if (dataRow != null)
                {
                    if (this.CheckInput(dataRow[BaseStaffEntity.FieldId].ToString(), dataRow[BaseStaffEntity.FieldRealName].ToString()))
                    {
                        this.SelectedId = dataRow[BaseStaffEntity.FieldId].ToString();
                        this.SelectedFullName = dataRow[BaseStaffEntity.FieldRealName].ToString();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grdStaff.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }
            //foreach (DataRow dataRow in this.DTStaffList.Rows)
            //{
            //    dataRow["colSelected"] = true.ToString();
            //}
        }

        private void btnInvertSelect_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dgvRow in grdStaff.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value??false);
            }
            //foreach (DataRow dataRow in this.DTStaffList.Rows)
            //{
            //    if (dataRow["colSelected"].ToString() == true.ToString())
            //    {
            //        dataRow["colSelected"] = false.ToString();
            //    }
            //    else
            //    {
            //        dataRow["colSelected"] = true.ToString();
            //    }
            //}
        }

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            this.SelectedId = null;
            this.SelectedFullName = null;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SelectOrganize()
        {
            if (BaseInterfaceLogic.CheckInputSelectOne(this.grdStaff, "colSelected"))
            {
                DataRow dataRow = BaseInterfaceLogic.GetSelecteRow(this.grdStaff, "colSelected");
                if (dataRow == null)
                {
                    // 默认当前的行
                    dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdStaff);
                }
                if (dataRow != null)
                {
                    if (this.CheckInput(dataRow[BaseStaffEntity.FieldId].ToString(), dataRow[BaseStaffEntity.FieldRealName].ToString()))
                    {
                        this.GetSelectedId();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.SelectOrganize();
        }

        private void tvOrganize_MouseDown(object sender, MouseEventArgs e)
        {
            if (tvOrganize.GetNodeAt(e.X, e.Y) != null)
            {
                tvOrganize.SelectedNode = tvOrganize.GetNodeAt(e.X, e.Y);
            }
        }      
    }
}