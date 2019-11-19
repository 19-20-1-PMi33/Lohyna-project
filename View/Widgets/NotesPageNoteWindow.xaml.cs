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
        private string textNamePlaceholder = "Title of your note";
        private string textDeadlinePlaceholder = "Deadline";
        NotesPage parent;
        Note note;
        public NotesPageNoteWindow(NotesPage parent, Note note = null)
        {
            this.parent = parent;
            this.note = note;
            this.Title = "Note";
            InitializeComponent();
            comboSubject.ItemsSource = parent.GetSubjects();
            button_cancel.Click += Button_cancel_Click;
            if (note == null)
            {
                textName.Text = textNamePlaceholder;
                textDeadline.Text = textDeadlinePlaceholder;
                textName.GotFocus += TextTitle_GotFocus;
                textDeadline.GotFocus += TextDate_GotFocus;
                button_add.Click += Button_add_Click;
            }
            else
            {
                textName.Text = note.Name;
                textDeadline.Text = note.Deadline.ToShortDateString();
                comboSubject.SelectedItem = note.SubjectID;
                textMaterials.AppendText(note.Materials);
                button_add.Click += Button_add_Click_Modify;
            }
        }

        private void TextDate_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textDeadline.Text == textDeadlinePlaceholder)
            {
                textDeadline.Text = "";
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
                parent.AddNoteFromString(textName.Text, textDeadline.Text, comboSubject.SelectedItem.ToString(), new TextRange(textMaterials.Document.ContentStart, textMaterials.Document.ContentEnd).Text);
                this.Close();
            }
        }
        private void Button_add_Click_Modify(object sender, RoutedEventArgs e)
        {
            if (validateText() && wasChanged())
            {
                Note newNote = new Note();
                newNote.Deadline = DateTime.Parse(textDeadline.Text);
                newNote.SubjectID = comboSubject.SelectedItem.ToString();
                newNote.Materials = new TextRange(textMaterials.Document.ContentStart, textMaterials.Document.ContentEnd).Text;
                newNote.Name = textName.Text;
                parent.ChangeNote(note,newNote);
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
            if (note.SubjectID != comboSubject.SelectedItem.ToString())
            {
                return true;
            }
            if(note.Materials!= new TextRange(textMaterials.Document.ContentStart, textMaterials.Document.ContentEnd).Text)
            {
                return true;
            }
            return false;
        }
    }
}
