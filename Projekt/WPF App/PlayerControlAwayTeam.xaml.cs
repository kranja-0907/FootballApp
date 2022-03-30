using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
using WPF_App.ViewModels;

namespace WPF_App
{
    /// <summary>
    /// Interaction logic for PlayerControlAwayTeam.xaml
    /// </summary>
    public partial class PlayerControlAwayTeam : UserControl
    {
        private StartingElevenViewModel startingEleven;
        StartingEleven se;
        public PlayerControlAwayTeam(StartingEleven se)
        {
            InitializeComponent();
            this.se = se;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            startingEleven = new StartingElevenFactory().GetStartingEleven(se);
            this.DataContext = startingEleven;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            new Player(se).Show();
        }
    }
}
