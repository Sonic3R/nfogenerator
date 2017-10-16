using Newtonsoft.Json;
using Services.Model;
using System;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace Services
{
    public static class SteamManager
    {
        private const string API_URL = "http://store.steampowered.com/api/appdetails?appids={0}";

        /// <summary>
        /// Load game by id
        /// </summary>
        /// <param name="steamId"></param>
        /// <returns></returns>
        public static SteamModel LoadGameById(string steamId)
        {
            if (string.IsNullOrWhiteSpace(steamId))
            {
                throw new ArgumentNullException(nameof(steamId));
            }

            Uri uri = new Uri(string.Format(API_URL, steamId));
            using (HttpClient cl = new HttpClient())
            {
                string data = cl.GetStringAsync(uri).Result;

                string firstElem = string.Format("\"{0}\"", steamId) + ":{";
                string modifiedData = data.Replace(firstElem, "");
                modifiedData = modifiedData.Substring(0, modifiedData.Length - 1);

                return JsonConvert.DeserializeObject<SteamModel>(modifiedData);
            }
        }

        /// <summary>
        /// Extract steam url from string
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string ExtractUrlFromString(string str)
        {
            //http://store.steampowered.com/app/686680/Computer_Tycoon/?snr=1_1452_4__103

            if (string.IsNullOrWhiteSpace(str))
            {
                throw new ArgumentNullException(nameof(str));
            }

            string pattern = @"(http(s)?)?(:\/\/)?store\.steampowered\.com/app/(\d+)/?";
            Regex reg = new Regex(pattern);

            Match m = reg.Match(str);
            if (m.Success)
            {
                return m.Value;
            }

            return null;
        }
    }
}
