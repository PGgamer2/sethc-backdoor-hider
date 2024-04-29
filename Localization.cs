using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace sethc
{
    public class Localization
    {
        [DllImport("kernel32.dll")]
        private static extern IntPtr LoadLibraryA(string lpLibFileName);
        [DllImport("user32.dll")]
        private static extern int LoadStringA(IntPtr hInstance, uint uID, StringBuilder lpBuffer, int nBufferMax);

        public static string getMUIstring(IntPtr resContainer, uint msgId)
        {
            StringBuilder pBuffer = new StringBuilder(512);
            if (LoadStringA(resContainer, msgId, pBuffer, 512) == 0) {
                MessageBox.Show($"Cannot find resource {msgId}.", AppDomain.CurrentDomain.FriendlyName + " - Error interpreting mui file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return pBuffer.ToString();
        }

        public static void SetLanguage(Main mainForm, int windowMode)
        {
            IntPtr resContainer = LoadLibraryA($"{Environment.GetFolderPath(Environment.SpecialFolder.Windows)}\\System32\\{CultureInfo.InstalledUICulture.Name}\\EaseOfAccessDialog.exe.mui");
            if (resContainer == null) {
                MessageBox.Show("Cannot read mui file.", AppDomain.CurrentDomain.FriendlyName + " - Error loading mui file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            mainForm.Text = getMUIstring(resContainer, 512);
            mainForm.labelturnsk.Text = getMUIstring(resContainer, 1138);
            mainForm.labelskcontent.Text = getMUIstring(resContainer, 1117);
            mainForm.labeldeactivatedialog.Text = getMUIstring(resContainer, 1143);
            mainForm.buttonYes.Text = getMUIstring(resContainer, 1135);
            mainForm.buttonNo.Text = getMUIstring(resContainer, 1134);
            mainForm.Refresh();
        }
    }
}
