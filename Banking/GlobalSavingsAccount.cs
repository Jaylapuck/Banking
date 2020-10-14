using System;

namespace Banking
{
    internal class GlobalSavingsAccount : Savings, IExchangable
    {
        public GlobalSavingsAccount(double balance, double annualInterestRate) : base(balance, annualInterestRate)
        {
        }

        public double USvalue(double usRates)
        {
            double value = base.Balance * usRates;
            value = Math.Round(value, 2);
            return value;
        }
    }
}