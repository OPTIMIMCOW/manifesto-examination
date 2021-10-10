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

        [Fact]
        public void TestHandleAccountOperations_WithWithdrawTooLargeForATM_AtmFundsWillBeUnchanged()
        {
            //Arrange
            var inputData = new List<string>() { "1000", "", "12345678 1111 1111","10000 0", "W 1100" };
            Atm atm = new Atm { Funds = 1000, RowNumber = 4, InputData= inputData };
            Account account = new Account { Balance = 1000, Number = 12345678, Overdraft = 0, Pin = 1111 };

            //Act
            Program.HandleAccountOperations(atm, account);

            //Asertion
            atm.Funds.Should().Be(1000); 
            account.Balance.Should().Be(1000);
        }

        [Fact]
        public void TestHandleAccountOperations_WithWithDrawTooLargeForForAccount_AtmFundsWillBeUnchanged()
        {
            //Arrange
            var inputData = new List<string>() { "10000", "", "12345678 1111 1111", "10000 0", "W 1100" };
            Atm atm = new Atm { Funds = 10000, RowNumber = 4, InputData = inputData };
            Account account = new Account { Balance = 1000, Number = 12345678, Overdraft = 0, Pin = 1111 };

            //Act
            Program.HandleAccountOperations(atm, account);

            //Asertion
            atm.Funds.Should().Be(10000);
            account.Balance.Should().Be(1000);
        }

        [Fact]
        public void TestHandleAccountOperations_WithSubsequentWithDrawTooLargeForForAccount_AtmFundsWillBeUnchanged()
        {
            //Arrange
            var inputData = new List<string>() { "10000", "", "12345678 1111 1111", "10000 0", "W 1000", "W 9100" };
            Atm atm = new Atm { Funds = 10000, RowNumber = 4, InputData = inputData };
            Account account = new Account { Balance = 50000, Number = 12345678, Overdraft = 0, Pin = 1111 };

            //Act
            Program.HandleAccountOperations(atm, account);

            //Asertion
            atm.Funds.Should().Be(10000 - 1000);
            account.Balance.Should().Be(50000 - 1000);
        }
    }
}
