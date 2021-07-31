
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;

namespace GTATools
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SuspendButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.killGameButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBoxClr = new System.Windows.Forms.TextBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // SuspendButton
            // 
            this.SuspendButton.Location = new System.Drawing.Point(148, 12);
            this.SuspendButton.Name = "SuspendButton";
            this.SuspendButton.Size = new System.Drawing.Size(91, 23);
            this.SuspendButton.TabIndex = 1;
            this.SuspendButton.Text = "Suspend now";
            this.SuspendButton.UseVisualStyleBackColor = true;
            this.SuspendButton.Click += new System.EventHandler(this.SuspendButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Suspend for";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(85, 14);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(57, 20);
            this.numericUpDown1.TabIndex = 3;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Lag switch:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Enabled = false;
            this.radioButton1.Location = new System.Drawing.Point(85, 56);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 6;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // killGameButton
            // 
            this.killGameButton.Location = new System.Drawing.Point(148, 51);
            this.killGameButton.Name = "killGameButton";
            this.killGameButton.Size = new System.Drawing.Size(91, 23);
            this.killGameButton.TabIndex = 7;
            this.killGameButton.Text = "Kill Game";
            this.killGameButton.UseVisualStyleBackColor = true;
            this.killGameButton.Click += new System.EventHandler(this.killGameButton_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(127, 56);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Increment = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.numericUpDown2.Location = new System.Drawing.Point(85, 95);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(57, 20);
            this.numericUpDown2.TabIndex = 9;
            this.numericUpDown2.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Wheelspin";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(168, 94);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(71, 20);
            this.textBox1.TabIndex = 11;
            this.textBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyUp);
            // 
            // textBoxClr
            // 
            this.textBoxClr.Location = new System.Drawing.Point(67, 120);
            this.textBoxClr.Name = "textBoxClr";
            this.textBoxClr.ReadOnly = true;
            this.textBoxClr.Size = new System.Drawing.Size(100, 20);
            this.textBoxClr.TabIndex = 12;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Enabled = false;
            this.radioButton2.Location = new System.Drawing.Point(148, 97);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(14, 13);
            this.radioButton2.TabIndex = 13;
            this.radioButton2.TabStop = true;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 150);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.textBoxClr);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.killGameButton);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SuspendButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Dj\'s GTA Tools";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SuspendButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;

        private void ColorLoop()
        {
            while (true)
            {
                var clr = Utils.GetColorAt(new System.Drawing.Point(x: 90, y: 40));
                Thread.Sleep(100);
                textBoxClr.Invoke((Action)delegate
                {
                    textBoxClr.Text = clr.ToHex();
                });
            }            
        }

        [STAThread]
        private async void WheelSpinLoop()
        {            
            var mainWheelspinToken = new CancellationTokenSource();
            CancellationTokenSource curWheelSpin = null;
            bool state = KeyStates.WheelspinHotkey;
            while (!mainWheelspinToken.IsCancellationRequested)
            {
                bool curState = KeyStates.WheelspinHotkey;
                if (curState != state) // Key Pressed
                {                 
                    if (curState) // If it was just enabled
                    {
                        curWheelSpin = new CancellationTokenSource();
                        _ = Task.Run(() => fuck(curWheelSpin.Token), curWheelSpin.Token);
                    }
                    else // If it was just disabled
                    {
                        curWheelSpin?.Cancel();
                    }                    
                }
                state = curState;
                await Task.Delay(10);
            }
            curWheelSpin?.Dispose();
            mainWheelspinToken.Dispose();
        }

        private async Task fuck(CancellationToken token)
        {
            radioButton2.Invoke((Action)delegate 
            {
                radioButton2.Checked = true;
            });

            var inputSim = new InputSimulator();
            if (!token.IsCancellationRequested)
            {
                inputSim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.RETURN);
                await Task.Delay(100);
                inputSim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.RETURN);

                while (Utils.GetColorAt(new System.Drawing.Point(x: 90, y: 40)).ToHex() != "#E5E5E5")
                {
                    await Task.Delay(10);
                    if (token.IsCancellationRequested)
                    {
                        radioButton2.Invoke((Action)delegate
                        {
                            radioButton2.Checked = false;
                        });
                        return;
                    }
                }
                await Task.Delay(Properties.Settings.Default.WheelspinDelay);
                inputSim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.VK_S);
                await Task.Delay(100);
                inputSim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.VK_S);
            }
            radioButton2.Invoke((Action)delegate
            {
                radioButton2.Checked = false;
            });
        }

        private void LagSwitchLoop()
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

        private System.Windows.Forms.Button killGameButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBoxClr;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}

