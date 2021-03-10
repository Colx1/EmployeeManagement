using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductBlazorFront.ViewModels
{
    public class BrandViewModel
    {
        public int Id { get; set; }
        [Required]
        public string BrandName { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "You have to select one!")]
        public int CompanyId { get; set; }

        public CompanyViewModel Company { get; set; }
    }
}
