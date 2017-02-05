//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DotNet.WinForm.LogOn
{
    using DotNet.Utilities;

    /// <summary>
    /// FrmSelectNetwork
    /// 
    /// 修改纪录
    /// 
    ///		2008.03.31 版本：1.0 JiRiGaLa 整理文件。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.09.17</date>
    /// </author> 
    /// </summary>
    public partial class FrmSelectNetwork : Form
    {
        public FrmSelectNetwork()
        {
            InitializeComponent();
        }

        private string selectNetwork = string.Empty;
        public string SelectNetwork
        {
            get
            {
                return this.selectNetwork;
            }
            set
            {
                this.selectNetwork = value;
            }
        }

        private void btnInner_Click(object sender, EventArgs e)
        {
            this.SelectNetwork = "Inner";
            UserConfigHelper.GetConfig();
            this.Close();
        }

        private void btnOuter_Click(object sender, EventArgs e)
        {
            this.SelectNetwork = "Outer";
            UserConfigHelper.GetConfig();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}