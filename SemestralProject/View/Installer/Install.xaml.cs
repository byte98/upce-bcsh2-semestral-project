using SemestralProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SemestralProject.View.Installer
{
    /// <summary>
    /// Interaction logic for Install1.xaml
    /// </summary>
    public partial class Install : Page
    {
        /// <summary>
        /// Handler of the whole installation process.
        /// </summary>
        private readonly InstallViewModel install;

        public Install()
        {
            InitializeComponent();
            this.install = new InstallViewModel();
            this.install.ButtonNextEnabledChanged += (sender, args) =>
            {
                this.ButtonNext.Dispatcher.Invoke(() =>
                {
                    this.ButtonNext.IsEnabled = args.ButtonEnabled;
                });
            };
            this.install.ButtonPreviousEnabledChanged += (sender, args) =>
            {
                this.ButtonPrevious.Dispatcher.Invoke(() =>
                {
                    this.ButtonPrevious.IsEnabled = args.ButtonEnabled;
                });
                
            };
            this.ContentInstall.Content = this.install.GoNext();
        }

        private void ButtonBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ButtonNext_Click(object sender, RoutedEventArgs e)
        {
            this.ContentInstall.Content = this.install.GoNext();
        }

        private void ButtonPrevious_Click(object sender, RoutedEventArgs e)
        {
            this.ContentInstall.Content = this.install.GoNext();
        }
    }
}
