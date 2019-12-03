using System.Diagnostics;
using System.Windows;
using AutoUi.Services;

namespace AutoUi.Util
{
    public static class WindowExtensions
    {
        public static bool Display<TWin, TVm>(this TWin window, TVm viewModel)
            where TVm: new()
            where TWin: Window,IBindableWindow<TVm>, new()
        {
            // damit wir beim Abbrechen nicht aus Versehen etwas
            // übernehmen, das wir nicht wollen, arbeiten wir
            // temporär mit einer Kopie
            var vm = PoorMansObjectCloner.Clone<TVm>(viewModel);

            var win = new TWin();
            win.Model = viewModel;

            // wir zeigen das Fenster als Dialogfenster (blockierend!) an
            if (win.ShowDialog() != true)
            {
                // Abbrechen ...
                Debug.WriteLine("Bearbeitung des Kunden abgebrochen");
                return false;
            }

            // Ok geklickt... 
            Debug.WriteLine("Bearbeitung des Kunden beendet");

            // nun wollen wir die geänderten Properties zurück ins
            // Originalobjekt übernehmen
            PoorMansObjectCloner.CopyProperties(vm, viewModel);

            return true;
        }
    }
}
