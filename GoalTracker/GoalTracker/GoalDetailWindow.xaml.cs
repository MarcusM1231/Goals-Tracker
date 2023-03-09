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
        Goals thisQuest;
        public GoalDetailWindow(Goals quest)
        {
            InitializeComponent();

            thisQuest = quest;
            QuestTitle.Content = quest.GetGoalName();
            QuestDesc.Text = quest.GetGoalDesc();
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Form.CurrentPage.NavigationService.Navigate(new GoalPage(thisQuest.GetGoalType()));
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            switch (thisQuest.GetGoalType())
            {
                case "Daily":
                    GoalLists.activeGoals.Remove(thisQuest);
                    GoalLists.dailyGoals.Remove(thisQuest);
                    break;
                case "Event":
                    GoalLists.activeGoals.Remove(thisQuest);
                    GoalLists.weeklyGoals.Remove(thisQuest);
                    break;
                default:
                    GoalLists.activeGoals.Remove(thisQuest);
                    break;

            }


            this.Close();
            Form.CurrentPage.NavigationService.Navigate(new GoalPage(thisQuest.GetGoalType()));
        }
    }
}
