// See https://aka.ms/new-console-template for more information
using TB5.ConsoleApp.EFCoreSample.EFCoreSample;

Console.WriteLine("Hello, World!");

//EFCoreService service = new EFCoreService();
//service.Create();
//service.Read();
//service.Update();
//service.Edit();
//service.Delete();

ProductCategoryEFCoreService productCategoryService = new ProductCategoryEFCoreService();
productCategoryService.Create();
productCategoryService.Read();
productCategoryService.Update();
productCategoryService.Edit();
productCategoryService.Delete();
