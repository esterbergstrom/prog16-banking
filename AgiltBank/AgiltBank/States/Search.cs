using System;
using System.Collections.Generic;
using System.Text;

namespace AgiltBank.States
{
    public class Search : State
    {
        public Search(Context context) : base(context, "Namn eller postort?", "* Sök kund *")
        {
            Console.WriteLine(Header);
            Read();
        }

        protected override void ProcessLine(string line)
        {
            var customers = Context.BankData.SearchCustomers(line);

            if (customers.Count > 0)
            {
                foreach (var customer in customers)
                {
                    Console.WriteLine($"{customer.Id}: {customer.Name}");
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Ett fel uppstod. Inga kunder hittades.");
            }

            Console.WriteLine("Tryck för att fortsätta...");
            Console.ReadKey(true);

            Console.WriteLine();
            Context.State = new Home(Context);
        }
    }
}
