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
        public NotesPageNoteBlock(Note note)
        {
            this.note = note;
            InitializeComponent();
            textDeadline.Text = note.Deadline.ToShortDateString() ;
            textSubject.Text = note.SubjectID;
            textName.Text = note.Name;
            textMaterials.AppendText(note.Materials);
        }
    }
}
