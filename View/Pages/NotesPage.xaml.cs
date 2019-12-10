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
using Model;
using ViewModel;
using DataServices;
using View.Widgets;

namespace View.Pages
{
    /// <summary>
    /// Interaction logic for NotesPage.xaml
    /// </summary>
    public partial class NotesPage : Page
    {
        private SortedBy sorted = SortedBy.Created;

        private NotesPageVM logic;
        public NotesPage()
        {
            this.logic = new NotesPageVM(new SQLiteDataService(), "RomanLevkovych");
            logic.GetNotes();
            InitializeComponent();
            navbar.button_Profile.Click += Navbar_Button_Profile_Click;
            navbar.button_FAQ.Click += Navbar_Button_FAQ_Click;
            navbar.button_Notes.Click += Navbar_Button_Notes_Click;
            navbar.button_TimeTable.Click += Navbar_Button_TimeTable_Click;
            navbar.button_Notes.Style = Application.Current.Resources["MenuButtonActive"] as Style;
            content.button_delete.Click += Content_Button_delete_Click;
            content.button_add.MouseDown += Content_Button_add_MouseDown;
            content.button_sortCreated.Click += Content_Button_sortCreated_Click;
            content.button_sortDeadline.Click += Content_Button_sortDeadline_Click;
            content.button_sortSubject.Click += Content_Button_sortCreated_Click;
            content.button_sortName.Click += Content_Button_sortDeadline_Click;
            SortNotes(sorted);
            searchBar.textSearch.KeyDown += SearchBar_TextSearch_Search_On_KeyDown;
        }

        /// <summary>
        /// Method for executing search in searchBar
        /// </summary>
        private void SearchBar_TextSearch_Search_On_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && !String.IsNullOrWhiteSpace(searchBar.textSearch.Text))
            {
                App.LastSearch = searchBar.textSearch.Text;
                this.NavigationService.Navigate(new Uri("Pages/SearchPage.xaml", UriKind.Relative));
            }
        }
        /// <summary>
        /// Method for sorting notes by Deadline
        /// </summary>
        private void Content_Button_sortDeadline_Click(object sender, RoutedEventArgs e)
        {
            if (sorted == SortedBy.Deadline)
            {
                SortNotes(SortedBy.DeadlineReverse);
                sorted = SortedBy.DeadlineReverse;
            }
            else
            {
                SortNotes(SortedBy.Deadline);
                sorted = SortedBy.Deadline;
            }
        }

        /// <summary>
        /// Method for sorting notes by Creation date
        /// </summary>
        private void Content_Button_sortCreated_Click(object sender, RoutedEventArgs e)
        {
            if(sorted == SortedBy.Created)
            {
                SortNotes(SortedBy.CreatedReverse);
                sorted = SortedBy.CreatedReverse;
            }
            else
            {
                SortNotes(SortedBy.Created);
                sorted = SortedBy.Created;
            }
        }

        /// <summary>
        /// Method for sorting notes by Subject
        /// </summary>
        private void Content_Button_sortSubject_Click(object sender, RoutedEventArgs e)
        {
            if (sorted == SortedBy.Subject)
            {
                SortNotes(SortedBy.SubjectReverse);
                sorted = SortedBy.SubjectReverse;
            }
            else
            {
                SortNotes(SortedBy.Subject);
                sorted = SortedBy.Subject;
            }
        }

        /// <summary>
        /// Method for sorting notes by Title
        /// </summary>
        private void Content_Button_sortTitle_Click(object sender, RoutedEventArgs e)
        {
            if (sorted == SortedBy.Title)
            {
                SortNotes(SortedBy.TitleReverse);
                sorted = SortedBy.TitleReverse;
            }
            else
            {
                SortNotes(SortedBy.Title);
                sorted = SortedBy.Title;
            }
        }

        private void Content_Button_add_MouseDown(object sender, MouseButtonEventArgs e)
        {
            new NotesPageNoteWindow(this).ShowDialog();
        }


        /// <summary>
        /// Method for delation all checked notes
        /// </summary>
        private void Content_Button_delete_Click(object sender, RoutedEventArgs e)
        { 
            foreach(NotesPageNoteBlock i in content.stack.Children)
            {
                if ((bool)i.check.IsChecked)
                {
                    logic.DeleteNote(i.textName.Text);
                }
            }
            content.check.IsChecked = false;
            fillNotes();
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
        /// Method for filling notes
        /// </summary>
        /// <remarks>
        /// Notes are preserved in stack
        /// </remarks>
        private void fillNotes()
        {
            this.content.stack.Children.Clear();
            int cnt = 0;
            foreach (var note in logic.GetNotes())
            {
                NotesPageNoteBlock temp = new NotesPageNoteBlock(note);
                temp.MouseDown += NotesPageBlock_MouseDown;
                if (cnt++ % 2 == 1)
                {
                    temp.grid.Background = new SolidColorBrush(Colors.LightGray);
                }
                this.content.stack.Children.Add(temp);
            }
        }

        private void NotesPageBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            new NotesPageNoteWindow(this,(sender as NotesPageNoteBlock).note).ShowDialog();
        }

        /// <summary>
        /// Method for getting subjects
        /// </summary>
        public List<String> GetSubjects()
        {
            return logic.GetSubjects();
        }


        /// <summary>
        /// Method for adding notes
        /// </summary>
        public void AddNoteFromString(string name, string deadline, string subject, string materials)
        {
            logic.AddNote(name, deadline, subject, materials);
            fillNotes();
        }


        /// <summary>
        /// Method for changing notes info
        /// </summary>
        public void ChangeNote(Note note,Note newNote)
        {
            logic.UpdateNote(note,newNote);
            fillNotes();
        }


        /// <summary>
        /// Method for executing notes sortition
        /// </summary>
        public void SortNotes(SortedBy by)
        {
            logic.sort(by);
            fillNotes();
        }
    }
}
