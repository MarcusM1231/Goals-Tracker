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


namespace GoalTracker.Pages
{
    /// <summary>
    /// Interaction logic for QuestPage.xaml
    /// </summary>
    public partial class QuestPage : Page
    {
        private string currentPage;
        private MainWindow Form = Application.Current.Windows[0] as MainWindow;
        MessageBoxResult result;


        public QuestPage(string page)
        {
            InitializeComponent();

            currentPage = page;
            PageName.Content = currentPage;

            ButtonContent();
        }

        private void ButtonContent()
        {
            foreach (Quests quest in QuestLists.quests)
            {
                if (quest.questType == currentPage)
                {
                    Button button = new Button()
                    {
                        Content = quest.questName,
                        Tag = quest,
                        Width = 200,
                        Background = Brushes.Teal
                    };

                    Button submitButton = new Button()
                    {
                        Content = "✅",
                        Tag = quest,
                        Width = 50 ,
                        Background = Brushes.Teal,
                        
                        
                    };

                    Button deleteButton = new Button()
                    {
                        Content = "🗑",
                        Tag = quest,
                        Width = 50,
                        Background = Brushes.Teal
                    };

                    Style buttonStyle = new Style(typeof(Button));
                    buttonStyle.Setters.Add(new Setter(Border.CornerRadiusProperty, new CornerRadius(10)));
                    button.Style = buttonStyle;

                    button.Click += new RoutedEventHandler(QuestClicked);
                    submitButton.Click += new RoutedEventHandler(CompleteButtonClicked);
                    deleteButton.Click += new RoutedEventHandler(DeleteButtonCLicked);

                    innerPanel.Children.Add(button);
                    innerPanel.Children.Add(submitButton);
                    innerPanel.Children.Add(deleteButton);  
                    
                }
            }            
        }

        // Opens a new window with the quest detail whenever the quest is clicked
        private void QuestClicked(object sender, RoutedEventArgs e)
        {       
            QuestDetailWindow detailWindow = new QuestDetailWindow((Quests)(sender as Button).Tag);
            detailWindow.ShowDialog();
        }

        // Completes the quest and removes it from your list of quests
        private void CompleteButtonClicked(object sender, RoutedEventArgs e)
        {
            result = MessageBox.Show("Do you want to submit this quest?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // User clicked Yes
                QuestLists.completedQuests.Add((Quests)(sender as Button).Tag);
                QuestLists.quests.Remove((Quests)(sender as Button).Tag);
                Form.CurrentPage.NavigationService.Navigate(new QuestPage(currentPage));
            }            
        }

        //Deletes the quest and removes it from the list of quests
        private void DeleteButtonCLicked(object sender, RoutedEventArgs e)
        {
            result = MessageBox.Show("Do you want to remove this quest?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                // User clicked Yes
                QuestLists.quests.Remove((Quests)(sender as Button).Tag);
                Form.CurrentPage.NavigationService.Navigate(new QuestPage(currentPage));
            }
        }

        //Takes you to a new page where you create a new quest
        private void AddQuest_Click(object sender, RoutedEventArgs e)
        {
            Form.CurrentPage.NavigationService.Navigate(new CreateQuestPage(currentPage));
        }
    }
}
