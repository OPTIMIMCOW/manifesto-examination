using System;
using System.Collections.Generic;
using System.Globalization;

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
        public static void ValidateLine(Utilities.LineType expectedType, Atm atm, List<string> inputInformation)
        {
            var rowInformationSplit = Utilities.SplitRowInformation(inputInformation[0]);
            if (ValidLineType(expectedType, rowInformationSplit) == false)
            {
                throw new Exception($"Line {0} was invalid. Processing Terminated");
            }
        }
        public static void ValidateLine(Utilities.LineType expectedType, string[] rowInformationSplit, int rowNumber)
        {
            if (ValidLineType(expectedType, rowInformationSplit) == false)
            {
                throw new Exception($"Line {rowNumber} was invalid. Processing Terminated");
            }
        }
        public static bool ValidLineType(Utilities.LineType expectedType, string[] actualLine)
        {
            switch (expectedType)
            {
                case Utilities.LineType.AccountFunds:
                    if (actualLine.Length != 2)
                    {
                        return false;
                    }
                    if (ValidDataType(Utilities.DataType.FinancialAmount, actualLine[0]) == false || ValidDataType(Utilities.DataType.FinancialAmount, actualLine[1]) == false)
                    {
                        return false;
                    }
                    return true;
                case Utilities.LineType.AccountInfo:
                    if (actualLine.Length != 3)
                    {
                        return false;
                    }
                    if (ValidDataType(Utilities.DataType.AccountNumber, actualLine[0]) == false || ValidDataType(Utilities.DataType.Pin, actualLine[1]) == false || ValidDataType(Utilities.DataType.Pin, actualLine[2]) == false)
                    {
                        return false;
                    }
                    return true;
                case Utilities.LineType.AtmFunds:
                    if (actualLine.Length != 1)
                    {
                        return false;
                    }
                    if (ValidDataType(Utilities.DataType.FinancialAmount, actualLine[0]) == false)
                    {
                        return false;
                    }
                    return true;
                case Utilities.LineType.Blank:
                    if (actualLine.Length != 1)
                    {
                        return false;
                    }
                    if (actualLine[0] != "" && actualLine[0] != "")
                    {
                        return false;
                    }
                    return true;
                case Utilities.LineType.UserOperation:
                    if (actualLine.Length == 2)
                    {
                        if (ValidDataType(Utilities.DataType.Operation, actualLine[0]) == false || ValidDataType(Utilities.DataType.WithdrawalAmount, actualLine[1]) == false)
                        {
                            return false;
                        }
                        return true;
                    }
                    if (actualLine.Length == 1)
                    {
                        if (actualLine[0] == "")
                        {
                            return true;
                        }
                        if (ValidDataType(Utilities.DataType.Operation, actualLine[0]) == false)
                        {
                            return false;
                        }
                        return true;
                    }
                    return false;
            }
            return false;
        }
        public static bool ValidDataType(Utilities.DataType expectedData, string actualData)
        {
            try
            {
                switch (expectedData)
                {
                    case Utilities.DataType.AccountNumber:
                        if (int.Parse(actualData) <= 0)
                        {
                            return false;
                        }
                        return true;
                    case Utilities.DataType.FinancialAmount:
                        decimal.Parse(actualData, NumberStyles.AllowDecimalPoint | NumberStyles.Number);
                        return true;
                    case Utilities.DataType.Pin:
                        if (actualData.Length != 4)
                        {
                            return false;
                        }
                        int.Parse(actualData);
                        return true;
                    case Utilities.DataType.Operation:
                        if (actualData != "W" && actualData != "B")
                        {
                            return false;
                        }
                        return true;
                    case Utilities.DataType.WithdrawalAmount:
                        if (decimal.Parse(actualData) <= 0)
                        {
                            return false;
                        }
                        return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }
    }
}
