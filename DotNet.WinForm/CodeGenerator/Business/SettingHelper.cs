//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

namespace DotNet.WinForm
{
    /// <summary>
    ///	SettingHelper
    /// 配置器助手
    /// 
    /// 修改纪录
    /// 
    ///		2008.08.06 版本：1.0    吉日嘎拉创建。
    ///	
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.08.06</date>
    /// </author> 
    /// </summary>
    public class SettingHelper
    {
        public string Company = string.Empty;
        public string Project = string.Empty;
        public string Author = string.Empty;
        public string Design = string.Empty;
        public string Output = string.Empty;
        public bool Overwrite = true;
        public string CurrentDb = string.Empty;
        private string p;
        private string p_2;
        private string p_3;
        private string p_4;
        private string p_5;
        private FrmCodeGenerator frmCodeGenerator;
        private string p_6;
        private bool p_7;

        public SettingHelper()
        {
        }

        public SettingHelper(string company, string project, string author, string design, string output, string currentDb, bool overwrite) : this()
        {
            this.Company = company;
            this.Project = project;
            this.Author = author;
            this.Design = design;
            this.Output = output;
            this.CurrentDb = currentDb;
            this.Overwrite = overwrite;
        }

        public SettingHelper(string p, string p_2, string p_3, string p_4, string p_5, FrmCodeGenerator frmCodeGenerator, string p_6, bool p_7)
        {
            // TODO: Complete member initialization
            this.p = p;
            this.p_2 = p_2;
            this.p_3 = p_3;
            this.p_4 = p_4;
            this.p_5 = p_5;
            this.frmCodeGenerator = frmCodeGenerator;
            this.p_6 = p_6;
            this.p_7 = p_7;
        }

        #region public void GetSetting() 读取配置文件
        /// <summary>
        /// 读取配置文件
        /// </summary>
        public void GetSetting()
        {
            this.Company = Properties.Settings.Default.Company;
            this.Project = Properties.Settings.Default.Project;
            this.Author = Properties.Settings.Default.Author;
            this.Design = Properties.Settings.Default.Design;
            this.Output = Properties.Settings.Default.Output;
            this.CurrentDb = Properties.Settings.Default.CurrentDb;
            this.Overwrite = Properties.Settings.Default.Overwrite;
        }
        #endregion

        public void SaveSetting(string company, string project, string author, string design, string output, string currentDb, bool overwrite)
        {
            this.Company = company;
            this.Project = project;
            this.Author = author;
            this.Design = design;
            this.Output = output;
            this.CurrentDb = currentDb;
            this.Overwrite = overwrite;
            // 保存配置文件
            this.SaveSetting();
        }

        #region public void SaveSetting() 保存配置文件
        /// <summary>
        /// 保存配置文件
        /// </summary>
        public void SaveSetting()
        {
            Properties.Settings.Default.Company = this.Company;
            Properties.Settings.Default.Project = this.Project;
            Properties.Settings.Default.Author = this.Author;
            Properties.Settings.Default.Output = this.Output;
            Properties.Settings.Default.Design = this.Design;
            Properties.Settings.Default.CurrentDb = this.CurrentDb;
            Properties.Settings.Default.Overwrite = this.Overwrite;
            Properties.Settings.Default.Save();
        }
        #endregion

        #region public bool Equals(SettingHelper SettingHelper) 判断配置类实体是否相等
        /// <summary>
        /// 判断配置类实体是否相等
        /// </summary>
        /// <param name="SettingHelper">目标配置类</param>
        /// <returns>相等</returns>
        public bool Equals(SettingHelper SettingHelper)
        {
            if (!SettingHelper.Company.Equals(this.Company))
            {
                return false;
            }
            if (!SettingHelper.Project.Equals(this.Project))
            {
                return false;
            }
            if (!SettingHelper.Author.Equals(this.Author))
            {
                return false;
            }
            if (!SettingHelper.Design.Equals(this.Design))
            {
                return false;
            }
            if (!SettingHelper.Output.Equals(this.Output))
            {
                return false;
            }
            if (!SettingHelper.CurrentDb.Equals(this.CurrentDb))
            {
                return false;
            }
            if (!SettingHelper.Overwrite.Equals(this.Overwrite))
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}