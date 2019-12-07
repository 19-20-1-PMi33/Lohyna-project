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
	/// Interaction logic for FaqPageQuestionBlock.xaml
	/// </summary>
	public partial class FaqPageQuestionBlock : UserControl
	{
		StackPanel stack;
		List<String> answers;
		bool collapsed;
		public FaqPageQuestionBlock()
		{
			collapsed = true;
			stack = new StackPanel();
			answers = new List<string>();
			InitializeComponent();
			question.setText("Question");
			Grid.SetRow(stack, 1);
			Grid.SetColumn(stack, 1);
		}
		public FaqPageQuestionBlock(String questionText, String answerText)
		{
			collapsed = true;
			stack = new StackPanel();
			answers = new List<String>();
			InitializeComponent();
			question.setText("Question");
			Grid.SetRow(stack, 1);
			Grid.SetColumn(stack, 1);

			this.setText(questionText, answerText);
		}
		private void QuestionCollapse(object sender, MouseButtonEventArgs e)
		{
			if (collapsed)
			{
				collapsed = false;
				question.setCollapsed(collapsed);

				stack.Children.Clear();
				answers.ForEach(x => stack.Children.Add(new FaqPageQuestionBlockAnswer(x)));

				grid.Children.Add(stack);

				question.Background = new SolidColorBrush(Color.FromRgb(200, 200, 200));
			}
			else
			{
				collapsed = true;
				question.setCollapsed(collapsed);

				grid.Children.Remove(stack);

				question.Background = null;
			}
		}

		private void QuestionMouseEnter(object sender, MouseEventArgs e)
		{
			if (collapsed)
				question.Background = new SolidColorBrush(Color.FromRgb(220, 220, 220));
		}

		private void QuestionMouseLeave(object sender, MouseEventArgs e)
		{
			if (collapsed)
				question.Background = null;
		}
		public void setText(String questionText, String answerText)
		{
			question.setText(questionText);
			this.answers.Add(answerText);
		}
	}
}


