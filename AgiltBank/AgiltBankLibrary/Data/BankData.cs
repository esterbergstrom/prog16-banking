using AgiltBankLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace AgiltBankLibrary.Data
{
    public class BankData
    {
        public BankData(IEnumerable<Customer> customers, IEnumerable<Account> accounts)
        {
            Customers = customers.ToList();
            Accounts = accounts.ToList();
        }

        public IList<Customer> Customers { get; }
        public IList<Account> Accounts { get; }
    }
}
