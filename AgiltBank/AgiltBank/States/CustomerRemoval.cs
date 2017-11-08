using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgiltBank.States
{
    public class CustomerRemoval : State
    {
        public CustomerRemoval(Context context) : base(context, "Kundnummer?", "* Ta bort kund *")
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
                    decimal customerBalance = 0;
                    var accounts = Context.BankData.Accounts.Where(a => a.CustomerId == customer.Id).ToList();

                    foreach (var account in accounts)
                    {
                        customerBalance += account.Balance;
                    }

                    if (customerBalance == 0)
                    {
                        Context.BankData.RemoveCustomer(customer.Id);
                        Console.WriteLine($"Kunden {customer.Name} har tagits bort.");
                    }
                    else
                    {
                        Console.WriteLine("Ett fel uppstod. Summan av kundens alla konton måste vara 0.");
                    }
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
    }
}
