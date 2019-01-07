using System;
using System.Collections.Generic;
using System.Text;

namespace App2.Models
{
    class AccountStatement
    {
        public List<Account> accounts { get; set; }
        public double previousBalance { get; set; }
        public double currentBalance { get; set; }
        public int accountsReceivable { get; set; }
        public int accountsPayable { get; set; }
    }
}
