using ExtensionClass;
using System.Text;

namespace Banking

{
    internal abstract class Account : IAccount
    {
        protected internal static double startingBalance;
        protected internal static double balance;
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
            Account.balance = balance;
            this.annualInterestRates = annualInterestRates;
            Account.startingBalance = balance;
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
            numberOfDeposit = 0;
            serviceCharge = 0;
            double valueChange = ((newBalance / startingBalance) * 100) - 100;

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
            stringBuilder.Append("%");
            stringBuilder.Append("\n");
            stringBuilder.Append("Service Charge: ");
            stringBuilder.Append(serviceCharge.ToNaMoneyFormat(true));
            stringBuilder.Append("\n");
            stringBuilder.Append("\n");
            stringBuilder.Append("MonthlyInterestRate: ");
            stringBuilder.Append(MonthlyInterestRate * 100);
            stringBuilder.Append("%\n");
            stringBuilder.Append("MontlyInterest: ");
            stringBuilder.Append(MonthlyInterest.ToNaMoneyFormat(true));
            stringBuilder.Append("\n");

            string Report = stringBuilder.ToString();

            return Report;
        }
    }
}