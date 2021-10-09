using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;

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

                var rowNumber = 0;
                var atmFunds = int.Parse(inputInformation[rowNumber]);
                rowNumber++;
                if (inputInformation[rowNumber] != "")
                {
                    throw new Exception($"Input Data Failure. Row{rowNumber} was expexted to be empty but was {inputInformation[rowNumber]}");
                }
                rowNumber++;

                // start Interaction as a function
                while (rowNumber != inputInformation.Count)
                {
                    UserInteraction(ref rowNumber, inputInformation, atmFunds);
                    rowNumber++;
                }
            }
            catch (Exception e)
            {
                // TODO add something for the logger or similar. 
            }

            static List<string> DeserialiseJson(String path)
            {
                var inputJson = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<List<string>>(inputJson);
            }

            static void UserInteraction(ref int rowNumber, List<string> inputInformation, int atmFunds)
            {
                //TODO check line is not null
                // TODO check split is not null
                var rowInformationSplit = SplitRowInformation(inputInformation[rowNumber]);
                if (rowInformationSplit[1] != rowInformationSplit[2])
                {
                    Console.WriteLine("ACCOUNT_ERR");
                    return;
                }
                rowNumber++;
                HandleUserOperations(ref rowNumber, inputInformation, ref atmFunds);
            }

            static void HandleUserOperations(ref int rowNumber, List<string> inputInformation, ref int atmFunds)
            {
                var rowInformationSplit = SplitRowInformation(inputInformation[rowNumber]);
                var accoutBal = int.Parse(rowInformationSplit[0]);
                var accountBalWithOverdraft = accoutBal + int.Parse(rowInformationSplit[1]);
                rowNumber++;
                while (rowNumber < inputInformation.Count)
                {
                    rowInformationSplit = SplitRowInformation(inputInformation[rowNumber]);

                    switch (rowInformationSplit[0])
                    {
                        case "":
                            return;
                        case "B":
                            Console.WriteLine(accoutBal);
                            rowNumber++;
                            break;
                        case "W":
                            var withdrawalAmount = int.Parse(rowInformationSplit[1]);              
                            if (ValidTransaction(accountBalWithOverdraft, atmFunds, withdrawalAmount))
                            {
                                accoutBal = accoutBal - withdrawalAmount;
                                atmFunds = atmFunds - withdrawalAmount;
                                Console.WriteLine(accoutBal);
                                rowNumber++;
                                break;
                            }
                            rowNumber++;
                            break;
                    }
                }
            }

            static bool ValidTransaction(int accountBalWithOverdraft, int atmFunds, int withdrawalAmount )
            {
                if (accountBalWithOverdraft < withdrawalAmount)
                {
                    Console.WriteLine("FUNDS_ERR");
                    return false;
                }else if(atmFunds< withdrawalAmount)
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
}
