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
    public partial class RankPlayer : UserControl
    {
        public string FullName { get; set; }
        public int Goals { get; set; }
        public int YellowCards { get; set; }
        public Image Image { get; set; }

        public TeamEvent TeamEvent { get; set; }

        public RankPlayer(TeamEvent te)
        {
            InitializeComponent();
            SetData(te);
        }

        public void SetData(TeamEvent te)
        {
            lblName.Text = te.Player;
            lblGoals.Text = te.NumberOfGoals.ToString();
            lblCards.Text = te.YellowCards.ToString();
        }
    }
}
