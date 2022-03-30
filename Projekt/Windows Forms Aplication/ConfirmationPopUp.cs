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
    public partial class ConfirmationPopUp : Form
    {
        public bool isClicked = false;
        public ConfirmationPopUp()
        {
            InitializeComponent();
            InitPopUp();
        }

        private void InitPopUp()
        {
            lblTextInfo.Text = "Are you sure you want to continue with these settings.\n" +
                                "Setting can be changed at any time by pressing the settings tool in the menu strip\n" +
                                "For yes press ENTER, for no press ESCAPE.";
            btnNo.TabStop = false;
        }


        private void ConfirmationPopUp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            if (e.KeyCode == Keys.Enter)
            {
                isClicked = true;
            }
        }


    }
}
