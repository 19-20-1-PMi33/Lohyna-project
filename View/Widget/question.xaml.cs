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
using View.Widget.Images;

namespace View.Widget
{
    /// <summary>
    /// Interaction logic for question.xaml
    /// </summary>
    public partial class question : UserControl
    {
        icon_collapse_up col_up;
        public question()
        {
            InitializeComponent();
            col_up = new icon_collapse_up();
            col_up.Height = 50;
            col_up.Width = 50;
            Grid.SetColumn(col_up, 0);
        }
        public void setCollapsed(bool collapsed)
        {
            if (collapsed)
            {
                grid.Children.Remove(col_up);
                grid.Children.Add(col_down);
            }
            else
            {
                grid.Children.Remove(col_down);
                grid.Children.Add(col_up);
            }
        }
        public void setText(string text)
        {
            quest_string.Text = text;
        }
    }
}
