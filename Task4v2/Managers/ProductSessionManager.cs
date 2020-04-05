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
            product.Id = products.Count > 0 ? products.Max(x => x.Id) + 1 : 1;
            products.Add(product);
            return products;
        }

        public ProductModel DetailsProduct(int id, HttpContextBase httpContext)
        {
            var products = GetOrCreateProductList(httpContext)
                .Where(x => x.Id == id)
                .FirstOrDefault();
            return products;
        }

        public ProductModel EditProduct(ProductModel product, HttpContextBase httpContext)
        {
            var editProduct = GetOrCreateProductList(httpContext)
                .Where(x => x.Id == product.Id)
                .FirstOrDefault();
            editProduct.Name = product.Name;
            editProduct.Quantity = product.Quantity;
            return editProduct;
        }

        public List<ProductModel> DeleteProduct(ProductModel product, HttpContextBase httpContext)
        {
            var products = GetOrCreateProductList(httpContext);
            var queryDelete = products
                .Where(x => x.Id == product.Id)
                .FirstOrDefault();
            products.Remove(queryDelete);
            return products;
        }
    }
}