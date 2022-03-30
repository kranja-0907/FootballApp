using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Constants
{
    public static class APIConstants
    {
        public static string FEMALE_TEAMS = "https://worldcup.sfg.io/teams/results";
        public static string FEMALE_MATCHES = "https://worldcup.sfg.io/matches/country?fifa_code=ENG";
        public static string FEMALE_GROUP_RESULTS = "https://worldcup.sfg.io/teams/results";

        public static string MALE_TEAMS = "https://world-cup-json-2018.herokuapp.com/teams/results";
        public static string MALE_MATCHES = "https://world-cup-json-2018.herokuapp.com/matches/country?fifa_code=ENG";
        public static string MALE_GROUP_RESULTS = "https://world-cup-json-2018.herokuapp.com/teams/results";
    }
}
