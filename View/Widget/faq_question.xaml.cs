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
    /// Interaction logic for faq_question.xaml
    /// </summary>
    public partial class faq_question : UserControl
    {
        StackPanel stack;
        List<String> answers;
        bool collapsed;
        public faq_question()
        {
            collapsed = true;
            stack = new StackPanel();
            answers = new List<string>();
            InitializeComponent();
            question.setText("Question");
            Grid.SetRow(stack, 1);
            Grid.SetColumn(stack, 1);
        }

        private void question_collapse(object sender, MouseButtonEventArgs e)
        {
            if (collapsed)
            {
                collapsed = false;
                question.setCollapsed(collapsed);
                stack.Children.Clear();
                for (int i = 0; i < answers.Count; i++)
                {
                    answer temp = new answer();
                    temp.setText(answers[i]);
                    stack.Children.Add(temp);
                }
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

        private void Question_MouseEnter(object sender, MouseEventArgs e)
        {
            if(collapsed)
                question.Background = new SolidColorBrush(Color.FromRgb(220, 220, 220));
        }

        private void Question_MouseLeave(object sender, MouseEventArgs e)
        {
            if(collapsed)
                question.Background = null;
        }
        public void setText(string ques,List<String> answers)
        {
            question.setText(ques);
            this.answers = answers;
        }
    }
}
