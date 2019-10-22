﻿using System;
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
using View.Widget;

namespace View
{
    /// <summary>
    /// Interaction logic for Navbar.xaml
    /// </summary>
    public partial class Navbar : UserControl, IViewTransition<faq_page>
    {
        public Navbar()
        {
            InitializeComponent();
        }

        public event EventHandler NavigationEventHandler;

        public void NavigateTo(faq_page element)
        {
            
        }
    }
}
