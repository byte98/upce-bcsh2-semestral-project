using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Model.Entities;
using SemestralProject.Utils;
using SemestralProject.View.Windows;
using SemestralProject.ViewModel.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SemestralProject.ViewModel.Pages
{
    /// <summary>
    /// Class which handles employees page.
    /// </summary>
    public partial class EmployeesPageViewModel: AbstractPageViewModel
    {


        /// <summary>
        /// Collection of all available employees.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Employee> employees;

        /// <summary>
        /// Actually selected employee.
        /// </summary>
        [ObservableProperty]
        private Employee? selectedEmployee;

        /// <summary>
        /// Creates new view model for employees page.
        /// </summary>
        public EmployeesPageViewModel(): base(Model.Enums.PermissionNames.EmployeesModify)
        {
            this.employees = new ObservableCollection<Employee>();
            WeakReferenceMessenger.Default.Register<EmployeesChangedMessage>(this, async (sender, args) =>
            {
                this.WaitVisibility = Visibility.Visible;
                this.ContentVisibility = Visibility.Collapsed;
                this.Employees.Clear();
                Employee[] emps = await Employee.GetAllAsync();
                foreach (Employee e in emps)
                {
                    this.Employees.Add(e);
                }
                this.WaitVisibility = Visibility.Collapsed;
                this.ContentVisibility = Visibility.Visible;
            });
        }

        /// <summary>
        /// Handles loading of page.
        /// </summary>
        [RelayCommand]
        private async Task PageLoaded()
        {
            this.WaitVisibility = Visibility.Visible;
            this.ContentVisibility = Visibility.Collapsed;
            this.Employees.Clear();
            Employee[] emps = await Employee.GetAllAsync();
            foreach(Employee e in emps)
            {
                this.Employees.Add(e);
            }
            this.WaitVisibility = Visibility.Collapsed;
            this.ContentVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles click on new button.
        /// </summary>
        [RelayCommand]
        private void New()
        {
            NewEmployeeWindow window = new NewEmployeeWindow();
            window.ShowDialog();
            WeakReferenceMessenger.Default.Send<EmployeesChangedMessage>(new EmployeesChangedMessage());
        }

        /// <summary>
        /// Handles click on edit button.
        /// </summary>
        [RelayCommand]
        private void Edit()
        {
            if (this.SelectedEmployee != null)
            {
                EmployeeDetailWindow window = new EmployeeDetailWindow();
                WeakReferenceMessenger.Default.Send<InfoEmployeeMessage>(new InfoEmployeeMessage(this.SelectedEmployee));
                window.ShowDialog();
                WeakReferenceMessenger.Default.Send<EmployeesChangedMessage>(new EmployeesChangedMessage());
            }
            
        }

        /// <summary>
        /// Handles click on delete button.
        /// </summary>
        [RelayCommand]
        private async Task Delete()
        {
            if (this.SelectedEmployee != null)
            {
                User[] users = await User.GetAllAsync();
                foreach(User user in users)
                {
                    if (user.Employee.Equals(this.SelectedEmployee))
                    {
                        await user.DeleteAsync();
                        WeakReferenceMessenger.Default.Send<UsersChangedMessage>(new UsersChangedMessage());
                        break;
                    }
                }
                await this.SelectedEmployee.DeleteAsync();
                WeakReferenceMessenger.Default.Send<EmployeesChangedMessage>(new EmployeesChangedMessage());
            }
        }
    }
}
