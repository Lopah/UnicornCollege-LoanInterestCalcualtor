namespace LoanInterestCalculator.Core.RepaymentCalendar
{
    public class RepaymentRow
    {
        /// <summary>
        /// Effectively an index
        /// </summary>
        public int Order { get; set; }

        public decimal DueAmount { get; set; }
        
        public decimal InterestAmount { get; set; }

        public decimal AmortizationAmount { get; set; }
    }
}