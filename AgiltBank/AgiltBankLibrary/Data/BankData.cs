using AgiltBankLibrary.Models;
using System;
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

        public Customer GetCustomer(int id)
        {
            return Customers.FirstOrDefault(c => c.Id == id);
        }

        public void AddCustomer(Customer customer)
        {
            Customers.Add(customer);
        }

        public bool RemoveCustomer(int id)
        {
            var customer = Customers.FirstOrDefault(c => c.Id == id);
            return RemoveRelatedAccounts(id) && Customers.Remove(customer);
        }

        public IList<Customer> SearchCustomers(string query)
        {
            return Customers.Where(c => c.Name.ToLower().Contains(query.ToLower()) || c.PostalCode.Contains(query)).ToList();
        }

        public void OpenAccount(int customerId)
        {
            Accounts.Add(new Account
            {
                Id = ++Accounts.Last().Id,
                CustomerId = customerId,
                Balance = 0
            });
        }

        public bool RemoveAccount(int accountId)
        {
            var account = Accounts.FirstOrDefault(a => a.Id == accountId);
            if (account != null && account.Balance != 0)
                return false;

            return Accounts.Remove(account);
        }

        private bool RemoveRelatedAccounts(int customerId)
        {
            var accountsToRemove = Accounts.Where(a => a.CustomerId == customerId).ToList();

            if (accountsToRemove.Any(a => a.Balance != 0))
                return false;

            return accountsToRemove.All(a => Accounts.Remove(a));
        }

        public bool Deposit(int accountId, decimal amount)
        {
            try
            {
                if (amount > 0)
                    Accounts.FirstOrDefault(c => c.Id == accountId).Balance += amount;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Withdrawal(int accountId, decimal amount)
        {
            try
            {
                var account = Accounts.FirstOrDefault(c => c.Id == accountId);

                if (amount > 0 && account.Balance >= amount)
                    account.Balance -= amount;
                else
                    return false;
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public bool Transfer(int fromAccountId, int toAccountId, decimal amount)
        {
            try
            {
                var fromAccount = Accounts.FirstOrDefault(c => c.Id == fromAccountId);

                if (amount > 0 && fromAccount.Balance >= amount)
                {
                    fromAccount.Balance -= amount;
                    Accounts.FirstOrDefault(c => c.Id == toAccountId).Balance += amount;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
