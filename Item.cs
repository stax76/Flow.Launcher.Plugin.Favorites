
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Flow.Launcher.Plugin.Favorites
{
    class Item
    {
        public string Name { get; set; }
        public string Value { get; set; }

        private static string AssemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        
        string _iconPath;
        
        public string IconPath {
            get {
                if (_iconPath == null)
                {
                    if (Value != null && Value.StartsWith("http"))
                        _iconPath = Path.Combine(AssemblyDirectory, "Icons\\Web.ico");
                    else if (Value != null && Value.StartsWith("shell:"))
                        _iconPath = @"C:\Windows\explorer.exe";
                    else if (Value != null && Value.Contains(".") && File.Exists(Value))
                        _iconPath = Value;
                    else if (Directory.Exists(Value))
                        _iconPath = @"C:\Windows\explorer.exe";
                    else
                        _iconPath = Path.Combine(AssemblyDirectory, "Icons\\CommandLine.ico");
                }
                
                return _iconPath;
            }
        }
        
        public void Execute(bool asAdmin = false)
        {
            if (string.IsNullOrEmpty(Value))
                return;

            if (Value.Length > 3 && Value[1..].StartsWith(":\\") &&
                Value.Contains(" ") && (File.Exists(Value) || Directory.Exists(Value)))
            {
                Value = "\"" + Value + "\"";
            }

            Match match = Regex.Match(Value, "((?<file>[^\\s\"]+)|\"(?<file>.+?)\") *(?<args>[^\\f\\r]*)");

            var info = new ProcessStartInfo();

            bool controlKeyIsPressed = Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl);

            if (controlKeyIsPressed)
                info.FileName = Path.GetDirectoryName(match.Groups["file"].Value);
            else
            {
                info.FileName = match.Groups["file"].Value;
                info.Arguments = match.Groups["args"].Value;
            }
            
            info.UseShellExecute = true;

            if (asAdmin)
                info.Verb = "runas";

            using Process p = new Process() { StartInfo = info };

            try {
                p.Start();
            } catch { }
        }

        public static List<Item> LoadFile(string path)
        {
            List<Item> ret = new List<Item>();

            if (!File.Exists(path))
                return ret;

            foreach (string line in File.ReadAllLines(path))
            {
                if (!line.Contains("="))
                    continue;

                Item item = new Item() {
                    Name = line.Substring(0, line.IndexOf("=")).Trim(),
                    Value = line.Substring(line.IndexOf("=") + 1).Trim()
                };

                ret.Add(item);
            }
            
            return ret;
        }
        
        public static List<Item> Filter(List<Item> items, string value)
        {
            List<Item> ret = new List<Item>();

            if (string.IsNullOrEmpty(value) || value.Length == 1)
                return ret;

            string[] searches = value.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
            string valueLower = value.ToLower();

            // all searches
            if (searches.Length > 1)
            {
                foreach (Item item in items)
                {
                    bool notFound = false;

                    foreach (string search in searches)
                    {
                        if (!item.Name.ToLower().Contains(search.ToLower()) && !item.Value.ToLower().Contains(search.ToLower()))
                        {
                            notFound = true;
                            break;
                        }
                    }

                    if (notFound)
                        continue;
                    else
                        if (!ret.Contains(item))
                            ret.Add(item);
                }
            }

            // upper chars
            foreach (Item item in items)
            {
                if (ret.Contains(item))
                    continue;

                string upperChars = "";

                foreach (char ch in item.Name)
                    if (char.IsUpper(ch))
                        upperChars += ch;

                if (upperChars.ToLower().StartsWith(valueLower) && !ret.Contains(item))
                    ret.Add(item);
            }

            // name starts with
            foreach (Item item in items)
                if (item.Name.ToLower().StartsWith(valueLower) && !ret.Contains(item))
                    ret.Add(item);

            // name contains
            foreach (Item item in items)
                if (item.Name.ToLower().Contains(valueLower) && !ret.Contains(item))
                    ret.Add(item);

            // value contains
            foreach (Item item in items)
                if (item.Value.ToLower().Contains(valueLower) && !ret.Contains(item))
                    ret.Add(item);

            return ret;
        }
    }
}
