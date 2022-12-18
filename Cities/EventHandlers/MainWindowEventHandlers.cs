using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Cities
{
    public partial class MainWindow : Window
    {
        public void StartButton_Click(object sender, RoutedEventArgs e)
        {
            var loginwindow = new LoginWindow(this);
            IsEnabled = false;
            loginwindow.ShowDialog();
        }

        public void LeaderBoardButton_Click(object sender, RoutedEventArgs e)
        {
            var leaderboardwindow = new LeaderBoard();
            this.Hide();
            leaderboardwindow.Show();
            this.Show();
        }
        public void ExitButton_Click(object sender, RoutedEventArgs e) => Close_App();
        private void Close_App() => Application.Current.Shutdown();
    }
}
