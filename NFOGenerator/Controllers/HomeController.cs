using System.Linq;
using System.Web.Mvc;
using Services;
using NFOGenerator.Models;
using Services.Model;

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
        public ActionResult Index(SteamViewModel model)
        {
            string nfo = null;

            if (model.File != null && model.File.ContentLength > 0)
            {
                string path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetTempFileName());
                path = System.IO.Path.ChangeExtension(path, "nfo");

                model.File.SaveAs(path);

                nfo = System.IO.File.ReadAllText(path);
                System.IO.File.Delete(path);
            } else if (!string.IsNullOrWhiteSpace(model.Text))
            {
                nfo = model.Text;
            }

            if (string.IsNullOrWhiteSpace(nfo))
            {
                ModelState.AddModelError("Error", "Must provide a file or put nfo content in textarea !");
                return View();
            }

            string data = nfo.RemoveNonAscii();         

            string steamUrl = SteamManager.ExtractUrlFromString(data)?.TrimEnd('/');
            if (string.IsNullOrWhiteSpace(steamUrl))
            {
                ModelState.AddModelError("Error", "No steam url is found !");
                return View();
            }

            var steamId = steamUrl.Split('/').Last();
            SteamModel sm = SteamManager.LoadGameById(steamId);

            model.Result = sm.Data.Detailed_description;

            return View(model);
        }
    }
}