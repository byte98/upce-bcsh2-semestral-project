using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Model;
using SemestralProject.Model.Entities;
using SemestralProject.Model.Enums;
using SemestralProject.View.Components;
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
    /// Class which handles behaviour of schedules page.
    /// </summary>
    public partial class SchedulesPageViewModel: AbstractPageViewModel
    {
        [ObservableProperty]
        private ObservableCollection<Schedule> schedules = new ObservableCollection<Schedule>();

        [ObservableProperty]
        private ObservableCollection<ScheduleGrouping> scheduleGroups = new ObservableCollection<ScheduleGrouping>();

        [ObservableProperty]
        private Schedule? selectedSchedule;

        [ObservableProperty]
        private ScheduleGrouping? selectedGroup;

        /// <summary>
        /// Flag, whether details panel is visible.
        /// </summary>
        [ObservableProperty]
        private bool detailsVisible;

        /// <summary>
        /// Creates new view model for schedules page.
        /// </summary>
        public SchedulesPageViewModel(): base(Model.Enums.PermissionNames.SchedulesModify)
        {
            this.schedules = new ObservableCollection<Schedule>();
            this.scheduleGroups = new ObservableCollection<ScheduleGrouping>();
            WeakReferenceMessenger.Default.Register<SchedulesChangedMessage>(this, async (sender, args) =>
            {
                this.WaitVisibility = Visibility.Visible;
                this.ContentVisibility = Visibility.Collapsed;
                this.schedules.Clear();
                this.scheduleGroups.Clear();
                Schedule[] schedules = Schedule.GetAll();
                foreach (Schedule schedule in schedules)
                {
                    this.schedules.Add(schedule);
                    var sg = this.scheduleGroups.FirstOrDefault(sg => sg.Line.Id == schedule.Line.Id);
                    if (sg == null)
                    {
                        sg = new ScheduleGrouping(schedule.Line);
                        this.scheduleGroups.Add(sg);
                    }
                    sg.Schedules.Add(schedule);
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
            this.DetailsVisible = false;
            this.WaitVisibility = Visibility.Visible;
            this.ContentVisibility = Visibility.Collapsed;
            this.Schedules.Clear();
            this.ScheduleGroups.Clear();
            Schedule[] schedules = Schedule.GetAll();
            foreach (Schedule schedule in schedules)
            {
                Schedules.Add(schedule);
                var sg = ScheduleGroups.FirstOrDefault(sg => sg.Line.Id == schedule.Line.Id);
                if (sg == null)
                {
                    sg = new ScheduleGrouping(schedule.Line);
                    ScheduleGroups.Add(sg);
                }
                sg.Schedules.Add(schedule);
            }
            this.WaitVisibility = Visibility.Collapsed;
            this.ContentVisibility = Visibility.Visible;
        }


        
        /// <summary>
        /// Handles click on change schedules button.
        /// </summary>
        [RelayCommand]
        private async void ChangeSchedules()
        {
            if (this.SelectedGroup != null)
            {
                SchedulesWindow window = new SchedulesWindow();
                WeakReferenceMessenger.Default.Send(new SelectedScheduleGroupChangedMessage(this.SelectedGroup));

                await Task.Run(async () =>
                {
                    IList<Task> tasks = new List<Task>();
                    foreach (Schedule s in this.SelectedGroup.Schedules)
                    {
                        tasks.Add(s.DeleteAsync());
                    }
                    await Task.WhenAll(tasks);
                });

                window.ShowDialog();
                WeakReferenceMessenger.Default.Unregister<SelectedPermissionsChangedMessage>(this);
            }
    }


        /// <summary>
        /// Handles click on new button.
        /// </summary>
        [RelayCommand]
        private void New()
        {
            // unnecesary, should be handled
            SchedulesWindow window = new SchedulesWindow();
            window.ShowDialog();
            this.Schedules.Clear();
            Schedule[] schedules = Schedule.GetAll();
            foreach (Schedule schedule in schedules)
            {
                this.Schedules.Add(schedule);
            }
            WeakReferenceMessenger.Default.Send<SchedulesChangedMessage>(new SchedulesChangedMessage());
        }

        [RelayCommand]
        private async void Remove()
        {
            if (this.SelectedGroup != null)
            {
                await Task.Run(async () =>
                {
                    IList<Task> tasks = new List<Task>();
                    foreach (Schedule s in SelectedGroup.Schedules)
                    {
                        tasks.Add(s.DeleteAsync());
                    }
                    await Task.WhenAll(tasks);
                });
            }
            WeakReferenceMessenger.Default.Send<SchedulesChangedMessage>(new SchedulesChangedMessage());
        }
    }
}
