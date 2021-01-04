using System;
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
            if (!Utils.IsAdministrator())
            {
                Utils.MakeAdmin();
                return;
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //var lagThread = new Thread(LagHandler.DoShit);
            //lagThread.Start();
        }
    }
}
