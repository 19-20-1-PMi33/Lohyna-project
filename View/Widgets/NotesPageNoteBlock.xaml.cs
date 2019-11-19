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

namespace View.Widgets
{
    /// <summary>
    /// Interaction logic for NotesPageNoteBlock.xaml
    /// </summary>
    public partial class NotesPageNoteBlock : UserControl
    {
        public Note note { get; set; } = null;
        public NotesPageNoteBlock()
        {
            InitializeComponent();
        }
        public NotesPageNoteBlock(string date, string subject, string title, string text)
        {
            InitializeComponent();
            textDate.Text = date;
            textSubject.Text = subject;
            textTitle.Text = title;
            textNote.AppendText(text);
        }
        public NotesPageNoteBlock(Note note)
        {
            this.note = note;
            InitializeComponent();
            textDate.Text = note.Deadline.ToShortDateString() ;
            textSubject.Text = note.SubjectID;
            textTitle.Text = note.Name;
            textNote.AppendText(note.Materials);
        }
    }
}
