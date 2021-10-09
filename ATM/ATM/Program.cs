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
            // assume json input (an array representing each row)
            // deserialise json into an array
            // scan through line by line: 
            // make global variable for total cash in program.cs
            // create class for each user:
            // 1) variable total ballance available
            // 2) variable to hold account number
            // 3) variable for correct pin number
            // 4) method to authenticate pin number
            // authenticate pin, if pass then read through transactions and handle each sequentially else return
            // 5) method to check if withdrawal is ok if not return 
            // 6) method to update the ballance
            // when blank line hit, return final balance.  repeat above steps
            // when row == arr.length end script.
            var JsonFileLocation = @"..\..\..\TestFile.json";
            DeserialiseJson(JsonFileLocation);

        }
        public static List<string> DeserialiseJson(String path)
        {
            var inputJson = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<string>>(inputJson);
        }
    }
}
