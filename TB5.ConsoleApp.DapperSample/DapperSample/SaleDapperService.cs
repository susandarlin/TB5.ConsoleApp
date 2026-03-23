using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace TB5.ConsoleApp.DapperSample.DapperSample
public class SaleDapperService
{
    private string connectionString = "Data Source=.;Initial Catalog=Batch5MiniPOS;User ID=sa;Password=sasa@123;Trust Server Certificate=True;";

    public void Create()
    {
        string query = @"INSERT INTO [dbo].[Tbl_Sale]
           ([ProductId]
           ,[Price]
           ,[Quantity]
           ,[SaleDate])
     VALUES
           (@ProductId
           ,@Price
           ,@Quantity
           ,@SaleDate)";

        using IDbConnection connection = new SqlConnection(connecttionString);
        connection.Open();

        int result = connection.Execute(query, new
        {
            ProductId = 1,
            Price = 2000,
            Quantity = 2,
            SaleDate = DateTime.Now
        });

        string message = result > 0 ? "Sale created Successfully!" : "Fail to create Sale";
        Console.WriteLine(message);
    }

    public void Read()
    {
        string query = "SELECT * FROM Tbl_Sales";
        using IDbConnection connection = new SqlConnection(connectionString);
        connection.Open();

        List<TblSale> lst = connection.Query<TblSale>(query).ToList();
        foreach (TblSale item in lst)
        {
            Console.WritetLine($"SaleId : {item.SaleId}, ProductId : {item.ProductId}, Price : {item.Price}, Quantity : {item.Quantity}, SaleDate : {item.SaleDate} ");
        }
    }

    public void Edit()
    {
        string query = "SELECT * from Tbl_Sale WHERE SaleId = @SaleId";

        using IDbConnection connection = new SqlConnection(connectionString);
        connection.Open();

        var item = connection.Query<TblSale>(query, new
        {
            SaleId = 1
        }).FirstOrDefault();

        if (item is null)
        {
            Console.WriteLine("Sale not found");
            return;
        }

        Console.WritetLine($"SaleId : {item.SaleId}, ProductId : {item.ProductId}, Price : {item.Price}, Quantity : {item.Quantity}, SaleDate : {item.SaleDate} ");
    }

    public void Update()
    {
        string query = @"UPDATE [dbo].[Tbl_Sale]
            SET [ProductId] = @ProductId,
            [Price] = @Price,
            [Quantity] = @Quantity,
            [SaleDate] = @SaleDate
            WHERE SaleId = @SaleId";

        using IDbConnection connection = new SqlConnection(connectionString);
        connection.Open();

        int result = connection.Execute(query, new
        {
            SaleId = 1,
            ProductId = 1,
            Price = 2000,
            Quantity = 2,
            SaleDate = DateTime.Now
        })
        
        string message = result > 0 ? "Sale updated successfully." : "Failed to update sale.";
        Console.WriteLine(message);   
    }

    public void Delete()
    {
        string query = "DELETE FROM Tbl_Sale WHERE SaleId = @SaleId";

        using IDbConnection connection = new SqlConnection(connectionString);
        connection.Open();

        var item = connection.Execute<TblSale>(query, new
        {
            SaleId = 1
        });

        string message = result > 0 ? "Sale deleted successfully." : "Failed to delete sale.";
    }

    public class TblSale
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public DateTime SaleDate { get; set; }
    }
}
