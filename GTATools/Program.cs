﻿using System;
using System.Threading;
using System.Windows.Forms;

namespace GTATools
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-us");
            //if (Process.GetProcessesByName("GTA5").FirstOrDefault() == null)
            //{
            //    MessageBox.Show("GTA must be running to run this Software!");
            //    return;
            //}
            if (!Utils.IsAdministrator())
            {
                Utils.MakeAdmin();
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
