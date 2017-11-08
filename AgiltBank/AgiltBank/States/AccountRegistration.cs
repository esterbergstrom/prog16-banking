using System;
using System.Collections.Generic;
using System.Text;

namespace AgiltBank.States
{
    public class AccountRegistration : State
    {
        public AccountRegistration(Context context) : base(context, "Kundnummer?", "* Skapa konto *")
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
                    Context.BankData.OpenAccount(customer.Id);
                    Console.WriteLine("Konto skapat.");
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
