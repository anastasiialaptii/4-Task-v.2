using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Web;
using Task4v2.Models;

namespace Task4v2.Managers
{
    public class SessionManager
    {
        private HttpContextBase Context { get; set; }

        public SessionManager(HttpContextBase context)
        {
            Context = context;
        }

        public List<ProductModel> GetOrCreateProductList()
        {
            var products = Context.Session["productList"] as List<ProductModel>;    
            if (products == null)
            {
                products = new List<ProductModel>();
            }
            Context.Session["productList"]=products;
            return products;
        }

        public List<ProductModel> AddProductToList(ProductModel product)
        {
            var products = GetOrCreateProductList();
            products.Add(product);
            return products;
        }
    }
}