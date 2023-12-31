﻿using System;
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

namespace SemestralProject.View
{
    /// <summary>
    /// Interaction logic for MasterWindow.xaml
    /// </summary>
    public partial class MasterWindow : Window
    {
        /// <summary>
        /// Frame with main content of page.
        /// </summary>
        public static Frame? ContentFrame = null;

        public MasterWindow()
        {
            InitializeComponent();
            MasterWindow.ContentFrame = this.FrameContent;
        }
    }
}
