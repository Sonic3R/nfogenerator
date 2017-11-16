using System.Collections.Generic;

namespace Services.Music
{
    public sealed class EbmParser : FileParser
    {
        private static string ARTIST_PATTERN = @"\.label\.+:\s(.*)";
        private static string TITLE_PATTERN = @"\.label\.+:\s(.*)";
        private static string GENRE_PATTERN = @"\.genre\.+:\s(.*)";
        private static string QUALITY_PATTERN = @"\.audio\.quality\.+:\s(.*)";
        private static string LENGTH_PATTERN = @"Total:(.*)";
        private static string TRACKLIST_PATTERN = @"Tracklist[\r\n]+[\r\n]+\s+(\d{1,3})\.(.*)";

        public EbmParser(string filePath) : base(filePath)
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
