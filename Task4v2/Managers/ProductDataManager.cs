using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task4v2.Models;

namespace Task4v2.Managers
{
    public class ProductDataManager
    {
        private ProductManager product = new ProductManager();
        public List<ProductModel> productList = new List<ProductModel>();

        public ProductDataManager()
        {
            productList.Add(product.CreateProduct("Apple", "2 kg"));
            productList.Add(product.CreateProduct("Orange", "5 kg"));
            productList.Add(product.CreateProduct("Juice", "3 bottles"));
        }
    }
}