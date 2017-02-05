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
    /// FrmItemDetailsSelect.cs
    /// 选择基础编码窗体
    ///		
    /// 修改记录
    /// 
    ///     2007.06.05 版本：1.3 JiRiGaLa      整理主键。
    ///     2007.06.05 版本：1.2 JiRiGaLa      传参数CategoryId。
    ///     2007.05.29 版本：1.1 JiRiGaLa   优化CheckInput 方法。
    ///     2007.05.23 版本：1.0 JiRiGaLa      基础编码选择功能页面编写。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.05.23</date>
    /// </author> 
    /// </summary>
    public partial class FrmItemDetailsSelect : BaseForm
    {
        private DataTable DTItemDetails = new DataTable();  // 编码DataTable

        /// <summary>
        /// 目标基础主键表
        /// </summary>
        public string TargetTableName = BaseItemDetailsEntity.TableName;

        private bool allowNull = true;
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

        private string parentId = "ItemDetails";
        /// <summary>
        /// 父亲节点
        /// </summary>
        public string ParentId
        {
            get
            {
                return this.parentId;
            }
            set
            {
                this.parentId = value;
            }
        }

        private string categoryId =  "ItemDetails";    // 基础主键分类
        /// <summary>
        /// 基础主键分类
        /// </summary>
        public string CategoryId
        {
            get
            {
                return this.categoryId;
            }
            set
            {
                this.categoryId = value;
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

        private string selectedCode = string.Empty;
        /// <summary>
        /// 被选中的员工主键
        /// </summary>
        public string SelectedCode
        {
            get
            {
                return this.selectedCode;
            }
            set
            {
                this.selectedCode = value;
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

        public FrmItemDetailsSelect()
        {
            InitializeComponent();
        }

        public FrmItemDetailsSelect(string categoryId) : this()
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
            this.grdItemDetails.DataSource = this.DTItemDetails;
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
                this.btnConfirm.Enabled = false;
            }
            else
            {
                this.btnConfirm.Enabled = true;
            }
        }
        #endregion

        #region private void GetSelecteId() 获得已被选择的权限主键
        /// <summary>
        /// 获得已被选择的权限主键数组
        /// </summary>
        /// <returns></returns>
        private void GetSelectedId()
        {
            DataRow dataRow = BaseInterfaceLogic.GetSelecteRow(this.grdItemDetails, "colSelected");
            if (dataRow != null)
            {
                this.SelectedId       = dataRow[BaseItemDetailsEntity.FieldId].ToString();
                this.SelectedFullName = dataRow[BaseItemDetailsEntity.FieldItemName].ToString();
            }
        }
        #endregion

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            this.SelectedId = null;
            this.SelectedFullName = null;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (BaseInterfaceLogic.CheckInputSelectAnyOne(this.grdItemDetails, "colSelected"))
            {
                this.GetSelectedId();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}