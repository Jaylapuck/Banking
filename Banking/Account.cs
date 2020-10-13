using ExtensionClass;
using System.Text;

namespace Banking

{
    internal abstract class Account : IAccount
    {
        protected internal double startingBalance;
        protected internal double balance;
        protected internal double newBalance;
        protected internal double totalDeposits;
        protected internal int numberOfDeposit;
        protected internal double totalWithdrawls;
        protected internal int numberofWithdrawls;
        protected internal double annualInterestRates;
        protected internal double serviceCharge;

        protected internal double MonthlyInterestRate;
        protected internal double MonthlyInterest;

        protected internal enum CurrentStatus
        {
            active,
            inactive
        }

        public double StartingBalance { get { return startingBalance; } }
        public double Balance { get { return balance; } }

        public Account(double balance, double annualInterestRates)
        {
            this.annualInterestRates = annualInterestRates;
            this.startingBalance = balance;
        }

        public void MakeDeposit(double deposit)
        {
            balance += deposit;
            totalDeposits += deposit;
            numberOfDeposit++;
        }

        public void MakeWithdrawl(double withdrawl)
        {
            balance -= withdrawl;
            totalWithdrawls += withdrawl;
            numberofWithdrawls++;
        }

        public void CalculateInterest()
        {
            MonthlyInterestRate = annualInterestRates / 12;
            MonthlyInterest = newBalance * MonthlyInterestRate;
            newBalance += MonthlyInterest;
        }

        public string CloseAndReport()
        {
            //Calculate
            newBalance = startingBalance + balance;
            CalculateInterest();
            newBalance -= serviceCharge;

            double valueChange = ((newBalance - startingBalance) / startingBalance);

            //stringbuilder a report then send toString()
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Starting Balance: ");
            stringBuilder.Append(startingBalance.ToNaMoneyFormat(true));
            stringBuilder.Append("\n");
            stringBuilder.Append("Current Balance: ");
            stringBuilder.Append(balance.ToNaMoneyFormat(true));
            stringBuilder.Append("\n");
            stringBuilder.Append("New Starting Balance: ");
            stringBuilder.Append(newBalance.ToNaMoneyFormat(true));
            stringBuilder.Append("\n");
            stringBuilder.Append("Total amount of deposits: ");
            stringBuilder.Append(numberOfDeposit);
            stringBuilder.Append("\n");
            stringBuilder.Append("Total amount of Withdrawls: ");
            stringBuilder.Append(numberofWithdrawls);
            stringBuilder.Append("\n");
            stringBuilder.Append("Percentage Change from starting the current balances: ");
            stringBuilder.Append(valueChange.GetPercentageChange());
            stringBuilder.Append("\n");
            stringBuilder.Append("Service Charge: ");
            stringBuilder.Append(serviceCharge.ToNaMoneyFormat(true));
            stringBuilder.Append("\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("MonthlyInterestRate: ");
            string changeFormat = string.Format("{0:0.00}%", MonthlyInterestRate * 100);
            stringBuilder.Append(changeFormat);
            stringBuilder.Append("\n");
            stringBuilder.Append("MontlyInterest: ");
            stringBuilder.Append(MonthlyInterest.ToNaMoneyFormat(true));
            stringBuilder.Append("\n");

            string Report = stringBuilder.ToString();

            //Reset
            numberofWithdrawls = 0;
            numberOfDeposit = 0;
            serviceCharge = 0;
            balance = 0;
            startingBalance = newBalance;

            return Report;
        }
    }
}