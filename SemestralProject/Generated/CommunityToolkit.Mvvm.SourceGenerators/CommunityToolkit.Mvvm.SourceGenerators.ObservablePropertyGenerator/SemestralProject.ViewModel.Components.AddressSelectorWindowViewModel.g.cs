﻿// <auto-generated/>
#pragma warning disable
#nullable enable
namespace SemestralProject.ViewModel.Components
{
    /// <inheritdoc/>
    partial class AddressSelectorWindowViewModel
    {
        /// <inheritdoc cref="street"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public string? Street
        {
            get => street;
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<string?>.Default.Equals(street, value))
                {
                    OnStreetChanging(value);
                    OnStreetChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Street);
                    street = value;
                    OnStreetChanged(value);
                    OnStreetChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Street);
                    OKCommand.NotifyCanExecuteChanged();
                }
            }
        }

        /// <inheritdoc cref="houseNumber"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public int? HouseNumber
        {
            get => houseNumber;
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<int?>.Default.Equals(houseNumber, value))
                {
                    OnHouseNumberChanging(value);
                    OnHouseNumberChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.HouseNumber);
                    houseNumber = value;
                    OnHouseNumberChanged(value);
                    OnHouseNumberChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.HouseNumber);
                    OKCommand.NotifyCanExecuteChanged();
                }
            }
        }

        /// <inheritdoc cref="orientationNumber"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public int? OrientationNumber
        {
            get => orientationNumber;
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<int?>.Default.Equals(orientationNumber, value))
                {
                    OnOrientationNumberChanging(value);
                    OnOrientationNumberChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.OrientationNumber);
                    orientationNumber = value;
                    OnOrientationNumberChanged(value);
                    OnOrientationNumberChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.OrientationNumber);
                }
            }
        }

        /// <inheritdoc cref="municipality"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::SemestralProject.Model.Entities.Municipality? Municipality
        {
            get => municipality;
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::SemestralProject.Model.Entities.Municipality?>.Default.Equals(municipality, value))
                {
                    OnMunicipalityChanging(value);
                    OnMunicipalityChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Municipality);
                    municipality = value;
                    OnMunicipalityChanged(value);
                    OnMunicipalityChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Municipality);
                    OKCommand.NotifyCanExecuteChanged();
                }
            }
        }

        /// <inheritdoc cref="buttonTextVisibility"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Windows.Visibility ButtonTextVisibility
        {
            get => buttonTextVisibility;
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::System.Windows.Visibility>.Default.Equals(buttonTextVisibility, value))
                {
                    OnButtonTextVisibilityChanging(value);
                    OnButtonTextVisibilityChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ButtonTextVisibility);
                    buttonTextVisibility = value;
                    OnButtonTextVisibilityChanged(value);
                    OnButtonTextVisibilityChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ButtonTextVisibility);
                }
            }
        }

        /// <inheritdoc cref="savingProgressVisibility"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Windows.Visibility SavingProgressVisibility
        {
            get => savingProgressVisibility;
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::System.Windows.Visibility>.Default.Equals(savingProgressVisibility, value))
                {
                    OnSavingProgressVisibilityChanging(value);
                    OnSavingProgressVisibilityChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SavingProgressVisibility);
                    savingProgressVisibility = value;
                    OnSavingProgressVisibilityChanged(value);
                    OnSavingProgressVisibilityChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SavingProgressVisibility);
                }
            }
        }

        /// <summary>Executes the logic for when <see cref="Street"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Street"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnStreetChanging(string? value);
        /// <summary>Executes the logic for when <see cref="Street"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Street"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnStreetChanging(string? oldValue, string? newValue);
        /// <summary>Executes the logic for when <see cref="Street"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Street"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnStreetChanged(string? value);
        /// <summary>Executes the logic for when <see cref="Street"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Street"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnStreetChanged(string? oldValue, string? newValue);
        /// <summary>Executes the logic for when <see cref="HouseNumber"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="HouseNumber"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnHouseNumberChanging(int? value);
        /// <summary>Executes the logic for when <see cref="HouseNumber"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="HouseNumber"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnHouseNumberChanging(int? oldValue, int? newValue);
        /// <summary>Executes the logic for when <see cref="HouseNumber"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="HouseNumber"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnHouseNumberChanged(int? value);
        /// <summary>Executes the logic for when <see cref="HouseNumber"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="HouseNumber"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnHouseNumberChanged(int? oldValue, int? newValue);
        /// <summary>Executes the logic for when <see cref="OrientationNumber"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="OrientationNumber"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnOrientationNumberChanging(int? value);
        /// <summary>Executes the logic for when <see cref="OrientationNumber"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="OrientationNumber"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnOrientationNumberChanging(int? oldValue, int? newValue);
        /// <summary>Executes the logic for when <see cref="OrientationNumber"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="OrientationNumber"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnOrientationNumberChanged(int? value);
        /// <summary>Executes the logic for when <see cref="OrientationNumber"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="OrientationNumber"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnOrientationNumberChanged(int? oldValue, int? newValue);
        /// <summary>Executes the logic for when <see cref="Municipality"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Municipality"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnMunicipalityChanging(global::SemestralProject.Model.Entities.Municipality? value);
        /// <summary>Executes the logic for when <see cref="Municipality"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Municipality"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnMunicipalityChanging(global::SemestralProject.Model.Entities.Municipality? oldValue, global::SemestralProject.Model.Entities.Municipality? newValue);
        /// <summary>Executes the logic for when <see cref="Municipality"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Municipality"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnMunicipalityChanged(global::SemestralProject.Model.Entities.Municipality? value);
        /// <summary>Executes the logic for when <see cref="Municipality"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Municipality"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnMunicipalityChanged(global::SemestralProject.Model.Entities.Municipality? oldValue, global::SemestralProject.Model.Entities.Municipality? newValue);
        /// <summary>Executes the logic for when <see cref="ButtonTextVisibility"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="ButtonTextVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnButtonTextVisibilityChanging(global::System.Windows.Visibility value);
        /// <summary>Executes the logic for when <see cref="ButtonTextVisibility"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="ButtonTextVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnButtonTextVisibilityChanging(global::System.Windows.Visibility oldValue, global::System.Windows.Visibility newValue);
        /// <summary>Executes the logic for when <see cref="ButtonTextVisibility"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="ButtonTextVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnButtonTextVisibilityChanged(global::System.Windows.Visibility value);
        /// <summary>Executes the logic for when <see cref="ButtonTextVisibility"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="ButtonTextVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnButtonTextVisibilityChanged(global::System.Windows.Visibility oldValue, global::System.Windows.Visibility newValue);
        /// <summary>Executes the logic for when <see cref="SavingProgressVisibility"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="SavingProgressVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSavingProgressVisibilityChanging(global::System.Windows.Visibility value);
        /// <summary>Executes the logic for when <see cref="SavingProgressVisibility"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="SavingProgressVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSavingProgressVisibilityChanging(global::System.Windows.Visibility oldValue, global::System.Windows.Visibility newValue);
        /// <summary>Executes the logic for when <see cref="SavingProgressVisibility"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="SavingProgressVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSavingProgressVisibilityChanged(global::System.Windows.Visibility value);
        /// <summary>Executes the logic for when <see cref="SavingProgressVisibility"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="SavingProgressVisibility"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSavingProgressVisibilityChanged(global::System.Windows.Visibility oldValue, global::System.Windows.Visibility newValue);
    }
}