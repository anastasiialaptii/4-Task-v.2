using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Task4v2.Managers;
using Task4v2.Models;

namespace Task4v2.Controllers
{
    public class ProductController : Controller
    {
        private ProductManager productManager = new ProductManager();
        private ProductDataManager productDataManager = new ProductDataManager();

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
                var sessionManager = new ProductSessionManager();
                sessionManager.AddProductToList(product, HttpContext);
                return RedirectToAction("SessionList");
            }
            else
            {
                return View();
            }
        }

        public ActionResult SessionList()
        {
            var sessionManager = new ProductSessionManager();
            return View(sessionManager.GetOrCreateProductList(HttpContext));
        }
    }
}