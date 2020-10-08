using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        protected internal enum CurrentStatus
        {
            active,
            inactive
        }

        public double StartingBalance { get { return startingBalance; } }
        public double Balance { get { return balance; } }

        public Account(double balance, double annualInterestRates)
        {
            this.balance = balance;
            this.annualInterestRates = annualInterestRates;
        }
       
        public void MakeDeposit(double deposit)
        {
            balance += deposit;
            numberOfDeposit++;
        }

        public void MakeWithdrawl(double withdrawl)
        {
            balance -= withdrawl;
            numberofWithdrawls++;
        }

        public void CalculateInterest()
        {
            double MonthlyInterestRate = annualInterestRates / 12;
            double MonthlyInterest = balance * MonthlyInterestRate;
             balance += MonthlyInterest;
        }

        public string CloseAndReport()
        {

            double previousBalance = balance;
            double newBalance = (balance -= serviceCharge);
            CalculateInterest();
            numberOfDeposit = 0;
            serviceCharge = 0;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Previous Balance: ");
            stringBuilder.Append(previousBalance);
            stringBuilder.Append("\n");
            stringBuilder.Append("New Balance: ");
            stringBuilder.Append(balance);
            stringBuilder.Append("\n");
            stringBuilder.Append("Percentage Change from starting the current balances: ");
            double percentageChange = ((newBalance - startingBalance) / newBalance) * 100;
            stringBuilder.Append(percentageChange);
            stringBuilder.Append("\n");
            /*
            stringBuilder.Append("Details About the Calculated Intesrest: ");
            stringBuilder.Append("\n");
            stringBuilder.Append("MontlyInterestRate: ");
            stringBuilder.Append(MonthlyInterestRate);
            stringBuilder.Append("\n");
            stringBuilder.Append("MontlyInterest: ");
            stringBuilder.Append(MonthlyInterest);
            stringBuilder.Append("\n");
            */
            string Report = stringBuilder.ToString();

            return Report;
        }
    }
}