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

namespace View.Widgets
{
    /// <summary>
    /// Interaction logic for Navbar.xaml
    /// </summary>
    public partial class Navbar : UserControl
    {
        private Dictionary<Button, Uri> _routingPaths;
        public Navbar()
        {
            InitializeComponent();
            _routingPaths = new Dictionary<Button, Uri>
            {
                { ProfileButton, new Uri("../Pages/ProfilePage.xaml", UriKind.Relative) },
                { NotesButton, new Uri("../Pages/NotesPage.xaml", UriKind.Relative) },
                { TimeTableButton, new Uri("../Pages/TimeTablePage.xaml", UriKind.Relative) },
                { FAQButton, new Uri("../Pages/FaqPageLoged.xaml", UriKind.Relative) }
            };
        }

        private void NavigationButtonTransitionHandler(object sender, RoutedEventArgs eventArgs)
        {
            Button senderButton = sender as Button;
            
        }
    }
}
