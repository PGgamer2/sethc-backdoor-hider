using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace sethc.exe
{
	static class Program
	{
		[STAThread]
		static void Main(string[] args)
		{
			// Check if argument is valid
			if (Debugger.IsAttached) {
				args = new string[] { "211" };
			} else {
				try
				{
					short arg = short.Parse(args[0]);
					if (arg < 211 || arg > 251) return;
					if ((arg - 211) % 10 != 0) return;
				}
				catch (Exception) { return; }
			}

			// Don't open the window if the process already exists
			string thisprocessname = Process.GetCurrentProcess().ProcessName;
			if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
				return;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			Application.Run(new Main(args));
		}
	}
}
