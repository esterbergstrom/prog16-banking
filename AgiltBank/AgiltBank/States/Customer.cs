using System;
using System.Collections.Generic;
using System.Text;

namespace AgiltBank.States
{
    public class Customer : State
    {
        public Customer(Context context) : base(context, "Kundnummer?", "* Visa kundbild *")
        {
            Console.WriteLine(Header);
            Read();
        }

        protected override void ProcessLine(string line)
        {
            if (int.TryParse(line, out int id))
            {
                var customer = Context.BankData.GetCustomer(id);

                if (customer != null)
                {
                    Console.WriteLine();
                    WriteCustomerSummary(customer);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Ett fel uppstod. Det finns ingen kund med det numret.");
                }
            }
            else
            {
                Console.WriteLine("Ett fel uppstod. Ange endast siffror.");
            }

            Console.WriteLine("Tryck för att fortsätta...");
            Console.ReadKey(true);

            Console.WriteLine();
            Context.State = new Home(Context);
        }

        private void WriteCustomerSummary(AgiltBankLibrary.Models.Customer customer)
        {
            Console.WriteLine($"Kundnummer: {customer.Id}");
            Console.WriteLine($"Namn: {customer.Name}");
        }
    }
}
