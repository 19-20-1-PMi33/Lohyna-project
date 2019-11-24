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

namespace View.Widgets
{
    /// <summary>
    /// Interaction logic for LogInNavbar.xaml
    /// </summary>
    public partial class LogInNavbar : UserControl
    {
        private Dictionary<Control, string> _placeholderText;
        public LogInNavbar()
        {
            InitializeComponent();
            _placeholderText = new Dictionary<Control, string>
            {
                { usernameTextBox, "Username" },
                { passwordTextBox, "Password" }
            };

            passwordTextBox.GotFocus += RemoveText;
            usernameTextBox.GotFocus += RemoveText;

            passwordTextBox.LostFocus += AddText;
            usernameTextBox.LostFocus += AddText;

            AddText(passwordTextBox, null);
            AddText(usernameTextBox, null);
        }

        private void AddText(object sender, EventArgs e)
        {
            TextBox senderBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(senderBox.Text))
            {
                senderBox.Text = _placeholderText[senderBox];
            }
        }

        private void RemoveText(object sender, EventArgs e)
        {
            TextBox senderBox = sender as TextBox;
            if (senderBox.Text.Equals(_placeholderText[senderBox]))
            {
                senderBox.Text = "";
            }
        }
    }
}
