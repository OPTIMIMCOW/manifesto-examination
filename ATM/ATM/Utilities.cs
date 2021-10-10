using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public static class Utilities
    {
        public static string[] SplitRowInformation(string inputInformationRow)
        {
            return inputInformationRow.Split(" ");
        }
    }
}
