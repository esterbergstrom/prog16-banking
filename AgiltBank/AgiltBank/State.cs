using System;
using System.Collections.Generic;
using System.Text;

namespace AgiltBank
{
    public abstract class State
    {
        public State(Context context, string prompt = "", string header = "")
        {
            Context = context;
            Header = header;
            Prompt = prompt;
            MenuItems = new Dictionary<string, MenuItem>();
        }
        
        public Context Context { get; set; }
        public string Header { get; set; }
        public string Prompt { get; set; }
        public Dictionary<string, MenuItem> MenuItems { get; set; }

        protected void WriteMenuItems()
        {
            foreach (var menuItem in MenuItems)
            {
                Console.WriteLine($"{menuItem.Key}) {menuItem.Value.Name}");
            }
        }

        protected void Read()
        {
            var prompt = !string.IsNullOrEmpty(Prompt) ? $"{Prompt} " : "> ";
            Console.Write(prompt);

            if (MenuItems.Count < 1)
            {
                var line = Console.ReadLine();
                ProcessLine(line);
            }
            else
            {
                var key = Console.ReadKey().KeyChar.ToString();
                Console.WriteLine();

                if (MenuItems.ContainsKey(key))
                {
                    MenuItems[key].Method();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Read();
                }
            }
        }

        protected abstract void ProcessLine(string line);

        public class MenuItem
        {
            public MenuItem(string name, MenuItemHandler method)
            {
                Name = name;
                Method = method;
            }

            public delegate void MenuItemHandler();
            
            public string Name { get; set; }
            public MenuItemHandler Method { get; set; }
        }
    }
}
