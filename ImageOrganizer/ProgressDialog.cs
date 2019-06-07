using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageOrganizer
{
    public partial class ProgressDialog : Form
    {
        private System.Windows.Forms.Button cancelButton;
        public System.Windows.Forms.ProgressBar progressBar;
        private BackgroundWorker worker;
        Stopwatch stopWatch = new Stopwatch();

        public ProgressDialog(BackgroundWorker worker, int size)
        {
            this.worker = worker;
            this.DialogResult = DialogResult.OK;
            InitializeComponent();
            worker.ProgressChanged += ProgressChanged;
            DialogResult = DialogResult.OK;
            progressBar.Style = ProgressBarStyle.Blocks;
            progressBar.Maximum = size;
        }

        public ProgressDialog(BackgroundWorker worker)
        {
            this.worker = worker;
            this.DialogResult = DialogResult.OK;
            InitializeComponent();
            worker.ProgressChanged += ProgressChanged;
            DialogResult = DialogResult.OK;
            progressBar.Style = ProgressBarStyle.Marquee;
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!stopWatch.IsRunning) stopWatch.Start();

            if (stopWatch.Elapsed.TotalMilliseconds > 20)
            {
                lblProgress.Text = e.UserState.ToString();
                stopWatch.Restart();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you shure you want to stop?", "Question", MessageBoxButtons.YesNo) != DialogResult.Yes) return;
            DialogResult = DialogResult.Abort;
            worker.CancelAsync();
        }

    }
}
