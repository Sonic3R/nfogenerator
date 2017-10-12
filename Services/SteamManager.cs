using Newtonsoft.Json;
using Services.Model;
using System;
using System.Net;

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

            using(WebClient cl = new WebClient())
            {
                Uri uri = new Uri(string.Format(API_URL, steamId));

                string data = cl.DownloadStringTaskAsync(uri).Result;

                return JsonConvert.DeserializeObject<SteamModel>(data);
            }
        }
    }
}
