using Day39CaseStudy.DataAccess;
using Day39CaseStudy.DataAccess.Models;
using Day39CaseStudy.Services.DbService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Day39CaseStudy.Services.DbService;

public class CrudProductService : ICrudService<Product>
{
    public async Task AddAsync(Product product)
    {
        using var context = new SampleStoreDbContext();
        await context.Products.AddAsync(product);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        using var context = new SampleStoreDbContext();

        var p =
        await(from product in context.Products
         join brand in context.Brands on product.BrandId equals brand.BrandId
         join category in context.Categories on product.CategoryId equals category.CategoryId
         orderby product.BrandId, product.ProductId
         select new Product
         {
             ProductId = product.ProductId,
             ProductName = product.ProductName,
             BrandId = product.BrandId,
             CategoryId = product.CategoryId,
             ModelYear = product.ModelYear,
             ListPrice = product.ListPrice,
             Brand = brand,
             Category = category
         }).ToListAsync();
        return  p;
    }

    public async Task UpdateAsync(Product product)
    {
        using var context = new SampleStoreDbContext();
         context.Products.Update(product);
        await context.SaveChangesAsync();
    }

    public async Task<Product> GetByNameAsync(string productName)
    {
        using var context = new SampleStoreDbContext();
        //var product = context.Products.SingleOrDefault(b => b.ProductName == productName);
        //return product;
        var product = from get
                       in context.Products
                      where get.ProductName == productName
                      select get;
        return await product.SingleOrDefaultAsync();
    }

    public async Task DeleteAsync(int productId)
    {
        using var context = new SampleStoreDbContext();
        //var product = context.Products.Find(productId);
        var product = from del
                       in context.Products
                      where del.ProductId == productId
                      select del;

        if (product == null)
        {
            Console.WriteLine($"ProductId {productId} not found");
            return;
        }

         context.Products.Remove(await product.SingleOrDefaultAsync());
        await context.SaveChangesAsync();
    }
}
