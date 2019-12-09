﻿using System;
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
using System.IO;
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
        private readonly string viewDirectory;
        int currentPageNumber = 0;
        public ProfilePage()

        {
            this.logic = new ProfilePageVM(new SQLiteDataService(), "OlegAndrus");
            viewDirectory = Directory
                .GetParent(Directory
                .GetParent(System.IO.Path.Combine(Directory.GetCurrentDirectory()))
                .FullName)
                .FullName;

            InitializeComponent();

            navbar.button_Profile.Click += ProfileTransition;
            navbar.button_FAQ.Click += FAQTransition;
            navbar.button_Notes.Click += NotesTransition;
            navbar.button_TimeTable.Click += TimetableTransition;
            navbar.button_Profile.Style = Application.Current.Resources["MenuButtonActive"] as Style;
            if (logic.GetPerson() != null)
            {
                content.nameSurnameTextblock.Text = logic.GetPerson().Name + " " + logic.GetPerson().Surname;

                BitmapImage temp = new BitmapImage();
                temp.BeginInit();
                temp.CacheOption = BitmapCacheOption.OnLoad;
                temp.UriSource = new Uri(System.IO.Path.Combine(viewDirectory) + logic.GetPerson().Photo, UriKind.Relative);
                temp.EndInit();
                content.profilePhoto.Source = temp;
                if (logic.GetLecturer() != null)
                {
                    content.groupDepartmentLabel.Text = "Department:";
                    content.groupDepartmentTextblock.Text = logic.GetLecturer().Department;
                    content.numberZalikovkaLabel.Visibility = Visibility.Hidden;
                    content.numberZalikovkaTextblock.Visibility = Visibility.Hidden;
                    content.courseLabel.Visibility = Visibility.Hidden;
                    content.courseTextblock.Visibility = Visibility.Hidden;
                    content.marks.Visibility = Visibility.Hidden;
                    content.buttonNext.Visibility = Visibility.Hidden;
                    content.buttonPrev.Visibility = Visibility.Hidden;
                }
                else if (logic.GetStudent() != null)
                {
                    logic.GetRatings();
                    content.groupDepartmentTextblock.Text = logic.GetStudent().GroupID;
                    content.courseTextblock.Text = logic.GetGroup().Course.ToString();
                    content.numberZalikovkaTextblock.Text = logic.GetStudent().TicketNumber.ToString();
                    content.marks.HeadRow1.subjectColumn.Click += SortRatingsBySubjectClick;
                    content.marks.HeadRow1.markColumn.Click += SortRatingsByMarkClick;
                    content.marks.HeadRow2.subjectColumn.Click += SortRatingsBySubjectClick;
                    content.marks.HeadRow2.markColumn.Click += SortRatingsByMarkClick;
                    content.buttonNext.MouseDown += PreviousRatingsPageMouseDown;
                    content.buttonPrev.MouseDown += NextRatingsPageMouseDown;
                    content.pageIndexTextblock.Text = $"{currentPageNumber + 1} of {logic.GetPageCount(pageLimit)}";

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
            content.marks.stack1.Children.Clear();
            content.marks.stack2.Children.Clear();
            var fillTableIndex = 0;
            foreach (Rating row in logic.GetCurrentPageRatings(pageLimit, currentPageNumber))
            {
                ProfilePageTableMarksRow item = new ProfilePageTableMarksRow(row);
                if (fillTableIndex % 2 == 0)
                    this.content.marks.stack1.Children.Add(item);
                else
                    this.content.marks.stack2.Children.Add(item);
                ++fillTableIndex;
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
        private void SortRatingsBySubjectClick(object sender, RoutedEventArgs e)
        {
            sorted = (sorted == SortMarkTable.Subject) ? SortMarkTable.SubjectReverse : SortMarkTable.Subject;
            SortMarksTableRows(sorted);
        }

        private void PreviousRatingsPageMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (currentPageNumber < logic.GetPageCount(pageLimit) - 1)
            {
                currentPageNumber += 1;
                content.pageIndexTextblock.Text = $"{currentPageNumber + 1} of {logic.GetPageCount(pageLimit)}";
                FillMarksTable();

            }
        }

        private void NextRatingsPageMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (currentPageNumber > 0)
            {
                currentPageNumber -= 1;
                content.pageIndexTextblock.Text = $"{currentPageNumber + 1} of {logic.GetPageCount(pageLimit)}";
                FillMarksTable();
            }
        }

        private void SortRatingsByMarkClick(object sender, RoutedEventArgs e)
        {
            sorted = (sorted == SortMarkTable.Mark) ? SortMarkTable.MarkReverse : SortMarkTable.Mark;
            SortMarksTableRows(sorted);
        }

    }
}
