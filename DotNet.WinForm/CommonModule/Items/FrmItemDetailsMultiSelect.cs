//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    
    /// <summary>
    /// FrmItemDetailsMultiSelect.cs
    /// 权限管理-选择权限窗体
    ///		
    /// 修改记录
    /// 
    ///     2007.06.05 版本：1.3 JiRiGaLa     整理主键。
    ///     2007.06.05 版本：1.2 JiRiGaLa     传参数CategoryId。
    ///     2007.05.29 版本：1.1 JiRiGaLa  AddColumnToDataSet 方法改进。
    ///     2007.05.10 版本：1.0 JiRiGaLa  权限选择功能页面编写。
    ///		
    /// 版本：1.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.29</date>
    /// </author> 
    /// </summary>
    public partial class FrmItemDetailsMultiSelect : BaseForm
    {
        /// <summary>
        /// 目标基础主键表
        /// </summary>
        public string TargetTableName = BaseItemDetailsEntity.TableName;

        private DataTable DTItemDetails = new DataTable();  // 编码DataTable
        public string[] SelecteIds = new string[0];         // 被选中的权限主键
        public bool   AllowNull         = false;            // 是否允许空值
        public string CategoryId = "ItemDetails";           // 基础主键分类

        public FrmItemDetailsMultiSelect()
        {
            InitializeComponent();
            // 加载系统信息
            // UserInfo = new BaseUserInfo(this.Name, this.Text);
        }

        public FrmItemDetailsMultiSelect(string categoryId) : this()
        {
            this.CategoryId = categoryId;
        }

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdItemDetails);
            // 权限信息
            this.DTItemDetails = DotNetService.Instance.ItemDetailsService.GetDataTable(UserInfo, this.TargetTableName);
            this.grdItemDetails.AutoGenerateColumns = false;
            this.grdItemDetails.DataSource = DTItemDetails;
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnSetNull.Visible = this.AllowNull;
            if (this.DTItemDetails.Rows.Count == 0)
            {
                this.btnSelectAll.Enabled       = false;
                this.btnInvertSelect.Enabled = false;
                this.btnConfirm.Enabled         = false;
            }
            else
            {
                this.btnSelectAll.Enabled       = true;
                this.btnInvertSelect.Enabled = true;
                this.btnConfirm.Enabled         = true;
            }
        }
        #endregion

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grdItemDetails.Rows)
            {
                dgvRow.Cells["colSelected"].Value = true;
            }

            //foreach (DataRow dataRow in this.DTItemDetails.Rows)
            //{
            //    dataRow["colSelected"] = true.ToString();
            //}
        }

        private void btnTurnSelect_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in grdItemDetails.Rows)
            {
                dgvRow.Cells["colSelected"].Value = !(System.Boolean)(dgvRow.Cells["colSelected"].Value??false);
            }

            //foreach (DataRow dataRow in this.DTItemDetails.Rows)
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

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>bool</returns>
        public override bool CheckInput()
        {
            return BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdItemDetails, "colSelected");
        }
        #endregion

        #region private string[] GetSelecteIds() 获得已被选择的权限主键数组
        /// <summary>
        /// 获得已被选择的权限主键数组
        /// </summary>
        /// <returns></returns>
        private string[] GetSelecteIds()
        {
            return BaseInterfaceLogic.GetSelecteIds(this.grdItemDetails, BaseItemDetailsEntity.FieldId, "colSelected", true);
        }
        #endregion

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            this.SelecteIds = null;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                this.SelecteIds = this.GetSelecteIds();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}