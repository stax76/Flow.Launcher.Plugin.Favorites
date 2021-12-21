
## About

Favorites is a [Flow Launcher](https://flow-launcher.github.io/#/)
plugin to define favorite apps, files, folders, URLs and command lines.

Launcher apps typically find all installed apps, the Favorites plugin
is different, it let's users define apps using a conf file, this has
the advantage getting clean results that are not cluttered with never
or rarely used items.

The Favorites plugin is ideal for people that prefer typing short
queries with few characters.

Also supported are:

1. Files
2. Folders
3. URLs
4. Command lines

## Usage

Extract the files in the release and put them at:

`C:\Users\JonDoe\AppData\Roaming\FlowLauncher\Plugins\Flow.Launcher.Plugin.Favorites`

Or use Flow Launcher's built-in Plugin Manager to install the Favorites plugin:

`pm install Favorites`

Create the definition file at:

`C:\Users\JonDoe\AppData\Roaming\FlowLauncher\Settings\Favorites.conf`

Or create it in the portable settings folder if you use portable mode.

Here is an example configuration:

```
Favorites = C:\Users\JonDoe\AppData\Roaming\FlowLauncher\Settings\Favorites.conf
VS Code = C:\Users\JonDoe\AppData\Local\Programs\Microsoft VS Code\Code.exe
CPP Folder = C:\My Projects\CPP
To Do = C:\Users\JonDoe\OneDrive\Documents\To Do.txt
Google = https://www.google.de
Last system events = wt -- powershell -nologo -noexit -command get-eventlog system | select -first 500
Wheater (Store/UWP/MSIX) = C:\Users\JonDoe\OneDrive\Shortcuts\Weather.lnk
```

Pressing the Ctrl key does not open a file but instead the folder of the file.

Pressing Ctrl+Shift starts as admin.

There is a context menu to copy to the clipboard and to run as admin.

Tip 1: To edit the favorites conf file use an text editor. Put new
entries on top so you don't have to navigate to the bottom all the
time. After editing the conf file refresh the definitions by pressing
F5 in Flow Launchers main window.

Tip 2: For Microsoft Store (UWP/MSIX) apps navigate File Explorer to
`Shell:AppsFolder`, in there you can search for apps and create
shortcuts (.lnk files) using the context menu.

Tip 3: The Favorites plugin detects changes of the Favorites.conf file
automatically and reloads the file.

![Screenshot](Screenshot.jpg)

## Links

https://www.winhelponline.com/blog/shell-commands-to-access-the-special-folders

https://www.tenforums.com/tutorials/77458-rundll32-commands-list-windows-10-a.html

https://www.ghacks.net/2017/06/10/windows-msc-files-overview

https://support.microsoft.com/de-de/topic/how-to-run-control-panel-tools-by-typing-a-command-bce95b4d-e8c2-1cd0-ee0d-027679d520a6

https://docs.microsoft.com/en-us/windows/uwp/launch-resume/launch-settings-app
