using Xunit;
using ATM;
using FluentAssertions;

namespace UnitTest
{
    public class ValidatorTests
    {
        [Fact]
        public void TestValidDataType_WithInvalidData_ReturnFalse()
        {
            //Arrange
            var invalidPin1 = "123456";
            var invalidPin2 = "hehe";
            var invalidOperation1 = "Z";
            var invalidOperation2 = "";
            var invalidFinancialAmount1 = "jdfjfjf";
            var invalidFinancialAccountNumber1 = "sdsfdfg";

            //Act
            var result1 = Validator.ValidDataType(Utilities.DataType.Pin, invalidPin1);
            var result2 = Validator.ValidDataType(Utilities.DataType.Pin, invalidPin2);
            var result3 = Validator.ValidDataType(Utilities.DataType.Operation, invalidOperation1);
            var result4 = Validator.ValidDataType(Utilities.DataType.Operation, invalidOperation2);
            var result5 = Validator.ValidDataType(Utilities.DataType.FinancialAmount, invalidFinancialAmount1);
            var result6 = Validator.ValidDataType(Utilities.DataType.AccountNumber, invalidFinancialAccountNumber1);

            //Asertion
            result1.Should().Be(false);
            result2.Should().Be(false);
            result3.Should().Be(false);
            result4.Should().Be(false);
            result5.Should().Be(false);
            result6.Should().Be(false);
        }
        [Fact]
        public void TestValidDataType_WithValidData_ReturnTrue()
        {
            //Arrange
            var validPin1 = "1234";
            var validPin2 = "0000";
            var validOperation1 = "W";
            var validOperation2 = "B";
            var validFinancialAmount1 = "-100";
            var validFinancialAccountNumber1 = "1200.05";

            //Act
            var result1 = Validator.ValidDataType(Utilities.DataType.Pin, validPin1);
            var result2 = Validator.ValidDataType(Utilities.DataType.Pin, validPin2);
            var result3 = Validator.ValidDataType(Utilities.DataType.Operation, validOperation1);
            var result4 = Validator.ValidDataType(Utilities.DataType.Operation, validOperation2);
            var result5 = Validator.ValidDataType(Utilities.DataType.FinancialAmount, validFinancialAmount1);
            var result6 = Validator.ValidDataType(Utilities.DataType.FinancialAmount, validFinancialAccountNumber1);

            //Asertion
            result1.Should().Be(true);
            result2.Should().Be(true);
            result3.Should().Be(true);
            result4.Should().Be(true);
            result5.Should().Be(true);
            result6.Should().Be(true);
        }
        [Fact]
        public void TestValidLine_WithValidData_ReturnTrue()
        {
            //Arrange
            var validAccountFunds1 = new string[] { "1000", "0" };
            var validAccountFunds2 = new string[] { "-1000", "10" };
            var validAccountFunds3 = new string[] { "1000.05", "10" };
            var validOperation1 = "W";
            var validOperation2 = "B";
            var validFinancialAmount1 = "-100";
            var validFinancialAccountNumber1 = "1200.05";

            //Act
            var result1 = Validator.ValidLine(Utilities.LineType.AccountFunds, validAccountFunds1);
            var result2 = Validator.ValidDataType(Utilities.DataType.Pin, validPin2);
            var result3 = Validator.ValidDataType(Utilities.DataType.Operation, validOperation1);
            var result4 = Validator.ValidDataType(Utilities.DataType.Operation, validOperation2);
            var result5 = Validator.ValidDataType(Utilities.DataType.FinancialAmount, validFinancialAmount1);
            var result6 = Validator.ValidDataType(Utilities.DataType.FinancialAmount, validFinancialAccountNumber1);

            //Asertion
            result1.Should().Be(true);
            result2.Should().Be(true);
            result3.Should().Be(true);
            result4.Should().Be(true);
            result5.Should().Be(true);
            result6.Should().Be(true);
        }
    }
}
