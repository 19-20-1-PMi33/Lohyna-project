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
    /// Interaction logic for ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private SortMarkTable sorted;
        private ProfilePageVM logic;
        public ProfilePage()

        {
            this.logic = new ProfilePageVM(new SQLiteDataService(), "OlegAndrus");
            logic.GetRatings();
            InitializeComponent();

            navbar.button_Profile.Click += Navbar_Button_Profile_Click;
            navbar.button_FAQ.Click += Navbar_Button_FAQ_Click;
            navbar.button_Notes.Click += Navbar_Button_Notes_Click;
            navbar.button_TimeTable.Click += Navbar_Button_TimeTable_Click;
            navbar.button_Profile.Style = Application.Current.Resources["MenuButtonActive"] as Style;
            if (logic.GetPerson() != null)
            {
                content.name_surname_textblock.Text = $"{logic.GetPerson().Name} {logic.GetPerson().Surname}";
                //content.profile_photo.Source = new BitmapImage(new Uri(logic.GetPerson().Photo, UriKind.Relative));
                if (logic.GetLecturer() != null)
                {
                    content.label1.Text = "Department:";
                    content.group_department_textblock.Text = $"{logic.GetLecturer().Department}";
                    content.label2.Text = "";
                    content.label3.Text = "";
                    content.course_textblock.Text = "";
                    content.nom_zalik_textblock.Text = "";
                    content.marks.Visibility = Visibility.Hidden;
                }
                else if (logic.GetStudent() != null)
                {
                    content.group_department_textblock.Text = $"{logic.GetStudent().GroupID}";
                    content.course_textblock.Text = $"{logic.GetGroup().Course}";
                    content.nom_zalik_textblock.Text = $"{logic.GetStudent().TicketNumber}";
                    content.marks.HeadRow.subject_column.Click += Content_Marks_HeadRow_Button_sortSubject_Click;
                    content.marks.HeadRow.mark_column.Click += Content_Marks_HeadRow_Button_sortMarks_Click;
                }
            }
            fillMarksTable();
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

        private void fillMarksTable()
        {
            this.content.marks.stack.Children.Clear();
            foreach (Rating row in logic.GetRatings())
            {
                ProfilePageTableMarksRow item = new ProfilePageTableMarksRow(row);
                this.content.marks.stack.Children.Add(item);
            }
        }
        public void SortMarksTableRows(SortMarkTable by)
        {
            logic.sort(by);
            fillMarksTable();
        }
        private void Content_Marks_HeadRow_Button_sortSubject_Click(object sender, RoutedEventArgs e)
        {
            if (sorted == SortMarkTable.Subject)
            {
                SortMarksTableRows(SortMarkTable.SubjectReverse);
                sorted = SortMarkTable.SubjectReverse;
            }
            else
            {
                SortMarksTableRows(SortMarkTable.Subject);
                sorted = SortMarkTable.Subject;
            }
        }

        private void Content_Marks_HeadRow_Button_sortMarks_Click(object sender, RoutedEventArgs e)
        {
            if (sorted == SortMarkTable.Mark)
            {
                SortMarksTableRows(SortMarkTable.MarkReverse);
                sorted = SortMarkTable.MarkReverse;
            }
            else
            {
                SortMarksTableRows(SortMarkTable.Mark);
                sorted = SortMarkTable.Mark;
            }
        }

    }
}
