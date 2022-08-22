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
        private Thread _lagThread = null;
        private readonly Thread _colorThread = null;
        private FirewallRule fw = null;
        //readonly Process _gtaProc = Process.GetProcessesByName("GTA5").FirstOrDefault();
        private Process temp = null;
        public Process _gtaProc
        {
            get
            {
                if (temp == null)
                {
                    return Process.GetProcessesByName("GTA5").FirstOrDefault();
                }
                return temp;
            }
        }
        public MainForm()
        {
            InitializeComponent();


            //_lagThread = new Thread(LagSwitchLoop);
            //_lagThread.Start();

            //_colorThread = new Thread(ColorLoop);
            //_colorThread.Start();


            //Task.Factory.StartNew(() => { return; }).ContinueWith(a => WheelSpinLoop(), scheduler); // https://stackoverflow.com/questions/5971686/how-to-create-a-task-tpl-running-a-sta-thread

            var scheduler = TaskScheduler.FromCurrentSynchronizationContext();
            var factory = new TaskFactory(CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskContinuationOptions.None, scheduler);
            factory.StartNew(() => WheelSpinLoop());
            factory.StartNew(() => KillGameLoop());
            Task.Run(async () =>
            {
                while (_gtaProc == null)
                {
                    await Task.Delay(5000);
                }
                fw = new FirewallRule(_gtaProc.MainModule.FileName);
                _lagThread = new Thread(LagSwitchLoop);
                _lagThread.Start();
            });
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
            this.Location = Properties.Settings.Default.FormLocation;
            this.textBox1.Text = Properties.Settings.Default.WheelspinKey.ToString();
            this.numericUpDown2.Value = Properties.Settings.Default.WheelspinDelay;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.SuspendTimer = this.numericUpDown1.AsInt();
            if (this.WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.FormLocation = this.Location;
            }
            Properties.Settings.Default.Save();


            _lagThread?.Abort(); // Closing lagswitch thread
            _colorThread?.Abort();
            fw?.Unblock(); // Removing firewall rule
        }

        private void killGameButton_Click(object sender, EventArgs e)
        {
            KillGame();
        }

        private void KillGame()
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

        // Wheelspin hotkey textbox stuff
        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                label3.Focus();
                return;
            }
            textBox1.Text = e.KeyCode.ToString();
            label3.Focus();
            e.Handled = true;
            Properties.Settings.Default.WheelspinKey = e.KeyCode;
            Properties.Settings.Default.Save();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.WheelspinDelay = (int)numericUpDown2.Value;
            Properties.Settings.Default.Save();
        }
    }
}
