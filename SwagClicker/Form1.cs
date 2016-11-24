using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using InputManager;
using SwagClicker;
using SwagClicker.FullSwag;
using SwagClicker.Models;
using SwagClicker.Utils;

namespace SwagClicker
{
    public partial class Form1 : Form
    {
        private SwagHelper _helper;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _helper = new SwagHelper();
            KeyboardHook.KeyUp += KeyUpHandler;
            KeyboardHook.KeyDown += KeyDownHandler;
            KeyboardHook.InstallHook();
            MouseHook.MouseMove += new MouseHook.MouseMoveEventHandler(MouseMoveHandler);
            MouseHook.MouseEvent += new MouseHook.MouseEventEventHandler(MouseClickHandler);
            MouseHook.InstallHook();
        }


        private void MouseClickHandler(MouseHook.MouseEvents mEvent)
        {  
            _helper.MouseClick(mEvent);
        }

        private void MouseMoveHandler(MouseHook.POINT ptLocat)
        {
            _helper.MouseMove(ptLocat);
        }

        private void KeyUpHandler(int vkCode)
        {
            switch (vkCode)
            {
                case (int)Keys.Home:
                    if (_helper.TimerRecord.Enabled)
                    {
                        _helper.StopRecord();
                    }
                    else
                    {
                        _helper.StartRecord();
                    }
                    break;
                case (int) Keys.End:
                    if (_helper.TimerPlayback.Enabled)
                    {
                        _helper.StopPlayback();
                    }
                    else
                    {
                        _helper.StartPlayback();
                    }
                    
                    break;
                default:
                    _helper.KeyboardAction((Keys)vkCode, false);
                    break;
            }
        }

        private void KeyDownHandler(int vkCode)
        {
            if (vkCode == (int) Keys.Home || vkCode == (int) Keys.End) return;  
            _helper.KeyboardAction((Keys)vkCode, true);
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            _helper.SaveCommands();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _helper.LoadCommands();
        }

        private void nudUpdateTime_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void btnApplyUpdate_Click(object sender, EventArgs e)
        {
            SwagHelper.UpdateMills = (int)nudUpdateTime.Value;
        }
    }
}
