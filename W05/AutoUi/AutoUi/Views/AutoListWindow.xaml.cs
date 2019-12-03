using System.Windows;
using AutoUi.ViewModels;

namespace AutoUi.Views
{
    /// <summary>
    /// Interaction logic for AutoListWindow.xaml
    /// </summary>
    public partial class AutoListWindow : Window
    {
        public AutoListVm Model { get; set; }

        public AutoListWindow(AutoListVm model)
        {
            InitializeComponent();

            Model = model;

            DataContext = model;
        }

        /// <summary>
        /// Helper-Methode zum einfachen Anzeigen des Fensters
        /// </summary>
        /// <param name="model">Das ViewModel, welches angezeigt werden soll</param>
        /// <returns>true, falls der User Ok geklickt hat</returns>
        public static void Display(AutoListVm model)
        {
            // Keine Kopie, da Daten nur Read-Only angezeigt
            var win = new AutoListWindow(model);

            // wir zeigen das Fenster als Dialogfenster (blockierend!) an
            win.ShowDialog();

            // Resultat von .DialogResult()-Call spielt hier keine Rolle...
            // Daher ist Methode void
        }
    }

}
