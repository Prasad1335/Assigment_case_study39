using Day39CaseStudy.DataAccess;
using Day39CaseStudy.DataAccess.Models;
using Day39CaseStudy.Services.DbService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Day39CaseStudy.Services.DbService;

public class CrudBrandService : ICrudService<Brand>
{
    public async Task AddAsync(Brand brand)
    {
        using var context = new SampleStoreDbContext();
        await context.Brands.AddAsync(brand);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Brand>> GetAllAsync()
    {
        using var context = new SampleStoreDbContext();
        var brand = from getBrand
                   in context.Brands
                    select getBrand;
        return await brand.ToListAsync();
    }

    public async Task UpdateAsync(Brand brand)
    {
        using var context = new SampleStoreDbContext();
        context.Brands.Update(brand);
        await context.SaveChangesAsync();
    }

    public async Task<Brand> GetByNameAsync(string brandName)
    {
        using var context = new SampleStoreDbContext();
        //var brand = context.Brands.SingleOrDefault(b => b.BrandName == brandName);
        var brand = from getBrand
                    in context.Brands
                    where getBrand.BrandName == brandName
                    select getBrand;
        return await brand.SingleOrDefaultAsync();
    }

    public async Task DeleteAsync(int brandId)
    {
        using var context = new SampleStoreDbContext();
        // var brand = context.Brands.Find(brandId);
        var brand = from brand_items
                    in context.Brands
                    where brand_items.BrandId == brandId
                    select brand_items;

        if (brand == null)
        {
            Console.WriteLine($"BrandId {brandId} not found");
            return;
        }

        context.Brands.Remove(await brand.SingleOrDefaultAsync());
        await context.SaveChangesAsync();
    }
}
