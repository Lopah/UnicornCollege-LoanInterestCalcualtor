using LoanInterestCalculator.ViewModels;
using System;
using System.Windows.Input;

namespace LoanInterestCalculator.Commands;

public class CalculateLoanCommand : ICommand
{
    private readonly LoanCalculatorViewModel _loanCalculatorViewModel;
    private readonly RepaymentCalendarViewModel _repaymentCalendarViewModel;
    public CalculateLoanCommand(LoanCalculatorViewModel loanCalculatorViewModel, RepaymentCalendarViewModel repaymentCalendarViewModel)
    {
        _loanCalculatorViewModel = loanCalculatorViewModel;
        _repaymentCalendarViewModel = repaymentCalendarViewModel;
    }

    public bool CanExecute(object? parameter) => true;

    /// <summary>Defines the method to be called when the command is invoked.</summary>
    /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
    public void Execute(object? parameter)
    {
        
    }

    /// <summary>Occurs when changes occur that affect whether or not the command should execute.</summary>
    public event EventHandler? CanExecuteChanged;
}