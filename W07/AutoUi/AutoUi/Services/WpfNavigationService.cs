using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using AutoUi.Core.Services;
using AutoUi.Core.ViewModels;
using AutoUi.Views;

namespace AutoUi.Services
{
    public class WpfNavigationService : INavigationService
    {
        public readonly Dictionary<Type, Action<object>> WindowFactory = new Dictionary<Type, Action<object>>();

        public WpfNavigationService()
        {
            WindowFactory.Add(typeof(AutoListVm), vm => AutoListWindow.Display(vm as AutoListVm));
            WindowFactory.Add(typeof(AutoVm), vm => AutoWindow.Display(vm as AutoVm));
            WindowFactory.Add(typeof(CustomerVm), vm => CustomerWindow.Display(vm as CustomerVm));
        }

        public void Show<T>(T vm)
        {
            var factoryAction = WindowFactory[typeof(T)];

            // Zur Sicherheit wrappen wir den Aufruf der
            // jeweiligen Display-Methoden in einem Aufruf
            // an Dispatcher.Invoke(...), um sicherzustellen,
            // dass dies im UI Thread erfolgt und nicht 
            // aus Versehen aus einem Background Thread
            // heraus...
            App.Current.Dispatcher.Invoke(() => factoryAction(vm));
        }

    }
}
