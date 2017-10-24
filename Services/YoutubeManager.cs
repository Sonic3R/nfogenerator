using System;
using System.Collections.Generic;
using YoutubeSearch;
using System.Linq;

namespace Services
{
    public static class YoutubeManager
    {
        private static string[] invalidSystems = new []{ "xbox", "ps4", "ps3", "playstation", "play station" };

        public static string GetVideoByKeyword(string keyword)
        {
            VideoSearch videoSearch = new VideoSearch();
            List<VideoInformation> result = videoSearch.SearchQuery(keyword, 1);

            if (result.Count == 0)
            {
                if (keyword.IndexOf("trailer", StringComparison.InvariantCultureIgnoreCase) == -1)
                {
                    return GetVideoByKeyword($"{keyword} gameplay");
                }

                return string.Empty;
            }

            Func<VideoInformation, bool> filterVideoTitle = (v) =>
            {
                return v.Title.IndexOf("trailer", StringComparison.InvariantCultureIgnoreCase) > -1 || v.Title.IndexOf("gameplay", StringComparison.InvariantCultureIgnoreCase) > -1
                && !invalidSystems.Contains(v.Title.ToLowerInvariant());
            };

            return result.FirstOrDefault(filterVideoTitle)?.Url;
        }
    }
}
