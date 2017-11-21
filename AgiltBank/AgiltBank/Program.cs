using System;
using System.IO;
using System.Reflection;
using AgiltBank.States;
using AgiltBankLibrary.Data;
using AgiltBankLibrary.Models;

namespace AgiltBank
{
    public class Program
    {
        static void Main(string[] args)
        {
            var bankFileService = new BankFileService();
            var bankData = bankFileService.ReadBankDataFromFile("C://bankdata-small.txt");
            
            var context = new Context(new Bank(bankData.Customers, bankData.Accounts, "SuperBank"));
            context.State = new Home(context);

            Console.WriteLine("Tack för att du använder agilt-bank");
        }
    }
}
