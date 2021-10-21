
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

Ensure the Favorites Plugin is enabled in the Flow Launcher settings.

It's a huge task to define everything manually, the reward is getting
results that are not poluted with useless entries. The user has full control
over the results. Personally I use only two plugins, Browser Bookmarks
and Favorites.

![Screenshot](Screenshot.jpg)
