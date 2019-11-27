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
    /// Interaction logic for ProfilePageTableMarksRow.xaml
    /// </summary>
    public partial class ProfilePageTableMarksRow : UserControl
    {
        public Rating Mark { get; set; } = null;
        public ProfilePageTableMarksRow(Rating mark)
        {
            this.Mark = mark;
            InitializeComponent();
            subjectTextbox.Text = Mark.SubjectID;
            markTextbox.Text = Convert.ToString(mark.Mark);
        }
    }
}
