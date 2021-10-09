using System;
using Xunit;
using ATM;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;
using FluentAssertions;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public async void TestDeserialiseJson_WithExampleDataset_ReturnValidListOfStrings()
        {
            //Arrange


            //Act
            var result = Program.DeserialiseJson(@"..\..\..\..\ATM\TestFile.json");

            //Asertion
            result.Should().HaveCount(15);
        }

        [Fact]
        public async void TestHandleAccountOperations_WithInvalidTransaction_AtmFundsWillBeUnchanged()
        {
            ////Arrange
            
            //Atm atm = new Atm {Funds=1000, RowNumber=0, };

            ////Act
            //var result = Program.DeserialiseJson(@"..\..\..\..\ATM\TestFile.json");

            ////Asertion
            //result.Should().HaveCount(15);

            //Console.WriteLine($"NewLine: {Environment.NewLine}  first line{Environment.NewLine}  second line");
        }
    }
}
