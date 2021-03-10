using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagerBackend.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }

        public ICollection<Brand> Brands { get; set; }
    }
}
