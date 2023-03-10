using GoalTracker.Data;
using GoalTracker.Pages;
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

namespace GoalTracker
{
    /// <summary>
    /// Interaction logic for QuestDetailWindow.xaml
    /// </summary>
    public partial class GoalDetailWindow : Window
    {
        MainWindow Form = Application.Current.Windows[0] as MainWindow;
        Goals thisGoal;
        public GoalDetailWindow(Goals goal)
        {
            InitializeComponent();

            thisGoal = goal;
            QuestTitle.Content = goal.GetGoalName();
            QuestDesc.Text = goal.GetGoalDesc();
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show($"This will stop your goal from reoccurring.", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                switch (thisGoal.GetGoalType())
                {
                    case "Daily":
                        GoalLists.dailyGoals.Remove(thisGoal);
                        break;
                    case "Event":
                        GoalLists.weeklyGoals.Remove(thisGoal);
                        break;
                    default:
                        break;

                }

                this.Close();
                Form.CurrentPage.NavigationService.Refresh();
            }
        }
    }
}
