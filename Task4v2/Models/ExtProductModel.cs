using System.ComponentModel.DataAnnotations;

namespace Task4v2.Models
{
    public class ExtProductModel
    {
        [Required]
        public string Name { get; set; }

        [Required, Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int Quantity { get; set; }

        public MassUnitsModel MassUnits { get; set; }
    }
}