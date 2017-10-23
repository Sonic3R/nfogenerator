using System;
using System.Collections.Generic;
using YoutubeSearch;

namespace Services
{
    public static class YoutubeManager
    {
        public static string GetVideoByKeyword(string keyword)
        {
            if(keyword.IndexOf("gameplay", StringComparison.InvariantCultureIgnoreCase) == -1)
            {
                keyword = $"{keyword} gameplay";
            }

            VideoSearch videoSearch = new VideoSearch();
            List<VideoInformation> result = videoSearch.SearchQuery(keyword, 1);

            if(result.Count == 0)
            {
                return string.Empty;
            }

            return result[0].Url;
        }
    }
}
