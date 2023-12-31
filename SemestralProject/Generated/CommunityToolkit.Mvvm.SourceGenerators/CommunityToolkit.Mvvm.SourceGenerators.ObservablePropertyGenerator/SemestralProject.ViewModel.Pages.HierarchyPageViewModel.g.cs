﻿// <auto-generated/>
#pragma warning disable
#nullable enable
namespace SemestralProject.ViewModel.Pages
{
    /// <inheritdoc/>
    partial class HierarchyPageViewModel
    {
        /// <inheritdoc cref="viewData"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.HierarchyView> ViewData
        {
            get => viewData;
            [global::System.Diagnostics.CodeAnalysis.MemberNotNull("viewData")]
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.HierarchyView>>.Default.Equals(viewData, value))
                {
                    OnViewDataChanging(value);
                    OnViewDataChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ViewData);
                    viewData = value;
                    OnViewDataChanged(value);
                    OnViewDataChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ViewData);
                }
            }
        }

        /// <summary>Executes the logic for when <see cref="ViewData"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="ViewData"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnViewDataChanging(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.HierarchyView> value);
        /// <summary>Executes the logic for when <see cref="ViewData"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="ViewData"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnViewDataChanging(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.HierarchyView>? oldValue, global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.HierarchyView> newValue);
        /// <summary>Executes the logic for when <see cref="ViewData"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="ViewData"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnViewDataChanged(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.HierarchyView> value);
        /// <summary>Executes the logic for when <see cref="ViewData"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="ViewData"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnViewDataChanged(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.HierarchyView>? oldValue, global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.HierarchyView> newValue);
    }
}