using System.ComponentModel.DataAnnotations;

namespace Task4v2.Models
{
    public class ExtProductModel
    {
        [Required, Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required"),
         Range(1, 20, ErrorMessage = "Please enter integer value between 1 and 20")]
        public int Quantity { get; set; }

        [Required]
        [Display(Name = "Weight")]
        public MassUnitsModel MassUnits { get; set; }
    }
}