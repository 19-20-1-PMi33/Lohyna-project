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
    /// Interaction logic for tableMarks.xaml
    /// </summary>
    public partial class tableMarks : UserControl
    {
        public tableMarks()
        {
            InitializeComponent();
            for(int i = 0; i < 7; i++)
            {
                tableMarksItem temp = new tableMarksItem();
                if (i % 2 == 1)
                {
                    temp.grid.Background = new SolidColorBrush(Colors.LightGray);
                }
                grid.RowDefinitions[1].Height = new GridLength(grid.RowDefinitions[1].Height.Value+30);
                stack.Children.Add(temp);
            }
        }
    }
}
