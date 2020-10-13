using System;
using ExtensionClass;

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
            if (base.numberofWithdrawls > 4)
            {
                base.serviceCharge = (base.numberofWithdrawls - 4);
            }
            return base.CloseAndReport();
        }

        public void CheckIfActive()
        {
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