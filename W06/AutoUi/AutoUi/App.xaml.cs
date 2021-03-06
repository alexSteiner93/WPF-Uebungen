﻿using System.Windows;
using AutoUi.ViewModels;

namespace AutoUi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public AppVm Vm { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // hier den Glue Code ergänzen (DataContext von MainWindow,
            // sowie ViewModels etc.):
            // ...          

            Vm = new AppVm();

            MainWindow = new MainWindow();
            MainWindow.DataContext = Vm;
            MainWindow.Show();

            // ... und nicht vergessen, im App.xaml die Property
            // StartupUri zu entfernen, falls das MainWindow hier
            // erzeugt und angezeigt wird (wie z.B. in Ü4).
        }
    }
}
