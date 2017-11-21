using System;
using System.Collections.Generic;
using System.Text;
using AgiltBankLibrary.Data;
using AgiltBankLibrary.Dtos;
using AgiltBankLibrary.Models;

namespace AgiltBank
{
    public class Context
    {
        public Context(Bank bankData)
        {
            BankData = bankData;
        }

        public Bank BankData { get; set; }
        public State State { get; set; }
    }
}
