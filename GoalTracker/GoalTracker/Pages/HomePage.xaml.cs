using GoalTracker.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoalTracker.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public static int getTotalPoints = 0;
        
        public HomePage()
        {
            InitializeComponent();

            totalPoints.Content = TotalPoints();
            totalCompleted.Content = QuestLists.completedQuests.Count;

            
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            EditButton.Visibility = Visibility.Hidden;
            DoneButton.Visibility = Visibility.Visible;
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            DoneButton.Visibility = Visibility.Hidden;
            EditButton.Visibility = Visibility.Visible;

        }

        public int TotalPoints()
        {

            foreach(Quests val in QuestLists.completedQuests)
            {
                getTotalPoints += val.points;
            }

            return getTotalPoints;
        }

        
    }
}
