using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Model.Entities;
using SemestralProject.Model.Enums;
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
        /// Code of new line.
        /// </summary>
        [ObservableProperty]
        private string lineCode = string.Empty;

        /// <summary>
        /// Actually selected line.
        /// </summary>
        [ObservableProperty]
        private Line? selectedLine;

        /// <summary>
        /// Creates new page for lines page.
        /// </summary>
        public LinesPageViewModel() : base(PermissionNames.LinesModify)
        {
            this.lines = new ObservableCollection<Line>();
            WeakReferenceMessenger.Default.Register<LinesChangedMessage>(this, async (sender, args) =>
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
            Line[] loadedLines = await Line.GetAllAsync();
            this.Lines.Clear();
            foreach (Line l in loadedLines.OrderBy(line => line.Code))
            {
                this.Lines.Add(l);
            }
            this.WaitVisibility = Visibility.Collapsed;
            this.ContentVisibility = Visibility.Visible;
        }

        /// <summary>
        /// Handles click on new line button.
        /// </summary>
        [RelayCommand]
        private async Task New()
        {
            if (this.LineCode.Length == 3)
            {
                await Line.CreateAsync(this.LineCode);
                WeakReferenceMessenger.Default.Send<LinesChangedMessage>(new LinesChangedMessage());
            }
        }

        /// <summary>
        /// Handles click on remove line button.
        /// </summary>
        [RelayCommand]
        private async Task Remove()
        {
            if (this.SelectedLine != null)
            {
                await this.SelectedLine.DeleteAsync();
                WeakReferenceMessenger.Default.Send<LinesChangedMessage>(new LinesChangedMessage());
            }
        }

    }
}
