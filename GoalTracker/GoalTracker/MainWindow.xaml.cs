using GoalTracker.Data;
using GoalTracker.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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



namespace GoalTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DailyTimer timer = new DailyTimer();
            LoadList();
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigatePage("/Pages/HomePage.xaml");

        }

        private void DailyButton_Click(object sender, RoutedEventArgs e)
        {
            //NavigatePage("/Pages/DailyPage.xaml");
            CurrentPage.NavigationService.Navigate(new GoalPage("Daily"));
        }

        private void EventButton_Click(object sender, RoutedEventArgs e)
        {
            // NavigatePage("/Pages/EventPage.xaml");
            CurrentPage.NavigationService.Navigate(new GoalPage("Weekly"));
        }

        private void LongtermButton_Click_1(object sender, RoutedEventArgs e)
        {
            //NavigatePage("/Pages/SpecialPage.xaml");
            CurrentPage.NavigationService.Navigate(new GoalPage("Long-term"));
        }

        private void NavigatePage(string page)
        {
            CurrentPage.Navigate(new Uri(page, UriKind.Relative));
        }

        ////Saving and loading 

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Save the list when the window is closing
            SaveList();
        }

        private void SaveList()
        {
            var myListsDict = new Dictionary<string, object>()
            {
                { "ActiveGoals", GoalLists.activeGoals },
                { "CompletedGoals", GoalLists.completedGoals },
                { "DailyGoals", GoalLists.dailyGoals },
                { "WeeklyGoals", GoalLists.weeklyGoals }
            };
            string json = JsonConvert.SerializeObject(myListsDict, Formatting.Indented);
            File.WriteAllText("SavedGoals.json", json);
        }

        private void LoadList()
        {
            if (File.Exists("SavedGoals.json"))
            {
                string json = File.ReadAllText("SavedGoals.json");
                var myListsDict = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);

                GoalLists.activeGoals = JsonConvert.DeserializeObject<List<Goals>>(myListsDict["ActiveGoals"].ToString());
                GoalLists.completedGoals = JsonConvert.DeserializeObject<List<Goals>>(myListsDict["CompletedGoals"].ToString());
                GoalLists.dailyGoals = JsonConvert.DeserializeObject<List<Goals>>(myListsDict["DailyGoals"].ToString());
                GoalLists.weeklyGoals = JsonConvert.DeserializeObject<List<Goals>>(myListsDict["WeeklyGoals"].ToString());
            }
        }
    }
}
