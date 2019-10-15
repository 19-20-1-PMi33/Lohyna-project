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
    /// Interaction logic for Search.xaml
    /// </summary>
    public partial class Search : UserControl
    {
        public Search()
        {
            InitializeComponent();
        }
        public void addSearchItem(SearchItem item)
        {
            item.BorderBrush = new SolidColorBrush(Colors.Black);
            item.BorderThickness = new Thickness(1,0,1,1);
            this.stack.Children.Add(item);
        }
        public void clear()
        {
            this.stack.Children.Clear();
        }
    }
}
