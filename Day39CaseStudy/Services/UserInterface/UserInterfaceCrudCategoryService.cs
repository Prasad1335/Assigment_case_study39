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

    public void Add()
    {
        Console.WriteLine("**** Adding new Category ****");
        Console.WriteLine("-----------------------------");

        Console.Write(" Enter Category Name >>  ");
        var TextCategoryName = Console.ReadLine();

        var category = new Category { CategoryName = TextCategoryName };

        _categoryService.Add(category);
    }

    public IEnumerable<Category> GetAll()
    {
        return _categoryService.GetAll();
    }

    public void Update()
    {
        Console.WriteLine("Updating existing Product");
        Console.WriteLine("-----------------------");
    }
    public void Delete()
    {
        Console.WriteLine("Deleting existing Product");
        Console.WriteLine("-----------------------");
    }
    public void Show()
    {
        var cats = _categoryService.GetAll();
        Console.WriteLine("Product List");
        Console.WriteLine("-------------------------------------");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(Category.Header);
        Console.ResetColor();
        Console.WriteLine("-------------------------------------");
        foreach (var cat in cats)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine($"|   {cat.CategoryId,(-7)}  | {cat.CategoryName,(-20)} |");
            Console.ResetColor();
        }
            Console.WriteLine("-------------------------------------");
    }
}
