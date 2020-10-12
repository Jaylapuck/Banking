using System;

namespace Banking
{
    internal class Savings : Account
    {
        protected internal static CurrentStatus status;

        public Savings(double balance, double annualInterestRate) : base(balance, annualInterestRate)
        {
        }

        public new void MakeDeposit(double deposit)
        {
            CheckIfActive();
            base.MakeDeposit(deposit);
        }

        public new void MakeWithdrawl(double withdrawl)
        {
            CheckIfActive();
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

        public void CheckIfActive()
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