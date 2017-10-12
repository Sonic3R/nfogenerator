using Newtonsoft.Json;

namespace Services.Model.Movie
{
    public class MovieVideoModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("results")]
        public VideoDetails[] Results { get; set; }
    }

    public class VideoDetails
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("iso_639_1")]
        public string Iso_639_1 { get; set; }

        [JsonProperty("iso_3166_1")]
        public string Iso_3166_1 { get; set; }

        // Append to Youtube: https://www.youtube.com/watch?v=below_key
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        // if is Youtube or other
        [JsonProperty("site")]
        public string Site { get; set; }

        [JsonProperty("size")]
        public int Size { get; set; }

        // usually "trailer"
        [JsonProperty("type")]
        public string Type { get; set; }

        public string FullVideoUrl => Site.Equals("youtube", System.StringComparison.OrdinalIgnoreCase) ? $"https://www.youtube.com/watch?v={Key}" : string.Empty;
    }

}
