namespace LoanInterestCalculator.Core.Loans
{
    public readonly struct AnnualInterestRate
    {
        private readonly Interval _interval;
        private readonly InterestPercentage _percentage;
        private readonly LoanAmount _loanAmount;

        public AnnualInterestRate(Interval interval, InterestPercentage percentage, LoanAmount loanAmount) : this()
        {
            _interval = interval;
            _percentage = percentage;
            _loanAmount = loanAmount;

            TotalAnnuity = CalculateAnnuity();
        }

        public decimal GetMonthlyPercentageRate()
        {
            return _percentage.Percentage / _interval.PerYear;
        }

        private decimal GetYearlyPercentageRate()
        {
            var monthlyPercentageRate = GetMonthlyPercentageRate();
            return 1m / (1m + monthlyPercentageRate);
        }

        public decimal CalculateAnnuity()
        {
            var monthlyPercentage = GetYearlyPercentageRate();
            var annuityTotal =
                (_percentage.Percentage * _loanAmount.Amount) /
                (1m - ((decimal)Math.Pow((double)monthlyPercentage, (double)_interval.Total)));


            var annuity = annuityTotal / _interval.PerYear;

            return Math.Round(annuity, 2, MidpointRounding.ToEven);
        }


        public decimal TotalAnnuity { get; }
    }
}