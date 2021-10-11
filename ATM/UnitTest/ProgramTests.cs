using System;
using Xunit;
using ATM;
using FluentAssertions;
using System.Collections.Generic;

namespace UnitTest
{
    public class ProgramTests
    {
        [Fact]
        public void TestDeserialiseJson_WithExampleDataset_ReturnValidListOfStrings()
        {
            //Arrange

            //Act
            var result = Program.DeserialiseJson(@"..\..\..\..\ATM\TestFile.json");

            //Asertion
            result.Should().HaveCount(15);
        }
    }
}
