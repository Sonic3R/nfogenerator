using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace Services.Music
{
    public abstract class FileParser
    {
        private readonly string _filePath;
        private static Dictionary<string, string> _availableScene = new Dictionary<string, string>
        {
            { "TALiON", "talion" },
            { "- d e e p h o u s e -", "dh" },
            { "...Moniti Meliora Sequamur presents:", "mms" },
            { "Electronic Body Music", "ebm" },
            { "WE R 2FAST4U", "fast4u" },
            { "enslave: (verb)", "enslave" },
            { "SOUNDS FROM HEAVEN PROUDLY PRESENTS", "sfh" },
            { "TEAM ZzZz", "zzzz" },
            { "bb8", "bb8" },
            { "cue", "cue" },
            { "r35", "r35" }
        };

        public FileParser(string filePath)
        {
            _filePath = filePath;
        }

        public string Artist { get; protected set; }
        public string Title { get; protected set; }
        public string Genre { get; protected set; }
        public string Length { get; protected set; }
        public string Quality { get; protected set; }
        public List<string> TrackList { get; protected set; }

        public void LoadData()
        {
            string content = GetContent(_filePath);
            if (!string.IsNullOrWhiteSpace(content))
            {
                foreach(var kvp in RegexDict)
                {
                    var regex = new Regex(kvp.Value, RegexOptions.Multiline);

                    if(kvp.Key.Equals("tracklist", StringComparison.OrdinalIgnoreCase))
                    {
                        var matches = regex.Matches(content);
                        List<string> list = new List<string>();

                        foreach(Match match in matches)
                        {
                            StringBuilder sb = new StringBuilder();
                            for(int i = 1; i < match.Groups.Count; i++)
                            {
                                sb.Append(match.Groups[i].Value.Trim() + " ");
                            }

                            list.Add(sb.ToString().Trim());
                        }

                        SetPropByKey(kvp.Key, list);
                    } else
                    {
                        var match = regex.Match(content);
                        SetPropByKey(kvp.Key, match.Groups[1].Value);
                    }
                }
            }
        }

        public bool IsEmpty => string.IsNullOrWhiteSpace(Title) &&
            string.IsNullOrWhiteSpace(Artist) &&
            string.IsNullOrWhiteSpace(Genre) &&
            string.IsNullOrWhiteSpace(Length) &&
            string.IsNullOrWhiteSpace(Quality) &&
            TrackList == null;

        protected abstract Dictionary<string, string> RegexDict { get; }

        public static string GetScene(string filePath)
        {
            var content = GetContent(filePath);
            var filenameWithoutExt = Path.GetFileNameWithoutExtension(filePath);

            foreach(var kvp in _availableScene)
            {
                if (content.IndexOf(kvp.Key, StringComparison.OrdinalIgnoreCase) > -1)
                {
                    return kvp.Value.ToLower();
                }

                if (filenameWithoutExt.EndsWith(kvp.Value))
                {
                    return kvp.Value.ToLower();
                }
            }


            return null;
        }

        private static string GetContent(string filePath)
        {
            return File.ReadAllText(filePath).RemoveNonAscii().Trim();
        }

        private void SetPropByKey(string key, object value)
        {
            switch (key.ToLower())
            {
                case "artist":
                    Artist = value as string;
                    break;

                case "title":
                    Title = value as string;
                    break;

                case "genre":
                    Genre = value as string;
                    break;

                case "length":
                    Length = value as string;
                    break;

                case "tracklist":
                    TrackList = value as List<string>;
                    break;

                case "quality":
                    Quality = value as string;
                    break;
            }
        }
    }
}
