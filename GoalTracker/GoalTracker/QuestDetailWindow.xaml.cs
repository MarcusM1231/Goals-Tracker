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
    public partial class QuestDetailWindow : Window
    {
        MainWindow Form = Application.Current.Windows[0] as MainWindow;
        Goals thisQuest;
        public QuestDetailWindow(Goals quest)
        {
            InitializeComponent();

            thisQuest = quest;
            QuestTitle.Content = quest.goalName;
            QuestDesc.Text = quest.goalDesc;
        }


        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Form.CurrentPage.NavigationService.Navigate(new QuestPage(thisQuest.goalType));
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            switch (thisQuest.goalType)
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
            Form.CurrentPage.NavigationService.Navigate(new QuestPage(thisQuest.goalType));
        }
    }
}
