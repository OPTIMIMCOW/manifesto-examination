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
            var jsonFileLocation = @"..\..\..\TestFile.json";
            var inputInformation = DeserialiseJson(jsonFileLocation);
            if (inputInformation == null)
            {
                return;
            }

            Atm atm = null;
            InitialiseAtm(ref atm, inputInformation);
            if(atm== null)
            {
                return;
            }
            atm.ProcessInputData();
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
        
        
        
        


    }
}
