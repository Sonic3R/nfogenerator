using System.Collections.Generic;

namespace Services.Music
{
    public sealed class ZzzzParser : FileParser
    {
        private static string ARTIST_PATTERN = @"Artist:\s(.*)";
        private static string TITLE_PATTERN = @"Title───:\s(.*)";
        private static string GENRE_PATTERN = @"Genre─────:\s(.*)";
        private static string QUALITY_PATTERN = @"Quality──:\s(.*)";
        private static string LENGTH_PATTERN = @"(.*) (min)";
        private static string TRACKLIST_PATTERN = @"Track\s+Title\s+Time[\r\n]+\W+(\d{1,3})\.(.*)";

        public ZzzzParser(string filePath) : base(filePath)
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
