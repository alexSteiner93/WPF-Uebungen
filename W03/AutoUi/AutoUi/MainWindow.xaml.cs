﻿using System.Windows;
using System.Windows.Input;

namespace ModernUi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void AutoWindow_Click(object sender, RoutedEventArgs e)
        {
            new AutoWindow().Show();
        }

        private void CustomerWindow_Click(object sender, RoutedEventArgs e)
        {
            new CustomerWindow().Show();
        }
    }
}
