using System;
using ExtensionClass;

namespace Banking
{
    internal class Chequings : Account
    {
        public Chequings(double balance, double annualInterestRate) : base(balance, annualInterestRate)
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
                Console.WriteLine("Withdrawl DECLINED, insufficient funds, 15 serviceCharge taken");
            }
            else
            {
                base.MakeWithdrawl(withdrawl);
            }
        }

        public new string CloseAndReport()
        {
            base.serviceCharge += 5 + (base.numberofWithdrawls * 0.10);
            return base.CloseAndReport();
        }
    }
}