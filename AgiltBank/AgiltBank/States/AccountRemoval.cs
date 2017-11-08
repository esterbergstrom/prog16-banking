using System;
using System.Collections.Generic;
using System.Text;

namespace AgiltBank.States
{
    public class AccountRemoval : State
    {
        public AccountRemoval(Context context) : base(context, "Kontonummer?", "* Ta bort konto *")
        {
            Console.WriteLine(Header);
            Read();
        }

        protected override void ProcessLine(string line)
        {
            if (int.TryParse(line, out int id))
            {
                if (Context.BankData.RemoveAccount(id))
                {
                    Console.WriteLine("Kontot har tagits bort.");
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

            Console.WriteLine("Tryck för att fortsätta...");
            Console.ReadKey(true);

            Console.WriteLine();
            Context.State = new Home(Context);
        }
    }
}
