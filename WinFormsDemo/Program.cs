﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsDemo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //注册消息过滤器
            Application.AddMessageFilter(new GlobalMessageFilter());
            Application.Run(new TabControlForm());
            Application.Run(new ChartForm());
            Application.Run(new MainForm());
            Application.Run(new MainForm2());
        }
    }
}
