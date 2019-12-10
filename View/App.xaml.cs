using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using ViewModel;
using System.Xml;

namespace View
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
        public static string LastSearch { get; set; }
        public static string userToDisplay { get; set; }
        public static string currentUser { get; set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (File.Exists(Logger.DefaultFilePath))
            {
                File.WriteAllText(Logger.DefaultFilePath, string.Empty);
            }
            if (ConfigurationManager.AppSettings["currentUser"] != "")
            {
                App.setUser(ConfigurationManager.AppSettings["currentUser"]);
            }
            this.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }
        public static void setUser(string username)
        {
            currentUser = username;
            userToDisplay = username;
        }
    }
}
