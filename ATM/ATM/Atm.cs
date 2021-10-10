using System;
using System.Collections.Generic;

namespace ATM
{
    interface IAtm
    {
        void ProcessInputData();
    }
    public class Atm : IAtm
    {
        public decimal Funds { get; set; }
        public List<string> InputData { get; set; }
        public int RowNumber = 0;
        public void ProcessInputData()
        {
            while (this.RowNumber != this.InputData.Count)
            {
                UserInteraction();
            }
        }
        void UserInteraction()
        {
            var rowInformationSplit = Utilities.SplitRowInformation(this.InputData[this.RowNumber]);
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
                        var withdrawalAmount = decimal.Parse(rowInformationSplit[1]);
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
        void SetAccountBalanceAndOverdraft(Account account)
        {
            var rowInformationSplit = Utilities.SplitRowInformation(this.InputData[this.RowNumber]);
            account.SetBalanceAndOverDraft(int.Parse(rowInformationSplit[0]), int.Parse(rowInformationSplit[1]));
            this.RowNumber++;
        }
    }
}
