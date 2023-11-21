using CommunityToolkit.Mvvm.Messaging.Messages;
using SemestralProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.ViewModel.Messaging
{
    /// <summary>
    /// Class which encapsulates information,
    /// that selected country has been changed.
    /// </summary>
    class SelectedCountryChangedMessage: ValueChangedMessage<Country>
    {
        /// <summary>
        /// Creates new message informing about change of selected country.
        /// </summary>
        /// <param name="country">Actually selected country.</param>
        public SelectedCountryChangedMessage(Country country) : base(country) { }
    }
}
