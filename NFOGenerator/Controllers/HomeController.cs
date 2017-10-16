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
            string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetTempFileName());
            path = System.IO.Path.ChangeExtension(path, "nfo");

            file.SaveAs(path);

            string data = System.IO.File.ReadAllText(path);
                        

            return View();
        }
    }
}