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
using Microsoft.Extensions.Logging;
using ViewModel;
using View.Widget;

namespace View
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        private void one()
        {
            ILogger logger = new Logger();
            using (logger.BeginScope("first level of logging"))
            {
                logger.LogInformation("info");
                using (logger.BeginScope("second level of logging"))
                {
                    logger.LogDebug("debug");
                }
            }
        }
		public MainWindow()
		{
            ILogger logger = new Logger();
            logger.LogInformation("Test info");
            one();
			InitializeComponent();
            TimeTableNote temp = new TimeTableNote();
            temp.Show();
            NoteItem2 temp2 = new NoteItem2();
            temp2.Show();
		}

        private void ProfilePage_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
