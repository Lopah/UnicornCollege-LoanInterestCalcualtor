namespace LoanInterestCalculator.Core.Loans
{
    public readonly struct Interval
    {
        public int PerYear { get; }

        public int Total { get; }

        public Interval(IntervalType intervalType, NumberOfYears numberOfYears) : this()
        {
            PerYear = CalculateInterval(intervalType);
            Total = CalculateInterval(intervalType) * numberOfYears.Value;
        }

        private static int CalculateInterval(IntervalType intervalType)
        {
            return intervalType switch
            {
                IntervalType.Monthly => 12,
                IntervalType.Yearly => 1,
                IntervalType.HalfYearly => 2,
                IntervalType.Quarterly => 4,
                IntervalType.Thirdly => 3,
                IntervalType.Sixthly => 6,
                IntervalType.Daily => 365,
                _ => throw new ArgumentOutOfRangeException(nameof(intervalType), intervalType, "Unknown Interval!")
            };
        }
    }
}