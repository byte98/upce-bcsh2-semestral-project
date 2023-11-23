using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Common;
using SemestralProject.Model.Entities;
using SemestralProject.Utils;
using SemestralProject.View;
using SemestralProject.ViewModel.Messaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SemestralProject.ViewModel
{
    /// <summary>
    /// Class which handles behaviour of master window.
    /// </summary>
    public partial class MasterWindowViewModel : ObservableObject
    {

        /// <summary>
        /// Actually logged user.
        /// </summary>
        private User? user;

        /// <summary>
        /// Actually displayed role of user.
        /// </summary>
        private Role? role;

        /// <summary>
        /// Content of user image.
        /// </summary>
        [ObservableProperty]
        private ImageSource image;

        /// <summary>
        /// Name of user.
        /// </summary>
        [ObservableProperty]
        private string name = string.Empty;

        /// <summary>
        /// Displayed role of user.
        /// </summary>
        [ObservableProperty]
        private string displayRole = string.Empty;

        /// <summary>
        /// Creates new handler of master window.
        /// </summary>
        public MasterWindowViewModel() : base()
        {
            this.user = null;
            this.role = null;
            WeakReferenceMessenger.Default.Register<LoggedUserChangedMessage>(this, (sender, args) =>
            {
                this.UserChanged(args.Value);
            });
            WeakReferenceMessenger.Default.Register<LoggedRoleChangedMessage>(this, (sender, args) =>
            {
                this.RoleChanged(args.Value);
            });
            this.image = UserImage.Default.ToImage();
        }

        /// <summary>
        /// Handles change of logged user.
        /// </summary>
        /// <param name="user">New logged user.</param>
        private void UserChanged(User user)
        {
            this.user = user;
            this.Image = this.user.Image.ToImage();
            this.Name = this.user.Employee.PersonalData.Name + " " + this.user.Employee.PersonalData.Surname;
        }
        
        /// <summary>
        /// Handles change of role of user.
        /// </summary>
        /// <param name="role">New role of user.</param>
        private void RoleChanged(Role role)
        {
            this.role = role;
            this.DisplayRole = role.Name;
        }

        /// <summary>
        /// Handles procedure after window has been loaded.
        /// </summary>
        [RelayCommand]
        private void WindowLoaded()
        {
            WindowUtils.MinimizeForModel(this);
            MainWindow mw = new MainWindow();
            mw.ShowDialog();
            if (this.user == null)
            {
                App.Current.Shutdown();
            }
            else
            {
                WindowUtils.MaximizeForModel(this);
            }
        }

        /// <summary>
        /// Handles logout of user.
        /// </summary>
        [RelayCommand]
        private void Logout()
        {
            MainWindow main = new MainWindow();
            main.Show();
            WindowUtils.HideForModel(this);
        }
    }
}
