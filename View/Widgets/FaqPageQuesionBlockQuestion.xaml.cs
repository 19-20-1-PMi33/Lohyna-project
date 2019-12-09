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
    /// Interaction logic for FaqPageQuesionBlock_question.xaml
    /// </summary>
    public partial class FaqPageQuesionBlockQuestion : UserControl
    {
		Images.collapse_up_icon ColUp;
		public FaqPageQuesionBlockQuestion()
		{
			InitializeComponent();
			ColUp = new Images.collapse_up_icon();
			ColUp.Height = 50;
			ColUp.Width = 50;
			Grid.SetColumn(ColUp, 0);
		}
		public void SetCollapsed(bool collapsed)
		{
			if (collapsed)
			{
				grid.Children.Remove(ColUp);
				grid.Children.Add(ColDown);
			}
			else
			{
				grid.Children.Remove(ColDown);
				grid.Children.Add(ColUp);
			}
		}
		public void SetText(string text)
		{
			quest_string.Text = text;
		}
	}
}
