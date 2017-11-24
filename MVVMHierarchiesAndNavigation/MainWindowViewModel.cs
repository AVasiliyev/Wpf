using MVVMHierarchiesAndNavigation.ViewModel;

namespace MVVMHierarchiesAndNavigation
{
    internal class MainWindowViewModel : BindableBase
    {

        public MainWindowViewModel()
        {
            NavCommand = new MyICommand<string>(OnNav);
        }

        private readonly CustomerListViewModel _custListViewModel = new CustomerListViewModel();

        private readonly OrderViewModel _orderViewModelModel = new OrderViewModel();

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
                default:
                    CurrentViewModel = _custListViewModel;
                    break;
            }
        }
    }
}