using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using AsciiArtGenerator;
using AsciiGenerator.UI.Commands;
using Microsoft.Win32;

namespace AsciiGenerator.UI.ViewModels
{
    public class AsciiGeneratorViewModel:BindableBase
    {
        // Kommando, das ein ASCII Art erzeugt
        private ICommand _calcCommand;
        public ICommand CalcCommand => _calcCommand ?? (_calcCommand = new RelayCommand(() => CreateAsciiArt()));

        // Kommando, das den Datei-Öffnen Dialog anzeigt
        private ICommand _chooseFileCommand;
        public ICommand ChooseFileCommand => _chooseFileCommand ?? (_chooseFileCommand = new RelayCommand(() => ChooseFile()));

        private int _fontSize;
        public int FontSize
        {
            get { return _fontSize; }
            set { SetProperty(ref _fontSize, value, nameof(FontSize)); }
        }


        private int _lineWidth;
        public int LineWidth
        {
            get { return _lineWidth; }
            set { SetProperty(ref _lineWidth, value, nameof(LineWidth)); }
        }

        private string _result;
        public string Result
        {
            get { return _result; }
            set { SetProperty(ref _result, value, nameof(Result)); }
        }


        private string _imagePath;
        public string ImagePath
        {
            get { return _imagePath; }
            set { SetProperty(ref _imagePath, value, nameof(ImagePath)); }
        }

        private bool _canCreate;

        public bool CanCreate
        {
            get { return _canCreate; }
            set { SetProperty(ref _canCreate, value, nameof(CanCreate)); }
        }

        public AsciiGeneratorViewModel()
        {
            CanCreate = true;
            LineWidth = 80;
            FontSize = 12;
        }
        

        /// <summary>
        /// Erzeugt ein ASCII Art aus dem Bild, das der Property ImagePath
        /// zugewiesen wurde. Legt das Resultat in der Property Result ab.
        /// </summary>
        public void CreateAsciiArt()
        {
            if (string.IsNullOrEmpty(ImagePath))
            {
                ShowError("Kann leider nichts berechnen: Keine Quelldatei angegeben");
                return;
            }

            if (!System.IO.File.Exists(ImagePath))
            {
                ShowError("Kann leider nichts berechnen: Quelldatei nicht gefunden");
                return;
            }

            CanCreate = false;

            try
            {
                // Achtung: Non-WPF Image!
                var bm = (Bitmap) System.Drawing.Image.FromFile(ImagePath);
                var generator = new Generator();
                var result = generator.GenerateFrom(bm, LineWidth);

                // should notify the UI automa(g)ically
                Result = result;
            }
            catch (Exception e)
            {
                ShowError($"Berechnung fehlgeschlagen. Ursache: {e.Message}");
            }

            CanCreate = true;
        }

        /// <summary>
        /// Zeigt ein Datei-Öffnen Dialogfenster, erlaubt die Auswahl einer
        /// Bilddatei und weist das ausgewählte Bild der Property ImagePath zu.
        /// </summary>
        public void ChooseFile()
        {
            var dlg = new OpenFileDialog();
            // nur Bilder auswählen lassen
            dlg.Filter = "Image Files | *.jpg; *.jpeg; *.png; *.gif;";
            // Pfad des .exe verwenden:
            dlg.InitialDirectory = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            if (dlg.ShowDialog() == true)
            {
                if (string.IsNullOrEmpty(dlg.FileName))
                    return;

                ImagePath = dlg.FileName;
            }
        }

        private void ShowError(string msg)
        {
            MessageBox.Show(msg, "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
