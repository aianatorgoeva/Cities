using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Cities.DAL;
using Cities.DomainModel;

namespace Cities { 
    public class LeaderBoardViewModel : INotifyPropertyChanged
    {
        private List<User> leaders;
        public List<User> Leaders
        {
            get => leaders;
            set
            {
                leaders = value;
                OnPropertyChanged("Leaders");
            }
        }

        // INotifyPropertyChanged interface methods
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public LeaderBoardViewModel(GameRepository repository)
        {
            Leaders = repository.GetLeaderBord(10).ToList();
        }
    }
}
