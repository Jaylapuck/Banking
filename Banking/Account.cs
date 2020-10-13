using ExtensionClass;
using System.Text;

namespace Banking

{
    internal abstract class Account : IAccount
    {
        protected internal double startingBalance;
        protected internal double balance;
        protected internal double totalDeposits;
        protected internal int numberOfDeposit;
        protected internal double totalWithdrawls;
        protected internal int numberofWithdrawls;
        protected internal double annualInterestRates;
        protected internal double serviceCharge;

        protected internal static double MonthlyInterestRate;
        protected internal static double MonthlyInterest;

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
            this.balance = balance;
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
            MonthlyInterest = balance * MonthlyInterestRate;
            balance += MonthlyInterest;
        }

        public string CloseAndReport()
        {
            //Reset and Calculate
            CalculateInterest();
            double newBalance = (balance -= serviceCharge);
            double valueChange = ((newBalance - startingBalance) / startingBalance);

            //stringbuilder a report then send toString()
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Previous Balance: ");
            stringBuilder.Append(startingBalance.ToNaMoneyFormat(true));
            stringBuilder.Append("\n");
            stringBuilder.Append("Balance: ");
            stringBuilder.Append(newBalance.ToNaMoneyFormat(true));
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

            numberofWithdrawls = 0;
            numberOfDeposit = 0;
            serviceCharge = 0;

            return Report;
        }
    }
}