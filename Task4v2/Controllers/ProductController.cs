using System.Web.Mvc;
using Task4v2.Managers;
using Task4v2.Models;

namespace Task4v2.Controllers
{
    public class ProductController : Controller
    {
        private ProductSessionManager sessionManager = new ProductSessionManager();

        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                sessionManager.AddProduct(product, HttpContext);
                return RedirectToAction("ProductList");
            }
            else
            {
                return View();
            }
        }

        public ActionResult DeleteProduct(string name, string quantity)
        {
            sessionManager.DeleteProduct(name, quantity, HttpContext);
            return RedirectToAction("ProductList");
        }

        public ActionResult EditProduct(string name, string quantity)
        {
            var res = sessionManager.DetailsProduct(name, quantity, HttpContext);
            return View(res);
        }

        [HttpPost]
        public ActionResult EditProduct(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                sessionManager.EditProduct(product, HttpContext);
                return RedirectToAction("ProductList");
            }
            return View();
        }

        public ActionResult ProductList()
        {
            return View(sessionManager.GetOrCreateProductList(HttpContext));
        }
    }
}