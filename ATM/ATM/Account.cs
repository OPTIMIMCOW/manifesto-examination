using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    class Account
    {
        public int Number { get; set; }
        public int Pin { get; set; }
        public int? Balance { get; set; } = null;
        public int? Overdraft { get; set; } = null;
    }
}
