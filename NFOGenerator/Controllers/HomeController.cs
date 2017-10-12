using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using NFOGenerator.Helpers;

namespace NFOGenerator.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //SteamModel sm = SteamManager.LoadGameById("346110");
            //MovieModel movie = MovieManager.LoadMovieByImdbId("tt5301662");

            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            string path = @"U:\test.nfo";

            file.SaveAs(path);

            string data = System.IO.File.ReadAllText(path);

            System.IO.File.WriteAllText(path, Regex.Replace(data, @"[^\u0000-\u007F]+", string.Empty));

            return Content(data.RemoveNonAscii());
        }
    }
}