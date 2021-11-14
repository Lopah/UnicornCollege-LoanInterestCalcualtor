using System.Windows.Input;
using LoanInterestCalculator.Commands;
using LoanInterestCalculator.Core.Loans;

namespace LoanInterestCalculator.ViewModels;

public class LoanCalculatorViewModel
{
    private RepaymentCalendarViewModel _repaymentCalendarView;
    private ICommand calculateLoanButton;
    private Loan _loan;
    public ICommand CalculateCommand
    {
        get => calculateLoanButton is null ? new CalculateLoanCommand() : calculateLoanButton;
        set => calculateLoanButton = value;
    }

    public decimal LoanAmount
    {
        get
        {
            return _loan.LoanAmount.Amount;
        }
    }

    public int InterestPercentage
    {
        get
        {
            return _loan.InterestPercentage.Value;
        }
    }

    public int NumberOfYears
    {
        get
        {
            return _loan.NumberOfYears.Value;
        }
    }

    public decimal AveragePayment
    {
        get
        {
            return _loan.MonthlyPayment;
        }
    }

    public decimal TotalPaidOut
    {
        get
        {
            return _loan.TotalAmountToPayBack;
        }
    }

    public decimal DebtPaidOut
    {
        get
        {
            return _loan.InterestToBePaidTotal;
        }
    }

    public Interval Interval
    {
        get => _loan.Interval;
    }
    public LoanCalculatorViewModel()
    {
        _loan = new Loan(
            new LoanAmount(2000000m),
            new InterestPercentage(4),
            new NumberOfYears(20),
            new Interval(IntervalType.Yearly, new NumberOfYears(20)));

    }
}