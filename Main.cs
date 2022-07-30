
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Flow.Launcher.Plugin.Favorites
{
    public class Favorites : IPlugin, IReloadable, IContextMenu
    {
        List<Item> Items = new List<Item>();

        public void Init(PluginInitContext context) => ReloadData();

        public static string AssemblyDirectory { get; } = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string DataDirectory { get; } = Path.Combine(AssemblyDirectory, @"..\..\");
        public static DateTime LoadTime;

        public List<Result> LoadContextMenus(Result selectedResult)
        {
            List<Result> results = new List<Result>();

            results.Add(new Result()
            {
                Title = "Execute as admin",
                SubTitle = selectedResult.SubTitle,
                Action = e =>
                {
                    foreach (Item item in Items)
                        if (item.Name == selectedResult.Title && item.Value == selectedResult.SubTitle)
                            item.Execute(true);

                    return true;
                }
            });

            results.Add(new Result()
            {
                Title = "Copy to clipboard",
                SubTitle = selectedResult.SubTitle,
                Action = e =>
                {
                    System.Windows.Clipboard.SetText(selectedResult.SubTitle);
                    return true;
                }
            });

            return results;
        }

        public List<Result> Query(Query query)
        {
            string confFile = DataDirectory + @"Settings\Favorites.conf";

            if (LoadTime != File.GetLastWriteTimeUtc(confFile))
                ReloadData();

            List<Result> results = new List<Result>();
            int score = int.MaxValue - 100000;

            foreach (Item item in Item.Filter(Items, query.Search))
            {
                Item tempItem = item;
                score -= 5;
                string title = tempItem.Name;

                if (title.Contains("__"))
                    title = title.Replace("__", "!dbl!");

                if (title.Contains("_"))
                    title = title.Replace("_", "");

                if (title.Contains("!dbl!"))
                    title = title.Replace("!dbl!", "_");

                results.Add(new Result()
                {
                    Title = title,
                    SubTitle = tempItem.Value,
                    IcoPath = tempItem.IconPath,
                    Score = score,
                    ContextData = this,
                    Action = e =>
                    {
                        bool runAsAdmin = e.SpecialKeyState.CtrlPressed &&  e.SpecialKeyState.ShiftPressed &&
                                         !e.SpecialKeyState.AltPressed  && !e.SpecialKeyState.WinPressed;
                        tempItem.Execute(runAsAdmin);
                        return true;
                    }
                });
            }
            
            return results;
        }

        public void ReloadData()
        {
            string confFile = DataDirectory + @"Settings\Favorites.conf";
            Items = Item.LoadFile(confFile);
            LoadTime = File.GetLastWriteTimeUtc(confFile);
        }
    }
}
