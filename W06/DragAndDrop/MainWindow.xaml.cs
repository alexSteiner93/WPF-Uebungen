using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace DragAndDrop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<UserInfo> AvailableUsers { get; set; }
        public ObservableCollection<UserInfo> SelectedUsers { get; set; }

        public MainWindow()
        {
            // userliste mit Beispieldaten abfüllen
            InitUsers();

            InitializeComponent();

            DataContext = this;
        }

        private void InitUsers()
        {
            SelectedUsers = new ObservableCollection<UserInfo>();
            AvailableUsers = new ObservableCollection<UserInfo>();

            // C# goodies:
            // - anonymous objects (hier ein Array von Strings)
            // - Linq (hier ein ForEach über die Liste)
            new [] { "Dilbert", "Dogbert", "Boss" }
                .ToList()
                .ForEach(x => AvailableUsers.Add(new UserInfo()
                {
                    NickName = x,
                    Image = $"media/{x.ToLower()}.png"
                }));
        }

    }
}
