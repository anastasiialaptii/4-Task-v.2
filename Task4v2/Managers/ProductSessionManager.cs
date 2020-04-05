using System.Collections.Generic;
using System.Linq;
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
            var products = context.HttpContext.Session["ProductList"] as List<ProductModel>;
            if (products == null)
            {
                products = new List<ProductModel>();
            }
            context.HttpContext.Session["ProductList"] = products;
            return products;
        }

        public List<ProductModel> AddProduct(ProductModel product, HttpContextBase httpContext)
        {
            var products = GetOrCreateProductList(httpContext);
            products.Add(product);
            return products;
        }

        public List<ProductModel> DeleteProduct(string name, string quantity, HttpContextBase httpContext)
        {
            var products = GetOrCreateProductList(httpContext);
            var queryDelete = products
                .Where(x => x.Name == name)
                .Where(x => x.Quantity == quantity)
                .FirstOrDefault();
            products.Remove(queryDelete);
            return products;
        }

        public ProductModel DetailsProduct(string name, string quantity, HttpContextBase httpContext)
        {
            var products = GetOrCreateProductList(httpContext)
                .Where(x => x.Name == name)
                .Where(x => x.Quantity == quantity)
                .FirstOrDefault();
            return products;
        }

        public ProductModel EditProduct(ProductModel product, HttpContextBase httpContext)
        {
            var products = GetOrCreateProductList(httpContext)
                .Where(x => x.Name == product.Name)
                .FirstOrDefault();
            products.Quantity = product.Quantity;
            return products;
        }
    }
}