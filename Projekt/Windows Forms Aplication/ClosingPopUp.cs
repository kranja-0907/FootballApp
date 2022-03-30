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
    public partial class ClosingPopUp : Form
    {
        public ClosingPopUp()
        {
            InitializeComponent();
            InitPopUp();
        }
        private void InitPopUp()
        {
            lblTextInfo.Text = "Are you sure you want to exit the application?\n" +
                                "All changes will be saved.\n" +
                                "For yes press ENTER, for no press ESCAPE.";
            btnNo.TabStop = false;
        }



        private void ClosingPopUp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                Application.Exit();
            }
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
