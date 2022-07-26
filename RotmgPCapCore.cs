using RotmgPCap.Capture;
using RotmgPCap.Forms;
using RotmgPCap.Packets;
using RotmgPCap.Util;
using SharpPcap;
using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RotmgPCap
{
    internal class RotmgPCapCore
    {
        internal const string VERSION = "v1.0.2.0";

        internal readonly CaptureManager CaptureManager;
        internal readonly PacketManager PacketManager;

        private PacketCaptureForm captureForm;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LauncherForm());
        }

        internal RotmgPCapCore()
        {
            CaptureManager = new CaptureManager(this);
            PacketManager = new PacketManager();
        }

        internal void Close() => CaptureManager.Stop();

        internal void Launch(LauncherForm launcherForm)
        {
            launcherForm.Update("Loading...", 0);

            launcherForm.Update("Loading packet structures...", 10);

            string result = PacketManager.LoadStructures();

            if (result != null)
            {
                launcherForm.Finish(result);
                return;
            }

            launcherForm.Update("Fetching network devices...", 30);

            if(!CaptureManager.LoadCaptureDevices())
            {
                launcherForm.Finish("Failed to fetch network devices.\nMake sure you have WinPCap installed.");
                return;
            }

            launcherForm.Update("Creating firewall rule...", 80);

            try
            {
                FirewallUtil.SetFirewallRule();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                launcherForm.Finish("Failed to create firewall rule.\nMake sure you launched the application evelated.");
                return;
            }

            launcherForm.Update("Finishing up", 100);
            Thread.Sleep(300);
            launcherForm.Finish(null);
        }

        internal string HotReloadStructures()
        {
            string result = PacketManager.LoadStructures();

            if (result == null)
                foreach (Packet packet in captureForm.Packets.Values)
                    packet.ReapplyStructure(PacketManager);

            return result;
        }

        internal void OpenPacketCapture() => Open(() => Application.Run(captureForm = new PacketCaptureForm(this)));

        internal void OpenPacketAnalyzer(Packet packet) => Open(() => Application.Run(new PacketAnalyzerForm(this, packet)));

        internal void FinishCapturing(bool timeout) => captureForm.FinishCapturing(timeout);

        internal void AddressDetected(string address) => captureForm.AddressDetected(address);

        internal void AddPacket(Packet packet) => captureForm.AddPacket(packet);

        internal void AddPacketsCaught(int count) => captureForm.AddPacketsCaught(count);

        internal void SetSync(bool incoming) => captureForm.SetSync(incoming);

        private void Open(ThreadStart threadStart)
        {
            Thread thread = new Thread(threadStart);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}
