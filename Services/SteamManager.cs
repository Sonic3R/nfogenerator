using Newtonsoft.Json;
using Services.Model;
using System;
using System.Net.Http;

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
            HttpClient cl = new HttpClient();
            string data = cl.GetStringAsync(uri).Result;

            string firstElem = string.Format("\"{0}\"", steamId) + ":{";
            string modifiedData = data.Replace(firstElem, "");
            modifiedData = modifiedData.Substring(0, modifiedData.Length - 1);

            return JsonConvert.DeserializeObject<SteamModel>(modifiedData);
        }
    }
}
