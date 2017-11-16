using System.Collections.Generic;

namespace Services.Music
{
    public sealed class CueParser : FileParser
    {
        private const string COMMON_PATTERN = @":\s+(.*)";
        private static string ARTIST_PATTERN = @"Artist" + COMMON_PATTERN;
        private static string TITLE_PATTERN = @"Title" + COMMON_PATTERN;
        private static string GENRE_PATTERN = @"Genre" + COMMON_PATTERN;
        private static string QUALITY_PATTERN = @"Quality" + COMMON_PATTERN;
        private static string LENGTH_PATTERN = @"Total:(.*)";
        private static string TRACKLIST_PATTERN = @"Tracklist:[\r\n]+(\d{1,3})\.+(.*)";

        public CueParser(string filePath) : base(filePath)
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
