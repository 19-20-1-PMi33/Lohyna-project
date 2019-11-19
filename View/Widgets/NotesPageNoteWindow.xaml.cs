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

namespace View.Widgets
{
    /// <summary>
    /// Interaction logic for NotesPageNoteWindow.xaml
    /// </summary>
    public partial class NotesPageNoteWindow : Window
    {
        private string textTitlePlaceholder = "Title of your note";
        private string textDeadlinePlaceholder = "Deadline";
        NotesPage parent = null;
        Note note = null;
        public NotesPageNoteWindow()
        {
            setUp();
        }
        public NotesPageNoteWindow(NotesPage parent)
        {
            setUp();
            this.parent = parent;
            combo.ItemsSource = parent.GetSubjects();
            button_cancel.Click += Button_cancel_Click;
            button_add.Click += Button_add_Click;
        }
        public NotesPageNoteWindow(NotesPage parent, Note note)
        {
            this.note = note;
            this.Title = "Note";
            InitializeComponent();
            textTitle.Text = note.Name;
            textDate.Text = note.Deadline.ToShortDateString();
            combo.SelectedItem = note.SubjectID;
            textNote.AppendText(note.Materials);
            this.parent = parent;
            combo.ItemsSource = parent.GetSubjects();
            button_cancel.Click += Button_cancel_Click;
            button_add.Click += Button_add_Click_Modify;
        }
        private void setUp()
        {
            InitializeComponent();
            textTitle.Text = textTitlePlaceholder;
            textDate.Text = textDeadlinePlaceholder;
            textTitle.GotFocus += TextTitle_GotFocus;
            textDate.GotFocus += TextDate_GotFocus;
        }

        private void TextDate_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textDate.Text == textDeadlinePlaceholder)
            {
                textDate.Text = "";
            }
        }

        private void TextTitle_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textTitle.Text == textTitlePlaceholder)
            {
                textTitle.Text = "";
            }
        }
        private void Button_add_Click(object sender, RoutedEventArgs e)
        {
            if (validateText())
            {
                parent.AddNote(textTitle.Text, textDate.Text, combo.SelectedItem.ToString(), new TextRange(textNote.Document.ContentStart, textNote.Document.ContentEnd).Text);
                this.Close();
            }
        }
        private void Button_add_Click_Modify(object sender, RoutedEventArgs e)
        {
            if (validateText())
            {
                note.Deadline = DateTime.Parse(textDate.Text);
                note.SubjectID = combo.SelectedItem.ToString();
                note.Materials = new TextRange(textNote.Document.ContentStart, textNote.Document.ContentEnd).Text;
                parent.ChangeNote(note);
                this.Close();
            }
        }
        private void Button_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private bool validateText()
        {
            if (String.IsNullOrWhiteSpace(textTitle.Text))
            {
                return false;
            }
            DateTime temp = new DateTime();
            if (DateTime.TryParse(textDate.Text, out temp) == false)
            {
                return false;
            }
            return true;
        }
    }
}
