using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task4v2.Models;

namespace Task4v2.Managers
{
    public class ExtProductSessionManager
    {
        private SessionManager sessionManager = new SessionManager();

        public List<ExtProductModel> GetOrCreateExtProductList(HttpContextBase httpContext)
        {
            var context = sessionManager.CreateHttpContext(httpContext);
            var products = context.HttpContext.Session["ExtProductList"] as List<ExtProductModel>;
            if (products == null)
            {
                products = new List<ExtProductModel>();
            }
            context.HttpContext.Session["ExtProductList"] = products;
            return products;
        }

        public List<ExtProductModel> AddExtProduct(ExtProductModel extProduct, HttpContextBase httpContext)
        {
            var extnProducts = GetOrCreateExtProductList(httpContext);
            extProduct.Id = extnProducts.Count > 0 ? extnProducts.Max(x => x.Id) + 1 : 1;
            extnProducts.Add(extProduct);
            return extnProducts;
        }

        public ExtProductModel DetailsExtProduct(int id, HttpContextBase httpContext)
        {
            var detailsExtProduct = GetOrCreateExtProductList(httpContext)
                .Where(x => x.Id == id)
                .FirstOrDefault();
            return detailsExtProduct;
        }

        public ExtProductModel EditExtProduct(ExtProductModel extProduct, HttpContextBase httpContext)
        {
            var editExtProduct = GetOrCreateExtProductList(httpContext)
                .Where(x => x.Id == extProduct.Id)
                .FirstOrDefault();
            editExtProduct.Name = extProduct.Name;
            editExtProduct.Quantity = extProduct.Quantity;
            editExtProduct.MassUnits = extProduct.MassUnits;
            return editExtProduct;
        }

        public List<ExtProductModel> DeleteExtProduct(ExtProductModel extProduct, HttpContextBase httpContext)
        {
            var extProducts = GetOrCreateExtProductList(httpContext);
            var queryDelete = extProducts
                .Where(x => x.Id == extProduct.Id)
                .FirstOrDefault();
            extProducts.Remove(queryDelete);
            return extProducts;
        }
    }
}