using System.Web.Mvc;
using Task4v2.Managers;
using Task4v2.Models;

namespace Task4v2.Controllers
{
    public class ExtProductController : Controller
    {
        public ActionResult CreateExtProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateExtProduct(ExtProductModel extProduct)
        {
            if (ModelState.IsValid)
            {
                var session = new ExtProductSessionManager(HttpContext);
                session.AddExtProduct(extProduct);
                return RedirectToAction(nameof(ExtProductList));
            }
            return View(extProduct);
        }

        public ActionResult ExtProductList()
        {
            var session = new ExtProductSessionManager(HttpContext);
            return View(session.GetOrCreateExtProductList());
        }

        public ActionResult DetailsExtProduct(int id)
        {
            var session = new ExtProductSessionManager(HttpContext);
            return View(session.DetailsExtProduct(id));
        }

        public ActionResult EditExtProduct(int id)
        {
            var session = new ExtProductSessionManager(HttpContext);
            return View(session.DetailsExtProduct(id));
        }

        [HttpPost]
        public ActionResult EditExtProduct(ExtProductModel extProduct)
        {
            if (ModelState.IsValid)
            {
                var session = new ExtProductSessionManager(HttpContext);
                session.EditExtProduct(extProduct);
                return RedirectToAction(nameof(ExtProductList));
            }
            return View(extProduct);
        }

        public ActionResult DeleteExtProduct(ExtProductModel extProduct)
        {
            var session = new ExtProductSessionManager(HttpContext);
            session.DeleteExtProduct(extProduct);
            return RedirectToAction(nameof(ExtProductList));
        }
    }
}