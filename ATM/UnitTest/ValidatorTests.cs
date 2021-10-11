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
            var validAtmFunds1 = new string[] { "1000.05"};
            var validAtmFunds2 = new string[] { "-1000.05" };
            var validAtmFunds3 = new string[] { "1000" };
            var validBlank1 = new string[] { "" };
            var validAccountInfo1 = new string[] { "12341212", "1212", "1111" };
            var validUserOperation1 = new string[] { "W", "102020" };
            var validUserOperation2 = new string[] { "B" };

            //Act
            var result1 = Validator.ValidLineType(Utilities.LineType.AccountFunds, validAccountFunds1);
            var result2 = Validator.ValidLineType(Utilities.LineType.AccountFunds, validAccountFunds2);
            var result3 = Validator.ValidLineType(Utilities.LineType.AccountFunds, validAccountFunds3);
            var result4 = Validator.ValidLineType(Utilities.LineType.AtmFunds, validAtmFunds1);
            var result5 = Validator.ValidLineType(Utilities.LineType.AtmFunds, validAtmFunds2);
            var result6 = Validator.ValidLineType(Utilities.LineType.AtmFunds, validAtmFunds3);
            var result7 = Validator.ValidLineType(Utilities.LineType.Blank, validBlank1);
            var result8 = Validator.ValidLineType(Utilities.LineType.AccountInfo, validAccountInfo1);
            var result9 = Validator.ValidLineType(Utilities.LineType.UserOperation, validUserOperation1);
            var result10 = Validator.ValidLineType(Utilities.LineType.UserOperation, validUserOperation2);

            //Asertion
            result1.Should().Be(true);
            result2.Should().Be(true);
            result3.Should().Be(true);
            result4.Should().Be(true);
            result5.Should().Be(true);
            result6.Should().Be(true);
            result7.Should().Be(true);
            result8.Should().Be(true);
            result9.Should().Be(true);
            result10.Should().Be(true);
        }
        [Fact]
        public void TestValidLine_WithInValidData_ReturnFalse()
        {
            //Arrange
            var inValidAccountFunds1 = new string[] { "1000", "dfdfdf" };
            var inValidAccountFunds2 = new string[] { "-1000.11.11", "10" };
            var inValidAccountFunds3 = new string[] { "1000.05", "10", "10" };
            var inValidAtmFunds1 = new string[] { "sdsds" };
            var inValidAtmFunds2 = new string[] { "-1000.05", "10" };
            var inValidAtmFunds3 = new string[] { "1000.10.10" };
            var inValidBlank1 = new string[] { "*" };
            var inValidAccountInfo1 = new string[] { "-110001", "1212", "1111" };
            var inValidUserOperation1 = new string[] { "M", "102020" };
            var inValidUserOperation2 = new string[] { "W", "-1000" };
            var inValidBlank2 = new string[] { "","" };
            var inValidAccountInfo2 = new string[] { "110001", "1212" };


            //Act
            var result1 = Validator.ValidLineType(Utilities.LineType.AccountFunds, inValidAccountFunds1);
            var result2 = Validator.ValidLineType(Utilities.LineType.AccountFunds, inValidAccountFunds2);
            var result3 = Validator.ValidLineType(Utilities.LineType.AccountFunds, inValidAccountFunds3);
            var result4 = Validator.ValidLineType(Utilities.LineType.AtmFunds, inValidAtmFunds1);
            var result5 = Validator.ValidLineType(Utilities.LineType.AtmFunds, inValidAtmFunds2);
            var result6 = Validator.ValidLineType(Utilities.LineType.AtmFunds, inValidAtmFunds3);
            var result7 = Validator.ValidLineType(Utilities.LineType.Blank, inValidBlank1);
            var result8 = Validator.ValidLineType(Utilities.LineType.AccountInfo, inValidAccountInfo1);
            var result9 = Validator.ValidLineType(Utilities.LineType.UserOperation, inValidUserOperation1);
            var result10 = Validator.ValidLineType(Utilities.LineType.UserOperation, inValidUserOperation2);
            var result11 = Validator.ValidLineType(Utilities.LineType.Blank, inValidBlank2);
            var result12 = Validator.ValidLineType(Utilities.LineType.AccountInfo, inValidAccountInfo2);



            //Asertion
            result1.Should().Be(false);
            result2.Should().Be(false);
            result3.Should().Be(false);
            result4.Should().Be(false);
            result5.Should().Be(false);
            result6.Should().Be(false);
            result7.Should().Be(false);
            result8.Should().Be(false);
            result9.Should().Be(false);
            result10.Should().Be(false);
            result11.Should().Be(false);
            result12.Should().Be(false);
        }
    }
}
