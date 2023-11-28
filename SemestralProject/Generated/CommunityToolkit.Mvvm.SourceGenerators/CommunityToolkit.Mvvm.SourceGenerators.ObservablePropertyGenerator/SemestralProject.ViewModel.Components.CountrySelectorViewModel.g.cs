﻿// <auto-generated/>
#pragma warning disable
#nullable enable
namespace SemestralProject.ViewModel.Components
{
    /// <inheritdoc/>
    partial class CountrySelectorViewModel
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

        /// <inheritdoc cref="comboBoxVisibility"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Windows.Visibility ComboBoxVisibility
        {
            get => comboBoxVisibility;
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::System.Windows.Visibility>.Default.Equals(comboBoxVisibility, value))
                {
                    OnComboBoxVisibilityChanging(value);
                    OnComboBoxVisibilityChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ComboBoxVisibility);
                    comboBoxVisibility = value;
                    OnComboBoxVisibilityChanged(value);
                    OnComboBoxVisibilityChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ComboBoxVisibility);
                }
            }
        }

        /// <inheritdoc cref="availableCountries"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Country> AvailableCountries
        {
            get => availableCountries;
            [global::System.Diagnostics.CodeAnalysis.MemberNotNull("availableCountries")]
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Country>>.Default.Equals(availableCountries, value))
                {
                    OnAvailableCountriesChanging(value);
                    OnAvailableCountriesChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.AvailableCountries);
                    availableCountries = value;
                    OnAvailableCountriesChanged(value);
                    OnAvailableCountriesChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.AvailableCountries);
                }
            }
        }

        /// <inheritdoc cref="selectedCountry"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::SemestralProject.Model.Entities.Country? SelectedCountry
        {
            get => selectedCountry;
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::SemestralProject.Model.Entities.Country?>.Default.Equals(selectedCountry, value))
                {
                    OnSelectedCountryChanging(value);
                    OnSelectedCountryChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedCountry);
                    selectedCountry = value;
                    OnSelectedCountryChanged(value);
                    OnSelectedCountryChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedCountry);
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
        /// <summary>Executes the logic for when <see cref="ComboBoxVisibility"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="ComboBoxVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnComboBoxVisibilityChanging(global::System.Windows.Visibility value);
        /// <summary>Executes the logic for when <see cref="ComboBoxVisibility"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="ComboBoxVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnComboBoxVisibilityChanging(global::System.Windows.Visibility oldValue, global::System.Windows.Visibility newValue);
        /// <summary>Executes the logic for when <see cref="ComboBoxVisibility"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="ComboBoxVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnComboBoxVisibilityChanged(global::System.Windows.Visibility value);
        /// <summary>Executes the logic for when <see cref="ComboBoxVisibility"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="ComboBoxVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnComboBoxVisibilityChanged(global::System.Windows.Visibility oldValue, global::System.Windows.Visibility newValue);
        /// <summary>Executes the logic for when <see cref="AvailableCountries"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="AvailableCountries"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnAvailableCountriesChanging(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Country> value);
        /// <summary>Executes the logic for when <see cref="AvailableCountries"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="AvailableCountries"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnAvailableCountriesChanging(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Country>? oldValue, global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Country> newValue);
        /// <summary>Executes the logic for when <see cref="AvailableCountries"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="AvailableCountries"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnAvailableCountriesChanged(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Country> value);
        /// <summary>Executes the logic for when <see cref="AvailableCountries"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="AvailableCountries"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnAvailableCountriesChanged(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Country>? oldValue, global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Country> newValue);
        /// <summary>Executes the logic for when <see cref="SelectedCountry"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="SelectedCountry"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedCountryChanging(global::SemestralProject.Model.Entities.Country? value);
        /// <summary>Executes the logic for when <see cref="SelectedCountry"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="SelectedCountry"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedCountryChanging(global::SemestralProject.Model.Entities.Country? oldValue, global::SemestralProject.Model.Entities.Country? newValue);
        /// <summary>Executes the logic for when <see cref="SelectedCountry"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="SelectedCountry"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedCountryChanged(global::SemestralProject.Model.Entities.Country? value);
        /// <summary>Executes the logic for when <see cref="SelectedCountry"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="SelectedCountry"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedCountryChanged(global::SemestralProject.Model.Entities.Country? oldValue, global::SemestralProject.Model.Entities.Country? newValue);
    }
}