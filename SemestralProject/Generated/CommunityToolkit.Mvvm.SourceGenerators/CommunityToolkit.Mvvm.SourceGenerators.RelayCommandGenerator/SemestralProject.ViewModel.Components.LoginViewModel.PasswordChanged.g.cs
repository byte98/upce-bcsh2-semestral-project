﻿// <auto-generated/>
#pragma warning disable
#nullable enable
namespace SemestralProject.ViewModel.Components
{
    /// <inheritdoc/>
    partial class LoginViewModel
    {
        /// <summary>The backing field for <see cref="PasswordChangedCommand"/>.</summary>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.2.0.0")]
        private global::CommunityToolkit.Mvvm.Input.RelayCommand<global::System.Windows.Controls.PasswordBox>? passwordChangedCommand;
        /// <summary>Gets an <see cref="global::CommunityToolkit.Mvvm.Input.IRelayCommand{T}"/> instance wrapping <see cref="PasswordChanged"/>.</summary>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.RelayCommandGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::CommunityToolkit.Mvvm.Input.IRelayCommand<global::System.Windows.Controls.PasswordBox> PasswordChangedCommand => passwordChangedCommand ??= new global::CommunityToolkit.Mvvm.Input.RelayCommand<global::System.Windows.Controls.PasswordBox>(new global::System.Action<global::System.Windows.Controls.PasswordBox>(PasswordChanged));
    }
}