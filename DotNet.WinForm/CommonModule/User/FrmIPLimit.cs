
//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;

namespace DotNet.WinForm
{
    using DotNet.Business;
    using DotNet.Utilities;
    

    /// <summary>
    /// FrmIPLimit.cs
    /// 权限管理-IP，MAC地址登录限制
    ///		
    /// 修改记录
    ///
    ///     2011.07.04 版本：1.0 zgl  用户按IP地址限制。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>zgl</name>
    ///		<date>2011.07.04</date>
    /// </author> 
    /// </summary>    
    public partial class FrmIpLimit : BaseForm
    {
        /// <summary>
        /// 定义UserCenterDbHelper
        /// </summary>
        string connectionString = BaseSystemInfo.UserCenterDbConnection;
        private IDbHelper UserCenterDbHelper = null;
        
        /// <summary>
        /// 用户管理
        /// </summary>
        private DataTable DTUser = new DataTable(BaseUserEntity.TableName);
        /// <summary>
        /// IP地址
        /// </summary>
        private DataTable DTIp = new DataTable("DtIp");
        /// <summary>
        /// Mac地址
        /// </summary>
        private DataTable DTMac = new DataTable("DtMac");


        // 目标用户主键
        private string TargetUserId
        {
            set
            {
                this.ucUser.SelectedId = value;
            }
            get
            {
                return this.ucUser.SelectedId;
            }
        }

        // 目标用户姓名     
        private string TargetName
        {
            set
            {
                this.ucUser.SelectedFullName = value;
            }
            get
            {
                return this.ucUser.SelectedFullName;
            }
        }


        private System.Windows.Forms.Control LastControl = null;   // 记录最后点击的控件

        public FrmIpLimit()
        {
            InitializeComponent();
        }
        public FrmIpLimit(BaseUserEntity userEntity)
            : this()
        {
            this.TargetUserId = userEntity.Id.ToString();
            this.TargetName = userEntity.RealName;
        }
        public FrmIpLimit(string userId, string fullName)
            : this()
        {
            this.TargetUserId = userId;
            this.TargetName = fullName;
        }

        #region public override void SetControlState() 设置控件状态
        /// <summary>
        /// 设置控件状态
        /// </summary>
        public override void SetControlState()
        {
            // 这里判断是否有数据被复制
            //object clipboardData = Clipboard.GetData("userPermission");
            //this.btnPaste.Enabled = (clipboardData != null);
        }
        #endregion

