using System.Collections.Generic;

namespace Services.Music
{
    public sealed class TalionParser : FileParser
    {
        private const string COMMON_PATTERN = @"\.{1,10}\s:\s(.*)";
        private static string ARTIST_PATTERN = @"ARTiST" + COMMON_PATTERN;
        private static string TITLE_PATTERN = @"TiTLE" + COMMON_PATTERN;
        private static string GENRE_PATTERN = @"GENRE" + COMMON_PATTERN;
        private static string LENGTH_PATTERN = @"LENGTH" + COMMON_PATTERN;
        private static string QUALITY_PATTERN = @"QUALiTY" + COMMON_PATTERN;        
        private static string TRACKLIST_PATTERN = @"(\d{1,3})+\.\s+(.*?)\s+(.*)";

        protected override Dictionary<string, string> RegexDict => new Dictionary<string, string>
        {
            { "artist",  ARTIST_PATTERN },
            { "title", TITLE_PATTERN },
            { "genre", GENRE_PATTERN },
            { "length", LENGTH_PATTERN },
            { "tracklist", TRACKLIST_PATTERN },
            { "quality", QUALITY_PATTERN }
        };

        public TalionParser(string filePath) : base(filePath)
        {
        }
    }
}
