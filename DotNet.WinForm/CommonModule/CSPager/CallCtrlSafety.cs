//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System.Windows.Forms;

namespace DotNet.WinForm
{
    public class CallCtrlSafety
    {
        #region 跨线程的控件安全访问方式

        delegate void SetTextCallback(System.Windows.Forms.Control objCtrl, string text, Form winf);
        delegate void SetEnableCallback(System.Windows.Forms.Control objCtrl, bool enable, Form winf);
        delegate void SetFocusCallback(System.Windows.Forms.Control objCtrl, Form winf);
        delegate void SetCheckedCallback(System.Windows.Forms.CheckBox objCtrl, bool isCheck, Form winf);
        delegate void SetVisibleCallback(System.Windows.Forms.Control objCtrl, bool isVisible, Form winf);
        delegate void SetValueCallback(System.Windows.Forms.ProgressBar objCtrl, int value, Form winf);

        public static void SetText<TObject>(TObject objCtrl, string text, Form winf) where TObject : System.Windows.Forms.Control
        {
            if (objCtrl.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                if (winf.IsDisposed)
                {
                    return;
                }
                winf.Invoke(d, new object[] { objCtrl, text, winf });
            }
            else
            {
                objCtrl.Text = text;
            }
        }
        public static void SetEnable<TObject>(TObject objCtrl, bool enable, Form winf) where TObject : System.Windows.Forms.Control
        {
            if (objCtrl.InvokeRequired)
            {
                SetEnableCallback d = new SetEnableCallback(SetEnable);
                if (winf.IsDisposed)
                {
                    return;
                }
                winf.Invoke(d, new object[] { objCtrl, enable, winf });
            }
            else
            {
                objCtrl.Enabled = enable;
            }
        }
        public static void SetFocus<TObject>(TObject objCtrl, Form winf) where TObject : System.Windows.Forms.Control
        {
            if (objCtrl.InvokeRequired)
            {
                SetFocusCallback d = new SetFocusCallback(SetFocus);
                if (winf.IsDisposed)
                {
                    return;
                }
                winf.Invoke(d, new object[] { objCtrl, winf });
            }
            else
            {
                objCtrl.Focus();
            }
        }
        public static void SetChecked<TObject>(TObject objCtrl, bool isChecked, Form winf) where TObject : System.Windows.Forms.CheckBox
        {
            if (objCtrl.InvokeRequired)
            {
                SetCheckedCallback d = new SetCheckedCallback(SetChecked);
                if (winf.IsDisposed)
                {
                    return;
                }
                winf.Invoke(d, new object[] { objCtrl, isChecked, winf });
            }
            else
            {
                objCtrl.Checked = isChecked;
            }
        }
        public static void SetVisible<TObject>(TObject objCtrl, bool isVisible, Form winf) where TObject : System.Windows.Forms.Control
        {
            if (objCtrl.InvokeRequired)
            {
                SetVisibleCallback d = new SetVisibleCallback(SetVisible);
                if (winf.IsDisposed)
                {
                    return;
                }
                winf.Invoke(d, new object[] { objCtrl, isVisible, winf });
            }
            else
            {
                objCtrl.Visible = isVisible;
            }
        }
        public static void SetValue<TObject>(TObject objCtrl, int value, Form winf) where TObject : System.Windows.Forms.ProgressBar
        {
            if (objCtrl.InvokeRequired)
            {
                SetValueCallback d = new SetValueCallback(SetValue);
                if (winf.IsDisposed)
                {
                    return;
                }
                winf.Invoke(d, new object[] { objCtrl, value, winf });
            }
            else
            {
                objCtrl.Value = value;
            }
        }
        #endregion
    }
}
