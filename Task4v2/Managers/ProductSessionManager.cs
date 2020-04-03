using System.Collections.Generic;
using System.Web;
using Task4v2.Models;

namespace Task4v2.Managers
{
    public class ProductSessionManager
    {
        private SessionManager sessionManager = new SessionManager();

        public List<ProductModel> GetOrCreateProductList(HttpContextBase httpContext)
        {           
            var context = sessionManager.CreateHttpContext(httpContext);
            var products = context.HttpContext.Session["productList"] as List<ProductModel>;
            if (products == null)
            {
                products = new List<ProductModel>();
            }
            context.HttpContext.Session["productList"] = products;
            return products;
        }

        public List<ProductModel> AddProductToList(ProductModel product, HttpContextBase httpContext)
        {
            var products = GetOrCreateProductList(httpContext);
            products.Add(product);
            return products;
        }
    }
}