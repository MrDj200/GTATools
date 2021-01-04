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
            int time = numericUpDown1.AsInt();
            Task.Factory.StartNew(() => _gtaProc.SuspendFor(time));

            Properties.Settings.Default.SuspendTimer = time; // Updating settings file
            Properties.Settings.Default.Save();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Loading from settings
            this.numericUpDown1.Value = Properties.Settings.Default.SuspendTimer;
            this.Location = Properties.Settings.Default.F1Location;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.SuspendTimer = this.numericUpDown1.AsInt();
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.F1Location = this.Location;
            }
            Properties.Settings.Default.Save();


            _lagThread?.Abort(); // Closing lagswitch thread
            fw?.Unblock(); // Removing firewall rule
        }

        private void killGameButton_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("Do you want to kill the game?", "Are you sure?", MessageBoxButtons.YesNo);
                if (dialogResult != DialogResult.Yes)
                {
                    return;
                }
            }
            _gtaProc?.Kill();
            checkBox1.Checked = false;
        }
    }
}
