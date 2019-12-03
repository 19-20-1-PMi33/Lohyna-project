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
			QuestionBlocks = new List<FaqPageQuestionBlock>();

			FaqPageVM Service = new FaqPageVM(new SQLiteDataService());
			
			List<String> Questions = new List<String>();
			Questions = Service.GetQuestions();

			for (int i = 0; i < Questions.Count; i++)
			{
				List<String> Answers = new List<string>();
				Answers.Add(Service.GetAnswer(Questions[i]));

				FaqPageQuestionBlock Block = new FaqPageQuestionBlock();
				Block.setText(Questions[i], Answers);
				QuestionBlocks.Add(Block);
			}
			QuestionBlocks.ForEach(x => stack.Children.Add(x));
		}
	}
}
