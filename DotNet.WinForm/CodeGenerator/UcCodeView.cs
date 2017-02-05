//-----------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------

using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;

namespace DotNet.WinForm
{

    public class UcCodeView : UserControl
    {
        private IContainer components;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem menu_Save;
        public TextEditorControl txtContent;
        private string Type = "CS";

        public UcCodeView()
        {
            this.InitializeComponent();
            this.txtContent.Document.DocumentChanged += new DocumentEventHandler(Document_DocumentChanged);
            this.SettxtContent("CS", "");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcCodeView));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.txtContent = new ICSharpCode.TextEditor.TextEditorControl();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_Save});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 26);
            // 
            // menu_Save
            // 
            this.menu_Save.Name = "menu_Save";
            this.menu_Save.Size = new System.Drawing.Size(112, 22);
            this.menu_Save.Text = "保存(&S)";
            this.menu_Save.Click += new System.EventHandler(this.menu_Save_Click);
            // 
            // txtContent
            // 
            this.txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtContent.Encoding = ((System.Text.Encoding)(resources.GetObject("txtContent.Encoding")));
            this.txtContent.Location = new System.Drawing.Point(0, 0);
            this.txtContent.Name = "txtContent";
            this.txtContent.ShowEOLMarkers = true;
            this.txtContent.ShowSpaces = true;
            this.txtContent.ShowTabs = true;
            this.txtContent.ShowVRuler = true;
            this.txtContent.Size = new System.Drawing.Size(790, 415);
            this.txtContent.TabIndex = 1;
            this.txtContent.VRulerRow = 5000;
            // 
            // UcCodeView
            // 
            this.Controls.Add(this.txtContent);
            this.Name = "UcCodeView";
            this.Size = new System.Drawing.Size(790, 415);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void menu_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "保存当前代码";
            string text = "";
            if (this.Type == "CS")
            {
                dialog.Filter = "C# files (*.cs)|*.cs|All files (*.*)|*.*";
                text = this.txtContent.Text;
            }
            if (this.Type == "SQL")
            {
                dialog.Filter = "SQL files (*.sql)|*.cs|All files (*.*)|*.*";
                text = this.txtContent.Text;
            }
            if (this.Type == "Aspx")
            {
                dialog.Filter = "Aspx files (*.aspx)|*.cs|All files (*.*)|*.*";
                text = this.txtContent.Text;
            }
            if (this.Type == "XML")
            {
                dialog.Filter = "Aspx files (*.xml)|*.xml|All files (*.*)|*.*";
                text = this.txtContent.Text;
            }
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(dialog.FileName, false, Encoding.Default);
                writer.Write(text);
                writer.Flush();
                writer.Close();
            }
        }

        private string GetTypeName(string Type)
        {
            string ReturnValue = String.Empty;
            switch (Type)
            {
                case "SQL":
                    ReturnValue = "SQL";
                    break;
                case "CS":
                    ReturnValue = "C#";
                    break;
                case "Aspx":
                    ReturnValue = "HTML";
                    break;
                case "XML":
                    ReturnValue = "XML";
                    break;
                default:
                    ReturnValue = "C#";
                    break;
            }
            return ReturnValue;
        }

        public void SettxtContent(string Type, string strContent)
        {
            this.Type = Type;
            this.txtContent.Encoding = System.Text.Encoding.Default;
            this.txtContent.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy(GetTypeName(Type));
            this.txtContent.ShowEOLMarkers = false;
            this.txtContent.ShowSpaces = false;
            this.txtContent.ShowTabs = false;

            this.txtContent.ShowInvalidLines = false;
            this.txtContent.LineViewerStyle = LineViewerStyle.FullRow;

            this.txtContent.Text = strContent;
        }

        private void Document_DocumentChanged(object sender, DocumentEventArgs e)
        {
            this.txtContent.Document.FoldingManager.FoldingStrategy = new RegionFoldingStrategy();
            this.txtContent.Document.FoldingManager.UpdateFoldings(null, null);
        }
    }
}