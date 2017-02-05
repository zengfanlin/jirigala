//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;
    using System.Data;

    /// <summary>
    /// FrmOrganizeCodeBuilder
    /// 组织机构管理-编号产生器
    ///		
    /// 修改记录
    /// 
    ///     2008.05.14 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：1.9
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.02.05</date>
    /// </author> 
    /// </summary>
    public partial class FrmOrganizeCodeBuilder : BaseForm
    {
        public FrmOrganizeCodeBuilder()
        {
            InitializeComponent();
            // 加载系统信息
            // UserInfo = new BaseUserInfo(this.Name, this.Text);
        }

        public FrmOrganizeCodeBuilder(TreeView TreeView) : this()
        {
            this.TVOrganize = TreeView;
        }

        TreeView TVOrganize = null;

        /// <summary>
        /// 获取参数设置
        /// </summary>
        /// <param name="nudLevel">控件</param>
        /// <param name="level">参数值</param>
        private void GetDatabaseParameter(NumericUpDown nudLevel, string level)
        {
            string parameter = DotNetService.Instance.ParameterService.GetParameter(UserInfo, "Application", "OrganizeCodeBuilder", level);
            if (!String.IsNullOrEmpty(parameter))
            {
                nudLevel.Value = int.Parse(parameter);
            }
        }

        /// <summary>
        /// 获取参数设置
        /// </summary>
        private void GetDatabaseParameter()
        {
            this.GetDatabaseParameter(this.nudLevel01, "Level01");
            this.GetDatabaseParameter(this.nudLevel02, "Level02");
            this.GetDatabaseParameter(this.nudLevel03, "Level03");
            this.GetDatabaseParameter(this.nudLevel04, "Level04");
            this.GetDatabaseParameter(this.nudLevel05, "Level05");
            this.GetDatabaseParameter(this.nudLevel06, "Level06");
            this.GetDatabaseParameter(this.nudLevel07, "Level07");
            this.GetDatabaseParameter(this.nudLevel08, "Level08");
            this.GetDatabaseParameter(this.nudLevel09, "Level09");
            this.GetDatabaseParameter(this.nudLevel10, "Level10");
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnAdvice.Enabled = false;
            this.btnCodeBuilder.Enabled = false;
            if (this.TVOrganize != null)
            {
                this.btnAdvice.Enabled = true;
                this.btnCodeBuilder.Enabled = true;
            }
        }
        #endregion

        private void FrmOrganizeCodeBuilder_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                // 获取参数设置
                this.GetDatabaseParameter();
            }
        }

        private void SetAdvice(int level, int nodesCount)
        {
            string nudLevel = level.ToString();
            if (level < 10)
            {
                nudLevel = "0" + nudLevel;
            }
            nudLevel = "nudLevel" + nudLevel;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].Name.Equals(nudLevel))
                {
                    if (nodesCount.ToString().Length > ((NumericUpDown)this.Controls[i]).Value)
                    {
                        ((NumericUpDown)this.Controls[i]).Value = nodesCount.ToString().Length;
                        break;
                    }
                }
            } 
        }

        private void GetTreeNodesCount(TreeNode treeNode)
        {
            this.SetAdvice(treeNode.Level + 1, treeNode.Nodes.Count);
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                this.GetTreeNodesCount(treeNode.Nodes[i]);
            }
        }

        #region private void GetAdvice() 计算树型机构的节点数目
        /// <summary>
        /// 计算树型机构的节点数目
        /// </summary>
        private void GetAdvice()
        {
            this.SetAdvice(1, this.TVOrganize.Nodes.Count);
            for (int i = 0; i < this.TVOrganize.Nodes.Count; i++)
            {
                this.GetTreeNodesCount(this.TVOrganize.Nodes[i]);
            }
        }
        #endregion

        private void SetDefault()
        {
            this.nudLevel01.Value = 2;
            this.nudLevel02.Value = 2;
            this.nudLevel03.Value = 2;
            this.nudLevel04.Value = 2;
            this.nudLevel05.Value = 2;
            this.nudLevel06.Value = 2;
            this.nudLevel07.Value = 2;
            this.nudLevel08.Value = 2;
            this.nudLevel09.Value = 2;
            this.nudLevel10.Value = 2;
        }

        private void btnAdvice_Click(object sender, EventArgs e)
        {
            if (this.TVOrganize == null)
            {
                return;
            }
            this.SetDefault();
            this.GetAdvice();
        }

        /// <summary>
        /// 获取那个层参数设置为几位
        /// </summary>
        /// <param name="level">层数</param>
        /// <returns>位数</returns>
        private int GetParameterSeting(int level)
        {
            int returnValue = 0;
            string nudLevel = level.ToString();
            if (level < 10)
            {
                nudLevel = "0" + nudLevel;
            }
            nudLevel = "nudLevel" + nudLevel;
            for (int i = 0; i < this.Controls.Count; i++)
            {
                if (this.Controls[i].Name.Equals(nudLevel))
                {
                    returnValue = (int)((NumericUpDown)this.Controls[i]).Value;
                    break;
                }
            }
            return returnValue;
        }

        private string GetNodeCode(TreeNode treeNode)
        {
            string returnValue = string.Empty;
            string code = string.Empty;
            int levelLength = 0;
            
            // 计算编号
            levelLength = this.GetParameterSeting(treeNode.Level + 1);
            code = (treeNode.Index + 1).ToString();
            code = code.PadLeft(levelLength, '0');
            returnValue = code + returnValue;

            while (treeNode.Parent != null)
            {
                treeNode = treeNode.Parent;
                
                // 计算编号
                levelLength = this.GetParameterSeting(treeNode.Level + 1);
                code = (treeNode.Index + 1).ToString();
                code = code.PadLeft(levelLength, '0'); 
                returnValue = code + "." + returnValue;
            }
            return returnValue;
        }

        string organizeIdList = string.Empty;
        string organizeCodeList = string.Empty;

        private void CodeBuilder(TreeNode treeNode)
        {
            // 这里是可以获得所有节点的编号
            // TreeNode.Text = this.GetNodeCode(TreeNode);
            organizeIdList += (treeNode.Tag as DataRow)[BaseOrganizeEntity.FieldId].ToString() + ",";
            organizeCodeList += this.GetNodeCode(treeNode) + ",";

            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                this.CodeBuilder(treeNode.Nodes[i]);
            }
        }

        /// <summary>
        /// 检查页面输入
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInput()
        {
            bool returnValue = true;
            int maxLength = 0;
            maxLength += (int)this.nudLevel01.Value;
            maxLength += (int)this.nudLevel02.Value;
            maxLength += (int)this.nudLevel03.Value;
            maxLength += (int)this.nudLevel04.Value;
            maxLength += (int)this.nudLevel05.Value;
            maxLength += (int)this.nudLevel06.Value;
            maxLength += (int)this.nudLevel07.Value;
            maxLength += (int)this.nudLevel08.Value;
            maxLength += (int)this.nudLevel09.Value;
            maxLength += (int)this.nudLevel10.Value;
            if (maxLength > 40)
            {
                MessageBox.Show(AppMessage.MSG0213, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                returnValue = false;
            }
            return returnValue;
        }


        private void btnCodeBuilder_Click(object sender, EventArgs e)
        {
            if (!this.CheckInput())
            {
                return;
            }
            for (int i = 0; i < this.TVOrganize.Nodes.Count; i++)
            {
                this.CodeBuilder(this.TVOrganize.Nodes[i]);
            }

            if ((!String.IsNullOrEmpty(this.organizeIdList)) && (!String.IsNullOrEmpty(this.organizeCodeList)))
            {

                this.organizeIdList = this.organizeIdList.Substring(0, this.organizeIdList.Length - 1);
                this.organizeCodeList = this.organizeCodeList.Substring(0, this.organizeCodeList.Length - 1);
                
                string[] ids = this.organizeIdList.Split(',');
                string[] codes = this.organizeCodeList.Split(',');
                this.organizeIdList = string.Empty;
                this.organizeCodeList = string.Empty;
                DotNetService.Instance.OrganizeService.BatchSetCode(UserInfo, ids, codes);
            }
            MessageBox.Show(AppMessage.MSG0283, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void SaveDatabaseParameter(NumericUpDown nudLevel, string level)
        {
            DotNetService.Instance.ParameterService.SetParameter(UserInfo, "Application", "OrganizeCodeBuilder", level, ((int)nudLevel.Value).ToString());
        }

        /// <summary>
        /// 保存参数
        /// </summary>
        private void SaveDatabaseParameter()
        {
            this.SaveDatabaseParameter(this.nudLevel01, "Level01");
            this.SaveDatabaseParameter(this.nudLevel02, "Level02");
            this.SaveDatabaseParameter(this.nudLevel03, "Level03");
            this.SaveDatabaseParameter(this.nudLevel04, "Level04");
            this.SaveDatabaseParameter(this.nudLevel05, "Level05");
            this.SaveDatabaseParameter(this.nudLevel06, "Level06");
            this.SaveDatabaseParameter(this.nudLevel07, "Level07");
            this.SaveDatabaseParameter(this.nudLevel08, "Level08");
            this.SaveDatabaseParameter(this.nudLevel09, "Level09");
            this.SaveDatabaseParameter(this.nudLevel10, "Level10");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (this.CheckInput())
            {
                this.SaveDatabaseParameter();
                MessageBox.Show(AppMessage.MSG0011, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }     
    }
}