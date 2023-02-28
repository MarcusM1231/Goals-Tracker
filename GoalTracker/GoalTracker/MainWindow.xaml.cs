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
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            NavigatePage("/Pages/HomePage.xaml");

        }

        private void DailyButton_Click(object sender, RoutedEventArgs e)
        {
            //NavigatePage("/Pages/DailyPage.xaml");
            CurrentPage.NavigationService.Navigate(new QuestPage("Daily"));
        }

        private void EventButton_Click(object sender, RoutedEventArgs e)
        {
            // NavigatePage("/Pages/EventPage.xaml");
            CurrentPage.NavigationService.Navigate(new QuestPage("Event"));
        }

        private void SpecialButton_Click(object sender, RoutedEventArgs e)
        {
            //NavigatePage("/Pages/SpecialPage.xaml");
            CurrentPage.NavigationService.Navigate(new QuestPage("Special"));

        }

        private void NavigatePage(string page)
        {
            CurrentPage.Navigate(new Uri(page, UriKind.Relative));
        }
    }
}
