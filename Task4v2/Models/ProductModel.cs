using System.ComponentModel.DataAnnotations;

namespace Task4v2.Models
{
    public class ProductModel
    {
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required"),
        Range(1, int.MaxValue, ErrorMessage = "Please enter a value greater than {0}.")]
        public string Quantity { get; set; }
    }
}