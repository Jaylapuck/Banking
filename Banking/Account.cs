using ExtensionClass;
using System.Text;

namespace Banking

{
    internal abstract class Account : IAccount
    {
        protected internal double startingBalance;
        protected internal double balance;
        private double totalDeposits;
        private int numberOfDeposit;
        private double totalWithdrawls;
        protected internal int numberofWithdrawls;
        private readonly double annualInterestRates;
        protected internal double serviceCharge;

        //CalculateInterest() and CloseAndReport()
        private double MonthlyInterestRate;

        private double MonthlyInterest;

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
            this.balance += balance;
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
            if (balance > 0)
            {
                MonthlyInterestRate = annualInterestRates / 12;
                MonthlyInterest = balance * MonthlyInterestRate;
                balance += MonthlyInterest;
            }
            else
            {
                MonthlyInterest = 0;
            }
        }

        public string CloseAndReport()
        {
            //Calculate and calling methods
            balance -= serviceCharge;
            CalculateInterest();

            //stringbuilder a report then send toString()
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Starting Balance: " + startingBalance.ToNaMoneyFormat(true));
            stringBuilder.Append("\n");
            stringBuilder.Append("MontlyInterest: +" + MonthlyInterest.ToNaMoneyFormat(true));
            stringBuilder.Append("\n");
            stringBuilder.Append("Service Charge: -" + serviceCharge.ToNaMoneyFormat(true));
            stringBuilder.Append("\n");
            stringBuilder.Append("New Starting Balance: " + balance.ToNaMoneyFormat(true));
            stringBuilder.Append("\n\n");
            stringBuilder.Append("Total amount of cumulative deposits: " + totalDeposits.ToNaMoneyFormat(true));
            stringBuilder.Append("\n");
            stringBuilder.Append("Total amount of cumulative Withdrawls: " + totalWithdrawls.ToNaMoneyFormat(true));
            stringBuilder.Append("\n");
            stringBuilder.Append("Total amount of deposits: " + numberOfDeposit);
            stringBuilder.Append("\n");
            stringBuilder.Append("Total amount of Withdrawls: " + numberofWithdrawls);
            stringBuilder.Append("\n");
            stringBuilder.Append("Monthly Interest Rate: " + string.Format("{0:0.00}%", MonthlyInterestRate * 100));
            stringBuilder.Append("\n");

            string Report = stringBuilder.ToString();

            //Reset Values
            numberofWithdrawls = 0;
            numberOfDeposit = 0;
            serviceCharge = 0;
            startingBalance = balance;

            return Report;
        }
    }
}