using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Cities
{
    /// <summary>
    /// https://metanit.com/sharp/wpf/22.2.php
    /// </summary>
    public class GameViewModel : INotifyPropertyChanged
    {
        private string currentCity;
        public string CurrentCity 
        {
            get => currentCity;
            set
            {
                currentCity = value;
                OnPropertyChanged("CurrentCity");
            }
        }
        private string currentLastChar;
        public string CurrentLastChar
        {
            get => currentLastChar;
            set
            {
                currentLastChar = value;
                OnPropertyChanged("CurrentLastChar");
            }
        }
        //IM INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
