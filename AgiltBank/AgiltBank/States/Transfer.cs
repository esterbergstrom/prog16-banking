using System;
using System.Collections.Generic;
using System.Text;

namespace AgiltBank.States
{
    public class Transfer : State
    {
        public Transfer(Context context) : base(context, "Från kontonummer?", "* Överföring *")
        {
            GiverAccountId = -1;
            ReceiverAccountId = -1;
            Amount = -1;

            Console.WriteLine(Header);
            Read();
        }

        public int GiverAccountId { get; set; }
        public int ReceiverAccountId { get; set; }
        public decimal Amount { get; set; }

        protected override void ProcessLine(string line)
        {
            if (GiverAccountId == -1)
            {
                if (int.TryParse(line, out int id))
                {
                    GiverAccountId = id;
                    Prompt = "Till kontonummer?";
                    Read();
                }
                else
                {
                    Console.WriteLine("Ett fel uppstod. Ange endast siffror.");
                }
            }
            else if (ReceiverAccountId == -1)
            {
                if (int.TryParse(line, out int id))
                {
                    ReceiverAccountId = id;
                    Prompt = "Belopp?";
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

                    if (Context.BankData.Transfer(GiverAccountId, ReceiverAccountId, amount))
                    {
                        Console.WriteLine("Överföringen lyckades.");
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
