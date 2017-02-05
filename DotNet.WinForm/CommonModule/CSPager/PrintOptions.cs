//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    public partial class PrintOptions : Form
    {
        public PrintOptions()
        {
            InitializeComponent();
        }

        public PrintOptions(List<string> availableFields)
        {
            InitializeComponent();

            foreach (string field in availableFields)
            {
                chklst.Items.Add(field, true);
            }
        }

        /// <summary>
        /// 设置选定项目
        /// </summary>
        /// <param name="items"></param>
        public void SetCheckedItems(string[] items)
        {
            for (int i = 0; i < this.chklst.Items.Count; i++)
            {
                this.chklst.SetItemChecked(i, false);
                foreach (string item in items)
                {
                    if (item == this.chklst.Items[i].ToString())
                    {
                        this.chklst.SetItemChecked(i, true);
                    }
                }
            }
        }

        /// <summary>
        /// 获取用户选定的项目内容
        /// </summary>
        /// <returns></returns>
        public List<string> GetCheckItems()
        {
            List<string> list = new List<string>();
            for (int i = 0; i < this.chklst.Items.Count; i++)
            {
                if (this.chklst.GetItemChecked(i))
                {
                    list.Add(this.chklst.Items[i].ToString());
                }
            }
            return list;
        }

        private void PrintOtions_Load(object sender, EventArgs e)
        {
            // Initialize some controls
            rdoAllRows.Checked = true;
            chkFitToPageWidth.Checked = true; 
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public List<string> GetSelectedColumns()
        {
            List<string> lst = new List<string>();
            foreach (object item in chklst.CheckedItems)
            {
                lst.Add(item.ToString());
            }
            return lst;
        }

        public string PrintTitle
        {
            get { return txtTitle.Text; }
            set { this.txtTitle.Text = value; }
        }

        public bool PrintAllRows
        {
            get { return rdoAllRows.Checked; }
        }

        public bool FitToPageWidth
        {
            get { return chkFitToPageWidth.Checked; }
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.chklst.Items.Count; i++)
            {
                this.chklst.SetItemChecked(i, this.chkSelectAll.Checked);
            }
        }

    }
}