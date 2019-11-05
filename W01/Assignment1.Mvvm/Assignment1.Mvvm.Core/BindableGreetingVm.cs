using Assignment1.Mvvm.Util;
namespace Assignment1.Mvvm.Core
{
    /// <summary>
    /// Diese Version der ViewModel Klasse implementiert
    /// das Interface INotifyPropertyChanged (in Basisklasse
    /// BindableBase). Dies ermöglicht es dem User Interface,
    /// zur Laufzeit über Änderungen an Properties von
    /// Objekten dieser Klasse informiert zu werden.
    /// </summary>
    public class BindableGreetingVm:BindableBase
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private string _greeting;
        public string Greeting
        {
            get { return _greeting; }
            set { SetProperty(ref _greeting, value); }
        }
    }
}
