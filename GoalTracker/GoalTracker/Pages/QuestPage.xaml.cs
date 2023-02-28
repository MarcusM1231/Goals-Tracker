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
    /// Interaction logic for QuestPage.xaml
    /// </summary>
    public partial class QuestPage : Page
    {
        private string currentPage;
        private MainWindow Form = Application.Current.Windows[0] as MainWindow;
        public QuestPage(string page)
        {
            InitializeComponent();
            currentPage = page;
            PageName.Content = currentPage;

            PageContent();
        }

        private void PageContent()
        {
            foreach (Quests quest in QuestLists.quests)
            {
                if (quest.questType == currentPage)
                {
                    Button button = new Button()
                    {
                        Content = quest.questName,
                        Tag = quest
                    };

                    button.Click += new RoutedEventHandler(QuestClicked);
                    sp.Children.Add(button);
                }
            }
        }

        private void QuestClicked(object sender, RoutedEventArgs e)
        {

            QuestDetailWindow detailWindow = new QuestDetailWindow((Quests)(sender as Button).Tag);
            detailWindow.ShowDialog();
        }

        private void AddQuest_Click(object sender, RoutedEventArgs e)
        {
            Form.CurrentPage.NavigationService.Navigate(new CreateQuestPage(currentPage));
        }
    }
}
