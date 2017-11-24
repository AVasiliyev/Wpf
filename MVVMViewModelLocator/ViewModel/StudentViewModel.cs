using System.Collections.ObjectModel;
using MVVMViewModelLocator.Model;

namespace MVVMViewModelLocator.ViewModel
{
    public class StudentViewModel
    {
        public StudentViewModel()
        {
            LoadStudents();
        }

        public ObservableCollection<Student> Students
        {
            get;
            set;
        }

        public void LoadStudents()
        {
            var students = new ObservableCollection<Student>
            {
                new Student {FirstName = "Mark", LastName = "Allain"},
                new Student {FirstName = "Allen", LastName = "Brown"},
                new Student {FirstName = "Linda", LastName = "Hamerski"},
                new Student {FirstName = "Linda", LastName = "Hamerski"}
            };


            Students = students;
        }
    }
}