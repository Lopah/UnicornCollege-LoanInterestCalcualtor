namespace LoanInterestCalculator.Core.Loan
{
    /// <summary>
    /// Represents our entity
    /// </summary>
    public class Loan
    {
        public Loan(LoanAmount loanAmount, InterestPercentage percentage, NumberOfYears numberOfYears, Interval interval)
        {
            LoanAmount = loanAmount;
            InterestPercentage = percentage;
            NumberOfYears = numberOfYears;
            Interval = interval;
        }
        public LoanAmount LoanAmount { get; }

        public Interval Interval { get; }

        public InterestPercentage InterestPercentage { get; }

        public NumberOfYears NumberOfYears { get; }

        public decimal MonthlyPayment => new AnnualInterestRate(Interval, InterestPercentage, LoanAmount).TotalAnnuity;

        public decimal TotalAmountToPayBack => MonthlyPayment * (decimal)Interval.Total;

        public decimal InterestToBePaidTotal => TotalAmountToPayBack - LoanAmount.Amount;
    }
}