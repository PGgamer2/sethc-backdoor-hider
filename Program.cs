using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace sethc.exe
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Don't open the program if the process already exists
            string thisprocessname = Process.GetCurrentProcess().ProcessName;
            if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
                return;

            Application.Run(new main());
        }
    }
}
