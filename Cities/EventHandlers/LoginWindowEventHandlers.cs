using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cities
{
    public partial class LoginWindow : Window
    {
        private bool _firstClicked;
        private bool _showSourceWindow = true;
        public void LoginBox_Changed(object sender, RoutedEventArgs e)
        {
            TextBox box = (TextBox)sender;
            _inputedText = box.Text;
        }
        public void StartButton_Click(object sender, RoutedEventArgs e)
        {
            _showSourceWindow = false;
            var game = new GameWindow(_inputedText, this);
            game.Show();
            this.Close();
            _sourceWindow.Close();
        }
        public void LoginBox_FirstClick(object sender, RoutedEventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (!_firstClicked)
            {
                box.Text = "";
                _firstClicked = true;
            }
        }
        public void LoginWindow_Closed(object sender, EventArgs e)
        {
            if (_showSourceWindow)
            {
                _sourceWindow.Show();
                _sourceWindow.IsEnabled = true;
            }
        }
    }
}
