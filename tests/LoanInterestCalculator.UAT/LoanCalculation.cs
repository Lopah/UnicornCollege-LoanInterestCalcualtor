using FluentAssertions;
using LoanInterestCalculator.Core.Loan;
using Xunit;

namespace LoanInterestCalculator.UAT
{
    [Collection("High level loan calculation")]
    public class LoanCalculation
    {
        [Fact]
        public void Loan_WhenCreatedAccordingToWebsite_CalculatesValuesExactlyTheSame()
        {
            // 2 million
            var loanedAmount = 2m * 1000m * 1000m;

            var interestPercentage = 4;

            var repaymentDurationYears = 20;

            var interval = IntervalType.Monthly;

            var expectedAmounts = new
            {
                PaymentsAverageAmount = 12119.61m,
                TotalRepaid = 2908706.40m,
                InterestRepaid = 908706.40m
            };

            var numberOfYears = new NumberOfYears(repaymentDurationYears);

            var actualLoan = new Loan(
                new LoanAmount(loanedAmount),
                new InterestPercentage(interestPercentage),
                numberOfYears,
                new Interval(interval, numberOfYears));

            actualLoan.MonthlyPayment.Should().Be(expectedAmounts.PaymentsAverageAmount);
            actualLoan.TotalAmountToPayBack.Should().Be(expectedAmounts.TotalRepaid);
            actualLoan.InterestToBePaidTotal.Should().Be(expectedAmounts.InterestRepaid);
        }
    }
}