using Cities.DAL;
using Cities.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    public partial class GameWindow : Window
    {
        private GameRepository repository;

        private Dictionary<char, Dictionary<string, bool>> currentSessionCities =
            new Dictionary<char, Dictionary<string, bool>>();
        private User user;
        private string _inputedCity;
        private int _currentScore;
        public GameWindow(string username, Window sourceWindow)
        {
            repository = new GameRepository();
            user = GetOrAddUser(username);
            var rnd = new Random();
            var list = repository.GetCitiesList().ToList();
            var currentCity = list[rnd.Next(0, list.Count)].Name;
            FillDictionary(list);
            currentSessionCities[currentCity.ToLower()[0]][currentCity] = true;
            InitializeComponent();
            DataContext = new GameViewModel()
            {
                CurrentCity = currentCity, CurrentLastChar = GetLastCharString(currentCity.ToUpper()[^1])
            };
            SurrenderButton.Click += SurrenderButton_Click;
            Submit.Click += SubmitButton_Click;
            CitySetBox.TextChanged += CitySetBox_TextChanged;
        }
        private User GetOrAddUser(string username)
        {
            var user = repository.GetUser(username);
            if (user != null) return user;
            user = new User() { Name = username };
            repository.CreateUser(user);
            repository.Save();
            return user;
        }
    
        private void FillDictionary(IEnumerable<City> list)
        {
            foreach (var city in list)
            {
                var cityfirstchar = city.Name.ToLower()[0];
                if (!currentSessionCities.ContainsKey(cityfirstchar))
                    currentSessionCities.Add(cityfirstchar, new Dictionary<string, bool>());
                currentSessionCities[cityfirstchar].Add(city.Name, false);
            }
        }
        // viewmodel helper function
        private string GetLastCharString(char ch)
        {
            return $"Your city must start with the letter: {ch.ToString().ToUpper()}";
        }
    }
}
