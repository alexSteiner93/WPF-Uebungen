using System.Diagnostics;
using System.Windows;

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

        private void AutoWindow_Click(object sender, RoutedEventArgs e)
        {
            var win = new AutoWindow();
            if (win.ShowDialog() != true)
            {
                // Abbrechen ...
                Debug.WriteLine("Bearbeitung des Autos abgebrochen");
                return;
            }

            // Ok geklickt... 
            Debug.WriteLine("Bearbeitung des Autos beendet");
            return;
        }

        private void CustomerWindow_Click(object sender, RoutedEventArgs e)
        {
            var win = new CustomerWindow();
            if (win.ShowDialog() != true)
            {
                // Abbrechen ...
                Debug.WriteLine("Bearbeitung des Kunden abgebrochen");
                return;
            }

            // Ok geklickt... 
            Debug.WriteLine("Bearbeitung des Kunden beendet");
            return;
        }
    }
}
