using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using SemestralProject.Model;
using SemestralProject.Model.Entities;
using SemestralProject.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.ViewModel.Windows
{
    /// <summary>
    /// Class which handles behaviour of schedules window.
    /// </summary>
    public partial class SchedulesWindowViewModel: ObservableObject
    {
        /// <summary>
        /// Collection of all available schedules.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<LightSchedule> availableSchedules;

        /// <summary>
        /// Collection of set schedules.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<LightSchedule> setSchedules;

        /// <summary>
        /// Collection of all available lines.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Line> lines;

        /// <summary>
        /// Selected set schedule.
        /// </summary>
        [ObservableProperty]
        private LightSchedule? selectedSet;

        /// <summary>
        /// Selected available schedule.
        /// </summary>
        [ObservableProperty]
        private LightSchedule? selectedAvailable;

        /// <summary>
        /// Actually selected line.
        /// </summary>
        [ObservableProperty]
        private Line? selectedLine;

        /// <summary>
        /// Text with departure.
        /// </summary>
        [ObservableProperty]
        private string depText = string.Empty;

        /// <summary>
        /// Text with arrival.
        /// </summary>
        [ObservableProperty]
        private string arrText = string.Empty;

        /// <summary>
        /// Creates view mdoel of schedules window.
        /// </summary>
        public SchedulesWindowViewModel()
        {
            this.availableSchedules = new ObservableCollection<LightSchedule>();
            this.Lines = new ObservableCollection<Line>();
            this.setSchedules = new ObservableCollection<LightSchedule>();
            Line[] ls = Line.GetAll();
            foreach (Line l in ls)
            {
                this.Lines.Add(l);
            }
            this.SelectedLine = this.Lines.FirstOrDefault();
            Stop[] stops = Stop.GetAll();
            foreach(Stop stop in stops)
            {
                this.AvailableSchedules.Add(new LightSchedule { Stop = stop , Arrival = DateTime.MinValue, Departure = DateTime.MinValue});
            }

            
        }

        /// <summary>
        /// Handles change of set schedule.
        /// </summary>
        [RelayCommand]
        private void SetChanged()
        {
            if (this.SelectedSet != null)
            {
                this.DepText = this.SelectedSet.Departure.ToString("HH:mm");
                this.ArrText = this.SelectedSet.Arrival.ToString("HH:mm");
            }
        }

        /// <summary>
        /// Handles change of departure time.
        /// </summary>
        [RelayCommand]
        private void DepChanged()
        {
            TimeOnly time;
            if (TimeOnly.TryParse(this.DepText, out time) && this.SelectedSet != null)
            {
                this.SelectedSet.Departure = DateTime.MinValue + time.ToTimeSpan();
            }
        }

        /// <summary>
        /// Handles change of arrivat time.
        /// </summary>
        [RelayCommand]
        private void ArrChanged()
        {
            TimeOnly time;
            if (TimeOnly.TryParse(this.ArrText, out time) && this.SelectedSet != null)
            {
                this.SelectedSet.Arrival = DateTime.MinValue + time.ToTimeSpan();
            }
        }

        /// <summary>
        /// Adds new row in set schedules.
        /// </summary>
        [RelayCommand]
        private void Add()
        {
            if (this.SelectedAvailable != null)
            { 

                this.SetSchedules.Add(this.SelectedAvailable);
                this.AvailableSchedules.Remove(this.SelectedAvailable);
            }
            
        }

        /// <summary>
        /// Removes row from set schedules.
        /// </summary>
        [RelayCommand]
        private void Remove()
        {
            if (this.SelectedSet != null)

            {
                this.AvailableSchedules.Add(this.SelectedSet);
                this.SetSchedules.Remove(this.SelectedSet);
            }
        }

        /// <summary>
        /// Handles click on OK button.
        /// </summary>
        [RelayCommand]
        private void OK()
        {
            int var = new Random().Next();
           if (this.SelectedLine != null)
            {
                int idx = 1;
                foreach(LightSchedule ls in this.SetSchedules)
                {
                    Schedule.Create(ls.Arrival, ls.Departure, idx, var, this.SelectedLine, ls.Stop);
                        idx++;
                }
                WindowUtils.CloseForModel(this);
            }
            
        }

    }
}
