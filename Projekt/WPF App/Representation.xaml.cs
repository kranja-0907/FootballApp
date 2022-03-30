using DAL;
using DAL.Constants;
using DAL.Enums;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for Representation.xaml
    /// </summary>
    public partial class Representation : Window
    {
        private string name;
        List<GroupResults> groupResults;
        public Representation(string representationName)
        {
            PreInit();
            InitializeComponent();
            name = representationName;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadRepresentationInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "RepDetails_WindowLoaded");
            }
        }

        private async void LoadRepresentationInfo()
        {
            if (MySettings.Championship == Championship.Female.ToString() || MySettings.Championship == "Zenski")
            {
                groupResults = await Repository.LoadJson<GroupResults>(FileConstants.FEMALE_GROUP_RESULTS, APIConstants.FEMALE_GROUP_RESULTS);
            }
            else if (MySettings.Championship == Championship.Male.ToString() || MySettings.Championship == "Muski")
            {
                groupResults = await Repository.LoadJson<GroupResults>(FileConstants.MALE_GROUP_RESULTS, APIConstants.MALE_GROUP_RESULTS);
            }

            foreach (var list in groupResults)
            {
                foreach (var team in list.OrderedTeams)
                {
                    if (team.Country == name)
                    {
                        lblCountry.Content = team.Country;
                        lblFifaCode.Content = team.FifaCode;
                        lblGamesPlayed.Content = team.GamesPlayed;
                        lblGamesWon.Content = team.Wins;
                        lblDraws.Content = team.Draws;
                        lblGamesLost.Content = team.Losses;
                        lblGoalsFor.Content = team.GoalsFor;
                        lblGoalsAgainst.Content = team.GoalsAgainst;
                        lblGoalsDiff.Content = team.GoalDifferential;
                        return;
                    }
                }
            }
        }
    }
}
