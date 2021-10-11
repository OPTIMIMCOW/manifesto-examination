using System;
using Xunit;
using ATM;
using FluentAssertions;
using System.Collections.Generic;

namespace UnitTest
{
    public class AtmTests
    {
        [Fact]
        public void TestCreateAtm_WithValidData_AtmPropertiesShouldAllBeInitialised()
        {
            //Arrange
            var inputData = new List<string>() { "1000", "", "12345678 1111 1111", "10000 0", "W 1100" };

            //Act
            Atm atm = new Atm(inputData);

            //Asertion
            atm.RowNumber.Should().Be(0);
        }
    }
}
