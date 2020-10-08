using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
     internal class Chequings : Account
    {
        public Chequings(double balance, double annualInterestRate) : base(balance,annualInterestRate)
        {
           
        }
        public new void MakeDeposit(double deposit)
        {
            base.MakeDeposit(deposit);
        }
        

        public new void MakeWithdrawl(double withdrawl)
        {
        
            if (base.balance - withdrawl < 0)
            {
                base.serviceCharge += 15;
                base.balance -= base.serviceCharge;
            }
            else
            {
                base.MakeWithdrawl(withdrawl);
            }
        }

        public new string CloseAndReport()
        {
            double monthlyFee = 5 + (base.numberofWithdrawls * 0.10);
            base.serviceCharge += monthlyFee;
            return base.CloseAndReport();
        }

    }
}
