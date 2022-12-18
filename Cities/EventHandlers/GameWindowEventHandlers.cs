using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Cities
{
    partial class GameWindow : Window
    {
        public void SurrenderButton_Click(object sender, RoutedEventArgs e)
        {
            if (user.Record < _currentScore)
            {
                user.Record = _currentScore;
                repository.UpdateUser(user);
                repository.Save();
            }
            var newwindow = new MainWindow();
            MessageBox.Show($"You lose\nCurrent score: {_currentScore}", "Info");
            newwindow.Show();
            this.Close();
        }

        public void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            var input = _inputedCity.ToLower();
            try
            {
                var cities = currentSessionCities[input[0]];
                try
                {
                    if (cities[_inputedCity])
                    {
                        MessageBox.Show("This city has already been used", "Error");
                        return;
                    }
                    cities[_inputedCity] = true;
                    _currentScore++;
                    var lastchar = input[^1];
                    try
                    {
                        foreach (var city in currentSessionCities[lastchar])
                        {
                            if (!city.Value && lastchar==city.Key.ToLower()[0])
                            {
                                currentSessionCities[lastchar][city.Key] = true;
                                var vm = (GameViewModel) DataContext;
                                vm.CurrentCity = city.Key;
                                vm.CurrentLastChar = GetLastCharString(city.Key[^1]);
                                CitySetBox.Text = "";
                                return;
                            }
                        }
                    }
                    catch (KeyNotFoundException)
                    {
                        MessageBox.Show("There are no cities in the database ending with this symbol!", "Error");
                    }
                }
                catch (KeyNotFoundException)
                {
                    MessageBox.Show("This city does not exist in the game database!", "Error");
                }
            }
            catch(KeyNotFoundException)
            {
                MessageBox.Show("There are no cities in the database starting with this symbol!", "Error");
            }
        }

        public void CitySetBox_TextChanged(object sender, RoutedEventArgs e)
        {
            var textbox = (TextBox) sender;
            _inputedCity = textbox.Text;
        }
    }
}
