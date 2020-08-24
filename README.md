# sethc.exe Backdoor Hider

**[Download](https://github.com/PGgamer2/sethc-backdoor-hider/releases/)**

To open the secret context menu **right click on the title bar**.
At the moment, if you press the "Yes" button you'll receive a **fake** error message (0x5) and the Sticky Keys settings will not be changed.

## What's this "sethc.exe"?
It's a Windows accessibility program (You can find it in your PC inside the System32 folder) that opens itself when you press shift 5 times.
It consists in a really simple message box that asks you if you want to turn on [Sticky Keys](https://en.wikipedia.org/wiki/Sticky_keys).

## What is this backdoor and how does it work?
You can open this program EVERYWHERE, even in the **log on screen** thanks to his "5 time shift" functionality.
So, if you replace it with another program, you can open *that* program everywhere.
If you try opening any software in the log on screen it will be opened with full admin rights because Windows isn't yet logged to any user.

At that point lot of people started replacing it (via another OS stored in their external hard-drive/USB) with cmd.exe to run any command with admin permissions without knowing any password.

# This program I made allows you to hide this backdoor by faking the Sticky Keys original message box.
In fact, if you **Right Click with you mouse on the title bar** you'll see an expanded context menu where you can open
* The Command Prompt
* PowerShell
* The Control Panel
* The Registry.

---

At the moment there are only two languages: English and italian...
But YOU can help me translating this program! Just modify the SetLanguage() function in the main.cs file and send me a pull request.
