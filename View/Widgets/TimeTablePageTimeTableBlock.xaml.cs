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
    /// Interaction logic for TimeTablePageTimeTableBlock.xaml
    /// </summary>
    public partial class TimeTablePageTimeTableBlock : UserControl
	{
		TimeTablePageTimeTableNote notes;
		public TimeTablePageTimeTableBlock()
		{
			notes = new TimeTablePageTimeTableNote();
			InitializeComponent();
		}
		private void OpenNotesForSubject(object sender, MouseButtonEventArgs e)
		{
			new TimeTablePageTimeTableNote(this.name.Text, this.lecturer.Text).ShowDialog();
		}
	}
}
