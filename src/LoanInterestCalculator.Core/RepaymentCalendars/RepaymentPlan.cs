using LoanInterestCalculator.Core.Loans;

namespace LoanInterestCalculator.Core.RepaymentCalendars
{
    public class RepaymentCalendar
    {
        private readonly Loan _loan;

        public RepaymentCalendar(Loan loan)
        {
            _loan = loan;
        }

        public IEnumerable<RepaymentRow> RepaymentRows()
        {
            var repayment = _loan.MonthlyPayment;

            var totalOwed = _loan.LoanAmount.Amount;

            var interest = _loan.MonthlyPercentageInterestRate;

            for (var i = 0; i < _loan.Interval.Total + 1; i++)
            {
                var row = new RepaymentRow(i, repayment, totalOwed, interest);

                totalOwed -= Math.Round(row.AmortizationAmount, 2, MidpointRounding.ToEven);

                yield return row;
            }
        }
    }
}