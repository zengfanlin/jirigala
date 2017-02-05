using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// FrmImportStaff
    /// 员工数据批量导入Excel
    /// 
    /// 修改纪录
    /// 2012.04.24 版本：1.0 HLD  员工数据批量导入Excel页面编写。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>HLD</name>
    ///		<date>2012.04.24</date>
    /// </author>
    public partial class FrmImportStaff : BaseForm
    {
        private DataTable dt1 = new DataTable();
        private DataTable dt2 = new DataTable();
        private DataTable dt = new DataTable();
        ImportUtil importUtil = new ImportUtil();
        List<BaseStaffEntity> staffs = new List<BaseStaffEntity>();
        BaseStaffManager userManager = new BaseStaffManager();
        string checkMessage = string.Empty;
        private Dictionary<string, string> dataTable2ExcelField = null;

        // 未导入成功条数
        int importFailNum = 0;

        // 模板中必须有的列
        private string[] needExistColumnName = { "编号" };

        public FrmImportStaff(Dictionary<string, string> dt2ef)
        {
            this.dataTable2ExcelField = dt2ef;
            InitializeComponent();
        }

        #region private void Init() 操作前得初始化
        /// <summary>
        /// 操作前初始化
        /// </summary>
        private void Init()
        {
            dt1.Clear();
            dt1.Columns.Clear();
            dt2.Clear();
            dt2.Columns.Clear();
            this.grdStaff.Columns.Clear();
            this.grdStaff.DataSource = null;
        }
        #endregion

        private void btnDownload_Click(object sender, EventArgs e)
        {
            DownloadTemplate.DownloadExcelTemplate("ImportUserTemplate");
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            Init();
            string fileName = OpenExcelFile();
            this.txtFile1.Text = fileName;
            if (!string.IsNullOrEmpty(fileName))
            {
                dt1 = LoadData(fileName);
            }
            bool returnMessage = CheckInput();
            dt = dt1;
            if (!returnMessage)
            {
                btnImport.Enabled = false;
                if (MessageBox.Show(returnMessage + " 是否继续预览导入数据", AppMessage.MSG0000, MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    this.grdStaff.DataSource = dt1;
                }
            }
            else
            {
                btnImport.Enabled = true;
                this.grdStaff.DataSource = dt1;
            }
            //btnBrowse2.Enabled = true;
            this.Cursor = Cursors.Default;
        }

        //private void btnBrowse2_Click(object sender, EventArgs e)
        //{
        //    string fileName = OpenExcelFile();
        //    this.txtFile1.Text = fileName;
        //    if (!string.IsNullOrEmpty(fileName))
        //    {
        //        dt2 = LoadData(fileName);
        //    }
        //    bool returnMessage = CheckInput();
        //    if (!returnMessage)
        //    {
        //        MessageBox.Show("缺少必要的字段，无法导入");
        //        return;
        //    }
            
        //}

        private void Merge()
        {

        }

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

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInput()
        {
            bool returnValue = true;
            checkMessage = string.Empty;
            string columnNames = DataTableColumn2String(dt);
            foreach (string element in needExistColumnName)
            {
                checkMessage += CheckColumnExist(element, columnNames);
            }
            if (string.IsNullOrEmpty(checkMessage))
            {
                checkMessage += CheckIsNullOrEmpty(dt, needExistColumnName);
                //foreach (DataRow dr in dt.Rows)
                //{
                //    if (!(dr["性别".ToLower()].ToString() == "男" || dr["性别".ToLower()].ToString() == "女"))
                //    {
                //        checkMessage += "性别只能填《男》或者《女》";
                //    }
                //    string roleId = DotNetService.Instance.RoleService.GetDataTableByRoleName(UserInfo, dr["默认角色".ToLower()].ToString()).Rows[0][BaseRoleEntity.FieldId].ToString().Trim();
                //    if (string.IsNullOrEmpty(roleId))
                //    {
                //        checkMessage += " " + dr["默认角色".ToLower()].ToString() + "　没有对应的默认角色信息";
                //    }
                //    string companyId = DotNetService.Instance.OrganizeService.GetCompanyDTByName(UserInfo, dr["公司名称".ToLower()].ToString()).Rows[0][BaseOrganizeEntity.FieldId].ToString().Trim();
                //    if (string.IsNullOrEmpty(companyId))
                //    {
                //        checkMessage += " " + dr["公司名称".ToLower()].ToString() + "　没有对应的公司名称信息";
                //    }
                //    string departmentId = DotNetService.Instance.OrganizeService.GetDepartmentDTByName(UserInfo, dr["部门名称".ToLower()].ToString()).Rows[0][BaseOrganizeEntity.FieldId].ToString().Trim();
                //    if (string.IsNullOrEmpty(departmentId))
                //    {
                //        checkMessage += " " + dr["部门名称".ToLower()].ToString() + "　没有对应的部门名称信息";
                //    }
                //}
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
                        dt.Rows[j]["错误信息".ToLower()] = returnValue;
                    }
                }
            }
            return returnValue.ToString();
        }
        #endregion

        #region private DataTable LoadData(string fileName) 读取Excel中的数据到DataTable
        /// <summary>
        /// 读取Excel中的数据到DataTable
        /// </summary>
        /// <param name="strFileName">fileName</param>
        private DataTable LoadData(string fileName)
        {
            try
            {
                return importUtil.ImportExcel(fileName);
            }
            catch
            {
                //importUtil.ReturnMessage
                return null;
            }
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
            }
            return fileName;
        }
        #endregion

        #region public List<BaseStaffEntity> Convert2StaffEntitys(DataTable dt) DataTable转换成StaffEntity
        public List<BaseStaffEntity> Convert2StaffEntitys(DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                int tempint = 0;
                BaseStaffEntity staff = new BaseStaffEntity();
                staff.Age = dr[dataTable2ExcelField["Age".ToLower()]].ToString();
                staff.BankCode = dr[dataTable2ExcelField["BankCode".ToLower()]].ToString();
                staff.Birthday = dr[dataTable2ExcelField["Birthday".ToLower()]].ToString();
                staff.CarCode = dr[dataTable2ExcelField["CarCode".ToLower()]].ToString();
                staff.Code = dr[dataTable2ExcelField["Code".ToLower()]].ToString();
                staff.CompanyId = dr[dataTable2ExcelField["CompanyId".ToLower()]].ToString();
                staff.Competency = dr[dataTable2ExcelField["Competency".ToLower()]].ToString();
                staff.CreateBy = dr[dataTable2ExcelField["CreateBy".ToLower()]].ToString();
                staff.CreateOn = Convert.ToDateTime(dr[dataTable2ExcelField["CreateOn".ToLower()]]);
                staff.CreateUserId = dr[dataTable2ExcelField["CreateUserId".ToLower()]].ToString();
                staff.Degree = dr[dataTable2ExcelField["Degree".ToLower()]].ToString();
                staff.DeletionStateCode = Convert.ToInt32(dr[dataTable2ExcelField["DeletionStateCode".ToLower()]]);
                staff.DepartmentId = dr[dataTable2ExcelField["DepartmentId".ToLower()]].ToString();
                staff.Description = dr[dataTable2ExcelField["Description".ToLower()]].ToString();
                staff.DimissionCause = dr[dataTable2ExcelField["DimissionCause".ToLower()]].ToString();
                staff.DimissionDate = dr[dataTable2ExcelField["DimissionDate".ToLower()]].ToString();
                staff.DimissionWhither = dr[dataTable2ExcelField["DimissionWhither".ToLower()]].ToString();
                staff.DutyId = dr[dataTable2ExcelField["DutyId".ToLower()]].ToString();
                staff.Education = dr[dataTable2ExcelField["Education".ToLower()]].ToString();
                staff.Email = dr[dataTable2ExcelField["Email".ToLower()]].ToString();
                staff.EmergencyContact = dr[dataTable2ExcelField["EmergencyContact".ToLower()]].ToString();
                staff.Enabled = Convert.ToInt32(dr[dataTable2ExcelField["Enabled".ToLower()]]);
                staff.Gender = dr[dataTable2ExcelField["Gender".ToLower()]].ToString();
                staff.GraduationDate = dr[dataTable2ExcelField["GraduationDate".ToLower()]].ToString();
                staff.HomeAddress = dr[dataTable2ExcelField["HomeAddress".ToLower()]].ToString();
                staff.HomeFax = dr[dataTable2ExcelField["HomeFax".ToLower()]].ToString();
                staff.HomePhone = dr[dataTable2ExcelField["HomePhone".ToLower()]].ToString();
                staff.HomeZipCode = dr[dataTable2ExcelField["HomeZipCode".ToLower()]].ToString();
                staff.Id = Convert.ToInt32(dr[dataTable2ExcelField["Id".ToLower()]]);
                staff.IDCard = dr[dataTable2ExcelField["IdCard".ToLower()]].ToString();
                staff.IdentificationCode = dr[dataTable2ExcelField["IdentificationCode".ToLower()]].ToString();
                if(int.TryParse(dr[dataTable2ExcelField["IsDimission".ToLower()]].ToString(),out tempint))
                    staff.IsDimission = tempint;
                
                staff.JoinInDate = dr[dataTable2ExcelField["JoinInDate".ToLower()]].ToString();
                staff.Major = dr[dataTable2ExcelField["Major".ToLower()]].ToString();
                staff.Mobile = dr[dataTable2ExcelField["Mobile".ToLower()]].ToString();
                staff.ModifiedBy = dr[dataTable2ExcelField["ModifiedBy".ToLower()]].ToString();
                staff.ModifiedOn = Convert.ToDateTime(dr[dataTable2ExcelField["ModifiedOn".ToLower()]]);
                staff.ModifiedUserId = dr[dataTable2ExcelField["ModifiedUserId".ToLower()]].ToString();
                staff.Nation = dr[dataTable2ExcelField["Nation".ToLower()]].ToString();
                staff.Nationality = dr[dataTable2ExcelField["Nationality".ToLower()]].ToString();
                staff.NativePlace = dr[dataTable2ExcelField["NativePlace".ToLower()]].ToString();
                staff.OfficeAddress = dr[dataTable2ExcelField["OfficeAddress".ToLower()]].ToString();
                staff.OfficeFax = dr[dataTable2ExcelField["OfficeFax".ToLower()]].ToString();
                staff.OfficePhone = dr[dataTable2ExcelField["OfficePhone".ToLower()]].ToString();
                staff.OfficeZipCode = dr[dataTable2ExcelField["OfficeZipCode".ToLower()]].ToString();
                staff.OICQ = dr[dataTable2ExcelField["OICQ".ToLower()]].ToString();
                staff.Party = dr[dataTable2ExcelField["Party".ToLower()]].ToString();
                staff.RealName = dr[dataTable2ExcelField["RealName".ToLower()]].ToString();
                staff.School = dr[dataTable2ExcelField["School".ToLower()]].ToString();
                staff.ShortNumber = dr[dataTable2ExcelField["ShortNumber".ToLower()]].ToString();
                staff.SortCode = Convert.ToInt32(dr[dataTable2ExcelField["SortCode".ToLower()]]);
                staff.Telephone = dr[dataTable2ExcelField["Telephone".ToLower()]].ToString();
                staff.TitleDate = dr[dataTable2ExcelField["TitleDate".ToLower()]].ToString();
                staff.TitleId = dr[dataTable2ExcelField["TitleId".ToLower()]].ToString();
                staff.TitleLevel = dr[dataTable2ExcelField["TitleLevel".ToLower()]].ToString();
                tempint = Convert.ToInt32(dr[dataTable2ExcelField["UserId".ToLower()]]);
                if (tempint > 0)
                    staff.UserId = tempint;

                staff.UserName = dr[dataTable2ExcelField["UserName".ToLower()]].ToString();
                staff.WorkgroupId = dr[dataTable2ExcelField["WorkgroupId".ToLower()]].ToString();
                staff.WorkingDate = dr[dataTable2ExcelField["WorkingDate".ToLower()]].ToString();
                staff.WorkingProperty = dr[dataTable2ExcelField["WorkingProperty".ToLower()]].ToString();
                staffs.Add(staff);
                //user.Code = dr["编号".ToLower()].ToString().Trim();
                //user.RealName = dr["姓名".ToLower()].ToString().Trim();
                //user.UserName = dr["登录名".ToLower()].ToString().Trim();
                //user.QuickQuery = dr["快速查询".ToLower()].ToString().Trim();
                //user.RoleId = DotNetService.Instance.RoleService.GetDataTableByRoleName(UserInfo, dr["默认角色".ToLower()].ToString()).Rows[0][BaseRoleEntity.FieldId].ToString().Trim();
                //user.WorkCategory = dr["工作行业".ToLower()].ToString().Trim();
                //user.CompanyId = DotNetService.Instance.OrganizeService.GetCompanyDTByName(UserInfo, dr["公司名称".ToLower()].ToString()).Rows[0][BaseOrganizeEntity.FieldId].ToString().Trim();
                //user.CompanyName = dr["公司名称".ToLower()].ToString().Trim();
                //user.DepartmentId = DotNetService.Instance.OrganizeService.GetDepartmentDTByName(UserInfo, dr["部门名称".ToLower()].ToString()).Rows[0][BaseOrganizeEntity.FieldId].ToString().Trim();
                //user.DepartmentName = dr["部门名称".ToLower()].ToString().Trim();
                //user.Gender = dr["性别".ToLower()].ToString().Trim();
                //user.Mobile = dr["手机".ToLower()].ToString().Trim();
                //user.Telephone = dr["电话号码".ToLower()].ToString().Trim();
                //user.Birthday = dr["出生日期".ToLower()].ToString().Trim();
                //user.Duty = dr["岗位".ToLower()].ToString().Trim();
                //user.Title = dr["职称".ToLower()].ToString().Trim();
                //user.UserPassword = dr["用户密码".ToLower()].ToString().Trim();
                //user.OICQ = dr["QQ号码".ToLower()].ToString().Trim();
                //user.Email = dr["电子邮件".ToLower()].ToString().Trim();
                //user.Description = dr["描述".ToLower()].ToString().Trim();
                //users.Add(user);
            }
            return staffs;
        }
        #endregion

        private void btnImport_Click(object sender, EventArgs e)
        {
            string statusCode = string.Empty;
            string statusMessage = string.Empty;
            staffs = Convert2StaffEntitys(dt);
            this.pbImport.Minimum = 0;//进度条最小值
            this.pbImport.Maximum = staffs.Count;//进度条最大值
            this.pbImport.Step = 1;//步进值
            DotNetService dotNetService = new DotNetService();
            dt.Columns.Add(new DataColumn("错误信息"));
            for (int i = 0; i < staffs.Count; i++)
            {
                this.pbImport.Value = i + 1;
                this.grbImport.Text = "导入进度(" + ((i + 1) / staffs.Count) * 100 + "%)";
                //if (dotNetService.StaffService.GetEntity(UserInfo, staffs[i].Id.ToString()) == null)
                    dotNetService.StaffService.AddStaff(UserInfo, staffs[i], out statusCode, out statusMessage);
                //else
                //    dotNetService.StaffService.UpdateStaff(UserInfo, staffs[i], out statusCode, out statusMessage);
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
                grdStaff.DataSource = dt;
            }
            btnImport.Enabled = false;
        }
    }
}
