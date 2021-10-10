using System;
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
    }
}
