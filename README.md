
## About

Favorites is a [Flow Launcher](https://flow-launcher.github.io/#/)
plugin to define favorite apps, files, folders, URLs and command lines.

Launcher apps typically find all installed apps. The Favorites plugin
is different, it lets users define apps using a conf file. This has
the advantage of getting clean results that are not cluttered with items
which are never or rarely used.

The Favorites plugin is ideal for people that prefer typing short
queries with few characters.

Also supported are:

1. Files
2. Folders
3. URLs
4. Command lines

## Usage

### Installation

Extract the files in the release and put them at:

`%APPDATA%\FlowLauncher\Plugins\Flow.Launcher.Plugin.Favorites`

Or use Flow Launcher's built-in Plugin Manager to install the Favorites plugin:

`pm install Favorites`

### Setup the definition file

Create the definition file at:

`%APPDATA%\FlowLauncher\Settings\Favorites.conf`

Or create it in the portable settings folder if you use portable mode.
You can find this folder by searching for "userdata" in FlowLauncher.

Now fill the definition file with the items you want to add to your Favorites.

Here is an example configuration:

```
Favorites = %APPDATA%\FlowLauncher\Settings\Favorites.conf
VS Code = %LOCALAPPDATA%\Programs\Microsoft VS Code\Code.exe
CPP Folder = C:\My Projects\CPP
To Do = %USERPROFILE%\OneDrive\Documents\To Do.txt
Google = https://www.google.de
Last system events = wt -- powershell -nologo -noexit -command get-eventlog system | select -first 500
Wheater (Store/UWP/MSIX) = %USERPROFILE%\OneDrive\Shortcuts\Weather.lnk
```
### Controls

Press the Ctrl key to open the folder of the file, rather than the file itself.

Press Ctrl+Shift to launch a file as admin.

There is a context menu to copy an entry to the clipboard or to run it as admin.

### Miscellanea

To edit the Favorites.conf file, use a text editor, for instance Sublime Text.
Use Flow Launcher to open the file as shown in the example below.
The Favorites plugin detects changes of the Favorites.conf file
automatically and reloads the file automatically.

For Microsoft Store (UWP/MSIX) apps, navigate File Explorer to
`Shell:AppsFolder`. In there you can search for apps and create
shortcuts (.lnk files) using the context menu. These shortcuts can then
be used to start the app.

Underscores have a special meaning: they enable single character
input matching. The character after the underscore is matched.

Environment variables are expanded.

![Screenshot](Screenshot.jpg)

## Links

https://www.winhelponline.com/blog/shell-commands-to-access-the-special-folders

https://www.tenforums.com/tutorials/77458-rundll32-commands-list-windows-10-a.html

https://www.ghacks.net/2017/06/10/windows-msc-files-overview

https://support.microsoft.com/de-de/topic/how-to-run-control-panel-tools-by-typing-a-command-bce95b4d-e8c2-1cd0-ee0d-027679d520a6

https://docs.microsoft.com/en-us/windows/uwp/launch-resume/launch-settings-app

## List of my apps

https://stax76.github.io/frankskare
