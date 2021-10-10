using System;
using System.Collections.Generic;
using System.Globalization;

namespace ATM
{
    interface IAtm
    {
        void ProcessInputData();
        void UserInteraction();
        void HandleAccountOperations(Account account);
        void SetAccountBalanceAndOverdraft(Account account);
    }
    public class Atm : IAtm
    {
        public decimal Funds { get; set; }
        public List<string> InputData { get; set; }
        public int RowNumber;
        public Atm(List<string> inputData)
        {
            RowNumber = 0;
            Funds = decimal.Parse(inputData[0], NumberStyles.AllowDecimalPoint | NumberStyles.Number);
            InputData = inputData;
        }
        public void ProcessInputData()
        {
            while (this.RowNumber != this.InputData.Count)
            {
                UserInteraction();
            }
        }
        public void UserInteraction()
        {
            var rowInformationSplit = Utilities.SplitRowInformation(this.InputData[this.RowNumber]);
            // validate line // if invalid then throw error
            var account = new Account { Number = int.Parse(rowInformationSplit[0]), Pin = int.Parse(rowInformationSplit[1]) };
            if (Validator.PinValid(account, rowInformationSplit[2]) == false)
            {
                Console.WriteLine("ACCOUNT_ERR");
                this.RowNumber++;
                return;
            }
            this.RowNumber++;
            SetAccountBalanceAndOverdraft(account);
            HandleAccountOperations(account);
        }
        public void HandleAccountOperations(Account account)
        {
            while (this.RowNumber < this.InputData.Count)
            {
                var rowInformationSplit = Utilities.SplitRowInformation(this.InputData[this.RowNumber]);
                switch (rowInformationSplit[0])
                {
                    case "":
                        this.RowNumber++;
                        return;
                    case "B":
                        Console.WriteLine(account.Balance);
                        this.RowNumber++;
                        break;
                    case "W":
                        var withdrawalAmount = decimal.Parse(rowInformationSplit[1], NumberStyles.AllowDecimalPoint | NumberStyles.Number);
                        if (Validator.ValidTransaction(account, this, withdrawalAmount))
                        {
                            account.Balance = account.Balance - withdrawalAmount;
                            this.Funds = this.Funds - withdrawalAmount;
                            Console.WriteLine(account.Balance);
                            this.RowNumber++;
                            break;
                        }
                        this.RowNumber++;
                        break;
                }
            }
        }
        public void SetAccountBalanceAndOverdraft(Account account)
        {
            var rowInformationSplit = Utilities.SplitRowInformation(this.InputData[this.RowNumber]);
            account.SetBalanceAndOverDraft(int.Parse(rowInformationSplit[0]), int.Parse(rowInformationSplit[1]));
            this.RowNumber++;
        }
    }
}
