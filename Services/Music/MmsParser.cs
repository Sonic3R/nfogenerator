using System.Collections.Generic;

namespace Services.Music
{
    public sealed class MmsParser : FileParser
    {
        private const string COMMON_PATTERN = @"-{1,10}=]-:\s(.*)";
        private static string ARTIST_PATTERN = @"PERFORMER" + COMMON_PATTERN;
        private static string TITLE_PATTERN = @"TITLE" + COMMON_PATTERN;
        private static string GENRE_PATTERN = @"GENRE" + COMMON_PATTERN;
        private static string QUALITY_PATTERN = @"QUALITY" + COMMON_PATTERN;
        private static string LENGTH_PATTERN = @"Playtime\s:\s(.*)";
        private static string TRACKLIST_PATTERN = @"\[\s=\sTracklist\s=\s\]_+[\r\n]+(\d{1,3})\s(.*)";

        public MmsParser(string filePath) : base(filePath)
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
