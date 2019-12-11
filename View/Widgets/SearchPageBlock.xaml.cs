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
using ViewModel;

namespace View.Widgets
{
    /// <summary>
    /// Interaction logic for SearchPageBlock.xaml
    /// </summary>
    public partial class SearchPageBlock : UserControl
    {
        private string notFoundText = "Nothing was found (";
        public Person Person { get; set; }
        public SearchPageBlock(SearchPageVM logic,Person p)
        {
            InitializeComponent();
            if (p != null)
            {
                this.Person = p;
                textNameSurname.Text = $"{p.Name} {p.Surname}";
                BitmapImage tmpBitMap = new BitmapImage();
                tmpBitMap.BeginInit();
                tmpBitMap.CacheOption = BitmapCacheOption.OnLoad;
                tmpBitMap.UriSource = new Uri("../../" + p.Photo,UriKind.RelativeOrAbsolute);
                tmpBitMap.EndInit();
                image_profile.Source = tmpBitMap;
                if (logic.GetStudent(p) != null)
                {
                    textInfo.Text = $"{p.Student.GroupID}";
                }
                else if(logic.GetLecturer(p)!=null)
                {
                    textInfo.Text = $"{p.Lecturer.Department}";
                }
            }
            else
            {
                textNameSurname.Text = notFoundText;
            }
        }
    }
}
