using Newtonsoft.Json;
using System;

namespace Services.Model
{
    public sealed class GogModel
    {
        public Data[] DataList { get; set; }

        public class Data
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("title")]
            public string Title { get; set; }

            [JsonProperty("purchase_link")]
            public string Purchase_link { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }

            [JsonProperty("content_system_compatibility")]
            public Content_System_Compatibility Content_system_compatibility { get; set; }

            [JsonProperty("in_development")]
            public In_Development In_development { get; set; }

            [JsonProperty("is_secret")]
            public bool Is_secret { get; set; }

            [JsonProperty("is_installable")]
            public bool Is_installable { get; set; }

            [JsonProperty("game_type")]
            public string Game_type { get; set; }

            [JsonProperty("release_date")]
            public DateTime Release_date { get; set; }

            [JsonProperty("id")]
            public Images Images { get; set; }
        }

        public class Content_System_Compatibility
        {
            [JsonProperty("windows")]
            public bool Windows { get; set; }

            [JsonProperty("osx")]
            public bool Osx { get; set; }

            [JsonProperty("linux")]
            public bool Linux { get; set; }
        }

        public class In_Development
        {
            [JsonProperty("active")]
            public bool Active { get; set; }

            [JsonProperty("until")]
            public object Until { get; set; }
        }

        public class Images
        {
            [JsonProperty("background")]
            public string Background { get; set; }

            [JsonProperty("logo")]
            public string Logo { get; set; }

            [JsonProperty("logo2x")]
            public string Logo2x { get; set; }

            [JsonProperty("icon")]
            public string Icon { get; set; }
        }

        public class Dlcs
        {
            [JsonProperty("products")]
            public Product[] Products { get; set; }

            [JsonProperty("all_products_url")]
            public string All_products_url { get; set; }

            [JsonProperty("expanded_all_products_url")]
            public string Expanded_all_products_url { get; set; }
        }

        public class Product
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("link")]
            public string Link { get; set; }

            [JsonProperty("expanded_link")]
            public string Expanded_link { get; set; }
        }
    }
}
