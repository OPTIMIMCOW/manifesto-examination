using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Account
    {
        public int Number { get; set; }
        public int Pin { get; set; }
        public decimal? Balance { get; set; } = null;
        public decimal? Overdraft { get; set; } = null;

        public void SetBalanceAndOverDraft(decimal balance, decimal overdraft)
        {
            Balance = balance;
            Overdraft = overdraft;
        }
    }
}
