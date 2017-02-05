//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Linq;

namespace DotNet.WinForm
{
    using DotNet.Utilities;

    /// <summary>
    ///	BaseInterfaceLogic
    /// 通用页面控制基类
    /// 
    /// 修改纪录
    ///                                      这个程序应该进行分解了，按功能都给分解出来。
    ///     2012.06.09 版本：3.9    Pcsky    修改“加载树型结构的主键”方法,加入按用户配置展开功能，TreeNode的Tag改成存储DataRow，
    ///     2012.2.2   版本：3.8    张毅     修改“加载树型结构的主键”方法  
    ///     2011.10.31 版本：3.8    张广梁   增加CheckChild,CheckParent方法
    ///     2011.10.10 版本：3.7    张广梁   增加AddTreeNode方法,增加MoveTreeNode方法,增加BatchRemoveNode方法
    ///     2011.07.07 版本：3.6    JiRiGaLa 增加DataGridView保存列宽，页面设置。
    ///     2011.06.16 版本：3.6    JiRiGaLa 修改多语言使其适应TabsMainForm窗体。
    ///     2008.04.01 版本：1.3    JiRiGaLa IsModfiedAnyOne 函数功能能改进。
    ///     2008.02.03 版本：1.2    JiRiGaLa LoadTreeNodes 函数性能改进。
    ///		2007.09.29 版本：1.1	JiRiGaLa IsModfiedAnyOne() 函数进行修正。
    ///		2007.05.16 版本：1.0	JiRiGaLa 建立，为了提高效率分开建立了类。
    ///	
    /// 版本：1.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.02.03</date>
    /// </author> 
    /// </summary>
    public class BaseInterfaceLogic
    {
        #region public static string FromatStringWidth(Font font, string target, int width) 获取指定长度的字符串
        /// <summary>
        /// 获取指定长度的字符串
        /// </summary>
        /// <param name="Font">显示的字体</param>
        /// <param name="target">目标字符串</param>
        /// <param name="width">需要截断的宽度</param>
        /// <returns>结果字符串</returns>
        public static string FromatStringWidth(Font font, string target, int width)
        {
            // 创建画布对象
            Image image = new Bitmap(1, 1);
            Graphics graphics = Graphics.FromImage(image);
            string returnValue = target;
            SizeF sizeF = graphics.MeasureString(target, font);
            for (int i = target.Length - 1; i >= 0; i--)
            {
                if (sizeF.Width <= width)
                {
                    break;
                }
                returnValue = target.Substring(0, i);
                sizeF = graphics.MeasureString(returnValue, font);
            }
            // 释放资源
            graphics.Dispose();
            return returnValue;
        }
        #endregion

        public static void SetColumns(DataGridView dataGridView, string[] columns)
        {
            for (int i = dataGridView.Columns.Count - 1; i > 0; i--)
            {
                if (dataGridView.Columns[i].DataPropertyName.Equals("Selected"))
                {
                    break;
                }
                if (!StringUtil.Exists(columns, dataGridView.Columns[i].DataPropertyName))
                {
                    dataGridView.Columns.RemoveAt(i);
                }
            }
        }

        public static void SetEditColumns(DataGridView dataGridView, string[] columns)
        {
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                if (StringUtil.Exists(columns, dataGridView.Columns[i].DataPropertyName))
                {
                    dataGridView.Columns[i].ReadOnly = false;
                    dataGridView.Columns[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 128);
                }
            }
        }

        public static void RemoveColumns(DataGridView dataGridView, string[] columns)
        {
            for (int i = dataGridView.Columns.Count - 1; i > 0; i--)
            {
                if (StringUtil.Exists(columns, dataGridView.Columns[i].DataPropertyName))
                {
                    dataGridView.Columns.RemoveAt(i);
                }
            }
        }

        #region public static DataRow GetDataGridViewEntity(DataGridView targetDataGridView) 获得表格中的当前数据行
        /// <summary>
        /// 获得表格中的当前数据行
        /// </summary>
        /// <param name="targetDataGridView">目标表格控件</param>
        /// <returns>数据行</returns>
        public static DataRow GetDataGridViewEntity(DataGridView targetDataGridView)
        {
            DataRow dataRow = null;
            CurrencyManager currencyManager = null;
            if (targetDataGridView.DataMember == string.Empty)
            {
                if (targetDataGridView.DataSource != null)
                {
                    currencyManager = (CurrencyManager)targetDataGridView.BindingContext[targetDataGridView.DataSource, string.Empty];
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(targetDataGridView.DataMember))
                {
                    currencyManager = (CurrencyManager)targetDataGridView.BindingContext[targetDataGridView.DataMember];
                }
            }
            if (currencyManager != null && currencyManager.Count > 0)
            {
                dataRow = ((DataRowView)currencyManager.Current).Row;
            }
            return dataRow;
        }
        #endregion

        #region public static string GetDataGridViewEntityID(DataGridView targetDataGridView, string fieldId) 获得表格中的当前的ID主键
        /// <summary>
        /// 获得表格中的当前的ID主键
        /// </summary>
        /// <param name="targetDataGridView">目标表格控件</param>
        /// <param name="fieldId">主键字段</param>
        /// <returns>主键</returns>
        public static string GetDataGridViewEntityId(DataGridView targetDataGridView, string fieldId)
        {
            string returnValue = string.Empty;
            if (targetDataGridView.CurrentRow != null)
            {
                DataRow dataRow = (targetDataGridView.CurrentRow.DataBoundItem as DataRowView).Row;
                if (dataRow != null)
                {
                    returnValue = dataRow[fieldId].ToString();
                }
            }
            return returnValue;
        }
        #endregion

        #region public static int SetLanguageResource(Form targetForm) 设置页面控件上的多语言信息
        public static int SetLanguageResource(UserControl userControl)
        {
            int returnValue = 0;
            string key = string.Empty;
            string language = string.Empty;
            System.Reflection.FieldInfo[] fieldInfo = userControl.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            for (int i = 0; i < fieldInfo.Length; i++)
            {
                if ((fieldInfo[i].FieldType.Name.Equals("Label")) || (fieldInfo[i].FieldType.Name.Equals("CheckBox")) || (fieldInfo[i].FieldType.Name.Equals("Button")) || (fieldInfo[i].FieldType.Name.Equals("GroupBox")) || (fieldInfo[i].FieldType.Name.Equals("RadioButton")))
                {
                    Control control = (Control)fieldInfo[i].GetValue(userControl);
                    // 窗体上的控件多语言处理
                    key = userControl.GetType().Name + "_" + control.Name;
                    language = ResourceManagerWrapper.Instance.Get(key);
                    if (language.Length > 0)
                    {
                        control.Text = language;
                        returnValue++;
                    }
                }
                // 对表格的列名多语言处理
                if (fieldInfo[i].FieldType.Name.Equals("DataGridView"))
                {
                    DataGridView targetDataGridView = (DataGridView)fieldInfo[i].GetValue(userControl);
                    for (int j = 0; j < targetDataGridView.ColumnCount; j++)
                    {
                        key = userControl.Name + "_" + targetDataGridView.Columns[j].Name;
                        language = ResourceManagerWrapper.Instance.Get(key);
                        if (language.Length > 0)
                        {
                            targetDataGridView.Columns[j].HeaderText = language;
                            returnValue++;
                        }
                    }
                }
            }
            return returnValue;
        }

