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
			logic = new NotesPageVM(new SQLiteDataService(), App.currentUser);
			Title = "Note";
			this.parent = parent;

			note = Note;
			InitializeComponent();
			textDeadline.DisplayDateStart = DateTime.Now;
			subjectName.Text = SubjectName;
			buttonCancel.Click += ButtonCancelClick;
			if (note == null)
			{
				textName.Text = textNamePlaceholder;
				textName.GotFocus += TextTitleGotFocus;
				buttonAdd.Click += ButtonAddClick;
			}
			else
			{
				textName.Text = note.Name;
				textDeadline.Text = note.Deadline.ToShortDateString();
				subjectName.Text = note.SubjectID;
				textMaterials.AppendText(note.Materials);
				buttonAdd.Click += ButtonAddClickModify;
			}
		}
		private void TextTitleGotFocus(object sender, RoutedEventArgs e)
		{
			if (textName.Text == textNamePlaceholder)
			{
				textName.Text = string.Empty;
			}
		}
		private void ButtonAddClick(object sender, RoutedEventArgs e)
		{
			if (validateText())
			{
				String Materials = new TextRange(textMaterials.Document.ContentStart, textMaterials.Document.ContentEnd).Text;
				parent.AddNoteFromString(textName.Text, textDeadline.Text, subjectName.Text, Materials);
				Close();
			}
		}
		private void ButtonAddClickModify(object sender, RoutedEventArgs e)
		{
			if (validateText() && wasChanged())
			{
				Note newNote = new Note();
				newNote.Deadline = DateTime.Parse(textDeadline.Text);
				newNote.SubjectID = subjectName.Text;
				newNote.Materials = new TextRange(textMaterials.Document.ContentStart, textMaterials.Document.ContentEnd).Text;
				newNote.Name = textName.Text;
				parent.ChangeNote(note, newNote);
				Close();
			}
		}
		private void ButtonCancelClick(object sender, RoutedEventArgs e)
		{
			Close();
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
