using System;
using System.Collections.Generic;

namespace TB5.ConsoleApp.EFCoreSample.EFCOreSample
public class SaleDapperService
{
	private readonly AppDbContext db = new AppDbContext();

	public void Read()
	{
		List<TblSale> lst = db.TblSales.ToList();

		foreach(TblSale item in lst)
		{
			Console.WriteLine(item.SaleId);
            Console.WriteLine(item.ProductId);
            Console.WriteLine(item.Price);
            Console.WriteLine(item.Quantity);
            Console.WriteLine(item.SaleDate);
        }
	}

	public void Edit()
	{
		TblSale? itemSale = db.TblSales.where(x=>x.SaleId == 1).FirstOrDefault();
		if(itemSale is null)
		{
			Console.WriteLine("Sale not found!");
			return;
		}
		Console.WriteLine(itemSale.SaleId);
        Console.WriteLine(itemSale.ProductId);
        Console.WriteLine(itemSale.Price);
        Console.WriteLine(itemSale.Quantity);
        Console.WriteLine(itemSale.SaleDate);
    }

	public void Create()
	{
		TblSale sale = new TblSale()
		{
            ProductId = 1,
			Price = 1000,
			Quantity = 5,
			SaleDate = DateTime.Now,
        }
		db.TblSales.Add(sale);
		int result = db.SaveChanges();
        string message = result > 0 ? "Sale created successfully." : "Failed to create sale.";
        Console.WriteLine(message);
    }

	public void Update()
	{
		TblSale? itemSale = db.TblSales.where(x=>x.SaleId == 1).FirstOrDefault();
		if(itemSale is null)
		{
			Console.WriteLine("Sale not found!");
		    return;
		}
		itemSale.Price = 1800
		int result = db.SaveChanges();
        string message = result > 0 ? "Sale updated successfully." : "Failed to update sale.";
        Console.WriteLine(message);
    }

	public void Delete()
	{
		TblSale? itemSale = db.TblSales.where(x=>x.SaleId == 1).FirstOrDefault();
		if(itemSale is null)
		{
			Console.WriteLine("Sale not found!");
		}
		db.TblSales.Remove(itemSale);
		int result = db.SaveChanges();
        tring message = result > 0 ? "Sale deleted successfully." : "Failed to delete sale.";
        Console.WriteLine(message);
    }
}
