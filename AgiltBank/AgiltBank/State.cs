using System;
using System.Collections.Generic;
using System.Text;

namespace AgiltBank
{
    public abstract class State
    {
        public delegate void MenuItemHandler();

        protected string _prompt = string.Empty;
        protected Dictionary<string, MenuItemHandler> _menuItems = new Dictionary<string, MenuItemHandler>();

        protected void Read()
        {
            Console.Write($"{_prompt}: ");

            if (_menuItems.Count < 1)
            {
                var line = Console.ReadLine();
                ProcessLine(line);
            }
            else
            {
                var key = Console.ReadKey().ToString();

                if (_menuItems.ContainsKey(key))
                {
                    _menuItems[key]();
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Read();
                }
            }
        }

        protected abstract void ProcessLine(string line);
    }
}
