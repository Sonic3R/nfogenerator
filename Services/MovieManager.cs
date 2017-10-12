using Newtonsoft.Json;
using Services.Model;
using System;
using System.Net.Http;
using System.Linq;

namespace Services
{
    public static class MovieManager
    {
        private const string API_KEY_V3 = "8554b62674d8e933e6674cf43ef79e41";
        private const string API_KEY_V4 = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJhdWQiOiI4NTU0YjYyNjc0ZDhlOTMzZTY2NzRjZjQzZWY3OWU0MSIsInN1YiI6IjU5ZGYzODdiOTI1MTQxMjRlYjA5ZTRkYyIsInNjb3BlcyI6WyJhcGlfcmVhZCJdLCJ2ZXJzaW9uIjoxfQ.YhvCiPhUtkUgilxeO5jPEnRTpzfzUMHi5gm7Z62Cr78";

        private const string MOVIE_URL = "https://api.themoviedb.org/3/movie/{0}?api_key={1}";
        private const string IMAGES_URL = "https://api.themoviedb.org/3/movie/{0}/images?api_key={1}";
        private const string VIDEOS_URL = "https://api.themoviedb.org/3/movie/{0}/videos?api_key={1}";

        private const string STATIC_IMAGE_URL = "https://image.tmdb.org/t/p/original/{0}";

        /// <summary>
        /// Load movie data by imdb id
        /// </summary>
        /// <param name="imdbId"></param>
        /// <returns></returns>
        public static MovieModel LoadMovieByImdbId(string imdbId)
        {
            if (string.IsNullOrWhiteSpace(imdbId))
            {
                throw new ArgumentNullException(nameof(imdbId));
            }

            string imdb = imdbId.StartsWith("tt") ? imdbId : string.Concat("tt", imdbId);
            MovieModel movieModel = new MovieModel();

            using (HttpClient cl = new HttpClient())
            {
                string url = string.Format(MOVIE_URL, imdb, API_KEY_V3);

                string movieJson = cl.GetStringAsync(url).Result;
                movieModel.InfoData = JsonConvert.DeserializeObject<Model.Movie.MovieInfoModel>(movieJson);

                movieModel.PosterData = LoadImagesById(cl, imdb);
                movieModel.VideoData = LoadVideosById(cl, imdb);

                return movieModel;
            }
        }

        /// <summary>
        /// Get movie posters/images
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="imdbId"></param>
        /// <returns></returns>
        private static Model.Movie.MovieImageModel LoadImagesById(HttpClient cl, string imdbId)
        {
            string url = string.Format(IMAGES_URL, imdbId, API_KEY_V3);
            string json = cl.GetStringAsync(url).Result;

            return JsonConvert.DeserializeObject<Model.Movie.MovieImageModel>(json);
        }

        /// <summary>
        /// Get movie posters/images
        /// </summary>
        /// <param name="cl"></param>
        /// <param name="imdbId"></param>
        /// <returns></returns>
        private static Model.Movie.MovieVideoModel LoadVideosById(HttpClient cl, string imdbId)
        {
            string url = string.Format(VIDEOS_URL, imdbId, API_KEY_V3);
            string json = cl.GetStringAsync(url).Result;

            return JsonConvert.DeserializeObject<Model.Movie.MovieVideoModel>(json);
        }
    }
}
