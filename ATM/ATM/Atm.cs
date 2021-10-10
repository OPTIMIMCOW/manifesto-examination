using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public class Atm
    {
        public decimal Funds { get; set; }
        public List<string> InputData { get; set; }
        public int RowNumber = 0;
    }
}
