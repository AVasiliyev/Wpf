using MVVMValidations.ViewModel;

namespace MVVMValidations
{
    internal class MainWindowViewModel : BindableBase
    {

        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
        }

        private readonly CustomerListViewModel _custListViewModel = new CustomerListViewModel();
        private readonly OrderViewModel _orderViewModelModel = new OrderViewModel();
        private readonly AddEditCustomerViewModel _addEditCustomerViewMode = new AddEditCustomerViewModel();

        private BindableBase _currentViewModel;

        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }

        public MyICommand<string> NavCommand { get; private set; }

        private void OnNav(string destination)
        {

            switch (destination)
            {
                case "orders":
                    CurrentViewModel = _orderViewModelModel;
                    break;

                case "addCustomer":
                    CurrentViewModel = _addEditCustomerViewMode;
                    break;
                default:
                    CurrentViewModel = _custListViewModel;
                    break;
            }
        }
    }
}