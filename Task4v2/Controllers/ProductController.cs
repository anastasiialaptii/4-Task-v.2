using System.Web.Mvc;
using Task4v2.Managers;
using Task4v2.Models;

namespace Task4v2.Controllers
{
    public class ProductController : Controller
    {
        private ProductManager productManager = new ProductManager();
        private ProductDataManager productDataManager = new ProductDataManager();
        private ProductSessionManager sessionManager = new ProductSessionManager();

        public ActionResult ProductListView()
        {
            return View(productDataManager.productList);
        }

        public ActionResult ProductListDetails(string name)
        {
            return View(productManager.ProductDetails(productDataManager.productList, name));
        }

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

        public ActionResult ProductList()
        {
            return View(sessionManager.GetOrCreateProductList(HttpContext));
        }
    }
}