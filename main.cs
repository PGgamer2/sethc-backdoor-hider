using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace sethc
{
    public partial class main : Form
    {
        public const Int32 SPI_SETSTICKYKEYS = 0x003B;
        public const Int32 SPIF_UPDATEINIFILE = 0x01;
        public const Int32 SPIF_SENDWININICHANGE = 0x02;
        public const UInt32 SKF_STICKYKEYSON = 0x00000001;
        public const UInt32 SKF_HOTKEYACTIVE = 0x00000004;

        public const Int32 WM_SYSCOMMAND = 0x112;
        public const Int32 MF_BYPOSITION = 0x400;
        public const Int32 MF_SEPARATOR = 0x800;
        public const Int32 CTXMENU1 = 1000;
        public const Int32 CTXMENU2 = 1001;
        public const Int32 CTXMENU3 = 1002;
        public const Int32 CTXMENU4 = 1003;
        public const Int32 CTXMENU5 = 1004;

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

        public main()
        {
            InitializeComponent();
        }

        protected override void WndProc(ref Message msg)
        {
            if (msg.Msg == WM_SYSCOMMAND)
            {
                try
                {
                    switch (msg.WParam.ToInt32())
                    {
                        // Actions for context menu
                        case CTXMENU1:
                            Process.Start("cmd.exe");
                            return;
                        case CTXMENU2:
                            if (Directory.Exists(@"C:\Windows\System32\WindowsPowerShell"))
                                Process.Start("powershell.exe");
                            else
                                MessageBox.Show("This Windows version doesn't have a\nC:\\Windows\\System32\\WindowsPowerShell folder.", AppDomain.CurrentDomain.FriendlyName);
                            return;
                        case CTXMENU3:
                            Process.Start("explorer.exe");
                            return;
                        case CTXMENU4:
                            Process.Start("control");
                            return;
                        case CTXMENU5:
                            Process.Start("regedit.exe");
                            return;
                        default:
                            break;
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine($"Cannot open process: {error}");
                }
            }
            base.WndProc(ref msg);
        }

        private void main_Load(object sender, EventArgs e)
        {
            SetLanguage();

            // Insert new items into context menu
            IntPtr MenuHandle = GetSystemMenu(this.Handle, false);
            InsertMenu(MenuHandle, 5, MF_BYPOSITION | MF_SEPARATOR, 0, string.Empty);
            InsertMenu(MenuHandle, 6, MF_BYPOSITION, CTXMENU1, "Open Command Prompt");
            InsertMenu(MenuHandle, 7, MF_BYPOSITION, CTXMENU2, "Open PowerShell");
            InsertMenu(MenuHandle, 8, MF_BYPOSITION, CTXMENU3, "Open Explorer");
            InsertMenu(MenuHandle, 9, MF_BYPOSITION, CTXMENU4, "Open Control Panel");
            InsertMenu(MenuHandle, 10, MF_BYPOSITION, CTXMENU5, "Open Registry");
        }

        private void SetLanguage()
        {
            // Default language (English)
            string sktitle = "Sticky Keys";
            string turnsktext = "Do you want to turn on Sticky Keys?";
            string skcontenttext = "Sticky Keys lets you use the SHIFT, CTRL, ALT, or Windows Logo keys by pressing one key at a time. The keyboard shortcut to turn on Sticky Keys is to press the SHIFT key 5 times.";
            string deactivatesktext = "Go to the Ease of Access Center to disable the keyboard shortcut";
            string skyes = "&Yes";
            string skno = "&No";

            switch (Thread.CurrentThread.CurrentCulture.Name)
            {
                // Multiple languages support
                case "it-IT":
                    sktitle = "Tasti permanenti";
                    turnsktext = "Attivare Tasti permanenti?";
                    skcontenttext = "Tasti permanenti consente di utilizzare combinazioni di tasti con MAIUSC, CTRL, ALT o il tasto logo Windows premendo un tasto alla volta. Per attivare Tasti permanenti, premere MAIUSC cinque volte.";
                    deactivatesktext = "Disabilita questa scelta rapida da tastiera nelle impostazioni della tastiera di Accesso Rapido";
                    skyes = "&Sì";
                    break;
            }

            this.Text = sktitle;
            labelturnsk.Text = turnsktext;
            labelskcontent.Text = skcontenttext;
            labeldeactivatedialog.Text = deactivatesktext;
            buttonYes.Text = skyes;
            buttonNo.Text = skno;
            Refresh();
        }

        private void labeldeactivatedialog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open settings
            try
            {
                Process.Start("ms-settings:easeofaccess-keyboard");
            }
            catch (Exception error)
            {
                if (error is Win32Exception || error is ObjectDisposedException)
                {
                    Process.Start("control");
                    Application.Exit();
                    return;
                }

                int code = GetErrorCode(error);
                MessageBox.Show($"Cannot open settings from {AppDomain.CurrentDomain.FriendlyName}:\n{error}", AppDomain.CurrentDomain.FriendlyName + " - Cannot open settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(code);
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
            try
            {
                tagSTICKYKEYS stk;
                stk.dwFlags = SKF_STICKYKEYSON | SKF_HOTKEYACTIVE;
                stk.cbSize = Marshal.SizeOf(typeof(tagSTICKYKEYS));
                IntPtr pObj = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(tagSTICKYKEYS)));
                Marshal.StructureToPtr(stk, pObj, false);
                SystemParametersInfoA(SPI_SETSTICKYKEYS, 0, pObj,
                    SPIF_UPDATEINIFILE | SPIF_SENDWININICHANGE);
                Marshal.FreeHGlobal(pObj);
            }
            catch (Exception error)
            {
                int code = GetErrorCode(error);
                MessageBox.Show($"Cannot change settings from {AppDomain.CurrentDomain.FriendlyName}: {error}\nThe current user will have to manually change the settings.", AppDomain.CurrentDomain.FriendlyName + " - Cannot change settings", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(code);
            }

            Application.Exit();
        }

        private int GetErrorCode(Exception error)
        {
            int code = 1;
            var w32ex = error as Win32Exception;
            if (w32ex == null)
                w32ex = error.InnerException as Win32Exception;
            if (w32ex != null)
                code = w32ex.ErrorCode;
            return code;
        }
    }
}
