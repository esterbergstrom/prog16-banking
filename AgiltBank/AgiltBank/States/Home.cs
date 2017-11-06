using System;
using System.Collections.Generic;
using System.Text;

namespace AgiltBank.States
{
    public class Home : State
    {
        public Home() : base("Huvudmeny")
        {
            MenuItems.Add("1", new MenuItem("Menu item", ConfirmChoice));

            Console.WriteLine(Header.ToUpper());
            WriteMenuItems();
            Console.WriteLine();
            Read();
        }

        protected override void ProcessLine(string line)
        {
            throw new NotImplementedException();
        }

        private void ConfirmChoice()
        {
            Console.WriteLine("Menu item selected");
            Console.WriteLine();
            Read();
        }
    }
}
