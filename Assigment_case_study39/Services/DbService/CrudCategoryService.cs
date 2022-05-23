using Day39CaseStudy.DataAccess;
using Day39CaseStudy.DataAccess.Models;
using Day39CaseStudy.Services.DbService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Day39CaseStudy.Services.DbService;

public class CrudCategoryService : ICrudService<Category>
{
    public async Task AddAsync(Category category)
    {
        using var context = new SampleStoreDbContext();
        await context.Categories.AddAsync(category);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int CategoryId)
    {
        using var context = new SampleStoreDbContext();
        // var category = context.Categories.Find(CategoryId);
        var category = from delCat
                         in context.Categories
                       where delCat.CategoryId == CategoryId
                       select delCat;

        if (category == null)
        {
            Console.WriteLine($"CategoryId {CategoryId} not found");
            return;
        }
        context.Categories.Remove(await category.SingleOrDefaultAsync());
       await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        using var context = new SampleStoreDbContext();
        var cat = from categoryes
                   in context.Categories
                  select categoryes;
        return await cat.ToListAsync();
    }

    public async Task<Category> GetByNameAsync(string CategoryName)
    {   
        using var context = new SampleStoreDbContext();
        //var category = context.Categories.SingleOrDefault(b => b.CategoryName == CategoryName);

        var cats = from getName
                   in context.Categories
                   where getName.CategoryName == CategoryName
                   select getName;
        return await cats.SingleOrDefaultAsync();
    }

    public async Task UpdateAsync(Category category)
    {
        using var context = new SampleStoreDbContext();
         context.Categories.Update(category);
        await context.SaveChangesAsync();
    }
}