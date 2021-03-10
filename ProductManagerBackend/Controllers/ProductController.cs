using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductManagerBackend.Models;
using ProductManagerBackend.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManagerBackend.Controllers
{
    class ResponseModel
    {
        public bool Status { get; set; }
        public string Error { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductDbContext Db { get; set; }
        public ProductController(ProductDbContext _Db)
        {
            Db = _Db;
        }

        [HttpGet("[action]/{Id?}")]
        public async Task<IActionResult> GetCompanies(int? Id)
            => Ok(Id.HasValue ? await Db.Tbl_Companies.FirstOrDefaultAsync(x => x.Id == Id)
                              : await Db.Tbl_Companies.Select(x => new { x.Id, x.CompanyName }).ToListAsync());

        [HttpGet("[action]/{loadFullData?}/{Id?}")]
        public async Task<IActionResult> GetBrands(bool? loadFullData, int? Id)
        {
            IQueryable<Brand> query = Db.Tbl_Brands.AsQueryable();

            if (loadFullData.HasValue && loadFullData.Value)
                query = query.Include(x => x.Company);

            if (Id.HasValue)
                return Ok(await query.FirstOrDefaultAsync(x => x.Id == Id));

            return Ok(await query.ToListAsync());

        }

        [HttpGet("[action]/{CompanyId}")]
        public async Task<IActionResult> GetBrandsByCompanyId(int CompanyId)
            => Ok(await Db.Tbl_Brands
                .Where(x => x.CompanyId == CompanyId)
                .Select(x => new { x.Id, x.BrandName, x.CompanyId }).ToListAsync());

        [HttpGet("[action]/{loadFullData?}/{Id?}")]
        public async Task<IActionResult> GetProducts(bool? loadFullData, int? Id)
        {
            IQueryable<Product> query = Db.Tbl_Products.AsQueryable();

            if (loadFullData.HasValue && loadFullData.Value)
                query = query.Include(x => x.Brand).ThenInclude(x => x.Company);

            if (Id.HasValue)
                return Ok(await query.FirstOrDefaultAsync(x => x.Id == Id));

            return Ok(await query.ToListAsync());
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            if (!await Db.Tbl_Products.AnyAsync(x => x.Id == Id))
                return NotFound(new ResponseModel { Status = false, Error = $"The product with id: {Id} didn't found" });

            try
            {
                var product = await Db.Tbl_Products.FirstOrDefaultAsync(x => x.Id == Id);
                Db.Remove(product);
                await Db.SaveChangesAsync();
                return Ok(new ResponseModel { Status = true, Error = "Produt removed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel { Status = false, Error = $"Error: {ex.Message}" });
                throw;
            }
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteBrand(int Id)
        {
            if (!await Db.Tbl_Brands.AnyAsync(x => x.Id == Id))
                return NotFound(new ResponseModel { Status = false, Error = $"The brand with id: {Id} didn't found" });

            try
            {
                var brand = await Db.Tbl_Brands.FirstOrDefaultAsync(x => x.Id == Id);
                Db.Remove(brand);
                await Db.SaveChangesAsync();
                return Ok(new ResponseModel { Status = true, Error = "Brand removed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel { Status = false, Error = $"Error: {ex.Message}" });
                throw;
            }
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> DeleteCompany(int Id)
        {
            if (!await Db.Tbl_Companies.AnyAsync(x => x.Id == Id))
                return NotFound(new ResponseModel { Status = false, Error = $"The company with id: {Id} didn't found" });

            try
            {
                var brand = await Db.Tbl_Companies.FirstOrDefaultAsync(x => x.Id == Id);
                Db.Remove(brand);
                await Db.SaveChangesAsync();
                return Ok(new ResponseModel { Status = true, Error = "Company removed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel { Status = false, Error = $"Error: {ex.Message}" });
                throw;
            }
        }

        [HttpPut("[action]/{Id}")]
        public async Task<IActionResult> UpdateProduct(int Id, ProductViewModel model, [FromServices] IMapper mapper)
        {
            if (!await Db.Tbl_Products.AnyAsync(x => x.Id == Id))
                return NotFound(new ResponseModel { Status = false, Error = $"The product with id: {Id} didn't found" });

            //var product = await Db.Tbl_Products.FirstOrDefaultAsync(x => x.Id == Id);
            Product product = mapper.Map<Product>(model);
            Db.Update(product);
            await Db.SaveChangesAsync();

            return Ok(new ResponseModel { Status = true, Error = null });
        }

        [HttpPut("[action]/{Id}")]
        public async Task<IActionResult> UpdateBrand(int Id, BrandViewModel model, [FromServices] IMapper mapper)
        {
            if (!await Db.Tbl_Brands.AnyAsync(x => x.Id == Id))
                return NotFound(new ResponseModel { Status = false, Error = $"The brand with id: {Id} didn't found" });

            Brand product = mapper.Map<Brand>(model);
            Db.Update(product);
            await Db.SaveChangesAsync();

            return Ok(new ResponseModel { Status = true, Error = null });
        }

        [HttpPut("[action]/{Id}")]
        public async Task<IActionResult> UpdateCompany(int Id, CompanyViewModel model, [FromServices] IMapper mapper)
        {
            if (!await Db.Tbl_Companies.AnyAsync(x => x.Id == Id))
                return NotFound(new ResponseModel { Status = false, Error = $"The brand with id: {Id} didn't found" });

            Company product = mapper.Map<Company>(model);
            Db.Update(product);
            await Db.SaveChangesAsync();

            return Ok(new ResponseModel { Status = true, Error = null });
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> InsertProduct(ProductViewModel model, [FromServices] IMapper mapper)
        {
            try
            {
                Product product = mapper.Map<Product>(model);
                await Db.AddAsync(product);
                await Db.SaveChangesAsync();
                return Ok(new ResponseModel { Status = true });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Status = false, Error = $"Error: {ex.Message}" });
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> InsertBrand(BrandViewModel model, [FromServices] IMapper mapper)
        {
            try
            {
                Brand brand = mapper.Map<Brand>(model);
                await Db.AddAsync(brand);
                await Db.SaveChangesAsync();
                return Ok(new ResponseModel { Status = true });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Status = false, Error = $"Error: {ex.Message}" });
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> InsertCompany(CompanyViewModel model, [FromServices] IMapper mapper)
        {
            try
            {
                Company company = mapper.Map<Company>(model);
                await Db.AddAsync(company);
                await Db.SaveChangesAsync();
                return Ok(new ResponseModel { Status = true });
            }
            catch (Exception ex)
            {
                return Ok(new ResponseModel { Status = false, Error = $"Error: {ex.Message}" });
            }
        }
    }
}
