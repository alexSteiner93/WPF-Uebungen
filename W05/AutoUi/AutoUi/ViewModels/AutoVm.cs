using System.Collections.Generic;
using AutoUi.Util;

namespace AutoUi.ViewModels
{
    public class AutoVm:BindableBase
    {
        private string _name;
        public string Name
        {
            // hier mit "alter" Syntax
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        private bool _istNeu;
        public bool IstNeu
        {
            // ab hier mit kürzerer Lambda-Syntax
            get => _istNeu;
            set => SetProperty(ref _istNeu, value);
        }

        private decimal _tagestarif;
        public decimal Tagestarif
        {
            get => _tagestarif;
            set => SetProperty(ref _tagestarif, value);
        }

        private AutoklasseEnum _autoklasse;
        public AutoklasseEnum Autoklasse
        {
            get => _autoklasse;
            set => SetProperty(ref _autoklasse, value);
        }


        // Da ein ViewModel quasi der "Butler" für die View ist, stellen wir
        // auch die Liste von Autoklassen via Data Binding zur Verfügung:
        // dabei benutzen wir eine Helper-Methode, die uns alle Enum Values in einer
        // Liste zurückgibt:
        public List<AutoklasseEnum> Autoklassen { get; } = EnumUtils.GetListOfEnumValues<AutoklasseEnum>();
    }
}
