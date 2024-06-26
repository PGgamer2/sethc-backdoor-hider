﻿using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace sethc
{
	public partial class Main : Form
	{
		private const Int32 SPI_SETSTICKYKEYS = 0x003B;
        private const Int32 SPIF_UPDATEINIFILE = 0x01;
        private const Int32 SPIF_SENDWININICHANGE = 0x02;
        private const UInt32 SKF_STICKYKEYSON = 0x00000001;
        private const UInt32 SKF_HOTKEYACTIVE = 0x00000004;

        private const Int32 WM_SYSCOMMAND = 0x112;
        private const Int32 MF_BYPOSITION = 0x400;
        private const Int32 MF_SEPARATOR = 0x800;
        private const Int32 CTXMENU1 = 1000;
        private const Int32 CTXMENU2 = 1001;
        private const Int32 CTXMENU3 = 1002;
        private const Int32 CTXMENU4 = 1003;
        private const Int32 CTXMENU5 = 1004;

		[DllImport("user32.dll")]
		private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
		[DllImport("user32.dll")]
		private static extern bool InsertMenu(IntPtr hMenu, Int32 wPosition, Int32 wFlags, Int32 wIDNewItem, string lpNewItem);
		[DllImport("user32.dll")]
		private static extern bool SystemParametersInfoA(Int32 uiAction, Int32 uiParam, IntPtr pvParam, Int32 fWinIni);
		[StructLayout(LayoutKind.Sequential)]
		private struct tagSTICKYKEYS
		{
			public Int32 cbSize;
			public UInt32 dwFlags;
		}

		public Main(string[] args)
		{
			InitializeComponent();
			Localization.SetLanguage(this, (int.Parse(args[0]) - 211) / 10);
		}

		protected override void WndProc(ref Message msg)
		{
			if (msg.Msg == WM_SYSCOMMAND) {
				try {
					switch (msg.WParam.ToInt32()) {
						// Actions for context menu
						case CTXMENU1:
							Process.Start("cmd.exe");
							return;
						case CTXMENU2:
							try {
								Process.Start("powershell.exe");
							} catch (Exception) {
								MessageBox.Show("Cannot start PowerShell.", AppDomain.CurrentDomain.FriendlyName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
							}
							return;
						case CTXMENU3:
							Process.Start("explorer.exe");
							return;
						case CTXMENU4:
							Process.Start("control.exe");
							return;
						case CTXMENU5:
							Process.Start("regedit.exe");
							return;
						default:
							break;
					}
				} catch (Exception error) {
					Console.WriteLine($"Cannot open process: {error}");
				}
			}
			base.WndProc(ref msg);
		}

		private void Main_Load(object sender, EventArgs e)
		{
			// Insert new items into context menu
			IntPtr MenuHandle = GetSystemMenu(this.Handle, false);
			InsertMenu(MenuHandle, 5, MF_BYPOSITION | MF_SEPARATOR, 0, string.Empty);
			InsertMenu(MenuHandle, 6, MF_BYPOSITION, CTXMENU1, "Open Command Prompt");
			InsertMenu(MenuHandle, 7, MF_BYPOSITION, CTXMENU2, "Open PowerShell");
			InsertMenu(MenuHandle, 8, MF_BYPOSITION, CTXMENU3, "Open Explorer");
			InsertMenu(MenuHandle, 9, MF_BYPOSITION, CTXMENU4, "Open Control Panel");
			InsertMenu(MenuHandle, 10, MF_BYPOSITION, CTXMENU5, "Open Registry");
		}

		private void labeldeactivatedialog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			// Open settings
			try {
				Process.Start("ms-settings:easeofaccess-keyboard");
			} catch (Exception) {
				try {
					ProcessStartInfo skwinxp = new ProcessStartInfo("rundll32.exe");
					skwinxp.Arguments = "Shell32.dll,Control_RunDLL access.cpl,,1";
					Process.Start(skwinxp);
				} catch (Exception) {
					try {
						Process.Start("control.exe");
					} catch (Exception error) {
						MessageBox.Show($"Cannot open settings from {AppDomain.CurrentDomain.FriendlyName}:\n{error}", AppDomain.CurrentDomain.FriendlyName + " - Cannot open settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
						Environment.Exit(126);
					}
				}
			}
			Application.Exit();
		}

		private void buttonNo_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void buttonYes_Click(object sender, EventArgs e)
		{
			// Try to enable sticky keys
			try {
				tagSTICKYKEYS stk;
				stk.dwFlags = SKF_STICKYKEYSON | SKF_HOTKEYACTIVE;
				stk.cbSize = Marshal.SizeOf(typeof(tagSTICKYKEYS));
				// Convert struct to IntPtr
				IntPtr pObj = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(tagSTICKYKEYS)));
				Marshal.StructureToPtr(stk, pObj, false);
				// Set Sticky Keys settings
				SystemParametersInfoA(SPI_SETSTICKYKEYS, 0, pObj, SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
				Marshal.FreeHGlobal(pObj);
			} catch (Exception error) {
				MessageBox.Show($"Cannot change settings from {AppDomain.CurrentDomain.FriendlyName}: {error}\nThe current user will have to manually change the settings.", AppDomain.CurrentDomain.FriendlyName + " - Cannot change settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Environment.Exit(126);
			}
			Application.Exit();
		}
	}
}
