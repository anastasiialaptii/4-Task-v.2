using System.Web.Mvc;
using Task4v2.Managers;
using Task4v2.Models;

namespace Task4v2.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateProduct(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var session = new ProductSessionManager(HttpContext);
                session.AddProduct(product);
                return RedirectToAction(nameof(ProductList));
            }
            else
            {
                return View(product);
            }
        }

        public ActionResult ProductList()
        {
            var session = new ProductSessionManager(HttpContext);
            return View(session.GetOrCreateProductList());
        }

        public ActionResult DetailsProduct(int? id)
        {
            if (id != null)
            {
                var session = new ProductSessionManager(HttpContext);
                return View(session.DetailsProduct(id));

            }
            return RedirectToAction(nameof(ProductList));
        }

        public ActionResult EditProduct(int? id)
        {
            if (id != null)
            {
                var session = new ProductSessionManager(HttpContext);
                return View(session.DetailsProduct(id));

            }
            return RedirectToAction(nameof(ProductList));
        }

        [HttpPost]
        public ActionResult EditProduct(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var session = new ProductSessionManager(HttpContext);
                session.EditProduct(product);
                return RedirectToAction(nameof(ProductList));
            }
            return View(product);
        }

        public ActionResult DeleteProduct(ProductModel product)
        {
            var session = new ProductSessionManager(HttpContext);
            session.DeleteProduct(product);
            return RedirectToAction(nameof(ProductList));
        }
    }
}