using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace WpfAppDemo
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Employee _selectedEmployee;

        // public ObservableCollection<Phone> Phones { get; set; }
        public ObservableCollection<Employee> Employees { get; set; }
        public Employee SelectedEmployee
        {
            get { return _selectedEmployee; }
            set
            {
                _selectedEmployee = value;
                OnPropertyChanged("SelectedEmployee");
            }
        }

        private async Task<List<Employee>> GetEmployee()
        {
            List<Employee> dbEmployees;
            using (var db = new NorthWndEntities())
            {
                dbEmployees = db.Employees.ToList();
            }

            Employees = new ObservableCollection<Employee>(dbEmployees);

            return dbEmployees;
        }

        public NotifyTaskCompletion<int> UrlByteCount { get; private set; }

        public ApplicationViewModel()
        {
            UrlByteCount = new NotifyTaskCompletion<int>(CountBytesInUrlAsync());

            //await GetEmployee();

            //Phones = new ObservableCollection<Phone>
            //{
            //    new Phone {Title="iPhone 7", Company="Apple", Price=56000 },
            //    new Phone {Title="Galaxy S7 Edge", Company="Samsung", Price =60000 },
            //    new Phone {Title="Elite x3", Company="HP", Price=56000 },
            //    new Phone {Title="Mi5S", Company="Xiaomi", Price=35000 }
            //};

            //Task.Run(() =>
            //{
            //    Thread.Sleep(TimeSpan.FromSeconds(5));

            //    List<Employee> dbEmployees;
            //    using (var db = new NorthWndEntities())
            //    {
            //        dbEmployees = db.Employees.ToList();
            //    }

            //    Employees = new ObservableCollection<Employee>(dbEmployees);
            //}
            //);
        }

        private static async Task<int> CountBytesInUrlAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(3)).ConfigureAwait(false);
            //Thread.Sleep(TimeSpan.FromSeconds(3));
            return 159;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}