        /// <summary>
        /// 设置页面控件上的多语言信息
        /// </summary>
        /// <param name="targetForm">目标页面</param>
        /// <returns>设置多语言的控件个数</returns>
        public static int SetLanguageResource(Form targetForm)
        {
            int returnValue = 0;
            string key = string.Empty;
            string language = string.Empty;

            // 窗体的名字
            key = targetForm.Name;
            language = ResourceManagerWrapper.Instance.Get(key);
            if (!string.IsNullOrEmpty(language))
            {
                targetForm.Text = language;
            }
            // 控件ContextMenuStrip不在controls集合里，所以必须用反射取得；
            System.Reflection.FieldInfo[] fieldInfo = targetForm.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            for (int i = 0; i < fieldInfo.Length; i++)
            {
                if (fieldInfo[i].FieldType.Name.Equals("UCOrganizeSelect") || fieldInfo[i].FieldType.Name.Equals("UCUserSelect")
                    || fieldInfo[i].FieldType.Name.Equals("UCItemDetailsTreeSelect") || fieldInfo[i].FieldType.Name.Equals("UCAutoWorkFlowStatr")
                    || fieldInfo[i].FieldType.Name.Equals("UCFreeWorkFlowStatr") || fieldInfo[i].FieldType.Name.Equals("UCFreeWorkFlow")
                    || fieldInfo[i].FieldType.Name.Equals("UCAutoWorkFlow") || fieldInfo[i].FieldType.Name.Equals("UCStaffSelect")
                    || fieldInfo[i].FieldType.Name.Equals("UCPermissionSelect") || fieldInfo[i].FieldType.Name.Equals("UCModuleSelect")
                    || fieldInfo[i].FieldType.Name.Equals("UCPicture") || fieldInfo[i].FieldType.Name.Equals("UCFolderSelect")
                    || fieldInfo[i].FieldType.Name.Equals("UCRoleSelect") || fieldInfo[i].FieldType.Name.Equals("UCScopePermissionSelect"))
                {
                    UserControl userControl = (UserControl)fieldInfo[i].GetValue(targetForm);
                    returnValue += SetLanguageResource(userControl);
                }

                if (fieldInfo[i].FieldType.Name.Equals("ToolStripMenuItem"))
                {
                    ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)fieldInfo[i].GetValue(targetForm);
                    key = targetForm.Name + "_" + toolStripMenuItem.Name;
                    language = ResourceManagerWrapper.Instance.Get(key);
                    if (!string.IsNullOrEmpty(language))
                    {
                        toolStripMenuItem.Text = language;
                        returnValue++;
                    }
                }
                if (fieldInfo[i].FieldType.Name.Equals("NotifyIcon"))
                {
                    NotifyIcon notifyIcon = (NotifyIcon)fieldInfo[i].GetValue(targetForm);
                    key = targetForm.Name + "_notifyIcon";
                    language = ResourceManagerWrapper.Instance.Get(key);
                    if (!string.IsNullOrEmpty(language))
                    {
                        notifyIcon.BalloonTipText = language;
                        notifyIcon.BalloonTipTitle = language;
                        notifyIcon.Text = language;
                        returnValue++;
                    }
                }
                if ((fieldInfo[i].FieldType.Name.Equals("Label")) || (fieldInfo[i].FieldType.Name.Equals("CheckBox"))
                    || (fieldInfo[i].FieldType.Name.Equals("Button")) || (fieldInfo[i].FieldType.Name.Equals("GroupBox"))
                    || (fieldInfo[i].FieldType.Name.Equals("RadioButton")) || (fieldInfo[i].FieldType.Name.Equals("TabPage")))
                {

                    Control control = (Control)fieldInfo[i].GetValue(targetForm);
                    // 窗体上的控件多语言处理
                    key = targetForm.Name + "_" + control.Name;
                    language = ResourceManagerWrapper.Instance.Get(key);
                    if (!string.IsNullOrEmpty(language))
                    {
                        control.Text = language;
                        returnValue++;
                    }
                }

                // 对表格的列名多语言处理 及列宽处理
                if (fieldInfo[i].FieldType.Name.Equals("DataGridView"))
                {
                    DataGridView targetDataGridView = (DataGridView)fieldInfo[i].GetValue(targetForm);
                    for (int j = 0; j < targetDataGridView.ColumnCount; j++)
                    {
                        key = targetForm.Name + "_" + targetDataGridView.Columns[j].Name;
                        language = ResourceManagerWrapper.Instance.Get(key);
                        if (!string.IsNullOrEmpty(language))
                        {
                            targetDataGridView.Columns[j].HeaderText = language;
                            returnValue++;
                        }
                    }
                }
            }

