using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public static class MySettings
    {
        public static string Language { get; set; }
        public static string Championship { get; set; }
        public static string Culture { get; set; }
        public static string Team { get; set; }
        public static string PlayerImagePath { get; set; }
        public static HashSet<string> Favourites { get; set; }
        public static string Resolution { get; set; }
        public static string WindowState { get; set; }
        public static string AwayTeam { get; set; }
        public static string HomeTeam { get; set; }

    }
}
