using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Banking
{
    class Savings : Account
    {

        public Savings(double balance, double annualInterestRate) : base(balance, annualInterestRate)
        {

        }
        public new void MakeDeposit(double deposit, CurrentStatus currentStatus)
        {
            if (currentStatus == CurrentStatus.inactive)
            {
                
            }
            else
            {
                base.MakeDeposit(deposit);
            }
        }

        public new void MakeWithdrawl(double withdrawl, CurrentStatus currentStatus)
        {
            if (currentStatus == CurrentStatus.inactive && base.balance > 25)
            {
                currentStatus = CurrentStatus.active;
            }
            else
            {
                base.MakeWithdrawl(withdrawl);
            }
        }

        public new void CloseAndReport()
        {
            if (base.numberofWithdrawls >= 4)
            {
                base.serviceCharge += (1 * (base.numberofWithdrawls - 3));
            }
            base.CloseAndReport();
        }
    }
}
