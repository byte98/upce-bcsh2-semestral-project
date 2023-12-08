﻿// <auto-generated/>
#pragma warning disable
#nullable enable
namespace SemestralProject.ViewModel.Windows
{
    /// <inheritdoc/>
    partial class LogsWindowViewModel
    {
        /// <inheritdoc cref="logs"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Collections.ObjectModel.ObservableCollection<string> Logs
        {
            get => logs;
            [global::System.Diagnostics.CodeAnalysis.MemberNotNull("logs")]
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::System.Collections.ObjectModel.ObservableCollection<string>>.Default.Equals(logs, value))
                {
                    OnLogsChanging(value);
                    OnLogsChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Logs);
                    logs = value;
                    OnLogsChanged(value);
                    OnLogsChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Logs);
                }
            }
        }

        /// <summary>Executes the logic for when <see cref="Logs"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Logs"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnLogsChanging(global::System.Collections.ObjectModel.ObservableCollection<string> value);
        /// <summary>Executes the logic for when <see cref="Logs"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Logs"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnLogsChanging(global::System.Collections.ObjectModel.ObservableCollection<string>? oldValue, global::System.Collections.ObjectModel.ObservableCollection<string> newValue);
        /// <summary>Executes the logic for when <see cref="Logs"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Logs"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnLogsChanged(global::System.Collections.ObjectModel.ObservableCollection<string> value);
        /// <summary>Executes the logic for when <see cref="Logs"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Logs"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnLogsChanged(global::System.Collections.ObjectModel.ObservableCollection<string>? oldValue, global::System.Collections.ObjectModel.ObservableCollection<string> newValue);
    }
}