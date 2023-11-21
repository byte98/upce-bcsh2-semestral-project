using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.Model;
using SemestralProject.Model.Entities;
using SemestralProject.View.Installer;
using SemestralProject.View.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SemestralProject.ViewModel.Installer
{
    /// <summary>
    /// Class which handles fourth step of installation.
    /// </summary>
    [ObservableObject]
    public partial class InstallationStep4ViewModel : NavigationDynamicContent<InstallationModel>, IDynamicTarget<InstallationModel>
    {
        /// <summary>
        /// Data model of installation.
        /// </summary>
        private InstallationModel model;

        /// <summary>
        /// Actual stage of fourth step of installation process.
        /// </summary>
        private ushort stage = 1;

        /// <summary>
        /// Flag, whether fourth step of installation finished in some way.
        /// </summary>
        [ObservableProperty]
        private bool finished;

        /// <summary>
        /// Flag, whether fourth step of installation finished successfully.
        /// </summary>
        [ObservableProperty]
        private bool successfull;

        /// <summary>
        /// Font weight of text in first stage of fourth step of installation.
        /// </summary>
        [ObservableProperty]
        private FontWeight stage1FontWeight = FontWeights.Bold;

        /// <summary>
        /// Font weight of text in second stage of fourth step of installation.
        /// </summary>
        [ObservableProperty]
        private FontWeight stage2FontWeight = FontWeights.Normal;

        /// <summary>
        /// Font weight of text in third stage of fourth step of installation.
        /// </summary>
        [ObservableProperty]
        private FontWeight stage3FontWeight = FontWeights.Normal;

        /// <summary>
        /// Visibility of progress ring in first stage of fourth step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility stage1ProgressVisibility = Visibility.Visible;

        /// <summary>
        /// Visibility of progress ring in second stage of fourth step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility stage2ProgressVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of progress ring in third stage of fourth step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility stage3ProgressVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of fail icon of first stage of fourth step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility failStage1 = Visibility.Collapsed;

        /// <summary>
        /// Visibility of fail icon of second stage of fourth step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility failStage2 = Visibility.Collapsed;

        /// <summary>
        /// Visibility of fail icon of third stage of fourth step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility failStage3 = Visibility.Collapsed;

        /// <summary>
        /// Visibility of success icon of first stage of fourth step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility successStage1 = Visibility.Collapsed;

        /// <summary>
        /// Visibility of success icon of second stage of fourth step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility successStage2 = Visibility.Collapsed;

        /// <summary>
        /// Visibility of success icon of third stage of fourth step of installation.
        /// </summary>
        [ObservableProperty]
        private Visibility successStage3 = Visibility.Collapsed;

        /// <summary>
        /// Person created during the process.
        /// </summary>
        private Person? person;

        /// <summary>
        /// Employee inserted into the database.
        /// </summary>
        private Employee? employee;

        /// <summary>
        /// Creates fourth step of installation process.
        /// </summary>
        public InstallationStep4ViewModel()
        {
            if (InstallationProcessViewModel.Instance != null)
            {
                InstallationProcessViewModel.Instance.RegisterDynamicSource(this);
                InstallationProcessViewModel.Instance.RegisterTarget(this);
            }
        }

        /// <summary>
        /// Handles load of control.
        /// </summary>
        [RelayCommand]
        private void ControlLoaded()
        {
            this.stage = 1;
            this.DispatchStage();
        }

        public void SetData(InstallationModel data)
        {
            this.model = data;
        }

        /// <summary>
        /// Fails actual stage.
        /// </summary>
        private void Fail()
        {
            this.HideProgressRings();
            switch (this.stage)
            {
                case 1: this.FailStage1 = Visibility.Visible; break;
                case 2: this.FailStage2 = Visibility.Visible; break;
                case 3: this.FailStage3 = Visibility.Visible; break;
            }
            this.Finished = true;
            this.stage = 9;
            this.UpdateFontWeights();
        }

        /// <summary>
        /// Marks actual stage as successfull.
        /// </summary>
        private void Success()
        {
            this.HideProgressRings();
            switch (this.stage)
            {
                case 1: this.SuccessStage1 = Visibility.Visible; break;
                case 2: this.SuccessStage2 = Visibility.Visible; break;
                case 3: this.SuccessStage3 = Visibility.Visible; break;
            }
            if (
                this.SuccessStage1 == Visibility.Visible &&
                this.SuccessStage2 == Visibility.Visible &&
                this.SuccessStage3 == Visibility.Visible 
            )
            {
                this.Successfull = true;
                this.Finished = true;
                this.ChangeContent(new InstallationStep5());
            }
        }

        /// <summary>
        /// Performs first stage of fourth step of installation.
        /// </summary>
        private async void Stage1()
        {
            this.person = await Person.CreateAsync(
                this.model.User.Name,
                this.model.User.Surname,
                this.model.User.Email,
                this.model.User.Phone
            );
            if (this.person != null)
            {
                this.Success();
                this.stage = 2;
                this.DispatchStage();
            }
            else
            {
                this.Fail();
            }
        }

        /// <summary>
        /// Performs second stage of fourth step of installation.
        /// </summary>
        private async void Stage2()
        {
            if (this.person != null && this.model.User.Address != null)
            {
                this.employee = await Employee.CreateAsync(
                    this.model.User.PersonalNumber,
                    DateTime.Now,
                    this.model.User.Address,
                    this.person,
                    null
                );
                if (this.employee != null)
                {
                    this.Success();
                    this.stage = 3;
                    this.DispatchStage();
                }
                else
                {
                    this.Fail();
                }
            }
            else
            {
                this.Fail();
            }
        }

        /// <summary>
        /// Performs third stage of fourth step of installation.
        /// </summary>
        private async void Stage3()
        {
            if (this.employee != null)
            {
                User u = await User.CreateAsync(this.model.User.Password, DateTime.Now, this.model.User.Image, Role.Superuser, State.Active, this.employee);
                if (u != null)
                {
                    this.Success();
                }
                else
                {
                    this.Fail();
                }
            }
            else
            {
                this.Fail();
            }
        }

        /// <summary>
        /// Hides all progress rings.
        /// </summary>
        private void HideProgressRings()
        {
            this.Stage1ProgressVisibility = Visibility.Collapsed;
            this.Stage2ProgressVisibility = Visibility.Collapsed;
            this.Stage3ProgressVisibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Runs correct method according to the actual stage.
        /// </summary>
        private void DispatchStage()
        {
            this.HideProgressRings();
            this.UpdateFontWeights();
            this.UpdateProgressVisibility();
            Action? action = null;
            switch (this.stage)
            {
                case 1: action = this.Stage1; break;
                case 2: action = this.Stage2; break;
                case 3: action = this.Stage3; break;
            }
            if (action != null)
            {
                action();
            }
        }

        /// <summary>
        /// Updates font weights of text of all stages.
        /// </summary>
        private void UpdateFontWeights()
        {
            Func<short, FontWeight> fw = s => s == this.stage ? FontWeights.Bold : FontWeights.Normal;
            this.Stage1FontWeight = fw.Invoke(1);
            this.Stage2FontWeight = fw.Invoke(2);
            this.Stage3FontWeight = fw.Invoke(3);
        }

        /// <summary>
        /// Updates visibility of progress rings of all stages.
        /// </summary>
        private void UpdateProgressVisibility()
        {
            Func<short, Visibility> vis = s => s == this.stage ? Visibility.Visible : Visibility.Collapsed;
            this.Stage1ProgressVisibility = vis.Invoke(1);
            this.Stage2ProgressVisibility = vis.Invoke(2);
            this.Stage3ProgressVisibility = vis.Invoke(3);
        }

        /// <summary>
        /// Function which returns FALSE.
        /// </summary>
        /// <returns>Always FALSE.</returns>
        private bool GetFalse() => false;

        /// <summary>
        /// Handles click on 'back' button.
        /// </summary>
        [RelayCommand(CanExecute =nameof(GetFalse))]
        private void BackClicked()
        {
            // NOP
            // Navigating back is not allowed in this step of installation.
        }
    }
}
