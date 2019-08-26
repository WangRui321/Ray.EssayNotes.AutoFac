using System.Web.Mvc;

namespace Ray.EssayNotes.AutoFac.NetFrameworkApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}