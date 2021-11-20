using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using JetBrains.Annotations;
using LoanInterestCalculator.Commands.Base;
using LoanInterestCalculator.Core.Loans;
using LoanInterestCalculator.Core.RepaymentCalendars;
using LoanInterestCalculator.Helpers;
using Microsoft.Win32;

namespace LoanInterestCalculator.ViewModels;

public sealed class LoanCalculatorViewModel : INotifyPropertyChanged
{
    public Loan Loan { get; private set; }

    public RepaymentCalendarViewModel? RepaymentCalendarViewModel { get; private set; }

    [UsedImplicitly]
    public ICommand CalculateCommand =>
        new RelayCommand((_) => CalculateLoanSummary(),
            () => LoanAmount > 0 && InterestPercentage > 0 && NumberOfYears > 0);

    [UsedImplicitly]
    public ICommand GenerateExportCommand => new RelayCommand((_) => ExportToCsv(),
        () => RepaymentCalendarViewModel?.RepaymentRows.Count > 0);

    private void ExportToCsv()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var sDialog = new SaveFileDialog
        {
            InitialDirectory = basePath,
            Filter = "CSV file (*.csv)|*.csv| All Files (*.*)|*.*",
            Title = "Save Repayment Calendar",
            CreatePrompt = true,
            OverwritePrompt = true,
            DefaultExt = ".csv",
            AddExtension = true,
            ValidateNames = true,
            FileName = $"Repayment-Calendar_{DateTime.Now:hh-mm-ss}"
        };

        sDialog.FileOk += async (_, _) =>
            await EnumerableToCsvHelper.GenerateCsv(RepaymentCalendarViewModel!.RepaymentRows, sDialog.OpenFile());
        
        sDialog.ShowDialog();
    }

    [UsedImplicitly]
    public decimal LoanAmount
    {
        get => Loan.LoanAmount.Amount;
        set
        {
            Loan.SetLoanAmount(new(value));
            OnPropertyChanged();
        }
    }

    [UsedImplicitly]
    public int InterestPercentage
    {
        get => Loan.InterestPercentage.Value;
        set
        {
            Loan.SetInterestPercentage(new(value));
            OnPropertyChanged();
        }
    }

    [UsedImplicitly]
    public int NumberOfYears
    {
        get => Loan.NumberOfYears.Value;
        set
        {
            Loan.SetNumberOfYears(new(value));
            OnPropertyChanged();
        }
    }

    [UsedImplicitly]
    public IntervalType IntervalType
    {
        get => Loan.IntervalType;
        set
        {
            Loan.SetIntervalType(value);
            OnPropertyChanged();
        }
    }

    public decimal AveragePayment { get; private set; }

    public decimal TotalPaidOut { get; private set; }

    public decimal DebtPaidOut { get; private set; }

    public LoanCalculatorViewModel()
    {
        Loan = new Loan(
            new LoanAmount(0m),
            new InterestPercentage(0),
            new NumberOfYears(0),
            IntervalType.Yearly);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Raises <see cref="PropertyChangedEventArgs"/> when property changes
    /// </summary>
    /// <param name="propertyName">String representing the property name</param>
    [NotifyPropertyChangedInvocator]
    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void CalculateLoanSummary()
    {
        AveragePayment = Loan.MonthlyPayment;
        OnPropertyChanged(nameof(AveragePayment));

        TotalPaidOut = Loan.TotalAmountToPayBack;
        OnPropertyChanged(nameof(TotalPaidOut));

        DebtPaidOut = Loan.InterestToBePaidTotal;
        OnPropertyChanged(nameof(DebtPaidOut));

        RepaymentCalendarViewModel = new RepaymentCalendarViewModel(new RepaymentCalendar(Loan));
        OnPropertyChanged(nameof(RepaymentCalendarViewModel));
        
        
    }
}