using Assignment1.Mvvm.Core;
using System.Windows;

namespace Assignment1.Mvvm.App
{
    public partial class MainWindow : Window
    {
        // Property Deklaration für einfacheren Zugriff auf das View Model
        private GreetingVm TheModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            // neue Instanz des ViewModels erzeugen ...
            TheModel = new GreetingVm();

            // ... und diese dann ans UI "kleben"
            DataContext = TheModel;
        }

        private void SayHelloButton_Click(object sender, RoutedEventArgs e)
        {
            // wir ändern den Wert nun im ViewModel und manipulieren das
            // UI nicht mehr direkt
            TheModel.Greeting = $"Hello, {TheModel.Name}!";

            // unter Nutzung der Klasse GreetingVm wird das UI sich
            // leider nicht korrekt aktualisieren (Rückschritt gegenüber
            // Aufgabe 3) 

            // wenn wir jedoch oben die Klasse BindableGreetingVm verwenden,
            // aktualisiert sich das ui automa(g)isch und zeigt die im 
            // ViewModel geänderten Werte sofort korrekt an, ohne dass
            // wir etwas zusätzliches Vorsehen müssten
        }
    }
}
