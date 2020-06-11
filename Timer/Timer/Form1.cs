using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timer
{
    public partial class Form1 : Form
    {

        System.Diagnostics.Stopwatch StopWatch = new System.Diagnostics.Stopwatch();
        public Form1()
        {
            InitializeComponent();
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCHITTEST)
                m.Result = (IntPtr)(HT_CAPTION);
        }

        private const int WM_NCHITTEST = 0x84;
        private const int HT_CLIENT = 0x1;
        private const int HT_CAPTION = 0x2;

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.StopWatch.Start();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan elapsed = this.StopWatch.Elapsed;
            //label1.Text = string.Format("{0:00}:{1:00}:{2:00}:{3:00}",
            //    Math.Floor(elapsed.TotalHours),
            //    elapsed.Minutes,
            //    elapsed.Seconds,
            //    elapsed.Milliseconds);
            label1.Text = string.Format("{0:00}:{1:00}:{2:00}",
                Math.Floor(elapsed.TotalHours),
                elapsed.Minutes,
                elapsed.Seconds);


        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.StopWatch.Stop();
        }

        private void reNewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.StopWatch.Reset();
            label1.Text = "00:00:00";
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
        }
    }
}
