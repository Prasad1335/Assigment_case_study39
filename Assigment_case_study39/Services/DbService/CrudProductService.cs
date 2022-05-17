using Day39CaseStudy.DataAccess;
using Day39CaseStudy.DataAccess.Models;
using Day39CaseStudy.Services.DbService.Interfaces;
namespace Day39CaseStudy.Services.DbService;

public class CrudProductService : ICrudService<Product>
{
    public void Add(Product product)
    {
        using var context = new SampleStoreDbContext();
        context.Products.Add(product);
        context.SaveChanges();
    }

    public IEnumerable<Product> GetAll()
    {
        using var context = new SampleStoreDbContext();

        var p3 =
        (from product in context.Products
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
         }).ToList();
        return p3;
    }

    public void Update(Product product)
    {
        using var context = new SampleStoreDbContext();
        context.Products.Update(product);
        context.SaveChanges();
    }

    public Product GetByName(string productName)
    {
        using var context = new SampleStoreDbContext();
        //var product = context.Products.SingleOrDefault(b => b.ProductName == productName);
        //return product;
        var product = from get
                       in context.Products
                      where get.ProductName == productName
                      select get;
        return product.SingleOrDefault();
    }

    public void Delete(int productId)
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

        context.Products.Remove(product.SingleOrDefault());
        context.SaveChanges();
    }
}
