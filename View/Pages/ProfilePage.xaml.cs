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
        private readonly ProfilePageVM logic;
        private readonly int pageLimit = 4;
        int current_page_number = 0;
        public ProfilePage()

        {
            this.logic = new ProfilePageVM(new SQLiteDataService(), "OlegAndrus");

            InitializeComponent();

            navbar.button_Profile.Click += ProfileTransition;
            navbar.button_FAQ.Click += FAQTransition;
            navbar.button_Notes.Click += NotesTransition;
            navbar.button_TimeTable.Click += TimetableTransition;
            navbar.button_Profile.Style = Application.Current.Resources["MenuButtonActive"] as Style;
            if (logic.GetPerson() != null)
            {
                content.name_surname_textblock.Text = $"{logic.GetPerson().Name} {logic.GetPerson().Surname}";
                if (logic.GetPerson().Photo != null)
                    content.profile_photo.Source = new BitmapImage(new Uri(logic.GetPerson().Photo, UriKind.Relative));
                else
                    content.profile_photo.Source = new BitmapImage(new Uri("Images/profile_placeholder.jpg", UriKind.Relative));
                
                if (logic.GetLecturer() != null)
                {
                    content.group_department_label.Text = "Department:";
                    content.group_department_textblock.Text = $"{logic.GetLecturer().Department}";
                    content.number_zalikovka_label.Visibility = Visibility.Hidden;
                    content.number_zalikovka_textblock.Visibility = Visibility.Hidden;
                    content.course_label.Visibility = Visibility.Hidden;
                    content.course_textblock.Visibility = Visibility.Hidden;
                    content.marks.Visibility = Visibility.Hidden;
                    content.button_next.Visibility = Visibility.Hidden;
                    content.button_prev.Visibility = Visibility.Hidden;
                }
                else if (logic.GetStudent() != null)
                {
                    logic.GetRatings();
                    content.group_department_textblock.Text = $"{logic.GetStudent().GroupID}";
                    content.course_textblock.Text = $"{logic.GetGroup().Course}";
                    content.number_zalikovka_textblock.Text = $"{logic.GetStudent().TicketNumber}";
                    content.marks.HeadRow1.subject_column.Click += sortRatingsBySubjectClick;
                    content.marks.HeadRow1.mark_column.Click += SortRatingsByMarkClick;
                    content.marks.HeadRow2.subject_column.Click += sortRatingsBySubjectClick;
                    content.marks.HeadRow2.mark_column.Click += SortRatingsByMarkClick;
                    content.button_next.MouseDown += PreviousRatingsPageMouseDown;
                    content.button_prev.MouseDown += NextRatingsPageMouseDown;
                    content.page_index_textblock.Text = $"{current_page_number + 1} of {logic.GetPageCount(pageLimit)}";

                    FillMarksTable();
                }
            }
        }

        private void TimetableTransition(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/TimeTablePage.xaml", UriKind.Relative));
        }

        private void NotesTransition(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/NotesPage.xaml", UriKind.Relative));
        }

        private void FAQTransition(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/FaqPageLoged.xaml", UriKind.Relative));
        }

        private void ProfileTransition(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Pages/ProfilePage.xaml", UriKind.Relative));
        }

        private void FillMarksTable()
        {
            this.content.marks.stack1.Children.Clear();
            this.content.marks.stack2.Children.Clear();
            foreach (Rating row in logic.GetCurrentPageRatings(pageLimit, current_page_number))
            {
                ProfilePageTableMarksRow item = new ProfilePageTableMarksRow(row);
                if (content.marks.stack1.Children.Count < Math.Ceiling((double)pageLimit / 2))
                    this.content.marks.stack1.Children.Add(item);
                else
                    this.content.marks.stack2.Children.Add(item);
            }
            if (content.marks.stack2.Children.Count == 0)
                content.marks.HeadRow2.Visibility = Visibility.Hidden;
            else
                content.marks.HeadRow2.Visibility = Visibility.Visible;
        }
        public void SortMarksTableRows(SortMarkTable by)
        {
            logic.Sort(by);
            FillMarksTable();
        }
        private void sortRatingsBySubjectClick(object sender, RoutedEventArgs e)
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

        private void PreviousRatingsPageMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (current_page_number < logic.GetPageCount(pageLimit) - 1)
            {
                current_page_number += 1;
                content.page_index_textblock.Text = $"{current_page_number + 1} of {logic.GetPageCount(pageLimit)}";
                FillMarksTable();

            }
        }

        private void NextRatingsPageMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (current_page_number > 0)
            {
                current_page_number -= 1;
                content.page_index_textblock.Text = $"{current_page_number + 1} of {logic.GetPageCount(pageLimit)}";
                FillMarksTable();
            }
        }

        private void SortRatingsByMarkClick(object sender, RoutedEventArgs e)
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
