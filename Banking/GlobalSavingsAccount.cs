namespace Banking
{
    internal class GlobalSavingsAccount : Savings, IExchangable
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