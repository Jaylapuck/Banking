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
       protected internal static CurrentStatus status;

        public Savings(double balance, double annualInterestRate) : base(balance, annualInterestRate)
        {
        
        }
        public new void MakeDeposit(double deposit)
        {
            checkIfActive();
            base.MakeDeposit(deposit);
                   
        }

        public new void MakeWithdrawl(double withdrawl)
        {
            checkIfActive();
            if (status == CurrentStatus.inactive && Account.balance > 25)
            {
                status = CurrentStatus.active;
                base.MakeWithdrawl(withdrawl);
            }
            else if (status == CurrentStatus.active)
            {
                base.MakeWithdrawl(withdrawl);
            }
            else if (status == CurrentStatus.inactive)
            {
                Console.WriteLine("The ammount will make your account go into the negatives, DECLINED");
            }
        }

        public new string CloseAndReport()
        {
            if (base.numberofWithdrawls > 4)
            {
                base.serviceCharge += (base.numberofWithdrawls - 4);
            }
            return base.CloseAndReport();
            
        }
        public void checkIfActive()
        {
            if (balance < 25)
            {
                status = CurrentStatus.inactive;
            }
            else
            {
                status = CurrentStatus.active;
            }
        }
    }
}
