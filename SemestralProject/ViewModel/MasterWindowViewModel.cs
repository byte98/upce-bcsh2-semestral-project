using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using SemestralProject.Common;
using SemestralProject.Model.Entities;
using SemestralProject.Model.Enums;
using SemestralProject.Utils;
using SemestralProject.View;
using SemestralProject.View.Components;
using SemestralProject.View.Navigation;
using SemestralProject.View.Pages;
using SemestralProject.View.Windows;
using SemestralProject.ViewModel.Messaging;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace SemestralProject.ViewModel
{
    /// <summary>
    /// Class which handles behaviour of master window.
    /// </summary>
    [ObservableObject]
    public partial class MasterWindowViewModel : NavigationSource
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
        /// Visibility of change role button.
        /// </summary>
        [ObservableProperty]
        private Visibility changeRoleVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of role management.
        /// </summary>
        [ObservableProperty]
        private Visibility rolesVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of users menu item.
        /// </summary>
        [ObservableProperty]
        private Visibility usersVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of employees menu item.
        /// </summary>
        [ObservableProperty]
        private Visibility employeesVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of lines menu item.
        /// </summary>
        [ObservableProperty]
        private Visibility linesVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of stops menu item.
        /// </summary>
        [ObservableProperty]
        private Visibility stopsVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of schedules menu item.
        /// </summary>
        [ObservableProperty]
        private Visibility schedulesVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of super tool menu item.
        /// </summary>
        [ObservableProperty]
        private Visibility supertoolVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of logs menu item.
        /// </summary>
        [ObservableProperty]
        private Visibility logsVisibility = Visibility.Collapsed;

        /// <summary>
        /// Visibility of hierarchy menu item.
        /// </summary>
        [ObservableProperty]
        private Visibility hierarchyVisibility = Visibility.Collapsed;

        /// <summary>
        /// Page with users details.
        /// </summary>
        private MyPage myPage;

        /// <summary>
        /// Page with permissions manager.
        /// </summary>
        private PermissionsPage permPage;

        /// <summary>
        /// Page with all users in system.
        /// </summary>
        private UsersPage usersPage;

        /// <summary>
        /// Page with employees.
        /// </summary>
        private EmployeesPage employeesPage;

        /// <summary>
        /// Page with lines.
        /// </summary>
        private LinesPage linesPage;

        /// <summary>
        /// Page with stops.
        /// </summary>
        private StopsPage stopsPage;

        /// <summary>
        /// Page with schedules.
        /// </summary>
        private SchedulesPage schedulesPage;

        /// <summary>
        /// Page with database supertool.
        /// </summary>
        private DatabasePage supertoolPage;

        /// <summary>
        /// Page with logs.
        /// </summary>
        private LogsPage logsPage;

        /// <summary>
        /// Page with hierarchy
        /// </summary>
        private HierarchyPage hierarchyPage;

        /// <summary>
        /// Flag, whether my page menu item is checked.
        /// </summary>
        [ObservableProperty]
        private bool myPageCheck;

        /// <summary>
        /// Flag, whether permissions menu item is checked.
        /// </summary>
        [ObservableProperty]
        private bool permCheck;

        /// <summary>
        /// Flag, whether users menu item is checked.
        /// </summary>
        [ObservableProperty]
        private bool usersCheck;

        /// <summary>
        /// Flag, whether employees menu item is checked.
        /// </summary>
        [ObservableProperty]
        private bool employeesCheck;

        /// <summary>
        /// Flag, whether lines menu item is checked.
        /// </summary>
        [ObservableProperty]
        private bool linesCheck;

        /// <summary>
        /// Flag, whether stops menu item is checked.
        /// </summary>
        [ObservableProperty]
        private bool stopsCheck;

        /// <summary>
        /// Flag, whether schedules menu item is checked.
        /// </summary>
        [ObservableProperty]
        private bool schedulesCheck;

        /// <summary>
        /// Flag, whether supertool menu item is checked.
        /// </summary>
        [ObservableProperty]
        private bool supertoolCheck;

        /// <summary>
        /// Flag, whether logs menu item is checked.
        /// </summary>
        [ObservableProperty]
        private bool logsCheck;

        /// <summary>
        /// Flag, whether hierarchy menu item is checked.
        /// </summary>
        [ObservableProperty]
        private bool hierarchyCheck;

        /// <summary>
        /// Visibility of wait window.
        /// </summary>
        [ObservableProperty]
        private Visibility waitVisibility;

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
            this.image = UserImage.FromImageFile(ImageFile.Default).ToImage();
            this.waitVisibility = Visibility.Visible;
            this.myPageCheck = false;
            this.permCheck = false;
            this.usersCheck = false;
            this.employeesCheck = false;
            this.linesCheck = false;
            this.schedulesCheck = false;
            this.supertoolCheck = false;
            this.logsCheck = false;
            this.stopsCheck = false;
            this.hierarchyCheck = false;
            this.myPage = new MyPage();
            this.permPage = new PermissionsPage();
            this.usersPage = new UsersPage();
            this.employeesPage = new EmployeesPage();
            this.linesPage = new LinesPage();
            this.stopsPage = new StopsPage();
            this.schedulesPage = new SchedulesPage();
            this.supertoolPage = new DatabasePage();
            this.logsPage = new LogsPage();
            this.hierarchyPage = new HierarchyPage();
        }

        /// <summary>
        /// Handles change of logged user.
        /// </summary>
        /// <param name="user">New logged user.</param>
        private async void UserChanged(User user)
        {
            this.WaitVisibility = Visibility.Visible;
            this.ChangeRoleVisibility = Visibility.Collapsed;
            this.user = user;
            this.Image = UserImage.FromImageFile(this.user.Image).ToImage();
            this.Name = this.user.Employee.PersonalData.Name + " " + this.user.Employee.PersonalData.Surname;
            await this.user.Role.LoadPermissionsAsync();
            bool canChangeRole = this.CanChangeRole();
            if (canChangeRole == true)
            {
                this.ChangeRoleVisibility = Visibility.Visible;
            }
            WeakReferenceMessenger.Default.Send<InfoUserMessage>(new InfoUserMessage(user));
            this.WaitVisibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Handles change of role of user.
        /// </summary>
        /// <param name="role">New role of user.</param>
        private void RoleChanged(Role role)
        {
            this.WaitVisibility = Visibility.Visible;
            this.role = role;
            this.DisplayRole = role.Name;
            this.RoleMenu();
            this.WaitVisibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Displays menu items according to the actual role.
        /// </summary>
        private async void RoleMenu()
        {
            if (this.role != null)
            {
                this.WaitVisibility = Visibility.Visible;
                await this.role.LoadPermissionsAsync();
                this.RolesVisibility = this.role.HasPermission(PermissionNames.RolesRead) ? Visibility.Visible : Visibility.Collapsed;
                this.UsersVisibility = this.role.HasPermission(PermissionNames.UsersRead) ? Visibility.Visible : Visibility.Collapsed;
                this.EmployeesVisibility = this.role.HasPermission(PermissionNames.EmployeesRead) ? Visibility.Visible : Visibility.Collapsed;
                this.LinesVisibility = this.role.HasPermission(PermissionNames.LinesRead) ? Visibility.Visible : Visibility.Collapsed;
                this.StopsVisibility = this.role.HasPermission(PermissionNames.StopsRead) ? Visibility.Visible : Visibility.Collapsed;
                this.SchedulesVisibility = this.role.HasPermission(PermissionNames.SchedulesRead) ? Visibility.Visible : Visibility.Collapsed;
                this.SupertoolVisibility = this.role.HasPermission(PermissionNames.Supertool) ? Visibility.Visible : Visibility.Collapsed;
                this.LogsVisibility = this.role.HasPermission(PermissionNames.LogsRead) ? Visibility.Visible : Visibility.Collapsed;
                this.HierarchyVisibility = this.role.HasPermission(PermissionNames.HierarchyRead) ? Visibility.Visible : Visibility.Collapsed;
                this.ResetChecks();


                this.MyPage();
                this.WaitVisibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Handles closing window.
        /// </summary>
        [RelayCommand]
        private void WindowClosing()
        {
            if (this.user != null)
            {
                string sql = $"sempr_api.proc_users_logout({this.user.Id})";
                string cmd = $"BEGIN\n    {sql};\nEND;";
                IConnection connection = OracleConnector.Load();
                connection.Execute(cmd);
            }
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
                if (this.user != null)
                {
                    WeakReferenceMessenger.Default.Send<InfoUserMessage>(new InfoUserMessage(this.user));
                }
                if (this.role != null)
                {
                    WeakReferenceMessenger.Default.Send<InfoRoleMessage>(new InfoRoleMessage(this.role));
                    this.RoleMenu();
                }

            }
        }

        /// <summary>
        /// Handles logout of user.
        /// </summary>
        [RelayCommand]
        private void Logout()
        {
            if (this.user != null)
            {
                string sql = $"sempr_api.proc_users_logout({this.user.Id})";
                string cmd = $"BEGIN\n    {sql};\nEND;";
                IConnection connection = OracleConnector.Load();
                connection.Execute(cmd);
            }
            this.user = null;
            MainWindow main = new MainWindow();
            main.Show();
            WindowUtils.HideForModel(this);
        }

        /// <summary>
        /// Checks, whether user can change role.
        /// </summary>
        /// <returns>TRUE if user can change role, FALSE otherwise.</returns>
        private bool CanChangeRole()
        {
            bool reti = false;
            if (this.user != null)
            {
                if (user.Role.HasPermission(Model.Enums.PermissionNames.RoleModifyRuntime))
                {
                    reti = true;
                }
            }
            return reti;
        }

        /// <summary>
        /// Checks, whether user can change role asynchronously.
        /// </summary>
        /// <returns>Task which resolves into TRUE if user can change role, FALSE otherwise.</returns>
        private Task<bool> CanChangeRoleAsync()
        {
            return Task<bool>.Run(() =>
            {
                return this.CanChangeRole();
            });
        }

        /// <summary>
        /// Handles change of role.
        /// </summary>
        [RelayCommand]
        private void ChangeRole()
        {
            RoleSelectionWindow roleSelection = new RoleSelectionWindow();
            if (this.role != null)
            {
                WeakReferenceMessenger.Default.Send<InfoRoleMessage>(new InfoRoleMessage(this.role));
                this.RoleMenu();
            }
            WeakReferenceMessenger.Default.Register<SelectedRoleChangedMessage>(this, (sender, args) =>
            {
                WeakReferenceMessenger.Default.Send<LoggedRoleChangedMessage>(new LoggedRoleChangedMessage(args.Value));
            });
            roleSelection.ShowDialog();
            WeakReferenceMessenger.Default.Unregister<InfoRoleMessage>(this);
            WeakReferenceMessenger.Default.Unregister<SelectedRoleChangedMessage>(this);
        }

        /// <summary>
        /// Resets all checks from menu items.
        /// </summary>
        private void ResetChecks()
        {
            this.MyPageCheck = false;
            this.PermCheck = false;
        }

        /// <summary>
        /// Handles click on 'my page' menu item.
        /// </summary>
        [RelayCommand]
        private void MyPage()
        {
            this.ResetChecks();
            this.MyPageCheck = true;
            if (this.role != null)
            {
                WeakReferenceMessenger.Default.Send<InfoRoleMessage>(new InfoRoleMessage(this.role));
            }
            this.Navigate(this.myPage);
        }

        /// <summary>
        /// Handles click on 'permissions' menu item.
        /// </summary>
        [RelayCommand]
        private void Permission()
        {
            this.ResetChecks();
            this.PermCheck = true;
            if (this.role != null)
            {
                WeakReferenceMessenger.Default.Send<InfoRoleMessage>(new InfoRoleMessage(this.role));
            }
            this.Navigate(this.permPage);
        }

        /// <summary>
        /// Handles click on 'users' menu item.
        /// </summary>
        [RelayCommand]
        private void Users()
        {
            this.ResetChecks();
            this.UsersCheck = true;
            if (this.role != null)
            {
                WeakReferenceMessenger.Default.Send<InfoRoleMessage>(new InfoRoleMessage(this.role));
            }
            this.Navigate(this.usersPage);
        }

        /// <summary>
        /// Handles click on 'employees menu item'.
        /// </summary>
        [RelayCommand]
        private void Employees()
        {
            this.ResetChecks();
            this.EmployeesCheck = true;
            if (this.role != null)
            {
                WeakReferenceMessenger.Default.Send<InfoRoleMessage>(new InfoRoleMessage(this.role));
            }
            this.Navigate(this.employeesPage);
        }

        /// <summary>
        /// Handles click on 'lines' menu item.
        /// </summary>
        [RelayCommand]
        private void Lines()
        {
            this.ResetChecks();
            this.LinesCheck = true;
            this.Navigate(this.linesPage);
        }

        /// <summary>
        /// Handles click on 'stops' menu item.
        /// </summary>
        [RelayCommand]
        private void Stops()
        {
            this.ResetChecks();
            this.StopsCheck = true;
            this.Navigate(this.stopsPage);
        }

        /// <summary>
        /// Handles click on 'schedules' menu item.
        /// </summary>
        [RelayCommand]
        private void Schedules()
        {
            this.ResetChecks();
            this.SchedulesCheck = true;
            this.Navigate(this.schedulesPage);
        }

        /// <summary>
        /// Handles click on 'supertool' button.
        /// </summary>
        [RelayCommand]
        private void Supertool()
        {
            this.ResetChecks();
            this.SupertoolCheck = true;
            this.Navigate(this.supertoolPage);
        }

        /// <summary>
        /// Handles click on 'logs' button.
        /// </summary>
        [RelayCommand]
        private void Logs()
        {
            this.ResetChecks();
            this.LogsCheck = true;
            this.Navigate(this.logsPage);
        }

        /// <summary>
        /// Handles click on 'hierarchy' button.
        /// </summary>
        [RelayCommand]
        private void Hierarchy()
        {
            this.ResetChecks();
            this.HierarchyCheck = true;
            this.Navigate(this.hierarchyPage);
        }
    }
}
