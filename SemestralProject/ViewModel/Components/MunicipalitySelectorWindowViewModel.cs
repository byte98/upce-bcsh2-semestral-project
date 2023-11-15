using CommunityToolkit.Mvvm.ComponentModel;
using SemestralProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.ViewModel.Components
{
    /// <summary>
    /// View model of municipality selector window.
    /// </summary>
    public partial class MunicipalitySelectorWindowViewModel: ObservableObject
    {
        /// <summary>
        /// Name of municipality.
        /// </summary>
        [ObservableProperty]
        private string name;

        /// <summary>
        /// Name of part of municipality.
        /// </summary>
        [ObservableProperty]
        private string part;

        /// <summary>
        /// Zip code of municipality.
        /// </summary>
        [ObservableProperty]
        private string zip;

        /// <summary>
        /// Country in which is municipality located.
        /// </summary>
        [ObservableProperty]
        private Country? country;


    }
}
