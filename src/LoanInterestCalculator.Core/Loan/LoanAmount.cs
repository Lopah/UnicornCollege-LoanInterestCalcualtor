namespace LoanInterestCalculator.Core.Loan
{
    public readonly struct LoanAmount
    {
        public decimal Amount { get; }

        public LoanAmount(decimal amount)
        {
            Amount = amount;
        }
    }
}