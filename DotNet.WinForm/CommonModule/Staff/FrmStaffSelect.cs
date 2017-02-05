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
    /// FrmStaffSelect.cs
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
    public partial class FrmStaffSelect : BaseForm
    {
        private DataTable DTStaff = new DataTable(BaseStaffEntity.TableName);    // 员工 DataTable

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

        public string CheckPermissionFullName   = string.Empty;   // 检查什么模块
        public string CheckModuleCode           = string.Empty;   // 检查什么模块
        public string CheckOperationCode        = string.Empty;   // 检查什么权限
        
        public bool AllowSelectOther = true;

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

        private string[] selectedIds = null;    // 被选中的主键集
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

        public delegate bool ButtonConfirmEventHandler();

        public FrmStaffSelect()
        {
            InitializeComponent();
        }

        #region public override void GetList() 绑定屏幕数据
        /// <summary>
        /// 绑定屏幕数据
        /// </summary>
        public override void GetList()
        {
            if (UserInfo.IsAdministrator || String.IsNullOrEmpty(this.PermissionItemScopeCode))
            {
                this.DTStaff = DotNetService.Instance.StaffService.GetDataTable(UserInfo);
            }
            else
            {
                this.DTStaff = DotNetService.Instance.PermissionService.GetUserDTByPermissionScope(UserInfo, UserInfo.Id, this.PermissionItemScopeCode);
            }
            this.grdStaff.AutoGenerateColumns = false;
            this.DTStaff.AcceptChanges();
            this.grdStaff.DataSource = this.DTStaff.DefaultView;
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

            // 加载树
            this.GetList();
            // 检查是否需要移出
            if (this.RemoveIds != null)
            {
                for (int i = 0; i < this.RemoveIds.Length; i++)
                {
                    this.DTStaff.Rows.Find(RemoveIds[i]).Delete();
                }
                this.DTStaff.AcceptChanges();
            }
            // 检查选中状态
            if (this.SetSelectIds != null)
            {
                foreach (DataGridViewRow dgvRow in grdStaff.Rows)
                {
                    if (Array.IndexOf(this.setSelectIds, (dgvRow.DataBoundItem as DataRowView).Row[BaseStaffEntity.FieldId].ToString()) >= 0)
                        dgvRow.Cells["colSelected"].Value = true;
                }

                //for (int i = 0; i < this.SetSelectIds.Length; i++)
                //{
                //    this.DTStaff.Rows.Find(SetSelectIds[i])[BaseBusinessLogic.SelectedColumn] = true;
                //}
                //this.DTStaff.AcceptChanges();
            }
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnSetNull.Visible = this.AllowNull;
            this.btnSelectAll.Visible = false;
            this.btnInvertSelect.Visible = false;
            this.btnConfirm.Enabled = false;

            if (this.DTStaff.Rows.Count > 0)
            {
                if (this.MultiSelect)
                {
                    this.btnSelectAll.Visible = true;
                    this.btnInvertSelect.Visible = true;
                }
                this.btnConfirm.Enabled = true;
            }
            this.txtSearch.Visible = this.AllowSelectOther;
            this.btnSearch.Visible = this.AllowSelectOther;
        }
        #endregion

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string search = this.txtSearch.Text.Trim();
            if (String.IsNullOrEmpty(search))
            {
                this.DTStaff.DefaultView.RowFilter = string.Empty;
            }
            else
            {
                search = StringUtil.GetSearchString(search);
                this.DTStaff.DefaultView.RowFilter = 
                    
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
            this.DTStaff = DotNetService.Instance.StaffService.Search(UserInfo, string.Empty, this.txtSearch.Text);
            // this.GetList();
            // 设置按钮状态
            this.SetControlState();
        }

        private void grdStaff_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!this.MultiSelect)
            {
                DataRow dataRow = BaseInterfaceLogic.GetDataGridViewEntity(this.grdStaff);
                if (dataRow != null)
                {
                    this.SelectedId = dataRow[BaseStaffEntity.FieldId].ToString();
                    this.SelectedFullName = dataRow[BaseStaffEntity.FieldRealName].ToString();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dgvRow in grdStaff.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }

            //foreach (DataRow dataRow in this.DTStaff.Rows)
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
            //foreach (DataRow dataRow in this.DTStaff.Rows)
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

        private string[] GetSelectedFullNames()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdStaff, BaseStaffEntity.FieldRealName, "colSelected", true);
        }

        #region private string[] GetSelectedIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得已被选择的权限主键数组
        /// </summary>
        /// <returns>主键组</returns>
        private string[] GetSelectedIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdStaff, BaseStaffEntity.FieldId, "colSelected", true);
        }
        #endregion

        #region private bool CheckPermission(string userId, string staffFullName) 检查权限
        /// <summary>
        /// 检查权限
        /// </summary>
        /// <param name="userId">员工主键</param>
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

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInput()
        {
            bool returnValue = false;
            DataRow dataRow = BaseInterfaceLogic.GetSelecteRow(this.grdStaff, "colSelected");
            // DataRowView dataRowView = (DataRowView)this.grdStaff.BindingContext[this.grdStaff.DataSource].Current;
            if (dataRow != null)
            {
                if ((dataRow[BaseStaffEntity.FieldId].ToString().Length > 0) && (dataRow[BaseStaffEntity.FieldRealName].ToString().Length > 0))
                {
                    string staffId = dataRow[BaseStaffEntity.FieldId].ToString();
                    string staffFullName = dataRow[BaseStaffEntity.FieldRealName].ToString();
                    if (this.CheckPermission(staffId, staffFullName))
                    {
                        returnValue = true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            if (!returnValue)
            {
                MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            this.SelectedId = null;
            this.SelectedFullName = null;
            this.SelectedIds = null;
            this.DialogResult = DialogResult.OK;
            this.Close();
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

        private void SelectStaff()
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
                    this.GetSelectedId();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void SelectMulti()
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdStaff, "colSelected"))
            {
                if (this.CheckInput())
                {
                    this.SelectedIds = this.GetSelectedIds();
                    this.SelectedFullName = BaseBusinessLogic.ObjectsToList(this.GetSelectedFullNames());
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.MultiSelect)
            {
                this.SelectMulti();
            }
            else
            {
                this.SelectStaff();
            }
        }
    }
}