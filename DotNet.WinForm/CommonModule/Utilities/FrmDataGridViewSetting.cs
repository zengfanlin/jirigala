//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
namespace DotNet.WinForm
{
    using DotNet.Utilities;

    /// <summary>
    ///	FrmDataGridViewSetting
    /// DataGridView设置页面
    /// 
    /// 修改纪录
    ///     2011.12.07 版本：1.1    zgl 修改排序的bug。
    ///     2011.07.07 版本：1.0    2438创建。
    ///	
    /// 版本：1.1
    ///
    /// <author>
    ///		<name>2438</name>
    ///		<date>2010.07.07</date>
    /// </author> 
    /// </summary>
    public partial class FrmDataGridViewSetting : BaseForm
    {
        #region 构造函数
        public FrmDataGridViewSetting()
        {
            InitializeComponent();
        }
        #endregion

        #region 公共属性

        //所属窗体
        private Form targetForm = null;
        public Form TargetForm
        {
            get { return targetForm; }
            set { targetForm = value; }
        }

        //所属DataGridView
        private DataGridView targetDataGridView = null;
        public DataGridView TargetDataGridView
        {
            get { return targetDataGridView; }
            set { targetDataGridView = value; }
        }
        #endregion

        #region 窗体加载事件
        public override void FormOnLoad()
        {
            // 表格显示序号的处理部分
            this.DataGridViewOnLoad(grdSetting);
            string targetFileFullName = BaseSystemInfo.StartupPath + "\\UserParameter\\" + TargetForm.Name + "_" + targetDataGridView.Name + ".xml";
            DataSet dsDataGridViewColumns = new DataSet();
            dsDataGridViewColumns.ReadXml(targetFileFullName);
            grdSetting.DataSource = dsDataGridViewColumns.Tables[0];
        }
        #endregion

