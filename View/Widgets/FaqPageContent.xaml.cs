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
        public FaqPageContent()
        {
            InitializeComponent();

			FaqPageVM Service = new FaqPageVM(new SQLiteDataService());
			Service.GetQuestions()
				.ForEach(x => stack.Children.Add(new FaqPageQuestionBlock(x, Service.GetAnswer(x))));
		}
	}
}