            return returnValue;
        }
        #endregion

        #region public static void LoadDataGridViewColumnWidth(Form targetForm) 加载页面DataGridView控件上的列宽
        /// <summary>
        /// 加载页面DataGridView控件上的列宽
        /// </summary>
        /// <param name="targetForm">目标页面</param>
        public static void LoadDataGridViewColumnWidth(Form targetForm)
        {
            //FrmDataGridViewSetting窗体不加载保存
            if (targetForm.Name == "FrmDataGridViewSetting" || targetForm.Name == "FrmImportUser" || targetForm.Name == "FrmImportStaff")
            {
                return;
            }
            //配置数据权限
            DataSet dsDataGridViewColumns = new DataSet();
            // 窗体的名字
            string key = targetForm.Name;
            System.Reflection.FieldInfo[] fieldInfo = targetForm.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            //检索出DataGridViews控件
            var fieldDataGridViews = from dgv in fieldInfo
                                     where dgv.FieldType.Name.Equals("DataGridView")
                                     select dgv;
            foreach (var item in fieldDataGridViews)
            {
                DataGridView targetDataGridView = (DataGridView)item.GetValue(targetForm);
                //加载事件
                LoadMouseClick(targetDataGridView, targetForm);

                string targetFileFullName = BaseSystemInfo.StartupPath + "\\UserParameter\\" + targetForm.Name + "_" + targetDataGridView.Name + ".xml";
                //判断DataGridView配置文件是否存在,如果存在则设置列宽，如果不存在则新增文件。
                if (System.IO.File.Exists(targetFileFullName))
                {
                    dsDataGridViewColumns.Tables.Clear();
                    dsDataGridViewColumns.ReadXml(targetFileFullName);
                    //如果列没有更新
                    if (dsDataGridViewColumns.Tables[0].Rows.Count == targetDataGridView.ColumnCount)
                    {
                        for (int j = 0; j < targetDataGridView.ColumnCount; j++)
                        {
                            targetDataGridView.Columns[j].HeaderText = targetDataGridView.Columns[j].HeaderText;
                            //设置冻结列
                            bool ColumnFrozen = bool.Parse(dsDataGridViewColumns.Tables[0].Select("ColumnName='" + targetDataGridView.Columns[j].Name + "'")[0]["Frozen"].ToString());

                            targetDataGridView.Columns[j].Frozen = ColumnFrozen;
                            //设置显示
                            bool ColumnVisible = bool.Parse(dsDataGridViewColumns.Tables[0].Select("ColumnName='" + targetDataGridView.Columns[j].Name + "'")[0]["Visible"].ToString());
                            targetDataGridView.Columns[j].Visible = ColumnVisible;
                            //设置位置
                            int DisplayIndex = int.Parse(dsDataGridViewColumns.Tables[0].Select("ColumnName='" + targetDataGridView.Columns[j].Name + "'")[0]["DisplayIndex"].ToString());
                            //冻结列有待优化
                            try
                            {
                                targetDataGridView.Columns[j].DisplayIndex = DisplayIndex;
                            }
                            catch
                            { }
                            //设置列宽
                            int ColumnsWidth = int.Parse(dsDataGridViewColumns.Tables[0].Select("ColumnName='" + targetDataGridView.Columns[j].Name + "'")[0]["Width"].ToString());
                            targetDataGridView.Columns[j].Width = ColumnsWidth;
                        }
                    }
                    else
                    {
                        SaveDataGridViewColumnWidth(targetForm, targetDataGridView);
                    }
                }
                else
                {
                    if (!System.IO.Directory.Exists(BaseSystemInfo.StartupPath + "\\UserParameter"))
                    {
                        System.IO.Directory.CreateDirectory(BaseSystemInfo.StartupPath + "\\UserParameter");
                    }
                    SaveDataGridViewColumnWidth(targetForm, targetDataGridView);
                }
            }
        }

        //设置DataGridView右键菜单
        private static void LoadMouseClick(DataGridView targetDataGridView, Form targetForm)
        {
            /// <summary>
            /// 扩展DGV的右键菜单。
            /// 如果DGV已经定义了右键菜单(DGV的属性ContextMenuStrip)，就在其之后添加 数据栏设置 菜单项。
            /// 如果DGV没有定义右键菜单，则创建新右键菜单，并将其赋给DGV
            /// </summary>
            /// <name>赵秉杰</name>
            ///	<date>2012-7-17</date>

            //  先注释原来的创建ContextMenuStrip的语句
            //System.Windows.Forms.ContextMenuStrip contextMenuStrip = new ContextMenuStrip();
            System.Windows.Forms.ContextMenuStrip contextMenuStrip;
            if (targetDataGridView.ContextMenuStrip == null)
            {
                contextMenuStrip = new ContextMenuStrip();
                contextMenuStrip.Name = "contextMenuStrip";
            }
            else
            {
                contextMenuStrip = targetDataGridView.ContextMenuStrip;
            }
            // -------------End 赵秉杰 2012-7-17 -------------------------------------------------------

            
            contextMenuStrip.Tag = targetForm;
            System.Windows.Forms.ToolStripMenuItem clickToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { clickToolStripMenuItem });
            //contextMenuStrip.Name = "contextMenuStrip";
            contextMenuStrip.Size = new System.Drawing.Size(153, 48);
            clickToolStripMenuItem.Name = "clickToolStripMenuItem";
            clickToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            clickToolStripMenuItem.Text = AppMessage.clickToolStripMenuItem;
            clickToolStripMenuItem.Tag = targetDataGridView;
            clickToolStripMenuItem.Click += new System.EventHandler(clickToolStripMenuItem_Click);

            targetDataGridView.ContextMenuStrip = contextMenuStrip;
        }

        private static void clickToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            FrmDataGridViewSetting frmDataGridViewSetting = new FrmDataGridViewSetting();
            frmDataGridViewSetting.TargetDataGridView = (sender as ToolStripMenuItem).Tag as DataGridView;
            frmDataGridViewSetting.TargetForm = (sender as ToolStripMenuItem).Owner.Tag as Form;
            frmDataGridViewSetting.ShowDialog();
        }
        #endregion

        #region public static void SaveDataGridViewColumnWidth(Form targetForm) 保存页面DataGridView控件上的列宽
        /// <summary>
        /// 保存页面DataGridView控件上的列宽
        /// </summary>
        /// <param name="targetForm">目标页面</param>
        public static void SaveDataGridViewColumnWidth(Form targetForm)
        {
            //配置数据权限
            DataSet dsDataGridViewColumns = new DataSet();
            // 窗体的名字
            string key = targetForm.Name;
            System.Reflection.FieldInfo[] fieldInfo = targetForm.GetType().GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            //检索出DataGridViews控件
            var fieldDataGridViews = from dgv in fieldInfo
                                     where dgv.FieldType.Name.Equals("DataGridView")
                                     select dgv;
            foreach (var item in fieldDataGridViews)
            {
                SaveDataGridViewColumnWidth(targetForm, (DataGridView)item.GetValue(targetForm));
            }
        }

        private static void SaveDataGridViewColumnWidth(Form targetForm, DataGridView targetDataGridView)
        {
            //FrmDataGridViewSetting窗体不加载保存
            if (targetForm.Name == "FrmDataGridViewSetting")
            {
                return;
            }
            string targetFileFullName = BaseSystemInfo.StartupPath + "\\UserParameter\\" + targetForm.Name + "_" + targetDataGridView.Name + ".xml";
            DataSet dsDataGridViewColumns = new DataSet(targetDataGridView.Name);
            dsDataGridViewColumns.Tables.Add(targetDataGridView.Name);
            dsDataGridViewColumns.Tables[0].Columns.Add("ColumnName", typeof(string));
            dsDataGridViewColumns.Tables[0].Columns.Add("HeaderText", typeof(string));
            dsDataGridViewColumns.Tables[0].Columns.Add("Frozen", typeof(bool));
            dsDataGridViewColumns.Tables[0].Columns.Add("Visible", typeof(bool));
            dsDataGridViewColumns.Tables[0].Columns.Add("DisplayIndex", typeof(int));
            dsDataGridViewColumns.Tables[0].Columns.Add("Width", typeof(int));
            for (int j = 0; j < targetDataGridView.ColumnCount; j++)
            {
                DataGridViewColumn Column = targetDataGridView.Columns[j];
                dsDataGridViewColumns.Tables[0].Rows.Add(Column.Name, Column.HeaderText, Column.Frozen, Column.Visible, Column.DisplayIndex, Column.Width);
            }
            dsDataGridViewColumns.WriteXml(targetFileFullName);
        }
        #endregion

        #region public static bool NodeAllowDelete(TreeNode treeNode) 节点是否允许删除
        /// <summary>
        /// 节点是否允许删除
        /// </summary>
        /// <param name="treeNode">当前节点</param>
        /// <returns>是否允许</returns>
        public static bool NodeAllowDelete(TreeNode treeNode)
        {
            if (treeNode == null)
            {
                return false;
            }
            return (treeNode.Nodes.Count == 0);
        }
        #endregion

        #region public static void ExpandTreeNode(TreeView treeView) 展开节点
        /// <summary>
        /// 展开节点
        /// </summary>
        /// <param name="treeView">当前节点</param>
        public static void ExpandTreeNode(TreeView treeView)
        {
            TreeNode treeNode = treeView.SelectedNode;
            while (treeNode != null)
            {
                treeNode.Expand();
                treeNode = treeNode.Parent;
            }
        }
        #endregion

        // 已找到的树节点
        public static TreeNode TargetNode = null;

        #region public static void FindTreeNode(TreeView treeView, string fieldId, string id) 查找树节点(Tag存DataRow方式)
        /// <summary>
        /// 查找树节点(Tag存DataRow方式)
        /// </summary>
        /// <param name="treeView">树节点</param>
        /// <param name="fieldId">主键字段</param>
        /// <param name="id">主键</param>
        public static void FindTreeNode(TreeView treeView, string fieldId, string id)
        {
            TargetNode = null;
            for (int i = 0; i < treeView.Nodes.Count; i++)
            {
                if (treeView.Nodes[i].Tag is DataRow)
                {
                    if (((DataRow)treeView.Nodes[i].Tag)[fieldId].ToString() == id)
                    {
                        TargetNode = treeView.Nodes[i];
                        return;
                    }
                }
                else
                {
                    if (treeView.Nodes[i].Tag.ToString() == id)
                    {
                        TargetNode = treeView.Nodes[i];
                        return;
                    }
                }
                FindTreeNode(treeView.Nodes[i], fieldId, id);
            }
        }
        #endregion

        #region private static void FindTreeNode(TreeNode treeNode, string fieldId, string id) 查找树节点(Tag存DataRow方式)
        /// <summary>
        /// 查找树节点(Tag存DataRow方式)
        /// </summary>
        /// <param name="treeNode">节点</param>
        /// <param name="id">主键</param>
        private static void FindTreeNode(TreeNode treeNode, string fieldId, string id)
        {
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                //if (treeNode.Nodes[i].Tag.ToString() == id)
                if (treeNode.Nodes[i].Tag is DataRow)
                {
                    if (((DataRow)treeNode.Nodes[i].Tag)[fieldId].ToString() == id)
                    {
                        TargetNode = treeNode.Nodes[i];
                        break;
                    }
                }
                else
                {
                    if (treeNode.Nodes[i].Tag.ToString() == id)
                    {
                        TargetNode = treeNode.Nodes[i];
                        return;
                    }
                }
                FindTreeNode(treeNode.Nodes[i], fieldId, id);
            }
        }
        #endregion

        #region public static void FindTreeNode(TreeView treeView, string id) 查找树节点
        /// <summary>
        /// 查找树节点(这方法与下面的方法写得有些不好)
        /// </summary>
        /// <param name="treeView">树节点</param>
        /// <param name="id">主键</param>
        public static void FindTreeNode(TreeView treeView, string id)
        {
            TargetNode = null;
            for (int i = 0; i < treeView.Nodes.Count; i++)
            {
                if (treeView.Nodes[i].Tag is DataRow)
                {
                    if (((DataRow)treeView.Nodes[i].Tag)[BaseBusinessLogic.FieldId].ToString() == id)
                    {
                        TargetNode = treeView.Nodes[i];
                        return;
                    }
                }
                else if (treeView.Nodes[i].Tag.ToString() == id)
                {
                    TargetNode = treeView.Nodes[i];
                    return;
                }
                FindTreeNode(treeView.Nodes[i], id);
            }
        }
        #endregion


        #region private static void FindTreeNode(TreeNode treeNode, string id) 查找树节点
        /// <summary>
        /// 查找树节点(这方法与上面的方法写得有些不好)
        /// </summary>
        /// <param name="treeNode">节点</param>
        /// <param name="id">主键</param>
        private static void FindTreeNode(TreeNode treeNode, string id)
        {
            for (int i = 0; i < treeNode.Nodes.Count; i++)
            {
                if (treeNode.Nodes[i].Tag is DataRow)
                {
                    if (((DataRow)treeNode.Nodes[i].Tag)[BaseBusinessLogic.FieldId].ToString() == id)
                    {
                        TargetNode = treeNode.Nodes[i];
                        return;
                    }
                }
                if (treeNode.Nodes[i].Tag.ToString() == id)
                {
                    TargetNode = treeNode.Nodes[i];
                    break;
                }
                FindTreeNode(treeNode.Nodes[i], id);
            }
        }
        #endregion

        #region public static bool TreeNodeCanMoveTo(TreeNode currentTreeNode, TreeNode targetTreeNode) 当前节点是否允许转移到目标节点
        /// <summary>
        /// 当前节点是否允许转移到目标节点
        /// </summary>
        /// <param name="currentTreeNode">当前节点</param>
        /// <param name="targetTreeNode">目标节点</param>
        /// <returns>允许</returns>
        public static bool TreeNodeCanMoveTo(TreeNode currentTreeNode, TreeNode targetTreeNode)
        {
            if (currentTreeNode != null)
            {
                // 当前节点不能移动到当前节点上
                if (currentTreeNode.Equals(targetTreeNode))
                {
                    return false;
                }
                // 当前节点的父节点也不用移动了
                //if (currentTreeNode.Parent == targetTreeNode)
                //{
                //    return false;
                //}

                // 季俊武 20110219 当前节点为顶级节点的也不用移动
                // 吉日嘎拉 20110319，顶级节点也能拖动才对
                // if (currentTreeNode.Parent == null)
                // {
                //    return false;
                // }
                // 有相同名字的，不能移动
                for (int i = 0; i < targetTreeNode.Nodes.Count; i++)
                {
                    if (currentTreeNode.Text.Equals(targetTreeNode.Nodes[i].Text))
                    {
                        return false;
                        // break;
                    }
                }
                // 当前节点不能移动到自己的子节点上去
                while (targetTreeNode.Parent != null)
                {
                    targetTreeNode = targetTreeNode.Parent;
                    if (currentTreeNode.Equals(targetTreeNode))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #region public static void LoadTreeNodes(DataTable dataTable, string fieldId, string fieldParentId, string fieldFullName, TreeView treeView, TreeNode treeNode, bool loadTree = true, int expandLevel = 0, string fieldToolTipText = null)
        /// <summary>
        /// 加载树型结构的主键
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="fieldId">主键</param>
        /// <param name="fieldParentId">上级字段</param>
        /// <param name="fieldFullName">全称</param>
        /// <param name="treeNode">当前树结点</param>
        /// <param name="userSettingExpand">是否按用户配置展开</param>
        /// <param name="checkEnabledNode">是否选中启用的节点</param>
        public static void LoadTreeNodes(DataTable dataTable, string fieldId, string fieldParentId, string fieldFullName, TreeView treeView, TreeNode treeNode, bool loadTree = true, int expandLevel = 1, string fieldToolTipText = null, int isloadTreeNum = 1, bool userSettingExpand = false, bool checkEnabledNode = false)
        {
            // 加入按用户配置展开功能 Pcsky
            // 不递归的情况下，实际上还是要递归一层比较好 张毅
            // 查找 ParentId 字段的值是否在 Id字段 里
            // 一般情况是简单的数据过滤，就没必要进行严格的检查了，进行了严格的检查，反而降低运行效率
            DataRow[] dataRows = null;
            if (treeNode.Tag == null)
            {
                if (dataTable.Columns[fieldId].DataType == typeof(int)
                    || (dataTable.Columns[fieldId].DataType == typeof(Int16))
                    || (dataTable.Columns[fieldId].DataType == typeof(Int32))
                    || (dataTable.Columns[fieldId].DataType == typeof(Int64))
                    || dataTable.Columns[fieldId].DataType == typeof(decimal))
                {
                    dataRows = dataTable.Select(fieldParentId + " IS NULL OR " + fieldParentId + " = 0");
                }
                else
                {
                    dataRows = dataTable.Select(fieldParentId + " IS NULL OR " + fieldParentId + " = ''");
                }
            }
            else
            {
                if (dataTable.Columns[fieldId].DataType == typeof(int)
                   || (dataTable.Columns[fieldId].DataType == typeof(Int16))
                   || (dataTable.Columns[fieldId].DataType == typeof(Int32))
                   || (dataTable.Columns[fieldId].DataType == typeof(Int64))
                   || dataTable.Columns[fieldId].DataType == typeof(decimal))
                {
                    dataRows = dataTable.Select(fieldParentId + "=" + (treeNode.Tag as DataRow)[fieldId].ToString() + "", dataTable.DefaultView.Sort);
                }
                else
                {
                    dataRows = dataTable.Select(fieldParentId + "='" + (treeNode.Tag as DataRow)[fieldId].ToString() + "'", dataTable.DefaultView.Sort);
                }
            }

            foreach (DataRow dataRow in dataRows)
            {
                // 判断不为空的当前节点的子节点
                if ((treeNode.Tag != null) && ((treeNode.Tag as DataRow)[fieldId] != null) && ((treeNode.Tag as DataRow)[fieldId].ToString().Length > 0) && (!(treeNode.Tag as DataRow)[fieldId].ToString().Equals(dataRow[fieldParentId].ToString())))
                {
                    continue;
                }

                // 当前节点的子节点, 加载根节点
                if (dataRow.IsNull(fieldParentId) || (dataRow[fieldParentId].ToString() == "0") || (dataRow[fieldParentId].ToString().Length == 0) || (((treeNode.Tag as DataRow)[fieldId] != null) || (treeNode.Tag != null) && (treeNode.Tag as DataRow)[fieldId].Equals(dataRow[fieldParentId].ToString())))
                {
                    TreeNode newTreeNode = new TreeNode();
                    newTreeNode.Text = dataRow[fieldFullName].ToString();
                    newTreeNode.Tag = dataRow;
                    if (!string.IsNullOrEmpty(fieldToolTipText))
                    {
                        newTreeNode.ToolTipText = dataRow[fieldToolTipText].ToString();
                    }
                    // 是否选中启用的节点 Pcsky
                    if (checkEnabledNode)
                    {
                        newTreeNode.Checked = ((newTreeNode.Tag as DataRow)["Enabled"].ToString().Equals("1"));
                    }

                    if ((treeNode.Tag == null) || ((treeNode.Tag as DataRow)[fieldId] == null) || ((treeNode.Tag as DataRow)[fieldId].ToString().Length == 0))
                    {
                        // 树的根节点加载
                        treeView.Nodes.Add(newTreeNode);

                        // 是否按用户配置展开 Pcsky
                        if (userSettingExpand)
                        {
                            if (((DataRow)newTreeNode.Tag)["Expand"].ToString() == "1")
                            {
                                newTreeNode.Expand();
                            }
                        }
                        else
                        {
                            if (expandLevel > newTreeNode.Level)
                            {
                                newTreeNode.Expand();
                            }
                        }
                    }
                    else
                    {
                        // 节点的子节点加载，第一层节点需要展开                        
                        treeNode.Nodes.Add(newTreeNode);
                        // 是否按用户配置展开 Pcsky
                        if (userSettingExpand)
                        {
                            if ((treeNode.Tag as DataRow)["Expand"].ToString() == "1")
                            {
                                treeNode.Expand();
                            }
                        }
                        else
                        {
                            if (expandLevel > treeNode.Level)
                            {
                                treeNode.Expand();
                            }
                        }
                    }
                    if (loadTree)
                    {
                        // 递归调用本函数
                        LoadTreeNodes(dataTable, fieldId, fieldParentId, fieldFullName, treeView, newTreeNode, loadTree, expandLevel, fieldToolTipText, 1, userSettingExpand, checkEnabledNode);
                    }
                    else if (isloadTreeNum == 1)
                    {
                        // 递归调用本函数
                        LoadTreeNodes(dataTable, fieldId, fieldParentId, fieldFullName, treeView, newTreeNode, loadTree, expandLevel, fieldToolTipText, 2, userSettingExpand, checkEnabledNode);
                    }
                }
            }
        }
        #endregion

        #region public static void LoadTreeNodes(DataTable dataTable, string fieldId, string fieldFullName, TreeView treeView, int expandLevel = 0, string fieldToolTipText = null) 构造一级树形结构
        /// <summary>
        /// 构造一级树形结构
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="fieldId">主键字段</param>
        /// <param name="fieldFullName">名称字段</param>
        /// <param name="treeView">树形控件</param>
        /// <param name="expandLevel">是否展开</param>
        /// <param name="fieldToolTipText">是否提示</param>
        public static void LoadTreeNodes(DataTable dataTable, string fieldId, string fieldFullName, TreeView treeView, int expandLevel = 0, string fieldToolTipText = null)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                TreeNode newTreeNode = new TreeNode();
                newTreeNode.Text = dataRow[fieldFullName].ToString();
                newTreeNode.Tag = dataRow[fieldId].ToString();
                if (!string.IsNullOrEmpty(fieldToolTipText))
                {
                    newTreeNode.ToolTipText = dataRow[fieldToolTipText].ToString();
                }
                if (expandLevel > newTreeNode.Level)
                {
                    newTreeNode.Expand();
                }
                treeView.Nodes.Add(newTreeNode);
            }
        }
        #endregion

        #region public static void AddTreeNode(TreeView treeView, TreeNode newNode, TreeNode parentNode) 添加一个节点，并使其可见
        /// <summary>
        /// 添加一个节点，并使其可见
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="newNode"></param>
        /// <param name="parentNode"></param>
        public static void AddTreeNode(TreeView treeView, TreeNode newNode, TreeNode parentNode)
        {
            if (parentNode != null)
            {
                parentNode.Nodes.Add(newNode);
                treeView.SelectedNode = parentNode;
                parentNode.Expand();
                // 让新添加节点可视 
            }
            else
            {
                treeView.Nodes.Add(newNode);
                treeView.SelectedNode = newNode;
                newNode.Expand();
            }
            newNode.EnsureVisible();
        }
        #endregion

        #region  public static void BatchRemoveNode(TreeView treeView,string[] tags) 批量删除树中的节点，并使父节点可见
        /// <summary>
        /// 批量删除树中的节点，并使父节点可见
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="tags"></param>
        public static void BatchRemoveNode(TreeView treeView, string[] tags)
        {
            TreeNode parentNode = null;
            for (int i = 0; i < tags.Length; i++)
            {
                BaseInterfaceLogic.FindTreeNode(treeView, tags[i]);
                TreeNode treeNode = BaseInterfaceLogic.TargetNode;
                // 2012.05.21 Pcsky加入判断，修正删除最后一个节点后报错(未将对象引用设置到对象的实例)的BUG
                if (treeNode != null)
                {
                    if (i == 0)
                    {
                        parentNode = treeNode.Parent;
                    }
                    treeNode.Remove();
                }
            }
            // 使删除节点的parentNode可见
            if (parentNode != null)
            {
                parentNode.Expand();
                treeView.SelectedNode = parentNode;
                parentNode.EnsureVisible();
            }
        }
        #endregion

        #region public static void MoveTreeNode(TreeView treeView, TreeNode newParentNode)添加一个节点，并使其可见
        /// <summary>
        /// 移动一个节点，并使其可见
        /// </summary>
        /// <param name="treeView"></param>
        /// <param name="text"></param>
        /// <param name="tag"></param>
        public static void MoveTreeNode(TreeView treeView, TreeNode selectNode, TreeNode parentNode)
        {
            TreeNode temNode = selectNode;

            // 2012.05.28 Pcsky加入判断，修正移动最底层叶节点报错(未将对象引用设置到对象的实例)的BUG
            if (selectNode != null)
            {
                // 先删除
                selectNode.Remove();
                if (parentNode != null)
                {
                    // 添加到新的父节点下
                    parentNode.Nodes.Add(temNode);
                    // 展开新的父节点，是新增节点可见
                    parentNode.Expand();
                    treeView.SelectedNode = parentNode;
                }
                else
                {
                    treeView.Nodes.Add(temNode);
                    temNode.Expand();
                    treeView.SelectedNode = temNode;
                }
                temNode.EnsureVisible();
            }
        }
        #endregion

        #region public static void EditTreeNode(TreeView treeView, TreeNode selectNode,TreeNode parentNode) 编辑节点
        /// <summary>
        /// 编辑节点
        /// </summary>
        /// <param name="parentId"></param>
        public static void EditTreeNode(TreeView treeView, TreeNode selectNode, TreeNode parentNode)
        {
            MoveTreeNode(treeView, selectNode, parentNode);
        }
        #endregion

        #region public static void CheckChild(TreeNode node) 递归检查子节点是否被选中
        /// <summary>
        /// 递归检查子节点是否被选中
        /// </summary>
        /// <param name="node"></param>
        public static void CheckChild(TreeNode node)
        {
            bool childNodeCheck = false;

            if (node.Nodes.Count != 0)
            {
                //如果节点下有已选子节点
                foreach (TreeNode item in node.Nodes)
                {
                    childNodeCheck = item.Checked;
                    if (childNodeCheck)
                        break;
                }

                //1、如果node下有子节点checked，展开或者收缩节点不影响子节点的选择
                //2、如果节点由checked 变为Uncheced  子节点也都 变成unchecked
                if (!childNodeCheck || !node.Checked)
                {
                    foreach (TreeNode item in node.Nodes)
                    {
                        item.Checked = node.Checked;
                        CheckChild(item);
                    }
                }
            }
        }
        #endregion

        #region public static void CheckChild(TreeNode node) 递归检查父节点是否被选中
        /// <summary>
        /// 递归检查父节点，如果父节点下有node是checked，则该父节点是checked
        /// </summary>
        /// <param name="node"></param>
        public static void CheckParent(TreeNode node)
        {
            bool childNodeCheck = false;
            if (node.Parent != null)
            {
                foreach (TreeNode item in node.Parent.Nodes)
                {
                    childNodeCheck = item.Checked;
                    if (childNodeCheck)
                        break;
                }
                node.Parent.Checked = childNodeCheck;
                CheckParent(node.Parent);
            }
        }
        #endregion

        #region public static string[] GetSelecteIds(DataTable dataTable, string fieldId, string fieldSelected) 获得已被选择的主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <param name="dataTable">目标表</param>
        /// <param name="fieldId">表主键字段</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>主键数组</returns>
        public static string[] GetSelecteIds(DataTable dataTable, string fieldId, string fieldSelected)
        {
            return GetSelecteIds(dataTable.DefaultView, fieldId, fieldSelected);
        }
        #endregion

        #region public static string[] GetSelecteIds(DataView dataView, string fieldId, string fieldSelected) 获得已被选择的主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <param name="DataView">目标表</param>
        /// <param name="fieldId">表主键字段</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>主键数组</returns>
        public static string[] GetSelecteIds(DataView dataView, string fieldId, string fieldSelected)
        {
            return GetSelecteIds(dataView, fieldId, fieldSelected, true);
        }
        #endregion

        #region public static string[] GetSelecteIds(DataTable dataTable, string fieldId, string fieldSelected) 获得已被选择的主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <param name="dataTable">目标表</param>
        /// <param name="fieldId">表主键字段</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>主键数组</returns>
        public static string[] GetUnSelecteIds(DataTable dataTable, string fieldId, string fieldSelected)
        {
            return GetUnSelecteIds(dataTable.DefaultView, fieldId, fieldSelected);
        }
        #endregion

        #region public static string[] GetUnSelecteIds(DataView dataView, string fieldId, string fieldSelected) 获得已被选择的主键数组
        /// <summary>
        /// 获得已被选择的主键数组
        /// </summary>
        /// <param name="DataView">目标表</param>
        /// <param name="fieldId">表主键字段</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>主键数组</returns>
        public static string[] GetUnSelecteIds(DataView dataView, string fieldId, string fieldSelected)
        {
            return GetSelecteIds(dataView, fieldId, fieldSelected, false);
        }
        #endregion

        public static string[] GetSelecteIds(DataView dataView, string fieldId, string fieldSelected, bool selected)
        {
            string[] ids = new string[0];
            string Ids = string.Empty;
            foreach (DataRowView dataRowView in dataView)
            {
                if (dataRowView.Row.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (dataRowView.Row[fieldSelected].ToString().ToUpper().Equals(selected.ToString().ToUpper()))
                {
                    string id = dataRowView.Row[fieldId].ToString();
                    if (id.Length > 0)
                    {
                        Ids += id + ",";
                    }
                }
            }
            // 分离Id
            if (Ids.Length > 1)
            {
                Ids = Ids.TrimEnd(',');
                ids = Ids.Split(',');
            }
            return ids;
        }

        #region public static string[] GetSelecteIds(DataGridView dgView, string fieldId, string fieldSelected, bool selected) 获得已被选择的主键数组
        /// <summary>
        /// 获得(已/未)被选择的主键数组
        /// </summary>
        /// <param name="dgView">目标视图</param>
        /// <param name="fieldId">表主键字段</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <param name="selected">(已/未)被选择</param>
        /// <returns>主键数组</returns>
        public static string[] GetSelecteIds(DataGridView dgView, string fieldId, string fieldSelected, bool selected)
        {
            string[] ids = new string[0];
            string Ids = string.Empty;
            foreach (DataGridViewRow dgvRow in dgView.Rows)
            {
                DataRowView dataRowView = dgvRow.DataBoundItem as DataRowView;
                if (dataRowView.Row.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (((System.Boolean)(dgvRow.Cells[fieldSelected].Value ?? false)) == selected)
                {
                    string id = dataRowView.Row[fieldId].ToString();
                    if (id.Length > 0)
                    {
                        Ids += id + ",";
                    }
                }
            }
            // 分离Id
            Ids = Ids.TrimEnd(',');
            ids = Ids.Split(',');
            return ids;
        }
        #endregion

        #region public static DataRow GetSelecteRow(DataTable dataTable, string fieldSelected) 获得已被选择的数据行
        /// <summary>
        /// 获得已被选择的数据行
        /// </summary>
        /// <param name="dataTable">目标表</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>主键数组</returns>
        public static DataRow GetSelecteRow(DataTable dataTable, string fieldSelected)
        {
            return GetSelecteRow(dataTable.DefaultView, fieldSelected);
        }
        #endregion

        #region public static DataRow GetSelecteRow(DataView dataView, string fieldSelected) 获得已被选择的数据行
        /// <summary>
        /// 获得已被选择的数据行
        /// </summary>
        /// <param name="DataView">目标表</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>主键数组</returns>
        public static DataRow GetSelecteRow(DataView dataView, string fieldSelected)
        {
            DataRow returnValue = null;
            foreach (DataRowView dataRowView in dataView)
            {
                if (dataRowView.Row.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (dataRowView.Row[fieldSelected].ToString().ToUpper().Equals(true.ToString().ToUpper()))
                {
                    returnValue = dataRowView.Row;
                }
            }
            return returnValue;
        }
        #endregion

        #region public static DataRow GetSelecteRow(DataGridView dgView, string fieldSelected) 获得已被选择的数据行
        /// <summary>
        /// 获得已被选择的数据行
        /// </summary>
        /// <param name="dgView">目标表</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>主键数组</returns>
        public static DataRow GetSelecteRow(DataGridView dgView, string fieldSelected)
        {
            DataRow returnValue = null;
            foreach (DataGridViewRow dgvRow in dgView.Rows)
            {
                DataRow dataRow = (dgvRow.DataBoundItem as DataRowView).Row;
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if ((System.Boolean)(dgvRow.Cells[fieldSelected].Value ?? false))
                {
                    returnValue = dataRow;
                }
            }
            return returnValue;
        }
        #endregion


        public static bool IsModfiedAnyOne(DataTable dataTable)
        {
            return IsModfiedAnyOne(dataTable, false);
        }

        #region public static bool IsModfiedAnyOne(DataTable dataTable, bool containSelectedColumn) 当前数据是否被修改过
        /// <summary>
        /// 当前数据是否被修改过
        /// </summary>
        /// <param name="dataTable">目标表</param>
        /// <param name="containSelectedColumn">含选择列</param>
        /// <returns>是否有修改</returns>
        public static bool IsModfiedAnyOne(DataTable dataTable, bool containSelectedColumn)
        {
            bool returnValue = false;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                if (dataRow.RowState == DataRowState.Modified)
                {
                    for (int i = 0; i < dataTable.Columns.Count; i++)
                    {
                        // 含选择列
                        if (containSelectedColumn || (dataTable.Columns[i].ColumnName.ToUpper() != "colSelected".ToUpper()))
                        {
                            if (dataRow[i].ToString() != dataRow[i, DataRowVersion.Original].ToString())
                            {
                                returnValue = true;
                                break;
                            }
                        }
                    }
                }
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    returnValue = true;
                    break;
                }
                if (dataRow.RowState == DataRowState.Added)
                {
                    returnValue = true;
                    break;
                }
            }
            return returnValue;
        }
        #endregion

        #region public static bool CheckInputSelectOne(DataTable dataTable) 检查是否选择了任何一条记录
        /// <summary>
        /// 检查是否选择了一条记录
        /// </summary>
        /// <param name="dataTable">目标表</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>是否有选中的记录</returns>
        public static bool CheckInputSelectOne(DataTable dataTable)
        {
            return CheckInputSelectOne(dataTable, "colSelected");
        }
        #endregion

        /// <summary>
        /// 检查是否选择了一条记录
        /// </summary>
        /// <param name="dataTable">目标表</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>是否有选中的记录</returns>
        public static bool CheckInputSelectOne(DataTable dataTable, string fieldSelected)
        {
            bool returnValue = true;
            int selectRowCount = 0;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                //    if (dataRow[fieldSelected].ToString() == true.ToString())
                //    {
                //        selectRowCount++;
                //    }
                if (selectRowCount > 20)
                {
                    break;
                }
            }
            if (selectRowCount == 0)
            {
                MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                returnValue = false;
            }
            if (selectRowCount > 1)
            {
                MessageBox.Show(AppMessage.MSGC024, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                returnValue = false;
            }
            return returnValue;
        }

        #region public static bool CheckInputSelectOne(DataGridView dgView, string fieldSelected) 检查是否选择了任何一条记录
        /// <summary>
        /// 检查是否选择了一条记录
        /// </summary>
        /// <param name="dgView">目标视图</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>是否有选中的记录</returns>
        public static bool CheckInputSelectOne(DataGridView dgView, string fieldSelected)
        {
            bool returnValue = true;
            int selectRowCount = 0;
            foreach (DataGridViewRow dgvRow in dgView.Rows)
            {
                if ((System.Boolean)(dgvRow.Cells[fieldSelected].Value ?? false))
                {
                    selectRowCount++;
                }
                if (selectRowCount > 1)
                {
                    break;
                }
            }
            if (selectRowCount == 0)
            {
                MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                returnValue = false;
            }
            if (selectRowCount > 1)
            {
                MessageBox.Show(AppMessage.MSGC024, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        #region public static bool CheckInputSelectOne(DataGridView dgView, string fieldSelected,bool showMessage) 检查是否选择了任何一条记录
        /// <summary>
        /// 检查是否选择了一条记录
        /// </summary>
        /// <param name="dgView">目标视图</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <param name="showMessage">是否显示提示信息</param>
        /// <param name="OtherError">其他错误</param>
        /// <returns>是否有选中的记录</returns>
        public static bool CheckInputSelectOne(DataGridView dgView, string fieldSelected, bool showMessage, out bool otherError)
        {
            otherError = false;
            bool returnValue = true;
            int selectRowCount = 0;
            foreach (DataGridViewRow dgvRow in dgView.Rows)
            {
                if ((System.Boolean)(dgvRow.Cells[fieldSelected].Value ?? false))
                {
                    selectRowCount++;
                }
                if (selectRowCount > 1)
                {
                    break;
                }
            }
            if (selectRowCount == 0)
            {
                if (showMessage)
                {
                    MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                returnValue = false;
            }
            if (selectRowCount > 1)
            {
                //if (showMessage)
                //{
                MessageBox.Show(AppMessage.MSGC024, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                otherError = true;
                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        #region public static bool CheckInputSelectOne(DataGridView dgView, string fieldSelected,bool showMessage) 检查是否选择了任何一条记录
        /// <summary>
        /// 检查是否选择了一条记录
        /// </summary>
        /// <param name="dgView">目标视图</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <param name="showMessage">是否显示提示信息</param>
        /// <param name="OtherError">其他错误</param>
        /// <returns>是否有选中的记录</returns>
        public static bool CheckInputSelectOne(DataGridView dgView, string fieldSelected, bool showMessage)
        {
            bool returnValue = true;
            int selectRowCount = 0;
            foreach (DataGridViewRow dgvRow in dgView.Rows)
            {
                if ((System.Boolean)(dgvRow.Cells[fieldSelected].Value ?? false))
                {
                    selectRowCount++;
                }
                if (selectRowCount > 1)
                {
                    break;
                }
            }
            if (selectRowCount == 0)
            {
                if (showMessage)
                {
                    MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                returnValue = false;
            }
            if (selectRowCount > 1)
            {
                if (showMessage)
                {
                    MessageBox.Show(AppMessage.MSGC024, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                returnValue = false;
            }
            return returnValue;
        }
        #endregion

        #region public static bool CheckInputSelectAnyOne(DataTable dataTable, string fieldSelected) 检查是否选择了任何一条记录
        /// <summary>
        /// 检查是否选择了任何一条记录
        /// </summary>
        /// <param name="dataTable">目标表</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>是否有选中的记录</returns>
        public static bool CheckInputSelectAnyOne(DataTable dataTable, string fieldSelected)
        {
            return CheckInputSelectAnyOne(dataTable.DefaultView, fieldSelected);
        }
        #endregion

        #region public static bool CheckInputSelectAnyOne(DataView dataView, string fieldSelected) 检查是否选择了任何一条记录
        /// <summary>
        /// 检查是否选择了任何一条记录
        /// </summary>
        /// <param name="DataView">目标表</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>是否有选中的记录</returns>
        public static bool CheckInputSelectAnyOne(DataView dataView, string fieldSelected)
        {
            bool returnValue = false;
            foreach (DataRowView dataRowView in dataView)
            {
                if (dataRowView.Row[fieldSelected].ToString().ToUpper().Equals(true.ToString().ToUpper()))
                {
                    returnValue = true;
                    break;
                }
            }
            if (!returnValue)
            {
                MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        #region public static bool CheckInputSelectAnyOne(DataGridView dgView, string fieldSelected) 检查是否选择了任何一条记录
        /// <summary>
        /// 检查是否选择了任何一条记录
        /// </summary>
        /// <param name="dgView">目标表</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>是否有选中的记录</returns>
        public static bool CheckInputSelectAnyOne(DataGridView dgView, string fieldSelected)
        {
            bool returnValue = false;
            foreach (DataGridViewRow dgvRow in dgView.Rows)
            {
                if ((System.Boolean)(dgvRow.Cells[fieldSelected].Value ?? false))
                {
                    returnValue = true;
                    break;
                }
            }
            if (!returnValue)
            {
                MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        #region public static bool CheckInputSelectAnyOne(DataGridView dgView, string fieldSelected) 检查是否选择了任何一条记录
        /// <summary>
        /// 检查是否选择了任何一条记录
        /// </summary>
        /// <param name="dgView">目标表</param>
        /// <param name="fieldSelected">当前被选中的字段</param>
        /// <returns>是否有选中的记录</returns>
        public static bool CheckInputSelectAnyOne(DataGridView dgView, string fieldSelected, bool showMessage)
        {
            bool returnValue = false;
            foreach (DataGridViewRow dgvRow in dgView.Rows)
            {
                if ((System.Boolean)(dgvRow.Cells[fieldSelected].Value ?? false))
                {
                    returnValue = true;
                    break;
                }
            }
            if (!returnValue)
            {
                if (showMessage)
                {
                    MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return returnValue;
        }
        #endregion


        #region public static bool CheckInputModifyAnyOne(DataTable dataTable) 检查是否有数据变动
        /// <summary>
        /// 检查是否有数据变动
        /// </summary>
        /// <param name="dataTable">目标表</param>
        /// <returns>有变动</returns>
        public static bool CheckInputModifyAnyOne(DataTable dataTable)
        {
            bool returnValue = false;
            returnValue = IsModfiedAnyOne(dataTable);
            if (!returnValue)
            {
                MessageBox.Show(AppMessage.MSG0004, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return returnValue;
        }
        #endregion

        #region public static int GetRowIndex(DataTable dataTable, string fieldId, string id) 查找主键在视图中的位置
        /// <summary>
        /// 查找主键在视图中的位置
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="fieldId">主键字段</param>
        /// <param name="id">主键</param>
        /// <returns>位置</returns>
        public static int GetRowIndex(DataTable dataTable, string fieldId, string id)
        {
            int returnValue = 0;
            bool finded = false;
            foreach (DataRowView dataRowView in dataTable.DefaultView)
            {
                if (dataRowView[fieldId].ToString() == id)
                {
                    finded = true;
                    break;
                }
                returnValue++;
            }
            if (!finded)
            {
                returnValue = 0;
            }
            return returnValue;
        }
        #endregion

        #region public static void DataTableAddColumn(DataTable dataTable, string fieldName) 往 DataTable 里面添加一列
        /// <summary>
        /// 往 DataTable 里面添加一列
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="fieldName">字段名</param>
        public static void DataTableAddColumn(DataTable dataTable, string fieldName)
        {
            DataTableAddColumn(dataTable, fieldName, typeof(System.Boolean));
        }
        #endregion

        #region public static void DataTableAddColumn(DataTable dataTable, string fieldName) 往 DataTable 里面添加一列
        /// <summary>
        /// 往 DataTable 里面添加一列
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="fieldName">字段名</param>
        /// <param name="dataType">数据类型</param>
        public static void DataTableAddColumn(DataTable dataTable, string fieldName, Type dataType)
        {
            if (dataTable != null)
            {
                if (!dataTable.Columns.Contains(fieldName))
                {
                    DataColumn DataColumn = new DataColumn(fieldName, dataType);
                    DataColumn.DefaultValue = false;
                    DataColumn.AllowDBNull = false;
                    dataTable.Columns.Add(DataColumn);
                }
            }
        }
        #endregion

        #region public static void CheckTreeParentId(DataTable dataTable, string fieldId, string fieldParentId)
        /// <summary>
        /// 查找 ParentId 字段的值是否在 Id字段 里
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <param name="fieldId">主键字段</param>
        /// <param name="fieldParentId">父节点字段</param>
        public static void CheckTreeParentId(DataTable dataTable, string fieldId, string fieldParentId)
        {
            for (int i = dataTable.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dataRow = dataTable.Rows[i];
                // if (dataTable.Columns[fieldId].GetType() == typeof(int))
                if (dataRow[fieldParentId].ToString().Length > 0)
                {
                    if (dataTable.Select(fieldId + " = " + dataRow[fieldParentId].ToString() + "").Length == 0)
                    {
                        dataRow[fieldParentId] = DBNull.Value;
                    }
                }
            }
        }
        #endregion

        public static Form GetForm(string assemblyName, string formName)
        {
            Assembly assembly = Assembly.Load(assemblyName);
            Type type = assembly.GetType(assemblyName + "." + formName, true, false);
            return (Form)Activator.CreateInstance(type);
        }

        public static Form ShowForm(string assemblyName, string formName)
        {
            Form form = GetForm(assemblyName, formName);
            form.Show();
            return form;
        }
    }
}