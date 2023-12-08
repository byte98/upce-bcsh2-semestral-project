using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SemestralProject.Model.Entities;
using SemestralProject.Model.Enums;
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
    /// View model of lines page.
    /// </summary>
    public partial class LinesPageViewModel: AbstractPageViewModel
    {
        /// <summary>
        /// Collection with all available lines.
        /// </summary>
        [ObservableProperty]
        private ObservableCollection<Line> lines;

        /// <summary>
        /// Creates new page for lines page.
        /// </summary>
        public LinesPageViewModel() : base(PermissionNames.LinesModify)
        {
            this.lines = new ObservableCollection<Line>();
        }

        /// <summary>
        /// Handles loading of page.
        /// </summary>
        [RelayCommand]
        private async Task PageLoaded()
        {
            this.WaitVisibility = Visibility.Visible;
            this.ContentVisibility = Visibility.Collapsed;
            Line[] loadedLines = await Line.GetAllAsync();
            this.Lines.Clear();
            foreach (Line l in loadedLines.OrderBy(line => line.Code))
            {
                this.Lines.Add(l);
            }
            this.WaitVisibility = Visibility.Collapsed;
            this.ContentVisibility = Visibility.Visible;
        }
    }
}
