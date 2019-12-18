using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using AutoUi.Core.Commands;
using AutoUi.Core.Services;

namespace AutoUi.Core.ViewModels
{
    // Unser App ViewModel ist diese Woche noch im WPF-Projekt,
    // da wir von hier aus ja direkt WPF-Objekte erstellen
    // (resp. Fenster erstellen und öffnen).
    // Nächste Woche besprechen wir noch, wie wir das noch
    // besser lösen können (mit Interfaces, konkreten Implementationen
    // davon und Dependency Injection)
    public class AppVm:BindableBase
    {
        // flag, um anzuzeigen, ob gerade etwas läuft oder nicht...
        private bool _isLoading;
        public bool IsLoading
        {
            get { return _isLoading; }
            set { SetProperty(ref _isLoading, value, null, nameof(IsIdle)); }
        }

        // Zusätzlich eine zweite Property anbieten, mit welcher
        // das umgekehrte Flag abgerufen werden kann
        public bool IsIdle => !IsLoading;

        public AutoListVm AutoListModel { get; set; }
        public AutoVm DemoAuto { get; set; }
        public CustomerVm DemoCustomer { get; set; }

        // Die Commands brauchen wir nur zu lesen
        // (werden nur im Konstruktor geschrieben, daher 
        // können wir auf einen Setter verzichten)
        public ICommand ShowAutoListCommand { get; }
        public ICommand EditAutoCommand { get; }
        public ICommand EditCustomerCommand { get; }

        // die konkrete IModelDataService-Implementation übergeben
        // wir im Konstruktor, daher hier nur ein Auto-Getter
        public IModelDataService ModelDataService { get; }

        // die konkrete INavigationService-Implementation übergeben
        // wir im Konstruktor, daher hier nur ein Auto-Getter
        public INavigationService NavigationService { get; }

        public AppVm(IModelDataService modelService, INavigationService navigationService)
        {
            ModelDataService = modelService;
            NavigationService = navigationService;

            // Ohne Parameter, daher direkt RelayCommand
            ShowAutoListCommand = new RelayCommand(ShowAutoList);

            // Mit dem jeweiligen ViewModel als Command Parameter,
            // daher RelayCommand<T>
            EditAutoCommand = new RelayCommand<AutoVm>(EditAuto);
            EditCustomerCommand = new RelayCommand<CustomerVm>(EditCustomer);

            // unsere ViewModels (mit Beispieldaten)
            AutoListModel = new AutoListVm()
            {
                Autos = modelService.GetAutos()
            };
            DemoAuto = modelService.GetAutos().First();
            DemoCustomer = modelService.GetCustomers().First();

        }


        public void ShowAutoList()
        {
            // nun greifen wir nicht mehr direkt auf die View zu,
            // sondern nutzen den Navigation Service

            Task.Run(() =>
            {
                // Start des Vorgangs signalisieren
                IsLoading = true;

                // Autoliste neu laden:
                AutoListModel.Autos = ModelDataService.GetAutos();

                // zu Demozwecken eine Sekunde Pause machen...
                Thread.Sleep(1000);

                // Ende des Vorgangs signalisieren
                IsLoading = false;

                // und nun das entsprechende Fenster anzeigen
                NavigationService.Show(AutoListModel);

            });

           
        }

        public void EditAuto(AutoVm auto)
        {
            NavigationService.Show(auto);
        }

        public void EditCustomer(CustomerVm customer)
        {
            NavigationService.Show(customer);
        }
    }
}
