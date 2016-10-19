using System;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Cash_Machine.Models;

namespace Cash_Machine.Controllers
{
    public class HomeController : Controller
    {
        private static string Decode(string encodedString)
        {
            var data = Convert.FromBase64String(encodedString);
            return Encoding.UTF8.GetString(data);
        }

        [HttpGet]
        public ActionResult CardNumber()
        {
            var card = new Card();
            Session["CardId"] = null;
            return View(card);
        }

        [HttpPost]
        public ActionResult CardNumber(string number)
        {
            number = Decode(number);
            using (var context = new CashMachineContext())
            {
                var cards = context.Cards.Where(c => !c.IsBlocked && c.Number == number);
                if (!cards.Any())
                    return RedirectToAction("Error", new Error
                    {
                        Description = $"Card with number \"{number}\" doesn't exist or blocked",
                        PreviousUrl = ControllerContext.RouteData.Values["action"].ToString()
                    });
                Session["CardId"] = cards.First().Id;
                Session["PinTries"] = 1;
                return RedirectToAction("Pin");
            }
        }

        [HttpGet]
        public ActionResult Pin()
        {
            var card = new Card();
            return View(card);
        }

        [HttpPost]
        public ActionResult Pin(string password)
        {
            var cardIdObject = Session["CardId"];
            if (cardIdObject == null)
                return new HttpStatusCodeResult(500);
            var cardId = (Guid)cardIdObject;
            using (var context = new CashMachineContext())
            {
                var dbCard = context.Cards.SingleOrDefault(c => c.Id == cardId);
                if (dbCard == null)
                    return new HttpStatusCodeResult(500);

                if (password == dbCard.Password)
                    return RedirectToAction("Operations");

                var triesNumber = (int)Session["PinTries"];
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
                return RedirectToAction("Error", new Error
                {
                    Description = "You entered wrong PIN",
                    PreviousUrl = "Pin"
                });
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
            var cardIdObject = Session["CardId"];
            if (cardIdObject == null)
                return new HttpStatusCodeResult(500);
            var cardId = (Guid)cardIdObject;
            using (var context = new CashMachineContext())
            {
                var dbCard = context.Cards.SingleOrDefault(c => c.Id == cardId);
                if (dbCard == null)
                    return new HttpStatusCodeResult(500);
                var cardOperation = new CardOperation
                {
                    CardId = cardId,
                    OperationTypeId = Constants.OperationType.Balance,
                    Balance = 0m
                };
                context.CardOperations.Add(cardOperation);
                context.SaveChanges();

                return View(dbCard);
            }
        }

        [HttpGet]
        public ActionResult GetCash()
        {
            var cardIdObject = Session["CardId"];
            if (cardIdObject == null)
                return new HttpStatusCodeResult(500);
            var cardId = (Guid)cardIdObject;
            using (var context = new CashMachineContext())
            {
                var dbCard = context.Cards.SingleOrDefault(c => c.Id == cardId);
                if (dbCard == null)
                    return new HttpStatusCodeResult(500);
                return View(dbCard);
            }
        }

        [HttpPost]
        public ActionResult GetCash(decimal requestedAmount)
        {
            var cardIdObject = Session["CardId"];
            if (cardIdObject == null)
                return new HttpStatusCodeResult(500);
            var cardId = (Guid)cardIdObject;
            using (var context = new CashMachineContext())
            {
                var card = context.Cards.SingleOrDefault(c => c.Id == cardId);
                if (card == null)
                    return new HttpStatusCodeResult(500);
                if (card.Balance < requestedAmount)
                    return RedirectToAction("Error", new Error
                    {
                        Description = $"Your card balance is less then {requestedAmount}",
                        PreviousUrl = ControllerContext.RouteData.Values["action"].ToString()
                    });
                card.Balance -= requestedAmount;

                var cardOperation = new CardOperation
                {
                    CardId = cardId,
                    OperationTypeId = Constants.OperationType.GetCash,
                    Amount = requestedAmount,
                    Balance = card.Balance
                };
                context.CardOperations.Add(cardOperation);

                context.SaveChanges();

                return RedirectToAction("OperationResult", cardOperation);
            }
        }

        public ActionResult OperationResult(CardOperation cardOperation)
        {
            using (var context = new CashMachineContext())
            {
                var card = context.Cards.SingleOrDefault(c => c.Id == cardOperation.CardId);
                if (card == null)
                    return new HttpStatusCodeResult(500);
                return View(new Tuple<CardOperation, string>(cardOperation, card.Number));
            }
        }
    }
}