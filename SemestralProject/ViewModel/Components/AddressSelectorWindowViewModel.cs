using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.ViewModel.Components
{
    /// <summary>
    /// View model for address selector window.
    /// </summary>
    public partial class AddressSelectorWindowViewModel: ObservableObject
    {

        /// <summary>
        /// Street part of address.
        /// </summary>
        [ObservableProperty]
        private string street;

        
    }
}
