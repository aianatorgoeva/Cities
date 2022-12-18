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
using Cities.DAL;
using Cities.DomainModel;

namespace Cities
{
    /// <summary>
    /// Interaction logic for LeaderBoard.xaml
    /// </summary>
    public class LeaderBoardItem
    {
        public int Rank { get; set; }
        public User User { get; set; }
    }
    public partial class LeaderBoard : Window
    {
        private List<LeaderBoardItem> leaders = new List<LeaderBoardItem>();
        public LeaderBoard()
        {
            var rep = new GameRepository();
            var lbList = rep.GetLeaderBord(10).ToList();
            for (int i = 1; i <= lbList.Count; i++)
            {
                leaders.Add(new LeaderBoardItem() {Rank = i, User = lbList[i - 1]});
            }
            InitializeComponent();
            Leaders.ItemsSource = leaders;
        }
        
    }
}
