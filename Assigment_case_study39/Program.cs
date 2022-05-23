using Day39CaseStudy.Services.Menu;
using Day39CaseStudy.Services.UserInterface;

Console.WriteLine("***************************************************** WELCOME **********************************************");

IMenuService menuService = new MenuService();
var uiBrandService = new UserInterfaceCrudBrandService();
var uiProductService = new UserInterfaceCrudProductService();
var uiCategoryService = new UserInterfaceCrudCategoryService();

do
{
    var menuOptions = menuService.Show();

    switch (menuOptions)
    {
        case MenuOptions.Exit:
            return;
        case MenuOptions.BrandAdd:
           await uiBrandService.AddAsync();
            break;
        case MenuOptions.BrandUpdate:
           await uiBrandService.UpdateAsync();
            break;
        case MenuOptions.BrandDelete:
           await uiBrandService.DeleteAsync();
            break;
        case MenuOptions.BrandShow:
          await uiBrandService.Show();
            break;
        case MenuOptions.ProductAdd:
            await uiProductService.AddAsync();
            break;
        case MenuOptions.ProductUpdate:
            await uiProductService.UpdateAsync();
            break;
        case MenuOptions.ProductDelete:
            await uiProductService.DeleteAsync();
            break;
        case MenuOptions.ProductShow:
            await uiProductService.Show();
            break;
        case MenuOptions.CategoryAdd:
            await uiCategoryService.AddAsync();
            break;
        case MenuOptions.CategoryUpdate:
            await uiCategoryService.UpdateAsync();
            break;
        case MenuOptions.CategoryDelete:
            await uiCategoryService.DeleteAsync();
            break;
        case MenuOptions.CategoryShow:
            await uiCategoryService.Show();
            break;
    }
} while (true);