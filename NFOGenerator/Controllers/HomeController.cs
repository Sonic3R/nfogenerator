using Services;
using Services.Model;
using System.Web.Mvc;

namespace NFOGenerator.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //SteamModel sm = SteamManager.LoadGameById("346110");

            return View();
        }
    }
}