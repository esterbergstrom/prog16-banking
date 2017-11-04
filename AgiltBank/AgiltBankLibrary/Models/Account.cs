using System;
using System.Collections.Generic;
using System.Text;

namespace AgiltBankLibrary.Models
{
    public class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
