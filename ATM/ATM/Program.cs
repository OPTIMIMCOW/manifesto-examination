using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var jsonFileLocation = @"..\..\..\TestFile.json";
                var inputInformation = DeserialiseJson(jsonFileLocation);

                Atm atm = new Atm { RowNumber = 0, InputData = inputInformation, Funds = int.Parse(inputInformation[0]) };
                atm.RowNumber++;
                if (atm.InputData[atm.RowNumber] != "")
                {
                    throw new Exception($"Input Data Failure. Row{atm.RowNumber} was expexted to be empty but was {inputInformation[atm.RowNumber]}");
                }
                atm.RowNumber++;

                while (atm.RowNumber != atm.InputData.Count)
                {
                    UserInteraction(atm);
                    atm.RowNumber++;
                }
            }
            catch (Exception e)
            {
                // TODO add something for the logger or similar. 
            }
        }

        static List<string> DeserialiseJson(String path)
        {
            try
            {
                var inputJson = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<List<string>>(inputJson);
            }
            catch (Exception e)
            {
                throw new Exception($"Failed to deserialise JSON, error:{e}");
            }
        }
        static void UserInteraction(Atm atm)
        {
            var rowInformationSplit = SplitRowInformation(atm.InputData[atm.RowNumber]);
            var account = new Account { Number = int.Parse(rowInformationSplit[0]), Pin = int.Parse(rowInformationSplit[1]) };
            if (PinValid(account, rowInformationSplit[2]) == false)
            {
                Console.WriteLine("ACCOUNT_ERR");
                return;
            }
            atm.RowNumber++;
            SetAccountBalanceAndOverdraft(atm, account);
            HandleAccountOperations(atm, account);
        }
        static bool PinValid(Account account, string inputPin)
        {
            if (account.Pin != int.Parse(inputPin))
            {
                return false;
            }
            return true;
        }
        static void HandleAccountOperations(Atm atm, Account account)
        {
            while (atm.RowNumber < atm.InputData.Count)
            {
                var rowInformationSplit = SplitRowInformation(atm.InputData[atm.RowNumber]);
                switch (rowInformationSplit[0])
                {
                    case "":
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
        static void SetAccountBalanceAndOverdraft(Atm atm, Account account) {
            var rowInformationSplit = SplitRowInformation(atm.InputData[atm.RowNumber]);
            account.SetBalanceAndOverDraft(int.Parse(rowInformationSplit[0]), int.Parse(rowInformationSplit[1]));
            atm.RowNumber++;
        }
        static bool ValidTransaction(Account account, Atm atm, int withdrawalAmount)
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
        static string[] SplitRowInformation(string inputInformationRow)
        {
            return inputInformationRow.Split(" ");
        }
    }
}
