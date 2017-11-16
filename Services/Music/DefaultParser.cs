﻿using System.Collections.Generic;

namespace Services.Music
{
    public sealed class DefaultParser : FileParser
    {
        private const string COMMON_PATTERN = @"\.+:\s(.*)";
        private static string ARTIST_PATTERN = @"ARTIST" + COMMON_PATTERN;
        private static string TITLE_PATTERN = @"TITLE" + COMMON_PATTERN;
        private static string GENRE_PATTERN = @"GENRE" + COMMON_PATTERN;
        private static string QUALITY_PATTERN = @"QUALITY" + COMMON_PATTERN;
        private static string LENGTH_PATTERN = @"Total:(.*)";
        private static string TRACKLIST_PATTERN = @"Tracklist\s{0,10}:[\r\n]+\-+[\r\n]+(\d{1,3})\.+\s(.*)\s\.+(.*)"; //Tracklist\s{0,10}:[\r\n]+(\d{1,3})\.?\-?(.*)

        public DefaultParser(string filePath) : base(filePath)
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