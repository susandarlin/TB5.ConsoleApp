// See https://aka.ms/new-console-template for more information
using TB5.ConsoleApp.DapperSample.DapperSample;

Console.WriteLine("Hello, World!");

//DapperService service = new DapperService());
//service.Create();
//service.Read();
//service.Edit();
//service.Update();
//service.Delete();

//SaleDapperService saleService = new SaleDapperService();
//saleService.Create();
//saleService.Read();
//saleService.Edit();
//saleService.Update();
//saleService.Delete();

ProductCategoryDapperService productService = new ProductCategoryDapperService();
productService.Create();
productService.Read();
productService.Edit();
productService.Update();
productService.Delete();




