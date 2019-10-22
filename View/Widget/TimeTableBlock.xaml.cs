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

namespace View.Widget
{
    /// <summary>
    /// Interaction logic for TimeTableBlock.xaml
    /// </summary>
    public partial class TimeTableBlock : UserControl
    {
        TimeTableNote notes;
        public TimeTableBlock()
        {
            notes = new TimeTableNote();
            notes.button_Add.MouseDown += Notes_Button_Add_MouseDown;
            InitializeComponent();
        }

        private void Notes_Button_Add_MouseDown(object sender, MouseButtonEventArgs e)
        {
            new NoteItem2().Show();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            notes.Show();
        }
    }
}
