using System;
using MVVMValidations.Model;
using MVVMWPFDataTemplates.Interfaces;

namespace MVVMValidations.ViewModel
{
    internal class AddEditCustomerViewModel : BindableBase
    {

        public AddEditCustomerViewModel()
        {
            CancelCommand = new MyICommand(OnCancel);
            SaveCommand = new MyICommand(OnSave, CanSave);
        }

        private bool _editMode;

        public bool EditMode
        {
            get { return _editMode; }
            set { SetProperty(ref _editMode, value); }
        }

        private SimpleEditableCustomer _customer;

        public SimpleEditableCustomer Customer
        {
            get { return _customer; }
            set { SetProperty(ref _customer, value); }
        }

        public Customer EditingCustomer { get; private set; }

        public void SetCustomer(Customer cust)
        {
            EditingCustomer = cust;

            if (Customer != null)
                Customer.ErrorsChanged -= RaiseCanExecuteChanged;

            Customer = new SimpleEditableCustomer();
            Customer.ErrorsChanged += RaiseCanExecuteChanged;
            // CopyCustomer(cust, Customer);
        }

        private void RaiseCanExecuteChanged(object sender, EventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }

        public MyICommand CancelCommand { get; private set; }
        public MyICommand SaveCommand { get; private set; }

        public event Action Done = delegate { };

        private void OnCancel()
        {
            Done();
        }

        private void OnSave()
        {
            Done();
        }

        private bool CanSave()
        {
            if (Customer != null)
                return !Customer.HasErrors;

            return true;
        }
    }
}
