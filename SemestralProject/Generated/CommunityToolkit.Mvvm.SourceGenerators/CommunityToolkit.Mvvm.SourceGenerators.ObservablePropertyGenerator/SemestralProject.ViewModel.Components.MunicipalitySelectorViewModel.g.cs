﻿// <auto-generated/>
#pragma warning disable
#nullable enable
namespace SemestralProject.ViewModel.Components
{
    /// <inheritdoc/>
    partial class MunicipalitySelectorViewModel
    {
        /// <inheritdoc cref="loaderVisibility"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Windows.Visibility LoaderVisibility
        {
            get => loaderVisibility;
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::System.Windows.Visibility>.Default.Equals(loaderVisibility, value))
                {
                    OnLoaderVisibilityChanging(value);
                    OnLoaderVisibilityChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.LoaderVisibility);
                    loaderVisibility = value;
                    OnLoaderVisibilityChanged(value);
                    OnLoaderVisibilityChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.LoaderVisibility);
                }
            }
        }

        /// <inheritdoc cref="comboboxVisibility"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Windows.Visibility ComboboxVisibility
        {
            get => comboboxVisibility;
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::System.Windows.Visibility>.Default.Equals(comboboxVisibility, value))
                {
                    OnComboboxVisibilityChanging(value);
                    OnComboboxVisibilityChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ComboboxVisibility);
                    comboboxVisibility = value;
                    OnComboboxVisibilityChanged(value);
                    OnComboboxVisibilityChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ComboboxVisibility);
                    FindMunicipalityCommand.NotifyCanExecuteChanged();
                }
            }
        }

        /// <inheritdoc cref="availableMunicipalities"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Municipality> AvailableMunicipalities
        {
            get => availableMunicipalities;
            [global::System.Diagnostics.CodeAnalysis.MemberNotNull("availableMunicipalities")]
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Municipality>>.Default.Equals(availableMunicipalities, value))
                {
                    OnAvailableMunicipalitiesChanging(value);
                    OnAvailableMunicipalitiesChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.AvailableMunicipalities);
                    availableMunicipalities = value;
                    OnAvailableMunicipalitiesChanged(value);
                    OnAvailableMunicipalitiesChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.AvailableMunicipalities);
                }
            }
        }

        /// <inheritdoc cref="selectedMunicipality"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::SemestralProject.Model.Entities.Municipality? SelectedMunicipality
        {
            get => selectedMunicipality;
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::SemestralProject.Model.Entities.Municipality?>.Default.Equals(selectedMunicipality, value))
                {
                    OnSelectedMunicipalityChanging(value);
                    OnSelectedMunicipalityChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedMunicipality);
                    selectedMunicipality = value;
                    OnSelectedMunicipalityChanged(value);
                    OnSelectedMunicipalityChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedMunicipality);
                }
            }
        }

        /// <summary>Executes the logic for when <see cref="LoaderVisibility"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="LoaderVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnLoaderVisibilityChanging(global::System.Windows.Visibility value);
        /// <summary>Executes the logic for when <see cref="LoaderVisibility"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="LoaderVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnLoaderVisibilityChanging(global::System.Windows.Visibility oldValue, global::System.Windows.Visibility newValue);
        /// <summary>Executes the logic for when <see cref="LoaderVisibility"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="LoaderVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnLoaderVisibilityChanged(global::System.Windows.Visibility value);
        /// <summary>Executes the logic for when <see cref="LoaderVisibility"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="LoaderVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnLoaderVisibilityChanged(global::System.Windows.Visibility oldValue, global::System.Windows.Visibility newValue);
        /// <summary>Executes the logic for when <see cref="ComboboxVisibility"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="ComboboxVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnComboboxVisibilityChanging(global::System.Windows.Visibility value);
        /// <summary>Executes the logic for when <see cref="ComboboxVisibility"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="ComboboxVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnComboboxVisibilityChanging(global::System.Windows.Visibility oldValue, global::System.Windows.Visibility newValue);
        /// <summary>Executes the logic for when <see cref="ComboboxVisibility"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="ComboboxVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnComboboxVisibilityChanged(global::System.Windows.Visibility value);
        /// <summary>Executes the logic for when <see cref="ComboboxVisibility"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="ComboboxVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnComboboxVisibilityChanged(global::System.Windows.Visibility oldValue, global::System.Windows.Visibility newValue);
        /// <summary>Executes the logic for when <see cref="AvailableMunicipalities"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="AvailableMunicipalities"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnAvailableMunicipalitiesChanging(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Municipality> value);
        /// <summary>Executes the logic for when <see cref="AvailableMunicipalities"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="AvailableMunicipalities"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnAvailableMunicipalitiesChanging(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Municipality>? oldValue, global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Municipality> newValue);
        /// <summary>Executes the logic for when <see cref="AvailableMunicipalities"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="AvailableMunicipalities"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnAvailableMunicipalitiesChanged(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Municipality> value);
        /// <summary>Executes the logic for when <see cref="AvailableMunicipalities"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="AvailableMunicipalities"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnAvailableMunicipalitiesChanged(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Municipality>? oldValue, global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Municipality> newValue);
        /// <summary>Executes the logic for when <see cref="SelectedMunicipality"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="SelectedMunicipality"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedMunicipalityChanging(global::SemestralProject.Model.Entities.Municipality? value);
        /// <summary>Executes the logic for when <see cref="SelectedMunicipality"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="SelectedMunicipality"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedMunicipalityChanging(global::SemestralProject.Model.Entities.Municipality? oldValue, global::SemestralProject.Model.Entities.Municipality? newValue);
        /// <summary>Executes the logic for when <see cref="SelectedMunicipality"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="SelectedMunicipality"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedMunicipalityChanged(global::SemestralProject.Model.Entities.Municipality? value);
        /// <summary>Executes the logic for when <see cref="SelectedMunicipality"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="SelectedMunicipality"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedMunicipalityChanged(global::SemestralProject.Model.Entities.Municipality? oldValue, global::SemestralProject.Model.Entities.Municipality? newValue);
    }
}