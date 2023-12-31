using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Model.Entities;
using SemestralProject.Utils;
using SemestralProject.ViewModel.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SemestralProject.ViewModel.Components
{
    /// <summary>
    /// View mdoel which handles behaviour of employee detail window.
    /// </summary>
    public partial class EmployeeDetailWindowViewModel: ObservableObject
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
        /// Date of start of employement of employee.
        /// </summary>
        [ObservableProperty]
        private DateTime employementDate = DateTime.MinValue;

        /// <summary>
        /// Actually displayed employee.
        /// </summary>
        private Employee? employee;

        /// <summary>
        /// Creates new view model for employee detail window.
        /// </summary>
        public EmployeeDetailWindowViewModel()
        {
            WeakReferenceMessenger.Default.Register<InfoEmployeeMessage>(this, (sender, args) =>
            {
                this.employee = args.Value;
                this.Name = this.employee.PersonalData.Name;
                this.Surname = this.employee.PersonalData.Surname;
                this.Email = this.employee.PersonalData.Email;
                this.Phone = this.employee.PersonalData.Phone;
                this.EmployementDate = this.employee.EmploymentDate;
                WeakReferenceMessenger.Default.Send<SelectedAddressChangedMessage>(new SelectedAddressChangedMessage(this.employee.Residence));
                this.address = this.employee.Residence;
            });
            WeakReferenceMessenger.Default.Register<SelectedAddressChangedMessage>(this, (sender, args) =>
            {
                this.address = args.Value;
            });
        }

        /// <summary>
        /// Handles click on OK button.
        /// </summary>
        [RelayCommand]
        private async Task OK()
        {
            if (this.address != null && this.employee != null)
            {
                this.TextVisibility = Visibility.Collapsed;
                this.ProgressVisibility = Visibility.Visible;
                this.ControlsEnabled = false;
                this.employee.PersonalData.Name = this.Name;
                this.employee.PersonalData.Surname = this.Surname;
                this.employee.PersonalData.Email = this.Email;
                this.employee.PersonalData.Phone = this.Phone;
                await this.employee.PersonalData.UpdateAsync();
                this.employee.EmploymentDate = this.EmployementDate;
                this.employee.Residence = this.address;
                await this.employee.UpdateAsync();
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
