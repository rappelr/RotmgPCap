using RotmgPCap.Forms;
using System;
using System.Windows.Forms;

namespace RotmgPCap
{
    class AppEntry
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LauncherForm());
        }
    }
}
