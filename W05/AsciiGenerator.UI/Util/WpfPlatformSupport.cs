using System.Windows;
using Microsoft.Win32;

namespace AsciiGenerator.UI.Util
{
    /// <summary>
    /// Wpf-spezifische Version des ViewModels
    /// </summary>
    public class WpfPlatformSupport
    {

        /// <summary>
        /// Zeigt ein Datei-Öffnen Dialogfenster, erlaubt die Auswahl einer
        /// Bilddatei und weist das ausgewählte Bild der Property ImagePath zu.
        /// </summary>
        public string ChooseFile()
        {
            var dlg = new OpenFileDialog();
            
            // nur Bilder auswählen lassen
            dlg.Filter = "Image Files | *.jpg; *.jpeg; *.png; *.gif;";

            // Pfad des .exe verwenden:
            dlg.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            // Dialogbox anzeigen (blockiert!)
            if (dlg.ShowDialog() != true)
                return null;

            return string.IsNullOrEmpty(dlg.FileName) ? null : dlg.FileName;
        }

        /// <summary>
        /// Zeigt eine Fehlermeldung in einer Message box an
        /// </summary>
        /// <param name="msg"></param>
        public void ShowError(string msg)
        {
            MessageBox.Show(msg, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
