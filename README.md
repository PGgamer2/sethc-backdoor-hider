# sethc.exe Backdoor Hider

![Modified version of the original icon of the sethc.exe file](https://raw.githubusercontent.com/PGgamer2/sethc-backdoor-hider/master/icon.ico)

**[Download](https://github.com/PGgamer2/sethc-backdoor-hider/releases/)**

To open the modified context menu **right click on the title bar**.
Works on Windows XP and higher. Needs .NET Framework 4 or higher.

## What is this backdoor and how does it work?
Windows contains a feature called [sticky keys](https://en.wikipedia.org/wiki/Sticky_keys), which is an accessibility feature to help Windows users who have physical disabilities.
It essentially serializes keystrokes instead of pressing multiple keys at a time, so it allows the user to press and release a modifier key, such as Shift, Ctrl, Alt, or the Windows key, and have it remain active until any other key is pressed.
You activate sticky keys by pressing the Shift key 5 times. When you activate sticky keys, you are launching a file, C:\Windows\System32\sethc.exe, which executes as SYSTEM.
This is made into a backdoor by replacing the sethc.exe file with cmd.exe (renamed as sethc.exe). When you do this, you can activate sticky keys at the login prompt and you will get a SYSTEM command prompt.

# This program I made allows you to hide this backdoor by faking the sticky keys original window.
In fact, if you **right click with your mouse on the title bar** you'll see a slightly modified context menu where you can open
* The Command Prompt
* PowerShell
* Explorer
* The Control Panel
* The Registry.

---

At the moment there are only two languages: English and italian...

But YOU can help me translating this program! Just modify the SetLanguage() function in the main.cs file and send me a pull request.
