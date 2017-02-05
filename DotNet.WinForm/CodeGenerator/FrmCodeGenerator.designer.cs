namespace DotNet.WinForm
{
    partial class FrmCodeGenerator
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的主键

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用主键编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCodeGenerator));
            this.btnClose = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.rbtnWorkFlow = new System.Windows.Forms.RadioButton();
            this.rbtnBusiness = new System.Windows.Forms.RadioButton();
            this.rbtnUserCenter = new System.Windows.Forms.RadioButton();
            this.chkWCF = new System.Windows.Forms.CheckBox();
            this.chkTwoTier = new System.Windows.Forms.CheckBox();
            this.btnSearchPage = new System.Windows.Forms.Button();
            this.btnSearchCode = new System.Windows.Forms.Button();
            this.btnAdminPage = new System.Windows.Forms.Button();
            this.btnAdminCode = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.btnShowPage = new System.Windows.Forms.Button();
            this.btnShowCode = new System.Windows.Forms.Button();
            this.btnAddPage = new System.Windows.Forms.Button();
            this.btnEditPage = new System.Windows.Forms.Button();
            this.btnListPage = new System.Windows.Forms.Button();
            this.btnTableColumns = new System.Windows.Forms.Button();
            this.btnPdmDD = new System.Windows.Forms.Button();
            this.btnIService = new System.Windows.Forms.Button();
            this.rbzhCN = new System.Windows.Forms.RadioButton();
            this.rbenUS = new System.Windows.Forms.RadioButton();
            this.rbzhTW = new System.Windows.Forms.RadioButton();
            this.btnListCode = new System.Windows.Forms.Button();
            this.btnEditCode = new System.Windows.Forms.Button();
            this.btnAddCode = new System.Windows.Forms.Button();
            this.btnService = new System.Windows.Forms.Button();
            this.btnBuilder = new System.Windows.Forms.Button();
            this.btnSaveCode = new System.Windows.Forms.Button();
            this.chkOverwrite = new System.Windows.Forms.CheckBox();
            this.btnBuilderAll = new System.Windows.Forms.Button();
            this.btnClearOutput = new System.Windows.Forms.Button();
            this.btnClearDesign = new System.Windows.Forms.Button();
            this.btnOutput = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.txtDesign = new System.Windows.Forms.TextBox();
            this.lblDesign = new System.Windows.Forms.Label();
            this.btnBuilderManager = new System.Windows.Forms.Button();
            this.btnDesign = new System.Windows.Forms.Button();
            this.lblTables = new System.Windows.Forms.Label();
            this.lbxTables = new System.Windows.Forms.ListBox();
            this.btnCopyCode = new System.Windows.Forms.Button();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.lblClassName = new System.Windows.Forms.Label();
            this.btnBuilderTable = new System.Windows.Forms.Button();
            this.txtDateCreated = new System.Windows.Forms.TextBox();
            this.lblDateCreated = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.txtYearCreated = new System.Windows.Forms.TextBox();
            this.lblYearCreated = new System.Windows.Forms.Label();
            this.txtProject = new System.Windows.Forms.TextBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.btnBuilderEntity = new System.Windows.Forms.Button();
            this.txtCode = new DotNet.WinForm.UcCodeView();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(1036, 566);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(91, 23);
            this.btnClose.TabIndex = 53;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.flowLayoutPanel1.Controls.Add(this.rbtnWorkFlow);
            this.flowLayoutPanel1.Controls.Add(this.rbtnBusiness);
            this.flowLayoutPanel1.Controls.Add(this.rbtnUserCenter);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(295, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(475, 22);
            this.flowLayoutPanel1.TabIndex = 56;
            // 
            // rbtnWorkFlow
            // 
            this.rbtnWorkFlow.AutoSize = true;
            this.rbtnWorkFlow.Location = new System.Drawing.Point(389, 3);
            this.rbtnWorkFlow.Name = "rbtnWorkFlow";
            this.rbtnWorkFlow.Size = new System.Drawing.Size(83, 16);
            this.rbtnWorkFlow.TabIndex = 30;
            this.rbtnWorkFlow.TabStop = true;
            this.rbtnWorkFlow.Text = "工作流程库";
            this.rbtnWorkFlow.UseVisualStyleBackColor = true;
            // 
            // rbtnBusiness
            // 
            this.rbtnBusiness.AutoSize = true;
            this.rbtnBusiness.Checked = true;
            this.rbtnBusiness.Location = new System.Drawing.Point(300, 3);
            this.rbtnBusiness.Name = "rbtnBusiness";
            this.rbtnBusiness.Size = new System.Drawing.Size(83, 16);
            this.rbtnBusiness.TabIndex = 29;
            this.rbtnBusiness.TabStop = true;
            this.rbtnBusiness.Text = "业务中心库";
            this.rbtnBusiness.UseVisualStyleBackColor = true;
            // 
            // rbtnUserCenter
            // 
            this.rbtnUserCenter.AutoSize = true;
            this.rbtnUserCenter.Location = new System.Drawing.Point(211, 3);
            this.rbtnUserCenter.Name = "rbtnUserCenter";
            this.rbtnUserCenter.Size = new System.Drawing.Size(83, 16);
            this.rbtnUserCenter.TabIndex = 28;
            this.rbtnUserCenter.TabStop = true;
            this.rbtnUserCenter.Text = "用户中心库";
            this.rbtnUserCenter.UseVisualStyleBackColor = true;
            // 
            // chkWCF
            // 
            this.chkWCF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkWCF.AutoSize = true;
            this.chkWCF.Location = new System.Drawing.Point(443, 569);
            this.chkWCF.Name = "chkWCF";
            this.chkWCF.Size = new System.Drawing.Size(42, 16);
            this.chkWCF.TabIndex = 55;
            this.chkWCF.Text = "WCF";
            this.chkWCF.UseVisualStyleBackColor = true;
            // 
            // chkTwoTier
            // 
            this.chkTwoTier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkTwoTier.AutoSize = true;
            this.chkTwoTier.Checked = true;
            this.chkTwoTier.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTwoTier.Location = new System.Drawing.Point(293, 569);
            this.chkTwoTier.Name = "chkTwoTier";
            this.chkTwoTier.Size = new System.Drawing.Size(144, 16);
            this.chkTwoTier.TabIndex = 54;
            this.chkTwoTier.Text = "只生成两层简易版代码";
            this.chkTwoTier.UseVisualStyleBackColor = true;
            // 
            // btnSearchPage
            // 
            this.btnSearchPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchPage.Location = new System.Drawing.Point(957, 230);
            this.btnSearchPage.Name = "btnSearchPage";
            this.btnSearchPage.Size = new System.Drawing.Size(84, 23);
            this.btnSearchPage.TabIndex = 42;
            this.btnSearchPage.Text = "查询页面";
            this.btnSearchPage.UseVisualStyleBackColor = true;
            this.btnSearchPage.Click += new System.EventHandler(this.btnSearchPage_Click);
            // 
            // btnSearchCode
            // 
            this.btnSearchCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchCode.Location = new System.Drawing.Point(957, 254);
            this.btnSearchCode.Name = "btnSearchCode";
            this.btnSearchCode.Size = new System.Drawing.Size(84, 23);
            this.btnSearchCode.TabIndex = 43;
            this.btnSearchCode.Text = "查询代码";
            this.btnSearchCode.UseVisualStyleBackColor = true;
            this.btnSearchCode.Click += new System.EventHandler(this.btnSearchCode_Click);
            // 
            // btnAdminPage
            // 
            this.btnAdminPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdminPage.Location = new System.Drawing.Point(1042, 230);
            this.btnAdminPage.Name = "btnAdminPage";
            this.btnAdminPage.Size = new System.Drawing.Size(84, 23);
            this.btnAdminPage.TabIndex = 44;
            this.btnAdminPage.Text = "管理页面";
            this.btnAdminPage.UseVisualStyleBackColor = true;
            this.btnAdminPage.Click += new System.EventHandler(this.btnAdminPage_Click);
            // 
            // btnAdminCode
            // 
            this.btnAdminCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdminCode.Location = new System.Drawing.Point(1042, 254);
            this.btnAdminCode.Name = "btnAdminCode";
            this.btnAdminCode.Size = new System.Drawing.Size(84, 23);
            this.btnAdminCode.TabIndex = 45;
            this.btnAdminCode.Text = "管理代码";
            this.btnAdminCode.UseVisualStyleBackColor = true;
            this.btnAdminCode.Click += new System.EventHandler(this.btnAdminCode_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.BackColor = System.Drawing.Color.MistyRose;
            this.txtFileName.Location = new System.Drawing.Point(415, 216);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(167, 21);
            this.txtFileName.TabIndex = 11;
            // 
            // lblFileName
            // 
            this.lblFileName.Location = new System.Drawing.Point(332, 220);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(73, 12);
            this.lblFileName.TabIndex = 10;
            this.lblFileName.Text = "文件名：";
            this.lblFileName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnShowPage
            // 
            this.btnShowPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowPage.Location = new System.Drawing.Point(787, 230);
            this.btnShowPage.Name = "btnShowPage";
            this.btnShowPage.Size = new System.Drawing.Size(84, 23);
            this.btnShowPage.TabIndex = 38;
            this.btnShowPage.Text = "显示页面";
            this.btnShowPage.UseVisualStyleBackColor = true;
            this.btnShowPage.Click += new System.EventHandler(this.btnShowPage_Click);
            // 
            // btnShowCode
            // 
            this.btnShowCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnShowCode.Location = new System.Drawing.Point(787, 254);
            this.btnShowCode.Name = "btnShowCode";
            this.btnShowCode.Size = new System.Drawing.Size(84, 23);
            this.btnShowCode.TabIndex = 39;
            this.btnShowCode.Text = "显示代码";
            this.btnShowCode.UseVisualStyleBackColor = true;
            this.btnShowCode.Click += new System.EventHandler(this.btnShowCode_Click);
            // 
            // btnAddPage
            // 
            this.btnAddPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddPage.Location = new System.Drawing.Point(617, 230);
            this.btnAddPage.Name = "btnAddPage";
            this.btnAddPage.Size = new System.Drawing.Size(84, 23);
            this.btnAddPage.TabIndex = 34;
            this.btnAddPage.Text = "添加页面";
            this.btnAddPage.UseVisualStyleBackColor = true;
            this.btnAddPage.Click += new System.EventHandler(this.btnAddPage_Click);
            // 
            // btnEditPage
            // 
            this.btnEditPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditPage.Location = new System.Drawing.Point(702, 230);
            this.btnEditPage.Name = "btnEditPage";
            this.btnEditPage.Size = new System.Drawing.Size(84, 23);
            this.btnEditPage.TabIndex = 36;
            this.btnEditPage.Text = "编辑页面";
            this.btnEditPage.UseVisualStyleBackColor = true;
            this.btnEditPage.Click += new System.EventHandler(this.btnEditPage_Click);
            // 
            // btnListPage
            // 
            this.btnListPage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListPage.Location = new System.Drawing.Point(872, 230);
            this.btnListPage.Name = "btnListPage";
            this.btnListPage.Size = new System.Drawing.Size(84, 23);
            this.btnListPage.TabIndex = 40;
            this.btnListPage.Text = "列表页面";
            this.btnListPage.UseVisualStyleBackColor = true;
            this.btnListPage.Click += new System.EventHandler(this.btnListPage_Click);
            // 
            // btnTableColumns
            // 
            this.btnTableColumns.Enabled = false;
            this.btnTableColumns.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTableColumns.Location = new System.Drawing.Point(464, 255);
            this.btnTableColumns.Name = "btnTableColumns";
            this.btnTableColumns.Size = new System.Drawing.Size(118, 23);
            this.btnTableColumns.TabIndex = 33;
            this.btnTableColumns.Text = "数据库脚本";
            this.btnTableColumns.UseVisualStyleBackColor = true;
            this.btnTableColumns.Click += new System.EventHandler(this.btnTableColumns_Click);
            // 
            // btnPdmDD
            // 
            this.btnPdmDD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPdmDD.Enabled = false;
            this.btnPdmDD.Image = ((System.Drawing.Image)(resources.GetObject("btnPdmDD.Image")));
            this.btnPdmDD.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnPdmDD.Location = new System.Drawing.Point(178, 566);
            this.btnPdmDD.Name = "btnPdmDD";
            this.btnPdmDD.Size = new System.Drawing.Size(107, 23);
            this.btnPdmDD.TabIndex = 49;
            this.btnPdmDD.Text = "数据字典";
            this.btnPdmDD.UseVisualStyleBackColor = true;
            this.btnPdmDD.Click += new System.EventHandler(this.btnPdmDD_Click);
            // 
            // btnIService
            // 
            this.btnIService.Enabled = false;
            this.btnIService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIService.Location = new System.Drawing.Point(379, 255);
            this.btnIService.Name = "btnIService";
            this.btnIService.Size = new System.Drawing.Size(84, 23);
            this.btnIService.TabIndex = 32;
            this.btnIService.Text = "服务接口(&I)";
            this.btnIService.UseVisualStyleBackColor = true;
            this.btnIService.Click += new System.EventHandler(this.btnIService_Click);
            // 
            // rbzhCN
            // 
            this.rbzhCN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbzhCN.AutoSize = true;
            this.rbzhCN.BackColor = System.Drawing.Color.Transparent;
            this.rbzhCN.Location = new System.Drawing.Point(920, 30);
            this.rbzhCN.Name = "rbzhCN";
            this.rbzhCN.Size = new System.Drawing.Size(71, 16);
            this.rbzhCN.TabIndex = 22;
            this.rbzhCN.Tag = "zh-CN";
            this.rbzhCN.Text = "简体中文";
            this.rbzhCN.UseVisualStyleBackColor = false;
            this.rbzhCN.CheckedChanged += new System.EventHandler(this.rbCurrentLanguage_CheckedChanged);
            // 
            // rbenUS
            // 
            this.rbenUS.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbenUS.AutoSize = true;
            this.rbenUS.BackColor = System.Drawing.Color.Transparent;
            this.rbenUS.Location = new System.Drawing.Point(1062, 30);
            this.rbenUS.Name = "rbenUS";
            this.rbenUS.Size = new System.Drawing.Size(65, 16);
            this.rbenUS.TabIndex = 24;
            this.rbenUS.Tag = "en-US";
            this.rbenUS.Text = "English";
            this.rbenUS.UseVisualStyleBackColor = false;
            this.rbenUS.CheckedChanged += new System.EventHandler(this.rbCurrentLanguage_CheckedChanged);
            // 
            // rbzhTW
            // 
            this.rbzhTW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbzhTW.AutoSize = true;
            this.rbzhTW.BackColor = System.Drawing.Color.Transparent;
            this.rbzhTW.Location = new System.Drawing.Point(991, 30);
            this.rbzhTW.Name = "rbzhTW";
            this.rbzhTW.Size = new System.Drawing.Size(71, 16);
            this.rbzhTW.TabIndex = 23;
            this.rbzhTW.Tag = "zh-TW";
            this.rbzhTW.Text = "繁體中文";
            this.rbzhTW.UseVisualStyleBackColor = false;
            this.rbzhTW.CheckedChanged += new System.EventHandler(this.rbCurrentLanguage_CheckedChanged);
            // 
            // btnListCode
            // 
            this.btnListCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListCode.Location = new System.Drawing.Point(872, 254);
            this.btnListCode.Name = "btnListCode";
            this.btnListCode.Size = new System.Drawing.Size(84, 23);
            this.btnListCode.TabIndex = 41;
            this.btnListCode.Text = "列表代码";
            this.btnListCode.UseVisualStyleBackColor = true;
            this.btnListCode.Click += new System.EventHandler(this.btnListCode_Click);
            // 
            // btnEditCode
            // 
            this.btnEditCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditCode.Location = new System.Drawing.Point(702, 254);
            this.btnEditCode.Name = "btnEditCode";
            this.btnEditCode.Size = new System.Drawing.Size(84, 23);
            this.btnEditCode.TabIndex = 37;
            this.btnEditCode.Text = "编辑代码";
            this.btnEditCode.UseVisualStyleBackColor = true;
            this.btnEditCode.Click += new System.EventHandler(this.btnEditCode_Click);
            // 
            // btnAddCode
            // 
            this.btnAddCode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddCode.Location = new System.Drawing.Point(617, 254);
            this.btnAddCode.Name = "btnAddCode";
            this.btnAddCode.Size = new System.Drawing.Size(84, 23);
            this.btnAddCode.TabIndex = 35;
            this.btnAddCode.Text = "添加代码";
            this.btnAddCode.UseVisualStyleBackColor = true;
            this.btnAddCode.Click += new System.EventHandler(this.btnAddCode_Click);
            // 
            // btnService
            // 
            this.btnService.Enabled = false;
            this.btnService.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnService.Location = new System.Drawing.Point(295, 255);
            this.btnService.Name = "btnService";
            this.btnService.Size = new System.Drawing.Size(84, 23);
            this.btnService.TabIndex = 31;
            this.btnService.Text = "服务(&S)";
            this.btnService.UseVisualStyleBackColor = true;
            this.btnService.Click += new System.EventHandler(this.btnService_Click);
            // 
            // btnBuilder
            // 
            this.btnBuilder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuilder.Enabled = false;
            this.btnBuilder.Image = ((System.Drawing.Image)(resources.GetObject("btnBuilder.Image")));
            this.btnBuilder.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnBuilder.Location = new System.Drawing.Point(712, 566);
            this.btnBuilder.Name = "btnBuilder";
            this.btnBuilder.Size = new System.Drawing.Size(104, 23);
            this.btnBuilder.TabIndex = 50;
            this.btnBuilder.Text = "生成";
            this.btnBuilder.UseVisualStyleBackColor = true;
            this.btnBuilder.Click += new System.EventHandler(this.btnBuilder_Click);
            // 
            // btnSaveCode
            // 
            this.btnSaveCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveCode.Enabled = false;
            this.btnSaveCode.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveCode.Image")));
            this.btnSaveCode.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnSaveCode.Location = new System.Drawing.Point(929, 566);
            this.btnSaveCode.Name = "btnSaveCode";
            this.btnSaveCode.Size = new System.Drawing.Size(104, 23);
            this.btnSaveCode.TabIndex = 52;
            this.btnSaveCode.Text = "保存";
            this.btnSaveCode.UseVisualStyleBackColor = true;
            this.btnSaveCode.Click += new System.EventHandler(this.btnSaveCode_Click);
            // 
            // chkOverwrite
            // 
            this.chkOverwrite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkOverwrite.AutoSize = true;
            this.chkOverwrite.Checked = true;
            this.chkOverwrite.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOverwrite.Location = new System.Drawing.Point(18, 570);
            this.chkOverwrite.Name = "chkOverwrite";
            this.chkOverwrite.Size = new System.Drawing.Size(48, 16);
            this.chkOverwrite.TabIndex = 47;
            this.chkOverwrite.Text = "覆盖";
            this.chkOverwrite.UseVisualStyleBackColor = true;
            // 
            // btnBuilderAll
            // 
            this.btnBuilderAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuilderAll.Enabled = false;
            this.btnBuilderAll.Image = ((System.Drawing.Image)(resources.GetObject("btnBuilderAll.Image")));
            this.btnBuilderAll.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnBuilderAll.Location = new System.Drawing.Point(819, 566);
            this.btnBuilderAll.Name = "btnBuilderAll";
            this.btnBuilderAll.Size = new System.Drawing.Size(107, 23);
            this.btnBuilderAll.TabIndex = 51;
            this.btnBuilderAll.Text = "全部生成";
            this.btnBuilderAll.UseVisualStyleBackColor = true;
            this.btnBuilderAll.Click += new System.EventHandler(this.btnBuilderAll_Click);
            // 
            // btnClearOutput
            // 
            this.btnClearOutput.Image = ((System.Drawing.Image)(resources.GetObject("btnClearOutput.Image")));
            this.btnClearOutput.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClearOutput.Location = new System.Drawing.Point(549, 96);
            this.btnClearOutput.Name = "btnClearOutput";
            this.btnClearOutput.Size = new System.Drawing.Size(33, 23);
            this.btnClearOutput.TabIndex = 7;
            this.btnClearOutput.UseVisualStyleBackColor = true;
            this.btnClearOutput.Click += new System.EventHandler(this.btnClearOutput_Click);
            // 
            // btnClearDesign
            // 
            this.btnClearDesign.Image = ((System.Drawing.Image)(resources.GetObject("btnClearDesign.Image")));
            this.btnClearDesign.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnClearDesign.Location = new System.Drawing.Point(549, 69);
            this.btnClearDesign.Name = "btnClearDesign";
            this.btnClearDesign.Size = new System.Drawing.Size(33, 23);
            this.btnClearDesign.TabIndex = 3;
            this.btnClearDesign.UseVisualStyleBackColor = true;
            this.btnClearDesign.Click += new System.EventHandler(this.btnClearDesign_Click);
            // 
            // btnOutput
            // 
            this.btnOutput.Image = ((System.Drawing.Image)(resources.GetObject("btnOutput.Image")));
            this.btnOutput.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnOutput.Location = new System.Drawing.Point(514, 96);
            this.btnOutput.Name = "btnOutput";
            this.btnOutput.Size = new System.Drawing.Size(33, 23);
            this.btnOutput.TabIndex = 6;
            this.btnOutput.UseVisualStyleBackColor = true;
            this.btnOutput.Click += new System.EventHandler(this.btnOutput_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Location = new System.Drawing.Point(112, 97);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(398, 21);
            this.txtOutput.TabIndex = 5;
            // 
            // lblOutput
            // 
            this.lblOutput.Location = new System.Drawing.Point(24, 99);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(86, 12);
            this.lblOutput.TabIndex = 4;
            this.lblOutput.Text = "输出目录：";
            this.lblOutput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDesign
            // 
            this.txtDesign.Location = new System.Drawing.Point(112, 69);
            this.txtDesign.Name = "txtDesign";
            this.txtDesign.ReadOnly = true;
            this.txtDesign.Size = new System.Drawing.Size(398, 21);
            this.txtDesign.TabIndex = 1;
            // 
            // lblDesign
            // 
            this.lblDesign.Location = new System.Drawing.Point(24, 72);
            this.lblDesign.Name = "lblDesign";
            this.lblDesign.Size = new System.Drawing.Size(86, 12);
            this.lblDesign.TabIndex = 0;
            this.lblDesign.Text = "设计文档：";
            this.lblDesign.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBuilderManager
            // 
            this.btnBuilderManager.Enabled = false;
            this.btnBuilderManager.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuilderManager.Location = new System.Drawing.Point(211, 255);
            this.btnBuilderManager.Name = "btnBuilderManager";
            this.btnBuilderManager.Size = new System.Drawing.Size(84, 23);
            this.btnBuilderManager.TabIndex = 30;
            this.btnBuilderManager.Text = "管理(&M)";
            this.btnBuilderManager.UseVisualStyleBackColor = true;
            this.btnBuilderManager.Click += new System.EventHandler(this.btnBuilderManager_Click);
            // 
            // btnDesign
            // 
            this.btnDesign.Image = ((System.Drawing.Image)(resources.GetObject("btnDesign.Image")));
            this.btnDesign.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnDesign.Location = new System.Drawing.Point(514, 69);
            this.btnDesign.Name = "btnDesign";
            this.btnDesign.Size = new System.Drawing.Size(33, 23);
            this.btnDesign.TabIndex = 2;
            this.btnDesign.UseVisualStyleBackColor = true;
            this.btnDesign.Click += new System.EventHandler(this.btnDesign_Click);
            // 
            // lblTables
            // 
            this.lblTables.Location = new System.Drawing.Point(604, 72);
            this.lblTables.Name = "lblTables";
            this.lblTables.Size = new System.Drawing.Size(73, 12);
            this.lblTables.TabIndex = 6;
            this.lblTables.Text = "数据表：";
            this.lblTables.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbxTables
            // 
            this.lbxTables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxTables.FormattingEnabled = true;
            this.lbxTables.ItemHeight = 12;
            this.lbxTables.Location = new System.Drawing.Point(686, 70);
            this.lbxTables.Name = "lbxTables";
            this.lbxTables.Size = new System.Drawing.Size(439, 148);
            this.lbxTables.TabIndex = 7;
            this.lbxTables.SelectedIndexChanged += new System.EventHandler(this.lbxTables_SelectedIndexChanged);
            // 
            // btnCopyCode
            // 
            this.btnCopyCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCopyCode.Enabled = false;
            this.btnCopyCode.Image = ((System.Drawing.Image)(resources.GetObject("btnCopyCode.Image")));
            this.btnCopyCode.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnCopyCode.Location = new System.Drawing.Point(68, 566);
            this.btnCopyCode.Name = "btnCopyCode";
            this.btnCopyCode.Size = new System.Drawing.Size(107, 23);
            this.btnCopyCode.TabIndex = 48;
            this.btnCopyCode.Text = "复制(&C)";
            this.btnCopyCode.UseVisualStyleBackColor = true;
            this.btnCopyCode.Click += new System.EventHandler(this.btnCopyCode_Click);
            // 
            // txtClassName
            // 
            this.txtClassName.BackColor = System.Drawing.Color.MistyRose;
            this.txtClassName.Location = new System.Drawing.Point(112, 216);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(167, 21);
            this.txtClassName.TabIndex = 9;
            // 
            // lblClassName
            // 
            this.lblClassName.Location = new System.Drawing.Point(37, 220);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(73, 12);
            this.lblClassName.TabIndex = 8;
            this.lblClassName.Text = "实体类：";
            this.lblClassName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBuilderTable
            // 
            this.btnBuilderTable.Enabled = false;
            this.btnBuilderTable.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuilderTable.Location = new System.Drawing.Point(43, 255);
            this.btnBuilderTable.Name = "btnBuilderTable";
            this.btnBuilderTable.Size = new System.Drawing.Size(84, 23);
            this.btnBuilderTable.TabIndex = 28;
            this.btnBuilderTable.Text = "存储表(&T)";
            this.btnBuilderTable.UseVisualStyleBackColor = true;
            this.btnBuilderTable.Click += new System.EventHandler(this.btnBuilderTable_Click);
            // 
            // txtDateCreated
            // 
            this.txtDateCreated.Location = new System.Drawing.Point(112, 179);
            this.txtDateCreated.Name = "txtDateCreated";
            this.txtDateCreated.Size = new System.Drawing.Size(167, 21);
            this.txtDateCreated.TabIndex = 21;
            // 
            // lblDateCreated
            // 
            this.lblDateCreated.Location = new System.Drawing.Point(24, 183);
            this.lblDateCreated.Name = "lblDateCreated";
            this.lblDateCreated.Size = new System.Drawing.Size(86, 12);
            this.lblDateCreated.TabIndex = 20;
            this.lblDateCreated.Text = "创建日期：";
            this.lblDateCreated.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAuthor
            // 
            this.txtAuthor.Location = new System.Drawing.Point(415, 152);
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(167, 21);
            this.txtAuthor.TabIndex = 19;
            // 
            // lblAuthor
            // 
            this.lblAuthor.Location = new System.Drawing.Point(352, 156);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(53, 12);
            this.lblAuthor.TabIndex = 18;
            this.lblAuthor.Text = "作者：";
            this.lblAuthor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtYearCreated
            // 
            this.txtYearCreated.Location = new System.Drawing.Point(112, 152);
            this.txtYearCreated.Name = "txtYearCreated";
            this.txtYearCreated.Size = new System.Drawing.Size(167, 21);
            this.txtYearCreated.TabIndex = 15;
            // 
            // lblYearCreated
            // 
            this.lblYearCreated.Location = new System.Drawing.Point(24, 156);
            this.lblYearCreated.Name = "lblYearCreated";
            this.lblYearCreated.Size = new System.Drawing.Size(86, 12);
            this.lblYearCreated.TabIndex = 14;
            this.lblYearCreated.Text = "创建年份：";
            this.lblYearCreated.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtProject
            // 
            this.txtProject.Location = new System.Drawing.Point(415, 124);
            this.txtProject.Name = "txtProject";
            this.txtProject.Size = new System.Drawing.Size(167, 21);
            this.txtProject.TabIndex = 17;
            // 
            // lblProject
            // 
            this.lblProject.Location = new System.Drawing.Point(352, 128);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(53, 12);
            this.lblProject.TabIndex = 16;
            this.lblProject.Text = "项目：";
            this.lblProject.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCompany
            // 
            this.txtCompany.Location = new System.Drawing.Point(112, 124);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(167, 21);
            this.txtCompany.TabIndex = 13;
            // 
            // lblCompany
            // 
            this.lblCompany.Location = new System.Drawing.Point(24, 128);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(86, 12);
            this.lblCompany.TabIndex = 12;
            this.lblCompany.Text = "公司：";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBuilderEntity
            // 
            this.btnBuilderEntity.Enabled = false;
            this.btnBuilderEntity.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuilderEntity.Location = new System.Drawing.Point(127, 255);
            this.btnBuilderEntity.Name = "btnBuilderEntity";
            this.btnBuilderEntity.Size = new System.Drawing.Size(84, 23);
            this.btnBuilderEntity.TabIndex = 29;
            this.btnBuilderEntity.Text = "实体类(&E)";
            this.btnBuilderEntity.UseVisualStyleBackColor = true;
            this.btnBuilderEntity.Click += new System.EventHandler(this.btnBuilderEntity_Click);
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(18, 284);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(1105, 273);
            this.txtCode.TabIndex = 46;
            // 
            // FrmCodeGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DotNet.WinForm.Properties.Resources.Head;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1133, 593);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.chkWCF);
            this.Controls.Add(this.chkTwoTier);
            this.Controls.Add(this.btnSearchPage);
            this.Controls.Add(this.btnSearchCode);
            this.Controls.Add(this.btnAdminPage);
            this.Controls.Add(this.btnAdminCode);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblFileName);
            this.Controls.Add(this.btnShowPage);
            this.Controls.Add(this.btnShowCode);
            this.Controls.Add(this.btnAddPage);
            this.Controls.Add(this.btnEditPage);
            this.Controls.Add(this.btnListPage);
            this.Controls.Add(this.btnTableColumns);
            this.Controls.Add(this.btnPdmDD);
            this.Controls.Add(this.btnIService);
            this.Controls.Add(this.rbzhCN);
            this.Controls.Add(this.rbenUS);
            this.Controls.Add(this.rbzhTW);
            this.Controls.Add(this.btnListCode);
            this.Controls.Add(this.btnEditCode);
            this.Controls.Add(this.btnAddCode);
            this.Controls.Add(this.btnService);
            this.Controls.Add(this.btnBuilder);
            this.Controls.Add(this.btnSaveCode);
            this.Controls.Add(this.chkOverwrite);
            this.Controls.Add(this.btnBuilderAll);
            this.Controls.Add(this.btnClearOutput);
            this.Controls.Add(this.btnClearDesign);
            this.Controls.Add(this.btnOutput);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.txtDesign);
            this.Controls.Add(this.lblDesign);
            this.Controls.Add(this.btnBuilderManager);
            this.Controls.Add(this.btnDesign);
            this.Controls.Add(this.lblTables);
            this.Controls.Add(this.lbxTables);
            this.Controls.Add(this.btnCopyCode);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.lblClassName);
            this.Controls.Add(this.btnBuilderTable);
            this.Controls.Add(this.txtDateCreated);
            this.Controls.Add(this.lblDateCreated);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.lblAuthor);
            this.Controls.Add(this.txtYearCreated);
            this.Controls.Add(this.lblYearCreated);
            this.Controls.Add(this.txtProject);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBuilderEntity);
            this.Controls.Add(this.txtCode);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCodeGenerator";
            this.ShowInTaskbar = true;
            this.Text = "C# 代码批量生成器 V3.7";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmCodeGenerator_FormClosing);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.Button btnBuilderEntity;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.TextBox txtProject;
        private System.Windows.Forms.Label lblProject;
        private System.Windows.Forms.TextBox txtYearCreated;
        private System.Windows.Forms.Label lblYearCreated;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.TextBox txtDateCreated;
        private System.Windows.Forms.Label lblDateCreated;
        private System.Windows.Forms.Button btnBuilderTable;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.Button btnCopyCode;
        private System.Windows.Forms.ListBox lbxTables;
        private System.Windows.Forms.Label lblTables;
        private System.Windows.Forms.Button btnDesign;
        private System.Windows.Forms.Button btnBuilderManager;
        private System.Windows.Forms.Label lblDesign;
        private System.Windows.Forms.TextBox txtDesign;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Button btnOutput;
        private System.Windows.Forms.Button btnClearDesign;
        private System.Windows.Forms.Button btnClearOutput;
        private System.Windows.Forms.Button btnBuilderAll;
        private System.Windows.Forms.CheckBox chkOverwrite;
        private System.Windows.Forms.Button btnSaveCode;
        private System.Windows.Forms.Button btnBuilder;
        private System.Windows.Forms.Button btnService;
        private System.Windows.Forms.Button btnAddCode;
        private System.Windows.Forms.Button btnEditCode;
        private System.Windows.Forms.Button btnListCode;
        private UcCodeView txtCode;
        private System.Windows.Forms.RadioButton rbzhCN;
        private System.Windows.Forms.RadioButton rbenUS;
        private System.Windows.Forms.RadioButton rbzhTW;
        private System.Windows.Forms.Button btnIService;
        private System.Windows.Forms.Button btnPdmDD;
        private System.Windows.Forms.Button btnTableColumns;
        private System.Windows.Forms.Button btnListPage;
        private System.Windows.Forms.Button btnEditPage;
        private System.Windows.Forms.Button btnAddPage;
        private System.Windows.Forms.Button btnShowPage;
        private System.Windows.Forms.Button btnShowCode;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Button btnAdminPage;
        private System.Windows.Forms.Button btnAdminCode;
        private System.Windows.Forms.Button btnSearchPage;
        private System.Windows.Forms.Button btnSearchCode;
        private System.Windows.Forms.CheckBox chkTwoTier;
        private System.Windows.Forms.CheckBox chkWCF;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton rbtnWorkFlow;
        private System.Windows.Forms.RadioButton rbtnBusiness;
        private System.Windows.Forms.RadioButton rbtnUserCenter;
    }
}

