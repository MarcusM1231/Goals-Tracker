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
    public partial class GoalPage : Page
    {
        private string currentPage;
        private MainWindow Form = Application.Current.Windows[0] as MainWindow;
        
        public GoalPage(string page)
        {
            InitializeComponent();

            currentPage = page;
            PageName.Content = currentPage;

            ButtonContent();
        }

        //Diaplys the Quest buttons on the screen on the correct page 
        private void ButtonContent()
        {
            
            foreach (Goals quest in GoalLists.activeGoals)
            {
                if (quest.GetGoalType() == currentPage)
                {
                    Button button = new Button()
                    {
                        Content = quest.GetGoalName(),
                        Tag = quest,
                        Width = 200,
                        Background = Brushes.Teal
                    };

                    Button submitButton = new Button()
                    {
                        Content = "✅",
                        Tag = quest,
                        Width = 50 ,
                        Background = Brushes.Teal                                              
                    };

                    Button deleteButton = new Button()
                    {
                        Content = "🗑",
                        Tag = quest,
                        Width = 50,
                        Background = Brushes.Teal
                    };

                   
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
            GoalDetailWindow detailWindow = new GoalDetailWindow((Goals)(sender as Button).Tag);
            detailWindow.ShowDialog();
        }

        // Completes the quest and removes it from your list of quests
        private void CompleteButtonClicked(object sender, RoutedEventArgs e)
        {
            var result = ConfirmationBox("Do you want to submit this quest?");

            if (result == MessageBoxResult.Yes)
            {
                // User clicked Yes
                GoalLists.completedGoals.Add((Goals)(sender as Button).Tag);
                GoalLists.activeGoals.Remove((Goals)(sender as Button).Tag);
                Form.CurrentPage.NavigationService.Navigate(new GoalPage(currentPage));
            }            
        }

        //Deletes the quest and removes it from the list of quests
        private void DeleteButtonCLicked(object sender, RoutedEventArgs e)
        {
            var result = ConfirmationBox("Do you want to remove this quest ?");

            if (result == MessageBoxResult.Yes)
            {
                // User clicked Yes
                GoalLists.activeGoals.Remove((Goals)(sender as Button).Tag);
                Form.CurrentPage.NavigationService.Navigate(new GoalPage(currentPage));
            }
        }

        //Takes you to a new page where you create a new quest
        private void AddQuest_Click(object sender, RoutedEventArgs e)
        {
            Form.CurrentPage.NavigationService.Navigate(new CreateGoalPage(currentPage));
        }

        public MessageBoxResult ConfirmationBox(string promt)
        {
            var result = MessageBox.Show(promt, "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);

            return result;
        }
    }
}
