using DAL.Constants;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WPF_App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (!File.Exists(FileConstants.SETTINGS_PATH))
            {
                new Settings().Show();
            }
            else
            {
                new MainWindow().Show();
            }
        }
    }
}
