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
    /// Class which represents message informing about change of selected permissions.
    /// </summary>
    public class SelectedPermissionsChangedMessage: ValueChangedMessage<IList<Permission>>
    {
        /// <summary>
        /// Creates new message informing about change of selected permissions.
        /// </summary>
        /// <param name="permissions">Actually selected permissions.</param>
        public SelectedPermissionsChangedMessage(IList<Permission> permissions) : base(permissions) { }
    }
}
