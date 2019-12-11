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
    /// Interaction logic for FaqPageQuestionBlock_answer.xaml
    /// </summary>
    public partial class FaqPageQuestionBlockAnswer : UserControl
    {
        public FaqPageQuestionBlockAnswer()
        {
            InitializeComponent();
        }
		public FaqPageQuestionBlockAnswer(string text)
		{
			InitializeComponent();
			answer_string.Text = text;
		}
		public void setText(string text)
		{
			answer_string.Text = text;
		}
	}
}
