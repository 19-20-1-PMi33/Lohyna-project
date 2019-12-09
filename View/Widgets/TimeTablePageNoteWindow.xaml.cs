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
using System.Windows.Shapes;
using View.Pages;
using Model;
using ViewModel;
using DataServices;

namespace View.Widgets
{
	/// <summary>
	/// Interaction logic for NotesPageNoteWindow.xaml
	/// </summary>
	public partial class TimeTablePageNoteWindow : Window
	{
		private string textNamePlaceholder = "Title of your note";
		private NotesPageVM logic;
		private TimeTablePageTimeTableNote parent;
		Note note;
		public TimeTablePageNoteWindow(TimeTablePageTimeTableNote parent, string SubjectName, Note Note = null)
		{
			this.logic = new NotesPageVM(new SQLiteDataService(), App.username);
			this.Title = "Note";
			this.parent = parent;

			this.note = Note;
			InitializeComponent();
			textDeadline.DisplayDateStart = DateTime.Now;
			subjectName.Text = SubjectName;
			button_cancel.Click += Button_cancel_Click;
			if (note == null)
			{
				textName.Text = textNamePlaceholder;
				textName.GotFocus += TextTitle_GotFocus;
				button_add.Click += Button_add_Click;
			}
			else
			{
				textName.Text = note.Name;
				textDeadline.Text = note.Deadline.ToShortDateString();
				subjectName.Text = note.SubjectID;
				textMaterials.AppendText(note.Materials);
				button_add.Click += Button_add_Click_Modify;
			}
		}
		private void TextTitle_GotFocus(object sender, RoutedEventArgs e)
		{
			if (textName.Text == textNamePlaceholder)
			{
				textName.Text = "";
			}
		}
		private void Button_add_Click(object sender, RoutedEventArgs e)
		{
			if (validateText())
			{
				parent.AddNoteFromString(textName.Text, textDeadline.Text, subjectName.Text, new TextRange(textMaterials.Document.ContentStart, textMaterials.Document.ContentEnd).Text);
				this.Close();
			}
		}
		private void Button_add_Click_Modify(object sender, RoutedEventArgs e)
		{
			if (validateText() && wasChanged())
			{
				Note newNote = new Note();
				newNote.Deadline = DateTime.Parse(textDeadline.Text);
				newNote.SubjectID = subjectName.Text;
				newNote.Materials = new TextRange(textMaterials.Document.ContentStart, textMaterials.Document.ContentEnd).Text;
				newNote.Name = textName.Text;
				parent.ChangeNote(note, newNote);
				this.Close();
			}
		}
		private void Button_cancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}
		private bool validateText()
		{
			if (String.IsNullOrWhiteSpace(textName.Text))
			{
				return false;
			}
			if (textName.Text == textNamePlaceholder)
			{
				return false;
			}
			DateTime temp = new DateTime();
			if (DateTime.TryParse(textDeadline.Text, out temp) == false)
			{
				return false;
			}
			return true;
		}
		private bool wasChanged()
		{
			if (note.Name != textName.Text)
			{
				return true;
			}
			DateTime temp = new DateTime();
			if (DateTime.TryParse(textDeadline.Text, out temp))
			{
				if (note.Deadline != temp)
				{
					return true;
				}
			}
			if (note.SubjectID != subjectName.Text)
			{
				return true;
			}
			if (note.Materials != new TextRange(textMaterials.Document.ContentStart, textMaterials.Document.ContentEnd).Text)
			{
				return true;
			}
			return false;
		}
	}
}
