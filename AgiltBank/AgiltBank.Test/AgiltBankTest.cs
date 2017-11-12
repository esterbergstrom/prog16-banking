﻿using AgiltBankLibrary.Data;
using AgiltBankLibrary.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

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

        [TestMethod]
        public void CanCreateCustomer()
        {
            _bankData.AddCustomer(new Customer
            {
                Id = 1002,
                OrganisationNumber = "551234 - 6666",
                Name = "Emil Ekman",
                StreetAddress = "EkmanStreet 1",
                City = "EkmanCity",
                PostalCode = "S - 666 66",
                Country = "Sweden",
                PhoneNumber = "070 666 66 66"
            });

            Assert.IsNotNull(_bankData.GetCustomer(1002));
        }

        [TestMethod]
        public void CanRemoveCustomer() => Assert.IsTrue(_bankData.RemoveCustomer(1001));

        [TestMethod]
        public void RemoveCustomer_WithMoneyOnAccount_ShouldReturnFalse() => Assert.IsFalse(_bankData.RemoveCustomer(1005));

        [TestMethod]
        public void CanSearchCustomersByNameOrPostalCode()
        {
            const string query = "berglunds";
            Assert.IsTrue(_bankData.SearchCustomers(query)
                .All(c => c.Name.ToLower().Contains(query) || c.PostalCode.Contains(query)));
        }

        [TestMethod]
        public void CanOpenAccount() => _bankData.OpenAccount(1005);

        [TestMethod]
        public void CanRemoveAccount() => Assert.IsTrue(_bankData.RemoveAccount(13001));

        [TestMethod]
        public void CanWithdrawMoneyFromAccount() => Assert.IsTrue(_bankData.Withdrawal(14002, 100));

        [TestMethod]
        public void WithdrawNegativeMoney_ShouldReturnFalse() => Assert.IsFalse(_bankData.Withdrawal(14002, -100));

        [TestMethod]
        public void WithdrawMoreMoneyThanAccountBalance_ShouldReturnFalse() => Assert.IsFalse(_bankData.Withdrawal(14002, 10000));

        [TestMethod]
        public void CanDepositMoneyFromAccount() => Assert.IsTrue(_bankData.Deposit(14002, 100));

        [TestMethod]
        public void DepositNegativeMoney_ShouldReturnFalse() => Assert.IsFalse(_bankData.Deposit(14002, -100));

        [TestMethod]
        public void CanTransferMoneyBetweenAccounts() => Assert.IsTrue(_bankData.Transfer(14002, 14001, 50));

        [TestMethod]
        public void TransferNegativeMoney_ShouldReturnFalse() => Assert.IsFalse(_bankData.Transfer(14002, 14001, -50));

        [TestMethod]
        public void TransferMoreMoneyThanAccountBalance_ShouldReturnFalse() => Assert.IsFalse(_bankData.Transfer(14002, 14001, 10000));

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
                new Account { Id = 14001, Balance = 99, CustomerId = 1005 },
                new Account { Id = 14002, Balance = 9999, CustomerId = 1005 }
            };

            _bankData = new BankData(customers, accounts);
        }
    }
}
