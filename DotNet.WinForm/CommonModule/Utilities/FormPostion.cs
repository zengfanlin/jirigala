//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//--------------------------------------------------------------------

using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace DotNet.WinForm
{
    /// <summary>
    /// FormPostion
    /// 
    /// 修改纪录
    ///
    ///		2008.01.11 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.01.11</date>
    /// </author> 
    /// </summary>
    public class FormPostion : System.ComponentModel.Component
    {
        // 这是保存和恢复窗体状态的事件
        public delegate void WindowStateDelegate(object sender, RegistryKey key);
        public event WindowStateDelegate LoadStateEvent;
        public event WindowStateDelegate SaveStateEvent;

        private int Left;
        private int Top;
        private int Width;
        private int Height;
        private FormWindowState windowState;

        public FormPostion()
        {
        }

        private Form parent;
        public Form Parent
        {
            set
            {
                parent = value;
                // 预订所在窗体的事件
                parent.Closing += new System.ComponentModel.CancelEventHandler(OnClosing);
                parent.Resize += new System.EventHandler(OnResize);
                parent.Move += new System.EventHandler(OnMove);
                parent.Load += new System.EventHandler(OnLoad);
                // 保存所在窗体的初始宽度和高度
                Width = parent.Width;
                Height = parent.Height;
            }
            get
            {
                return parent;
            }
        }

        private string registryPath;
        public string RegistryPath
        {
            set
            {
                registryPath = value;
            }
            get
            {
                return registryPath;
            }
        }

        private bool saveMinimized = false;
        public bool SaveMinimized
        {
            set
            {
                saveMinimized = value;
            }
        }

        private void OnResize(object sender, System.EventArgs e)
        {
            // 保存宽带和高度
            if (parent.WindowState == FormWindowState.Normal)
            {
                Width = parent.Width;
                Height = parent.Height;
            }
        }

        private void OnMove(object sender, System.EventArgs e)
        {
            // 保存位置
            if (parent.WindowState == FormWindowState.Normal)
            {
                Left = parent.Left;
                Top = parent.Top;
            }
            // 保存状态
            windowState = parent.WindowState;
        }

        private void OnLoad(object sender, System.EventArgs e)
        {
            // 从注册表中读取信息
            RegistryKey key = Registry.CurrentUser.OpenSubKey(RegistryPath);
            if (key != null)
            {
                Left = (int)key.GetValue("Left", parent.Left);
                Top = (int)key.GetValue("Top", parent.Top);
                Width = (int)key.GetValue("Width", parent.Width);
                Height = (int)key.GetValue("Height", parent.Height);
                // windowState = (FormWindowState)key.GetValue("WindowState", (int)parent.WindowState);
                parent.Location = new Point(Left, Top);
                parent.Size = new Size(Width, Height);
                // parent.WindowState = windowState;
                // 触发LoadState事件
                if (LoadStateEvent != null)
                {
                    LoadStateEvent(this, key);
                }
            }
        }

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // 保存位置,大小,状态
            RegistryKey key = Registry.CurrentUser.CreateSubKey(RegistryPath);
            key.SetValue("Left", Left);
            key.SetValue("Top", Top);
            key.SetValue("Width", Width);
            key.SetValue("Height", Height);
            // 检查是否可以运行最小化
            if (!saveMinimized)
            {
                if (windowState == FormWindowState.Minimized)
                {
                    windowState = FormWindowState.Normal;
                }
            }
            key.SetValue("WindowState", (int)windowState);
            // 触发 SaveState 事件
            if (SaveStateEvent != null)
            {
                SaveStateEvent(this, key);
            }
        }
    }
}