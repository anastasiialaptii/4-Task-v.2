using System.Web.Mvc;
using Task4v2.Managers;

namespace Task4v2.Controllers
{
    public class TestProductController : Controller
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

    }
}