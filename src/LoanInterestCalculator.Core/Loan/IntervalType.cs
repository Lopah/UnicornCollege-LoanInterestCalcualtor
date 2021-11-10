namespace LoanInterestCalculator.Core.Loan
{
    public enum IntervalType
    {
        /// <summary>
        /// Period: One month
        /// <br/>
        /// Divide by: 12
        /// </summary>
        Monthly,
        /// <summary>
        /// Period: 12 months
        /// <br/>
        ///  Divide by: 1
        /// </summary>
        Yearly,
        /// <summary>
        /// Period: Six months.
        /// <br/>
        ///  Divide by: 2
        /// </summary>
        HalfYearly,
        /// <summary>
        /// Period: Three months.
        /// <br/>
        ///  Divide by: 4
        /// </summary>
        Quarterly,
        /// <summary>
        /// Period: Four months.
        /// <br/>
        ///  Divide by: 3
        /// </summary>
        Thirdly,
        /// <summary>
        /// Period: Two months
        /// <br/>
        ///  Divide by: 6
        /// </summary>
        Sixthly,
        /// <summary>
        /// Period: One day
        /// <br/>
        /// Divide by: 365
        /// </summary>
        Daily,
    }
}