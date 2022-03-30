using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Constants
{
    public static class FileConstants
    {
        public static string FEMALE_TEAMS = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Json/femaleTeams.json");
        public static string FEMALE_MATCHES = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Json/femaleMatches.json");
        public static string FEMALE_GROUP_RESULTS = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Json/femaleGroup_results.json");

        public static string MALE_TEAMS = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Json/maleTeams.json");
        public static string MALE_MATCHES = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Json/maleMatches.json");
        public static string MALE_GROUP_RESULTS = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Json/maleGroup_results.json");

        public static string SETTINGS_PATH = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Data/settings.txt");
        public static string FAVOURITES_PATH = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Data/favourites.txt");
        public static string CHOOSEN_REPRESENTATION = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Data/choices.txt");
        public static string AWAY_REPRESENTATION = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "Data/away.txt");
    }
}
