using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB5.ConsoleApp.Database.AppDbContextModels;

namespace TB5.ConsoleApp.EFCoreSample.EFCoreSample;

public class EFCoreService
{
    private readonly AppDbContext db = new AppDbContext();

    public void Read()
    {
        List<TblProduct> lst = db.TblProducts.ToList();

        foreach (TblProduct item in lst)
        {
            Console.WriteLine(item.Id);
            Console.WriteLine(item.Name);
            Console.WriteLine(item.Price);
        }
    }

    public void Edit()
    {
        TblProduct product = db.TblProducts.Where(p => p.Id == 1).FirstOrDefault()!;
        if (product is null)
        {
            Console.WriteLine("Product not found.");
            return;
        }

        Console.WriteLine(product.Id);
        Console.WriteLine(product.Name);
        Console.WriteLine(product.Price);
    }
    public void Create()
    {
        TblProduct product = new TblProduct
        {
            Name = "Grape",
            Price = 5000
        };

        db.TblProducts.Add(product);
        int result = db.SaveChanges();

        string message = result > 0 ? "Product created successfully." : "Failed to create product.";
        Console.Write(message);
    }

    public void Update()
    {
        TblProduct product = db.TblProducts.Where(p => p.Id == 1).FirstOrDefault();

        if (product is null)
        {
            Console.WriteLine("Product not found.");
            return;
        }

        product.Price = 6000;
        int result = db.SaveChanges();
        string message = result > 0 ? "Product updated successfully." : "Failed to update product.";
        Console.WriteLine(message);
    }
    public void Delete()
    {
        TblProduct product = db.TblProducts.Where(p => p.Id == 1).FirstOrDefault()!;
        if (product is null)
        {
            Console.WriteLine("Product not found.");
            return;
        }
        db.TblProducts.Remove(product);
        int result = db.SaveChanges();

        string message = result > 0 ? "Product deleted successfully." : "Failed to delete product.";
        Console.WriteLine(message);
    }
}
