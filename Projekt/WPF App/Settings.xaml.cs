using DAL;
using DAL.Constants;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_App
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        private const string HR = "hr", EN = "en";
        private string culture;

        public Settings()
        {
            PreInit();
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cbLanguage.SelectedIndex = 0;
            cbRepresentation.SelectedIndex = 0;
        }

        private void SetSelection(string language)
        {
            switch (language)
            {
                case HR:
                    cbLanguage.SelectedIndex = 1;
                    break;
                case EN:
                    cbLanguage.SelectedIndex = 0;
                    break;
            }
        }

        private void PreInit()
        {
            Repository.LoadLanguageAndChampionship();

            SetCulture(MySettings.Culture);
        }

        private void SetCulture(string culture)
        {
            if (Thread.CurrentThread.CurrentUICulture.Name == culture)
            {
                return;
            }
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }

        private void btnOK_Clicked(object sender, RoutedEventArgs e)
        {
            Close();
            new MainWindow().Show();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }



        private void cbLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbLanguage.SelectedIndex)
            {
                case 0:
                    culture = EN;
                    break;
                case 1:
                    culture = HR;
                    break;
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                File.WriteAllText(FileConstants.SETTINGS_PATH, string.Empty);

                Repository.SaveChoices(FileConstants.SETTINGS_PATH, cbLanguage.SelectedItem.ToString().Substring(cbRepresentation.SelectedItem.ToString().LastIndexOf(' ')).Trim(), cbRepresentation.SelectedItem.ToString().Substring(cbRepresentation.SelectedItem.ToString().LastIndexOf(' ')).Trim(), culture); //, cbResolution.SelectedItem.ToString().Substring(cbRepresentation.SelectedItem.ToString().LastIndexOf(' ')).Trim(), WindowState.ToString()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Your choices couldn't be saved.");
            }
        }
    }
}
