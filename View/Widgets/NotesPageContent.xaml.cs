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
using ViewModel;

namespace View.Widgets
{
    /// <summary>
    /// Interaction logic for NotesPageContent.xaml
    /// </summary>
    public partial class NotesPageContent : UserControl
    {
        public NotesPageContent()
        {
            InitializeComponent();
            check.Click += Check_Click;
        }

        private void Check_Click(object sender, RoutedEventArgs e)
        {
            foreach (NotesPageNoteBlock block in stack.Children)
            {
                block.check.IsChecked = check.IsChecked;
            }
        }
    }
}
