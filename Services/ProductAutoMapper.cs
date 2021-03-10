using AutoMapper;
using ProductManagerBackend.Models;
using ProductManagerBackend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagerBackend.Services
{
    public class ProductAutoMapper : Profile
    {
        public ProductAutoMapper()
        {
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();

            CreateMap<Company, CompanyViewModel>();
            CreateMap<CompanyViewModel, Company>();

            CreateMap<Brand, BrandViewModel>();
            CreateMap<BrandViewModel, Brand>();
        }
    }
}
