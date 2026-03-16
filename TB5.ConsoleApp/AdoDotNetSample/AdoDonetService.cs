using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TB5.ConsoleApp.AdoDotNetSample;

public class AdoDonetService
{

    private string connectionString = "Server=SANDAR\\MSSQLSERVER2022;Database=Batch5MiniPOS;User Id=sa;Password=admin123!;TrustServerCertificate=True";

    public void Create()
    {
        using SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        string query = @"INSERT INTO Tbl_Product (Code,Name,Price)
                         VALUES (@Code,@Name,@Price)";

        using SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Code", "P006");
        cmd.Parameters.AddWithValue("@Name", "Stawberry");
        cmd.Parameters.AddWithValue("@Price", "5000");

        cmd.ExecuteNonQuery();

        Console.WriteLine("Product inserted successfully");
    }

    public void Read()
    {
        string query = "SELECT * FROM Tbl_Product";

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand(query, connection);
        DataTable dt = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(dt);

        connection.Close();

        foreach (DataRow row in dt.Rows)
        {
            int id = Convert.ToInt32(row["Id"]);
            string name = row["Name"].ToString();
            decimal price = Convert.ToDecimal(row["Price"]);

            Console.WriteLine($"Id: {id}, Name: {name}, Price: {price}");
        }
    }

    public void Edit()
    {
        string query = "SELECT * FROM Tbl_Product Where Id=@Id;";

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Id", 2);

        DataTable dt = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(dt);

        connection.Close();

        if (dt.Rows.Count == 0)
        {
            Console.WriteLine("Product not found.");
            return;
        }

        DataRow row = dt.Rows[0];
        int id = Convert.ToInt32(row["Id"]);
        string name = row["Name"].ToString()!;
        decimal price = Convert.ToDecimal(row["Price"]);

        Console.WriteLine($"Id: {id}, Name: {name}, Price: {price}");
    }

    public void Update()
    {
        string query = @"UPDATE [dbo].[Tbl_Product]
SET [Name] = @Name,
    [Price] = @Price
WHERE Id = @Id";

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Id", 3);
        cmd.Parameters.AddWithValue("@Name", "Orange");
        cmd.Parameters.AddWithValue("@Price", 1000);

        int result = cmd.ExecuteNonQuery();

        connection.Close();

        string message = result > 0 ? "Product updated successfully." : "Failed to update product.";
        Console.WriteLine(message);
    }

    public void Delete()
    {
        string query = @"DELETE FROM [dbo].[Tbl_Product]
                     WHERE Id = @Id";

        SqlConnection connection = new SqlConnection(connectionString);
        connection.Open();

        SqlCommand cmd = new SqlCommand(query, connection);
        cmd.Parameters.AddWithValue("@Id", 1);

        int result = cmd.ExecuteNonQuery();

        connection.Close();

        string message = result > 0 ? "Product deleted successfully." : "Failed to delete product.";
        Console.WriteLine(message);
    }

}

public class Tbl_Product
{
    public int ID { get; set; }

    public string Code { get; set; }

    public string Name { get; set; }

    public decimal Price { get; set; }
}

public class Tbl_Sales
{
    public int SaleId { get; set; }

    public int ProductId { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public DateTime SaleDate { get; set; }
}