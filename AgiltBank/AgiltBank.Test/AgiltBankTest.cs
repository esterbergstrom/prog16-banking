using System.Collections.Generic;
using AgiltBankLibrary.Data;
using AgiltBankLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgiltBank.Test
{
    [TestClass]
    public class AgiltBankTest
    {
        private BankData _bankData;

        [TestInitialize]
        public void Initialize()
        {
            InitializeBankData();
        }

        [TestMethod]
        public void CanGetCustomerFromBankData() => Assert.IsNotNull(_bankData.GetCustomer(1005));

        private void InitializeBankData()
        {
            var customers = new List<Customer>
            {
                new Customer
                {
                    Id = 1001,
                    OrganisationNumber = "551234 - 1234",
                    Name = "Tangooe",
                    StreetAddress = "Bankstreet 1",
                    City = "BankCity",
                    PostalCode = "S - 123 45",
                    Country = "Sweden",
                    PhoneNumber = "070 123 45 67"
                },
                new Customer
                {
                    Id = 1005,
                    OrganisationNumber = "234543 - 1234",
                    Name = "BankGuy",
                    StreetAddress = "Bankstreet 3",
                    City = "BankCity",
                    PostalCode = "S - 123 45",
                    Country = "Sweden",
                    PhoneNumber = "070 456 45 78"
                }
            };

            var accounts = new List<Account>
            {
                new Account { Id = 13001, Balance = 0, CustomerId = 1001 },
                new Account { Id = 13002, Balance = 1000000, CustomerId = 1001 },
                new Account { Id = 14001, Balance = 99, CustomerId = 1005 },
                new Account { Id = 14002, Balance = 9999, CustomerId = 1005 }
            };

            _bankData = new BankData(customers, accounts);
        }
    }
}
