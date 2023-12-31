using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Common;
using SemestralProject.Model.Entities;
using SemestralProject.Utils;
using SemestralProject.View.Pages;
using SemestralProject.ViewModel.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SemestralProject.ViewModel.Components
{
    /// <summary>
    /// Class which handles new employee window model.
    /// </summary>
    public partial class NewEmployeeWindowViewModel: ObservableObject
    {
        /// <summary>
        /// Name of new employee.
        /// </summary>
        [ObservableProperty]
        private string name = string.Empty;

        /// <summary>
        /// Surname of new employee.
        /// </summary>
        [ObservableProperty]
        private string surname = string.Empty;

        /// <summary>
        /// E-mail of new employee.
        /// </summary>
        [ObservableProperty]
        private string email = string.Empty;

        /// <summary>
        /// Phone number of new employee.
        /// </summary>
        [ObservableProperty]
        private string phone = string.Empty;

        /// <summary>
        /// Password of new employee.
        /// </summary>
        private string password = string.Empty;

        /// <summary>
        /// Address of new employee.
        /// </summary>
        private Address? address;

        /// <summary>
        /// Flag, whether controls are enabled.
        /// </summary>
        [ObservableProperty]
        private bool controlsEnabled = true;

        /// <summary>
        /// Visibility of progress ring.
        /// </summary>
        [ObservableProperty]
        private Visibility progressVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of progress ring.
        /// </summary>
        [ObservableProperty]
        private Visibility textVisibility = Visibility.Visible;

        /// <summary>
        /// Creates new view model for new employee window.
        /// </summary>
        public NewEmployeeWindowViewModel()
        {
            WeakReferenceMessenger.Default.Register<SelectedAddressChangedMessage>(this, (sender, args) =>
            {
                this.address = args.Value;
            });
        }

        /// <summary>
        /// Handles change of password.
        /// </summary>
        /// <param name="pb">Password box with actual password.</param>
        [RelayCommand]
        private void PasswordChanged(PasswordBox pb)
        {
            this.password = pb.Password;
        }

        /// <summary>
        /// Handles click on OK button.
        /// </summary>
        [RelayCommand]
        private async Task OK()
        {
            if (this.address != null)
            {
                this.TextVisibility = Visibility.Collapsed;
                this.ProgressVisibility = Visibility.Visible;
                this.ControlsEnabled = false;
                Person person = await Person.CreateAsync(this.Name, this.Surname, this.Email, this.Phone);
                Employee employee = await Employee.CreateAsync(this.address, person);
                await User.CreateAsync(this.password, DateTime.Now, ImageFile.Default, Role.User, State.Active, employee);
                WeakReferenceMessenger.Default.Send<UsersChangedMessage>(new UsersChangedMessage());
                WeakReferenceMessenger.Default.Send<EmployeesChangedMessage>(new EmployeesChangedMessage());
                WindowUtils.CloseForModel(this);
            }
        }

        /// <summary>
        /// Handles click on cancel button.
        /// </summary>
        [RelayCommand]
        private void Cancel()
        {
            WindowUtils.CloseForModel(this);
        }
    }
}
