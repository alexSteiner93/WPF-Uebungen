using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Input;
using AsciiArtGenerator.Commands;

namespace AsciiArtGenerator.ViewModels
{
    public class AsciiGeneratorViewModel:BindableBase
    {
        // Kommando, das ein ASCII Art erzeugt
        public RelayCommand CalcCommand { get; set; }

        // Kommando, das den Datei-Öffnen Dialog anzeigt
        public RelayCommand ChooseFileCommand { get; set; }

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
            set
            {
                SetProperty(ref _canCreate, value, nameof(CanCreate));

                // nicht vergessen, das UI über Änderungen von
                // CanExecute des CalcCommands zu informieren!
                // -> Achtung: CalcCommand kann beim Laden noch null sein!
                CalcCommand?.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// kann von aussen gesetzt werden, um die Logik für das
        /// Abfragen eines Dateipfads abzufragen
        /// </summary>
        public Func<string> OnChooseFile { get; set; }

        /// <summary>
        /// kann von aussen gesetzt werden, um die Logik für die
        /// Anzeige eines Fehlers zu implementieren
        /// </summary>
        public Action<string> OnShowError { get; set; }

        public AsciiGeneratorViewModel()
        {
            CanCreate = true;
            LineWidth = 80;
            FontSize = 12;

            CalcCommand = new RelayCommand(CreateAsciiArt, () => CanCreate);
            ChooseFileCommand = new RelayCommand(ChooseFile);
        }

        public event EventHandler AsciiArtCreated;

        public void CreateAsciiArtInBgThread()
        {
            // your turn...

            Task.Run(() =>
            {
                CreateAsciiArt(); 

                AsciiArtCreated?.Invoke(this, new EventArgs());
            });
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
        /// Datei auswählen und den Pfad der ausgewählten Datei
        /// in der Property ImagePath speichern (wirft hier in
        /// der Basisklasse eine Exception, falls entsprechende
        /// Action nicht gesetzt ist. Im Plattform-Projekt
        /// [z.B. WPF] kann man die Action von aussen setzen
        /// und z.B. einen OpenFileDialog anzeigen)
        ///
        /// Die Änderung von ImagePath wird dann via PropertyChanged
        /// Event an alle interessierten Parteien weitergegeben.
        /// </summary>
        private void ChooseFile()
        {
            if (OnChooseFile == null)
                throw new NotImplementedException();

            var filename = OnChooseFile();
            if (!string.IsNullOrEmpty(filename))
            {
                ImagePath = filename;
            }
        }

        /// <summary>
        /// Fehler anzeigen (wirft hier in der Basisklasse eine
        /// Exception, falls entsprechende Action nicht gesetzt
        /// ist. Im Plattform-Projekt [z.B. WPF] kann man
        /// die Action von aussen setzen und z.B. eine
        /// MessageBox anzeigen)
        /// </summary>
        /// <param name="msg">Die Fehlermeldung</param>
        private void ShowError(string msg)
        {
            if (OnShowError == null)
                throw new NotImplementedException();

            OnShowError(msg);
        }
    }
}
