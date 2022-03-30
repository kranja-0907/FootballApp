using DAL;
using DAL.Constants;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Forms_Aplication
{
    public partial class SettingsForm : Form
    {

        string culture;
        private const string HR = "hr", EN = "en";
        ConfirmationPopUp popUp = new ConfirmationPopUp();
        public SettingsForm()
        {
            InitializeComponent();
            InitDDL();
        }

        private void InitDDL()
        {
            cbChampionship.SelectedIndex = 0;
            cbLanguage.SelectedIndex = 0;
        }

        private void cbLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckLanguage();
        }

        private void CheckLanguage()
        {
            switch (cbLanguage.SelectedItem)
            {
                case "Croatian":
                    LocalizationAndGlobalization(HR);
                    break;
                case "English":
                    LocalizationAndGlobalization(EN);
                    break;
                case "Hrvatski":
                    LocalizationAndGlobalization(HR);
                    break;
                case "Engleski":
                    LocalizationAndGlobalization(EN);
                    break;
            }
        }

        private void LocalizationAndGlobalization(string cultureName)
        {
            if (Thread.CurrentThread.CurrentUICulture.Name == cultureName)
            {
                return;
            }
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureName);

            int selectedIndexLanguage = cbLanguage.SelectedIndex;
            int selectedIndexChampionship = cbChampionship.SelectedIndex;
            culture = cultureName;

            Controls.Clear();
            InitializeComponent();
            cbChampionship.SelectedIndex = selectedIndexChampionship;
            cbLanguage.SelectedIndex = selectedIndexLanguage;
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (popUp.ShowDialog() == DialogResult.Yes || popUp.isClicked)
            {
                File.WriteAllText(FileConstants.SETTINGS_PATH, string.Empty);
                Repository.SaveChoices(FileConstants.SETTINGS_PATH, cbLanguage.SelectedItem.ToString(), cbChampionship.SelectedItem.ToString(), culture);
                new MainForm().Show();
                popUp.Close();
                Hide();
            }
        }



        private void LoadData()
        {
            Repository.LoadLanguageAndChampionship();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (popUp.ShowDialog() == DialogResult.No)
            {
                Close();
            }
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
