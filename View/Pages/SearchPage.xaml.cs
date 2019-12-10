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
using ViewModel;
using View.Widgets;
using DataServices;
using Model;

namespace View.Pages
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        SearchPageVM logic;
        public SearchPage()
        {
            logic = new SearchPageVM(new SQLiteDataService());
            InitializeComponent();
            searchBar.textSearch.KeyDown += SearchBar_TextSearch_KeyDown;
            fillSearch();
            navbar.button_Profile.Click += Navbar_Button_Profile_Click;
            navbar.button_FAQ.Click += Navbar_Button_FAQ_Click;
            navbar.button_Notes.Click += Navbar_Button_Notes_Click;
            navbar.button_TimeTable.Click += Navbar_Button_TimeTable_Click;
        }

        private void Navbar_Button_TimeTable_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/TimeTablePage.xaml", UriKind.Relative));
        }

        private void Navbar_Button_Notes_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/NotesPage.xaml", UriKind.Relative));
        }

        private void Navbar_Button_FAQ_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/FaqPageLoged.xaml", UriKind.Relative));
        }

        private void Navbar_Button_Profile_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/ProfilePage.xaml", UriKind.Relative));
        }

        /// <summary>
        /// Method for executing search in searchBar
        /// </summary>
        private void SearchBar_TextSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !String.IsNullOrWhiteSpace(searchBar.textSearch.Text))
            {
                App.LastSearch = searchBar.textSearch.Text;
                fillSearch();
            }
        }

        /// <summary>
        /// Method for getting search results
        /// </summary>
        private void fillSearch()
        {
            content.stack.Children.Clear();
            if(App.LastSearch != null)
            {
                List<Person> searchResult = logic.Search(App.LastSearch);
                searchBar.textSearch.Text = App.LastSearch;
                int cnt = 0;
                if (searchResult.Count == 0)
                {
                    content.stack.Children.Add(new SearchPageBlock(logic,null));
                }
                searchResult.ForEach(person =>
                {
                    var block = new SearchPageBlock(logic,person);
                    block.MouseDown += SearchPageBlock_MouseDown;
                    if (cnt++ % 2 == 1)
                    {
                        block.Background = new SolidColorBrush(Colors.LightGray);
                    }
                    content.stack.Children.Add(block);
                });
            }
        }

        private void SearchPageBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            App.userToDisplay = (sender as SearchPageBlock).Person.Username;
            this.NavigationService.Navigate(new Uri("Pages/ProfilePage.xaml", UriKind.Relative));
        }
    }
}
