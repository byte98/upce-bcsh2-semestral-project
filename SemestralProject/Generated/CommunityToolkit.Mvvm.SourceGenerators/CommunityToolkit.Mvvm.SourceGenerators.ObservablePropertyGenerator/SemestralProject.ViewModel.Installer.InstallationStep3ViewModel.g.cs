﻿// <auto-generated/>
#pragma warning disable
#nullable enable
namespace SemestralProject.ViewModel.Installer
{
    /// <inheritdoc/>
    partial class InstallationStep3ViewModel
    {
        /// <inheritdoc cref="image"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::System.Windows.Media.ImageSource Image
        {
            get => image;
            [global::System.Diagnostics.CodeAnalysis.MemberNotNull("image")]
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::System.Windows.Media.ImageSource>.Default.Equals(image, value))
                {
                    OnImageChanging(value);
                    OnImageChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Image);
                    image = value;
                    OnImageChanged(value);
                    OnImageChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Image);
                }
            }
        }

        /// <inheritdoc cref="userImage"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::SemestralProject.Model.Entities.ImageFile UserImage
        {
            get => userImage;
            [global::System.Diagnostics.CodeAnalysis.MemberNotNull("userImage")]
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::SemestralProject.Model.Entities.ImageFile>.Default.Equals(userImage, value))
                {
                    OnUserImageChanging(value);
                    OnUserImageChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.UserImage);
                    userImage = value;
                    OnUserImageChanged(value);
                    OnUserImageChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.UserImage);
                    NextCommand.NotifyCanExecuteChanged();
                }
            }
        }

        /// <inheritdoc cref="imageSource"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public string ImageSource
        {
            get => imageSource;
            [global::System.Diagnostics.CodeAnalysis.MemberNotNull("imageSource")]
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<string>.Default.Equals(imageSource, value))
                {
                    OnImageSourceChanging(value);
                    OnImageSourceChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.ImageSource);
                    imageSource = value;
                    OnImageSourceChanged(value);
                    OnImageSourceChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.ImageSource);
                }
            }
        }

        /// <inheritdoc cref="name"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public string Name
        {
            get => name;
            [global::System.Diagnostics.CodeAnalysis.MemberNotNull("name")]
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<string>.Default.Equals(name, value))
                {
                    OnNameChanging(value);
                    OnNameChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Name);
                    name = value;
                    OnNameChanged(value);
                    OnNameChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Name);
                    NextCommand.NotifyCanExecuteChanged();
                }
            }
        }

        /// <inheritdoc cref="surname"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public string Surname
        {
            get => surname;
            [global::System.Diagnostics.CodeAnalysis.MemberNotNull("surname")]
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<string>.Default.Equals(surname, value))
                {
                    OnSurnameChanging(value);
                    OnSurnameChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Surname);
                    surname = value;
                    OnSurnameChanged(value);
                    OnSurnameChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Surname);
                    NextCommand.NotifyCanExecuteChanged();
                }
            }
        }

        /// <inheritdoc cref="email"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public string Email
        {
            get => email;
            [global::System.Diagnostics.CodeAnalysis.MemberNotNull("email")]
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<string>.Default.Equals(email, value))
                {
                    OnEmailChanging(value);
                    OnEmailChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Email);
                    email = value;
                    OnEmailChanged(value);
                    OnEmailChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Email);
                    NextCommand.NotifyCanExecuteChanged();
                }
            }
        }

        /// <inheritdoc cref="phone"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public string Phone
        {
            get => phone;
            [global::System.Diagnostics.CodeAnalysis.MemberNotNull("phone")]
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<string>.Default.Equals(phone, value))
                {
                    OnPhoneChanging(value);
                    OnPhoneChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Phone);
                    phone = value;
                    OnPhoneChanged(value);
                    OnPhoneChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Phone);
                    NextCommand.NotifyCanExecuteChanged();
                }
            }
        }

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
                    NextCommand.NotifyCanExecuteChanged();
                }
            }
        }

        /// <inheritdoc cref="password"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public string Password
        {
            get => password;
            [global::System.Diagnostics.CodeAnalysis.MemberNotNull("password")]
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<string>.Default.Equals(password, value))
                {
                    OnPasswordChanging(value);
                    OnPasswordChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Password);
                    password = value;
                    OnPasswordChanged(value);
                    OnPasswordChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Password);
                    NextCommand.NotifyCanExecuteChanged();
                }
            }
        }

        /// <inheritdoc cref="address"/>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        [global::System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
        public global::SemestralProject.Model.Entities.Address? Address
        {
            get => address;
            set
            {
                if (!global::System.Collections.Generic.EqualityComparer<global::SemestralProject.Model.Entities.Address?>.Default.Equals(address, value))
                {
                    OnAddressChanging(value);
                    OnAddressChanging(default, value);
                    OnPropertyChanging(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangingArgs.Address);
                    address = value;
                    OnAddressChanged(value);
                    OnAddressChanged(default, value);
                    OnPropertyChanged(global::CommunityToolkit.Mvvm.ComponentModel.__Internals.__KnownINotifyPropertyChangedArgs.Address);
                    NextCommand.NotifyCanExecuteChanged();
                }
            }
        }

        /// <summary>Executes the logic for when <see cref="Image"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Image"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnImageChanging(global::System.Windows.Media.ImageSource value);
        /// <summary>Executes the logic for when <see cref="Image"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Image"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnImageChanging(global::System.Windows.Media.ImageSource? oldValue, global::System.Windows.Media.ImageSource newValue);
        /// <summary>Executes the logic for when <see cref="Image"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Image"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnImageChanged(global::System.Windows.Media.ImageSource value);
        /// <summary>Executes the logic for when <see cref="Image"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Image"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnImageChanged(global::System.Windows.Media.ImageSource? oldValue, global::System.Windows.Media.ImageSource newValue);
        /// <summary>Executes the logic for when <see cref="UserImage"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="UserImage"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnUserImageChanging(global::SemestralProject.Model.Entities.ImageFile value);
        /// <summary>Executes the logic for when <see cref="UserImage"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="UserImage"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnUserImageChanging(global::SemestralProject.Model.Entities.ImageFile? oldValue, global::SemestralProject.Model.Entities.ImageFile newValue);
        /// <summary>Executes the logic for when <see cref="UserImage"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="UserImage"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnUserImageChanged(global::SemestralProject.Model.Entities.ImageFile value);
        /// <summary>Executes the logic for when <see cref="UserImage"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="UserImage"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnUserImageChanged(global::SemestralProject.Model.Entities.ImageFile? oldValue, global::SemestralProject.Model.Entities.ImageFile newValue);
        /// <summary>Executes the logic for when <see cref="ImageSource"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="ImageSource"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnImageSourceChanging(string value);
        /// <summary>Executes the logic for when <see cref="ImageSource"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="ImageSource"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnImageSourceChanging(string? oldValue, string newValue);
        /// <summary>Executes the logic for when <see cref="ImageSource"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="ImageSource"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnImageSourceChanged(string value);
        /// <summary>Executes the logic for when <see cref="ImageSource"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="ImageSource"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnImageSourceChanged(string? oldValue, string newValue);
        /// <summary>Executes the logic for when <see cref="Name"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Name"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnNameChanging(string value);
        /// <summary>Executes the logic for when <see cref="Name"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Name"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnNameChanging(string? oldValue, string newValue);
        /// <summary>Executes the logic for when <see cref="Name"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Name"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnNameChanged(string value);
        /// <summary>Executes the logic for when <see cref="Name"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Name"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnNameChanged(string? oldValue, string newValue);
        /// <summary>Executes the logic for when <see cref="Surname"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Surname"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSurnameChanging(string value);
        /// <summary>Executes the logic for when <see cref="Surname"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Surname"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSurnameChanging(string? oldValue, string newValue);
        /// <summary>Executes the logic for when <see cref="Surname"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Surname"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSurnameChanged(string value);
        /// <summary>Executes the logic for when <see cref="Surname"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Surname"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnSurnameChanged(string? oldValue, string newValue);
        /// <summary>Executes the logic for when <see cref="Email"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Email"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnEmailChanging(string value);
        /// <summary>Executes the logic for when <see cref="Email"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Email"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnEmailChanging(string? oldValue, string newValue);
        /// <summary>Executes the logic for when <see cref="Email"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Email"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnEmailChanged(string value);
        /// <summary>Executes the logic for when <see cref="Email"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Email"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnEmailChanged(string? oldValue, string newValue);
        /// <summary>Executes the logic for when <see cref="Phone"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Phone"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnPhoneChanging(string value);
        /// <summary>Executes the logic for when <see cref="Phone"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Phone"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnPhoneChanging(string? oldValue, string newValue);
        /// <summary>Executes the logic for when <see cref="Phone"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Phone"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnPhoneChanged(string value);
        /// <summary>Executes the logic for when <see cref="Phone"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Phone"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnPhoneChanged(string? oldValue, string newValue);
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
        partial void OnPasswordChanging(string value);
        /// <summary>Executes the logic for when <see cref="Password"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Password"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnPasswordChanging(string? oldValue, string newValue);
        /// <summary>Executes the logic for when <see cref="Password"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Password"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnPasswordChanged(string value);
        /// <summary>Executes the logic for when <see cref="Password"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Password"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnPasswordChanged(string? oldValue, string newValue);
        /// <summary>Executes the logic for when <see cref="Address"/> is changing.</summary>
        /// <param name="value">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Address"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnAddressChanging(global::SemestralProject.Model.Entities.Address? value);
        /// <summary>Executes the logic for when <see cref="Address"/> is changing.</summary>
        /// <param name="oldValue">The previous property value that is being replaced.</param>
        /// <param name="newValue">The new property value being set.</param>
        /// <remarks>This method is invoked right before the value of <see cref="Address"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnAddressChanging(global::SemestralProject.Model.Entities.Address? oldValue, global::SemestralProject.Model.Entities.Address? newValue);
        /// <summary>Executes the logic for when <see cref="Address"/> just changed.</summary>
        /// <param name="value">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Address"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnAddressChanged(global::SemestralProject.Model.Entities.Address? value);
        /// <summary>Executes the logic for when <see cref="Address"/> just changed.</summary>
        /// <param name="oldValue">The previous property value that was replaced.</param>
        /// <param name="newValue">The new property value that was set.</param>
        /// <remarks>This method is invoked right after the value of <see cref="Address"/> is changed.</remarks>
        [global::System.CodeDom.Compiler.GeneratedCode("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "8.2.0.0")]
        partial void OnAddressChanged(global::SemestralProject.Model.Entities.Address? oldValue, global::SemestralProject.Model.Entities.Address? newValue);
    }
}