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
using System.Windows.Shapes;

namespace SemestralProject.View.Installer
{
    /// <summary>
    /// Interaction logic for InstallerWindow.xaml
    /// </summary>
    public partial class InstallerWindow : Window
    {
        /// <summary>
        /// Content of the window.
        /// </summary>
        public static Frame? ContentFrame = null;

        public InstallerWindow()
        {
            InitializeComponent();
            InstallerWindow.ContentFrame = this.FrameContent;
        }
    }
}
