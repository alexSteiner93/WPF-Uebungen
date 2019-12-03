using System.Linq;
using System.Windows;
using AutoUi.Services;
using AutoUi.ViewModels;
using AutoUi.Views;

namespace AutoUi
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

        
        private void AutoListWindow_Click(object sender, RoutedEventArgs e)
        {
            var vm = new AutoListVm()
            {
                Autos = MockDataProvider.BeispielAutos
            };

            AutoListWindow.Display(vm);
        }

        private void AutoWindow_Click(object sender, RoutedEventArgs e)
        {
            var vm = MockDataProvider.BeispielAutos.First();

            AutoWindow.Display(vm);
        }

        private void CustomerWindow_Click(object sender, RoutedEventArgs e)
        {
            var vm = MockDataProvider.BeispielKunden.First();

            CustomerWindow.Display(vm);
        }

    }
}
