using System.Web.Mvc;
using Task4v2.Managers;
using Task4v2.Models;

namespace Task4v2.Controllers
{
    public class ExtProductController : Controller
    {
        private ExtProductSessionManager sessionManager = new ExtProductSessionManager();

        public ActionResult CreateExtProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateExtProduct(ExtProductModel extProduct)
        {
            if (ModelState.IsValid)
            {
                sessionManager.AddExtProduct(extProduct, HttpContext);
                return RedirectToAction("ExtProductList");
            }
            return View(extProduct);
        }

        public ActionResult ExtProductList()
        {
            return View(sessionManager.GetOrCreateExtProductList(HttpContext));
        }

        public ActionResult DetailsExtProduct(int id)
        {
            return View(sessionManager.DetailsExtProduct(id, HttpContext));
        }

        public ActionResult EditExtProduct(int id)
        {
            return View(sessionManager.DetailsExtProduct(id, HttpContext));
        }

        [HttpPost]
        public ActionResult EditExtProduct(ExtProductModel extProduct)
        {
            if (ModelState.IsValid)
            {
                sessionManager.EditExtProduct(extProduct, HttpContext);
                return RedirectToAction("ExtProductList");
            }
            return View();
        }

        public ActionResult DeleteExtProduct(ExtProductModel extProduct)
        {
            sessionManager.DeleteExtProduct(extProduct, HttpContext);
            return RedirectToAction("ExtProductList");
        }
    }
}