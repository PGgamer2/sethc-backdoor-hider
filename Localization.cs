using System.Threading;

namespace sethc
{
	public class Localization
	{
		public static void SetLanguage(Main mainForm)
		{
			// English (Default language)
			string sktitle = "Sticky Keys";
			string turnsktext = "Do you want to turn on Sticky Keys?";
			string skcontenttext = "Sticky Keys lets you use the SHIFT, CTRL, ALT, or Windows Logo keys by pressing one key at a time. The keyboard shortcut to turn on Sticky Keys is to press the SHIFT key 5 times.";
			string deactivatesktext = "Go to the Ease of Access Center to disable the keyboard shortcut";
			string skyes = "&Yes";
			string skno = "&No";

			switch (Thread.CurrentThread.CurrentCulture.Name)
			{
				case "it-IT": // Italian
					sktitle = "Tasti permanenti";
					turnsktext = "Attivare Tasti permanenti?";
					skcontenttext = "Tasti permanenti consente di utilizzare combinazioni di tasti con MAIUSC, CTRL, ALT o il tasto logo Windows premendo un tasto alla volta. Per attivare Tasti permanenti, premere MAIUSC cinque volte.";
					deactivatesktext = "Disabilita questa scelta rapida da tastiera nelle impostazioni della tastiera di Accesso Rapido";
					skyes = "&Sì";
					// Italian "No" and English "No" are the same.
					break;
				case "zh-CN": // Chinese PRC
					sktitle = "粘滞键";
					turnsktext = "你想启用粘滞键吗?";
					skcontenttext = "通过一次按一个键，粘滞键允许使用 Shift、Ctrl、Alt 或 Windows徽标键。启用粘滞键的键盘快捷方式是按 5 次 Shift 键。";
					deactivatesktext = "在“轻松使用”键盘设置中禁用此键盘快捷方式";
					skyes = "&是(Y)";
					skno = "&否(N)";
					break;
			}

			mainForm.Text = sktitle;
			mainForm.labelturnsk.Text = turnsktext;
			mainForm.labelskcontent.Text = skcontenttext;
			mainForm.labeldeactivatedialog.Text = deactivatesktext;
			mainForm.buttonYes.Text = skyes;
			mainForm.buttonNo.Text = skno;
			mainForm.Refresh();
		}
	}
}
