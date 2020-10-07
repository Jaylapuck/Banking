using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    class GlobalSavingsAccount : Savings, IExchangable
    {
        public GlobalSavingsAccount(double balance, double annualInterestRate) : base(balance, annualInterestRate)
        {

        }
        public double USvalue(double usRates)
        {
           return base.Balance * usRates;
        }
    }
}