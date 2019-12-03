using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using AsciiArtGenerator.ViewModels;
using AsciiGenerator.UI.Util;

namespace AsciiGenerator.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public WpfPlatformSupport PlatformSupport { get; set; } = new WpfPlatformSupport();

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // hier den Glue Code ergänzen (DataContext von MainWindow,
            // sowie ViewModels etc.):
            // ...          

            // ... und nicht vergessen, im App.xaml die Property
            // StartupUri zu entfernen, falls das MainWindow hier
            // erzeugt und angezeigt wird (wie z.B. in Ü4).
        }
    }
}
