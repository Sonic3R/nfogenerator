using System.Collections.Generic;

namespace Services.Music
{
    public sealed class R35Parser : FileParser
    {
        private const string COMMON_PATTERN = @"\s+:\s(.*)";
        private static string ARTIST_PATTERN = @"ARTIST" + COMMON_PATTERN;
        private static string TITLE_PATTERN = @"TITLE" + COMMON_PATTERN;
        private static string GENRE_PATTERN = @"GENRE" + COMMON_PATTERN;
        private static string QUALITY_PATTERN = @"BITRATE" + COMMON_PATTERN;
        private static string LENGTH_PATTERN = @"Total:(.*)";
        private static string TRACKLIST_PATTERN = @"Track List[\r\n]+\-+[\r\n]+(\d{1,3})\.+(.*)";

        public R35Parser(string filePath) : base(filePath)
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