        #region 所有按钮事件
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            Save();
            BaseInterfaceLogic.LoadDataGridViewColumnWidth(TargetForm);
        }

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            this.Close();

        }

        private void btnSetUp_Click(object sender, System.EventArgs e)
        {
            SetUp();
        }

        private void btnSetDown_Click(object sender, System.EventArgs e)
        {
            SetDown();
        }

        private void btnSetTop_Click(object sender, System.EventArgs e)
        {
            SetTop();
        }

        private void btnSetBottom_Click(object sender, System.EventArgs e)
        {
            SetBottom();
        }
        #endregion

        #region 私有方法
        //保存
        private void Save()
        {
            grdSetting.EndEdit();
            string targetFileFullName = BaseSystemInfo.StartupPath + "\\UserParameter\\" + TargetForm.Name + "_" + TargetDataGridView.Name + ".xml";
            DataSet dsDataGridViewColumns = new DataSet(targetDataGridView.Name);
            dsDataGridViewColumns.Tables.Add(targetDataGridView.Name);
            dsDataGridViewColumns.Tables[0].Columns.Add("ColumnName", typeof(string));
            dsDataGridViewColumns.Tables[0].Columns.Add("HeaderText", typeof(string));
            dsDataGridViewColumns.Tables[0].Columns.Add("Frozen", typeof(bool));
            dsDataGridViewColumns.Tables[0].Columns.Add("Visible", typeof(bool));
            dsDataGridViewColumns.Tables[0].Columns.Add("DisplayIndex", typeof(int));
            dsDataGridViewColumns.Tables[0].Columns.Add("Width", typeof(int));
            foreach (DataGridViewRow item in grdSetting.Rows)
            {
                try
                {
                    dsDataGridViewColumns.Tables[0].Rows.Add(item.Cells["ColumnName"].Value.ToString(), item.Cells["HeaderText"].Value, item.Cells["Frozen"].Value, item.Cells["Visible"].Value, item.Index, item.Cells["Width"].Value);
                }
                catch(Exception ee)
                {
                    ProcessException(ee);
                    return;
                }
            }
            //因为一列为冻结列前面的所有也得为冻结列
            for (int i = 0; i < dsDataGridViewColumns.Tables[0].Rows.Count - 1; i++)
            {
                if (dsDataGridViewColumns.Tables[0].Rows[i]["Frozen"].ToString() == "True")
                {
                    for (int j = 0; j < i; j++)
                    {
                        dsDataGridViewColumns.Tables[0].Rows[j]["Frozen"] = true;
                    }
                }
            }
            dsDataGridViewColumns.WriteXml(targetFileFullName);

            this.DialogResult = DialogResult.OK;
        }

        //向上移动
        private void SetUp()
        {
            //得到当前选中列的索引
            int columnIndex = grdSetting.SelectedCells[0].ColumnIndex;
            //得到当前选中行的索引
            int rowIndex = grdSetting.SelectedCells[0].RowIndex;

            if (rowIndex == 0)
            {
                return;
            }

            List<string> list = new List<string>();
            for (int i = 0; i < grdSetting.Columns.Count; i++)
            {
                list.Add(grdSetting.Rows[rowIndex].Cells[i].Value.ToString());   //把当前选中行的数据存入list数组中
            }

            for (int j = 0; j < grdSetting.Columns.Count; j++)
            {
                grdSetting.Rows[rowIndex].Cells[j].Value = grdSetting.Rows[rowIndex - 1].Cells[j].Value;
                grdSetting.Rows[rowIndex - 1].Cells[j].Value = list[j].ToString();
            }
            grdSetting.Rows[rowIndex -1].Selected = true;
            this.SetControlState();
        }

        //向下移动
        private void SetDown()
        {
            //得到当前选中列的索引
            int columnIndex = grdSetting.SelectedCells[0].ColumnIndex;
            //得到当前选中行的索引
            int rowIndex = grdSetting.SelectedCells[0].RowIndex;

            if (rowIndex == grdSetting.Rows.Count - 1)
            {
                return;
            }

            List<string> list = new List<string>();
            for (int i = 0; i < grdSetting.Columns.Count; i++)
            {
                list.Add(grdSetting.Rows[rowIndex].Cells[i].Value.ToString());   //把当前选中行的数据存入list数组中
            }

            for (int j = 0; j < grdSetting.Columns.Count; j++)
            {
                grdSetting.Rows[rowIndex].Cells[j].Value = grdSetting.Rows[rowIndex + 1].Cells[j].Value;
                grdSetting.Rows[rowIndex + 1].Cells[j].Value = list[j].ToString();
            }
            grdSetting.Rows[rowIndex + 1].Selected = true;
            this.SetControlState();
        }

        //向顶移动
        private void SetTop()
        {
            //得到当前选中行的索引
            int rowIndex = grdSetting.SelectedCells[0].RowIndex;
            //我能想到最简单的方法
            for (int i = 0; i <= rowIndex; i++)
            {
                SetUp();
            }
        }

        //向底移动
        private void SetBottom()
        {
            //得到当前选中行的索引
            int rowIndex = grdSetting.SelectedCells[0].RowIndex;
            for (int i = 0; i <= grdSetting.Rows.Count - rowIndex - 1; i++)
            {
                SetDown();
            }
        }
        #endregion

        #region 其它事件
        //DataGridView选择Cell焦点进入事件
        private void grdSetting_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            this.SetControlState();
        }

        public override void SetControlState()
        {
            if (grdSetting.SelectedCells.Count == 0)
            {
                return;
            }
            if (grdSetting.SelectedCells[0].RowIndex == 0)
            {
                btnSetUp.Enabled = false;
                btnSetTop.Enabled = false;
            }
            else
            {
                btnSetUp.Enabled = true;
                btnSetTop.Enabled = true;
            }
            if (grdSetting.SelectedCells[0].RowIndex == grdSetting.Rows.Count - 1)
            {
                btnSetDown.Enabled = false;
                btnSetBottom.Enabled = false;
            }
            else
            {
                btnSetDown.Enabled = true;
                btnSetBottom.Enabled = true;
            }
        }
        #endregion
    }
}
