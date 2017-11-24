using System.ComponentModel;

namespace MVVMFirstApplication.Model
{
    public class Student : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;

        public string FirstName
        {
            get
            {
                return _firstName;
            }

            set
            {
                if (_firstName == value)
                    return;

                _firstName = value;

                RaisePropertyChanged("FirstName");
                RaisePropertyChanged("FullName");
            }
        }

        public string LastName
        {
            get { return _lastName; }

            set
            {
                if (_lastName == value)
                    return;

                _lastName = value;

                RaisePropertyChanged("LastName");
                RaisePropertyChanged("FullName");
            }
        }

        public string FullName => _firstName + " " + _lastName;

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}