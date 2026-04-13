using System;
using System.Windows.Input;

namespace FlowTextDesigner.App.Commands;

public class RelayCommand : ICommand
{
    // Co se má provést při Execute.
    private readonly Action _execute;
    // Volitelná podmínka, jestli je příkaz aktivní.
    private readonly Func<bool>? _canExecute;

    public RelayCommand(Action execute, Func<bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter) => _canExecute?.Invoke() ?? true;

    // Parameter se ignoruje, protože tato varianta je bez typu.
    public void Execute(object? parameter) => _execute();

    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
