using DAL.Constants;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Forms_Aplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (!File.Exists(FileConstants.SETTINGS_PATH))
            {
                Application.Run(new SettingsForm());
            }
            else
            {
                Application.Run(new MainForm());
            }
        }
    }
}
