using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
    /// Interaction logic for InstallerTitle.xaml
    /// </summary>
    public partial class InstallerTitle : Page
    {
        public InstallerTitle()
        {
            InitializeComponent();
            this.LabelVersion.Content = Assembly.GetExecutingAssembly().GetName().Version;
        }
    }
}
