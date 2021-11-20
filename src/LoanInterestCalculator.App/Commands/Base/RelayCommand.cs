using System;
using System.Windows.Input;

namespace LoanInterestCalculator.Commands.Base;

public class RelayCommand : ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    private readonly Action<object> _methodToExecute;
    private readonly Func<bool>? _canExecuteEvaluator;

    public RelayCommand(Action<object> methodToExecute, Func<bool>? canExecuteEvaluator = null)
    {
        _methodToExecute = methodToExecute;
        _canExecuteEvaluator = canExecuteEvaluator;
    }

    public bool CanExecute(object? parameter) => _canExecuteEvaluator is null || _canExecuteEvaluator.Invoke();

    public void Execute(object? parameter) => _methodToExecute.Invoke(parameter!);
}