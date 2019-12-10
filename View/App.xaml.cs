﻿using System;
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
        public static string LastSearch { get; set; }
		public static string username { get; set; } = "RomanLevkovych";
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            if (File.Exists(Logger.DefaultFilePath))
            {
                File.WriteAllText(Logger.DefaultFilePath, string.Empty);
            }
            this.ShutdownMode = ShutdownMode.OnMainWindowClose;
        }
    }
}
