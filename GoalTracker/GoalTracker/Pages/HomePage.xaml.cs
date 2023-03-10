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
        private MainWindow Form = Application.Current.Windows[0] as MainWindow;

        public int getTotalPoints = 0;
        List<Goals> lastFourGoals;


        public HomePage()
        {
            InitializeComponent();

            totalPoints.Content = DisplayTotalPoints();
            totalCompleted.Content = GoalLists.completedGoals.Count;
            DisplayRecentGoals();
            
        }

        public void DisplayRecentGoals()
        {
            lastFourGoals = GoalLists.completedGoals.Skip(Math.Max(0, GoalLists.completedGoals.Count - 4)).Take(4).ToList();

            for(int i = lastFourGoals.Count - 1; i >= 0; i--)
            {
                Button button = new Button()
                {
                    Content = lastFourGoals[i].GetGoalName(),
                    Tag = lastFourGoals[i],
                    Width = 150,
                    Height = 50,
                    Background = Brushes.Teal
                };

                RecentGoals.Children.Add(button);
            }
        }

        public int DisplayTotalPoints()
        {

            foreach (Goals val in GoalLists.completedGoals)
            {
                getTotalPoints += val.GetGoalPoints();
            }

            return getTotalPoints;
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show($"This will reset your points and remove all completed goals", "Are You Sure", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                GoalLists.completedGoals.Clear();
                lastFourGoals.Clear();
                this.NavigationService.Refresh();
            }
            
        }

        public void UpdateScreen()
        {
            Task.Run(() =>
            {
                App.Current.Dispatcher.Invoke(() =>
                {
                    totalPoints.Content = DisplayTotalPoints();
                    totalCompleted.Content = GoalLists.completedGoals.Count;

                });
            });
        }
        //private void EditButton_Click(object sender, RoutedEventArgs e)
        //{
        //    EditButton.Visibility = Visibility.Hidden;
        //    DoneButton.Visibility = Visibility.Visible;

        //}

        //private void DoneButton_Click(object sender, RoutedEventArgs e)
        //{
        //    DoneButton.Visibility = Visibility.Hidden;
        //    EditButton.Visibility = Visibility.Visible;

        //}  
    }
}
