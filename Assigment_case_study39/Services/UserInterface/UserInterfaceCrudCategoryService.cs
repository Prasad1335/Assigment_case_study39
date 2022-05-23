using Day39CaseStudy.DataAccess.Models;
using Day39CaseStudy.Services.DbService.Interfaces;
using Day39CaseStudy.Services.Factory;
namespace Day39CaseStudy.Services.UserInterface;

public class UserInterfaceCrudCategoryService
{
    readonly ICrudService<Category> _categoryService;

    public UserInterfaceCrudCategoryService()
    {
        _categoryService = CrudFactory.Create<Category>();    // LOOSELY BOUND. VERY GOOD
    }

    public async Task AddAsync()
    {
        Console.WriteLine("**** Adding new Category ****");
        Console.WriteLine("-----------------------------");

        Console.Write(" Enter Category Name >>  ");
        var TextCategoryName = Console.ReadLine();

        var category = new Category { CategoryName = TextCategoryName };
       await  _categoryService.AddAsync(category);
    }

    public async Task<IEnumerable<Category>> GetAllAsync()
    {
        return await _categoryService.GetAllAsync();
    }

    public async Task UpdateAsync()
    {
        Console.WriteLine("Updating existing category");
        Console.WriteLine("-----------------------");

        Console.Write("Enter category Name to Update: ");
        var categoryNameText = Console.ReadLine();

        var cat = await _categoryService.GetByNameAsync(categoryNameText);

        if (cat == null)
        {
            Console.WriteLine($"category Name {categoryNameText} not found!!");
            return;
        }

        Console.WriteLine($"Found category: {cat}");

        Console.Write("Enter category Name to change: ");
        var changedCategoryNameText = Console.ReadLine();

        cat.CategoryName = changedCategoryNameText;
       await _categoryService.UpdateAsync(cat);
    }
    public async Task DeleteAsync()
    {
        Console.WriteLine("Deleting existing category");
        Console.WriteLine("-----------------------");

        Console.Write("Enter the category Id to delete: >> ");
        var categoryIdText = Console.ReadLine();

        var CategoryId = int.Parse(categoryIdText);

        try
        {
            await _categoryService.DeleteAsync(CategoryId);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Delete category Failed!! {ex.Message}");
            Console.ResetColor();
        }
    }
    public async Task Show()
    {
        var cats = await _categoryService.GetAllAsync();
        Console.WriteLine("-------------------------------------");
        Console.WriteLine("|         Category List             |");
        Console.WriteLine("-------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(Category.Header);
        Console.WriteLine("-------------------------------------");
        Console.ResetColor();

        foreach (var cat in cats)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"|   {cat.CategoryId,(-7)}  | {cat.CategoryName,(-20)} |");
            Console.WriteLine("-------------------------------------");
           
        }
        Console.ResetColor();
    }
}
