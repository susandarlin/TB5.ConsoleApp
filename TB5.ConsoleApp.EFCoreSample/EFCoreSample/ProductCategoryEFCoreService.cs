using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TB5.ConsoleApp.Database.AppDbContextModels;

namespace TB5.ConsoleApp.EFCoreSample.EFCoreSample;

public class ProductCategoryEFCoreService
{
    private readonly AppDbContext db = new AppDbContext();

    public void Read()
    {
        List<TblProductCategory> lst = db.TblProductCategories.ToList();

        foreach (TblProductCategory item in lst)
        {
            Console.WriteLine(item.ProductCategoryId);
            Console.WriteLine(item.ProductCategoryName);
        }
    }

    public void Edit()
    {
        var item = db.TblProductCategories.Where(p => p.ProductCategoryId == 1).FirstOrDefault();
        if (item is null)
        {
            Console.WriteLine("Product Category  not found.");
            return;
        }

        Console.WriteLine(item.ProductCategoryId);
        Console.WriteLine(item.ProductCategoryName);
    }

    public void Create()
    {
        var item = new TblProductCategory
        {
            ProductCategoryName = "Electronics"
        };

        db.TblProductCategories.Add(item);
        int result = db.SaveChanges();

        var message = result > 0 ? "Product Category created successfully." : "Failed to create Product Category.";
        Console.WriteLine(message);
    }

    public void Update()
    {
        var item = db.TblProductCategories.Where(p => p.ProductCategoryId == 1).FirstOrDefault();
        if (item is null)
        {
            Console.WriteLine("Product Category  not found.");
            return;
        }

        item.ProductCategoryName = "Updated Electronics";
        int result = db.SaveChanges();

        var message = result > 0 ? "Product Category updated successfully." : "Failed to update Product Category.";
        Console.WriteLine(message);
    }

    public void Delete()
    {
        var item = db.TblProductCategories.Where(p => p.ProductCategoryId == 1).FirstOrDefault();
        if (item is null)
        {
            Console.WriteLine("Product Category  not found.");
            return;
        }

        db.TblProductCategories.Remove(item);
        int result = db.SaveChanges();

        var message = result > 0 ? "Product Category deleted successfully." : "Failed to delete Product Category.";
        Console.WriteLine(message);
    }
}
