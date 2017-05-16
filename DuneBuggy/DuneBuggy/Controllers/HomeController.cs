using System.Web.Mvc;

namespace DuneBuggy.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About us.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us.";

            return View();
        }
    }
}