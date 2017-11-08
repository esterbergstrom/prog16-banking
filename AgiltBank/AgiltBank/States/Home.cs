using System;
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
            MenuItems.Add("3", new MenuItem("Skapa kund", ViewCustomerRegistration));
            MenuItems.Add("4", new MenuItem("Ta bort kund", ViewCustomerRemoval));
            MenuItems.Add("5", new MenuItem("Skapa konto", ViewAccountRegistration));

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

        private void ViewCustomerRegistration()
        {
            Context.State = new CustomerRegistration(Context);
        }

        private void ViewCustomerRemoval()
        {
            Context.State = new CustomerRemoval(Context);
        }

        private void ViewAccountRegistration()
        {
            Context.State = new AccountRegistration(Context);
        }
    }
}
