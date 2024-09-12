using System.Windows.Input;

namespace up.suporte.Commands
{
    public class RelayCommand : ICommand
    {
        private Action<Object> _execute;
        private Func<Object, bool>? _canExecute;

        public RelayCommand(Action<Object> execute, Func<Object, bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute.Invoke(parameter ?? EventArgs.Empty);
        }

        public void Execute(object? parameter)
        {
            _execute?.Invoke(parameter ?? EventArgs.Empty);
        }
    }
}
