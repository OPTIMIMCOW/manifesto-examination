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
            try
            {
                var jsonFileLocation = @"..\..\..\TestFile.json";
                var inputInformation = DeserialiseJson(jsonFileLocation);

                Atm atm = null;
                InitialiseAtm(ref atm, inputInformation);

                atm.ProcessInputData();
            }
            catch (Exception e)
            {
                Console.WriteLine($" An Exception was thrown: {e}");
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
                throw new Exception($"Failed to deserialise JSON, Exception:{e}. Processing Terminated");
            }
        }
        public static void InitialiseAtm(ref Atm atm, List<string> inputInformation)
        {
            Validator.ValidateLine(Utilities.LineType.AtmFunds, atm, inputInformation);
            atm = new Atm(inputInformation);
            atm.RowNumber++;

            var rowInformationSplit = Utilities.SplitRowInformation(atm.InputData[atm.RowNumber]);
            Validator.ValidateLine(Utilities.LineType.Blank, rowInformationSplit, atm.RowNumber);
            atm.RowNumber++;
        }
    }
}
