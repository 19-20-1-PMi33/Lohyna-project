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

namespace View.Widgets
{
    /// <summary>
    /// Interaction logic for LogInNavbar.xaml
    /// </summary>
    public partial class LogInNavbar : UserControl
    {
        public LogInNavbar()
        {
            InitializeComponent();
        }

        private void usernameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
             if (e.Key == Key.Enter)
                passwordTextBox.Focus();
        }

        private void passwordTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                button_login.Focus();
        }
    }
}
