namespace LoanInterestCalculator.Core.RepaymentCalendars
{
    public class RepaymentRow
    {
        private readonly decimal _interestRate;

        public RepaymentRow(int order, decimal repaymentAmount, decimal owedTotal, decimal interestRate)
        {
            _interestRate = interestRate;
            Order = order;
            RepaymentAmount = repaymentAmount;
            OwedTotal = owedTotal;
        }

        /// <summary>
        /// Effectively an index
        /// </summary>
        public int Order { get; }

        public decimal RepaymentAmount { get; }

        public decimal InterestAmount => OwedTotal * _interestRate;

        public decimal AmortizationAmount => CalculateAmortizationAmount();

        private decimal CalculateAmortizationAmount()
        {
            var result = RepaymentAmount - InterestAmount;

            // Correction for incorrect calculation (Math rounding to make it show the same result as in online calculator website)
            if (OwedTotal - result < 0)
            {
                result -= result - OwedTotal;
            }

            return result;
        }

        public decimal OwedTotal { get; }
    }
}