
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Flow.Launcher.Plugin.Favorites
{
    public class Favorites : IPlugin, IReloadable, IContextMenu
    {
        List<Item> _items = new List<Item>();

        public void Init(PluginInitContext context) => ReloadData();

        public static string AssemblyDirectory { get; } = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        public static string DataDirectory { get; } = Path.Combine(AssemblyDirectory, @"..\..\");

        public List<Result> LoadContextMenus(Result selectedResult)
        {
            List<Result> results = new List<Result>();

            results.Add(new Result()
            {
                Title = "Execute as admin",
                SubTitle = selectedResult.SubTitle,
                Action = e =>
                {
                    foreach (Item item in _items)
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
            List<Result> results = new List<Result>();
            int score = int.MaxValue - 100000;

            foreach (Item item in Item.Filter(_items, query.Search))
            {
                Item tempItem = item;
                score -= 5;

                results.Add(new Result()
                {
                    Title = tempItem.Name,
                    SubTitle = tempItem.Value,
                    IcoPath = tempItem.IconPath,
                    Score = score,
                    Action = e =>
                    {
                        tempItem.Execute();
                        return true;
                    }
                });
            }
            
            return results;
        }

        public void ReloadData()
        {
            string confFile = DataDirectory + @"Settings\Favorites.conf";
            _items = Item.LoadFile(confFile);
        }
    }
}
