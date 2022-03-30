using DAL;
using DAL.Constants;
using DAL.Enums;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_App.Factory;

namespace WPF_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string representationName;
        List<BasicInfo> info = new List<BasicInfo>();
        List<Representations> representations = new List<Representations>();

        public MainWindow()
        {
            PreInit();
            InitializeComponent();
        }

        private void PreInit()
        {
            Repository.LoadLanguageAndChampionship();

            SetCulture(MySettings.Culture);
        }
        //kultura
        private void SetCulture(string culture)
        {
            if (Thread.CurrentThread.CurrentUICulture.Name == culture)
            { 
                return;
            }

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
        }
        //ucitavanje
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                FillHomeTeamDdl();
                LoadBasicInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MainWindow_Loaded");
            }
        }


        //home igraci, awayDDL, away igraci
        private async void LoadBasicInfo()
        {
            try
            {
                if (MySettings.Championship == "Female" || MySettings.Championship == "Zenski")
                {
                    info = await Repository.LoadJson<BasicInfo>(FileConstants.FEMALE_MATCHES, APIConstants.FEMALE_MATCHES);
                }
                else if (MySettings.Championship == "Male" || MySettings.Championship == "Muski")
                {
                    info = await Repository.LoadJson<BasicInfo>(FileConstants.MALE_MATCHES, APIConstants.MALE_MATCHES);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LoadHomeTeamPlayers();
            FillAwayTeamDdl();
            LoadAwayTeamPlayers();
        }

        private async void FillHomeTeamDdl()
        {
            if (MySettings.Championship == "Female" || MySettings.Championship == "Zenski")
            {
                representations = await Repository.LoadJson<Representations>(FileConstants.FEMALE_TEAMS, APIConstants.FEMALE_TEAMS);
            }
            else if (MySettings.Championship == "Male" || MySettings.Championship == "Muski")
            {
                representations = await Repository.LoadJson<Representations>(FileConstants.MALE_TEAMS, APIConstants.MALE_TEAMS);
            }
            FillDdl();
            SetChosenRepresentation();
            SetScores();
        }

        private void LoadHomeTeamPlayers()
        {
            if (info == null)
            {
                return;
            }

            lblDefenders.Children.Clear();
            lblGoalie.Children.Clear();
            lblMidfielder.Children.Clear();
            lblAttackers.Children.Clear();

            foreach (var item in info)
            {
                if (item.HomeTeam.Country == cbHomeTeam.SelectedItem.ToString().Substring(0, cbHomeTeam.SelectedItem.ToString().IndexOf('(')).Trim())
                {
                    foreach (var player in item.HomeTeamStatistics.StartingEleven)
                    {
                        StartingElevenFactory startingElevenFactory = new StartingElevenFactory();
                        startingElevenFactory.GetStartingEleven(player);

                        switch (player.Position)
                        {
                            case Position.Defender:
                                lblDefenders.Children.Add(new PlayerControlHomeTeam(player));
                                break;
                            case Position.Forward:
                                lblAttackers.Children.Add(new PlayerControlHomeTeam(player));
                                break;
                            case Position.Goalie:
                                lblGoalie.Children.Add(new PlayerControlHomeTeam(player));
                                break;
                            case Position.Midfield:
                                lblMidfielder.Children.Add(new PlayerControlHomeTeam(player));
                                break;
                            default:
                                break;
                        }
                    }
                    return;
                }
            }
        }

        private void FillAwayTeamDdl()
        {
            if (info == null)
            {
                return;
            }

            foreach (var match in info)
            {
                if (match.HomeTeam.Country == cbHomeTeam.SelectedItem.ToString().Substring(0, cbHomeTeam.SelectedItem.ToString().IndexOf('(')).Trim())
                {
                    cbAwayTeam.Items.Add(match.AwayTeam.Country);
                }
            }
            cbAwayTeam.SelectedIndex = 0;
            cbAwayTeam.SelectedItem = MySettings.AwayTeam;
        }

        private void LoadAwayTeamPlayers()
        {
            if (info == null)
            {
                return;
            }

            lblDefenderA.Children.Clear();
            lblGoalieA.Children.Clear();
            lblMidfielderA.Children.Clear();
            lblAttackerFirstA.Children.Clear();



            foreach (var item in info)
            {
                if (item.AwayTeam.Country == MySettings.AwayTeam)
                {
                    foreach (var player in item.AwayTeamStatistics.StartingEleven)
                    {
                        StartingElevenFactory startingElevenFactory = new StartingElevenFactory();
                        startingElevenFactory.GetStartingEleven(player);
                        switch (player.Position)
                        {
                            case Position.Defender:
                                lblDefenderA.Children.Add(new PlayerControlAwayTeam(player));
                                break;
                            case Position.Goalie:
                                lblGoalieA.Children.Add(new PlayerControlAwayTeam(player));
                                break;
                            case Position.Midfield:
                                lblMidfielderA.Children.Add(new PlayerControlAwayTeam(player));
                                break;
                            case Position.Forward:
                                lblAttackerFirstA.Children.Add(new PlayerControlAwayTeam(player));
                                break;
                            default:
                                break;
                        }
                    }
                    return;
                }
            }
        }




        private void FillDdl()
        {

            if (representations == null)
            {
                return;
            }

            foreach (var representation in representations)
            {
                cbHomeTeam.Items.Add(representation.ToString());
            }
        }

        private void SetScores()
        {
            foreach (var match in info)
            {
                if (match.HomeTeam.Country == cbHomeTeam.SelectedItem.ToString().Substring(0, cbHomeTeam.SelectedItem.ToString().IndexOf('(')).Trim())
                {
                    HomeTeamScore.Content = match.HomeTeam.Goals;
                    if (match.AwayTeam.Country == MySettings.AwayTeam)
                    {
                        AwayTeamScore.Content = match.AwayTeam.Goals;
                        return;
                    }
                }
            }
        }

        private void SetChosenRepresentation()
        {
            try
            {
                Repository.LoadChoices();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MainWindow_SetChosenRepresentation");
            }
            foreach (var representation in representations)
            {
                if (representation.Country == MySettings.HomeTeam.ToString().Substring(0, MySettings.HomeTeam.ToString().IndexOf('(')).Trim() || String.IsNullOrEmpty(MySettings.HomeTeam))
                {
                    cbHomeTeam.Text = MySettings.HomeTeam;
                }
                else
                {
                    cbHomeTeam.SelectedIndex = 0;
                }
            }
        }










        private void cbHomeTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FillAwayTeamDdl();
            LoadHomeTeamPlayers();
        }

        private void cbAwayTeam_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                File.WriteAllText(FileConstants.CHOOSEN_REPRESENTATION, string.Empty);
                Repository.SaveChoices(FileConstants.CHOOSEN_REPRESENTATION, cbHomeTeam.SelectedItem.ToString(), cbAwayTeam.SelectedItem.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Your choices couldn't be saved.");
            }
            Repository.LoadChoices();
            LoadAwayTeamPlayers();
            SetScores();
        }

        private void MoreAwayTeamButton_Click(object sender, RoutedEventArgs e)
        {
            if (cbAwayTeam.SelectedItem == null)
            {
                return;
            }
            CheckIfTableHeaderEmpty(tableAwayTeam.Content);
        }


        private void MoreHomeTeamButton_Click(object sender, RoutedEventArgs e)
        {
            CheckIfTableHeaderEmpty(tableHomeTeam.Content);
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            new Settings().Show();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CheckIfTableHeaderEmpty(object tableHeader)
        {
            string s = (string)tableHeader;
            representationName = s.Contains("(") ? s.Substring(0, cbHomeTeam.Text.IndexOf('(')).Trim() : s;
            if (String.IsNullOrEmpty((string)tableHeader)) return;

            new Representation(representationName).Show();
        }

        
    }
}
