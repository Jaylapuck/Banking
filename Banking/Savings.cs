using System;

namespace Banking
{
    internal class Savings : Account
    {
        private CurrentStatus status;

        public Savings(double balance, double annualInterestRate) : base(balance, annualInterestRate)
        {
            CheckIfActive();
        }

        public new void MakeDeposit(double deposit)
        {
            CheckIfActive();
            if (status == CurrentStatus.inactive && base.balance > 25)
            {
                status = CurrentStatus.active;
                base.MakeDeposit(deposit);
            }
            else
            {
                base.MakeDeposit(deposit);
            }
        }

        public new void MakeWithdrawl(double withdrawl)
        {
            CheckIfActive();
            if (status == CurrentStatus.active)
            {
                base.MakeWithdrawl(withdrawl);
            }
            else if (status == CurrentStatus.inactive)
            {
                Console.WriteLine("Withdrawl denied, balance is under 25");
            }
        }

        public new string CloseAndReport()
        {
            CheckIfActive();
            if (base.numberofWithdrawls > 4)
            {
                base.serviceCharge = (base.numberofWithdrawls - 4);
            }
            Console.WriteLine("Account Status : " + status);
            return base.CloseAndReport();
        }

        public void CheckIfActive()
        {
            double balance = base.balance;
            if (base.balance < 25)
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