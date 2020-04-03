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
                extProductSession.AddProductToList(extProduct, HttpContext);
                return RedirectToAction("ExtProductList");
            }
            return View();
        }

        public ActionResult ExtProductList()
        {
            return View(extProductSession.GetOrCreateExtProductList(HttpContext));
        }
    }
}