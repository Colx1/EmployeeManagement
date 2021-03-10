using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductBlazorFront.ViewModels
{
    public class CompanyViewModel
    {
        public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        //public ICollection<BrandViewModel> Brands { get; set; }
    }
}
