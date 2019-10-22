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
    /// Interaction logic for TimeTableNote_tableNotes.xaml
    /// </summary>
    public partial class TimeTableNote_tableNotes : UserControl
    {
        public TimeTableNote_tableNotes()
        {
            InitializeComponent();
            for(int i = 0; i < 5; i++)
            {
                NoteVeryShortItem temp = new NoteVeryShortItem();
                if (i % 2 == 1)
                {
                    temp.grid.Background = new SolidColorBrush(Colors.LightGray);
                }
                stack.Children.Add(temp);
            }
        }
    }
}
