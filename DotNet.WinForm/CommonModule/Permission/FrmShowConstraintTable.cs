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
    

    /// <summary>
    /// FrmShowConstraintTable.cs
    /// 选择基础编码窗体
    ///		
    /// 修改记录
    /// 
    ///     2011.10.22 版本：1.0 JiRiGaLa  创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.10.22</date>
    /// </author> 
    /// </summary>
    public partial class FrmShowConstraintTable : BaseForm
    {
        public FrmShowConstraintTable()
        {
            InitializeComponent();
        }

        private string tableName = string.Empty;
        /// <summary>
        /// 表名
        /// </summary>
        public string TableName
        {
            get
            {
                return tableName;
            }
            set
            {
                tableName = value;
            }
        }

        private string tableRealName = string.Empty;
        /// <summary>
        /// 表全名
        /// </summary>
        public string TableRealName
        {
            get
            {
                return tableRealName;
            }
            set
            {
                tableRealName = value;
            }
        }


        private string tableConstraint = string.Empty;
        /// <summary>
        /// 条件表达式
        /// </summary>
        public string TableConstraint
        {
            get
            {
                return tableConstraint;
            }
            set
            {
                tableConstraint = value;
            }
        }


        public FrmShowConstraintTable(string tableRealName, string tableName, string tableConstraint)
            : this()
        {
            this.TableRealName = tableRealName;
            this.TableName = tableName;
            this.TableConstraint = tableConstraint;
            this.LoadUserParameters = false;
        }

        private void ProcessTable(DataTable dt)
        {
            DotNetService dotNetService = new DotNetService();
            DataTable dtColumns = dotNetService.TableColumnsService.GetDataTableByTable(UserInfo, this.TableName);
            if (dotNetService.TableColumnsService is ICommunicationObject)
            {
                ((ICommunicationObject)dotNetService.TableColumnsService).Close();
            }
            // 1:列的显示顺序
            // 2:列是否显示？
            // 3:列的中文名字？
            foreach (DataRow dataRow in dtColumns.Rows)
            {
                if (dataRow[BaseTableColumnsEntity.FieldEnabled].ToString().Equals("1"))
                {
                    DataGridViewTextBoxColumn dgvtbc = new DataGridViewTextBoxColumn();
                    dgvtbc.Name = dataRow[BaseTableColumnsEntity.FieldColumnCode].ToString();
                    dgvtbc.HeaderText = dataRow[BaseTableColumnsEntity.FieldColumnName].ToString();
                    dgvtbc.DataPropertyName = dataRow[BaseTableColumnsEntity.FieldColumnCode].ToString();
                    this.grdTable.Columns.Add(dgvtbc);
                }
            }
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnExport.Enabled = false;

            if (this.grdTable.RowCount > 0)
            {
                this.btnExport.Enabled = true;
            }
        }
        #endregion

        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            this.txtTargetTable.Text = this.TableRealName;

            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdTable);

            string commandText = string.Empty;
            commandText = " SELECT * FROM " + this.TableName + " WHERE " + this.TableConstraint;
            UserCenterDbHelperService dbHelperService = new UserCenterDbHelperService();
            // BusinessDbHelperService dbHelperService = new BusinessDbHelperService();
            DataTable dt = dbHelperService.Fill(this.UserInfo, commandText);
            dt.TableName = this.TableName;
            // 表格显示序号的处理部分
            this.ProcessTable(dt);
            this.grdTable.AutoGenerateColumns = false;
            this.grdTable.DataSource = dt;
        }
        #endregion

        private void btnExport_Click(object sender, EventArgs e)
        {
            // 导出Excel
            //string exportFileName = this.Text + ".csv";
            string exportFileName = this.Text + ".xls";
            this.ExportExcel(this.grdTable , @"\Modules\Export\", exportFileName);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}