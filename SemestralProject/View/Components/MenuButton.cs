using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SemestralProject.View.Components
{
    /// <summary>
    /// Class representing menu button.
    /// </summary>
    public class MenuButton: RadioButton
    {
        /// <summary>
        /// Creates menu button.
        /// </summary>
        static MenuButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuButton), new FrameworkPropertyMetadata(typeof(MenuButton)));
        }
    }
}
