using System.Collections.Generic;

namespace Services.Music
{
    public sealed class SfhParser : FileParser
    {
        private const string COMMON_PATTERN = @"\.{0,10}:\s(.*)";
        private static string ARTIST_PATTERN = @"ARTIST" + COMMON_PATTERN;
        private static string TITLE_PATTERN = @"TiTLE" + COMMON_PATTERN;
        private static string GENRE_PATTERN = @"GENRE" + COMMON_PATTERN;
        private static string QUALITY_PATTERN = @"QUALITY" + COMMON_PATTERN;
        private static string LENGTH_PATTERN = @"RUNTIME" + COMMON_PATTERN;
        private static string TRACKLIST_PATTERN = @"(\d{1,3})\.+\s(.*)";

        public SfhParser(string filePath) : base(filePath)
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
