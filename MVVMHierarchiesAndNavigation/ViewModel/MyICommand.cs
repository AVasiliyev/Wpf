using System;
using System.Windows.Input;

namespace MVVMHierarchiesAndNavigation.ViewModel
{

    public class MyICommand<T> : ICommand
    {
        readonly Action<T> _targetExecuteMethod;
        readonly Func<T, bool> _targetCanExecuteMethod;

        public MyICommand(Action<T> executeMethod)
        {
            _targetExecuteMethod = executeMethod;
        }

        public MyICommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            _targetExecuteMethod = executeMethod;
            _targetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        #region ICommand Members

        bool ICommand.CanExecute(object parameter)
        {
            if (_targetCanExecuteMethod == null)
                return _targetExecuteMethod != null;

            var tparm = (T)parameter;
            return _targetCanExecuteMethod(tparm);
        }

        // Beware - should use weak references if command instance lifetime is
        // longer than lifetime of UI objects that get hooked up to command
 
        // Prism commands solve this in their implementation 

        public event EventHandler CanExecuteChanged = delegate { };

        void ICommand.Execute(object parameter)
        {
            if (_targetExecuteMethod != null)
            {
                _targetExecuteMethod((T)parameter);
            }
        }

        #endregion
    }
}