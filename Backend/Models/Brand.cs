using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagerBackend.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string BrandName { get; set; }

        public int CompanyId { get; set; }
        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
