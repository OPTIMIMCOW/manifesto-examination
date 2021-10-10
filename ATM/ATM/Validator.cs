using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM
{
    public static class Validator
    {
        public static bool PinValid(Account account, string inputPin)
        {
            int userInputPin = -1;
            try
            {
                userInputPin = int.Parse(inputPin);
            }
            catch (Exception e)
            {
                // for logger $"Failed to convert user pin to int for validation: Exception: {e}.;
            }
            if (account.Pin != userInputPin)
            {
                return false;
            }
            return true;
        }
        public static bool ValidTransaction(Account account, Atm atm, decimal withdrawalAmount)
        {
            var accoutBalWithOverdraft = account.Balance + account.Overdraft;
            if (accoutBalWithOverdraft < withdrawalAmount)
            {
                Console.WriteLine("FUNDS_ERR");
                return false;
            }
            else if (atm.Funds < withdrawalAmount)
            {
                Console.WriteLine("ATM_ERR");
                return false;
            }
            return true;
        }
        //public static bool ValidLine()
        //{

        //}
    }
}
