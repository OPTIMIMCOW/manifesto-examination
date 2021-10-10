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
            if (atm == null)
            {
                return;
            }

            try
            {
                atm.ProcessInputData();
            }
            catch (Exception e)
            {
                throw new Exception($"Exception: {e}");
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
        {// validate line before use here
            // return if line not valid
            atm = new Atm(inputInformation);
            atm.RowNumber++;
            atm.RowNumber++;
        }
    }
}