        #region public override bool CheckInput() 检查输入的有效性
        /// <summary>
        /// 检查输入的有效性
        /// </summary>
        /// <returns>有效</returns>
        public override bool CheckInput()
        {
            bool returnValue = false;

            // 符合ip正则表达式
            //ip地址正则表达式  ^((?:(?:25[0-5]|2[0-4]\d|[01]?\d?\d)\.){3}(?:25[0-5]|2[0-4]\d|[01]?\d?\d))$

            //ip地址段正则表达式 192.168.0.1-192.168.0.10  ： ^((?:(?:25[0-5]|2[0-4]\d|[01]?\d?\d)\.){3}(?:25[0-5]|2[0-4]\d|[01]?\d?\d))(?:([\\\-])((?:(?:25[0-5]|2[0-4]\d|[01]?\d?\d)\.){3}(?:25[0-5]|2[0-4]\d|[01]?\d?\d))$

            //带通配符的增则表达式  192.168.0.* :  ^(?:25[0-5]|2[0-4]\d|[01]?\d?\d\.){3}\*$

            //Mac 地址 正则表达式： ^\w{1,2}:\w{1,2}:\w{1,2}:\w{1,2}:\w{1,2}:\w{1,2}$


            if(!string.IsNullOrEmpty(this.txtIPAddress.Text.Trim()))
            {  
                string[] regexArr=new string[3];
                regexArr[0] = @"^((?:(?:25[0-5]|2[0-4]\d|[01]?\d?\d)\.){3}(?:25[0-5]|2[0-4]\d|[01]?\d?\d))$";
                regexArr[1] = @"^((?:[01]?\d{1,2}|2(?:[0-4]\d|5[0-5]))(?:\.(?:[01]?\d{1,2}|2(?:[0-4]\d|5[0-5]))){3})(?:([\\\-])((?:[01]?\d{1,2}|2(?:[0-4]\d|5[0-5]))(?:\.(?:[01]?\d{1,2}|2(?:[0-4]\d|5[0-5]))){3})|\\(0))$";
                regexArr[2] = @"^(?:25[0-5]|2[0-4]\d|[01]?\d?\d\.){3}\*$";
                 Regex ipRegex;
                for (int i = 0; i < regexArr.Length; i++)
                {
                    ipRegex=new Regex(regexArr[i]);

                    //如果有匹配则跳出循环
                    if (ipRegex.IsMatch(this.txtIPAddress.Text.Trim()))
                    {
                        returnValue= true;
                        break;
 
                    }
                }

                if (!returnValue)
                {
                   
                       
                        MessageBox.Show(AppMessage.MSG0052, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtIPAddress.Focus();
                        returnValue = false;
                }


            }
            if (!string.IsNullOrEmpty(this.txtMacAddress.Text.Trim()))
            {
                Regex macRegex = new Regex(@"^\w{1,2}-\w{1,2}-\w{1,2}-\w{1,2}-\w{1,2}-\w{1,2}$");
                if (!macRegex.IsMatch(this.txtMacAddress.Text.Trim()))
                {

                    MessageBox.Show(AppMessage.MSG0053, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtMacAddress.Focus();
                    returnValue = false;
                }
                else returnValue = true;
 
            }

            //添加时不能添加空数据
            if (string.IsNullOrEmpty(this.txtIPAddress.Text.Trim()) && string.IsNullOrEmpty(this.txtMacAddress.Text.Trim()))
            {
                MessageBox.Show(AppMessage.MSG0054, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //focus  txtIPAddr
                this.txtIPAddress.Focus();
                returnValue = false;

            }
           
            return returnValue;
        }
        #endregion

        #region private void CleanScreen() 清屏
        private void CleanScreen()
        {
            this.txtIPAddress.Text = "";
            this.txtMacAddress.Text = "";
 
        }
        #endregion
        
        #region public override void FormOnLoad() 加载窗体
        /// <summary>
        /// 加载窗体
        /// </summary>
        public override void FormOnLoad()
        {
            // 初始化UserCenterDbHelper
            this.UserCenterDbHelper = DbHelperFactory.GetHelper(CurrentDbType.SqlServer, this.connectionString);
            if (!string.IsNullOrEmpty(this.ucUser.SelectedId))
            {
                this.GetIpList(this.ucUser.SelectedId);
                this.GetMacList(this.ucUser.SelectedId);
            }
        }
        #endregion
      
        /// <summary>
        /// GetIpList 根据userId取得Ip，并绑定listIP
        /// </summary>
        /// <param name="userId"></param>
        private void GetIpList(string userId )
        {

            this.DTIp = DotNetService.Instance.ParameterService.GetDataTableByParameter(this.UserInfo, "IPAddress", userId);

            //只显示没有删除的数据
            //BaseBusinessLogic.SetFilter(this.DTIp, BaseParameterEntity.FieldDeletionStateCode, "0", false);
            this.DTIp.DefaultView.Sort = BaseParameterEntity.FieldSortCode;
            this.cklstIp.DataSource = this.DTIp.DefaultView;
            this.cklstIp.ValueMember = BaseParameterEntity.FieldId;
            this.cklstIp.DisplayMember = BaseParameterEntity.FieldParameterContent;
            //清除默认选择
            this.cklstIp.SelectedItems.Clear();
        }
        /// <summary>
        /// GetMacList 根据userId取得Mac，并绑定listMac
        /// </summary>
        /// <param name="userId"></param>
        private void GetMacList(string userId)
        {
            this.DTMac = DotNetService.Instance.ParameterService.GetDataTableByParameter(this.UserInfo, "MacAddress", userId);

            //只显示没有删除的数据
            //BaseBusinessLogic.SetFilter(this.DTMac,BaseParameterEntity.FieldDeletionStateCode,"0", false);
            this.DTMac.DefaultView.Sort = BaseParameterEntity.FieldSortCode;
            this.cklstMac.DataSource = this.DTMac.DefaultView;
            this.cklstMac.ValueMember = BaseParameterEntity.FieldId;
            this.cklstMac.DisplayMember = BaseParameterEntity.FieldParameterContent;
            //清除默认选择
            this.cklstMac.SelectedItems.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.cklstIp.CheckedItems.Count == 0 && this.cklstMac.CheckedItems.Count == 0)
            {
                MessageBox.Show(AppMessage.MSGC023, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //删除选择的Ip
            if (this.cklstIp.CheckedItems.Count > 0)
            {
                List<string> ipList=new List<string>();
                foreach(DataRowView row in this.cklstIp.CheckedItems )
                {
                    ipList.Add(row[BaseParameterEntity.FieldId].ToString());
                }               
                //执行批量删除
                DotNetService.Instance.ParameterService.BatchDelete(this.UserInfo,ipList.ToArray());
            
            }
            //删除选择的Mac
            if (this.cklstMac.CheckedItems.Count > 0)
            {
                List<string> macList = new List<string>();
                foreach (DataRowView row in this.cklstMac.CheckedItems)
                {
                    macList.Add(row[BaseParameterEntity.FieldId].ToString());
                }
                //执行批量删除
                DotNetService.Instance.ParameterService.BatchDelete(this.UserInfo, macList.ToArray());
     
            }
            MessageBox.Show(AppMessage.MSG0013, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //重新绑定
            if (!string.IsNullOrEmpty(this.ucUser.SelectedId))
            {
                this.GetIpList(this.ucUser.SelectedId);
                this.GetMacList(this.ucUser.SelectedId);
            }
        }

        private void cklstIp_Click(object sender, EventArgs e)
        {
            this.LastControl = this.cklstIp;
        }

        private void cklstMac_Click(object sender, EventArgs e)
        {
            this.LastControl = this.cklstMac;
        }
        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            if (this.LastControl == this.cklstIp)
            {
                for (int i = 0; i < this.cklstIp.Items.Count; i++)
                {
                    this.cklstIp.SetItemChecked(i, true);
                }
            }
            if (this.LastControl == this.cklstMac)
            {
                for (int i = 0; i < this.cklstMac.Items.Count; i++)
                {
                    this.cklstMac.SetItemChecked(i, true);
                }
            }
        }
        /// <summary>
        /// 反选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnInvertSelect_Click(object sender, EventArgs e)
        {
            if (this.LastControl == this.cklstIp)
            {
                for (int i = 0; i < this.cklstIp.Items.Count; i++)
                {
                    this.cklstIp.SetItemChecked(i, !this.cklstIp.CheckedIndices.Contains(i));
                }
            }
            if (this.LastControl == this.cklstMac)
            {
                for (int i = 0; i < this.cklstMac.Items.Count; i++)
                {
                    this.cklstMac.SetItemChecked(i, !this.cklstMac.CheckedIndices.Contains(i));
                }
            }

        }

        /// <summary>
        /// 添加IP地址或者Mac地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //检查输入是否有效
            if (!this.CheckInput())
                return;

            string statusCode=string.Empty;
            string returnValue=string.Empty;
            string[] nameArr = new string[2];
            string[] valueArr = new string[2];
            BaseParameterManager parameterManager=new BaseParameterManager(this.UserCenterDbHelper,this.UserInfo);
            BaseSequenceManager sequenceManager = new BaseSequenceManager(this.UserCenterDbHelper,this.UserInfo); 
            // 增加ip
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            if (!string.IsNullOrEmpty(this.txtIPAddress.Text.Trim()))
            {
                parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldParameterId, this.ucUser.SelectedId));
                parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldParameterContent, this.txtIPAddress.Text.Trim()));
                // 检查是否存在IpAddress
                if (parameterManager.Exists(parameters))
                {
                    statusCode = AppMessage.MSG0055;
                    MessageBox.Show(statusCode, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            
                BaseParameterEntity entityIp = new BaseParameterEntity();
                entityIp.Id = sequenceManager.GetSequence(BaseParameterEntity.TableName);
                entityIp.CategoryId = "IPAddress";
                entityIp.ParameterId = this.ucUser.SelectedId;
                string ipStr = this.txtIPAddress.Text.Trim();

                //Range Mask  和Single  在CheckInput 方法中使用正则表达式对输入进行验证
                //如果是地址段
                if(ipStr.IndexOf('-')>0)
                {
                    entityIp.ParameterCode = "Range";// mask range
                }
                else if (ipStr.IndexOf('*') > 0)
                { //如果有mask
                    entityIp.ParameterCode = "Mask";
                }
                else
                {
                    entityIp.ParameterCode = "Single";
                }
                //如果是单个ip
                
                entityIp.ParameterContent = this.txtIPAddress.Text.Trim();
                returnValue = parameterManager.AddEntity(entityIp);
                if (!string.IsNullOrEmpty(returnValue))
                {
                    statusCode = AppMessage.MSG0056;

                }
                else
                {
                    statusCode = AppMessage.MSG0057;
                }
            }
            // 增加Mac
            if (!string.IsNullOrEmpty(this.txtMacAddress.Text.Trim()))
            {
                parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldParameterId, this.ucUser.SelectedId));
                parameters.Add(new KeyValuePair<string, object>(BaseParameterEntity.FieldParameterContent, this.txtMacAddress.Text.Trim()));
                // 检查是否存在MacAddress
                if (parameterManager.Exists(parameters))
                {
                    statusCode = AppMessage.MSG0058;
                    MessageBox.Show(statusCode, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                BaseParameterEntity entityMac = new BaseParameterEntity();
                entityMac.Id = sequenceManager.GetSequence(BaseParameterEntity.TableName);
                entityMac.CategoryId = "MacAddress";
                entityMac.ParameterId = this.ucUser.SelectedId;
                entityMac.ParameterCode = "Single";
                entityMac.ParameterContent = this.txtMacAddress.Text.Trim();
                returnValue = parameterManager.AddEntity(entityMac);

                if (!string.IsNullOrEmpty(returnValue))
                {
                    statusCode += AppMessage.MSG0059;

                }
                else
                {
                    statusCode += AppMessage.MSG0061;
                }
            }

            MessageBox.Show(statusCode, AppMessage.MSG0000, MessageBoxButtons.OK, MessageBoxIcon.Information);
            // 重新绑定listbox
            this.GetIpList(this.ucUser.SelectedId);
            this.GetMacList(this.ucUser.SelectedId);
            this.CleanScreen();
        }
    }
}