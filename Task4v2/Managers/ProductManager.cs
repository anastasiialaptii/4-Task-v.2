using System.Collections.Generic;
using System.Linq;
using Task4v2.Models;

namespace Task4v2.Managers
{
    public class ProductManager
    {
        public ProductModel CreateProduct(string name, string quantity)
        {
            ProductModel product = new ProductModel()
            {
                Name = name,
                Quantity = quantity
            };
            return product;
        }

        public List<ProductModel> ProductDetails(List<ProductModel> products, string name)
        {
            return products.Where(x => x.Name == name).ToList(); ;
        }
    }
}