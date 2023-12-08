using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.Model.Entities;
using SemestralProject.View.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.ViewModel.Pages
{
    /// <summary>
    /// Class which handles behaviour of schedules page.
    /// </summary>
    public partial class SchedulesPageViewModel: AbstractPageViewModel
    {
        [ObservableProperty]
        private ObservableCollection<Schedule> schedules = new ObservableCollection<Schedule>();

        [ObservableProperty]
        private Schedule? selectedSchedule;

        /// <summary>
        /// Creates new view model for schedules page.
        /// </summary>
        public SchedulesPageViewModel(): base(Model.Enums.PermissionNames.SchedulesModify)
        {
            this.schedules.Clear();
            Schedule[] schedules = Schedule.GetAll();
            foreach (Schedule schedule in schedules)
            {
                this.schedules.Add(schedule);
            }
        }


        /// <summary>
        /// Handles click on new button.
        /// </summary>
        [RelayCommand]
        private void New()
        {
            SchedulesWindow window = new SchedulesWindow();
            window.ShowDialog();
            this.Schedules.Clear();
            Schedule[] schedules = Schedule.GetAll();
            foreach (Schedule schedule in schedules)
            {
                this.Schedules.Add(schedule);
            }
        }

        [RelayCommand]
        private void Remove()
        {
            if (this.SelectedSchedule != null)
            {
                this.SelectedSchedule.Delete();
                this.Schedules.Clear();
                Schedule[] schedules = Schedule.GetAll();
                foreach (Schedule schedule in schedules)
                {
                    this.Schedules.Add(schedule);
                }
            }
        }
    }
}
