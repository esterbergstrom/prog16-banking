using System;
using System.Collections.Generic;
using System.Text;

namespace AgiltBank.States
{
    public class Withdrawal : State
    {
        public Withdrawal(Context context) : base(context, "Kontonummer?", "* Uttag *")
        {
            AccountId = -1;
            Amount = -1;

            Console.WriteLine(Header);
            Read();
        }

        public int AccountId { get; set; }
        public decimal Amount { get; set; }

        protected override void ProcessLine(string line)
        {
            if (AccountId == -1)
            {
                if (int.TryParse(line, out int id))
                {
                    AccountId = id;
                    Prompt = "Summa?";
                    Read();
                }
                else
                {
                    Console.WriteLine("Ett fel uppstod. Ange endast siffror.");
                }
            }
            else if (Amount == -1)
            {
                if (decimal.TryParse(line, out decimal amount))
                {
                    Amount = amount;

                    if (Context.BankData.Withdrawal(AccountId, Amount))
                    {
                        Console.WriteLine("Uttaget lyckades.");
                    }
                    else
                    {
                        Console.WriteLine("Ett fel uppstod.");
                    }
                }
                else
                {
                    Console.WriteLine("Ett fel uppstod. Ange endast siffror.");
                }
            }

            Console.WriteLine("Tryck för att fortsätta...");
            Console.ReadKey(true);

            Console.WriteLine();
            Context.State = new Home(Context);
        }
    }
}
