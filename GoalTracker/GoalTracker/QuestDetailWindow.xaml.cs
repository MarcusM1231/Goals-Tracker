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
        Quests thisQuest;
        public QuestDetailWindow(Quests quest)
        {
            InitializeComponent();

            thisQuest = quest;
            QuestTitle.Content = quest.questName;
            QuestDesc.Content = quest.questDesc;
        }

        private void RemoveQuestButton_Click(object sender, RoutedEventArgs e)
        {
            QuestLists.quests.Remove(thisQuest);
            //Form.CurrentPage.Refresh();
            this.Close();
            Form.CurrentPage.NavigationService.Navigate(new QuestPage(thisQuest.questType));
        }
    }
}
