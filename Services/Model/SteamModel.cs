using Newtonsoft.Json;

namespace Services.Model
{
    public class SteamModel
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("steam_appid")]
        public int Steam_appid { get; set; }

        [JsonProperty("required_age")]
        public int Required_age { get; set; }

        [JsonProperty("is_free")]
        public bool Is_free { get; set; }

        [JsonProperty("controller_support")]
        public string Controller_support { get; set; }

        [JsonProperty("success")]
        public int[] Dlc { get; set; }

        [JsonProperty("detailed_description")]
        public string Detailed_description { get; set; }

        [JsonProperty("about_the_game")]
        public string About_the_game { get; set; }

        [JsonProperty("short_description")]
        public string Short_description { get; set; }

        [JsonProperty("supported_languages")]
        public string Supported_languages { get; set; }

        [JsonProperty("header_image")]
        public string Header_image { get; set; }

        [JsonProperty("website")]
        public string Website { get; set; }

        [JsonProperty("pc_requirements")]
        public Pc_Requirements Pc_requirements { get; set; }

        [JsonProperty("mac_requirements")]
        public Pc_Requirements Mac_requirements { get; set; }

        [JsonProperty("linux_requirements")]
        public Pc_Requirements Linux_requirements { get; set; }

        [JsonProperty("developers")]
        public string[] Developers { get; set; }

        [JsonProperty("publishers")]
        public string[] Publishers { get; set; }

        [JsonProperty("price_overview")]
        public Price_Overview Price_overview { get; set; }

        [JsonProperty("packages")]
        public int[] Packages { get; set; }

        [JsonProperty("package_groups")]
        public Package_Groups[] Package_groups { get; set; }

        [JsonProperty("platforms")]
        public Platforms Platforms { get; set; }

        [JsonProperty("metacritic")]
        public Metacritic Metacritic { get; set; }

        [JsonProperty("categories")]
        public Category[] Categories { get; set; }

        [JsonProperty("genres")]
        public Genre[] Genres { get; set; }

        [JsonProperty("screenshots")]
        public Screenshot[] Screenshots { get; set; }

        [JsonProperty("movies")]
        public Movie[] Movies { get; set; }

        [JsonProperty("recommendations")]
        public Recommendations Recommendations { get; set; }

        [JsonProperty("achievements")]
        public Achievements Achievements { get; set; }

        [JsonProperty("release_date")]
        public Release_Date Release_date { get; set; }

        [JsonProperty("support_info")]
        public Support_Info Support_info { get; set; }

        [JsonProperty("background")]
        public string Background { get; set; }
    }

    public class Pc_Requirements
    {
        [JsonProperty("minimum")]
        public string Minimum { get; set; }
    }

    public class Price_Overview
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("initial")]
        public int Initial { get; set; }

        [JsonProperty("final")]
        public int Final { get; set; }

        [JsonProperty("discount_percent")]
        public int Discount_percent { get; set; }
    }

    public class Platforms
    {
        [JsonProperty("windows")]
        public bool Windows { get; set; }

        [JsonProperty("mac")]
        public bool Mac { get; set; }

        [JsonProperty("linux")]
        public bool Linux { get; set; }
    }

    public class Metacritic
    {
        [JsonProperty("score")]
        public int Score { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Recommendations
    {
        [JsonProperty("total")]
        public int Total { get; set; }
    }

    public class Achievements
    {
        [JsonProperty("total")]
        public int Total { get; set; }

        [JsonProperty("highlighted")]
        public Highlighted[] Highlighted { get; set; }
    }

    public class Highlighted
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("path")]
        public string Path { get; set; }
    }

    public class Release_Date
    {
        [JsonProperty("coming_soon")]
        public bool Coming_soon { get; set; }

        [JsonProperty("date")]
        public string Date { get; set; }
    }

    public class Support_Info
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }

    public class Package_Groups
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("selection_text")]
        public string Selection_text { get; set; }

        [JsonProperty("save_text")]
        public string Save_text { get; set; }

        [JsonProperty("display_type")]
        public int Display_type { get; set; }

        [JsonProperty("is_recurring_subscription")]
        public string Is_recurring_subscription { get; set; }

        [JsonProperty("subs")]
        public Sub[] Subs { get; set; }
    }

    public class Sub
    {
        [JsonProperty("packageid")]
        public int Packageid { get; set; }

        [JsonProperty("percent_savings_text")]
        public string Percent_savings_text { get; set; }

        [JsonProperty("percent_savings")]
        public int Percent_savings { get; set; }

        [JsonProperty("option_text")]
        public string Option_text { get; set; }

        [JsonProperty("option_description")]
        public string Option_description { get; set; }

        [JsonProperty("can_get_free_license")]
        public string Can_get_free_license { get; set; }

        [JsonProperty("is_free_license")]
        public bool Is_free_license { get; set; }

        [JsonProperty("price_in_cents_with_discount")]
        public int Price_in_cents_with_discount { get; set; }
    }

    public class Category
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Genre
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Screenshot
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("path_thumbnail")]
        public string Path_thumbnail { get; set; }

        [JsonProperty("path_full")]
        public string Path_full { get; set; }
    }

    public class Movie
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty("webm")]
        public Webm Webm { get; set; }

        [JsonProperty("highlight")]
        public bool Highlight { get; set; }
    }

    public class Webm
    {
        [JsonProperty("_480")]
        public string Size_480 { get; set; }

        [JsonProperty("max")]
        public string Max { get; set; }
    }

}
