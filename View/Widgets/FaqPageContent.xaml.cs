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
using ViewModel;
using DataServices;

namespace View.Widgets
{
    /// <summary>
    /// Interaction logic for FaqPageContent.xaml
    /// </summary>
    public partial class FaqPageContent : UserControl
    {
		List<FaqPageQuestionBlock> QuestionBlocks;
        public FaqPageContent()
        {
            InitializeComponent();
			InitializeComponent();
			FaqPageVM Service = new FaqPageVM(new SQLiteDataService());
			List<String> Questions = Service.GetQuestions();

			QuestionBlocks = new List<FaqPageQuestionBlock>();
			Questions.ForEach(x => QuestionBlocks.Add(new FaqPageQuestionBlock(x, Service.GetAnswer(x))));
			QuestionBlocks.ForEach(x => stack.Children.Add(x));
		}
	}
}
