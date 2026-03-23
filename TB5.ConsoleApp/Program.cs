// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using TB5.ConsoleApp.AdoDotNetSample;

Console.WriteLine("Hello, World!");
SqlConnection conn = new SqlConnection("");

AdoDonetService service = new AdoDonetService();
//service.Create();
service.Read();
//service.Delete();
//service.Edit();
//service.Update();