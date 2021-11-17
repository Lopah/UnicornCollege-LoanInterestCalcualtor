using System.Linq;
using System.Security.Cryptography.X509Certificates;
using FluentAssertions;
using LoanInterestCalculator.Core.Loans;
using LoanInterestCalculator.Core.RepaymentCalendars;
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
                interval);

            actualLoan.MonthlyPayment.Should().Be(expectedAmounts.PaymentsAverageAmount);
            actualLoan.TotalAmountToPayBack.Should().Be(expectedAmounts.TotalRepaid);
            actualLoan.InterestToBePaidTotal.Should().Be(expectedAmounts.InterestRepaid);
        }

        [Fact]
        public void Loan_WhenCreatedAccordingToWebsite_CreatesTheSameRepaymentPlan()
        {
            // 2 million
            var loanedAmount = 2m * 1000m * 1000m;

            var interestPercentage = 4;

            var repaymentDurationYears = 20;

            var interval = IntervalType.Monthly;

            var numberOfYears = new NumberOfYears(repaymentDurationYears);

            var loan = new Loan(
                new LoanAmount(loanedAmount),
                new InterestPercentage(interestPercentage),
                numberOfYears,
                interval);

            var repaymentPlan = new RepaymentCalendar(loan);

            repaymentPlan.RepaymentRows().Should().HaveCount(241);
            repaymentPlan.RepaymentRows().Last().OwedTotal.Should().Be(0m);
        }
    }
}