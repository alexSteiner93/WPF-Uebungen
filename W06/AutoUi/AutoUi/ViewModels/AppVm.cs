using System.Linq;
using System.Windows.Input;
using AutoUi.Core.Commands;
using AutoUi.Core.Services;
using AutoUi.Core.ViewModels;
using AutoUi.Views;

namespace AutoUi.ViewModels
{
    // Unser App ViewModel ist diese Woche noch im WPF-Projekt,
    // da wir von hier aus ja direkt WPF-Objekte erstellen
    // (resp. Fenster erstellen und öffnen).
    // Nächste Woche besprechen wir noch, wie wir das noch
    // besser lösen können (mit Interfaces, konkreten Implementationen
    // davon und Dependency Injection)
    public class AppVm
    {
        public AutoListVm AutoListModel { get; set; }
        public AutoVm DemoAuto { get; set; }
        public CustomerVm DemoCustomer { get; set; }

        // Die Commands brauchen wir nur zu lesen
        // (werden nur im Konstruktor geschrieben, daher 
        // können wir auf einen Setter verzichten)
        public ICommand ShowAutoListCommand { get; }
        public ICommand EditAutoCommand { get; }
        public ICommand EditCustomerCommand { get; }


        public AppVm()
        {
            // Ohne Parameter, daher direkt RelayCommand
            ShowAutoListCommand = new RelayCommand(ShowAutoList);

            // Mit dem jeweiligen ViewModel als Command Parameter,
            // daher RelayCommand<T>
            EditAutoCommand = new RelayCommand<AutoVm>(EditAuto);
            EditCustomerCommand = new RelayCommand<CustomerVm>(EditCustomer);

            // unsere ViewModels (mit Beispieldaten)
            AutoListModel = new AutoListVm()
            {
                Autos = MockDataProvider.BeispielAutos
            };
            DemoAuto = MockDataProvider.BeispielAutos.First();
            DemoCustomer = MockDataProvider.BeispielKunden.First();

        }


        public void ShowAutoList()
        {
            // Hier greifen wir direkt auf eine "View" zu,
            // was wir eigentlich in einem ViewModel nicht wollen
            // -> vgl. Stoff Block 6 nächste Woche
            AutoListWindow.Display(AutoListModel);
        }

        public void EditAuto(AutoVm auto)
        {
            // Hier greifen wir direkt auf eine "View" zu,
            // was wir eigentlich in einem ViewModel nicht wollen
            // -> vgl. Stoff Block 6 nächste Woche
            AutoWindow.Display(auto);
        }

        public void EditCustomer(CustomerVm customer)
        {
            // Hier greifen wir direkt auf eine "View" zu,
            // was wir eigentlich in einem ViewModel nicht wollen
            // -> vgl. Stoff Block 6 nächste Woche
            CustomerWindow.Display(customer);
        }
    }
}
