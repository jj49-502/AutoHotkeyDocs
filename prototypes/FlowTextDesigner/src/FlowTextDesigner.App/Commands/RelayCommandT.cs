using System;
using System.Windows.Input;

namespace FlowTextDesigner.App.Commands;

public class RelayCommandT<T> : ICommand
{
    // Typed execute handler (např. SelectPage(string pageId)).
    private readonly Action<T?> _execute;
    // Volitelná typed podmínka dostupnosti příkazu.
    private readonly Func<T?, bool>? _canExecute;

    public RelayCommandT(Action<T?> execute, Func<T?, bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged;

    public bool CanExecute(object? parameter)
    {
        // Pokud parameter odpovídá T, předáme typed hodnotu.
        if (parameter is T typed)
        {
            return _canExecute?.Invoke(typed) ?? true;
        }

        return _canExecute?.Invoke(default) ?? true;
    }

    public void Execute(object? parameter)
    {
        if (parameter is T typed)
        {
            _execute(typed);
            return;
        }

        // Fallback pro null/nesprávný typ.
        _execute(default);
    }

    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
