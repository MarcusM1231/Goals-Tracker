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
    /// Interaction logic for CreateQuestPage.xaml
    /// </summary>
    public partial class CreateGoalPage : Page
    {
        private MainWindow Form = Application.Current.Windows[0] as MainWindow;
        private string typeOfGoal;
        public CreateGoalPage(string type)
        {
            InitializeComponent();
            typeOfGoal = type;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(QuestTitle.Text))
            {
                Goals goal;
                switch (typeOfGoal)
                {
                    case "Daily":
                        goal = new DailyGoals(QuestTitle.Text, QuestDesc.Text, typeOfGoal);
                        GoalLists.dailyGoals.Add(goal);
                        break;
                    case "Weekly":
                        goal = new WeeklyGoals(QuestTitle.Text, QuestDesc.Text, typeOfGoal);
                        GoalLists.weeklyGoals.Add(goal);
                        break;
                    default:
                        goal = new LongtermGoals(QuestTitle.Text, QuestDesc.Text, typeOfGoal);
                        break;
                }

                GoalLists.activeGoals.Add(goal);
                NavigatePage();
            }
            else
            {
                MessageBox.Show("Please Enter a Quest Title");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigatePage();
        }

        //Navigates back to the orginal quest Page
        private void NavigatePage()
        {
            Form.CurrentPage.NavigationService.Navigate(new GoalPage(typeOfGoal));
        }
    }
}
