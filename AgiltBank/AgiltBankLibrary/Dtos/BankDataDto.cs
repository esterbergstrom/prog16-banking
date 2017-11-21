using AgiltBankLibrary.Models;
using System.Collections.Generic;

namespace AgiltBankLibrary.Dtos
{
    public class BankDataDto
    {
        public IList<Customer> Customers { get; set; }
        public IList<Account> Accounts { get; set; }
    }
}
