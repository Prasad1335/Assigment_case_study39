using Day39CaseStudy.DataAccess;
using Day39CaseStudy.DataAccess.Models;
using Day39CaseStudy.Services.DbService.Interfaces;

namespace Day39CaseStudy.Services.DbService;

public class CrudCategoryService : ICrudService<Category>
{

    readonly ICrudService<Category>_categoryService;
    public void Add(Category category)
    {

        using var context = new SampleStoreDbContext();
        context.Categories.Add(category);
        context.SaveChanges();

    }

    public void Delete(int entityId)
    {

      
    }

    public IEnumerable<Category> GetAll()
    {
        using var context = new SampleStoreDbContext();

       // return context.Categories.ToList();



        var category = from cat in context.Categories.ToList() select cat;

        return category;
    }

    public Category GetByName(string entityName)
    {
        throw new ArgumentNullException();
    }

    public void Update(Category entity)
    {
        
    }
}