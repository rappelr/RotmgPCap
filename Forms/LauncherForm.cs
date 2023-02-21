using System;
using System.Diagnostics;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace RotmgPCap.Forms
{
    internal partial class LauncherForm : Form
    {
        private RotmgPCapCore rotmgPCap;
        private Thread launchThread;
        private bool closing = false;

        internal LauncherForm() => InitializeComponent();

        internal void Finish(string error) => Invoke(new LauncherFinish(DoFinish), error);

        internal void Update(string progressMessage, int progressBarValue) => Invoke(new LauncherUpdate(DoUpdate), progressMessage, progressBarValue);

        private void Launch() => (rotmgPCap = new RotmgPCapCore()).Launch(this);

        private void DoFinish(string error)
        {
            closing = true;

            if (error == null)
            {
                Close();
                rotmgPCap.OpenPacketCapture();
            }
            else
            {
                MessageBox.Show(error, "RotmgPCap launch failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }

        private void DoUpdate(string progressMessage, int progressBarValue)
        {
            progressLabel.Text = progressMessage;
            progressBar.Value = progressBarValue;
        }

        private void LauncherForm_Load(object sender, EventArgs e)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            versionLabel.Text = versionInfo.ProductVersion;
            (launchThread = new Thread(() => Launch())).Start();
        }

        private void LauncherForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closing)
                return;

            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = true;
            else
                if (launchThread != null && launchThread.IsAlive)
                launchThread.Abort();
        }
    }

    internal delegate void LauncherFinish(string error);
    internal delegate void LauncherUpdate(string progressMessage, int progressBarValue);
}
