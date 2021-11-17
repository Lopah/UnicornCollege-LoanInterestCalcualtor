namespace LoanInterestCalculator.Core.Loans
{
    /// <summary>
    /// Represents our entity
    /// </summary>
    public class Loan
    {
        public Loan(LoanAmount loanAmount, InterestPercentage percentage, NumberOfYears numberOfYears,
            IntervalType intervalType)
        {
            LoanAmount = loanAmount;
            InterestPercentage = percentage;
            NumberOfYears = numberOfYears;
            IntervalType = intervalType;
            Interval = new(intervalType, numberOfYears);
        }

        public LoanAmount LoanAmount { get; private set; }

        public IntervalType IntervalType { get; private set; }

        public Interval Interval { get; private set; }

        public InterestPercentage InterestPercentage { get; private set; }

        public NumberOfYears NumberOfYears { get; private set; }

        public AnnualInterestRate AnnualInterestRate => new(Interval, InterestPercentage, LoanAmount);

        public decimal MonthlyPercentageInterestRate => AnnualInterestRate.GetMonthlyPercentageRate();

        public decimal MonthlyPayment => AnnualInterestRate.TotalAnnuity;

        public decimal TotalAmountToPayBack => MonthlyPayment * (decimal)Interval.Total;

        public decimal InterestToBePaidTotal => TotalAmountToPayBack - LoanAmount.Amount;

        public void SetLoanAmount(LoanAmount amount)
        {
            LoanAmount = amount;
        }

        public void SetInterestPercentage(InterestPercentage interestPercentage)
        {
            InterestPercentage = interestPercentage;
        }

        public void SetNumberOfYears(NumberOfYears years)
        {
            NumberOfYears = years;
            Interval = new(IntervalType, years);
        }

        public void SetIntervalType(IntervalType intervalType)
        {
            IntervalType = intervalType;
            Interval = new Interval(intervalType, NumberOfYears);
        }
    }
}