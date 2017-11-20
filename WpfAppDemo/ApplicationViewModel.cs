using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

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

        public ApplicationViewModel(Window window)
        {
            //await GetEmployee();

            //Phones = new ObservableCollection<Phone>
            //{
            //    new Phone {Title="iPhone 7", Company="Apple", Price=56000 },
            //    new Phone {Title="Galaxy S7 Edge", Company="Samsung", Price =60000 },
            //    new Phone {Title="Elite x3", Company="HP", Price=56000 },
            //    new Phone {Title="Mi5S", Company="Xiaomi", Price=35000 }
            //};

            Task.Run(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(5));

                List<Employee> dbEmployees;
                using (var db = new NorthWndEntities())
                {
                    dbEmployees = db.Employees.ToList();
                }

                Employees = new ObservableCollection<Employee>(dbEmployees);
                window.Title = "Ready";
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}