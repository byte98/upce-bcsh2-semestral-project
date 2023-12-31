using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Common;
using SemestralProject.Model;
using SemestralProject.Model.Entities;
using SemestralProject.Model.Enums;
using SemestralProject.Utils;
using SemestralProject.View.Components;
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
        /// Visibility of email in plain format
        /// </summary>
        [ObservableProperty]
        private Visibility plainEmailVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of email in masked format.
        /// </summary>
        [ObservableProperty]
        private Visibility maskedEmailVisibility = Visibility.Visible;

        /// <summary>
        /// Visibility of phone in plain format.
        /// </summary>
        [ObservableProperty]
        private Visibility plainPhoneVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of phone in masked format.
        /// </summary>
        [ObservableProperty]
        private Visibility maskedPhoneVisibility = Visibility.Visible;

        /// <summary>
        /// Data of view.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<UsersView> viewData;

        /// <summary>
        /// Actually selected data.
        /// </summary>
        [ObservableProperty]
        private UsersView? selectedData;


        /// <summary>
        /// Creates new view model for employees page.
        /// </summary>
        public EmployeesPageViewModel(): base(Model.Enums.PermissionNames.EmployeesModify)
        {
            this.employees = new ObservableCollection<Employee>();
            this.ViewData = new ObservableCollection<UsersView>();
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
            this.ViewData.Clear();
            ICollection<UsersView> data = await Task<ICollection<UsersView>>.Run( async() =>
            {
                IList<UsersView> reti = new List<UsersView>();  
                bool showPlainPhone = false;
                bool showPlainEmail = false;
                if (this.actualRole != null)
                {
                    showPlainPhone = this.actualRole.HasPermission(PermissionNames.PhonesRead);
                    showPlainEmail = this.actualRole.HasPermission(PermissionNames.EmailsRead);
                }
                IConnection conn = await OracleConnector.LoadAsync();
                string sql = "SELECT * FROM vw_uzivatele_data";
                IDictionary<string, object?>[] results = await conn.QueryAsync(sql);
                if (results.Length > 0)
                {
                    foreach (IDictionary<string, object?> row in results)
                    {
                        string phone = (string)(row["phone"] ?? string.Empty);
                        string email = (string)(row["email"] ?? string.Empty);
                        int? userId = (int?)row["id"];
                        User? user = null;
                        if (userId != null)
                        {
                            user = await User.GetByIdAsync((int)userId);
                        }
                        if (user != null)
                        {
                            if (showPlainEmail)
                            {
                                email = user.Employee.PersonalData.Email;
                            }
                            if (showPlainPhone)
                            {
                                phone = user.Employee.PersonalData.Phone;
                            }
                            reti.Add(new UsersView(user, email, phone));
                        }
                    }
                }
                return reti;
            });
            this.WaitVisibility = Visibility.Collapsed;
            this.ContentVisibility = Visibility.Visible;
            foreach(UsersView u in data)
            {
                this.ViewData.Add(u);
            }
        }



        /// <summary>
        /// Handles change of seleczed data.
        /// </summary>
        [RelayCommand]
        private void SelectedDataChanged()
        {
            if (this.SelectedData != null)
            {
                this.SelectedEmployee = this.SelectedData.Value.User.Employee;
            }
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
