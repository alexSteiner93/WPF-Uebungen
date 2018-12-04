using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace DragAndDropWithAdorner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public ObservableCollection<UserInfo> AvailableUsers { get; set; }
        public ObservableCollection<UserInfo> SelectedUsers { get; set; }

        public DragDropHelper DragDropManager { get; set; }

        public MainWindow()
        {
            // userliste mit Beispieldaten abfüllen
            InitUsers();

            InitializeComponent();

            DataContext = this;

            DragDropManager = new DragDropHelper(this, AvailableListBox, SelectedListBox);
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
        

        private bool IsMovementFarEnough(Point origPos, Point curPos)
        {
            var minDistX = SystemParameters.MinimumHorizontalDragDistance;
            var minDistY = SystemParameters.MinimumHorizontalDragDistance;

            return (Math.Abs(curPos.X - origPos.X) >= minDistX
                || Math.Abs(curPos.Y - origPos.Y) >= minDistY);
        }
        

    }
}
