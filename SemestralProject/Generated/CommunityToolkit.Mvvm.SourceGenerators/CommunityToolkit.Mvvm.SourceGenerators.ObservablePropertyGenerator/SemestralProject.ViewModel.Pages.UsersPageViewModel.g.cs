﻿// <auto-generated/>
#pragma warning disable
#nullable enable
namespace SemestralProject.ViewModel.Pages
{
    /// <inheritdoc/>
    partial class UsersPageViewModel
    {
        /// <inheritdoc cref="states"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.State> States
        {
            get => states;
            [global::System.Diagnostics.CodeAnalysis.MemberNotNull("states")]
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.State>>.Default.Equals(states, value))
                {
                    OnStatesChanging(value);
                    OnStatesChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.States);
                    states = value;
                    OnStatesChanged(value);
                    OnStatesChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.States);
                }
            }
        }

        /// <inheritdoc cref="roles"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Role> Roles
        {
            get => roles;
            [global::System.Diagnostics.CodeAnalysis.MemberNotNull("roles")]
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Role>>.Default.Equals(roles, value))
                {
                    OnRolesChanging(value);
                    OnRolesChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Roles);
                    roles = value;
                    OnRolesChanged(value);
                    OnRolesChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Roles);
                }
            }
        }

        /// <inheritdoc cref="selectedRole"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::SemestralProject.Model.Entities.Role? SelectedRole
        {
            get => selectedRole;
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::SemestralProject.Model.Entities.Role?>.Default.Equals(selectedRole, value))
                {
                    OnSelectedRoleChanging(value);
                    OnSelectedRoleChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedRole);
                    selectedRole = value;
                    OnSelectedRoleChanged(value);
                    OnSelectedRoleChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedRole);
                }
            }
        }

        /// <inheritdoc cref="selectedState"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::SemestralProject.Model.Entities.State? SelectedState
        {
            get => selectedState;
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::SemestralProject.Model.Entities.State?>.Default.Equals(selectedState, value))
                {
                    OnSelectedStateChanging(value);
                    OnSelectedStateChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedState);
                    selectedState = value;
                    OnSelectedStateChanged(value);
                    OnSelectedStateChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedState);
                }
            }
        }

        /// <inheritdoc cref="users"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.User> Users
        {
            get => users;
            [global::System.Diagnostics.CodeAnalysis.MemberNotNull("users")]
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.User>>.Default.Equals(users, value))
                {
                    OnUsersChanging(value);
                    OnUsersChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Users);
                    users = value;
                    OnUsersChanged(value);
                    OnUsersChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Users);
                }
            }
        }

        /// <inheritdoc cref="selectedUser"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::SemestralProject.Model.Entities.User? SelectedUser
        {
            get => selectedUser;
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::SemestralProject.Model.Entities.User?>.Default.Equals(selectedUser, value))
                {
                    OnSelectedUserChanging(value);
                    OnSelectedUserChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedUser);
                    selectedUser = value;
                    OnSelectedUserChanged(value);
                    OnSelectedUserChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedUser);
                    ChangeRoleCommand.NotifyCanExecuteChanged();
                    ChangeStateCommand.NotifyCanExecuteChanged();
                    ChangePasswordCommand.NotifyCanExecuteChanged();
                    ChangeImageCommand.NotifyCanExecuteChanged();
                    ChangePasswordCommand.NotifyCanExecuteChanged();
                }
            }
        }

        /// <summary>Executes the logic for when <see cref="States"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="States"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnStatesChanging(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.State> value);
        /// <summary>Executes the logic for when <see cref="States"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="States"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnStatesChanging(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.State>? oldValue, global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.State> newValue);
        /// <summary>Executes the logic for when <see cref="States"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="States"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnStatesChanged(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.State> value);
        /// <summary>Executes the logic for when <see cref="States"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="States"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnStatesChanged(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.State>? oldValue, global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.State> newValue);
        /// <summary>Executes the logic for when <see cref="Roles"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Roles"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnRolesChanging(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Role> value);
        /// <summary>Executes the logic for when <see cref="Roles"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Roles"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnRolesChanging(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Role>? oldValue, global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Role> newValue);
        /// <summary>Executes the logic for when <see cref="Roles"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Roles"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnRolesChanged(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Role> value);
        /// <summary>Executes the logic for when <see cref="Roles"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Roles"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnRolesChanged(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Role>? oldValue, global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Role> newValue);
        /// <summary>Executes the logic for when <see cref="SelectedRole"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="SelectedRole"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedRoleChanging(global::SemestralProject.Model.Entities.Role? value);
        /// <summary>Executes the logic for when <see cref="SelectedRole"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="SelectedRole"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedRoleChanging(global::SemestralProject.Model.Entities.Role? oldValue, global::SemestralProject.Model.Entities.Role? newValue);
        /// <summary>Executes the logic for when <see cref="SelectedRole"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="SelectedRole"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedRoleChanged(global::SemestralProject.Model.Entities.Role? value);
        /// <summary>Executes the logic for when <see cref="SelectedRole"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="SelectedRole"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedRoleChanged(global::SemestralProject.Model.Entities.Role? oldValue, global::SemestralProject.Model.Entities.Role? newValue);
        /// <summary>Executes the logic for when <see cref="SelectedState"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="SelectedState"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedStateChanging(global::SemestralProject.Model.Entities.State? value);
        /// <summary>Executes the logic for when <see cref="SelectedState"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="SelectedState"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedStateChanging(global::SemestralProject.Model.Entities.State? oldValue, global::SemestralProject.Model.Entities.State? newValue);
        /// <summary>Executes the logic for when <see cref="SelectedState"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="SelectedState"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedStateChanged(global::SemestralProject.Model.Entities.State? value);
        /// <summary>Executes the logic for when <see cref="SelectedState"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="SelectedState"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedStateChanged(global::SemestralProject.Model.Entities.State? oldValue, global::SemestralProject.Model.Entities.State? newValue);
        /// <summary>Executes the logic for when <see cref="Users"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Users"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnUsersChanging(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.User> value);
        /// <summary>Executes the logic for when <see cref="Users"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Users"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnUsersChanging(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.User>? oldValue, global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.User> newValue);
        /// <summary>Executes the logic for when <see cref="Users"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Users"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnUsersChanged(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.User> value);
        /// <summary>Executes the logic for when <see cref="Users"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Users"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnUsersChanged(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.User>? oldValue, global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.User> newValue);
        /// <summary>Executes the logic for when <see cref="SelectedUser"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="SelectedUser"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedUserChanging(global::SemestralProject.Model.Entities.User? value);
        /// <summary>Executes the logic for when <see cref="SelectedUser"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="SelectedUser"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedUserChanging(global::SemestralProject.Model.Entities.User? oldValue, global::SemestralProject.Model.Entities.User? newValue);
        /// <summary>Executes the logic for when <see cref="SelectedUser"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="SelectedUser"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedUserChanged(global::SemestralProject.Model.Entities.User? value);
        /// <summary>Executes the logic for when <see cref="SelectedUser"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="SelectedUser"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedUserChanged(global::SemestralProject.Model.Entities.User? oldValue, global::SemestralProject.Model.Entities.User? newValue);
    }
}