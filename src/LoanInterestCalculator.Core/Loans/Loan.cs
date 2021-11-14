using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace LoanInterestCalculator.Core.Loans
{
    /// <summary>
    /// Represents our entity
    /// </summary>
    public class Loan
    {
        public Loan(LoanAmount loanAmount, InterestPercentage percentage, NumberOfYears numberOfYears,
            Interval interval)
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

        public AnnualInterestRate AnnualInterestRate =>
            new AnnualInterestRate(Interval, InterestPercentage, LoanAmount);

        public decimal MonthlyPercentageInterestRate => AnnualInterestRate.GetMonthlyPercentageRate();

        public decimal MonthlyPayment => AnnualInterestRate.TotalAnnuity;

        public decimal TotalAmountToPayBack => MonthlyPayment * (decimal)Interval.Total;

        public decimal InterestToBePaidTotal => TotalAmountToPayBack - LoanAmount.Amount;
    }
}