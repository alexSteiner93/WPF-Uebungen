using System.Collections.ObjectModel;
using AutoUi.Core.ViewModels;

namespace AutoUi.Core.Services
{
    /// <summary>
    /// Unser Service-Interface, welches vorschreibt, wie wir
    /// Daten abrufen können
    /// </summary>
    public interface IModelDataService
    {
        /// <summary>
        /// gibt alle verfügbaren Autos zurück
        /// </summary>
        /// <returns></returns>
        ObservableCollection<AutoVm> GetAutos();

        /// <summary>
        /// gibt alle verfügbaren Kundendaten zurück
        /// </summary>
        /// <returns></returns>
        ObservableCollection<CustomerVm> GetCustomers();
    }
}
