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
            content.button_sortTitle.Click += Content_Button_sortDeadline_Click;
            SortNotes(sorted);
        }

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

        private void Content_Button_delete_Click(object sender, RoutedEventArgs e)
        { 
            foreach(NotesPageNoteBlock i in content.stack.Children)
            {
                if ((bool)i.check.IsChecked)
                {
                    logic.DeleteNote(i.textTitle.Text);
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

        public List<String> GetSubjects()
        {
            return logic.GetSubjects();
        }
        public void AddNote(string title, string date, string subject, string text)
        {
            logic.AddNote(title, date, subject, text);
            fillNotes();
        }
        public void ChangeNote(Note note)
        {
            logic.UpdateNote(note);
            fillNotes();
        }
        public void SortNotes(SortedBy by)
        {
            logic.sort(by);
            fillNotes();
        }
    }
}
