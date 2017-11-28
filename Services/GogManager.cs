using Newtonsoft.Json;
using Services.Model;
using System;
using System.Net.Http;

namespace Services
{
    public static class GogManager
    {
        private const string API_URL = "http://api.gog.com/products?ids={0}";

        /// <summary>
        /// Load game by id
        /// </summary>
        /// <param name="gogId"></param>
        /// <returns></returns>
        public static GogModel LoadGameById(string gogId)
        {
            if (string.IsNullOrWhiteSpace(gogId))
            {
                throw new ArgumentNullException(nameof(gogId));
            }

            Uri uri = new Uri(string.Format(API_URL, gogId));
            using (HttpClient cl = new HttpClient())
            {
                string data = cl.GetStringAsync(uri).Result;

                string firstElem = string.Format("\"{0}\"", gogId) + ":{";
                string modifiedData = data.Replace(firstElem, "");
                modifiedData = modifiedData.Substring(0, modifiedData.Length - 1);

                return JsonConvert.DeserializeObject<GogModel>(modifiedData);
            }
        }
    }
}
