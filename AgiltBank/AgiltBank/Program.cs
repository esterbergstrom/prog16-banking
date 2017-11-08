using System;
using AgiltBank.States;
using AgiltBankLibrary.Data;

namespace AgiltBank
{
    public class Program
    {
        static void Main(string[] args)
        {
            var bankFileService = new BankFileService();
            var bankData = bankFileService.ReadBankDataFromFile("C:\\Users\\ester\\Documents\\bankdata-small.txt");
            
            var context = new Context(bankData);
            context.State = new Home(context);
        }
    }
}
