using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductBlazorFront.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "You have to select one")]
        public int BrandId { get; set; }
        public BrandViewModel Brand { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Value must be more than zero")]
        public int Amount { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Value must be more than zero")]
        public int Price { get; set; }
    }

}
