using DAL;
using DAL.Constants;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Windows_Forms_Aplication
{
    public partial class Player : UserControl
    {

        public List<Player> selectedCards = new List<Player>();

        public bool isSelected = false;
        public bool hasImage = false;
        public string imagePath;

        public static StartingEleven StartingEleven { get; private set; }
        public string FirstName { get; set; }
        public Player(StartingEleven se)
        {
            InitializeComponent();
            SetData(se);
        }

        private void SetData(StartingEleven se)
        {
            //Bitmap image = new Bitmap(imagePath);
            lblName.BringToFront();
            lblName.Text = FirstName = se.Name.ToUpper();
            lblPosition.Text = se.Position.ToString();
            lblFavourite.Text = isSelected ? "Yes" : "No";
            lblCaptain.Text = se.Captain ? "Yes" : "No";
            lblNumber.Text = se.ShirtNumber.ToString();
            //playerPicture.Image = hasImage ? image : Properties.Resources.PlayerLogo;
            label1.Text = imagePath;
        }


        public void SelectedEffects()
        {
            lblFavourite.Text = isSelected ? "Yes" : "No";
            pbFavourite.Visible = isSelected ? true : false;
        }

        private void btnPicture_Click(object sender, EventArgs e)
        {
            ChangeImage();
        }

        private void ChangeImage()
        {
            try
            {
                ChangePictureForm f = new ChangePictureForm(pbPicture);
                f.StartPosition = FormStartPosition.CenterScreen;

                if (f.ShowDialog() == DialogResult.OK)
                {
                    PictureBox pb = f.GetUpdatedPicture();
                    pbPicture.Image = pb.Image;
                    imagePath = f.imagePath;
                }
            }
            catch (System.Exception)
            {
                MessageBox.Show("Picture can't be loaded");
            }
        }

        public void SaveInfo()
        {
            Repository.SaveChoices(FileConstants.FAVOURITES_PATH, lblName.Text);
        }

        private void Player_MouseDown(object sender, MouseEventArgs e)
        {
            Player Player = sender as Player;
            selectedCards.Add(Player);
            foreach (var item in selectedCards)
            {
                DoDragDrop(item, DragDropEffects.Move);
                SelectedEffects();
            }
        }
    }
}
