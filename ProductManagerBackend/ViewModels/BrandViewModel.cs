using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagerBackend.ViewModels
{
    public class BrandViewModel
    {
        public int Id { get; set; }
        public string BrandName { get; set; }

        public int CompanyId { get; set; }
    }
}
