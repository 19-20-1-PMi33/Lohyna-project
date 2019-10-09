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
    /// Interaction logic for faq_page.xaml
    /// </summary>
    public partial class faq_page : UserControl
    {
        List<faq_question> quests;
        public faq_page()
        {
            quests = new List<faq_question>();
            List<String> temp_answers = new List<string>();
            temp_answers.Add("Answer 1");
            temp_answers.Add("Answer 2");
            temp_answers.Add("Answer 3");
            for(int i = 1; i < 6; i++)
            {
                faq_question temp = new faq_question();
                temp.setText($"Question {i}", temp_answers);
                quests.Add(temp);
            }
            InitializeComponent();
            quests.ForEach(x => stack.Children.Add(x));
        }
    }
}
