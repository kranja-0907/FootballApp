using DAL;
using DAL.Constants;
using DAL.Enums;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows_Forms_Aplication.Properties;

namespace Windows_Forms_Aplication
{
    public partial class MainForm : Form
    {

        List<RankMatches> matches = new List<RankMatches>();
        HashSet<TeamEvent> players = new HashSet<TeamEvent>();
        List<Representations> representations = new List<Representations>();
        List<BasicInfo> info = new List<BasicInfo>();

        public MainForm()
        {
            LoadSettings();
        }
        //zatvaranje
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                File.WriteAllText(FileConstants.FAVOURITES_PATH, string.Empty);
                File.WriteAllText(FileConstants.CHOOSEN_REPRESENTATION, string.Empty);
                Repository.SaveChoices(FileConstants.CHOOSEN_REPRESENTATION, cbCountries.SelectedItem.ToString(), "Croatia");
                foreach (Player card in pnlFavouritePlayers.Controls)
                {
                    card.SaveInfo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MainForm_Closing");
            }
            Application.Exit();
        }

        //settings
        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<SettingsForm>().Count() == 2)
            {
                Application.OpenForms.OfType<SettingsForm>().First().Close();
            }
            else
            {
                new SettingsForm().Show();

                if (Application.OpenForms.OfType<MainForm>().Count() > 1)
                {
                    Controls.Clear();
                    LoadSettings();                    
                }
            }
        }
        //ucitavanje jezika i punjenje funkcija za punjenje
        private void LoadSettings()
        {
            try
            {
                LoadLanguage();
                FillDdlWithData();
                lblStatus.Text = "To EXIT the application press the escape key.";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "MainForm_LoadSettings");
            }
        }

        //ucitavanje iz jsona i punjenje ddla
        private async void FillDdlWithData()
        {
            pbGif.Visible = true;
            if (MySettings.Championship == Championship.Female.ToString() || MySettings.Championship == Resources.Championship_Female)
            {
                representations = await Repository.LoadJson<Representations>(FileConstants.FEMALE_TEAMS, APIConstants.FEMALE_TEAMS);
            }
            else if (MySettings.Championship == Championship.Male.ToString() || MySettings.Championship == Resources.Championship_Male)
            {
                representations = await Repository.LoadJson<Representations>(FileConstants.MALE_TEAMS, APIConstants.MALE_TEAMS);
            }
            FillDdl();
            
            if (File.Exists(FileConstants.SETTINGS_PATH))
            {
                try
                {
                    Repository.LoadChoices();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "MainForm_LoadChoices");
                }
            }

            cbCountries.Text = MySettings.HomeTeam;
            Thread.Sleep(TimeSpan.FromSeconds(2));
            pbGif.Dispose();
        }

        //puni ddl
        private void FillDdl()
        {
            if (representations == null)
            {
                return;
            }

            foreach (var representation in representations)
            {
                cbCountries.Items.Add(representation.ToString());
            }
            cbCountries.SelectedIndex = 0;
            
        }

        //na promjeni drzave pocisti sve preuzmi dogadaje i ucitavaj
        private async void cbCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlAllPlayers.Controls.Clear();
            pnlPlayerSorter.Controls.Clear();
            pnlFavouritePlayers.Controls.Clear();
            yellowCardsSorter.Checked = false;
            goalsSorter.Checked = false;

            try
            {
                if (MySettings.Championship == Championship.Female.ToString() || MySettings.Championship == Resources.Championship_Female)
                {
                    info = await Repository.LoadJson<BasicInfo>(FileConstants.FEMALE_MATCHES, APIConstants.FEMALE_MATCHES);
                }
                else if (MySettings.Championship == Championship.Male.ToString() || MySettings.Championship == Resources.Championship_Male)
                {
                    info = await Repository.LoadJson<BasicInfo>(FileConstants.MALE_MATCHES, APIConstants.MALE_MATCHES);
                }
                FillAllPlayersPanel();
                FillSortingLists();
                CheckIfFavourite();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CheckIfFavourite()
        {
            Repository.LoadFavourites();
            foreach (Player card in pnlAllPlayers.Controls)
            {
                foreach (var favourite in MySettings.Favourites)
                {
                    if (card.FirstName == favourite)
                    {
                        pnlFavouritePlayers.Controls.Add(card);
                        pnlAllPlayers.Controls.Remove(card);
                        card.isSelected = true;
                        card.SelectedEffects();
                        card.imagePath = MySettings.PlayerImagePath;
                    }
                }
            }
        }

        //puni sve igrace
        private void FillAllPlayersPanel()
        {
            pnlAllPlayers.Controls.Clear();
            pnlFavouritePlayers.Controls.Clear();
            foreach (var i in info)
            {
                if (i.HomeTeamStatistics.Country == cbCountries.Text.Substring(0, cbCountries.Text.IndexOf('(')).Trim())
                {
                    foreach (var team in i.HomeTeamStatistics.StartingEleven)
                    {
                        pnlAllPlayers.Controls.Add(new Player(team));
                    }
                    foreach (var team in i.HomeTeamStatistics.Substitutes)
                    {
                        pnlAllPlayers.Controls.Add(new Player(team));
                    }
                    return;
                }
            }
        }

        //sorting lista i stadioni
        private void FillSortingLists()
        {
            fillPlayerSorter();
            fillMatches();
        }

        
        private void fillMatches()
        {
            pnlMatchSorter.Controls.Clear();
            matches.Clear();
            foreach (var i in info)
            {
                //ako je zemlja jednaka mom ddlu a igra doma ili u gostima popuni listu matcheva
                if (i.HomeTeam.Country == cbCountries.Text.Substring(0, cbCountries.Text.IndexOf('(')).Trim() || i.AwayTeam.Country == cbCountries.Text.Substring(0, cbCountries.Text.IndexOf('(')).Trim())
                {
                    matches.Add(new RankMatches(i));
                }
            }

            //sortiraj i prikazi matcheve
            IEnumerable<RankMatches> rankedMatches = matches.OrderBy(m => -m.Attendance).ToList();
            foreach (var item in rankedMatches)
            {
                pnlMatchSorter.Controls.Add(item);
            }
        }


        private void fillPlayerSorter()
        {
            players.Clear();
            pnlPlayerSorter.Controls.Clear();
            foreach (var i in info)
            {
                //ako je trenutna zemlja jednaka ddlu prodi po 
                if (i.HomeTeamStatistics.Country == cbCountries.Text.Substring(0, cbCountries.Text.IndexOf('(')).Trim())
                {
                    foreach (var player in i.HomeTeamEvents)
                    {
                        foreach (var eleven in i.HomeTeamStatistics.StartingEleven)
                        {
                            if (player.Player == eleven.Name)
                            {
                                switch (player.TypeOfEvent)
                                {
                                    case "goal":
                                        players.Add(player);
                                        break;
                                    case "yellow-card":
                                        players.Add(player);
                                        break;
                                }
                            }
                        }
                    }
                }
            }

            foreach (var i in info)
            {
                foreach (var player in i.HomeTeamEvents)
                {
                    foreach (var p in players)
                    {
                        if (player.Player == p.Player && player.TypeOfEvent == "goal")
                        {
                            p.NumberOfGoals++;
                        }
                        if (player.Player == p.Player && player.TypeOfEvent == "yellow-card")
                        {
                            p.YellowCards++;
                        }
                    }
                }
                foreach (var player in i.AwayTeamEvents)
                {
                    foreach (var p in players)
                    {
                        if (player.Player == p.Player && player.TypeOfEvent == "goal")
                        {
                            p.NumberOfGoals++;
                        }
                        if (player.Player == p.Player && player.TypeOfEvent == "yellow-card")
                        {
                            p.YellowCards++;
                        }
                    }
                }
            }
        }

        //ucitavanje jezika
        private void LoadLanguage()
        {
            InitializeComponent();
            Repository.LoadLanguageAndChampionship();
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(MySettings.Culture);
        }







        private void chooseAPrinterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog.ShowDialog();
        }

        private void pagePreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printPreviewDialog.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            if (pnlAllPlayers.Controls.Count == 0)
            {
                return;
            }

            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            int x = 50;
            int y = 100;
            foreach (Player item in pnlAllPlayers.Controls)
            {
                string fName = item.FirstName;
                string data = "Full Name : \t" + fName;
                e.Graphics.DrawString(data, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, x, y+=25);
            }
            foreach (var item in matches)
            {
                var data = $"Location: {item.Stadion}, Visitors: {item.Attendance}, Home team: {item.HomeTeam}, Away team: {item.AwayTeam}";
                e.Graphics.DrawString(data, new Font("Arial", 20, FontStyle.Regular), Brushes.Black, x, y += 25);
            }
        }

        private void yellowCardsSorter_Click(object sender, EventArgs e)
        {
            pnlPlayerSorter.Controls.Clear();
            switch (yellowCardsSorter.CheckState)
            {
                case CheckState.Checked:
                    goalsSorter.Checked = false;
                    foreach (var item in players.OrderBy(p => -p.YellowCards))
                    {
                        pnlPlayerSorter.Controls.Add(new RankPlayer(item));
                    }
                    break;
                case CheckState.Unchecked:
                    pnlPlayerSorter.Controls.Clear();
                    break;
            }
        }

        private void goalsSorter_Click(object sender, EventArgs e)
        {
            pnlPlayerSorter.Controls.Clear();
            switch (goalsSorter.CheckState)
            {
                case CheckState.Checked:
                    yellowCardsSorter.Checked = false;
                    foreach (var item in players.OrderBy(p => -p.NumberOfGoals))
                    {
                        pnlPlayerSorter.Controls.Add(new RankPlayer(item));
                    }
                    break;
                case CheckState.Unchecked:
                    pnlPlayerSorter.Controls.Clear();
                    break;
            }
        }


        //ako je kontrola iznad allplayersa a dosla iz favorita
        private void pnlAllPlayers_DragDrop(object sender, DragEventArgs e)
        {
            var playerCard = (Player)e.Data.GetData(typeof(Player));

            if (playerCard.Parent == pnlFavouritePlayers)
            {
                playerCard.isSelected = false;
                pnlAllPlayers.Controls.Add(playerCard);
            }
        }

        //ako je ikona iznad favourite playersa dodaj a dosla iz allplayersa
        private void pnlFavouritePlayers_DragDrop(object sender, DragEventArgs e)
        {
            var playerCard = (Player)e.Data.GetData(typeof(Player));

            if (pnlFavouritePlayers.Controls.Count > 2)
            {
                lblStatus.Text = "You can only have 3 favourite players!";
                return;
            }
            else
            {
                lblStatus.Text = "To EXIT the application press the escape key.";
            }

            if (playerCard.Parent == pnlAllPlayers)
            {
                playerCard.isSelected = true;
                pnlFavouritePlayers.Controls.Add(playerCard);
            }
            else
            {
                playerCard.isSelected = false;
            }
        }
        //ikona
        private void pnlAllPlayers_DragEnter(object sender, DragEventArgs e)
        {
            if (e.KeyState == 1)
            {
                e.Effect = DragDropEffects.Move;
            }
        }
        //ikona
        private void pnlFavouritePlayers_DragEnter(object sender, DragEventArgs e)
        {
            if (e.KeyState == 1)
            {
                e.Effect = DragDropEffects.Move;
            }
        }
        //gumbi
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                new ClosingPopUp().Show();
            }
        }
    }
}
