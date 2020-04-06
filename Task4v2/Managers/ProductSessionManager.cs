using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task4v2.Models;

namespace Task4v2.Managers
{
    public class ProductSessionManager
    {
        private HttpContextBase HttpContext { get; set; }

        public ProductSessionManager(HttpContextBase httpContext)
        {
            HttpContext = httpContext;
        }

        public List<ProductModel> GetOrCreateProductList()
        {
            var products = HttpContext.Session["ProductList"] as List<ProductModel>;
            if (products == null)
            {
                products = new List<ProductModel>();
            }
            HttpContext.Session["ProductList"] = products;
            return products;
        }

        public List<ProductModel> AddProduct(ProductModel product)
        {
            var products = GetOrCreateProductList();
            product.Id = products.Count > 0 ? products.Max(x => x.Id) + 1 : 1;
            products.Add(product);
            return products;
        }

        public ProductModel DetailsProduct(int? id)
        {
            var products = GetOrCreateProductList()
                .Where(x => x.Id == id)
                .FirstOrDefault();
            return products;
        }

        public ProductModel EditProduct(ProductModel product)
        {
            var editProduct = GetOrCreateProductList()
                .Where(x => x.Id == product.Id)
                .FirstOrDefault();
            editProduct.Name = product.Name;
            editProduct.Quantity = product.Quantity;
            return editProduct;
        }

        public List<ProductModel> DeleteProduct(ProductModel product)
        {
            var products = GetOrCreateProductList();
            var queryDelete = products
                .Where(x => x.Id == product.Id)
                .FirstOrDefault();
            products.Remove(queryDelete);
            return products;
        }
    }
}