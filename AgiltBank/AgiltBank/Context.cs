using System;
using System.Collections.Generic;
using System.Text;
using AgiltBankLibrary.Data;

namespace AgiltBank
{
    public class Context
    {
        public Context(BankData bankData)
        {
            BankData = bankData;
        }

        public BankData BankData { get; set; }
        public State State { get; set; }
    }
}
