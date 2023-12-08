﻿// <auto-generated/>
#pragma warning disable
#nullable enable
namespace SemestralProject.ViewModel.Pages
{
    /// <inheritdoc/>
    partial class EmployeesPageViewModel
    {
        /// <inheritdoc cref="employees"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Employee> Employees
        {
            get => employees;
            [global::System.Diagnostics.CodeAnalysis.MemberNotNull("employees")]
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Employee>>.Default.Equals(employees, value))
                {
                    OnEmployeesChanging(value);
                    OnEmployeesChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Employees);
                    employees = value;
                    OnEmployeesChanged(value);
                    OnEmployeesChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Employees);
                }
            }
        }

        /// <inheritdoc cref="selectedEmployee"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::SemestralProject.Model.Entities.Employee? SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::SemestralProject.Model.Entities.Employee?>.Default.Equals(selectedEmployee, value))
                {
                    OnSelectedEmployeeChanging(value);
                    OnSelectedEmployeeChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.SelectedEmployee);
                    selectedEmployee = value;
                    OnSelectedEmployeeChanged(value);
                    OnSelectedEmployeeChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.SelectedEmployee);
                }
            }
        }

        /// <summary>Executes the logic for when <see cref="Employees"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Employees"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnEmployeesChanging(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Employee> value);
        /// <summary>Executes the logic for when <see cref="Employees"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Employees"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnEmployeesChanging(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Employee>? oldValue, global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Employee> newValue);
        /// <summary>Executes the logic for when <see cref="Employees"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Employees"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnEmployeesChanged(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Employee> value);
        /// <summary>Executes the logic for when <see cref="Employees"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Employees"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnEmployeesChanged(global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Employee>? oldValue, global::System.Collections.ObjectModel.ObservableCollection<global::SemestralProject.Model.Entities.Employee> newValue);
        /// <summary>Executes the logic for when <see cref="SelectedEmployee"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="SelectedEmployee"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedEmployeeChanging(global::SemestralProject.Model.Entities.Employee? value);
        /// <summary>Executes the logic for when <see cref="SelectedEmployee"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="SelectedEmployee"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedEmployeeChanging(global::SemestralProject.Model.Entities.Employee? oldValue, global::SemestralProject.Model.Entities.Employee? newValue);
        /// <summary>Executes the logic for when <see cref="SelectedEmployee"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="SelectedEmployee"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedEmployeeChanged(global::SemestralProject.Model.Entities.Employee? value);
        /// <summary>Executes the logic for when <see cref="SelectedEmployee"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="SelectedEmployee"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSelectedEmployeeChanged(global::SemestralProject.Model.Entities.Employee? oldValue, global::SemestralProject.Model.Entities.Employee? newValue);
    }
}