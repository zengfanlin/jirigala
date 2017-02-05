//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmImportUser
    /// 用户数据批量导入Excel
    /// 
    /// 修改纪录
    /// 2012.04.24 版本：1.0 JChan  用户数据批量导入Excel页面编写。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JChan</name>
    ///		<date>2012.04.24</date>
    /// </author>
    public partial class FrmImportUser : BaseForm
    {
        private DataTable dt = new DataTable();
        ImportUtil importUtil = new ImportUtil();
        List<BaseUserEntity> users = new List<BaseUserEntity>();
        BaseUserManager userManager = new BaseUserManager();
        string checkMessage = string.Empty;

        // 未导入成功条数
        int importFailNum = 0;

        // 模板中必须有的列
        private string[] needExistColumnName = { "编号", "登录名", "姓名", "默认角色", "公司名称", "部门名称" };

        /// <summary>
        /// Excel列名与BaseUserTable对应数组（Excel列名、BaseUserTable列名）
        /// </summary>
        string[,] columnMapping = {
                                    {"编号", "Code"},
                                    {"登录名", "UserName"},
                                    {"姓名", "Realname"},
                                    {"快速查询", "QuickQuery"}
                                  };

        public FrmImportUser()
        {
            InitializeComponent();
        }

        #region private void Init() 操作前得初始化
        /// <summary>
        /// 操作前初始化
        /// </summary>
        private void Init()
        {
            dt.Clear();
            dt.Columns.Clear();
            this.grdUser.Columns.Clear();
            this.grdUser.DataSource = null;
        }
        #endregion

        #region private string OpenExcelFile() 打开Excel文件
        /// <summary>
        /// 打开Excel文件
        /// </summary>
        /// <returns>文件名称</returns>
        private string OpenExcelFile()
        {
            string fileName = string.Empty;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel2003文件(*.xls)|*.xls|Excel2010文件(*.xlsx)|*.xlsx|所有文件|*.*";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Title = "选择要导入的EXCEL文件";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
                this.txtFile.Text = fileName;
            }
            return fileName;
        }
        #endregion

        #region public List<BaseUserEntity> Convert2UserEntitys(DataTable dt) DataTable转换成UserEntity
        public List<BaseUserEntity> Convert2UserEntitys(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                BaseUserEntity user = new BaseUserEntity();
                user.Code = dr["编号"].ToString().Trim();
                user.RealName = dr["姓名"].ToString().Trim();
                user.UserName = dr["登录名"].ToString().Trim();
                user.QuickQuery = dr["快速查询"].ToString().Trim();
                user.RoleId = DotNetService.Instance.RoleService.GetDataTableByRoleName(UserInfo, dr["默认角色"].ToString()).Rows[0][BaseRoleEntity.FieldId].ToString().Trim();
                user.WorkCategory = dr["工作行业"].ToString().Trim();
                user.CompanyId = DotNetService.Instance.OrganizeService.GetCompanyDTByName(UserInfo, dr["公司名称"].ToString()).Rows[0][BaseOrganizeEntity.FieldId].ToString().Trim();
                user.CompanyName = dr["公司名称"].ToString().Trim();
                user.DepartmentId = DotNetService.Instance.OrganizeService.GetDepartmentDTByName(UserInfo, dr["部门名称"].ToString()).Rows[0][BaseOrganizeEntity.FieldId].ToString().Trim();
                user.DepartmentName = dr["部门名称"].ToString().Trim();
                user.Gender = dr["性别"].ToString().Trim();
                user.Mobile = dr["手机"].ToString().Trim();
                user.Telephone = dr["电话号码"].ToString().Trim();
                user.Birthday = dr["出生日期"].ToString().Trim();
                user.Duty = dr["岗位"].ToString().Trim();
                user.Title = dr["职称"].ToString().Trim();
                user.UserPassword = dr["用户密码"].ToString().Trim();
                user.OICQ = dr["QQ号码"].ToString().Trim();
                user.Email = dr["电子邮件"].ToString().Trim();
                user.Description = dr["描述"].ToString().Trim();
                users.Add(user);
            }
            return users;
        }
        #endregion

        #region private DataTable LoadData(string fileName) 读取Excel中的数据到DataTable
        /// <summary>
        /// 读取Excel中的数据到DataTable
        /// </summary>
        /// <param name="strFileName">fileName</param>
        private void LoadData(string fileName)
        {
            try
            {
                dt = importUtil.ImportExcel(fileName);
            }
            catch
            {
                //importUtil.ReturnMessage
            }
        }
        #endregion

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInput()
        {
            bool returnValue = true;
            checkMessage = string.Empty;
            string columnNames = DataTableColumn2String(this.dt);
            foreach (string element in needExistColumnName)
            {
                checkMessage += CheckColumnExist(element, columnNames);
            }
            if (string.IsNullOrEmpty(checkMessage))
            {
                checkMessage += CheckIsNullOrEmpty(dt, needExistColumnName);
                foreach (DataRow dr in dt.Rows)
                {
                    if (!(dr["性别"].ToString() == "男" || dr["性别"].ToString() == "女"))
                    {
                        checkMessage += "性别只能填《男》或者《女》";
                    }
                    string roleId = DotNetService.Instance.RoleService.GetDataTableByRoleName(UserInfo, dr["默认角色"].ToString()).Rows[0][BaseRoleEntity.FieldId].ToString().Trim();
                    if (string.IsNullOrEmpty(roleId))
                    {
                        checkMessage += " " + dr["默认角色"].ToString() + "　没有对应的默认角色信息";
                    }
                    string companyId = DotNetService.Instance.OrganizeService.GetCompanyDTByName(UserInfo, dr["公司名称"].ToString()).Rows[0][BaseOrganizeEntity.FieldId].ToString().Trim();
                    if (string.IsNullOrEmpty(companyId))
                    {
                        checkMessage += " " + dr["公司名称"].ToString() + "　没有对应的公司名称信息";
                    }
                    string departmentId = DotNetService.Instance.OrganizeService.GetDepartmentDTByName(UserInfo, dr["部门名称"].ToString()).Rows[0][BaseOrganizeEntity.FieldId].ToString().Trim();
                    if (string.IsNullOrEmpty(departmentId))
                    {
                        checkMessage += " " + dr["部门名称"].ToString() + "　没有对应的部门名称信息";
                    }
                }
            }
            return returnValue;
        }
        #endregion

        #region private string CheckColumnExist(string columnNames, string needCheckColumnName) 判断是否存在这一列
        /// <summary>
        /// 判断是否存在这一列
        /// </summary>
        /// <param name="columnNames">当前存在的列组</param>
        /// <param name="needCheckColumnNames">要求的列名组</param>
        /// <returns>提示信息</returns>
        public string CheckColumnExist(string columnNames, string needCheckColumnName)
        {
            string returnValue = string.Empty;
            if (!needCheckColumnName.Contains(columnNames))
            {
                returnValue += "\"" + columnNames + "\"这一列不存在，需添加此列。\r\n";
            }
            return returnValue;
        }
        #endregion

        #region public StringBuilder CheckIsNullOrEmpty(DataTable dt, string checkStrings) 判断是选中段的值否为空
        /// <summary>
        /// 判断是选中段的值否为空
        /// </summary>
        /// <param name="dr">DataTable</param>
        /// <param name="checkStrings">检查的字段串</param>
        /// <returns>返回提示</returns>
        public string CheckIsNullOrEmpty(DataTable dt, string[] checkStrings)
        {
            StringBuilder returnValue = new StringBuilder();
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                for (int i = 0; i < checkStrings.Length; i++)
                {
                    if (string.IsNullOrEmpty(dt.Rows[j][checkStrings[i]].ToString()))
                    {
                        returnValue.Append("\"" + checkStrings[i] + "\"不能为空。");
                        dt.Rows[j]["错误信息"] = returnValue;
                    }
                }
            }
            return returnValue.ToString();
        }
        #endregion

        #region public string DataTableColumn2String(DataTable dt)DataTable列转换成字符串
        /// <summary>
        /// DataTable列转换成字符串
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <returns>转换后的字符串</returns>
        public string DataTableColumn2String(DataTable dt)
        {
            StringBuilder ColumnNames = new StringBuilder();
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (i > 0)
                {
                    ColumnNames.Append(",");
                }
                ColumnNames.Append(dt.Columns[i].ColumnName);
            }
            return ColumnNames.ToString();
        }
        #endregion

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            Init();
            OpenExcelFile();
            if (!string.IsNullOrEmpty(this.txtFile.Text.Trim()))
            {
                LoadData(txtFile.Text.Trim());
            }
            bool returnMessage = CheckInput();
            if (!returnMessage)
            {
                btnImport.Enabled = false;
                if (MessageBox.Show(returnMessage + " 是否继续预览导入数据", AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    this.grdUser.DataSource = dt;
                }
            }
            else
            {
                btnImport.Enabled = true;
                this.grdUser.DataSource = dt;
            }
            this.Cursor = Cursors.Default;
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DownloadTemplate.DownloadExcelTemplate("ImportUserTemplate");
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            users = Convert2UserEntitys(dt);
            this.pbImport.Minimum = 0;//进度条最小值
            this.pbImport.Maximum = users.Count;//进度条最大值
            this.pbImport.Step = 1;//步进值
            for (int i = 0; i < users.Count; i++)
            {
                this.pbImport.Value = i + 1;
                this.grbImport.Text = "导入进度(" + ((i + 1) / users.Count) * 100 + "%)";
                DotNetService.Instance.UserService.AddUser(UserInfo, users[i], out statusCode, out statusMessage);
                // 是否编号重复了，提高友善性
                if (statusCode != StatusCode.OKAdd.ToString())
                {
                    importFailNum = importFailNum + 1;
                    if (statusCode == StatusCode.ErrorCodeExist.ToString())
                    {
                        dt.Rows[i]["错误信息"] = "用户编码存在";
                    }
                    if (statusCode == StatusCode.ErrorUserExist.ToString())
                    {
                        dt.Rows[i]["错误信息"] = "用户存在";
                    }
                }
                this.grbImport.Text = "导入完成(其中" + importFailNum + "条未成功导入)";
                grdUser.DataSource = dt;
            }
            btnImport.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
