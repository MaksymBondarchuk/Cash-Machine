using System.Linq;
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
            using (var context = new Cash_x0020_machine_x0020_modelContainer())
            {
                var cards = context.CardSet.Where(c => c.Number == card.Number);
                if (!cards.Any())
                    return HttpNotFound();
                return Redirect("/Home/Pin");
                //return View(cards.First());
            }
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