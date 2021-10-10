using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

namespace ATM
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var jsonFileLocation = @"..\..\..\TestFile_ComplexTestCase.json";
            var inputInformation = DeserialiseJson(jsonFileLocation);
            if (inputInformation == null)
            {

                return;
            }

            Atm atm = null;
            InitialiseAtm(ref atm, inputInformation);

            while (atm.RowNumber != atm.InputData.Count)
            {
                UserInteraction(atm);
            }
        }
        public static List<string> DeserialiseJson(String path)
        {
            try
            {
                var inputJson = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<List<string>>(inputJson);
            }
            catch (Exception e)
            {
                // for logger $"Failed to deserialise JSON, Exception:{e}. Program Terminated";
                return null;
            }
        }
        public static void InitialiseAtm(ref Atm atm, List<string> inputInformation)
        {
            atm = new Atm { RowNumber = 0, InputData = inputInformation, Funds = int.Parse(inputInformation[0]) };
            atm.RowNumber++;
            atm.RowNumber++;
        }
        public static void UserInteraction(Atm atm)
        {
            var rowInformationSplit = SplitRowInformation(atm.InputData[atm.RowNumber]);
            var account = new Account { Number = int.Parse(rowInformationSplit[0]), Pin = int.Parse(rowInformationSplit[1]) };
            if (PinValid(account, rowInformationSplit[2]) == false)
            {
                Console.WriteLine("ACCOUNT_ERR");
                atm.RowNumber++;
                return;
            }
            atm.RowNumber++;
            SetAccountBalanceAndOverdraft(atm, account);
            HandleAccountOperations(atm, account);
        }
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
        public static void HandleAccountOperations(Atm atm, Account account)
        {
            while (atm.RowNumber < atm.InputData.Count)
            {
                var rowInformationSplit = SplitRowInformation(atm.InputData[atm.RowNumber]);
                switch (rowInformationSplit[0])
                {
                    case "":
                        atm.RowNumber++;
                        return;
                    case "B":
                        Console.WriteLine(account.Balance);
                        atm.RowNumber++;
                        break;
                    case "W":
                        var withdrawalAmount = int.Parse(rowInformationSplit[1]);
                        if (ValidTransaction(account, atm, withdrawalAmount))
                        {
                            account.Balance = account.Balance - withdrawalAmount;
                            atm.Funds = atm.Funds - withdrawalAmount;
                            Console.WriteLine(account.Balance);
                            atm.RowNumber++;
                            break;
                        }
                        atm.RowNumber++;
                        break;
                }
            }
        }
        public static void SetAccountBalanceAndOverdraft(Atm atm, Account account)
        {
            var rowInformationSplit = SplitRowInformation(atm.InputData[atm.RowNumber]);
            account.SetBalanceAndOverDraft(int.Parse(rowInformationSplit[0]), int.Parse(rowInformationSplit[1]));
            atm.RowNumber++;
        }
        public static bool ValidTransaction(Account account, Atm atm, int withdrawalAmount)
        {
            var accoutBalWithOverdraft = (int)account.Balance + (int)account.Overdraft;
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
        public static string[] SplitRowInformation(string inputInformationRow)
        {
            return inputInformationRow.Split(" ");
        }
    }
}
