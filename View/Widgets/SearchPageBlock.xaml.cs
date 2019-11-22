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
using Model;
using View.Pages;

namespace View.Widgets
{
    /// <summary>
    /// Interaction logic for SearchPageBlock.xaml
    /// </summary>
    public partial class SearchPageBlock : UserControl
    {
        private string notFoundText = "Nothing was found (";
        public SearchPageBlock(Person p)
        {
            InitializeComponent();
            if (p != null)
            {
                textNameSurname.Text = $"{p.Name} {p.Surname}";
                image_profile.Source = new BitmapImage(new Uri(p.Photo, UriKind.Relative));
                if (p.Student != null)
                {
                    textInfo.Text = $"{p.Student.GroupID}";
                }
                else
                {
                    textInfo.Text = $"{p.Lecturer.Department}, {p.Lecturer.Specializations}";
                }
            }
            else
            {
                textNameSurname.Text = notFoundText;
            }
        }
    }
}
