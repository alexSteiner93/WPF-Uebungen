using System;
using System.Windows;

namespace NumbersOnly
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly Random Randomizer = new Random();

        public int SecretNumber { get; set; }
        public int NumberOfTries { get; set; }
        public int Record { get; set; }
        public string RecordAsString => NumberOfTries == 0 ? "-" : $"{Record} guess(es)";


        public MainWindow()
        {
            ThinkOfANumber();

            InitializeComponent();
        }

        private void ThinkOfANumber()
        {
            NumberOfTries = 0;
            SecretNumber = Randomizer.Next(0, 100);
        }

        private bool Check(int guess)
        {
            var delta = Math.Abs(guess - SecretNumber);
            if (delta >= 50)
            {
                MessageBox.Show("Miles away! Try again!");
                return false;
            }

            if (delta >= 20)
            {
                MessageBox.Show("Getting closer! Try again!");
                return false;
            }

            if (delta >= 10)
            {
                MessageBox.Show("Almost there! Try again!");
                return false;
            }

            if (delta >= 2)
            {
                MessageBox.Show("Only a little bit left! Try again!");
                return false;
            }

            if (delta == 1)
            {
                MessageBox.Show("Just missed! Try again!");
                return false;
            }

            // delta should be 0, now
            if (delta == 0)
            {
                MessageBox.Show($"You made it, hooorayyy! Number of tries to correctly guess the number: {NumberOfTries}");
                return true;
            }

            MessageBox.Show("You should get your things straight (You should not have gotten, here)! Try again!");
            return false;
        }

        private void CheckButton_Click(object sender, RoutedEventArgs e)
        {
            NumberOfTries++;

            var guess = int.Parse(NrInput.Text);
            if (Check(guess))
            {
                Win();
                return;
            }
        }

        private void Win()
        {
            if (Record == 0 || NumberOfTries < Record)
            {
                Record = NumberOfTries;
                // update ui - no binding :-(
                RecordText.Text = RecordAsString;
            }

            // you made it, restart the game
            MessageBox.Show("Restarting the game, now.");
            ThinkOfANumber();
        }
    }
}
