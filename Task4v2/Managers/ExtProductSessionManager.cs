using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task4v2.Models;

namespace Task4v2.Managers
{
    public class ExtProductSessionManager
    {
        private HttpContextBase HttpContext { get; set; }

        public ExtProductSessionManager(HttpContextBase httpContext)
        {
            HttpContext = httpContext;
        }

        public List<ExtProductModel> GetOrCreateExtProductList()
        {
            var products = HttpContext.Session["ExtProductList"] as List<ExtProductModel>;
            if (products == null)
            {
                products = new List<ExtProductModel>();
            }
            HttpContext.Session["ExtProductList"] = products;
            return products;
        }

        public List<ExtProductModel> AddExtProduct(ExtProductModel extProduct)
        {
            var extnProducts = GetOrCreateExtProductList();
            extProduct.Id = extnProducts.Count > 0 ? extnProducts.Max(x => x.Id) + 1 : 1;
            extnProducts.Add(extProduct);
            return extnProducts;
        }

        public ExtProductModel DetailsExtProduct(int id)
        {
            var detailsExtProduct = GetOrCreateExtProductList()
                .Where(x => x.Id == id)
                .FirstOrDefault();
            return detailsExtProduct;
        }

        public ExtProductModel EditExtProduct(ExtProductModel extProduct)
        {
            var editExtProduct = GetOrCreateExtProductList()
                .Where(x => x.Id == extProduct.Id)
                .FirstOrDefault();
            editExtProduct.Name = extProduct.Name;
            editExtProduct.Quantity = extProduct.Quantity;
            editExtProduct.MassUnits = extProduct.MassUnits;
            return editExtProduct;
        }

        public List<ExtProductModel> DeleteExtProduct(ExtProductModel extProduct)
        {
            var extProducts = GetOrCreateExtProductList();
            var queryDelete = extProducts
                .Where(x => x.Id == extProduct.Id)
                .FirstOrDefault();
            extProducts.Remove(queryDelete);
            return extProducts;
        }
    }
}