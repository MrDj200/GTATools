using GTAToolsHelper;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTATools
{
    public partial class Form1 : Form
    {
        private readonly Thread _lagThread = null;
        private readonly FirewallRule fw = null;
        Process gtaProc = Process.GetProcessesByName("GTA5").FirstOrDefault();
        public Form1()
        {
            InitializeComponent();
            _lagThread = new Thread(DoShit);
            _lagThread.Start();

            fw = new FirewallRule(gtaProc.MainModule.FileName);
        }

        private void SuspendButton_Click(object sender, System.EventArgs e)
        {
            
            if (gtaProc == null)
            {
                System.Media.SystemSounds.Hand.Play();
                return;
            }
            var shit = Task.Factory.StartNew(() => gtaProc.SuspendFor(Convert.ToInt32(Math.Round(numericUpDown1.Value, 0))));

        }

        #region Thread Safe BTN stuff

        private delegate void SafeCallDelegate(bool state);

        private void ChangeStateSafe(bool state)
        {
            if (radioButton1.InvokeRequired)
            {
                var d = new SafeCallDelegate(ChangeStateSafe);
                radioButton1.Invoke(d, new object[] { state });
            }
            else
            {
                radioButton1.Checked = state;
            }
        }
        #endregion

        private void DoShit()
        {
            bool state = KeyStates.ScrollLock;
            while (true)
            {
                if (KeyStates.ScrollLock && !state)
                {
                    fw.Block();                    
                    state = KeyStates.ScrollLock;
                    ChangeStateSafe(state);
                }
                else if (!KeyStates.ScrollLock && state)
                {
                    fw.Unblock();
                    state = KeyStates.ScrollLock;
                    ChangeStateSafe(state);
                }
                Thread.Sleep(100);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _lagThread?.Abort();
            fw?.Unblock();
        }
    }
}
