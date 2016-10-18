using System;
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
            Session["CardId"] = null;
            return View(card);
        }

        [HttpPost]
        public ActionResult CardNumber(Card card)
        {
            using (var context = new CashMachineContext())
            {
                var cards = context.Cards.Where(c => !c.IsBlocked && c.Number == card.Number);
                if (!cards.Any())
                    return RedirectToAction("Error", new Error
                    {
                        Description = $"Card with number \"{card.Number}\" doesn't exist or blocked",
                        PreviousUrl = ControllerContext.RouteData.Values["action"].ToString()
                    });
                Session["PinTries"] = -1;
                Session["CardId"] = cards.First().Id;
                return RedirectToAction("Pin", cards.First());
            }
        }

        public ActionResult Pin(Card card)
        {
            var triesNumber = (int)Session["PinTries"];
            Session["PinTries"] = triesNumber + 1;
            if (triesNumber == -1)
                return View(card);

            using (var context = new CashMachineContext())
            {
                var dbCard = context.Cards.SingleOrDefault(c => c.Id == card.Id);
                if (dbCard == null)
                    return new HttpStatusCodeResult(500);

                if (card.Password == dbCard.Password)
                    return RedirectToAction("Operations");

                if (triesNumber == 4)
                {
                    dbCard.IsBlocked = true;
                    context.SaveChanges();

                    return RedirectToAction("Error", new Error
                    {
                        Description = "You entered wrong PIN for 4 times. Card is blocked",
                        PreviousUrl = "CardNumber" // Back button will be used as exit button
                    });
                }
                Session["PinTries"] = triesNumber + 1;
                return View(card);
            }
        }

        public ActionResult Error(Error error)
        {
            return View(error);
        }

        public ActionResult Back()
        {
            Debug.Assert(Request.UrlReferrer != null, "Request.UrlReferrer != null");
            return Redirect(Request.UrlReferrer.ToString());
        }

        public ActionResult Operations()
        {
            return View();
        }

        public ActionResult Balance()
        {
            var cardId = (Guid)Session["CardId"];
            if (cardId == Guid.Empty)
                return new HttpStatusCodeResult(500);
            using (var context = new CashMachineContext())
            {
                var dbCard = context.Cards.SingleOrDefault(c => c.Id == cardId);
                if (dbCard == null)
                    return new HttpStatusCodeResult(500);
                //var cardOperation = new CardOperation
                //{
                //    CardId = cardId,
                //    OperationTypeId = Constants.OperationType.Balance,
                //    Balance = 0m
                //};
                //context.CardOperations.Add(cardOperation);
                context.SaveChanges();

                return View(dbCard);
            }
        }

        public ActionResult GetCash()
        {
            return View();
        }
    }
}