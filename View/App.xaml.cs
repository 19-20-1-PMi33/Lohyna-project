using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using ViewModel;

namespace View
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (File.Exists(Logger.DefaultFilePath))
            {
                File.WriteAllText(Logger.DefaultFilePath, string.Empty);
            }
            ShutdownMode = ShutdownMode.OnMainWindowClose;
        }
    }
}
