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
using DataServices;
using Model;
using ViewModel;

namespace View.Widgets
{
    /// <summary>
    /// Interaction logic for TimeTablePageTimeTableNote.xaml
    /// </summary>
    public partial class TimeTablePageTimeTableNote : Window
    {
		List<Note> NotesOfSubject;
		private NotesPageVM logic;
		private SortedBy sorted = SortedBy.Created;
		public TimeTablePageTimeTableNote(string Subject, string Teacher)
		{
            InitializeComponent();
			this.Subject.Text = Subject;
			this.Teacher.Text = Teacher;
			
			logic = new NotesPageVM(new SQLiteDataService(), App.currentUser);
			NotesOfSubject = ((List<Note>)logic.GetNotes()).Where(x => x.SubjectID == Subject).ToList();

			FillNotes();
			buttonOk.Click += EndWorkWithNotes;
			check.Click += MarkAll;
			buttonCheckedDone.Click += DeleteMarked;
			toSortByTime.Click += SortByTime;
			toSortByTitle.Click += SortByTitle;
		}
		private void AddNoteOnClick(object sender, MouseButtonEventArgs e)
		{
			new TimeTablePageNoteWindow(this, Subject.Text).ShowDialog();
		}
		public void AddNoteFromString(string name, string deadline, string subject, string materials)
		{
			logic.AddNote(name, deadline, subject, materials);
			FillNotes();
		}
		private void FillNotes()
		{
			this.stack.Children.Clear();
			int cnt = 0;
			foreach (var note in NotesOfSubject)
			{
				NotesPageNoteBlock temp = new NotesPageNoteBlock(note);
				temp.MouseDown += TimeTableNotesNoteBlockChange;
				if (cnt++ % 2 == 1)
				{
					temp.grid.Background = new SolidColorBrush(Colors.LightGray);
				}
				this.stack.Children.Add(temp);
			}

		}
		public void ChangeNote(Note Old, Note New)
		{
			NotesOfSubject.Remove(Old);
			NotesOfSubject.Add(New);
			FillNotes();
		}
		private void EndWorkWithNotes(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
		private void MarkAll(object sender, RoutedEventArgs e)
		{
			foreach (NotesPageNoteBlock block in stack.Children)
			{
				block.check.IsChecked = check.IsChecked;
			}
		}
		private void SortByTime(object sender, RoutedEventArgs e)
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
		private void SortByTitle(object sender, RoutedEventArgs e)
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
		private void DeleteMarked(object sender, RoutedEventArgs e)
		{
			foreach (NotesPageNoteBlock block in stack.Children)
			{
				if((bool)block.check.IsChecked)
				{
					logic.DeleteNote(block.textName.Text);
				}
			}
			check.IsChecked = false;
			FillNotes();
		}
		private void TimeTableNotesNoteBlockChange(object sender, MouseButtonEventArgs e)
		{
			new TimeTablePageNoteWindow(this, Subject.Text, (sender as NotesPageNoteBlock).note).ShowDialog();
		}
		public void SortNotes(SortedBy by)
		{
			logic.sort(by);
			FillNotes();
		}
	}
}
