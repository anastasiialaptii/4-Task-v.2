using System.Web.Mvc;
using Task4v2.Managers;
using Task4v2.Models;

namespace Task4v2.Controllers
{
    public class ExtProductController : Controller
    {
        private ExtProductSessionManager extProductSession = new ExtProductSessionManager();

        public ActionResult CreateExtProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateExtProduct(ExtProductModel extProduct)
        {
            if (ModelState.IsValid)
            {
                extProductSession.AddExtProduct(extProduct, HttpContext);
                return RedirectToAction("ExtProductList");
            }
            return View();
        }

        public ActionResult ExtProductList()
        {
            var products = extProductSession.GetOrCreateExtProductList(HttpContext);
            if (products.Count == 0)
            {
                return View("EmptyList");
            }
            return View(products);
        }

        public ActionResult DetailsExtProduct(int id)
        {
            return View(extProductSession.DetailsExtProduct(id, HttpContext));
        }

        public ActionResult EditExtProduct(int id)
        {           
            return View(extProductSession.DetailsExtProduct(id, HttpContext));
        }

        [HttpPost]
        public ActionResult EditExtProduct(ExtProductModel extProduct)
        {
            if (ModelState.IsValid)
            {
                extProductSession.EditExtProduct(extProduct, HttpContext);
                return RedirectToAction("ExtProductList");
            }
            return View();
        }

        public ActionResult DeleteExtProduct(ExtProductModel extProduct)
        {
            extProductSession.DeleteExtProduct(extProduct, HttpContext);
            return RedirectToAction("ExtProductList");
        }
    }
}