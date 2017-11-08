﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AgiltBank.States
{
    public class Home : State
    {
        public Home(Context context) : base(context, string.Empty, "Huvudmeny")
        {
            MenuItems.Add("1", new MenuItem("Visa kundbild", ViewCustomer));
            MenuItems.Add("2", new MenuItem("Sök kund", ViewSearch));

            Console.WriteLine(Header.ToUpper());
            WriteMenuItems();
            Console.WriteLine();
            Read();
        }

        protected override void ProcessLine(string line)
        {
            throw new NotImplementedException();
        }

        private void ViewSearch()
        {
            Context.State = new Search(Context);
        }

        private void ViewCustomer()
        {
            Context.State = new Customer(Context);
        }
    }
}
