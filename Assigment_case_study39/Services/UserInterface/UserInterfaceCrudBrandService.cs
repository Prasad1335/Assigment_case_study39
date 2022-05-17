using Day39CaseStudy.DataAccess.Models;
using Day39CaseStudy.Services.DbService.Interfaces;
using Day39CaseStudy.Services.Factory;

namespace Day39CaseStudy.Services.UserInterface;

public class UserInterfaceCrudBrandService
{
    readonly ICrudService<Brand> _brandService; // LOOSELY BOUND. VERY GOOD

    public UserInterfaceCrudBrandService()
    {
        _brandService = CrudFactory.Create<Brand>();
    }

    public void Add()
    {
        Console.WriteLine("Adding New Brand");
        Console.WriteLine("----------------");

        Console.Write("Enter Brand Name: >> ");
        var brandNameText = Console.ReadLine();

        var brand = new Brand { BrandName = brandNameText };
        _brandService.Add(brand);
    }

    public IEnumerable<Brand> GetAll()
    {
        return _brandService.GetAll();
    }

    public void Update()
    {
        Console.WriteLine("Updating existing Brand");
        Console.WriteLine("-----------------------");

        Console.Write("Enter Brand Name to Update: ");
        var brandNameText = Console.ReadLine();

        var brand = _brandService.GetByName(brandNameText);

        if (brand == null)
        {
            Console.WriteLine($"Brand Name {brandNameText} not found!!");
            return;
        }

        Console.WriteLine($"Found Brand: {brand}");

        Console.Write("Enter Brand Name to change: ");
        var changedBrandNameText = Console.ReadLine();

        brand.BrandName = changedBrandNameText;
        _brandService.Update(brand);
    }
    public void Delete()
    {
        Console.WriteLine("Deleting existing Brand");
        Console.WriteLine("-----------------------");

        Console.Write("Enter the Brand Id to delete: >> ");
        var brandIdText = Console.ReadLine();

        var brandId = int.Parse(brandIdText);

        try
        {
            _brandService.Delete(brandId);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Delete Brand Failed!! {ex.Message}");
            Console.ResetColor();
        }
    }

    public void Show()
    {
        var brands = _brandService.GetAll();
        Console.WriteLine("-----------------------------");
        Console.WriteLine("|          Brand List       |");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("-----------------------------");
        Console.WriteLine(Brand.Header);
        Console.WriteLine("-----------------------------");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkRed;

        foreach (var brand in brands)
        {
            Console.WriteLine(brand);
            Console.WriteLine("-----------------------------");

        }
        Console.ResetColor();
    }
}
