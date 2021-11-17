using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using JetBrains.Annotations;
using LoanInterestCalculator.Commands;
using LoanInterestCalculator.Core.Loans;
using LoanInterestCalculator.Core.RepaymentCalendars;

namespace LoanInterestCalculator.ViewModels;

public class LoanCalculatorViewModel : INotifyPropertyChanged
{
    private ICommand _calculateLoanButton;
    private Loan _loan;
    private RepaymentCalendarViewModel _repaymentCalendarViewModel;
    
    [UsedImplicitly]
    public ICommand CalculateCommand => new CalculateLoanCommand(this, _loan);

    public decimal LoanAmount
    {
        get => _loan.LoanAmount.Amount;
        set
        {
            _loan.SetLoanAmount(new(value));
            OnPropertyChanged();
        }
    }

    public int InterestPercentage
    {
        get => _loan.InterestPercentage.Value;
        set
        {
            _loan.SetInterestPercentage(new(value));
            OnPropertyChanged();
        }
    }

    public int NumberOfYears
    {
        get => _loan.NumberOfYears.Value;
        set
        {
            _loan.SetNumberOfYears(new(value));
            OnPropertyChanged();
        }
    }

    public IntervalType IntervalType
    {
        get => _loan.IntervalType;
        set
        {
            _loan.SetIntervalType(value);
            OnPropertyChanged();
        }
    }

    public decimal AveragePayment { get; private set; }

    public decimal TotalPaidOut { get; private set; }

    public decimal DebtPaidOut { get; private set; }
    public LoanCalculatorViewModel()
    {
        _loan = new Loan(
            new LoanAmount(2000000m),
            new InterestPercentage(4),
            new NumberOfYears(20),
            IntervalType.Yearly);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Raises <see cref="PropertyChangedEventArgs"/> when property changes
    /// </summary>
    /// <param name="propertyName">String representing the property name</param>
    [NotifyPropertyChangedInvocator]
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    internal void CalculateLoanSummary()
    {
        AveragePayment = _loan.MonthlyPayment;
        OnPropertyChanged(nameof(AveragePayment));

        TotalPaidOut = _loan.TotalAmountToPayBack;
        OnPropertyChanged(nameof(TotalPaidOut));

        DebtPaidOut = _loan.InterestToBePaidTotal;
        OnPropertyChanged(nameof(DebtPaidOut));

        _repaymentCalendarViewModel = new RepaymentCalendarViewModel(new RepaymentCalendar(_loan));
        OnPropertyChanged(nameof(RepaymentCalendarViewModel));
    }
}