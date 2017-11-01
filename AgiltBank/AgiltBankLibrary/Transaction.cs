using System;
using System.Collections.Generic;
using System.Text;

namespace AgiltBankLibrary
{
    class Transaction
    {
        // TODO: Update with the right var for the id's 
        // TODO: Update with logic when the account class is done

        public bool Deposit(int accountId, decimal amount)
        {
            try
            {

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

            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
