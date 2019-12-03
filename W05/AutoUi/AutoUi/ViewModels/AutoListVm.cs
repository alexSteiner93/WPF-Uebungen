using System.Collections.ObjectModel;
using System.Linq;

namespace AutoUi.ViewModels
{
    public class AutoListVm : BindableBase
    {
        private ObservableCollection<AutoVm> _autos;

        public ObservableCollection<AutoVm> Autos
        {
            get { return _autos; }
            set { SetProperty(ref _autos, value); }
        }

        public int AnzahlAutos => Autos.Count;

        public int AnzahlNeueAutos => Autos.Count(x => x.IstNeu);
    }
}
