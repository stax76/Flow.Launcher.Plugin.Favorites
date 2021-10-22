
## About
Favorites is a [Flow Launcher](https://flow-launcher.github.io/#/) plugin to
define favorite apps, files, folders and URLs.

The default behaviour of launcher apps is finding all apps that
can be found in the system. The Favorites plugin is different,
it let's users define apps using a INI like conf file.

More than just apps can be defined:

1. Files
2. Folders
3. URLs
4. Command lines

## Usage

Extract the files in the release and put them at:

`C:\Users\JonDoe\AppData\Roaming\FlowLauncher\Plugins\Flow.Launcher.Plugin.Favorites`

Create the definition file at:

`C:\Users\JonDoe\AppData\Roaming\FlowLauncher\Settings\Favorites.conf`

Here is an example configuration:

```
CPP Folder = C:\My Projects\CPP Projects
To Do = C:\Users\JonDoe\OneDrive\Documents\To Do.txt
Google = https://www.google.de
Last system events = wt -- powershell -nologo -noexit -command get-eventlog system | select -first 500
```

Pressing the Ctrl key does not open a file but instead the folder of the file.

There is a context menu to copy to the clipboard and to run as admin.

It's a huge task to define everything manually, the reward is getting
results that are not poluted with useless entries. The user has full control
over the results. Personally I use only two plugins, Browser Bookmarks
and Favorites.

![Screenshot](Screenshot.jpg)

## Links

https://www.winhelponline.com/blog/shell-commands-to-access-the-special-folders

https://www.tenforums.com/tutorials/77458-rundll32-commands-list-windows-10-a.html

https://www.tenforums.com/tutorials/78214-settings-pages-list-uri-shortcuts-windows-10-a.html

https://betanews.com/2015/06/19/windows-10-tips-settings-control-panel

https://www.ghacks.net/2017/06/10/windows-msc-files-overview

https://support.microsoft.com/de-de/topic/how-to-run-control-panel-tools-by-typing-a-command-bce95b4d-e8c2-1cd0-ee0d-027679d520a6
