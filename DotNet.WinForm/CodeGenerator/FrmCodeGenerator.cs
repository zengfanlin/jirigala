//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace DotNet.WinForm
{
    using DotNet.Utilities;

    /// <summary>
    ///	FrmCodeGenerator
    /// 主键生成器
    /// 
    /// 修改纪录
    ///
    ///     2011.10.25 版本：3.6    吉日嘎拉 改进数据权限部分。
    ///     2011.10.01 版本：2.5    吉日嘎拉 生成文件路径，自动复制到相应的目录里。
    ///     2011.04.25 版本：2.4    吉日嘎拉 Manager层代码生成功能实现。
    ///     2011.04.14 版本：2.3    吉日嘎拉 增加生成Pdm 数据字典 文档的功能。
    ///     2010.12.13 版本：2.2    吉日嘎拉 多语言能被记录功能实现。
    ///     2010.11.12 版本：2.1    吉日嘎拉 修改窗体继承（Form-->BaseForm)为了添加语言包引用。
    ///		2010.09.13 版本：2.0	棋圣     QQ:32054605 改进代码显示部分功能。
    ///		2009.12.05 版本：1.6	吉日嘎拉 排序码可以取消、字段的注释优化。
    ///		2009.12.02 版本：1.5	吉日嘎拉 公司名称可以为空。
    ///		2009.12.02 版本：1.4	吉日嘎拉 生成文件的文件名优化。
    ///		2009.09.30 版本：1.3	吉日嘎拉 增加设计文件是否存在的检查判断功能。
    ///		2009.06.12 版本：1.2	吉日嘎拉 英文提示信息改进。
    ///		2008.07.29 版本：1.1	吉日嘎拉 整理。
    ///		2008.07.25 版本：1.0    吉日嘎拉 整理。
    ///	
    /// 版本：2.5
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.10.01</date>
    /// </author> 
    /// </summary>
    public partial class FrmCodeGenerator : BaseForm
    {
        public FrmCodeGenerator()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName
        {
            get
            {
                if (string.IsNullOrEmpty(this.txtProject.Text))
                {
                    this.txtProject.Text = "DotNet";
                }
                return this.txtProject.Text;
            }
            set
            {
                this.txtProject.Text = value;
            }
        }

        /// <summary>
        /// 设计文档
        /// </summary>
        private XmlDocument xmlDocument = new XmlDocument();

        #region private SettingHelper GetSetting() 读取配置文件
        /// <summary>
        /// 读取配置文件
        /// </summary>
        private SettingHelper GetSetting()
        {
            SettingHelper settingHelper = new SettingHelper();
            settingHelper.GetSetting();
            this.txtCompany.Text = settingHelper.Company;
            this.ProjectName = settingHelper.Project;
            this.txtAuthor.Text = settingHelper.Author;
            this.txtDesign.Text = settingHelper.Design;
            this.txtOutput.Text = settingHelper.Output;
            this.chkOverwrite.Checked = settingHelper.Overwrite;

            this.CurrentDb = settingHelper.CurrentDb;

            // 检查文件是否存在，可能文件被删除了或者移动了，重新命名了之类的。
            if (!String.IsNullOrEmpty(this.txtDesign.Text) && (!File.Exists(this.txtDesign.Text)))
            {
                this.txtDesign.Text = string.Empty;
            }
            if (!String.IsNullOrEmpty(this.txtDesign.Text) && !Directory.Exists(this.txtOutput.Text))
            {
                this.txtOutput.Text = string.Empty;
            }
            if (String.IsNullOrEmpty(this.txtCompany.Text))
            {
                this.txtCompany.Text = "Hairihan";
            }
            if (String.IsNullOrEmpty(this.txtAuthor.Text))
            {
                this.txtAuthor.Text = "JiRiGaLa";
            }
            return settingHelper;
        }
        #endregion

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            this.btnCopyCode.Enabled = false;
            this.btnSaveCode.Enabled = false;

            if (this.txtDesign.Text.Length > 0)
            {
                this.btnDesign.Enabled = false;
                this.btnClearDesign.Enabled = true;
            }
            else
            {
                this.btnDesign.Enabled = true;
                this.btnClearDesign.Enabled = false;
            }
            if (this.txtOutput.Text.Length > 0)
            {
                this.btnOutput.Enabled = false;
                this.btnClearOutput.Enabled = true;
            }
            else
            {
                this.btnOutput.Enabled = true;
                this.btnClearOutput.Enabled = false;
            }

            if (this.lbxTables.Items.Count > 0)
            {
                this.btnBuilderEntity.Enabled = true;
                this.btnBuilderTable.Enabled = true;
                this.btnBuilderManager.Enabled = true;
                this.btnService.Enabled = true;
                this.btnIService.Enabled = true;
                this.btnTableColumns.Enabled = true;
                // 有输出路径了，那就可以生成主键了
                if (!String.IsNullOrEmpty(this.txtOutput.Text))
                {
                    this.btnBuilder.Enabled = true;
                    this.btnBuilderAll.Enabled = true;
                    this.btnPdmDD.Enabled = true;
                }
                else
                {
                    this.btnBuilder.Enabled = false;
                    this.btnBuilderAll.Enabled = false;
                    this.btnPdmDD.Enabled = false;
                }
            }
            else
            {
                this.btnBuilderEntity.Enabled = false;
                this.btnBuilderTable.Enabled = false;
                this.btnBuilderManager.Enabled = false;
                this.btnService.Enabled = false;
                this.btnIService.Enabled = false;
                this.btnTableColumns.Enabled = false;
                this.btnBuilder.Enabled = false;
                this.btnBuilderAll.Enabled = false;
                this.btnPdmDD.Enabled = false;
            }

            if (!string.IsNullOrEmpty(this.txtCode.txtContent.Text))
            {
                this.btnCopyCode.Enabled = true;
                this.btnSaveCode.Enabled = true;
            }
        }
        #endregion

        #region public override void SetControlState(bool enabled) 设置按钮状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        /// <param name="enabled">有效</param>
        public override void SetControlState(bool enabled)
        {
            this.btnDesign.Enabled = enabled;
            this.btnBuilderTable.Enabled = enabled;
            this.btnBuilderEntity.Enabled = enabled;
            this.btnBuilderManager.Enabled = enabled;
            this.btnCopyCode.Enabled = enabled;
            this.btnSaveCode.Enabled = enabled;
            this.btnBuilder.Enabled = enabled;
            this.btnBuilderAll.Enabled = enabled;
            this.btnPdmDD.Enabled = enabled;
        }
        #endregion

        public override void FormOnLoad()
        {
            this.txtYearCreated.Text = System.DateTime.Now.ToString("yyyy");
            this.txtDateCreated.Text = System.DateTime.Now.ToString("yyyy-MM-dd");

            // 先设置默认值
            if (this.txtAuthor.Text.Length == 0)
            {
                this.txtAuthor.Text = System.Environment.UserName;
                // this.txtAuthor.Text = System.Environment.MachineName;
                // this.txtAuthor.Text = System.Net.Dns.GetHostName();
            }
            if (this.txtCompany.Text.Length == 0)
            {
                try
                {
                    Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("Software");
                    registryKey = registryKey.OpenSubKey("Microsoft");
                    registryKey = registryKey.OpenSubKey("Windows NT");
                    registryKey = registryKey.OpenSubKey("CurrentVersion");
                    object company = registryKey.GetValue("RegisteredOrganization");
                    // object author = myRegistryKey.GetValue("RegisteredOwner");
                    this.txtCompany.Text = company.ToString();
                }
                catch
                {
                }
            }

            // 设置默认语言被选中状态
            this.SetCurrentLanguage();

            // 之后再读取配置文件，公司名称可以为空
            this.GetSetting();

            // 读取设计文件
            if (this.txtDesign.Text.Length > 0)
            {
                this.GetDesignTables();
            }
        }

        /// <summary>
        /// 设置默认语言被选中状态
        /// </summary>
        private void SetCurrentLanguage()
        {
            this.rbzhCN.Checked = this.rbzhCN.Tag.ToString().Equals(BaseSystemInfo.CurrentLanguage);
            this.rbzhTW.Checked = this.rbzhTW.Tag.ToString().Equals(BaseSystemInfo.CurrentLanguage);
            this.rbenUS.Checked = this.rbenUS.Tag.ToString().Equals(BaseSystemInfo.CurrentLanguage);
        }

        private void rbCurrentLanguage_CheckedChanged(object sender, EventArgs e)
        {
            // 要确认是用户点击发生的实践，不是默认加载时发生的事件
            if (this.FormLoaded)
            {
                // 设置当前语言选项
                BaseSystemInfo.CurrentLanguage = ((RadioButton)sender).Tag.ToString();
                this.Localization(this);
                // 保存用户的信息
                UserConfigHelper.SaveConfig();
            }
        }

        #region private string GetClassName() 获取类名
        /// <summary>
        /// 获取类名
        /// </summary>
        /// <returns>类名</returns>
        private string GetClassName()
        {
            string className = string.Empty;
            if (this.lbxTables.SelectedItem != null)
            {
                className = this.lbxTables.SelectedItem.ToString().Split(',')[0];
                className = className.Replace("_", string.Empty);
                if ((!string.IsNullOrEmpty(className)) && (!string.IsNullOrEmpty(this.txtProject.Text)))
                {
                    className = className.Replace(this.ProjectName, string.Empty);
                }
            }
            return className;
        }
        #endregion

        #region private string GetTableName() 获取表明
        /// <summary>
        /// 获取表名
        /// </summary>
        /// <returns>表名</returns>
        private string GetTableName()
        {
            string tableName = string.Empty;
            if (this.lbxTables.SelectedItem != null)
            {
                tableName = this.lbxTables.SelectedItem.ToString().Split(',')[0];
            }
            return tableName;
        }
        #endregion

        #region private string GetDescription() 获取类描述
        /// <summary>
        /// 获取类描述
        /// </summary>
        /// <returns>类描述</returns>
        private string GetDescription()
        {
            string description = string.Empty;
            if (this.lbxTables.SelectedItem != null)
            {
                description = this.lbxTables.SelectedItem.ToString().Split(',')[1];
            }
            return description;
        }
        #endregion

        #region private string[] GetDesignTables(string fileName) 获取设计的数据表名集合
        /// <summary>
        /// 获取设计的数据表名集合
        /// </summary>
        /// <param name="fileName">文件名</param>
        /// <returns>数据表名集合</returns>
        private string[] GetDesignTables(string fileName)
        {
            // 判断文件是否存在
            if (!System.IO.File.Exists(fileName))
            {
                MessageBox.Show(this, AppMessage.MSG0244, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            // 设置文件共享方式为读写，FileShare.ReadWrite，这样的话，就可以打开了
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            // 如果直接打开是以只读共享的方式打开的，
            // 但若此文件已被一个拥有写权限的进程打开的话，就无法读取了
            // 
            // 解决方法：使用文件流方式打开，设置文件共享方式为读写，FileShare.ReadWrite
            this.xmlDocument.Load(fileStream);

            XmlNamespaceManager nsmgr = new XmlNamespaceManager(xmlDocument.NameTable);
            nsmgr.AddNamespace("a", "attribute");
            nsmgr.AddNamespace("c", "collection");
            nsmgr.AddNamespace("o", "object");

            // 获取表格
            //string selectPath = "/Model/*[local-name()='RootObject' and namespace-uri()='object'][1]/*[local-name()='Children' and namespace-uri()='collection'][1]/*[local-name()='Model' and namespace-uri()='object'][1]/*[local-name()='Tables' and namespace-uri()='collection'][1]";

            var tableList = xmlDocument.SelectNodes("/descendant::c:Tables/o:Table", nsmgr);
            string tableNames = string.Empty;
            foreach (XmlNode table in tableList)
            {
                //XmlNodeList xmlNodeList = xmlDocument.SelectSingleNode("/descendant::*/c:Tables", nsmgr).ChildNodes; //xmlDocument.SelectSingleNode(selectPath).ChildNodes;
                tableNames += table.ChildNodes[2].InnerText + "," + table.ChildNodes[1].InnerText + ";";
            }

            if (tableNames.Length > 0)
            {
                tableNames = tableNames.Substring(0, tableNames.Length - 1);
            }
            return tableNames.Split(';');
        }
        #endregion

        #region private int GetDesignTables() 获取设计的数据表
        /// <summary>
        /// 获取设计的数据表
        /// </summary>
        /// <returns>数据表个数</returns>
        private int GetDesignTables()
        {
            if (!String.IsNullOrEmpty(this.txtDesign.Text))
            {
                this.lbxTables.DataSource = this.GetDesignTables(this.txtDesign.Text);
            }
            return this.lbxTables.Items.Count;
        }
        #endregion

        #region private string OpenDesignFile() 打开设计文件
        /// <summary>
        /// 打开设计文件
        /// </summary>
        /// <returns>文件名称</returns>
        private string OpenDesignFile()
        {
            string fileName = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "设计文档(*.pdm)|*.pdm|所有文件|*.*";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "选择数据库模型设计文档";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                this.txtDesign.Text = fileName;
            }
            return fileName;
        }
        #endregion

        private void btnDesign_Click(object sender, EventArgs e)
        {
            this.OpenDesignFile();
            if (this.txtDesign.Text.Length > 0)
            {
                this.GetDesignTables();
            }
            // 设置按钮状态
            this.SetControlState();
        }

        private void btnClearDesign_Click(object sender, EventArgs e)
        {
            this.txtDesign.Text = string.Empty;
            this.lbxTables.DataSource = null;
            this.lbxTables.Items.Clear();
            this.txtCode.txtContent.Text = string.Empty;
            // 设置按钮状态
            this.SetControlState();
        }

        #region private string SettingOutput() 设置输出路径
        /// <summary>
        /// 设置输出路径
        /// </summary>
        /// <returns>输出路径</returns>
        private string SettingOutput()
        {
            string returnValue = string.Empty;
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "选择程序保存路径：";
            if (System.IO.Directory.Exists(this.txtOutput.Text))
            {
                folderBrowserDialog.SelectedPath = this.txtOutput.Text;
            }
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                returnValue = folderBrowserDialog.SelectedPath;
                this.txtOutput.Text = returnValue;
            }
            return returnValue;
        }
        #endregion

        private void btnOutput_Click(object sender, EventArgs e)
        {
            this.SettingOutput();
            // 设置按钮状态
            this.SetControlState();
        }

        private void btnClearOutput_Click(object sender, EventArgs e)
        {
            this.txtOutput.Text = string.Empty;
            // 设置按钮状态
            this.SetControlState();
        }

        private void lbxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtClassName.Text = this.GetClassName();
            this.txtFileName.Text = this.GetClassName();
        }

        private void btnBuilderTable_Click(object sender, EventArgs e)
        {
            this.SetControlState(false);
            this.txtCode.txtContent.Text = string.Empty;
            this.txtClassName.Text = this.GetClassName();
            this.txtFileName.Text = this.txtClassName.Text + "Table";

            CodeGenerator codeGenerator = new CodeGenerator(this.xmlDocument, this.txtCompany.Text, this.ProjectName, this.txtAuthor.Text, this.txtYearCreated.Text, this.txtDateCreated.Text, this.GetClassName(), "Table", this.GetTableName(), this.GetDescription());

            this.txtCode.SettxtContent("c#", codeGenerator.BuilderTable());

            this.txtClassName.Text += "Table";
            this.btnCopyCode.Enabled = true;
            this.btnSaveCode.Enabled = true;
            this.SetControlState();
            this.txtClassName.Focus();
            this.txtClassName.SelectAll();
        }

        private void btnBuilderEntity_Click(object sender, EventArgs e)
        {
            this.SetControlState(false);
            this.txtCode.txtContent.Text = string.Empty;
            this.txtClassName.Text = this.GetClassName();
            CodeGenerator codeGenerator = new CodeGenerator(this.xmlDocument, this.txtCompany.Text, this.ProjectName, this.txtAuthor.Text, this.txtYearCreated.Text, this.txtDateCreated.Text, this.GetClassName(), "Entity", this.GetTableName(), this.GetDescription());

            this.txtCode.SettxtContent("c#", codeGenerator.BuilderEntity());

            this.txtClassName.Text += "Entity";
            this.txtFileName.Text = this.txtClassName.Text;

            this.btnCopyCode.Enabled = true;
            this.btnSaveCode.Enabled = true;
            this.SetControlState();
            this.txtClassName.Focus();
            this.txtClassName.SelectAll();
        }

        private string CurrentDb
        {
            get
            {
                string returnValue = string.Empty;
                if (rbtnUserCenter.Checked)
                {
                    returnValue = "UserCenterDb";
                }
                if (rbtnWorkFlow.Checked)
                {
                    returnValue = "WorkFlowDb";
                }
                return returnValue;
            }
            set
            {
                if (value.Equals("WorkFlowDb"))
                {
                    rbtnWorkFlow.Checked = true;
                }
                else if (value.Equals("UserCenterDb"))
                {
                    rbtnUserCenter.Checked = true;
                }
                else
                {
                    this.rbtnBusiness.Checked = true;
                }
            }
        }

        private void btnBuilderManager_Click(object sender, EventArgs e)
        {
            this.SetControlState(false);
            this.txtCode.txtContent.Text = string.Empty;
            this.txtClassName.Text = this.GetClassName();

            CodeGenerator codeGenerator = new CodeGenerator(this.xmlDocument, this.txtCompany.Text, this.ProjectName, this.txtAuthor.Text, this.txtYearCreated.Text, this.txtDateCreated.Text, this.GetClassName(), "Manager", this.GetTableName(), this.GetDescription());
            this.txtCode.SettxtContent("c#", codeGenerator.BuilderManager(this.CurrentDb));

            this.txtClassName.Text += "Manager";
            this.txtFileName.Text = this.txtClassName.Text + ".Auto";

            this.btnCopyCode.Enabled = true;
            this.btnSaveCode.Enabled = true;
            this.SetControlState();
            this.txtClassName.Focus();
            this.txtClassName.SelectAll();
        }

        public bool BuilderService(string outputDirectory, bool overwrite)
        {
            string fileName = outputDirectory + "\\" + this.ProjectName + ".Business\\" + this.ProjectName + ".Service\\" + this.txtClassName.Text + "Service.cs";
            string code = this.BuilderService();
            return CodeGenerator.WriteCode(fileName, overwrite, code);
        }

        private string BuilderService()
        {
            string file = Application.StartupPath + "\\CodeGenerator\\Templates\\Service.txt";
            string code = GetTemplate(file);
            code = ReplaceAssemblyInfo(code);
            return code;
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            this.SetControlState(false);
            this.txtCode.txtContent.Text = string.Empty;
            this.txtClassName.Text = this.GetClassName();

            string file = Application.StartupPath + "\\CodeGenerator\\Templates\\Service.txt";
            string code = GetTemplate(file);
            code = ReplaceAssemblyInfo(code);
            this.txtCode.SettxtContent("c#", code);

            this.txtClassName.Text = this.txtClassName.Text + "Service";
            this.txtFileName.Text = this.txtClassName.Text;

            this.btnCopyCode.Enabled = true;
            this.btnSaveCode.Enabled = true;
            this.SetControlState();
            this.txtClassName.Focus();
            this.txtClassName.SelectAll();
        }

        private string GetTemplate(string file)
        {
            string code = string.Empty;
            FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            using (StreamReader streamReader = new StreamReader(fileStream, Encoding.Default))
            {
                code = streamReader.ReadToEnd();
            }
            return code;
        }

        private string ReplaceAssemblyInfo(string code)
        {
            code = code.Replace("#Author#", this.txtAuthor.Text);
            code = code.Replace("#ClassName#", this.txtClassName.Text);
            code = code.Replace("#Code#", this.txtCode.Text);
            code = code.Replace("#Company#", this.txtCompany.Text);
            code = code.Replace("#DateCreated#", this.txtDateCreated.Text);
            code = code.Replace("#Project#", this.txtProject.Text);
            code = code.Replace("#YearCreated#", this.txtYearCreated.Text);
            code = code.Replace("#Title#", this.GetDescription());
            code = code.Replace("#Description#", this.GetDescription());
            return code;
        }

        public bool BuilderManager(string outputDirectory, bool overwrite, bool twoTier=true)
        {
            string fileName = outputDirectory + "\\" + this.ProjectName + ".Business\\" + (!twoTier?this.ProjectName + ".Manager\\Manager\\":this.txtClassName.Text+"\\") + this.txtClassName.Text + "Manager.cs";
            string code = this.BuilderManager();
            return CodeGenerator.WriteCode(fileName, overwrite, code);
        }

        private string BuilderManager()
        {
            string file = Application.StartupPath + "\\CodeGenerator\\Templates\\Manager.txt";
            string code = GetTemplate(file);
            CodeGenerator codeGenerator = new CodeGenerator(this.xmlDocument, this.txtCompany.Text, this.ProjectName, this.txtAuthor.Text, this.txtYearCreated.Text, this.txtDateCreated.Text, this.GetClassName(), "Table", this.GetTableName(), this.GetDescription());
            code = code.Replace("#Search#", codeGenerator.GetSearch());
            code = this.ReplaceAssemblyInfo(code);
            return code;
        }

        public bool BuilderIService(string outputDirectory, bool overwrite)
        {
            string fileName = outputDirectory + "\\" + this.ProjectName + ".Business\\" + this.ProjectName + ".IService\\" + "I" + this.txtClassName.Text + "Service.cs";
            string code = this.BuilderIService();
            return CodeGenerator.WriteCode(fileName, overwrite, code);
        }

        private string BuilderIService()
        {
            string file = Application.StartupPath + "\\CodeGenerator\\Templates\\IService.txt";
            string code = GetTemplate(file);
            code = this.ReplaceAssemblyInfo(code);
            return code;
        }

        #region 生成Edit页面
        public bool BuilderEditPage(string outputDirectory, bool overwrite)
        {
            string file = outputDirectory + "\\" + this.ProjectName + ".Web\\" + this.txtClassName.Text + "\\" + this.txtClassName.Text + "Edit.aspx";
            string code = this.BuilderEditPage();
            return CodeGenerator.WriteCode(file, overwrite, code);
        }

        private string BuilderEditPage()
        {
            string className = this.txtClassName.Text + "Edit";
            string file = Application.StartupPath + "\\CodeGenerator\\Templates\\EditEntity.aspx.txt";
            string code = GetTemplate(file);
            code = ReplaceAssemblyInfo(code);
            CodeGenerator codeGenerator = new CodeGenerator(this.xmlDocument, this.txtCompany.Text, this.ProjectName, this.txtAuthor.Text, this.txtYearCreated.Text, this.txtDateCreated.Text, className, "Entity", this.GetTableName(), this.GetDescription());
            string validateCode = string.Empty;
            string editPageField = codeGenerator.GetEditPage(out validateCode);
            code = code.Replace("#EditPageField#", editPageField);
            code = code.Replace("#ValidateCode#", validateCode);
            return code;
        }
        #endregion

        #region 生成EditCode页面
        public bool BuilderEditCode(string outputDirectory, bool overwrite)
        {
            string file = outputDirectory + "\\" + this.ProjectName + ".Web\\" + this.txtClassName.Text + "\\" + this.txtClassName.Text + "Edit.aspx.cs";
            string code = this.BuilderEditCodePage();
            return CodeGenerator.WriteCode(file, overwrite, code);
        }

        private string BuilderEditCodePage()
        {
            string className = this.txtClassName.Text+"Edit";
            string file = Application.StartupPath + "\\CodeGenerator\\Templates\\EditEntity.aspx.cs.txt";
            string code = GetTemplate(file);
            code = this.ReplaceAssemblyInfo(code);
            CodeGenerator codeGenerator = new CodeGenerator(this.xmlDocument, this.txtCompany.Text, this.ProjectName, this.txtAuthor.Text, this.txtYearCreated.Text, this.txtDateCreated.Text, className, string.Empty, this.GetTableName(), this.GetDescription());
            string returnGetEntity = string.Empty;
            string returnShowEntity = string.Empty;
            string returnItemDetails = string.Empty;
            string returnGetAttachment = string.Empty;
            string returnSaveFiles = string.Empty;
            string returnCheckInput = string.Empty;
            string showDefaultValue = string.Empty;
            codeGenerator.GetEditCode(out returnGetEntity, out returnShowEntity, out returnItemDetails, out returnGetAttachment, out returnSaveFiles, out returnCheckInput, out showDefaultValue);
            code = code.Replace("#GetEntity#", returnGetEntity);
            code = code.Replace("#ShowEntity#", returnShowEntity);
            code = code.Replace("#ItemDetails#", returnItemDetails);
            code = code.Replace("#GetAttachment#", returnGetAttachment);
            code = code.Replace("#SaveFiles#", returnSaveFiles);
            code = code.Replace("#CheckInput#", returnCheckInput);
            code = code.Replace("#ShowDefaultValue#", showDefaultValue);
            return code;
        }
        #endregion

        #region 生成List页面
        public bool BuilderListPage(string outputDirectory, bool overwrite)
        {
            string file = outputDirectory + "\\" + this.ProjectName + ".Web\\" + this.txtClassName.Text + "\\" + this.txtClassName.Text + "List.aspx";
            string code = this.BuilderListPage();
            return CodeGenerator.WriteCode(file, overwrite, code);
        }

        private string BuilderListPage()
        {
            string className = this.txtClassName.Text + "List";
            string file = Application.StartupPath + "\\CodeGenerator\\Templates\\ListEntity.aspx.txt";
            string code = GetTemplate(file);
            code = ReplaceAssemblyInfo(code);
            // 替换显示内容部分
            CodeGenerator codeGenerator = new CodeGenerator(this.xmlDocument, this.txtCompany.Text, this.ProjectName, this.txtAuthor.Text, this.txtYearCreated.Text, this.txtDateCreated.Text, className, string.Empty, this.GetTableName(), this.GetDescription());
            string showListField = codeGenerator.GetListPage();
            code = code.Replace("#BoundField#", showListField);
            return code;
        }
        #endregion

        #region 生成ListCode页面
        public bool BuilderListCode(string outputDirectory, bool overwrite)
        {
            string file = outputDirectory + "\\" + this.ProjectName + ".Web\\" + this.txtClassName.Text + "\\" + this.txtClassName.Text + "List.aspx.cs";
            string code = this.BuilderListCodePage();
            return CodeGenerator.WriteCode(file, overwrite, code);
        }

        private string BuilderListCodePage()
        {
            string className = this.txtClassName.Text + "List";
            string file = Application.StartupPath + "\\CodeGenerator\\Templates\\ListEntity.aspx.cs.txt";
            if (this.chkWCF.Checked)
            {
                file = Application.StartupPath + "\\CodeGenerator\\Templates\\ListEntity.aspx.cs.WCF.txt";
            }
            string code = GetTemplate(file);
            code = ReplaceAssemblyInfo(code);
            this.txtCode.SettxtContent("c#", code);
            return code;
        }
        #endregion

        #region 生成Admin页面
        public bool BuilderAdminPage(string outputDirectory, bool overwrite)
        {
            string file = outputDirectory + "\\" + this.ProjectName + ".Web\\" + this.txtClassName.Text + "\\" + this.txtClassName.Text + "Admin.aspx";
            string code = this.BuilderAdminPage();
            return CodeGenerator.WriteCode(file, overwrite, code);
        }

        private string BuilderAdminPage()
        {
            string className = this.txtClassName.Text + "Admin";
            string file = Application.StartupPath + "\\CodeGenerator\\Templates\\ListEntity.aspx.txt";
            string code = GetTemplate(file);
            code = ReplaceAssemblyInfo(code);
            code = code.Replace(this.txtClassName.Text + "List", this.txtClassName.Text + "Admin");
            // 替换显示内容部分
            CodeGenerator codeGenerator = new CodeGenerator(this.xmlDocument, this.txtCompany.Text, this.ProjectName, this.txtAuthor.Text, this.txtYearCreated.Text, this.txtDateCreated.Text, className, string.Empty, this.GetTableName(), this.GetDescription());
            string showListField = codeGenerator.GetListPage();
            code = code.Replace("#BoundField#", showListField);
            return code;
        }
        #endregion

        #region 生成AdminCode页面
        public bool BuilderAdminCode(string outputDirectory, bool overwrite)
        {
            string file = outputDirectory + "\\" + this.ProjectName + ".Web\\" + this.txtClassName.Text + "\\" + this.txtClassName.Text + "Admin.aspx.cs";
            string code = this.BuilderAdminCodePage();
            return CodeGenerator.WriteCode(file, overwrite, code);
        }

        private string BuilderAdminCodePage()
        {
            string className = this.txtClassName.Text + "Admin";
            string file = Application.StartupPath + "\\CodeGenerator\\Templates\\ListEntity.aspx.cs.txt";
            if (this.chkWCF.Checked)
            {
                file = Application.StartupPath + "\\CodeGenerator\\Templates\\ListEntity.aspx.cs.WCF.txt";
            }
            string code = GetTemplate(file);
            code = ReplaceAssemblyInfo(code);
            code = code.Replace(this.txtClassName.Text + "List", this.txtClassName.Text + "Admin");
            // 把列表页面替换为管理页面
            code = code.Replace("GetDataTableByPage(this.UserInfo.Id", "GetDataTableByPage(string.Empty");
            code = code.Replace("// this.permissionAdmin = true;", "this.permissionAdmin = true;");
            return code;
        }
        #endregion

        #region 生成Search页面
        public bool BuilderSearchPage(string outputDirectory, bool overwrite)
        {
            string file = outputDirectory + "\\" + this.ProjectName + ".Web\\" + this.txtClassName.Text + "\\" + this.txtClassName.Text + "Search.aspx";
            string code = this.BuilderSearchPage();
            return CodeGenerator.WriteCode(file, overwrite, code);
        }

        private string BuilderSearchPage()
        {
            string className = this.txtClassName.Text + "Admin";
            string file = Application.StartupPath + "\\CodeGenerator\\Templates\\ListEntity.aspx.txt";
            string code = GetTemplate(file);
            code = ReplaceAssemblyInfo(code);
            code = code.Replace(this.txtClassName.Text + "List", this.txtClassName.Text + "Search");
            // 替换显示内容部分
            CodeGenerator codeGenerator = new CodeGenerator(this.xmlDocument, this.txtCompany.Text, this.ProjectName, this.txtAuthor.Text, this.txtYearCreated.Text, this.txtDateCreated.Text, className, string.Empty, this.GetTableName(), this.GetDescription());
            string searchListField = codeGenerator.GetListPage();
            code = code.Replace("#BoundField#", searchListField);
            return code;
        }
        #endregion

        #region 生成SearchCode页面
        public bool BuilderSearchCode(string outputDirectory, bool overwrite)
        {
            string file = outputDirectory + "\\" + this.ProjectName + ".Web\\" + this.txtClassName.Text + "\\" + this.txtClassName.Text + "Search.aspx.cs";
            string code = this.BuilderSearchCodePage();
            return CodeGenerator.WriteCode(file, overwrite, code);
        }

        private string BuilderSearchCodePage()
        {
            string className = this.txtClassName.Text + "Search";
            string file = Application.StartupPath + "\\CodeGenerator\\Templates\\ListEntity.aspx.cs.txt";
            if (this.chkWCF.Checked)
            {
                file = Application.StartupPath + "\\CodeGenerator\\Templates\\ListEntity.aspx.cs.WCF.txt";
            }
            string code = GetTemplate(file);
            code = ReplaceAssemblyInfo(code);
            code = code.Replace(this.txtClassName.Text + "List", this.txtClassName.Text + "Search");
            code = code.Replace("this.permissionDelete = true;", "this.permissionDelete = false;");
            code = code.Replace("GetDataTableByPage(this.UserInfo.Id", "GetDataTableByPage(string.Empty");
            return code;
        }
        #endregion

        #region 生成Show页面
        public bool BuilderShowPage(string outputDirectory, bool overwrite)
        {
            string file = outputDirectory + "\\" + this.ProjectName + ".Web\\" + this.txtClassName.Text + "\\" + this.txtClassName.Text + "Show.aspx";
            string code = this.BuilderShowPage();
            return CodeGenerator.WriteCode(file, overwrite, code);
        }

        private string BuilderShowPage()
        {
            string className = this.txtClassName.Text + "Show";
            string file = Application.StartupPath + "\\CodeGenerator\\Templates\\ShowEntity.aspx.txt";
            string code = GetTemplate(file);
            code = ReplaceAssemblyInfo(code);
            CodeGenerator codeGenerator = new CodeGenerator(this.xmlDocument, this.txtCompany.Text, this.ProjectName, this.txtAuthor.Text, this.txtYearCreated.Text, this.txtDateCreated.Text,className,string.Empty, this.GetTableName(), this.GetDescription());
            string showPageField = codeGenerator.GetShowPageField();
            code = code.Replace("#ShowPageField#", showPageField);
            return code;
        }
        #endregion

        #region 生成ShowCode页面
        public bool BuilderShowCode(string outputDirectory, bool overwrite)
        {
            string file = outputDirectory + "\\" + this.ProjectName + ".Web\\" + this.txtClassName.Text + "\\" + this.txtClassName.Text + "Show.aspx.cs";
            string code = this.BuilderShowCodePage();
            return CodeGenerator.WriteCode(file, overwrite, code);
        }

        private string BuilderShowCodePage()
        {
            string className = this.txtClassName.Text + "Show";
            string file = Application.StartupPath + "\\CodeGenerator\\Templates\\ShowEntity.aspx.cs.txt";
            string code = GetTemplate(file);
            code = ReplaceAssemblyInfo(code);
            CodeGenerator codeGenerator = new CodeGenerator(this.xmlDocument, this.txtCompany.Text, this.ProjectName, this.txtAuthor.Text, this.txtYearCreated.Text, this.txtDateCreated.Text,className,string.Empty, this.GetTableName(), this.GetDescription());
            string showCodeField = codeGenerator.GetShowCode();
            code = code.Replace("#ShowCodeField#", showCodeField);
            return code;
        }
        #endregion


        private void btnIService_Click(object sender, EventArgs e)
        {
            this.SetControlState(false);
            this.txtCode.txtContent.Text = string.Empty;
            this.txtClassName.Text = this.GetClassName();

            string file = Application.StartupPath + "\\CodeGenerator\\Templates\\IService.txt";
            string code = GetTemplate(file);
            code = ReplaceAssemblyInfo(code);
            this.txtCode.SettxtContent("c#", code);

            this.txtClassName.Text = "I" + this.txtClassName.Text + "Service";
            this.txtFileName.Text = this.txtClassName.Text;

            this.btnCopyCode.Enabled = true;
            this.btnSaveCode.Enabled = true;
            this.SetControlState();
            this.txtClassName.Focus();
            this.txtClassName.SelectAll();
        }

        private void btnTableColumns_Click(object sender, EventArgs e)
        {
            this.SetControlState(false);
            this.txtCode.txtContent.Text = string.Empty;
            this.txtClassName.Text = this.GetClassName();
            this.txtClassName.Text += "TableColumns";
            this.txtFileName.Text = this.txtClassName.Text + ".SQL";

            CodeGenerator codeGenerator = new CodeGenerator(this.xmlDocument, this.txtCompany.Text, this.ProjectName, this.txtAuthor.Text, this.txtYearCreated.Text, this.txtDateCreated.Text, this.GetClassName(), "Table", this.GetTableName(), this.GetDescription());
            this.txtCode.SettxtContent("c#", codeGenerator.DBSQL());

            this.btnCopyCode.Enabled = true;
            this.btnSaveCode.Enabled = true;
            this.SetControlState();
            this.txtClassName.Focus();
            this.txtClassName.SelectAll();
        }

        private void btnCopyCode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCode.txtContent.Text))
            {
                MessageBox.Show(this, AppMessage.MSG0246, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Clipboard.SetText(this.txtCode.txtContent.Text);
            this.txtCode.txtContent.Text = string.Empty;
            this.btnCopyCode.Enabled = false;
            this.btnSaveCode.Enabled = false;
        }

        private void btnBuilder_Click(object sender, EventArgs e)
        {
            this.SetControlState(false);
            this.txtCode.txtContent.Text = string.Empty;
            this.txtCode.SettxtContent("c#", "");
            bool overwrite = this.chkOverwrite.Checked;
            this.txtClassName.Text = this.GetClassName();
            bool twoTier = this.chkTwoTier.Checked;
            CodeGenerator codeGenerator = new CodeGenerator(this.xmlDocument, this.txtCompany.Text, this.ProjectName, this.txtAuthor.Text, this.txtYearCreated.Text, this.txtDateCreated.Text, this.txtClassName.Text, "Manager", this.GetTableName(), this.GetDescription());
            overwrite = codeGenerator.BuilderTable(this.txtOutput.Text, overwrite, twoTier);
            overwrite = codeGenerator.BuilderEntity(this.txtOutput.Text, overwrite, twoTier);
            overwrite = codeGenerator.BuilderManager(this.txtOutput.Text, overwrite, this.CurrentDb, twoTier);
            overwrite = this.BuilderManager(this.txtOutput.Text, overwrite,twoTier);
            if (!this.chkTwoTier.Checked)
            {
                overwrite = this.BuilderIService(this.txtOutput.Text, overwrite);
                overwrite = this.BuilderService(this.txtOutput.Text, overwrite);
            }
            // 生成编辑页面
            overwrite = this.BuilderEditPage(this.txtOutput.Text, overwrite);
            overwrite = this.BuilderEditCode(this.txtOutput.Text, overwrite);
            // 生成显示页面
            overwrite = this.BuilderShowPage(this.txtOutput.Text, overwrite);
            overwrite = this.BuilderShowCode(this.txtOutput.Text, overwrite);
            // 生成列表页面
            overwrite = this.BuilderListPage(this.txtOutput.Text, overwrite);
            overwrite = this.BuilderListCode(this.txtOutput.Text, overwrite);
            // 生成查询页面
            overwrite = this.BuilderSearchPage(this.txtOutput.Text, overwrite);
            overwrite = this.BuilderSearchCode(this.txtOutput.Text, overwrite);
            // 生成管理页面
            overwrite = this.BuilderAdminPage(this.txtOutput.Text, overwrite);
            overwrite = this.BuilderAdminCode(this.txtOutput.Text, overwrite);
            
            this.SetControlState(true);
            // 打开文件夹
            Process.Start(this.txtOutput.Text);
        }

        private void btnBuilderAll_Click(object sender, EventArgs e)
        {
            this.SetControlState(false);
            this.txtCode.txtContent.Text = string.Empty;
            this.txtCode.SettxtContent("c#", "");//2011-10-21 Modify By Fang
            bool overwrite = this.chkOverwrite.Checked;
            bool twoTier = this.chkTwoTier.Checked;
            for (int i = 0; i < this.lbxTables.Items.Count; i++)
            {
                this.lbxTables.SelectedIndex = i;
                this.txtClassName.Text = this.GetClassName();
                CodeGenerator codeGenerator = new CodeGenerator(this.xmlDocument, this.txtCompany.Text, this.ProjectName, this.txtAuthor.Text, this.txtYearCreated.Text, this.txtDateCreated.Text, this.txtClassName.Text, "Manager", this.GetTableName(), this.GetDescription());
                overwrite = codeGenerator.BuilderTable(this.txtOutput.Text, overwrite,twoTier);
                overwrite = codeGenerator.BuilderEntity(this.txtOutput.Text, overwrite, twoTier);
                overwrite = codeGenerator.BuilderManager(this.txtOutput.Text, overwrite, this.CurrentDb, twoTier);
                overwrite = this.BuilderManager(this.txtOutput.Text, overwrite, twoTier);
                if (!this.chkTwoTier.Checked)
                {
                    overwrite = this.BuilderIService(this.txtOutput.Text, overwrite);
                    overwrite = this.BuilderService(this.txtOutput.Text, overwrite);
                }
                // 生成编辑页面
                overwrite = this.BuilderEditPage(this.txtOutput.Text, overwrite);
                overwrite = this.BuilderEditCode(this.txtOutput.Text, overwrite);
                // 生成显示页面
                overwrite = this.BuilderShowPage(this.txtOutput.Text, overwrite);
                overwrite = this.BuilderShowCode(this.txtOutput.Text, overwrite);
                // 生成列表页面
                overwrite = this.BuilderListPage(this.txtOutput.Text, overwrite);
                overwrite = this.BuilderListCode(this.txtOutput.Text, overwrite);
                // 生成查询页面
                overwrite = this.BuilderSearchPage(this.txtOutput.Text, overwrite);
                overwrite = this.BuilderSearchCode(this.txtOutput.Text, overwrite);
                // 生成管理页面
                overwrite = this.BuilderAdminPage(this.txtOutput.Text, overwrite);
                overwrite = this.BuilderAdminCode(this.txtOutput.Text, overwrite);
            }
            this.SetControlState(true);
            // 打开文件夹
            Process.Start(this.txtOutput.Text);
        }

        #region private string SaveCodeFile() 保存主键文件
        /// <summary>
        /// 保存主键文件
        /// </summary>
        /// <returns>文件名</returns>
        private string SaveCodeFile()
        {
            string fileName = this.txtFileName.Text;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (!fileName.EndsWith(".SQL"))
            {
                saveFileDialog.Filter = "程序文件(*.cs)|*.cs|页面文件(*.aspx)|*.aspx|所有文件|*.*";
            }
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.FileName = fileName;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = saveFileDialog.FileName;
                CodeGenerator.WriteCode(fileName, true, this.txtCode.txtContent.Text);
            }
            return fileName;
        }
        #endregion

        private void btnSaveCode_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtCode.txtContent.Text.Trim()))
            {
                MessageBox.Show(this, AppMessage.MSG0285, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.btnSaveCode.Enabled = false;
            this.SaveCodeFile();
            this.btnSaveCode.Enabled = true;
        }

        #region private SettingHelper GetFormSetting() 读取配置文件
        /// <summary>
        /// 读取配置文件
        /// </summary>
        private SettingHelper GetFormSetting()
        {
            SettingHelper settingHelper = new SettingHelper(this.txtCompany.Text, this.txtProject.Text, this.txtAuthor.Text, this.txtDesign.Text, this.txtOutput.Text, this.CurrentDb, this.chkOverwrite.Checked);
            return settingHelper;
        }
        #endregion

        #region private void SaveSetting() 保存配置文件
        /// <summary>
        /// 保存配置文件
        /// </summary>
        private void SaveSetting()
        {
            SettingHelper settingHelper = new SettingHelper(this.txtCompany.Text, this.txtProject.Text, this.txtAuthor.Text, this.txtDesign.Text, this.txtOutput.Text, this.CurrentDb, this.chkOverwrite.Checked);
            settingHelper.SaveSetting();
        }
        #endregion

        private void btnApply_Click(object sender, EventArgs e)
        {
            this.SaveSetting();
        }

        private void btnPdmDD_Click(object sender, EventArgs e)
        {
            this.SetControlState(false);
            this.txtCode.txtContent.Text = string.Empty;
            bool overwrite = this.chkOverwrite.Checked;
            string content = GetPdmDD();
            overwrite = this.BuilderPdmDD(this.txtOutput.Text, overwrite, content);
            this.SetControlState(true);
            // 打开文件夹
            Process.Start(this.txtOutput.Text);
        }

        private string GetPdmDD()
        {
            string content = "";
            string pdmFile = this.txtDesign.Text;
            PdmReader pdmReader = new PdmReader(pdmFile);
            pdmReader.InitData();
            if (pdmReader.Tables != null)
            {
                content = GetPdmData(pdmReader.Tables);
            }

            return content;
        }

        private string GetPdmData(IList<TableInfo> tables)
        {
            string tableStr = ""; //保存表的字符串
            string navStr = ""; //保存导航的字符串
            string classStr = "td-01";//表格样式名
            string mandatoryStr = "";//是否为空值
            string length = "";//长度
            string dataType = "";//数据类型
            string isPk = "";//是否主键
            int maxWidth = 0;//导航列的最大宽度
            IList<string> pkIds = new List<string>();//保存主键column 的Id
            //需要的参数可以继续添加

            #region 生成navStr和tableStr
            navStr = "<div id=leftcontent style=width:$width$px><h2>导&nbsp;&nbsp;航</h2><ul>";
            tableStr = "<div id=container style=text-align:center>";

            foreach (TableInfo table in tables)//遍历table
            {
                int i = 0;
                if (table.Name.Length > maxWidth)
                {
                    maxWidth = table.Name.Length;

                }
                navStr += "<li><a href=#" + table.Code + ">◇&nbsp;" + table.Name + "</a></li>";
                tableStr += "<a name=" + table.Code + "</a>";//定义锚点
                tableStr += @"<table class=Table-00 cellspacing=1 cellpadding=0>" +

                    @"<tr><td class=td-00 colspan=9 style='cursor:pointer' onclick='javascript:$("
                    + "\"#"
                    + table.Code
                    + "\""
                    + ").toggle();'>" +
                    table.Name + "(" + table.Code + ")" +
                    @"</td></tr>" +
                    @"<tbody id=" + table.Code + ">" +
                    @"<tr>
                     <td width=30px class=td-00>序号</td>
                     <td width=140px class=td-00>编码</td>
                     <td class=td-00>备注</td>
                     <td width=100px class=td-00>类型</td>
                     <td width=50px class=td-00>长度</td>
                     <td width=70px class=td-00>预设值</td>
                     <td width=30px class=td-00>主键</td>
                     <td width=30px class=td-00>空值</td>
                </tr>
            ";//定义表头

                //遍历key，获得column为主键的 Id
                foreach (KeyInfo key in table.Keys)
                {
                    foreach (ColumnInfo column in key.Columns)
                    {
                        pkIds.Add(column.RefId);
                    }
                }
                //遍历column
                foreach (ColumnInfo column in table.Columns)
                {
                    i++;
                    classStr = (i % 2) == 0 ? "td-01" : "td-02";

                    //datatype

                    if (column.DataType.IndexOf("(") < 0)
                    {
                        dataType = column.DataType;
                    }
                    else
                    {
                        dataType = column.DataType.Substring(0, column.DataType.IndexOf("("));
                    }

                    //length

                    if (!string.IsNullOrEmpty(column.Length))
                    {
                        length = column.Length;
                    }
                    else { length = ""; }

                    //length  此处可以进一步确定其他类型数据的长度，以后慢慢改改
                    ////if (!string.IsNullOrEmpty(column.Length))
                    ////{
                    ////    length = column.Length;
                    ////    dataType="nvchar";
                    ////}
                    ////else
                    ////{

                    ////    switch (column.DataType)
                    ////    {
                    ////        case "DATE":
                    ////            dataType = "datetime";
                    ////            length = "";
                    ////            break;
                    ////        default:
                    ////            length = "长度未知";
                    ////            break;
                    ////    }

                    ////}

                    //判断是否是主键
                    if (pkIds.Contains(column.Id))
                    {
                        isPk = "√";
                    }
                    else { isPk = "×"; }

                    //是否允许为空
                    if (!string.IsNullOrEmpty(column.Mandatory))
                    {
                        mandatoryStr = "×";
                    }
                    else { mandatoryStr = "√"; }


                    tableStr += @"<tr>" +
                                @"<td class=" + classStr + ">" + i.ToString() + "</td>" +
                                @"<td class=" + classStr + ">" + column.Code + "</td>" +
                                @"<td class=" + classStr + ">" + column.Name + "</td>" +
                                @"<td class=" + classStr + ">" + dataType + "</td>" +
                                @"<td class=" + classStr + ">" + length + "</td>" +
                                @"<td class=" + classStr + ">" + column.DefaultValue + "</td>" +
                                @"<td class=" + classStr + " style=font-size:14px>" + isPk + "</td>" +
                                @"<td class=" + classStr + " style=font-size:14px>" + mandatoryStr + "</td>" +
                                @"</tr>";

                }
                tableStr += "</tbody></table><br/>";
                tableStr += @"<div id=TOPEnd onClick=javascript:location.href='#TOP' class=TopClass>TOP</div>";
            }
            navStr += "</ul></div>";
            navStr = navStr.Replace("$width$", (maxWidth * 14).ToString());
            tableStr += "</div>";
            #endregion

            return navStr + tableStr;
        }

        //生成PdmDD
        public bool BuilderPdmDD(string outputDirectory, bool overwrite, string content)
        {
            string fileName = outputDirectory + "\\通用权限管理系统数据字典(PDM).html";
            string code = this.BuilderPdmDD(content);
            return CodeGenerator.WriteCode(fileName, overwrite, code);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="content">生成的内容</param>
        /// <returns></returns>
        private string BuilderPdmDD(string content)
        {
            string file = Application.StartupPath + "\\CodeGenerator\\Templates\\PdmDD.html";
            string code = GetTemplate(file);
            code = ReplaceTemplate(code, content);
            return code;
        }

        //替换模板
        private string ReplaceTemplate(string code, string content)
        {
            code = code.Replace("<!--content-->", content);
            return code;
        }

        private void btnAddPage_Click(object sender, EventArgs e)
        {
            this.SetControlState(false);
            this.txtCode.txtContent.Text = string.Empty;
            string className = this.GetClassName();
            this.txtClassName.Text = className;
            this.txtFileName.Text = className + "Add.aspx";
            string code = this.BuilderEditPage();
            // 把列表页面查询条件替换为管理页面
            code = code.Replace(txtClassName + "Edit", txtClassName + "Add");
            this.txtCode.SettxtContent("c#", code);
            this.SetControlState();
        }

        private void btnAddCode_Click(object sender, EventArgs e)
        {
            this.SetControlState(false);
            this.txtCode.txtContent.Text = string.Empty;
            string className = this.GetClassName();
            this.txtClassName.Text = className;
            this.txtFileName.Text = className + "Add.aspx.cs";
            string code=this.BuilderEditCodePage();
            // 把列表页面查询条件替换为管理页面
            code = code.Replace(txtClassName + "Edit", txtClassName + "Add");
            this.txtCode.SettxtContent("c#", code);
            this.SetControlState();
        }

        private void btnEditPage_Click(object sender, EventArgs e)
        {
            this.SetControlState(false);
            this.txtCode.SettxtContent("c#", "");
            string className = this.GetClassName();
            this.txtClassName.Text = className;
            this.txtFileName.Text = className + "Edit.aspx";
            string code=this.BuilderEditPage();
            this.txtCode.SettxtContent("c#", code);
            this.SetControlState();
        }

        private void btnEditCode_Click(object sender, EventArgs e)
        {
            this.SetControlState(false);
            this.txtCode.SettxtContent("c#","");
            string className = this.GetClassName();
            this.txtClassName.Text = className;
            this.txtFileName.Text = className + "Edit.aspx.cs";
            string code = this.BuilderEditCodePage();
            this.txtCode.SettxtContent("c#", code);
            this.SetControlState();
        }

        private void btnShowPage_Click(object sender, EventArgs e)
        {
            this.SetControlState(false);
            this.txtCode.SettxtContent("c#", "");
            string className = this.GetClassName();
            this.txtClassName.Text = className;
            this.txtFileName.Text = className + "Show.aspx";
            string code = this.BuilderShowPage();
            this.txtCode.SettxtContent("c#", code);
            this.SetControlState();
        }

        private void btnShowCode_Click(object sender, EventArgs e)
        {
            this.SetControlState(false);
            this.txtCode.SettxtContent("c#","");
            string className = this.GetClassName();
            this.txtClassName.Text = className;
            this.txtFileName.Text = className + "Show.aspx.cs";
            string code = this.BuilderShowCodePage();
            this.txtCode.SettxtContent("c#", code);
            this.SetControlState();
        }

        private void btnListPage_Click(object sender, EventArgs e)
        {
            this.SetControlState(false);
            this.txtCode.SettxtContent("c#", "");
            string className = this.GetClassName();
            this.txtClassName.Text = className;
            this.txtFileName.Text = className + "List.aspx";
            string code = this.BuilderListPage();
            this.txtCode.SettxtContent("c#", code);
            this.SetControlState();
        }

        private void btnListCode_Click(object sender, EventArgs e)
        {
            this.SetControlState(false);
            this.txtCode.SettxtContent("c#", "");
            string className = this.GetClassName();
            this.txtClassName.Text = className;
            this.txtFileName.Text = className + "List.aspx.cs";
            string code = this.BuilderListCodePage();
            this.txtCode.SettxtContent("c#", code);
            this.SetControlState();
        }

        private void btnSearchPage_Click(object sender, EventArgs e)
        {
            this.SetControlState(false);
            this.txtCode.SettxtContent("c#", "");
            string className = this.GetClassName();
            this.txtClassName.Text = className;
            this.txtFileName.Text = className + "Search.aspx";
            string code = this.BuilderSearchPage();
            this.txtCode.SettxtContent("c#", code);
            this.SetControlState();
        }

        private void btnSearchCode_Click(object sender, EventArgs e)
        {
            this.SetControlState(false);
            this.txtCode.SettxtContent("c#", "");
            string className = this.GetClassName();
            this.txtClassName.Text = className;
            this.txtFileName.Text = className + "Search.aspx.cs";
            string code = this.BuilderSearchCodePage();
            this.txtCode.SettxtContent("c#", code);
            this.SetControlState();
        }

        private void btnAdminPage_Click(object sender, EventArgs e)
        {
            this.SetControlState(false);
            this.txtCode.SettxtContent("c#", "");
            string className = this.GetClassName();
            this.txtClassName.Text = className;
            this.txtFileName.Text = className + "Admin.aspx";
            string code = this.BuilderAdminPage();
            this.txtCode.SettxtContent("c#", code);
            this.SetControlState();
        }

        private void btnAdminCode_Click(object sender, EventArgs e)
        {
            this.SetControlState(false);
            this.txtCode.SettxtContent("c#", "");
            string className = this.GetClassName();
            this.txtClassName.Text = className;
            this.txtFileName.Text = className + "Admin.aspx.cs";
            string code = this.BuilderAdminCodePage();
            this.txtCode.SettxtContent("c#", code);
            this.SetControlState();
        }

        private void FrmCodeGenerator_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 在这里检查配置项目是否发生过变化
            SettingHelper settingHelper = new SettingHelper();
            settingHelper.GetSetting();
            SettingHelper formSettingHelper = this.GetFormSetting();
            if (!settingHelper.Equals(formSettingHelper))
            {
                DialogResult dialogResult = MessageBox.Show(AppMessage.MSG0284, AppMessage.MSG0000, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dialogResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                if (dialogResult == DialogResult.Yes)
                {
                    // 保存配置文件
                    this.SaveSetting();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // 关闭窗体
            this.Close();
        }
    }
}