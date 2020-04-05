using Task4v2.Models;

namespace Task4v2.Managers
{
    public class ExtProductManager
    {
        public ExtProductModel CreateExtProduct(int id, string name, int quantity, MassUnitsModel massUnits) 
        {
            ExtProductModel extProduct = new ExtProductModel()
            {
                Id = id,
                Name = name,
                Quantity = quantity,
                MassUnits = massUnits
            };
            return extProduct;
        }
    }
}