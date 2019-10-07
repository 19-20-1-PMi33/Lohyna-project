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
    /// Interaction logic for LogInNavbar.xaml
    /// </summary>
    public partial class LogInNavbar : UserControl
    {
        public LogInNavbar()
        {
            InitializeComponent();
        }

        private void username_focused(object sender, RoutedEventArgs e)
        {
            if(text_user.Text=="Username")
            {
                text_user.Text = "";
                text_user.Foreground = new SolidColorBrush(Colors.Black);
            }
        }
        private void m_down(object sender, MouseButtonEventArgs e)
        {
            grid.Children.Remove(text_pass_block);
            text_pass.Focus();
        }
    }
}
