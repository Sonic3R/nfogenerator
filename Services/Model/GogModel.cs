using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Model
{
    public sealed class GogModel
    {

        public Data[] DataList { get; set; }

        public class Data
        {
            public int id { get; set; }
            public string title { get; set; }
            public string purchase_link { get; set; }
            public string slug { get; set; }
            public Content_System_Compatibility content_system_compatibility { get; set; }
            public Languages languages { get; set; }
            public Links links { get; set; }
            public In_Development in_development { get; set; }
            public bool is_secret { get; set; }
            public bool is_installable { get; set; }
            public string game_type { get; set; }
            public bool is_pre_order { get; set; }
            public DateTime release_date { get; set; }
            public Images images { get; set; }
            public object[] dlcs { get; set; }
        }

        public class Content_System_Compatibility
        {
            public bool windows { get; set; }
            public bool osx { get; set; }
            public bool linux { get; set; }
        }

        public class Languages
        {
            public string cz { get; set; }
            public string de { get; set; }
            public string en { get; set; }
            public string es { get; set; }
            public string fr { get; set; }
            public string hu { get; set; }
            public string it { get; set; }
            public string pl { get; set; }
            public string ru { get; set; }
        }

        public class Links
        {
            public string purchase_link { get; set; }
            public string product_card { get; set; }
            public string support { get; set; }
            public string forum { get; set; }
        }

        public class In_Development
        {
            public bool active { get; set; }
            public object until { get; set; }
        }

        public class Images
        {
            public string background { get; set; }
            public string logo { get; set; }
            public string logo2x { get; set; }
            public string icon { get; set; }
            public string sidebarIcon { get; set; }
            public string sidebarIcon2x { get; set; }
            public string menuNotificationAv { get; set; }
            public string menuNotificationAv2 { get; set; }
        }

    }
}
