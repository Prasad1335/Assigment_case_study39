using Day39CaseStudy.DataAccess;
using Day39CaseStudy.DataAccess.Models;
using Day39CaseStudy.Services.DbService.Interfaces;
namespace Day39CaseStudy.Services.DbService;

public class CrudCategoryService : ICrudService<Category>
{
    public void Add(Category category)
    {
        using var context = new SampleStoreDbContext();
        context.Categories.Add(category);
        context.SaveChanges();
    }

    public void Delete(int CategoryId)
    {
        using var context = new SampleStoreDbContext();
        var category = from delCat
                         in context.Categories
                       where delCat.CategoryId == CategoryId
                       select delCat;

        if (category == null)
        {
            Console.WriteLine($"BrandId {CategoryId} not found");
            return;
        }
        context.Categories.Remove(category.SingleOrDefault());
        context.SaveChanges();
    }

    public IEnumerable<Category> GetAll()
    {
        using var context = new SampleStoreDbContext();
        var cat = from categoryes
                   in context.Categories.ToList()
                  select categoryes;
        return cat;
    }

    public Category GetByName(string CategoryName)
    {   
        using var context = new SampleStoreDbContext();
        var cats = from getName
                   in context.Categories
                   where getName.CategoryName == CategoryName
                   select getName;
        return cats.SingleOrDefault();
    }

    public void Update(Category category)
    {
        using var context = new SampleStoreDbContext();
        context.Categories.Update(category);
        context.SaveChanges();
    }
}