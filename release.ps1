
dotnet publish Flow.Launcher.Plugin.Favorites -c Release -r win-x64
Compress-Archive -LiteralPath Flow.Launcher.Plugin.Favorites/bin/Release/win-x64/publish -DestinationPath Flow.Launcher.Plugin.Favorites/bin/Favorites.zip -Force
