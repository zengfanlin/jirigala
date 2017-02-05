//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Windows.Forms;

namespace DotNet.WinForm
{
    
    using DotNet.Business;
    using DotNet.Utilities;
    

    /// <summary>
    /// FrmSignature
    /// 用户签名。
    /// 
    /// 修改纪录
    /// 
    ///     2011.09.17 版本：1.0 JiRiGaLa 主键编辑。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.09.17</date>
    /// </author>
    public partial class FrmSignature : BaseForm
    {
        public FrmSignature()
        {
            InitializeComponent();
        }

        public FrmSignature(string userId)
            : this()
        {
            this.EntityId = userId;
        }

        private void ucPicture_OnAfterDelete(string pictureId)
        {
            DotNetService.Instance.ParameterService.SetParameter(UserInfo, "User", this.EntityId, "UserSignature", null);
        }

        private void FrmSignature_Load(object sender, EventArgs e)
        {
            // 获取图片部分，显示图片部分
            string pictureId = DotNetService.Instance.ParameterService.GetParameter(UserInfo, "User", this.EntityId, "UserSignature");
            if (!String.IsNullOrEmpty(pictureId))
            {
                this.ucPicture.PictureId = pictureId;
                this.ucPicture.OnAfterDelete += new UCPicture.OnAfterDeleteEventHandler(ucPicture_OnAfterDelete);

            }
        }

        private void FrmSignature_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(this.ucPicture.PictureId))
            {
                string pictureContent = string.Empty;
                pictureContent = this.ucPicture.Upload("UserSignature", this.EntityId);
                // 判断图片是否为空，如果为空不对图片过行更新 dfhjc
                if (!string.IsNullOrEmpty(pictureContent))
                {
                    DotNetService.Instance.ParameterService.SetParameter(UserInfo, "User", this.EntityId, "UserSignature", pictureContent);
                }
            }
        }
    }
}
