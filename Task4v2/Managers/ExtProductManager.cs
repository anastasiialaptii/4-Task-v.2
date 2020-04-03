using Task4v2.Models;

namespace Task4v2.Managers
{
    public class ExtProductManager
    {
        public ExtProductModel CreateExtProduct(string name, int quantity, MassUnitsModel massUnits) 
        {
            ExtProductModel extProduct = new ExtProductModel()
            {
                Name = name,
                Quantity = quantity,
                MassUnits = massUnits
            };
            return extProduct;
        }
    }
}