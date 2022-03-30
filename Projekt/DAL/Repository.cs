using DAL.Constants;
using DAL.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public static class Repository
    {
        public const char SEPARATOR = ',';

        public static void LoadLanguageAndChampionship()
        {
            if (!File.Exists(FileConstants.SETTINGS_PATH))
            {
                return;
            }

            string[] lines = File.ReadAllLines(FileConstants.SETTINGS_PATH);


            MySettings.Language = lines[0];  //String.IsNullOrEmpty(lines[0]) ? "English" : lines[0];
            MySettings.Championship = lines[1];  //String.IsNullOrEmpty(lines[1]) ? "female" : lines[1];
            MySettings.Culture = lines[2]; //String.IsNullOrEmpty(lines[2]) ? "en" : lines[2];
        }

        public static void SaveChoices(string path, params string[] parameters)
        {
            using (StreamWriter writer = File.AppendText(path))
            {
                foreach (var item in parameters)
                {
                    writer.WriteLine(item);
                }
            }
        }

        public static void LoadFavourites()
        {
            if (!File.Exists(FileConstants.FAVOURITES_PATH))
            {
                return;
            }

            MySettings.Favourites = File.ReadAllLines(FileConstants.FAVOURITES_PATH).ToHashSet();
        }

        public static void LoadChoices()
        {
            if (!File.Exists(FileConstants.CHOOSEN_REPRESENTATION))
            {
                return;
            }

            string[] lines = File.ReadAllLines(FileConstants.CHOOSEN_REPRESENTATION);

            MySettings.HomeTeam = lines[0];
            MySettings.AwayTeam = lines[1];

        }




        public static Task<List<T>> LoadJson<T>(string filePath, string url)
        {
            return Task.Run(() =>
            {
                if (File.Exists(filePath))
                {
                    return ReadFromFile<T>(filePath);
                }
                else
                {
                    return ReadFromWeb<T>(url);
                }
            });
        }

        private static List<T> ReadFromWeb<T>(string url)
        {
            var apiClient = new RestClient(url);
            var apiResult = apiClient.Execute<List<T>>(new RestRequest());

            return JsonConvert.DeserializeObject<List<T>>(apiResult.Content);
        }

        private static List<T> ReadFromFile<T>(string filePath)
        {
            List<T> list;
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                list = JsonConvert.DeserializeObject<List<T>>(json);
            }
            return list;
        }
    }
}
