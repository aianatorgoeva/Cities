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
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private string _inputedText;
        private Window _sourceWindow;
        public LoginWindow(Window sourceWindow)
        {
            InitializeComponent();
            _sourceWindow = sourceWindow;
            NickNameBox.TextChanged += LoginBox_Changed;
            NickNameBox.MouseLeftButtonDown += LoginBox_FirstClick;
            StartGameButton.Click += StartButton_Click;
            Closed += LoginWindow_Closed;
            _inputedText = NickNameBox.Text;
        }
    }
}
