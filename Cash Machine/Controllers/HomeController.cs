using System.Diagnostics;
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
                    return RedirectToAction("Error", new Error
                    {
                        Description = $"Card with number \"{card.Number}\" doesn't exist",
                        PreviousUrl = ControllerContext.RouteData.Values["action"].ToString()
                    });
                return Redirect("/Home/Pin");
                //return View(cards.First());
            }
        }

        public ActionResult Pin()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Error(Error error)
        {
            ViewBag.Message = "Your contact page.";

            return View(error);
        }

        public ActionResult Back()
        {
            Debug.Assert(Request.UrlReferrer != null, "Request.UrlReferrer != null");
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}