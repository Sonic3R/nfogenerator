using System.Collections.Generic;

namespace Services.Music
{
    public sealed class DhParser : FileParser
    {
        private static string ARTIST_PATTERN = @"artist\s+:\s(.*)";
        private static string TITLE_PATTERN = @"title\s+\.\s(.*)";
        private static string GENRE_PATTERN = @"genre\s+\:\s(.*)";
        private static string QUALITY_PATTERN = @"quality\s+\:\s(.*)";
        private static string LENGTH_PATTERN = @"(.*) (min)";
        private static string TRACKLIST_PATTERN = @"\W{1,100}\[trax\]\W{1,100}\s\W{1,100}[\r\n]+\s+(\d{1,3})\.(.*)";

        public DhParser(string filePath) : base(filePath)
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
