﻿// <auto-generated/>
#pragma warning disable
#nullable enable
namespace SemestralProject.ViewModel.Components
{
    /// <inheritdoc/>
    partial class LoginViewModel
    {
        /// <inheritdoc cref="personalNumber"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public int PersonalNumber
        {
            get => personalNumber;
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<int>.Default.Equals(personalNumber, value))
                {
                    OnPersonalNumberChanging(value);
                    OnPersonalNumberChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.PersonalNumber);
                    personalNumber = value;
                    OnPersonalNumberChanged(value);
                    OnPersonalNumberChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.PersonalNumber);
                    LoginCommand.NotifyCanExecuteChanged();
                }
            }
        }

        /// <inheritdoc cref="password"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public string? Password
        {
            get => password;
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<string?>.Default.Equals(password, value))
                {
                    OnPasswordChanging(value);
                    OnPasswordChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Password);
                    password = value;
                    OnPasswordChanged(value);
                    OnPasswordChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Password);
                    LoginCommand.NotifyCanExecuteChanged();
                }
            }
        }

        /// <inheritdoc cref="controlsEnabled"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public bool ControlsEnabled
        {
            get => controlsEnabled;
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<bool>.Default.Equals(controlsEnabled, value))
                {
                    OnControlsEnabledChanging(value);
                    OnControlsEnabledChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ControlsEnabled);
                    controlsEnabled = value;
                    OnControlsEnabledChanged(value);
                    OnControlsEnabledChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ControlsEnabled);
                    RegisterCommand.NotifyCanExecuteChanged();
                    LoginCommand.NotifyCanExecuteChanged();
                }
            }
        }

        /// <inheritdoc cref="loginVisibility"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Windows.Visibility LoginVisibility
        {
            get => loginVisibility;
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::System.Windows.Visibility>.Default.Equals(loginVisibility, value))
                {
                    OnLoginVisibilityChanging(value);
                    OnLoginVisibilityChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.LoginVisibility);
                    loginVisibility = value;
                    OnLoginVisibilityChanged(value);
                    OnLoginVisibilityChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.LoginVisibility);
                }
            }
        }

        /// <inheritdoc cref="errorVisibility"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Windows.Visibility ErrorVisibility
        {
            get => errorVisibility;
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::System.Windows.Visibility>.Default.Equals(errorVisibility, value))
                {
                    OnErrorVisibilityChanging(value);
                    OnErrorVisibilityChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ErrorVisibility);
                    errorVisibility = value;
                    OnErrorVisibilityChanged(value);
                    OnErrorVisibilityChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ErrorVisibility);
                }
            }
        }

        /// <summary>Executes the logic for when <see cref="PersonalNumber"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="PersonalNumber"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnPersonalNumberChanging(int value);
        /// <summary>Executes the logic for when <see cref="PersonalNumber"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="PersonalNumber"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnPersonalNumberChanging(int oldValue, int newValue);
        /// <summary>Executes the logic for when <see cref="PersonalNumber"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="PersonalNumber"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnPersonalNumberChanged(int value);
        /// <summary>Executes the logic for when <see cref="PersonalNumber"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="PersonalNumber"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnPersonalNumberChanged(int oldValue, int newValue);
        /// <summary>Executes the logic for when <see cref="Password"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Password"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnPasswordChanging(string? value);
        /// <summary>Executes the logic for when <see cref="Password"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Password"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnPasswordChanging(string? oldValue, string? newValue);
        /// <summary>Executes the logic for when <see cref="Password"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Password"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnPasswordChanged(string? value);
        /// <summary>Executes the logic for when <see cref="Password"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Password"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnPasswordChanged(string? oldValue, string? newValue);
        /// <summary>Executes the logic for when <see cref="ControlsEnabled"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="ControlsEnabled"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnControlsEnabledChanging(bool value);
        /// <summary>Executes the logic for when <see cref="ControlsEnabled"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="ControlsEnabled"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnControlsEnabledChanging(bool oldValue, bool newValue);
        /// <summary>Executes the logic for when <see cref="ControlsEnabled"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="ControlsEnabled"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnControlsEnabledChanged(bool value);
        /// <summary>Executes the logic for when <see cref="ControlsEnabled"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="ControlsEnabled"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnControlsEnabledChanged(bool oldValue, bool newValue);
        /// <summary>Executes the logic for when <see cref="LoginVisibility"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="LoginVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnLoginVisibilityChanging(global::System.Windows.Visibility value);
        /// <summary>Executes the logic for when <see cref="LoginVisibility"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="LoginVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnLoginVisibilityChanging(global::System.Windows.Visibility oldValue, global::System.Windows.Visibility newValue);
        /// <summary>Executes the logic for when <see cref="LoginVisibility"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="LoginVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnLoginVisibilityChanged(global::System.Windows.Visibility value);
        /// <summary>Executes the logic for when <see cref="LoginVisibility"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="LoginVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnLoginVisibilityChanged(global::System.Windows.Visibility oldValue, global::System.Windows.Visibility newValue);
        /// <summary>Executes the logic for when <see cref="ErrorVisibility"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="ErrorVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnErrorVisibilityChanging(global::System.Windows.Visibility value);
        /// <summary>Executes the logic for when <see cref="ErrorVisibility"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="ErrorVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnErrorVisibilityChanging(global::System.Windows.Visibility oldValue, global::System.Windows.Visibility newValue);
        /// <summary>Executes the logic for when <see cref="ErrorVisibility"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="ErrorVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnErrorVisibilityChanged(global::System.Windows.Visibility value);
        /// <summary>Executes the logic for when <see cref="ErrorVisibility"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="ErrorVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnErrorVisibilityChanged(global::System.Windows.Visibility oldValue, global::System.Windows.Visibility newValue);
    }
}