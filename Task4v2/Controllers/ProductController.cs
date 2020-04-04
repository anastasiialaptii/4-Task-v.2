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
                sessionManager.AddProductToList(product, HttpContext);
                return RedirectToAction("ProductList");
            }
            else
            {
                return View();
            }
        }

        public ActionResult DeleteProduct(string name, string quantity)
        {
            sessionManager.DeleteProductFromList(name, quantity, HttpContext);
            return RedirectToAction("ProductList");
        }

        public ActionResult ProductList()
        {
            return View(sessionManager.GetOrCreateProductList(HttpContext));
        }
    }
}