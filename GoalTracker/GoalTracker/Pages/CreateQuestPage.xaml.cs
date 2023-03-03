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
    public partial class CreateQuestPage : Page
    {
        private MainWindow Form = Application.Current.Windows[0] as MainWindow;
        private string typeOfQuest;
        public CreateQuestPage(string type)
        {
            InitializeComponent();
            typeOfQuest = type;
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(QuestTitle.Text))
            {
                Quests quest;
                switch (typeOfQuest)
                {
                    case "Daily":
                        quest = new DailyQuests(QuestTitle.Text, QuestDesc.Text, typeOfQuest);
                        break;
                    case "Event":
                        quest = new EventQuests(QuestTitle.Text, QuestDesc.Text, typeOfQuest);
                        break;
                    default:
                        quest = new SpecialQuests(QuestTitle.Text, QuestDesc.Text, typeOfQuest);
                        break;
                }

                QuestLists.quests.Add(quest);
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
            Form.CurrentPage.NavigationService.Navigate(new QuestPage(typeOfQuest));
        }
    }
}
