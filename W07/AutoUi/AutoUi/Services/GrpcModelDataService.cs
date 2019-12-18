using System.Collections.ObjectModel;
using AutoUi.Core.Services;
using AutoUi.Core.ViewModels;

namespace AutoUi.Services
{
    /// <summary>
    /// die Service-Implementation, welche den Grpc-Client aus
    /// MsTe benutzt, um die Daten über das Netzwerk abzurufen.
    ///
    /// (Die konkrete Implementation ist abhängig von Ihrem
    /// Mini-Projekt, daher wird hier - noch - keine Implementation
    /// mitgeliefert)
    /// </summary>
    public class GrpcModelDataService : IModelDataService
    {
        public ObservableCollection<AutoVm> GetAutos()
        {
            throw new System.NotImplementedException();
        }

        public ObservableCollection<CustomerVm> GetCustomers()
        {
            throw new System.NotImplementedException();
        }
    }
}