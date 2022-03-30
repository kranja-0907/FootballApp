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
    public partial class ChangePictureForm : Form
    {
        public string imagePath;
        public ChangePictureForm(PictureBox selectedPicture)
        {
            InitializeComponent();
            InitSetup(selectedPicture);
        }

        private void InitSetup(PictureBox selectedPicture)
        {
            pbPlayerPicture.Image = selectedPicture.Image;
        }

        public PictureBox GetUpdatedPicture()
        {
            return pbPlayerPicture;
        }
        private void btnChangePicture_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Pictures|*.bmp;*.jpg;*.jpeg;*.png;|All files|*.*";
            ofd.InitialDirectory = Application.StartupPath;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbPlayerPicture.ImageLocation = ofd.FileName;
                imagePath = ofd.FileName;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
