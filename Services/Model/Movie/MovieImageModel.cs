using Newtonsoft.Json;

namespace Services.Model.Movie
{
    public class MovieImageModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("backdrops")]
        public Backdrop[] Backdrops { get; set; }

        [JsonProperty("posters")]
        public Poster[] Posters { get; set; }
    }

    public class Backdrop
    {
        [JsonProperty("aspect_ratio")]
        public float Aspect_ratio { get; set; }

        [JsonProperty("file_path")]
        public string File_path { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("iso_639_1")]
        public string Iso_639_1 { get; set; }

        [JsonProperty("vote_average")]
        public float Vote_average { get; set; }

        [JsonProperty("vote_count")]
        public int Vote_count { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        public string FullPath => $"https://image.tmdb.org/t/p/original/{File_path.TrimStart('/')}";
    }

    public class Poster
    {
        [JsonProperty("aspect_ratio")]
        public float Aspect_ratio { get; set; }

        [JsonProperty("file_path")]
        public string File_path { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("iso_639_1")]
        public string Iso_639_1 { get; set; }

        [JsonProperty("vote_average")]
        public float Vote_average { get; set; }

        [JsonProperty("vote_count")]
        public int Vote_count { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        public string FullPath => $"https://image.tmdb.org/t/p/original/{File_path.TrimStart('/')}";
    }
}
