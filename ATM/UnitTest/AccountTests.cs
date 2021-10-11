using Xunit;
using ATM;
using FluentAssertions;
using System.Collections.Generic;

namespace UnitTest
{
    public class AccountTests
    {
        [Fact]
        public void TestCreateAcount_WithValidData_AccountPropertiesShouldAllBeInitialised()
        {
            //Arrange
            var accountNumber = 123456;
            var pinNumber = 1234;
            var accountBal = 10000;
            var overdraft = 100;

            //Act
            var result = new Account {Number= accountNumber, Pin= pinNumber, Balance= accountBal, Overdraft= overdraft } ;

            //Asertion
            result.Number.Should().Be(accountNumber);
            result.Pin.Should().Be(pinNumber);
            result.Balance.Should().Be(accountBal);
            result.Overdraft.Should().Be(overdraft);
        }
        [Fact]
        public void TestCreateAcount_WithLargeBalance_AccountPropertiesShouldAllBeInitialised()
        {
            //Arrange
            var accountBal = 1000000;

            //Act
            var result = new Account {Balance = accountBal};

            //Asertion
            result.Balance.Should().Be(accountBal);
        }
        [Fact]
        public void TestHandleAccountOperations_WithWithdrawTooLargeForATM_AtmFundsWillBeUnchanged()
        {
            //Arrange
            var inputData = new List<string>() { "1000", "", "12345678 1111 1111", "10000 0", "W 1100" };
            Atm atm = new Atm(inputData);
            atm.RowNumber = 4;
            Account account = new Account { Balance = 10000, Number = 12345678, Overdraft = 0, Pin = 1111 };

            //Act
            atm.HandleAccountOperations(account);

            //Asertion
            atm.Funds.Should().Be(1000);
            account.Balance.Should().Be(10000);
        }
        [Fact]
        public void TestHandleAccountOperations_WithWithDrawTooLargeForForAccount_AtmFundsWillBeUnchanged()
        {
            //Arrange
            var inputData = new List<string>() { "10000", "", "12345678 1111 1111", "10000 0", "W 1100" };
            Atm atm = new Atm(inputData);
            atm.RowNumber = 4;
            Account account = new Account { Balance = 1000, Number = 12345678, Overdraft = 0, Pin = 1111 };

            //Act
            atm.HandleAccountOperations(account);

            //Asertion
            atm.Funds.Should().Be(10000);
            account.Balance.Should().Be(1000);
        }
        [Fact]
        public void TestHandleAccountOperations_WithSubsequentWithDrawTooLargeForForAccount_AtmFundsWillBeUnchanged()
        {
            //Arrange
            var inputData = new List<string>() { "10000", "", "12345678 1111 1111", "10000 0", "W 1000", "W 9100" };
            Atm atm = new Atm(inputData);
            atm.RowNumber = 4;
            Account account = new Account { Balance = 50000, Number = 12345678, Overdraft = 0, Pin = 1111 };

            //Act
            atm.HandleAccountOperations(account);

            //Asertion
            atm.Funds.Should().Be(10000 - 1000);
            account.Balance.Should().Be(50000 - 1000);
        }
    }
}
