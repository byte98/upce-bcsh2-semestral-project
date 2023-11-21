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
    /// Message informing about change of selected municipality.
    /// </summary>
    public class SelectedMunicipalityChangedMessage: ValueChangedMessage<Municipality>
    {
        /// <summary>
        /// Creates new message informaing about change of selected municipality.
        /// </summary>
        /// <param name="municipality">Newly selected municipality.</param>
        public SelectedMunicipalityChangedMessage(Municipality municipality) : base(municipality) { }
    }
}
