using System.Collections.Generic;

namespace Services.Music
{
    public sealed class Bb8Parser : FileParser
    {
        private const string COMMON_PATTERN = @"\s+:\s(.*)";
        private static string ARTIST_PATTERN = @"Artist" + COMMON_PATTERN;
        private static string TITLE_PATTERN = @"Label" + COMMON_PATTERN;
        private static string GENRE_PATTERN = @"Genre" + COMMON_PATTERN;
        private static string QUALITY_PATTERN = @"Quality" + COMMON_PATTERN;
        private static string LENGTH_PATTERN = @"Total:(.*)";
        private static string TRACKLIST_PATTERN = @"Tracklist\s+:[\r\n]+(\d{1,3})\-+(.*)";

        public Bb8Parser(string filePath) : base(filePath)
        {
        }

        protected override Dictionary<string, string> RegexDict => new Dictionary<string, string>
        {
            { "artist",  ARTIST_PATTERN },
            { "title", TITLE_PATTERN },
            { "genre", GENRE_PATTERN },
            { "length", LENGTH_PATTERN },
            { "tracklist", TRACKLIST_PATTERN },
            { "quality", QUALITY_PATTERN }
        };
    }
}
