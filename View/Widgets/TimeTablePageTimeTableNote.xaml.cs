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
		public TimeTablePageTimeTableNote(string Subject, string Teacher)
		{
            InitializeComponent();
			this.Subject.Text = Subject;
			this.Teacher.Text = Teacher;
			logic = new NotesPageVM(new SQLiteDataService(), App.username);
			NotesOfSubject = (List<Note>)logic.GetNotes();
			fillNotes();
			button_ok.Click += EndWorkWithNotes;
		}
		private void AddNoteOnClick(object sender, MouseButtonEventArgs e)
		{
			new TimeTablePageNoteWindow(this,Subject.Text).ShowDialog();
		}
		public void AddNoteFromString(string name, string deadline, string subject, string materials)
		{
			logic.AddNote(name, deadline, subject, materials);
			fillNotes();
		}
		private void fillNotes()
		{
			this.TimeTablePageTimeTableNoteTableNotes.stack.Children.Clear();
			int cnt = 0;
			foreach (var note in NotesOfSubject)
			{
				NotesPageNoteBlock temp = new NotesPageNoteBlock(note);
				//temp.MouseDown += NotesPageBlock_MouseDown;
				if (cnt++ % 2 == 1)
				{
					temp.grid.Background = new SolidColorBrush(Colors.LightGray);
				}
				this.TimeTablePageTimeTableNoteTableNotes.stack.Children.Add(temp);
			}

		}
		public void ChangeNote(Note Old, Note New)
		{
			NotesOfSubject.Remove(Old);
			NotesOfSubject.Add(New);
			fillNotes();
		}
		private void EndWorkWithNotes(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
	}
}
