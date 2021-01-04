using GTAToolsHelper;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GTATools
{
    public partial class MainForm : Form
    {
        private readonly Thread _lagThread = null;
        private readonly FirewallRule fw = null;
        readonly Process _gtaProc = Process.GetProcessesByName("GTA5").FirstOrDefault();
        public MainForm()
        {
            InitializeComponent();

            numericUpDown1.Value = Properties.Settings.Default.SuspendTimer; // Loading from settings

            _lagThread = new Thread(LagSwitchLoop);
            _lagThread.Start();

            fw = new FirewallRule(_gtaProc.MainModule.FileName);
        }

        private void SuspendButton_Click(object sender, System.EventArgs e)
        {

            if (_gtaProc == null)
            {
                System.Media.SystemSounds.Hand.Play();
                MessageBox.Show("The GTA Process was not found! Is GTA running?");
                return;
            }
            int time = Convert.ToInt32(Math.Round(numericUpDown1.Value, 0));
            var shit = Task.Factory.StartNew(() => _gtaProc.SuspendFor(time));

            Properties.Settings.Default.SuspendTimer = time; // Updating settings file
            Properties.Settings.Default.Save(); 
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _lagThread?.Abort(); // Closing lagswitch thread
            fw?.Unblock(); // Removing firewall rule
        }
    }
}
