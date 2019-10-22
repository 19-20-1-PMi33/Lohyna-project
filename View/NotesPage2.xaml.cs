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
using View.Widget;

namespace View
{
    /// <summary>
    /// Interaction logic for NotesPage2.xaml
    /// </summary>
    public partial class NotesPage2 : UserControl
    {
        public NotesPage2()
        {
            InitializeComponent();
            for(int i = 0; i < 20; i++)
            {
                NoteShortItem2 temp = new NoteShortItem2();
                if (i % 2 == 1)
                {
                    temp.grid.Background = new SolidColorBrush(Colors.LightGray);
                }
                stack.Children.Add(temp);
            }
        }
    }
}
