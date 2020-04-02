using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Task4v2.Models
{
    public class ProductModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Quantity { get; set; }
    }
}