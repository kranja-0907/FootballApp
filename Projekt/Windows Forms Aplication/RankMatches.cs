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
    public partial class RankMatches : UserControl
    {
        public static BasicInfo BasicInfo { get; private set; }
        public long Attendance { get; private set; }
        public string Stadion { get; private set; }
        public long Visitors { get; private set; }
        public string HomeTeam { get; private set; }
        public string AwayTeam { get; private set; }
        public RankMatches(BasicInfo info)
        {
            InitializeComponent();
            SetData(info);
        }

        private void SetData(BasicInfo info)
        {
            lblLocation.Text = info.Location;
            lblVisitors.Text = info.Attendance.ToString();
            Attendance = info.Attendance;
            lblHomeTeam.Text = info.HomeTeam.Country;
            lblAwayTeam.Text = info.AwayTeam.Country;
        }
    }
}
