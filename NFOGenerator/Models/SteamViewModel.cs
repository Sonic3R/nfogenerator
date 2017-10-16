using System.Web;

namespace NFOGenerator.Models
{
    public class SteamViewModel
    {
        public HttpPostedFileBase File { get; set; }

        public string Text { get; set; }

        public string Result { get; set; }
    }
}