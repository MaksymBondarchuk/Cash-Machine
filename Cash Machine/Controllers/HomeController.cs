using System.Web.Mvc;
using Cash_Machine.Models;

namespace Cash_Machine.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult CardNumber()
        {
            var card = new Card();
            return View(card);
        }

        [HttpPost]
        public ActionResult CardNumber(Card card)
        {
            return View();
        }

        public ActionResult Pin()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}