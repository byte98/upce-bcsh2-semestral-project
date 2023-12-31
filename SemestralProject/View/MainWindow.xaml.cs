﻿using SemestralProject.Common;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Frame in which main content will be rendered.
        /// </summary>
        public static Frame? ContentFrame { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            MainWindow.ContentFrame = this.FrameContent;
        }
    }
}
