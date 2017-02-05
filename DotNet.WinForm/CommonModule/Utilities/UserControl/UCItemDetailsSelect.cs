//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.ServiceModel;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// UCItemDetailsSelect.cs
    /// 主键管理-选择主键控件
    ///		
    /// 修改记录
    /// 
    ///     2008.05.15 版本：1.0 JiRiGaLa  初步创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.05.15</date>
    /// </author> 
    /// </summary>
    public partial class UCItemDetailsSelect : UserControl
    {
        /// <summary>
        /// 目标基础主键表
        /// </summary>
        public string TargetTableName = BaseItemDetailsEntity.TableName;

        /// <summary>
        /// 当前用户信息
        /// </summary>
        public BaseUserInfo UserInfo
        {
            get
            {
                return BaseSystemInfo.UserInfo;
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

        private string selectedFullName = string.Empty; // 被选中的名称
        public string SelectedFullName
        {
            get
            {
                this.selectedFullName = this.cmbItemDetail.Text;
                return this.selectedFullName;
            }
            set
            {
                this.selectedFullName = value;
                this.cmbItemDetail.Text = value;
                this.SetControlState();
            }
        }

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
                this.SetControlState();
            }
        }

        private bool allowAdmin = false;
        public bool AllowAdmin
        {
            get
            {
                return this.allowAdmin;
            }
            set
            {
                this.allowAdmin = value;
                this.SetControlState();
            }
        }

        public string DisplayMember = BaseItemDetailsEntity.FieldItemName;
        public string ValueMember = BaseItemDetailsEntity.FieldId;

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

        private string categoryId = "ItemDetails";    // 基础主键分类
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

        private bool FormLoaded = false;    // 窗体已经加载完毕

        public UCItemDetailsSelect()
        {
            InitializeComponent();
        }

        // 当选择的公司部门发生变化时
        public event BaseBusinessLogic.SelectedIndexChangedEventHandler SelectedIndexChanged;

        #region private void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        private void SetControlState()
        {
            this.btnSetNull.Visible = this.AllowNull;
            this.pnlSetNull.Visible = this.AllowNull;
            this.btnAdmin.Visible = this.AllowAdmin;
            this.pnlAdmin.Visible = this.AllowAdmin;
            if (String.IsNullOrEmpty(this.SelectedId))
            {
                this.btnSetNull.Enabled = false;
            }
            else
            {
                this.btnSetNull.Enabled = true;
            }
        }
        #endregion

        public void SetSelectedValue(string selectedId)
        {
            if (!String.IsNullOrEmpty(selectedId))
            {
                for (int i = 0; i < this.cmbItemDetail.Items.Count; i++)
                {
                    if (selectedId.Equals(((DataRowView)this.cmbItemDetail.Items[i])[this.ValueMember].ToString()))
                    {
                        this.cmbItemDetail.SelectedIndex = i;
                        this.SelectedId = selectedId;
                        break;
                    }
                }
            }
        }

        public void DataBind()
        {
            this.FormLoaded = false;
            DotNetService dotNetService = new DotNetService();
            DataTable dataTable = dotNetService.ItemDetailsService.GetDataTable(this.UserInfo, this.TargetTableName);
            if (dotNetService.ItemDetailsService is ICommunicationObject)
            {
                ((ICommunicationObject)dotNetService.ItemDetailsService).Close();
            }
            // 绑定数据
            this.cmbItemDetail.DisplayMember = this.DisplayMember;
            this.cmbItemDetail.ValueMember = this.ValueMember;
            this.cmbItemDetail.DataSource = dataTable.DefaultView;
            if (this.AllowNull)
            {
                // 添加一个空记录
                DataRow dataRow = dataTable.NewRow();
                dataTable.Rows.InsertAt(dataRow, 0);
                this.cmbItemDetail.SelectedValue = dataRow;
            }
            this.SetSelectedValue(this.SelectedId);
            // this.AllowAdmin = UserInfo.IsAdministrator;
            // 默认绑定，没有进行选择时，也需要读取值，否则会不正确。
            this.GetSelectedValue();
            // 设置按钮状态
            this.SetControlState();
            this.FormLoaded = true;
        }

        public void DataBind(string categoryId, bool allowAdmin)
        {
            this.AllowAdmin = allowAdmin;
            this.DataBind(categoryId);
        }

        public void DataBind(string categoryId)
        {
            this.CategoryId = categoryId;
            this.DataBind();
        }

        private void GetSelectedValue()
        {
            if (this.cmbItemDetail.SelectedValue == null)
            {
                this.SelectedId = string.Empty;
                this.SelectedFullName = string.Empty;
            }
            else
            {
                this.SelectedId = this.cmbItemDetail.SelectedValue.ToString();
                this.SelectedFullName = this.cmbItemDetail.Text;
            }
        }

        private void cmbItemDetail_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 人工进行选择的，才算值有变动
            if (this.FormLoaded)
            {
                this.GetSelectedValue();
            }
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            // 用反射获得窗体
            string assemblyName = "DotNet.WinForm";
            string formName = "FrmItemDetailsAdmin";
            Form frmItemDetailsAdmin = CacheManager.Instance.GetForm(assemblyName, formName);
            ((FrmItemDetailsAdmin)frmItemDetailsAdmin).ParentId = this.CategoryId;
            if (frmItemDetailsAdmin.ShowDialog() == DialogResult.OK)
            {
                // 重新获取下拉列表框
                this.DataBind();
            }
        }

        private void btnSetNull_Click(object sender, EventArgs e)
        {
            if (this.cmbItemDetail.Text.Length > 0)
            {
                this.SelectedId = null;
                this.SelectedFullName = null;
                if (this.SelectedIndexChanged != null)
                {
                    this.SelectedIndexChanged(this.SelectedId);
                }
            }
            this.SetControlState();
        }  
    }
}