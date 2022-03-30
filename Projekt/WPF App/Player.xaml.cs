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
using System.Windows.Shapes;
using WPF_App.Factory;
using WPF_App.ViewModels;

namespace WPF_App
{
    /// <summary>
    /// Interaction logic for Player.xaml
    /// </summary>
    public partial class Player : Window
    {
        private StartingElevenViewModel startingEleven;
        StartingEleven se;
            
        public Player(StartingEleven se)
        {
            InitializeComponent();
            this.se = se;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            startingEleven = new StartingElevenFactory().GetStartingEleven(se);
            this.DataContext = startingEleven;
        }
    }
}
