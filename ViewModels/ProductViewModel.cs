using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagerBackend.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public int BrandId { get; set; }

        public string Name { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
    }
}
